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
        public Jogador? jogadorVenceu;

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
                jogadorVenceu = GetVitoria();

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
            List<List<Jogador>> jogadas = new List<List<Jogador>>();
            jogadas.Add(new List<Jogador>());
            jogadas.Add(new List<Jogador>());
            jogadas.Add(new List<Jogador>());
            jogadas.Add(new List<Jogador>());

            for (int x = 0; x < celulasTabuleiro.GetLength(1); x++)
            {
                for (int y = 0; y < celulasTabuleiro.GetLength(0); y++)
                {
                    if (celulasTabuleiro[x, y].GetJogada().HasValue)
                    {
                        jogadas[0].Add(celulasTabuleiro[x, y].GetJogada().Value);
                    }

                    if (celulasTabuleiro[y, x].GetJogada().HasValue)
                    {
                        jogadas[1].Add(celulasTabuleiro[y, x].GetJogada().Value);
                    }

                    if ((x == y) && celulasTabuleiro[x, y].GetJogada().HasValue)
                    {
                        jogadas[2].Add(celulasTabuleiro[x, y].GetJogada().Value);
                    }

                    if (((x == 1 && y == 1) || (x == 2 && y == 0) || (y == 2 && x == 0)) && celulasTabuleiro[x, y].GetJogada().HasValue)
                    {
                        jogadas[3].Add(celulasTabuleiro[x, y].GetJogada().Value);
                    }
                }

                // HORIZONTAL
                if (((jogadas[0].Count(c => c == Jogador.X)) == 3) || ((jogadas[0].Count(c => c == Jogador.O)) == 3))
                    return jogadas[0].First();

                // VERTICAL
                else if (((jogadas[1].Count(c => c == Jogador.X)) == 3) || ((jogadas[1].Count(c => c == Jogador.O)) == 3))
                    return jogadas[1].First();

                // DIAGONAL(L)
                else if (((jogadas[2].Count(c => c == Jogador.X)) == 3) || ((jogadas[2].Count(c => c == Jogador.O)) == 3))
                    return jogadas[2].First();
               
                // DIAGONAL(R)
                else if (((jogadas[3].Count(c => c == Jogador.X)) == 3) || ((jogadas[3].Count(c => c == Jogador.O)) == 3))
                    return jogadas[3].First();

                jogadas[0].Clear();
                jogadas[1].Clear();
            }
            jogadas[2].Clear();
            jogadas[3].Clear();
            
            // EMPATOU
            if (Empatou())
                return Jogador.EMPATE;

            return null;
        }

        private bool Empatou()
        {
            for (int y = 0; y < celulasTabuleiro.GetLength(1); y++)
            {
                for (int x = 0; x < celulasTabuleiro.GetLength(0); x++)
                {
                    if (celulasTabuleiro[x, y].GetJogada() == null) return false;
                }
            }
            return true;
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
