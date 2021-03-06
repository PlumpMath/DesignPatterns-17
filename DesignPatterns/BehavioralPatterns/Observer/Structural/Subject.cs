﻿using System.Collections.Generic;

namespace DesignPatterns.BehavioralPatterns.Observer.Structural
{
    internal abstract class Subject
    {
        private readonly List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var o in _observers)
            {
                o.Update();
            }
        }
    }
}