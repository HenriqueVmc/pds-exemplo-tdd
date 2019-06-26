using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projJogoVelhaTDD
{
    public class Celula
    {
        private Jogador? _jogada;

        public Jogador? GetJogada()
        {
            return _jogada;
        }

        public void SetJogada(Jogador jogador)
        {
            _jogada = jogador;
        }
    }
}