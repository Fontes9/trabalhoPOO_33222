using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using GestaoCondominios.Models;

namespace GestaoCondominios.Services
{
    public class FicheiroService
    {
        // O ficheiro ficará na pasta bin/Debug/net8.0
        private const string NOME_FICHEIRO = "dados_condominio.bin";

        /// <summary>
        /// Guarda os dados em disco (Binário).
        /// </summary>
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
        /// Carrega os dados do disco.
        /// </summary>
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