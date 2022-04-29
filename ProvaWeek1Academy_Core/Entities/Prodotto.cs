using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek1Academy_Core.Entities
{
    public abstract class Prodotto
    {
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }
        public override string ToString()
        {
            return $"Codice: {Codice} - Prezzo: {Prezzo} euro\nDescrizione: {Descrizione}";
        }
    }
}
