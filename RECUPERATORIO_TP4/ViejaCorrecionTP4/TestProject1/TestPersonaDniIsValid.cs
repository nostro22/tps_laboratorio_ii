using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP3ClassLibrary;

namespace TestTP3
{
    [TestClass]
    public class TestPersonaDniIsValid
    {
        [TestMethod]       
        public void ValidarDni_CuandoDniEsMenorCero_ReturnFalse()
        {
            //Arrange
            string dni = "-12345";
            
            //Act
            bool retorno = Persona.DniIsValid(dni);

            //Assert
            Assert.IsFalse(retorno);
        }
             


        [TestMethod]

        public void ValidarDni_CuandoContinerLetras_ReturnFalse()
        {
            //Arrange
            string dni = "12345C78A";

            //Act
            bool retorno = Persona.DniIsValid(dni);

            //Assert

            Assert.IsFalse(retorno);
        }

        [TestMethod]

        public void ValidarDni_CuandoSonLetras_ReturnFalse()
        {
            //Arrange
            string dni = "BfdA";

            //Act
            bool retorno = Persona.DniIsValid(dni);

            //Assert

            Assert.IsFalse(retorno);
        }

        [TestMethod]

        public void ValidarDni_CuandoEsSoloCeros_ReturnFalse()
        {
            //Arrange
            string dni = "000000";

            //Act
            bool retorno = Persona.DniIsValid(dni);

            //Assert

            Assert.IsFalse(retorno);
        }

        [TestMethod]

        public void ValidarDni_CuandoEsCeroYNumero_ReturnTrue()
        {
            //Arrange
            string dni = "000022";

            //Act
            bool retorno = Persona.DniIsValid(dni);

            //Assert

            Assert.IsTrue(retorno);
        }
    }

  
    
}
