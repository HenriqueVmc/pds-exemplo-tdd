using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projJogoVelhaTDD
{
    public abstract class Subject
    {
        private Tabuleiro tabuleiro;

        List<IObserver> observers = new List<IObserver>();

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void NotifyObservers()
        {
            foreach (var item in observers)
            {
                item.Notify(tabuleiro);
            }
        }
    }
}
