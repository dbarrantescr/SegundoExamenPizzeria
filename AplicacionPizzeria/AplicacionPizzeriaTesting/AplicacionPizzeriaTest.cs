using AplicacionPizzeria.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AplicacionPizzeriaTesting
{
    [TestClass]
    public class AplicacionPizzeriaTest
    {
        Calculador calculador = new Calculador();


        [TestMethod]
        public void DadaPizzaGrandeCalcularImpuesto()
        {
            double precioPizzaGrande = calculador.preciosBaseTamaño["Grande"]; // Precio: 7990
            double precioFinalEsperado = precioPizzaGrande * 1.13; //9028.7

            Assert.AreEqual(precioFinalEsperado, calculador.calcularPrecioConImpuesto(precioPizzaGrande));
        }

        [TestMethod]
        public void DadaPizzaMedianaAgregarQuesoYHongos()
        {
            double precioPizzaMediana = calculador.preciosBaseTamaño["Mediana"]; // 4990

            double precioFinalEsperado = 5740; //Precio P.Mediana = 4990 + 450 (queso) + 300 (hongos)

            precioPizzaMediana = calculador.agregarTopping(precioPizzaMediana, "Queso");
            precioPizzaMediana = calculador.agregarTopping(precioPizzaMediana, "Hongos");

            Assert.AreEqual(precioFinalEsperado, precioPizzaMediana);
        }
    }
}
