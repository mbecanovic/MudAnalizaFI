namespace MudAnalizaFI.Client.Models
{
    public class Element
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public double Duzina { get; set; }
        public double Sirina { get; set; }
        public double Visina { get; set; }

        public int GustinaId { get; set; }
        public virtual Gustina Gustina { get; set; }

        public int PaketId { get; set; }
        public virtual Paket Paket { get; set; }
    }
}
