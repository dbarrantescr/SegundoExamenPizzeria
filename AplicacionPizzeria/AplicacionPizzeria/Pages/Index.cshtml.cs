using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacionPizzeria.Controlador;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicacionPizzeria.Pages
{
    public class IndexModel : PageModel
    {
        ControladorPizzeria controlador;
        public string mensajeRetroalimentacion = null;

        public void OnGet()
        {
            this.mensajeRetroalimentacion = null;
        }

        public void OnPost()
        {
            controlador = new ControladorPizzeria();

            List<string> ingredientes = new List<string>();
            recolectarIngredientes(ingredientes);
            string tamaño = Request.Form["tamaño"];
            string direccion = Request.Form["direccionPedido"];

            if (tamaño == null || direccion == "")
            {
                mensajeRetroalimentacion = crearMensajeError(tamaño, direccion);
            }
            else
            {
                controlador.ElegirTamañoPizza(tamaño);
                controlador.ElegirToppingsPizza(ingredientes);

                double precioAPagar = calcularPrecioTotal(tamaño);

                mensajeRetroalimentacion = construirMensajeRetroAlimentacion(tamaño, direccion, ingredientes, precioAPagar);
            }          
        }

        public void recolectarIngredientes(List<string> ingredientes)
        {
            ingredientes.Add(Request.Form["Queso"]);
            ingredientes.Add(Request.Form["Salsa"]);
            ingredientes.Add(Request.Form["Jamon"]);
            ingredientes.Add(Request.Form["Peperoni"]);
            ingredientes.Add(Request.Form["Hongos"]);
            ingredientes.Add(Request.Form["Cebolla"]);
            ingredientes.Add(Request.Form["Chile"]);
            ingredientes.Add(Request.Form["Tocineta"]);
            ingredientes.Add(Request.Form["Olivas"]);
            ingredientes.Add(Request.Form["Piña"]);

            ingredientes.RemoveAll(ingrediente => ingrediente == null);
        }

        public string crearMensajeError(string tamaño, string direccion)
        {
            string mensaje = "";
            if (tamaño == null && direccion == "")
            {
                mensaje = "Por favor seleccione un tamaño de pizza e ingrese una dirección de envío.";
                return mensaje;
            }

            if (tamaño == null)
            {
                mensaje = "Por favor seleccione un tamaño de pizza.";
                return mensaje;
            }

            if (direccion == "")
            {
                mensaje = "Por favor ingrese una dirección de envío.";
                return mensaje;
            }
            return mensaje;
        }

        public string listaToppingsAString(List<string> ingredientes)
        {
            string toppings = "";

            foreach (string ingrediente in ingredientes)
            {
                toppings = toppings + " ";
                toppings = toppings + ingrediente +",";

                if (ingrediente == ingredientes.Last())
                    toppings = toppings.Remove(toppings.Length - 1, 1) + ".";
            }
            return toppings;
        }

        public string construirMensajeRetroAlimentacion(string tamaño, string direccion, List<string> ingredientes, double precioAPagar)
        {
            string mensaje = "";
            if (tamaño == null)
            {
                mensaje = "Por favor, seleccione un tamaño de pizza";
                return mensaje;
            }

            if (direccion == null)
            {
                mensaje = "Por favor, ingrese una dirección de envío";
                return mensaje;
            }                        

            string listaToppings = listaToppingsAString(ingredientes);

            if(ingredientes.Count() > 0)
                mensaje = "Su pedido se ha efectuado! \n Pizza " + tamaño + " con:" + listaToppings + " Se entregara a la dirección: " + direccion + ". Con un costo de: " + precioAPagar + "₡ IVA incluido. Costo de envío 1000₡ (incluído)";
            else
                mensaje = "Su pedido se ha efectuado! \n Pizza " + tamaño + ". Se entregara a la dirección: " + direccion + ". Con un costo de: " + precioAPagar + " IVA incluido. Costo de envío 1000₡ (incluído)";

            return mensaje;
        }

        public double calcularPrecioTotal(string tamaño)
        {
            double precioAPagar = 0;
            precioAPagar = precioAPagar + controlador.CalcularPrecioBasePizza(tamaño);
            precioAPagar = precioAPagar + controlador.CalcularPrecioToppings();
            precioAPagar = precioAPagar + controlador.CalcularPrecioEnvio();
            precioAPagar = controlador.AgregarImpuesto(precioAPagar);

            return precioAPagar;
        }       
    }
}
