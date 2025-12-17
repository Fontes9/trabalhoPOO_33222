/*
* <copyright file="ICondominioView.cs" company="IPCA">
* Copyright (c) 2025 All Rights Reserved
* </copyright>
* <author>Tiago Barroso Fontes (33222)</author>
* <description>Interface que define o contrato de interação com o utilizador.</description>
*/

namespace GestaoCondominios.Interfaces
{
    public interface ICondominioView
    {
        void MostrarMensagem(string mensagem);
        string LerTexto(string label);
        decimal LerDecimal(string label);
        int MenuPrincipal();
        void MostrarRelatorio(object dados);
    }
}