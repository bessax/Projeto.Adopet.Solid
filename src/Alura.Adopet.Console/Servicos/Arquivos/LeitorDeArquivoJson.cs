﻿using System.Text.Json;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Arquivos;

public abstract class LeitorDeArquivoJson<T> : ILeitorDeArquivo<T>
{
    private string caminhoArquivo;

    public LeitorDeArquivoJson(string caminhoArquivo)
    {
        this.caminhoArquivo = caminhoArquivo;
    }

    public IEnumerable<T> RealizaLeitura()
    {
        using Stream stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);
        return JsonSerializer.Deserialize<IEnumerable<T>>(stream) ?? Enumerable.Empty<T>();
    }
}