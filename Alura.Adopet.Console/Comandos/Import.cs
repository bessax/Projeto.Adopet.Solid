﻿using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    public class Import:IComando
    {
        private readonly IPetService clientPet;

        private readonly ILeitorDeArquivo<Pet> leitor;

        public Import(IPetService clientPet, ILeitorDeArquivo<Pet> leitor)
        {
            this.clientPet = clientPet;
            this.leitor = leitor;
        }

        public async Task<Result> ExecutarAsync()
        {
            return await this.ImportacaoArquivoPetAsync();
        }

        private async Task<Result> ImportacaoArquivoPetAsync()
        {
            try
            {
                var listaDePet = leitor.RealizaLeitura();
                if (listaDePet == null) return Result.Fail("Não havia pets no arquivo de importação");
                foreach (var pet in listaDePet)
                {                       
                   await clientPet.CreatePetAsync(pet);               
                }
                return Result.Ok().WithSuccess(new SuccessWithPets(listaDePet,"Importação Realizada com Sucesso!"));
            }
            catch (Exception exception)
            {

                return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
            }
        }
    }
}
