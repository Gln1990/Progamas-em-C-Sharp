namespace Calculadora
{
    public partial class Form1 : Form
    {

        public decimal Resultado { get; set; }
        public decimal Valor { get; set; }

        private Operacao OperacaoSelecionada { get; set; }
        private enum Operacao
        {
            Adicao,
            Subtracao,
            Multiplicacao,
            Divisao
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnMultiplicacao_Click(object sender, EventArgs e)
        {
            OperacaoSelecionada = Operacao.Multiplicacao;
            Valor = Convert.ToDecimal(TxtResultado.Text);
            TxtResultado.Text = "";
            LblOperacao.Text = "*";
        }

        //dois jeitos de concatenar
        private void Btn0_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "0";
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtResultado.Text += "1";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "2";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtResultado.Text += "3";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "4";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "5";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "6";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "7";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "8";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "9";
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = "";
            LblOperacao.Text = "";
        }

        private void BtnDivisao_Click(object sender, EventArgs e)
        {
            OperacaoSelecionada = Operacao.Divisao;
            Valor = Convert.ToDecimal(TxtResultado.Text);
            TxtResultado.Text = "";
            LblOperacao.Text = "/";
        }

        private void BtnSubtracao_Click(object sender, EventArgs e)
        {
            OperacaoSelecionada = Operacao.Subtracao;
            Valor = Convert.ToDecimal(TxtResultado.Text);
            TxtResultado.Text = "";
            LblOperacao.Text = "-";
        }

        private void BtnAdicao_Click(object sender, EventArgs e)
        {
            OperacaoSelecionada = Operacao.Adicao;
            Valor =Convert.ToDecimal(TxtResultado.Text);
            TxtResultado.Text = "";
            LblOperacao.Text = "+";
            
        }

        private void BtnIgual_Click(object sender, EventArgs e)
        {
            switch (OperacaoSelecionada)
            {
               case Operacao.Adicao:
                    Resultado = Valor + Convert.ToDecimal(TxtResultado.Text);
                    break;
               case Operacao.Subtracao:
                    Resultado = Valor - Convert.ToDecimal(TxtResultado.Text);
                    break;
               case Operacao.Multiplicacao:
                    Resultado = Valor * Convert.ToDecimal(TxtResultado.Text);
                    break;
               case Operacao.Divisao:
                    Resultado = Valor / Convert.ToDecimal(TxtResultado.Text);
                    break;  
            }
            TxtResultado.Text = Resultado.ToString();
            LblOperacao.Text = "=";
        }

        private void BtnVirgula_Click(object sender, EventArgs e)
        {
            if(!TxtResultado.Text.Contains(","))
            TxtResultado.Text += ",";
        }

        private void TxtResultado_TextChanged(object sender, EventArgs e)
        {

        }
    }
}