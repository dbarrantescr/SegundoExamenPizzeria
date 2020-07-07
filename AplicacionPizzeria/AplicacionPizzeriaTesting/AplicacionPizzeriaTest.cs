using AplicacionPizzeria.Controlador;
using AplicacionPizzeria.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AplicacionPizzeriaTesting
{
    [TestClass]
    public class AplicacionPizzeriaTest
    {
        Calculador calculador = new Calculador();
        ModeloPizza modeloPizza = new ModeloPizza();
        ControladorPizzeria controlador = new ControladorPizzeria();

        [TestMethod]
        public void VerificarAgregoToppingSalsa()
        {
            string topping = "Salsa";
            modeloPizza.AsignarToppingPizza(topping);

            bool esperado = true;

            Assert.AreEqual(esperado, modeloPizza.TieneTopping(topping));
        }

        [TestMethod]
        public void DadoQuitarToppingDeHongos()
        {
            string topping = "Hongos";

            modeloPizza.AsignarToppingPizza(topping);
            modeloPizza.QuitarTopping(topping);

            bool esperado = false;

            Assert.AreEqual(esperado, modeloPizza.TieneTopping(topping));
        }

        [TestMethod]
        public void DadaSeleccionConCebollaChileYPiña()
        {
            List<string> toppings = new List<string>();
            toppings.Add("Cebolla");
            toppings.Add("Chile");
            toppings.Add("Piña");

            modeloPizza.AsignarToppingsPizza(toppings);

            bool esperado = true;

            Assert.AreEqual(esperado, modeloPizza.TieneTopping("Cebolla"));
            Assert.AreEqual(esperado, modeloPizza.TieneTopping("Chile"));
            Assert.AreEqual(esperado, modeloPizza.TieneTopping("Piña"));
        }

        [TestMethod]
        public void DadaSeleccionPizzaPequeña()
        {
            string esperado = "Pequeña";
            modeloPizza.AsignarTamañoPizza("Pequeña");
            Assert.AreEqual(esperado, modeloPizza.Tamaño);
        }

        [TestMethod]
        public void DadaPizzaGrandeCalcularImpuesto()
        {
            double precioPizzaGrande = calculador.preciosBaseTamaño["Grande"]; // Precio: 7990
            double precioFinalEsperado = precioPizzaGrande * 1.13; //9028.7

            Assert.AreEqual(precioFinalEsperado, calculador.CalcularPrecioConImpuesto(precioPizzaGrande));
        }

        [TestMethod]
        public void DadaPizzaMedianaAgregarQuesoYHongos()
        {
            double precioPizzaMediana = calculador.preciosBaseTamaño["Mediana"]; // 4990

            double precioFinalEsperado = 5740; //Precio P.Mediana = 4990 + 450 (queso) + 300 (hongos)

            precioPizzaMediana = calculador.AgregarPrecioTopping(precioPizzaMediana, "Queso");
            precioPizzaMediana = calculador.AgregarPrecioTopping(precioPizzaMediana, "Hongos");

            Assert.AreEqual(precioFinalEsperado, precioPizzaMediana);
        }

        [TestMethod]
        public void DadaDireccionUniversidad()
        {
            string direccion = "San José, Montes de Oca, Universidad de Costa Rica, ECCI";

            calculador.AgregarDireccion(direccion);

            Assert.AreEqual(direccion, calculador.DireccionEnvio);
        }

        [TestMethod]

        public void DadoPonerYQuitarDireccionDeEnvio()
        {
            string vacia = "";
            string direccion = "Alajuela, Desamparados, Claudia";

            calculador.AgregarDireccion(direccion);
            calculador.QuitarDireccion();

            Assert.AreEqual(vacia, calculador.DireccionEnvio);

        }

        [TestMethod]
        public void DadoElegirTamañoExtraGrandeControlador()
        {
            string tamañoPizza = "ExtraGrande";
            controlador.ElegirTamañoPizza(tamañoPizza);

            Assert.AreEqual(tamañoPizza, controlador.ConsultarTamañoPizza());
        }

        [TestMethod]
        public void DadoAsignarToppingQuesoTocinetaYOlivas()
        {
            List<string> toppings = new List<string>();
            toppings.Add("Queso");
            toppings.Add("Tocineta");
            toppings.Add("Olivas");

            bool esperado = true;

            controlador.ElegirToppingsPizza(toppings);
            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza("Queso"));
            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza("Tocineta"));
            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza("Olivas"));
        }

        [TestMethod]
        public void DadoSoloSeleccionarQueso()
        {
            string topping = "Queso";
            controlador.ElegirToppingPizza(topping);

            bool esperado = true;
            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza(topping));
        }

        [TestMethod]
        public void DadoSeRemueveQuesoDePizza()
        {
            string topping = "Queso";
            controlador.ElegirToppingPizza(topping);
            controlador.RemoverTopping(topping);

            bool esperado = false;
            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza(topping));
        }

        [TestMethod]
        public void DadoPonerTodosLosToppings()
        {
            controlador.AsignarTodosLosToppings();

            bool esperado = true;

            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza("Queso"));
            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza("Jamon"));
            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza("Hongos"));
            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza("Chile"));
            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza("Olivas"));
        }

        [TestMethod]
        public void DadoQuitarTodosLosToppings()
        {
            controlador.RemoverTodosLosToppings();

            bool esperado = false;

            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza("Salsa"));
            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza("Peperoni"));
            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza("Cebolla"));
            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza("Tocineta"));
            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza("Piña"));
        }

        [TestMethod]
        public void DadaPizzaPequeñaPrecioEsperado()
        {
            string tamaño = "Pequeña";
            controlador.ElegirTamañoPizza(tamaño);

            double esperado = 2990;
            Assert.AreEqual(esperado, controlador.CalcularPrecioBasePizza(tamaño));
        }

        [TestMethod]
        public void DadaPizzaMedianaConTodosLosToppingsPrecioEsperado()
        {
            string tamaño = "Mediana";

            controlador.ElegirTamañoPizza(tamaño);
            double precio = controlador.CalcularPrecioBasePizza(tamaño);
            controlador.AsignarTodosLosToppings();

            precio = precio + controlador.CalcularPrecioToppings();
            double precioEseperado = 9190;
            Assert.AreEqual(precioEseperado, precio);
        }


    }
}
