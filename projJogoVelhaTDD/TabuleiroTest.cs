using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projJogoVelhaTDD
{
    public class TabuleiroTest : IObserver
    {
        private bool notificado = false;

        public void Notify(Tabuleiro tabuleiro)
        {
            notificado = true;
        }

        public void Test()
        {
            Tabuleiro t = new Tabuleiro();
            t.RegisterObserver(this);

            // Verifica estado inicial do tabuleiro (deve ser vazio)
            Celula[,] celulas = t.GetCelulas();
            for (int y = 0; y < celulas.GetLength(1); y++)
            {
                for (int x = 0; x < celulas.GetLength(0); x++)
                {
                    if (celulas[x, y].GetJogada() != null)
                    {
                        throw new Exception("Nenhuma jogada deve existir ao início da execução");
                    }
                }
            }

            // Verifica primeiro jogador a jogar (deve ser X)
            if (t.GetProximo() != Jogador.X)
            {
                throw new Exception("O jogador X deve ser sempre o primeiro a jogar");
            }

            // Verifica vitória (não deve existir)
            if (t.GetVitoria() != null)
            {
                throw new Exception("Não deve existir vitória ao início da execução");
            }

            // Efetua e verifica a primeira jogada na posição (1,1), e verifica o próximo jogador a jogar (deve ser O)
            notificado = false;
            if (!t.Jogar(1, 1))
            {
                throw new Exception("Uma primeira jogada em (1,1) ao início da execução deve ser factível");
            }
            if (t.GetCelulas()[1, 1].GetJogada() != Jogador.X)
            {
                throw new Exception("A primeira jogada, em (1,1), não foi efetivada para o jogador X");
            }
            if (t.GetProximo() != Jogador.O)
            {
                throw new Exception("Após a primeira jogada, o jogador O deve ser o próximo a jogar");
            }
            if (!notificado)
            {
                throw new Exception("Após a primeira jogada, a notificação de mudança não foi disparada");
            }

            // Efetua e verifica a segunda jogada na posição (2,1), e verifica o próximo jogador a jogar (deve ser X)
            notificado = false;
            if (!t.Jogar(2, 1))
            {
                throw new Exception("Uma segunda jogada em (2,1) deve ser factível");
            }
            if (t.GetCelulas()[2, 1].GetJogada() != Jogador.O)
            {
                throw new Exception("A segunda jogada, em (2,1), não foi efetivada para o jogador O");
            }
            if (t.GetProximo() != Jogador.X)
            {
                throw new Exception("Após a segunda jogada, o jogador X deve ser o próximo a jogar");
            }
            if (!notificado)
            {
                throw new Exception("Após a segunda jogada, a notificação de mudança não foi disparada");
            }

            // Efetua e verifica a terceira jogada na posição (0,0), e verifica o próximo jogador a jogar (deve ser O)
            notificado = false;
            if (!t.Jogar(0, 0))
            {
                throw new Exception("Uma terceira jogada em (0,0) deve ser factível");
            }
            if (t.GetCelulas()[0, 0].GetJogada() != Jogador.X)
            {
                throw new Exception("A terceira jogada, em (0,0), não foi efetivada para o jogador X");
            }
            if (t.GetProximo() != Jogador.O)
            {
                throw new Exception("Após a terceira jogada, o jogador O deve ser o próximo a jogar");
            }
            if (!notificado)
            {
                throw new Exception("Após a terceira jogada, a notificação de mudança não foi disparada");
            }

            // Efetua e verifica a quarta jogada na posição (2,2), e verifica o próximo jogador a jogar (deve ser X)
            notificado = false;
            if (!t.Jogar(2, 2))
            {
                throw new Exception("Uma quarta jogada em (2,2) deve ser factível");
            }
            if (t.GetCelulas()[2, 2].GetJogada() != Jogador.O)
            {
                throw new Exception("A quarta jogada, em (2,2), não foi efetivada para o jogador O");
            }
            if (t.GetProximo() != Jogador.X)
            {
                throw new Exception("Após a quarta jogada, o jogador X deve ser o próximo a jogar");
            }
            if (!notificado)
            {
                throw new Exception("Após a quarta jogada, a notificação de mudança não foi disparada");
            }

            // Tenta jogar novamente em posições já jogadas
            notificado = false;
            if (t.Jogar(1, 1))
            {
                throw new Exception("Uma nova jogada na posição (1,1) não deve ser possível");
            }
            if (t.Jogar(2, 1))
            {
                throw new Exception("Uma nova jogada na posição (2,1) não deve ser possível");
            }
            if (t.Jogar(0, 0))
            {
                throw new Exception("Uma nova jogada na posição (0,0) não deve ser possível");
            }
            if (t.Jogar(2, 2))
            {
                throw new Exception("Uma nova jogada na posição (2,2) não deve ser possível");
            }
            if (notificado)
            {
                throw new Exception("Nas jogadas inválidas, a notificação de mudança foi disparada");
            }

            // Efetua e verifica a quarta jogada na posição (1,0), e verifica o próximo jogador a jogar (deve ser O)
            notificado = false;
            if (!t.Jogar(1, 0))
            {
                throw new Exception("Uma quinta jogada em (1,0) deve ser factível");
            }
            if (t.GetCelulas()[1, 0].GetJogada() != Jogador.X)
            {
                throw new Exception("A quinta jogada, em (1,0), não foi efetivada para o jogador X");
            }
            if (t.GetProximo() != Jogador.O)
            {
                throw new Exception("Após a quinta jogada, o jogador O deve ser o próximo a jogar");
            }
            if (!notificado)
            {
                throw new Exception("Após a quinta jogada, a notificação de mudança não foi disparada");
            }

            // Efetua e verifica a quarta jogada na posição (2,0), que deve resultar em vitória para o jogador O
            notificado = false;
            if (!t.Jogar(2, 0))
            {
                throw new Exception("Uma sexta jogada em (2,0) deve ser factível");
            }
            if (t.GetCelulas()[2, 0].GetJogada() != Jogador.O)
            {
                throw new Exception("A sexta jogada, em (2,0), não foi efetivada para o jogador O");
            }
            if (t.GetVitoria() != Jogador.O)
            {
                throw new Exception("Após a sexta jogada, o jogador O deve ser o vitorioso");
            }
            if (!notificado)
            {
                throw new Exception("Após a sexta jogada, a notificação de mudança não foi disparada");
            }

            // Confere o estado final do tabuleiro
            if (t.GetCelulas()[0, 0].GetJogada() != Jogador.X)
            {
                throw new Exception("Estado final do tabuleiro inválido em (0,0)");
            }
            if (t.GetCelulas()[0, 1].GetJogada() != null)
            {
                throw new Exception("Estado final do tabuleiro inválido em (0,1)");
            }
            if (t.GetCelulas()[0, 2].GetJogada() != null)
            {
                throw new Exception("Estado final do tabuleiro inválido em (0,2)");
            }
            if (t.GetCelulas()[1, 0].GetJogada() != Jogador.X)
            {
                throw new Exception("Estado final do tabuleiro inválido em (1,0)");
            }
            if (t.GetCelulas()[1, 1].GetJogada() != Jogador.X)
            {
                throw new Exception("Estado final do tabuleiro inválido em (1,1)");
            }
            if (t.GetCelulas()[1, 2].GetJogada() != null)
            {
                throw new Exception("Estado final do tabuleiro inválido em (1,2)");
            }
            if (t.GetCelulas()[2, 0].GetJogada() != Jogador.O)
            {
                throw new Exception("Estado final do tabuleiro inválido em (2,0)");
            }
            if (t.GetCelulas()[2, 1].GetJogada() != Jogador.O)
            {
                throw new Exception("Estado final do tabuleiro inválido em (2,1)");
            }
            if (t.GetCelulas()[2, 2].GetJogada() != Jogador.O)
            {
                throw new Exception("Estado final do tabuleiro inválido em (2,2)");
            }

            Console.WriteLine("Teste executado com sucesso");
        }
    }
}
