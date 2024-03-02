namespace PoliziaMunicipaleContext.ViewModels
{
    public class DettaglioComunicazioneViewModel
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string Cod_Fisc { get; set; }
        public string Violazione { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public int IDAgente { get; set; }
        public DateTime DataTrascrizione { get; set; }
        public decimal Importo { get; set; }
        public byte DecurtamentoPunti { get; set; }
    }
}
