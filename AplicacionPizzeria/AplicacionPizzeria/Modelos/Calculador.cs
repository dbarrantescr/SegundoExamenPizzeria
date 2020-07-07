using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPizzeria.Modelos
{
    public class Calculador
    {
        //Valores constantes utilizadas en calculos
        public const double ImpuestoDeVenta = 1.13;
        public const double CostoEnvio = 1000;
        public string DireccionEnvio = "";

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
        public double CalcularPrecioConImpuesto(double precioSinImpuesto)
        {
            return (precioSinImpuesto * ImpuestoDeVenta);
        }

        //Suma el precio correspondiente al topping enviado por parametro
        public double AgregarPrecioTopping(double precioPrevio, string topping)
        {
            return (precioPrevio + preciosToppings[topping]);
        }

        //Establece la direccion de entrega
        public void AgregarDireccion(string direccionEnvio)
        {
            this.DireccionEnvio = direccionEnvio;
        }

        public void QuitarDireccion()
        {
            this.DireccionEnvio = "";
        }
    }
}
