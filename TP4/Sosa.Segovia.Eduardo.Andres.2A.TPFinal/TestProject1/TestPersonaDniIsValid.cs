using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP3ClassLibrary;

namespace TestTP3
{
    [TestClass]
    public class TestPersonaDniIsValid
    {
        [TestMethod]
        //Dni valido cunado solo contiene numero y un maximo de 6-9 digitos
        public void validarDni_CuandoDniEsMenorA6_ReturnFalse()
        {
            //Arrange
            string dni = "12345";
            
            //Act
            bool retorno = Persona.DniIsValid(dni);

            //Assert

            Assert.IsFalse(retorno);
        }
        
        [TestMethod]
       

        public void validarDni_CuandoDniEsMayorA9_ReturnFalse()
        {
            //Arrange
            string dni = "12345678910";

            //Act
            bool retorno = Persona.DniIsValid(dni);

            //Assert

            Assert.IsFalse(retorno);
        }

        [TestMethod]
        
        public void validarDni_CuandoDniEsDigits9_ReturnTrue()
        {
            //Arrange
            string dni = "123456789";

            //Act
            bool retorno = Persona.DniIsValid(dni);

            //Assert

            Assert.IsTrue(retorno);
        }

        [TestMethod]

        public void validarDni_CuandoDniEsDigits6_ReturnTrue()
        {
            //Arrange
            string dni = "123456";

            //Act
            bool retorno = Persona.DniIsValid(dni);

            //Assert

            Assert.IsTrue(retorno);
        }

        [TestMethod]

        public void validarDni_CuandoContinerLetras_ReturnFalse()
        {
            //Arrange
            string dni = "12345C78A";

            //Act
            bool retorno = Persona.DniIsValid(dni);

            //Assert

            Assert.IsFalse(retorno);
        }

        [TestMethod]

        public void validarDni_CuandoEsSoloCeros_ReturnFalse()
        {
            //Arrange
            string dni = "000000";

            //Act
            bool retorno = Persona.DniIsValid(dni);

            //Assert

            Assert.IsFalse(retorno);
        }

        [TestMethod]

        public void validarDni_CuandoEsCeroYNumeroPeroDigitMenor6_ReturnFalse()
        {
            //Arrange
            string dni = "000022";

            //Act
            bool retorno = Persona.DniIsValid(dni);

            //Assert

            Assert.IsFalse(retorno);
        }
    }

  
    
}
