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
    public partial class FormCadastroConta : Form
    {
        private ICollection<string> devedores;

        private Form1 formPrincipal;

        public FormCadastroConta(Form1 formPrincipal)
        {
            this.formPrincipal = formPrincipal;
            InitializeComponent();

            GeradorDeDevedores gerador = new GeradorDeDevedores();
            this.devedores = gerador.GeraList();
        }
        
    private void BotaoCadastro_Click(object sender, EventArgs e)
        {

            //if (comboTipoConta.Text == "Poupança")
            //    {
            //        ContaPoupanca novaConta = new ContaPoupanca();
            //        novaConta.Titular = new Cliente(textoTitular.Text);

            //        //novaConta.Numero = Convert.ToInt32(textoNumero.Text);
            //        //MessageBox.Show("numero: " + novaConta.Numero);

            //        //int numero = novaConta.ProximoNumero();
            //        //textoNumero.Text = numero.ToString();

            //}
            //else {
            //       ContaCorrente novaConta = new ContaCorrente();
            //        novaConta.Titular = new Cliente(textoTitular.Text);

            //        //novaConta.Numero;
            //        //novaConta.Numero = Convert.ToInt32(textoNumero.Text);
            //        //MessageBox.Show("numero: " + novaConta.Numero);

            //}

            //questão 03
            //string titular = textoTitular.Text;
            //bool ehDevedor = this.devedores.Contains(titular);
            //if (!ehDevedor)
            //{
            //    // faz a lógica para criar a conta
            //}
            //else
            //{
            //    MessageBox.Show("devedor");
            //}

            //questao 04, Resposta a janela de form fica "travada"! 
            string titular = this.textoTitular.Text;
            bool ehDevedor = false;
            for (int i = 0; i < 30000; i++)
            {
                ehDevedor = this.devedores.Contains(titular);
            }
            if (!ehDevedor)
            {
                // faz a lógica para criar a conta
            }
            else
            {
                MessageBox.Show("devedor");
            }
        }


        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ComboTipoConta_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void FormCadastroConta_Load(object sender, EventArgs e)
        {
            comboTipoConta.Items.Add("Poupança");
            comboTipoConta.Items.Add("Corrente");
    
            //questão 4
            textoNumero.Text = Convert.ToString(Conta.ProximoNumero());

        }
    }
    }

