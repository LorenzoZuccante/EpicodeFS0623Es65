namespace PoliziaMunicipale.Data.ViewModels
{
    public class ViolazioniMaggioriDiQuattrocentoViewModel
    {
        public int IDVerbale { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
    }
}
