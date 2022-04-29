using ProvaWeek1Academy.Mock;
using ProvaWeek1Academy_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek1Academy.Presentation
{
    internal class InterazioneUtente
    {
        //static RepositoryProdottiAlimentariMock pAlim = new RepositoryProdottiAlimentariMock();
        static RepositoryProdottiAlimentariFile pAlim = new RepositoryProdottiAlimentariFile();
        //static RepositoryProdottiTecnologiciMock pTecn = new RepositoryProdottiTecnologiciMock();
        static RepositoryProdottiTecnologiciFile pTecn = new RepositoryProdottiTecnologiciFile();
        internal static void Start()
        {
            bool continua = true;
            while (continua)
            {
                int scelta = Menu();
                continua = AnalizzaScelta(scelta);
            }
        }

        internal static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaTuttiProdotti();
                    break;
                case 2:
                    VisualizzareAlimentari();
                    break;
                case 3:
                    VisualizzareTecnologici();
                    break;
                case 4:
                    AggiungereTecnologico();
                    break;
                case 5:
                    AggiungereAlimentare();
                    break;
                case 6:
                    CercareAlimentareCodice();
                    break;
                case 7:
                    CercareTecnologicoMarca();
                    break;
                case 8:
                    VisualizzareTecnologiciNuovi();
                    break;
                case 9:
                    VisualizzareAlimentariScadenzaOggi();
                    break;
                case 10:
                    VisualizzareAlimentariScadonoMenoTreGiorni();
                    break;
                case 0:
                    Console.WriteLine("Arrivederici");
                    return false;
                default:
                    break;
            }
            return true;
        }

        private static void VisualizzareAlimentariScadonoMenoTreGiorni()
        {
            var listaAlimentariRecuperata = pAlim.GetAll();
            foreach (var item in listaAlimentariRecuperata)
            {
                if (item.GiorniMancantiScadenza <= 3)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void VisualizzareAlimentariScadenzaOggi()
        {
            var listaAlimentariRecuperata = pAlim.GetAll();        
            foreach (var item in listaAlimentariRecuperata)
            {
                if(item.GiorniMancantiScadenza == 0)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void VisualizzareTecnologiciNuovi()
        {
            var listaTecnologiciRecuperata = pTecn.GetAll();
            foreach (var item in listaTecnologiciRecuperata)
            {
                if (item.IsNuovo == true)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void CercareTecnologicoMarca()
        {
            Console.WriteLine("Inserisci il brand da cercare:");
            var marca = Console.ReadLine();
            var listaTecnologiciRecuperata = pTecn.GetByBrand(marca);
            if (listaTecnologiciRecuperata == null)
            {
                Console.WriteLine("Non sono presenti prodotti tecnologici con questa marca");
            }
            else
            {
                Console.WriteLine(listaTecnologiciRecuperata.ToString());
            }
            
        }

        private static void CercareAlimentareCodice()
        {
            Console.WriteLine("Inserisci il codice da cercare:");
            var codice = Console.ReadLine();
            var listaAlimentariRecuperata = pAlim.GetByCode(codice);
            if(listaAlimentariRecuperata == null)
            {
                Console.WriteLine("Non sono presenti alimenti con questo codice");
            }
            else
            {
                Console.WriteLine(listaAlimentariRecuperata.ToString());
            }
            
        }

        private static void AggiungereAlimentare()
        {
            ProdottoAlimentare nuovoA = new ProdottoAlimentare();
            string codice;
            do
            {
                Console.WriteLine("Inserisci il codice del nuovo prodotto: ");
                codice= Console.ReadLine();
            } while (!(pAlim.GetByCode(codice) == null));
            Console.WriteLine("Inserisci la descrizione: ");
            var descrizione = Console.ReadLine();
            double prezzo;
            do
            {
                Console.WriteLine("Quanto costa il nuovo prodotto? ");
            } while (!double.TryParse(Console.ReadLine(), out prezzo));            
            int quantitaMagazzino;
            do
            {
                Console.WriteLine("Quanti prodotti di questo articolo ci sono in magazzino?");
            } while (!int.TryParse(Console.ReadLine(), out quantitaMagazzino));
            DateTime dataScadenza;
            do
            {
                Console.WriteLine("Quando scade? \n(inserisci il formato yyyy-mm-dd o dd-mm-yyyy)");
            } while (!(DateTime.TryParse(Console.ReadLine(), out dataScadenza) && dataScadenza > DateTime.Now));
            nuovoA.Codice = codice;
            nuovoA.Descrizione = descrizione;
            nuovoA.Prezzo = prezzo;
            nuovoA.QuantitaMagazzino = quantitaMagazzino;
            nuovoA.DataScadenza = dataScadenza;
            pAlim.Add(nuovoA);
        }

        private static void AggiungereTecnologico()
        {
            ProdottoTecnologico nuovoT = new ProdottoTecnologico();
            string codice;
            do
            {
                Console.WriteLine("Inserisci il codice del nuovo prodotto: ");
                codice = Console.ReadLine();
            } while (!(pTecn.GetByCode(codice) == null));
            Console.WriteLine("Inserisci la descrizione: ");
            var descrizione = Console.ReadLine();
            double prezzo;
            do
            {
                Console.WriteLine("Quanto costa il nuovo prodotto? ");
            } while (!double.TryParse(Console.ReadLine(), out prezzo));
            Console.WriteLine("Inserisci la marca: ");
            var marca = Console.ReadLine();
            Console.WriteLine("L'oggetto è nuovo?\nScrivere sì o no"); //TODO: cambiare da true a "nuovo" o viceversa nel ToString();
            var esito = Console.ReadLine();
            if (esito == "si")
            {
                nuovoT.IsNuovo = true;
            }
            else
            {
                nuovoT.IsNuovo = false;
            }
            nuovoT.Codice = codice;
            nuovoT.Descrizione = descrizione;
            nuovoT.Prezzo = prezzo;
            nuovoT.Marca = marca;
            pTecn.Add(nuovoT);
        }

        private static void VisualizzareTecnologici()
        {
            Console.WriteLine("Ecco i nostri prodotti tecnologici");
            var listaTecnologiciRecuperata = pTecn.GetAll();
            foreach (var item in listaTecnologiciRecuperata)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void VisualizzareAlimentari()
        {
            Console.WriteLine("Ecco i nostri prodotti alimentari");
            var listaAlimentariRecuperata = pAlim.GetAll();
            foreach (var item in listaAlimentariRecuperata)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void VisualizzaTuttiProdotti()
        {
            Console.WriteLine("Ecco tutti i nostri prodotti");
            var listaAlimentariRecuperata = pAlim.GetAll();
            var listaTecnologiciRecuperata = pTecn.GetAll();
            List<Prodotto> listaCompleta = new List<Prodotto>();
            listaCompleta.AddRange(listaAlimentariRecuperata);
            listaCompleta.AddRange(listaTecnologiciRecuperata);
            foreach (var item in listaCompleta)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static int Menu()
        {
            Console.WriteLine("***Menu***");
            Console.WriteLine("1. Visualizzare tutti i prodotti presenti in store;");
            Console.WriteLine("2. Visualizzare solo i prodotti Alimentari;");
            Console.WriteLine("3. Visualizzare solo i prodotti Tecnologici");
            Console.WriteLine("4. Aggiungere un nuovo Prodotto Tecnologico.");
            Console.WriteLine("5. Aggiungere un nuovo Prodotto Alimentare.");
            Console.WriteLine("6. Cercare un prodotto Alimentare per codice;");
            Console.WriteLine("7. Cercare un prodotto tecnologico per Marca;");
            Console.WriteLine("8. Visualizzare i Prodotti Tecnologici nuovi");
            Console.WriteLine("9. Visualizzare i prodotti alimentari in scadenza oggi");
            Console.WriteLine("10. Visualizzare i prodotti alimentari che scadono tra meno 3 giorni");
            Console.WriteLine("\n0. Exit");
            int sceltaUtente;
            do
            {
                Console.WriteLine("\nFai la tua scelta: ");
            } while (!(int.TryParse(Console.ReadLine(), out sceltaUtente) && sceltaUtente >= 0 && sceltaUtente <= 10));
            return sceltaUtente;
        }
    }
}
