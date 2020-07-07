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
        public Dictionary<string, bool> Toppings = new Dictionary<string, bool>()
        {
            { "Queso", false },
            { "Salsa", false },
            { "Jamon", false },
            { "Peperoni", false },
            { "Hongos", false },
            { "Cebolla", false },
            { "Chile", false },
            { "Tocineta", false },
            { "Olivas", false },
            { "Piña", false }
        };

        //Asigna el tamaño de la pizza seleccionado
        public void AsignarTamañoPizza(string tamaño)
        {
            this.Tamaño = tamaño;
        }

        //Agrega un solo topping de la pizza selecionada
        public void AsignarToppingPizza(string topping)
        {
            this.Toppings[topping] = true;
        }

        //Asigna los toppings de la pizza seleccionado
        public void AsignarToppingsPizza(List<string> toppings)
        {
            foreach (string topping in toppings)
                this.Toppings[topping] = true;                             
        }

        //Quita un topping de la pizza
        public void QuitarTopping(string topping)
        {
            this.Toppings[topping] = false;
        }

        //Quita todos los toppings de una pizza
        public void QuitarToppings()
        {
            foreach (string topping in this.Toppings.Keys.ToList())
                Toppings[topping] = false;                    
        }

        //Asigna todos los toppings posibles a la pizza
        public void PonerTodosLosToppings()
        {
            foreach (string topping in this.Toppings.Keys.ToList())
                Toppings[topping] = true;
        }

        //Verifica si la pizza tiene algún topping específico
        public bool TieneTopping(string topping)
        {
            return this.Toppings[topping];
        }


        //Retorna el tamaño actualmente seleccionado para la pizza
        public string TamañoActualPizza()
        {
            return this.Tamaño;
        }
    }
}
