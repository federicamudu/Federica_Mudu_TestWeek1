using ProvaWeek1Academy_Core.Entities;
using ProvaWeek1Academy_Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek1Academy.Mock
{
    public class RepositoryProdottiTecnologiciMock : IRepositoryProdottiTecnologici
    {
        private static List<ProdottoTecnologico> listaTecnologici = new List<ProdottoTecnologico>() 
        {
            new ProdottoTecnologico{Codice ="T123", Descrizione ="TV Monitor", Prezzo= 120.00, IsNuovo= true, Marca="ASUS"},
            new ProdottoTecnologico{Codice ="T456", Descrizione ="Xiaomi Redmi Note7", Prezzo= 180.00, IsNuovo= true, Marca="Xiaomi"},
            new ProdottoTecnologico{Codice ="T789", Descrizione ="Mouse Locitech x2", Prezzo= 70.00, IsNuovo= false, Marca="Logitech"},
            new ProdottoTecnologico{Codice ="T012", Descrizione ="PC Laptop", Prezzo= 340.00, IsNuovo= true, Marca="Lenovo"}
        };
        public bool Add(ProdottoTecnologico item)
        {
            if (item == null)
            {
                return false;
            }
            listaTecnologici.Add(item);
            return true;
        }

        public List<ProdottoTecnologico> GetAll()
        {
            return listaTecnologici;
        }

        public List<ProdottoTecnologico> GetByBrand(string marca)
        {
            List<ProdottoTecnologico> listaFiltrataBrand = new List<ProdottoTecnologico>();
            foreach (var item in listaTecnologici)
            {
                if (item.Marca == marca)
                {
                    listaFiltrataBrand.Add(item);
                }
            }
            return listaFiltrataBrand;
        }

        public ProdottoTecnologico GetByCode(string code)
        {
            foreach (var item in listaTecnologici)
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
