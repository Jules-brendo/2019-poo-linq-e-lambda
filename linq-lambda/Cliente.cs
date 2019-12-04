using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Contas;

using Banco.Contas;

//namespace Array
namespace Banco.Contas
{
   public class Cliente
    {
        //private string p;
        //public Cliente(string p)
        //{
        //    this.Nome = p;
        //}
        //public string Nome { get; set; }

        //questão 02

        public string Nome { get; set; }
        public string Rg { get; set; }
        public Cliente(string nome)
        {
            this.Nome = nome;
        }
        public override bool Equals(Object obj)
        {
            Cliente outroCliente = (Cliente)obj;
            return this.Nome == outroCliente.Nome && this.Rg == outroCliente.Rg;
        }

    }
}
