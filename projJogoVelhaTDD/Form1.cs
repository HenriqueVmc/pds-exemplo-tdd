using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projJogoVelhaTDD
{
    public partial class Form1 : Form, IObserver
    {
        private Tabuleiro tabuleiro;
        private Jogador jogadorAtual;
        
        public Form1()
        {
            InitializeComponent();

            TabuleiroTest tt = new TabuleiroTest();
            tt.Test();

            tabuleiro = new Tabuleiro();
            tabuleiro.RegisterObserver(this);
            jogadorAtual = tabuleiro.GetProximo();
        }

        private void SAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn00_Click(object sender, EventArgs e)
        {
            if (tabuleiro.Jogar(0, 0))
            {
                btn00.Text = Enum.GetName(jogadorAtual.GetType(), jogadorAtual);
                verificarVencedor();
                jogadorAtual = tabuleiro.GetProximo();
            }
        }

        private void Btn01_Click(object sender, EventArgs e)
        {
            if (tabuleiro.Jogar(0, 1))
            {
                btn01.Text = Enum.GetName(jogadorAtual.GetType(), jogadorAtual);
                verificarVencedor();
                jogadorAtual = tabuleiro.GetProximo();
            }
        }

        private void Btn02_Click(object sender, EventArgs e)
        {
            if (tabuleiro.Jogar(0, 2))
            {
                btn02.Text = Enum.GetName(jogadorAtual.GetType(), jogadorAtual);
                verificarVencedor();
                jogadorAtual = tabuleiro.GetProximo();
            }
        }

        private void Btn10_Click(object sender, EventArgs e)
        {
            if (tabuleiro.Jogar(1, 0))
            {
                btn10.Text = Enum.GetName(jogadorAtual.GetType(), jogadorAtual);
                verificarVencedor();
                jogadorAtual = tabuleiro.GetProximo();
            }
        }

        private void Btn11_Click(object sender, EventArgs e)
        {
            if (tabuleiro.Jogar(1, 1))
            {
                btn11.Text = Enum.GetName(jogadorAtual.GetType(), jogadorAtual);
                verificarVencedor();
                jogadorAtual = tabuleiro.GetProximo();
            }
        }

        private void Btn12_Click(object sender, EventArgs e)
        {
            if (tabuleiro.Jogar(1, 2))
            {
                btn12.Text = Enum.GetName(jogadorAtual.GetType(), jogadorAtual);
                verificarVencedor();
                jogadorAtual = tabuleiro.GetProximo();
            }
        }

        private void Btn20_Click(object sender, EventArgs e)
        {
            if (tabuleiro.Jogar(2, 0))
            {
                btn20.Text = Enum.GetName(jogadorAtual.GetType(), jogadorAtual);
                verificarVencedor();
                jogadorAtual = tabuleiro.GetProximo();
            }
        }

        private void Btn21_Click(object sender, EventArgs e)
        {
            if (tabuleiro.Jogar(2, 1))
            {
                btn21.Text = Enum.GetName(jogadorAtual.GetType(), jogadorAtual);
                verificarVencedor();
                jogadorAtual = tabuleiro.GetProximo();
            }
        }

        private void Btn22_Click(object sender, EventArgs e)
        {
            if (tabuleiro.Jogar(2, 2))
            {
                btn22.Text = Enum.GetName(jogadorAtual.GetType(), jogadorAtual);
                verificarVencedor();
                jogadorAtual = tabuleiro.GetProximo();
            }
        }

        private void verificarVencedor()
        {            
            if (tabuleiro.jogadorVenceu.HasValue)
            {
                if (tabuleiro.jogadorVenceu.Value == Jogador.EMPATE)
                    MessageBox.Show(Enum.GetName(tabuleiro.jogadorVenceu.Value.GetType(), tabuleiro.jogadorVenceu.Value) + "!");
                else
                    MessageBox.Show("Parabéns jogador " + Enum.GetName(tabuleiro.jogadorVenceu.Value.GetType(), tabuleiro.jogadorVenceu.Value)+", você venceu!");

                Application.Restart();
            }
        }

        public void Notify(Tabuleiro tabuleiro)
        {
            this.tabuleiro = tabuleiro;
        }
    }
}
