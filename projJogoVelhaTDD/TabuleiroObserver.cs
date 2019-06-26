using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projJogoVelhaTDD
{
    public class TabuleiroObserver : IObserver
    {
        private Tabuleiro tabuleiro;

        public void Notify(Tabuleiro tabuleiro)
        {
            this.tabuleiro = tabuleiro;
        }
    }
}
