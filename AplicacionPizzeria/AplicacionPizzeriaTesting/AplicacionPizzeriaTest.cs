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
        public void DadaSeleccionConCebollaChileYPi�a()
        {
            List<string> toppings = new List<string>();
            toppings.Add("Cebolla");
            toppings.Add("Chile");
            toppings.Add("Pi�a");

            modeloPizza.AsignarToppingsPizza(toppings);

            bool esperado = true;

            Assert.AreEqual(esperado, modeloPizza.TieneTopping("Cebolla"));
            Assert.AreEqual(esperado, modeloPizza.TieneTopping("Chile"));
            Assert.AreEqual(esperado, modeloPizza.TieneTopping("Pi�a"));
        }

        [TestMethod]
        public void DadaSeleccionPizzaPeque�a()
        {
            string esperado = "Peque�a";
            modeloPizza.AsignarTama�oPizza("Peque�a");
            Assert.AreEqual(esperado, modeloPizza.Tama�o);
        }

        [TestMethod]
        public void DadaPizzaGrandeCalcularImpuesto()
        {
            double precioPizzaGrande = calculador.preciosBaseTama�o["Grande"]; // Precio: 7990
            double precioFinalEsperado = precioPizzaGrande * 1.13; //9028.7

            Assert.AreEqual(precioFinalEsperado, calculador.CalcularPrecioConImpuesto(precioPizzaGrande));
        }

        [TestMethod]
        public void DadaPizzaMedianaAgregarQuesoYHongos()
        {
            double precioPizzaMediana = calculador.preciosBaseTama�o["Mediana"]; // 4990

            double precioFinalEsperado = 5740; //Precio P.Mediana = 4990 + 450 (queso) + 300 (hongos)

            precioPizzaMediana = calculador.AgregarPrecioTopping(precioPizzaMediana, "Queso");
            precioPizzaMediana = calculador.AgregarPrecioTopping(precioPizzaMediana, "Hongos");

            Assert.AreEqual(precioFinalEsperado, precioPizzaMediana);
        }

        [TestMethod]
        public void DadaDireccionUniversidad()
        {
            string direccion = "San Jos�, Montes de Oca, Universidad de Costa Rica, ECCI";

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
        public void DadoElegirTama�oExtraGrandeControlador()
        {
            string tama�oPizza = "ExtraGrande";
            controlador.ElegirTama�oPizza(tama�oPizza);

            Assert.AreEqual(tama�oPizza, controlador.ConsultarTama�oPizza());
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
            Assert.AreEqual(esperado, controlador.ConsultarToppingPizza("Pi�a"));
        }

        [TestMethod]
        public void DadaPizzaPeque�aPrecioEsperado()
        {
            string tama�o = "Peque�a";
            controlador.ElegirTama�oPizza(tama�o);

            double esperado = 2990;
            Assert.AreEqual(esperado, controlador.CalcularPrecioBasePizza(tama�o));
        }

        [TestMethod]
        public void DadaPizzaMedianaConTodosLosToppingsPrecioEsperado()
        {
            string tama�o = "Mediana";

            controlador.ElegirTama�oPizza(tama�o);
            double precio = controlador.CalcularPrecioBasePizza(tama�o);
            controlador.AsignarTodosLosToppings();

            precio = precio + controlador.CalcularPrecioToppings();
            double precioEseperado = 9190;
            Assert.AreEqual(precioEseperado, precio);
        }


    }
}
