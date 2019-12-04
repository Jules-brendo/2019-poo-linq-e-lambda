using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//questão 03
namespace Banco.Contas
{
    public abstract class Conta
    {
        public int Numero { get; set; }
        //public double Saldo { get; protected set; }
        public double Saldo { get; set; }
        public Cliente Titular { get; set; }

        private static int numeroDeContas;

        public Conta()
        {
            Conta.numeroDeContas++;
            this.Numero = Conta.numeroDeContas;
        }

        public static int ProximoNumero()
        {
            return numeroDeContas + 1;
        }

        public abstract void Deposita(double valorOperacao);

        //public virtual void Deposita(double valorOperacao)
        //{
        //    //this.Saldo += valorOperacao;
        //}

        public abstract void Saca(double valor);

        //public virtual void Saca(double valor)
        //{
        //    this.Saldo -= valor;
        //}
        public virtual void Transfere(Conta contaDestino, double valor)
        {
            if (this.Saldo >= valor)
            {
                // Deposita conta destino
                contaDestino.Deposita(valor);
                // saca conta origem
                this.Saca(valor);
            }
        }

        public override String ToString()
        {
            return "titular: " + this.Titular.Nome;
        }

    }
}

