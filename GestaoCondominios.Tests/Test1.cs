/*
* <copyright file="CondominioTests.cs" company="IPCA">
* Copyright (c) 2025 All Rights Reserved
* </copyright>
* <author>Tiago Barroso Fontes (33222)</author>
* <description>Testes unitários para validar a lógica de negócio do condomínio.</description>
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestaoCondominios.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestaoCondominios.Tests
{
    [TestClass]
    public class CondominioTests
    {
        // TESTE 1: Verificar se a matemática da Permilagem funciona
        [TestMethod]
        public void GerarQuota_CalculaValorCorreto_BaseadoNaPermilagem()
        {
            // 1. ARRANGE (Preparar)
            // Criamos um proprietário fictício (pode ser null se não validares no construtor)
            Proprietario prop = new Proprietario("João", "123", "911");

            // Criamos uma fração com 500 de permilagem (ou seja, 50% do prédio)
            Fracao fracao = new Fracao("A", 500, prop);

            decimal valorDespesa = 1000m; // Despesa de 1000€

            // 2. ACT (Executar)
            fracao.GerarQuota(valorDespesa, "Reparação Telhado");

            // 3. ASSERT (Verificar)
            // 500 permilagem * 1000€ / 1000 = 500€
            decimal valorEsperado = 500m;
            decimal valorObtido = fracao.Quotas[0].Valor;

            Assert.AreEqual(valorEsperado, valorObtido, "O valor da quota devia ser 50% da despesa.");
        }

        // TESTE 2: Verificar se o Condominio distribui a despesa por todos
        [TestMethod]
        public void InserirDespesa_CriaQuotasParaTodasAsFracoes()
        {
            // 1. ARRANGE
            Condominio predio = new Condominio("Edifício Teste");
            Proprietario p1 = new Proprietario("Ana", "111", "222");

            // Adicionar 2 frações
            Fracao fA = new Fracao("A", 500, p1);
            Fracao fB = new Fracao("B", 500, p1);

            predio.AdicionarFracao(fA);
            predio.AdicionarFracao(fB);

            // 2. ACT
            // Inserir uma despesa no prédio
            predio.InserirDespesa(100m, "Luz", "Geral");

            // 3. ASSERT
            // Verificar se a despesa foi guardada
            Assert.AreEqual(1, predio.Despesas.Count, "A lista de despesas devia ter 1 elemento.");

            // Verificar se AMBAS as frações receberam uma quota
            Assert.AreEqual(1, fA.Quotas.Count, "A fração A devia ter 1 quota.");
            Assert.AreEqual(1, fB.Quotas.Count, "A fração B devia ter 1 quota.");
        }

        // TESTE 3: Verificar o Pagamento
        [TestMethod]
        public void PagarQuota_AlteraEstadoParaVerdadeiro()
        {
            // 1. ARRANGE
            Quota q = new Quota(50m, "Limpeza");

            // Verifica se começa como false
            Assert.IsFalse(q.EstaPaga, "A quota devia começar por pagar.");

            // 2. ACT
            q.Pagar();

            // 3. ASSERT
            Assert.IsTrue(q.EstaPaga, "A quota devia estar marcada como paga após o método Pagar().");
        }
    }
}