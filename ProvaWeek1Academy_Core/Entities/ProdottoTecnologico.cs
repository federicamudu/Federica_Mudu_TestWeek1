using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek1Academy_Core.Entities
{
    public class ProdottoTecnologico : Prodotto
    {
        public string Marca { get; set; }
        public bool IsNuovo { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nMarca: {Marca} - Condizione: {IsNuovo}";
        }
    }
}
