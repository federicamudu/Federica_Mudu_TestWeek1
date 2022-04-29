using ProvaWeek1Academy_Core.Entities;
using ProvaWeek1Academy_Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek1Academy.Mock
{
    public class RepositoryProdottiAlimentariMock : IRepositoryProdottiAlimentari
    {
        private static List<ProdottoAlimentare> listaAlimentari = new List<ProdottoAlimentare>()
        {
            new ProdottoAlimentare{Codice = "A1234", Descrizione = "Pane Sardo", Prezzo= 1.20, QuantitaMagazzino= 10, DataScadenza= new DateTime(2022, 05,02)},
            new ProdottoAlimentare{Codice = "A5678", Descrizione = "Yogurt Greco", Prezzo= 1.50, QuantitaMagazzino= 20, DataScadenza= new DateTime(2022, 05, 20)},
            new ProdottoAlimentare{Codice = "A9012", Descrizione = "Patatine", Prezzo= 1.80, QuantitaMagazzino= 15, DataScadenza= new DateTime(2022, 08, 20)},
            new ProdottoAlimentare{Codice = "A9512", Descrizione = "Patatine", Prezzo= 1.80, QuantitaMagazzino= 15, DataScadenza= new DateTime(2022, 04, 29)}
        };
        public bool Add(ProdottoAlimentare item)
        {
            if (item == null)
            {
                return false;
            }
            listaAlimentari.Add(item);
            return true;
        }

        public List<ProdottoAlimentare> GetAll()
        {
            return listaAlimentari;
        }

        public ProdottoAlimentare GetByCode(string code)
        {
            foreach (var item in listaAlimentari)
            {
                if (item.Codice == code)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
