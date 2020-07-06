using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPizzeria.Modelos
{
    public class ModeloPizza
    {
        //Posibles atributos de la pizza
        public string Tamaño { get; set; }
        public bool Queso { get; set; }
        public bool Salsa { get; set; }
        public bool Jamon { get; set; }
        public bool Peperoni { get; set; }
        public bool Hongos { get; set; }
        public bool Cebolla { get; set; }
        public bool Chile { get; set; }
        public bool Tocineta { get; set; }
        public bool Olivas { get; set; }
        public bool Piña { get; set; }
    }
}
