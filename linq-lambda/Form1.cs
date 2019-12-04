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

namespace Array
//namespace Banco
{
    public partial class Form1 : Form
    {
        //private Conta[] c;
        //private int numeroDeContas;

        private List<Conta> c;
        private Dictionary<string, Conta> dicionario;

        public Form1()
        {
            InitializeComponent();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

            // criando o array para guardar as contas
            //c = new Conta[10];

            this.c = new List<Conta>();
            this.dicionario = new Dictionary<string, Conta>();

            //Conta c1 = new Conta();
            Conta c1 = new ContaPoupanca();
            c1.Titular = new Cliente("victor");
            c1.Numero = 11;
            c1.Saldo = 1250;
            this.AdicionaConta(c1);

            Conta c2 = new ContaPoupanca();
            c2.Titular = new Cliente("mauricio");
            c2.Numero = 2;
            c2.Saldo = 1100;
            this.AdicionaConta(c2);

            Conta c3 = new ContaCorrente();
            c3.Titular = new Cliente("osni");
            c3.Numero = 3;
            c3.Saldo = 550;
            this.AdicionaConta(c3);

            //foreach (Conta conta in c)
            // {
            //  comboContas.Items.Add(conta.Titular.Nome);
            // comboDestinoTransferencia.Items.Add(conta.Titular.Nome);
            //}


        }
        public void AdicionaConta(Conta c)
        {
            //this.c[this.numeroDeContas] = c;
            //this.numeroDeContas++;
            //comboContas.Items.Add(c);
            //comboContas.DisplayMember = "Numero";

            this.c.Add(c);
            comboContas.Items.Add(c);

            this.dicionario.Add(c.Titular.Nome, c);

            //Conta[] novo = new Conta[this.numeroDeContas * 2];
            //if (this.numeroDeContas == this.c.Length)
            //{
            //    for (int i = 0; i < this.numeroDeContas; i++)
            //    {
            //        novo[i] = this.c[i];
            //    }

            //}
            //this.c[this.numeroDeContas] = c;
            //this.numeroDeContas++;
            //comboContas.Items.Add("titular: " + c.Titular.Nome);
        }


        private void BotaoBusca_Click(object sender, EventArgs e)
        {
            //int indice = Convert.ToInt32(textoIndice.Text);
            int indice = comboDestinoTransferencia.SelectedIndex;

            Conta selecionada = this.c[indice];

            textoNumero.Text = Convert.ToString(selecionada.Numero);
            textoTitular.Text = selecionada.Titular.Nome;
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
        }

        private void BotaoDeposito_Click(object sender, EventArgs e)
        {
            // primeiro precisamos recuperar o índice da conta selecionada
            int indice = comboContas.SelectedIndex;

            //int indice = Convert.ToInt32(textoIndice.Text);

            // e depois precisamos ler a posição correta do array.
            //Conta selecionada = this.c[indice];

            Conta selecionada = (Conta)comboContas.SelectedItem;

            double valor = Convert.ToDouble(textoValor.Text);
            //selecionada.Deposita(valor);
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
            try
            {
                selecionada.Deposita(valor);
                textoSaldo.Text = Convert.ToString(selecionada.Saldo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valor impróprio");
            }
        }
        
        private void BotaoSaque_Click(object sender, EventArgs e)
        {
            //int indice = Convert.ToInt32(textoIndice.Text);
            int indice = comboContas.SelectedIndex;

            //Conta selecionada = this.c[indice];
            Conta selecionada = (Conta)comboContas.SelectedItem;

            double valor = Convert.ToDouble(textoValor.Text);
            //selecionada.Saca(valor);
            //textoSaldo.Text = Convert.ToString(selecionada.Saldo);
            try
            {
                selecionada.Saca(valor);
                textoSaldo.Text = Convert.ToString(selecionada.Saldo);
                //MessageBox.Show("argumento inválido");
            }
            catch (SaldoInsuficienteException ex)
            {
                MessageBox.Show("Saldo insuficiente");
            }
        }

        private void ComboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int indice = comboContas.SelectedIndex;
            Conta selecionada = c[indice];
            textoTitular.Text = selecionada.Titular.Nome;
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
            textoNumero.Text = Convert.ToString(selecionada.Numero);

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            int indiceOrigem = comboContas.SelectedIndex;
            Conta contaOrigem = this.c[indiceOrigem];
            
            int indiceDaContaDestino = comboDestinoTransferencia.SelectedIndex;
            Conta contaDestino = this.c[indiceDaContaDestino];
           
            double valorTransferencia = Convert.ToDouble(textoValor.Text);
            
            contaOrigem.Transfere(contaDestino, valorTransferencia);

        }

        private void TextoIndice_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboDestinoTransferencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = comboDestinoTransferencia.SelectedIndex;
            Conta selecionadaDestinoTransferencia = c[indice];
        }

        private void BotaoNovaConta_Click(object sender, EventArgs e)
        {

            FormCadastroConta formularioDeCadastro = new FormCadastroConta(this);
            formularioDeCadastro.ShowDialog();
        }

        private void BotaoImpostos_Click(object sender, EventArgs e)
        {
            ContaCorrente conta = new ContaCorrente();
            conta.Deposita(200.0);

            SeguroDeVida sv = new SeguroDeVida();

            TotalizadorDeTributos totalizador = new TotalizadorDeTributos();
            totalizador.Acumula(conta);
            MessageBox.Show("Total: " + totalizador.Total);

            totalizador.Acumula(sv);
            MessageBox.Show("Total: " + totalizador.Total);

        }

        private void Questao02_Click(object sender, EventArgs e)
        {

            Cliente guilherme = new Cliente("Guilherme Silveira");
            guilherme.Rg = "12345678-9";

            Cliente mauricio = new Cliente("Mauricio Aniche");
            mauricio.Rg = "12345678-9";

            if (guilherme.Equals(mauricio))
            {
                MessageBox.Show("São o mesmo cliente");
            }
            else
            {
                MessageBox.Show("Não são o mesmo cliente");
            }

        }

       
        private void Button01_Click(object sender, EventArgs e)
        {
            //questao 01: RESPOSTA>>> "1", CONJUNTO NÃO ACEITA REPETIÇÃO
            var conjunto = new HashSet<Conta>();
            var c1 = new ContaCorrente();
            conjunto.Add(c1);
            conjunto.Add(c1);
            MessageBox.Show(conjunto.Count.ToString());

            //questao 02: Resposta: o método para apagar todos os itens da lista é "Clear()", 
            var c2 = new ContaCorrente();
            conjunto.Add(c2);
            MessageBox.Show(conjunto.Count.ToString());
            conjunto.Clear();
            MessageBox.Show(conjunto.Count.ToString());
        }

        //questão 20.8.1
        private void BotaoBuscaTitular_Click(object sender, EventArgs e)
        {
            string nomeTitular = textoBuscaTitular.Text;
            //Conta conta = dicionario[nomeTitular];
            Conta conta = dicionario[nomeTitular];

            // Questao 03, Resposta: não encontrada chave do dicionario

            textoTitular.Text = conta.Titular.Nome;
            textoNumero.Text = Convert.ToString(conta.Numero);
            textoSaldo.Text = Convert.ToString(conta.Saldo);

            comboContas.SelectedItem = conta;
        }

        private void BotaoRelatorio_Click(object sender, EventArgs e)
        {
            FormRelatorios formularioRelatorios = new FormRelatorios(this.c);
            formularioRelatorios.ShowDialog();
        }

    }
}
