using ProvaWeek1Academy_Core.Entities;
using ProvaWeek1Academy_Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek1Academy.Mock
{
    public class RepositoryProdottiAlimentariFile : IRepositoryProdottiAlimentari
    {
        string path = @"C:\Users\Federica\Desktop\AcademyWeek1\ProvaWeek1Academy\ProvaWeek1Academy.Mock\ProdottiAlimentari.txt";
        public bool Add(ProdottoAlimentare item)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{item.Codice}, {item.Descrizione}, {item.Prezzo}, {item.QuantitaMagazzino}, {item.DataScadenza}");
            }
            return true;
        }

        public List<ProdottoAlimentare> GetAll()
        {
            List<ProdottoAlimentare> listaAlimenti = new List<ProdottoAlimentare>();
            using (StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = sr.ReadToEnd();
                if (string.IsNullOrEmpty(contenutoFile))// (contenutoFile == null || contenutoFile == "")
                {
                    return listaAlimenti;
                }
                else
                {
                    var righeFile = contenutoFile.Split("\r\n");
                    for (int i = 0; i < righeFile.Length - 1; i++)
                    {
                        var campiRiga = righeFile[i].Split(",");
                        ProdottoAlimentare a = new ProdottoAlimentare();
                        a.Codice = campiRiga[0];
                        a.Descrizione = campiRiga[1];
                        a.Prezzo = double.Parse(campiRiga[2]);
                        a.QuantitaMagazzino = int.Parse(campiRiga[3]);
                        a.DataScadenza = DateTime.Parse(campiRiga[4]);
                        listaAlimenti.Add(a);
                    }
                }
                return listaAlimenti;
            }
        }

        public ProdottoAlimentare GetByCode(string code)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = sr.ReadToEnd();
                var righeFile = contenutoFile.Split("\r\n");
                for (int i = 0; i < righeFile.Length; i++)
                {
                    var campiRiga = righeFile[i].Split(",");
                    ProdottoAlimentare a = new ProdottoAlimentare();
                    a.Codice = campiRiga[0];
                    a.Descrizione = campiRiga[1];
                    a.Prezzo = double.Parse(campiRiga[2]);
                    a.QuantitaMagazzino = int.Parse(campiRiga[3]);
                    a.DataScadenza = DateTime.Parse(campiRiga[4]);
                    if (campiRiga[0] == code)
                    {
                        return a;
                    }
                }
                return null;
            }
        }
    }
}
