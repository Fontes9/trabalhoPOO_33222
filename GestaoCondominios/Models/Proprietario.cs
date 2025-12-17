/*
* <copyright file="Proprietario.cs" company="IPCA">
* <description>Classe Proprietário derivada de Pessoa.</description>
*/
using System;

namespace GestaoCondominios.Models
{
    [Serializable]
    public class Proprietario : Pessoa
    {
        string contacto;

        public Proprietario(string nome, string nif, string contacto) : base(nome, nif)
        {
            this.contacto = contacto;
        }

        public string Contacto { get { return contacto; } }
    }
}