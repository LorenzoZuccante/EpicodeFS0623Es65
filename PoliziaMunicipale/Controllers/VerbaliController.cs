using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipaleContext.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

public class VerbaliController : Controller
{
    private readonly PoliziaMunicipaleContext.Data.PoliziaMunicipaleContext _context;

    public VerbaliController(PoliziaMunicipaleContext.Data.PoliziaMunicipaleContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var comunicazioni = await _context.Comunicazione
            .Include(c => c.Anagrafe)
            .Include(c => c.Verbale)
                .ThenInclude(verbale => verbale.Agente)
            .Include(c => c.Violazione)
            .Select(c => new
            {
                Nome = c.Anagrafe.Nome,
                Cognome = c.Anagrafe.Cognome,
                Indirizzo = c.Anagrafe.Indirizzo,
                Citta = c.Anagrafe.Citta,
                CodFisc = c.Anagrafe.Cod_Fisc,
                Violazione = c.Violazione.Descrizione,
                DataViolazione = c.Verbale.DataViolazione,
                IndirizzoViolazione = c.Verbale.IndirizzoViolazione,
                IDAgente = c.Verbale.IDAgente,
                DataTrascrizione = c.Verbale.DataTrascrizioneVerbale,
                Importo = c.Verbale.Importo,
                DecurtamentoPunti = c.Verbale.DecurtamentoPunti
            })
            .ToListAsync();

        return View(comunicazioni);
    }

    // GET: Verbali/Create
    public IActionResult Create()
    {
        
        return View();
    }

    // POST: Verbali/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("DataViolazione,IndirizzoViolazione,IDAgente,DataTrascrizioneVerbale,Importo,DecurtamentoPunti")] Verbale verbale)
    {
        if (ModelState.IsValid)
        {
            
            _context.Add(verbale);
            
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        
        return View(verbale);
    }

}
