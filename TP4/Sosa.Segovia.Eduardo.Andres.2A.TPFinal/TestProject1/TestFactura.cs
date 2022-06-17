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

        public void GetFacturaNumber_CuandoListaEsVacia_Return0()
        {
            //Arrange
            List<Factura> facturas = new List<Factura>();
            int expected = 0;

            //Act
            int actual = Factura.GetFacturaActualNumber(facturas);

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void GetFacturaNumber_CuandoElIdMasBajoEs0_Return1()
        {
            //Arrange
            List<Factura> facturas = new List<Factura>();
            List<Producto> productos = new List<Producto>();
            Persona personaTest = new Cliente(123456, "test", DateTime.Now,eTipo.monotributo);
            Factura facturaTest = new Factura(0, personaTest, productos, eTipoPago.credito);
            facturas.Add(facturaTest);
            int expected = 1;

            //Act
            int actual = Factura.GetFacturaActualNumber(facturas);

            //Assert

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void GetFacturaNumber_CuandoFacturaMayor99EstaIntercalada_Return100()
        {
            //Arrange
            List<Factura> facturas = new List<Factura>();
            List<Producto> productos = new List<Producto>();
            Persona personaTest = new Cliente(123456, "test", DateTime.Now, eTipo.monotributo);
            Factura facturaTest = new Factura(0, personaTest, productos, eTipoPago.credito);
            facturas.Add(facturaTest);
            
            facturaTest = new Factura(99, personaTest, productos, eTipoPago.credito);
            facturas.Add(facturaTest);

            facturaTest = new Factura(50, personaTest, productos, eTipoPago.credito);
            facturas.Add(facturaTest);
            int expected = 100;

            //Act
            int actual = Factura.GetFacturaActualNumber(facturas);

            //Assert

            Assert.AreEqual(expected, actual);
        }

   
    }
}
