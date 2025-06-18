namespace Shared
{
    public class Paket
    {
        public int Id { get; set; }
        public string SifraPaketa { get; set; }
        public double Duzina { get; set; }
        public double Sirina { get; set; }
        public double Visina { get; set; }

        public virtual ICollection<Element>? Elementi { get; set; }
    }
}
