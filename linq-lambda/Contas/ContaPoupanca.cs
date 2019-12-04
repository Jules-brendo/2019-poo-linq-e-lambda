using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Contas;

namespace Array
{
    class ContaPoupanca : Conta, ITributavel
    {
        public override void Deposita(double valorOperacao)
       {  
         //questão 5
          if(valorOperacao < 0.0)
        {
            throw new ArgumentException("operação inválida");
        }
            else
            {
            this.Saldo += valorOperacao;
            }
       }
        public override void Saca(double valor)
        {
            if (valor > this.Saldo)
            {
                throw new SaldoInsuficienteException();
            }
            else
            {
                this.Saldo -= (valor + 0.10);
            }
        }
        public double CalculaTributo()
        {
            return this.Saldo * 0.02;
        }
    }
}
//questão 1: "throw new Exception();"
//questão 2:Se alguma linha lançar uma exceção, caso ela não seja tratada, todas as linhas que vêm depois do lançamento da exceção não são executadas. Portanto, se a linha 4 lançar uma exceção, apenas a linha 5 não será executada.
//questão 3: Dentro de um bloco try
//questão 4: O código que deve ser executado caso uma exceção seja lançada deve estar dentro de um bloco catch.
//questão 9: O bloco finally é executado sempre. Independentemente se foi lançado uma exceção ou não.