﻿using Alura.Adopet.Console;
using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Testes
{
    public class FabricaDeComandosTest
    {
        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoImport()
        {
            //Arrange
            string[] args = { "import", "lista.csv" };
            //Act
            var comando = FabricaDeComandos.CriarComando(args);
            //Assert
            Assert.IsType<Import>(comando);
        }

        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoList()
        {
            //Arrange
            string[] args = { "list", "lista.csv" };
            //Act
            var comando = FabricaDeComandos.CriarComando(args);
            //Assert
            Assert.IsType<List>(comando);
        }

        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoShow()
        {
            //Arrange
            string[] args = { "show", "lista.csv" };
            //Act
            var comando = FabricaDeComandos.CriarComando(args);
            //Assert
            Assert.IsType<Show>(comando);
        }

        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoHelp()
        {
            //Arrange
            string[] args = { "help", "lista.csv" };
            //Act
            var comando = FabricaDeComandos.CriarComando(args);
            //Assert
            Assert.IsType<Help>(comando);
        }

        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoImportInteressados()
        {
            //Arrange
            string[] args = { "import-clientes", "lista.csv" };
            //Act
            var comando = FabricaDeComandos.CriarComando(args);
            //Assert
            Assert.IsType<ImportClientes>(comando);
        }

        [Fact]
        public void DadoUmParametroInvalidoDeveRetornarNulo()
        {
            //Arrange
            string[] args = { "invalid", "lista.csv" };
            //Act
            var comando = FabricaDeComandos.CriarComando(args);
            //Assert
            Assert.Null(comando);
        }

        [Fact]
        public void DadoUmArrayDeArgumentosNuloDeveRetornarNulo()
        {
            //Arrange           
            //Act
            var comando = FabricaDeComandos.CriarComando(null);
            //Assert
            Assert.Null(comando);
        }

        [Fact]
        public void DadoUmArrayDeArgumentosVazioDeveRetornarNulo()
        {
            //Arrange
            string[] args = { };
            //Act
            var comando = FabricaDeComandos.CriarComando(args);
            //Assert
            Assert.Null(comando);
        }



    }
}
