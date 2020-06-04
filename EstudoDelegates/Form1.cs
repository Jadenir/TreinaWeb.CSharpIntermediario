using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstudoDelegates
{
    public partial class frmCalculadora : Form
    {
        private delegate int ExecutarOperacao(int numero1, int numero2);
        private ExecutarOperacao minhaOpercao;

        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        {

        }
        //Metodos
        private int Somar(int numero1, int numero2)
        {
            return numero1 + numero2;
        }
        private int Subtrair(int numero1, int numero2)
        {
            return numero1 - numero2;
        }
        private int Multiplicar(int numero1, int numero2)
        {
            return numero1 * numero2;
        }
        private int Dividir(int numero1, int numero2)
        {
            return numero1 / numero2;
        }
        private int Calcular()
        {
            int numero1 = Convert.ToInt32(txtNumero1.Text);
            int numero2 = Convert.ToInt32(txtNumero2.Text);
            return minhaOpercao(numero1, numero2);
        }
        //Click
        private void btnAdicao_Click(object sender, EventArgs e)
        {
            minhaOpercao = new ExecutarOperacao(Somar);
            txtResultado.Text = Calcular().ToString();
        }
        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            minhaOpercao = new ExecutarOperacao(Subtrair);
            txtResultado.Text = Calcular().ToString();
        }
        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            minhaOpercao = new ExecutarOperacao(Multiplicar);
            txtResultado.Text = Calcular().ToString();
        }
        private void btnDivisao_Click(object sender, EventArgs e)
        {
            minhaOpercao = new ExecutarOperacao(Dividir);
            txtResultado.Text = Calcular().ToString();
        }
    }
}
