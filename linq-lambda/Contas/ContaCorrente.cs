using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Contas;


namespace Array
//namespace Banco.Contas
{
    class ContaCorrente : Conta, ITributavel
    {

        private static int totalDeContas = 0;

        //public ContaCorrente
        //{
        //    ContaCorrente.totalDeContas++;
        //}
        //public int ProximaConta()
        //{
        //    return ContaCorrente.totalDeContas + 1;
        //}
        
        //questao 08
        public override void Saca(double valor)
        {
            if (valor > this.Saldo)
            {
                throw new SaldoInsuficienteException();
            }
            else
            {
                this.Saldo -= (valor + 0.05);
            }
        }
        public override void Deposita(double valorOperacao)
        {
            
            if (valorOperacao < 0.0)
            {
                throw new ArgumentException("operação inválida");
            }
            else
            {
                this.Saldo += (valorOperacao - 0.10);
            }
        }
        public double CalculaTributo()
        {
            return this.Saldo * 0.05;
        }
    }
}
