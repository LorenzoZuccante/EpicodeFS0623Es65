using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PoliziaMunicipaleContext.Data; 

public class ViolazioniController : Controller
{
    private readonly PoliziaMunicipaleContext.Data.PoliziaMunicipaleContext _context;

    public ViolazioniController(PoliziaMunicipaleContext.Data.PoliziaMunicipaleContext context)
    {
        _context = context;
    }

    // GET: Violazioni
    public IActionResult Index()
    {
        var violazioni = _context.Violazione.ToList();
        return View(violazioni);
    }
}
