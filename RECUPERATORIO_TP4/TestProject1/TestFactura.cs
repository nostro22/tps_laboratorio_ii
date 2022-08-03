using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TP3ClassLibrary;

namespace TestTP3
{
    [TestClass]
    public class TestFacturaGetFacturaActualNumber
    {
        //Es un metodo estatico que toma como referencia una lista de facturas la recorre y obtiene el valor mayor le suma uno, para tener un Id auto incremental suficientemente decente
        
        [TestMethod]

        public void ObtenerFacturaNumber_CuandoListaEsVacia_Retorno0()
        {
            //Arrange
            List<Factura> facturas = new List<Factura>();
            int expected = 0;

            //Act
            int actual = Factura.ObtenerFacturaActualNumber(facturas);

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void ObtenerFacturaNumber_CuandoElIdMasBajoEs0_Retorno1()
        {
            //Arrange
            List<Factura> facturas = new List<Factura>();
            List<Producto> productos = new List<Producto>();
            Persona personaTest = new Cliente(123456, "test", DateTime.Now,eTipo.Monotributo);
            Factura facturaTest = new Factura(0, personaTest, productos, eTipoPago.credito);
            facturas.Add(facturaTest);
            int expected = 1;

            //Act
            int actual = Factura.ObtenerFacturaActualNumber(facturas);

            //Assert

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void ObtenerFacturaNumber_CuandoFacturaMayor99EstaIntercalada_Retorno100()
        {
            //Arrange
            List<Factura> facturas = new List<Factura>();
            List<Producto> productos = new List<Producto>();
            Persona personaTest = new Cliente(123456, "test", DateTime.Now, eTipo.Monotributo);
            Factura facturaTest = new Factura(0, personaTest, productos, eTipoPago.credito);
            facturas.Add(facturaTest);
            
            facturaTest = new Factura(99, personaTest, productos, eTipoPago.credito);
            facturas.Add(facturaTest);

            facturaTest = new Factura(50, personaTest, productos, eTipoPago.credito);
            facturas.Add(facturaTest);
            int expected = 100;

            //Act
            int actual = Factura.ObtenerFacturaActualNumber(facturas);

            //Assert

            Assert.AreEqual(expected, actual);
        }

   
    }
}
