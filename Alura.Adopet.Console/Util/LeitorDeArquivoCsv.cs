﻿using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util
{
    public class LeitorDeArquivoCsv : ILeitorDeArquivo<Pet>
    {
        private string caminhoDoArquivoASerLido;
        public LeitorDeArquivoCsv(string caminhoDoArquivoASerLido)
        {
            this.caminhoDoArquivoASerLido = caminhoDoArquivoASerLido;
        }

        public virtual IEnumerable<Pet> RealizaLeitura()
        {
            if (string.IsNullOrEmpty(this.caminhoDoArquivoASerLido))
            {
                return null;
            }
            List<Pet> listaDePet = new List<Pet>();
            using (StreamReader sr = new StreamReader(caminhoDoArquivoASerLido))
            {               
                while (!sr.EndOfStream)
                {
                    // separa linha usando ponto e vírgula
                    string[]? propriedades = sr.ReadLine().Split(';');
                    // cria objeto Pet a partir da separação
                    Pet pet = new Pet(Guid.Parse(propriedades[0]),
                    propriedades[1],
                    int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro
                    );
                    listaDePet.Add(pet);
                }
            }

            return listaDePet;
        }
    }
}
