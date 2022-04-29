using ProvaWeek1Academy_Core.Entities;
using ProvaWeek1Academy_Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek1Academy.Mock
{
    public class RepositoryProdottiTecnologiciFile : IRepositoryProdottiTecnologici
    {
        string path = @"C:\Users\Federica\Desktop\AcademyWeek1\ProvaWeek1Academy\ProvaWeek1Academy.Mock\ProdottiTecnologici.txt";
        public bool Add(ProdottoTecnologico item)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{item.Codice}, {item.Descrizione}, {item.Prezzo}, {item.IsNuovo}, {item.Marca}");
            }
            return true;
        }

        public List<ProdottoTecnologico> GetAll()
        {
            List<ProdottoTecnologico> listaTecnologici = new List<ProdottoTecnologico>();
            using (StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = sr.ReadToEnd();
                if (string.IsNullOrEmpty(contenutoFile))// (contenutoFile == null || contenutoFile == "")
                {
                    return listaTecnologici;
                }
                else
                {
                    var righeFile = contenutoFile.Split("\r\n");
                    for (int i = 0; i < righeFile.Length - 1; i++)
                    {
                        var campiRiga = righeFile[i].Split(",");
                        ProdottoTecnologico t = new ProdottoTecnologico();
                        t.Codice = campiRiga[0];
                        t.Descrizione = campiRiga[1];
                        t.Prezzo = double.Parse(campiRiga[2]);
                        t.IsNuovo = bool.Parse(campiRiga[3]);
                        t.Marca = campiRiga[4];
                        listaTecnologici.Add(t);
                    }
                }
                return listaTecnologici;
            }
        }
        public List<ProdottoTecnologico> GetByBrand(string marca)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                List<ProdottoTecnologico> listaFiltrataBrand = new List<ProdottoTecnologico>();
                string contenutoFile = sr.ReadToEnd();
                var righeFile = contenutoFile.Split("\r\n");
                for (int i = 0; i < righeFile.Length; i++)
                {
                    var campiRiga = righeFile[i].Split(",");
                    ProdottoTecnologico t = new ProdottoTecnologico();
                    t.Codice = campiRiga[0];
                    t.Descrizione = campiRiga[1];
                    t.Prezzo = double.Parse(campiRiga[2]);
                    t.IsNuovo = bool.Parse(campiRiga[3]);
                    t.Marca = campiRiga[4];
                    if (campiRiga[4] == marca)
                    {
                        listaFiltrataBrand.Add(t);                        
                    }
                }
                return listaFiltrataBrand;
            }
        }

        public ProdottoTecnologico GetByCode(string code)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = sr.ReadToEnd();
                var righeFile = contenutoFile.Split("\r\n");
                for (int i = 0; i < righeFile.Length; i++)
                {
                    var campiRiga = righeFile[i].Split(",");
                    ProdottoTecnologico t = new ProdottoTecnologico();
                    t.Codice = campiRiga[0];
                    t.Descrizione = campiRiga[1];
                    t.Prezzo = double.Parse(campiRiga[2]);
                    t.IsNuovo = bool.Parse(campiRiga[3]);
                    t.Marca = campiRiga[4];
                    if (campiRiga[0] == code)
                    {
                        return t;
                    }
                }
                return null;
            }
        }
    }
}
