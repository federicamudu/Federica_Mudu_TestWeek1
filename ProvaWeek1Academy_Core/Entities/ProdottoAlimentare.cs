using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek1Academy_Core.Entities
{
    public class ProdottoAlimentare : Prodotto
    {
        public int QuantitaMagazzino { get; set; }
        public DateTime DataScadenza { get; set; }
        public int GiorniMancantiScadenza { get { return GiorniMancantiAllaScadenza(); } }

        private int GiorniMancantiAllaScadenza()
        {
            var dataOggi = DateTime.Now;
            TimeSpan diff1 = DataScadenza.Subtract(dataOggi);
            var diffGiorni = diff1.Days;
            return diffGiorni;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nQuantità Magazzino: {QuantitaMagazzino}\nData di Scadenza: {DataScadenza.ToShortDateString().ToString()} - Giorni mancanti alla Scadenza: {GiorniMancantiScadenza}";
        }
    }
}
