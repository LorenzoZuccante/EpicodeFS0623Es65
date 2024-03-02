namespace PoliziaMunicipale.Data.ViewModels
{
    public class ViolazioniMaggioriDiDieciPuntiViewModel
    {
        public string CognomeTrasgressore { get; set; }
        public string NomeTrasgressore { get; set; }
        public DateTime DataViolazione { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
    }
}
