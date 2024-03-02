using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoliziaMunicipale.Data.ViewModels;
using PoliziaMunicipaleContext.Data; 
using PoliziaMunicipaleContext.ViewModels; 
using System.Linq;
using System.Threading.Tasks;

namespace PoliziaMunicipale.Controllers
{
    public class QueryController : Controller
    {
        private readonly PoliziaMunicipaleContext.Data.PoliziaMunicipaleContext _context;

        public QueryController(PoliziaMunicipaleContext.Data.PoliziaMunicipaleContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public async Task<IActionResult> TotaleVerbaliPerTrasgressore()
        {
            var totaleVerbaliPerTrasgressore = await _context.Comunicazione
                .Include(c => c.Anagrafe) 
                .Include(c => c.Verbale) 
                .GroupBy(c => new { c.Anagrafe.IdAnagrafica, c.Anagrafe.Nome, c.Anagrafe.Cognome })
                .Select(group => new TotaleVerbaliPerTrasgressoreViewModel
                {
                    IdAnagrafica = group.Key.IdAnagrafica,
                    NomeTrasgressore = group.Key.Nome,
                    CognomeTrasgressore = group.Key.Cognome,
                    TotaleVerbali = group.Count()
                })
                .OrderByDescending(t => t.TotaleVerbali)
                .ToListAsync();

            return View(totaleVerbaliPerTrasgressore);
        }

        public async Task<IActionResult> TotalePuntiDecurtatiPerTrasgressore()
        {
            var totalePuntiPerTrasgressore = await _context.Comunicazione
                .Include(c => c.Anagrafe)
                .Include(c => c.Verbale)
                .GroupBy(c => new { c.Anagrafe.IdAnagrafica, c.Anagrafe.Nome, c.Anagrafe.Cognome })
                .Select(group => new TotalePuntiPerTrasgressoreViewModel
                {
                    IdAnagrafica = group.Key.IdAnagrafica,
                    NomeTrasgressore = group.Key.Nome,
                    CognomeTrasgressore = group.Key.Cognome,
                    TotalePuntiDecurtati = group.Sum(v => (int)v.Verbale.DecurtamentoPunti) 
                })
                .OrderByDescending(t => t.TotalePuntiDecurtati)
                .ToListAsync();

            return View(totalePuntiPerTrasgressore);
        }
        public async Task<IActionResult> DatiTrasgressorePerViolazioniMaggioriDi10Punti()
        {
            var violazioniMaggioriDiDieci = await _context.Verbale
                .Where(v => v.DecurtamentoPunti > 10)
                .Include(v => v.Comunicazioni)
                .ThenInclude(c => c.Anagrafe)
                .Select(v => new ViolazioniMaggioriDiDieciPuntiViewModel
                {
                    CognomeTrasgressore = v.Comunicazioni.FirstOrDefault().Anagrafe.Cognome,
                    NomeTrasgressore = v.Comunicazioni.FirstOrDefault().Anagrafe.Nome,
                    DataViolazione = v.DataViolazione,
                    Importo = v.Importo,
                    DecurtamentoPunti = v.DecurtamentoPunti
                })
                .OrderByDescending(v => v.DecurtamentoPunti)
                .ToListAsync();

            return View(violazioniMaggioriDiDieci);
        }
        public async Task<IActionResult> ViolazioniMaggioriDi400()
        {
            var violazioniMaggioriDiQuattrocento = await _context.Verbale
                .Where(v => v.Importo > 400)
                .Select(v => new ViolazioniMaggioriDiQuattrocentoViewModel
                {
                    IDVerbale = v.IDVerbale,
                    DataViolazione = v.DataViolazione,
                    IndirizzoViolazione = v.IndirizzoViolazione,
                    Importo = v.Importo,
                    DecurtamentoPunti = v.DecurtamentoPunti
                })
                .OrderByDescending(v => v.Importo)
                .ToListAsync();

            return View(violazioniMaggioriDiQuattrocento);
        }

    }
}
