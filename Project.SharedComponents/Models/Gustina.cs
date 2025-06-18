namespace MudAnalizaFI.Client.Models
{
    public class Gustina
    {
        public int Id { get; set; }

        public double Vrednost { get; set; }
        
        public string? Opis { get; set; }
        public virtual ICollection<Element> Elementi { get; set; }
    }
}
