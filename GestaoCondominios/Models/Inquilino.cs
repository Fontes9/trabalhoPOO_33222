/*
* <copyright file="Inquilino.cs" company="IPCA">
* <description>Classe Inquilino derivada de Pessoa.</description>
*/
using System;

namespace GestaoCondominios.Models
{
    [Serializable]
    public class Inquilino : Pessoa
    {
        string contacto;

        public Inquilino(string nome, string nif, string contacto) : base(nome, nif)
        {
            this.contacto = contacto;
        }
    }
}