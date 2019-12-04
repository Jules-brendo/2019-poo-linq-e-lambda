using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Banco.Contas;
using Banco.Busca;

namespace Array
{
    public partial class FormRelatorios : Form
    {
        private List<Conta> contas;
        public FormRelatorios(List<Conta> contas)
        {
            InitializeComponent();
            this.contas = contas;
        }

        private void ListaResultado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //questao 01
        private void BotaoFiltroSaldo_Click(object sender, EventArgs e)
        {
            listaResultado.Items.Clear();
            //var resultado = ""; // query do LINQ
            var resultado = from c in contas where c.Saldo > 500 select new { c.Numero, c.Titular };
            foreach (var c in resultado)
            {
                listaResultado.Items.Add(c);
            }
        }

        private void FormRelatorios_Load(object sender, EventArgs e)
        {

        }
        //questao 02
        private void ButaFiltroSaldo_Click(object sender, EventArgs e)
        {
            //listaResultado.Items.Clear();
            //var resultado = from c in contas where c.Saldo > 1000 && c.Numero < 10 select new { c.Numero, c.Titular };
            //foreach (var c in resultado)
            //{
            //    listaResultado.Items.Add(c);
            //}

            //questao 03
            //listaResultado.Items.Clear();
            //var resultado = from c in contas where c.Numero > 0 select new { c.Numero, c.Saldo }; // query do LINQ
            //foreach (var c in resultado)
            //{
            //    listaResultado.Items.Add(c);
            //}

            //double saldoTotal = resultado.Sum(conta => conta.Saldo);
            //double maiorSaldo = resultado.Max(conta => conta.Saldo);

            //labelSaldoTotal.Text = Convert.ToString(saldoTotal);
            //labelMaiorSaldo.Text = Convert.ToString(maiorSaldo);

            //questao 04
            listaResultado.Items.Clear();
            //var resultado = from c in contas where c.Numero > 0 orderby c.Titular.Nome ascending select new { c.Titular.Nome, c.Saldo }; // query do LINQ

            //questao 06
            var resultado = contas
                    .Where(c => c.Saldo > 10000)
                    .OrderBy(c => c.Titular.Nome)
                    .ThenBy(c => c.Numero);

            foreach (var c in resultado)
            {
                listaResultado.Items.Add(c);
            }

            double saldoTotal = resultado.Sum(conta => conta.Saldo);
            double maiorSaldo = resultado.Max(conta => conta.Saldo);

            labelSaldoTotal.Text = Convert.ToString(saldoTotal);
            labelMaiorSaldo.Text = Convert.ToString(maiorSaldo);

        }
    }
}
