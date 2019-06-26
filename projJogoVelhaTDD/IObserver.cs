using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projJogoVelhaTDD
{
    public interface IObserver
    {
        void Notify(Tabuleiro tabuleiro);
    }
}
