using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Domain.DesignPattern.ObserverPattern
{
    public class Observable
    {
        public event EventHandler SomethingHappened;

        public string DoSomething()
        {
            var handler = SomethingHappened;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
            return "Observer Do Something";
        }
    }

    public class Observer
    {
        public void HandleEvent(object sender, EventArgs args)
        {
            Console.WriteLine("Something happened to " + sender);
        }
    }
}
