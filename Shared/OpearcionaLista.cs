using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared
{
    public class OperacionaLista
    {
        public int Id { get; set; }

        public int SifraPaketa { get; set; }
        public double DuzinaPaketa { get; set; }

        // Umesto Elementi sada koristimo TextFieldItem
        public virtual ICollection<TextFieldItem>? TextFieldItems { get; set; }
        //public virtual List<TextFieldItem>? TextFieldItems { get; set; }

        public double? BrzinaLinijeUMinuti { get; set; }

        public DateTime? DatumKreiranja { get; set; } = DateTime.UtcNow;
    }


    public class TextFieldItem
    {
        public int Id { get; set; }

        public int? Kvartal { get; set; }

        // Glavni element
        public int ElementId { get; set; }
        [NotMapped]
        public virtual Element? Element { get; set; } = null!;

        // Podelement (jedan-na-jedan)
        public int? PodElementId { get; set; }
        [NotMapped]
        public virtual Element? PodElementi { get; set; }

        public int? RedniBroj { get; set; }
        public double? Vreme { get; set; }

        // FK ka operacionoj listi
        public int OperacionaListaId { get; set; }
        public virtual OperacionaLista? OperacionaLista { get; set; }
    }



}
