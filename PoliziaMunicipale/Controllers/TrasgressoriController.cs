using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using PoliziaMunicipaleContext.Data;

public class TrasgressoriController : Controller
{
    private readonly PoliziaMunicipaleContext.Data.PoliziaMunicipaleContext _context;

    public TrasgressoriController(PoliziaMunicipaleContext.Data.PoliziaMunicipaleContext context)
    {
        _context = context;
    }

    // GET: Trasgressori
    public IActionResult Index()
    {
        var trasgressori = _context.Anagrafe.ToList();
        return View(trasgressori);
    }

    // GET: Trasgressori/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Trasgressori/Create
    [HttpPost]
    [ValidateAntiForgeryToken] 
    public async Task<IActionResult> Create([Bind("Cognome,Nome,Indirizzo,Citta,Cod_Fisc")] Anagrafe trasgressore)
    {
        if (ModelState.IsValid)
        {
            _context.Add(trasgressore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(trasgressore);
    }
}
