using AplicacionPizzeria.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionPizzeria.Controlador
{
    public class ControladorPizzeria
    {
        ModeloPizza ModeloPizza = new ModeloPizza();
        Calculador Calculador = new Calculador();

        //Establece el tamaño de la pizza seleccionado por el usuario
        public void ElegirTamañoPizza(string tamaño)
        {
            ModeloPizza.AsignarTamañoPizza(tamaño);
        }

        //Asigna los toppings elegidos por el usuario
        public void ElegirToppingsPizza(List<string> toppings)
        {
            ModeloPizza.AsignarToppingsPizza(toppings);
        }

        //Asigna un solo topping elegido por el usuario
        public void ElegirToppingPizza(string topping)
        {
            ModeloPizza.AsignarToppingPizza(topping);
        }

        //Remueve un topping de la pizza
        public void RemoverTopping(string topping)
        {
            ModeloPizza.QuitarTopping(topping);
        }

        //Remueve todos los toppings de la pizza
        public void RemoverTodosLosToppings()
        {
            ModeloPizza.QuitarToppings();
        }

        //Asigna todos los topings posibles a la pizza
        public void AsignarTodosLosToppings()
        {
            ModeloPizza.PonerTodosLosToppings();
        }

        //Retorna el precio base de la pizza según su tamaño  
        public double CalcularPrecioBasePizza(string tamaño)
        {
            return Calculador.preciosBaseTamaño[tamaño];
        }

        //Retorna el precio de la pizza más los toppings seleccionados
        public double CalcularPrecioToppings()
        {
            double precioToppings = 0;

            foreach (string topping in ModeloPizza.Toppings.Keys)
            {
                if (ModeloPizza.TieneTopping(topping))
                    precioToppings = precioToppings + Calculador.preciosToppings[topping];
            }
            return precioToppings;
        }

        //Consulta la selección actual del tamaño de la pizza
        public string ConsultarTamañoPizza()
        {
            return ModeloPizza.TamañoActualPizza();
        }

        //Se fija si la pizza tiene algún topping específico
        public bool ConsultarToppingPizza(string topping)
        {
            return ModeloPizza.TieneTopping(topping);
        }

        public double AgregarPrecioEnvio()
        {
            return Calculador.PrecioEnvio();
        }

        public double AgregarImpuesto(double precioSinImpuesto)
        {
            return Calculador.CalcularPrecioConImpuesto(precioSinImpuesto);
        }

    }
}
