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
        ControladorPizzeria controlador = new ControladorPizzeria();
        public string mensajeRetroalimentacion = null;

        public void OnGet()
        {

        }

        public void OnPost()
        {
            List<string> ingredientes = new List<string>();
            string Tamaño = Request.Form["tamaño"];
            string direccion = Request.Form["direccionPedido"];

            if(Tamaño == null || direccion == null)
                //Retornar mensaje de error

            controlador.ElegirTamañoPizza(Tamaño);

            if (ingredientes.Count() == 1)
                controlador.ElegirToppingPizza(ingredientes.First());
            else if (ingredientes.Count() > 1)
                controlador.ElegirToppingsPizza(ingredientes);

            double precioAPagar = controlador.CalcularPrecioBasePizza(Tamaño);
            precioAPagar =+ controlador.CalcularPrecioToppings();
            precioAPagar =+ controlador.AgregarPrecioEnvio();
            precioAPagar = controlador.AgregarImpuesto(precioAPagar);

            string listaToppings = listaToppingsAString(ingredientes);
            mensajeRetroalimentacion = "Su pedido se ha efectuado, pizza " + Tamaño +
            " con:" + listaToppings + " se entregara a la direccion:" + direccion;

        }

        public void recolectarDatos(List<string> ingredientes)
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

        public string listaToppingsAString(List<string> ingredientes)
        {
            string toppings = "";

            foreach (string ingrediente in ingredientes)
            {
                toppings = toppings + " ";
                toppings = toppings + ingrediente +",";
            }
            return toppings;
        }
    }
}
