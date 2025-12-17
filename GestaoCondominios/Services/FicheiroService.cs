/*
* <copyright file="FicheiroService.cs" company="IPCA">
* Copyright (c) 2025 All Rights Reserved
* </copyright>
* <author>Tiago Barroso Fontes (33222)</author>
* <description>Serviço de persistência de dados em ficheiro.</description>
*/
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using GestaoCondominios.Models;

namespace GestaoCondominios.Services
{
    /// <summary>
    /// Serviço responsável pela persistência de dados em ficheiro (I/O).
    /// Utiliza serialização binária para guardar o estado do objeto Condominio.
    /// </summary>
    public class FicheiroService
    {
        // Define o nome do ficheiro binário a ser guardado na pasta de execução
        private const string NOME_FICHEIRO = "dados_condominio.bin";

        /// <summary>
        /// Serializa e guarda o objeto Condominio no disco.
        /// </summary>
        /// <param name="condominio">Objeto principal contendo todos os dados.</param>
        public static void GuardarDados(Condominio condominio)
        {
            try
            {
                using (FileStream fs = new FileStream(NOME_FICHEIRO, FileMode.Create))
                {
                    BinaryFormatter binFormatter = new BinaryFormatter();
                    binFormatter.Serialize(fs, condominio);
                }
                Console.WriteLine($"[IO] Dados guardados com sucesso em: {NOME_FICHEIRO}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERRO IO] Falha ao guardar: {ex.Message}");
            }
        }

        /// <summary>
        /// Tenta ler e desserializar os dados do disco.
        /// </summary>
        /// <returns>Objeto Condominio recuperado ou null se o ficheiro não existir/falhar.</returns>
        public static Condominio CarregarDados()
        {
            if (!File.Exists(NOME_FICHEIRO))
            {
                Console.WriteLine("[IO] Ficheiro de dados não existe. Será criado um novo.");
                return null;
            }

            try
            {
                using (FileStream fs = new FileStream(NOME_FICHEIRO, FileMode.Open))
                {
                    BinaryFormatter binFormatter = new BinaryFormatter();
                    Condominio c = (Condominio)binFormatter.Deserialize(fs);
                    Console.WriteLine("[IO] Dados carregados com sucesso!");
                    return c;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERRO IO] Falha ao ler ficheiro: {ex.Message}");
                return null;
            }
        }
    }
}