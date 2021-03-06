﻿using Logger;

namespace DesignPatterns.BehavioralPatterns.Mediator.Structural
{
    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    class ConcreteColleague1 : Colleague
    {
        // Constructor
        public ConcreteColleague1(Mediator mediator)
            : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Log.WriteLine("Colleague1 gets message: "+ message);
        }
    }
}