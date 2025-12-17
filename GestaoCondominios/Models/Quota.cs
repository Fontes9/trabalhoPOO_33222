using System;

namespace GestaoCondominios.Models
{
    [Serializable]
    public class Quota
    {
        decimal valor;
        bool estaPaga;
        string referencia;

        public Quota(decimal valor, string referencia)
        {
            this.valor = valor;
            this.referencia = referencia;
            this.estaPaga = false;
        }

        public decimal Valor { get { return valor; } }
        public bool EstaPaga { get { return estaPaga; } }

        public void Pagar()
        {
            this.estaPaga = true;
        }

        public override string ToString()
        {
            return $"Ref: {referencia} | {valor:F2}€ | {(estaPaga ? "PAGA" : "EM DÍVIDA")}";
        }
    }
}