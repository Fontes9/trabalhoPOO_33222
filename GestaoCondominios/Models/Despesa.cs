/*
* <copyright file="Despesa.cs" company="IPCA">
* <description>Representa uma despesa financeira.</description>
*/
using System;

namespace GestaoCondominios.Models
{
    [Serializable]
    public class Despesa
    {
        #region Attributes
        decimal valor;
        string descricao;
        string tipo;
        DateTime data;
        #endregion

        public Despesa(decimal valor, string descricao, string tipo)
        {
            this.valor = valor;
            this.descricao = descricao;
            this.tipo = tipo;
            this.data = DateTime.Now;
        }

        public decimal Valor => valor;
        public override string ToString() => $"{data.ToShortDateString()} - {descricao}: {valor:C}";
    }
}