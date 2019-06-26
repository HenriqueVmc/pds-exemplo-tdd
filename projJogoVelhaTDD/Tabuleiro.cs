using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projJogoVelhaTDD
{
    public class Tabuleiro
    {
        private Celula[,] celulasTabuleiro;
        private Jogador jogadorAtual;
        private Jogador? jogadorVencedor;

        public Tabuleiro()
        {
            celulasTabuleiro = new Celula[3, 3];

            for (int y = 0; y < celulasTabuleiro.GetLength(1); y++)
            {
                for (int x = 0; x < celulasTabuleiro.GetLength(0); x++)
                {
                    celulasTabuleiro[x, y] = new Celula();
                }
            }

            jogadorAtual = Jogador.X;
        }

        public Jogador GetProximo()
        {
            return jogadorAtual;
        }

        public bool Jogar(int x, int y)
        {
            bool statusJogada = false;

            var celula = celulasTabuleiro[x, y];

            if (celula.GetJogada() == null)
            {
                celula.SetJogada(jogadorAtual);             
                statusJogada = true;
                
                //VERIFICAR VENCEDOR

                NotifyObservers();
            }

            jogadorAtual = (jogadorAtual == Jogador.X) ? Jogador.O : Jogador.X;

            return statusJogada;
        }

        public Celula[,] GetCelulas()
        {
            return celulasTabuleiro;
        }

        public Jogador? GetVitoria()
        {
            return jogadorVencedor;
        }

        List<IObserver> observers = new List<IObserver>();

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void NotifyObservers()
        {
            foreach (var item in observers)
            {
                item.Notify(this);
            }
        }
    }
}
