using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPizzeria.Modelos
{
    public class Calculador
    {
        //Valores constantes utilizadas en calculos
        public const double impuestoDeVenta = 1.13;
        public const double costoEnvio = 1000;

        public Dictionary<string, double> preciosToppings = new Dictionary<string, double>()
        {
            { "Queso", 450 },
            { "Salsa", 400 },
            { "Jamon", 700 },
            { "Peperoni", 700 },
            { "Hongos", 300 },
            { "Cebolla", 200 },
            { "Chile", 200 },
            { "Tocineta", 700 },
            { "Olivas", 250 },
            { "Piña", 300 }
        };

        public Dictionary<string, double> preciosBaseTamaño = new Dictionary<string, double>()
        {
            { "Pequeña", 2990 },
            { "Mediana", 4990 },
            { "Grande", 7990 },
            { "ExtraGrande", 9990 }
        };


        //Calcula el precio con impuesto incluido 
        public double calcularPrecioConImpuesto(double precioSinImpuesto)
        {
            return (precioSinImpuesto * impuestoDeVenta);
        }

        //Suma el precio correspondiente al topping enviado por parametro
        public double agregarTopping(double precioPrevio, string topping)
        {
            return (precioPrevio + preciosToppings[topping]);
        }
    }
}
