﻿using Logger;

namespace DesignPatterns.BehavioralPatterns.State.RealWorld
{
    /// <summary>
    ///     A 'ConcreteState' class
    ///     <remarks>
    ///         Red indicates that account is overdrawn
    ///     </remarks>
    /// </summary>
    internal class RedState : RealState
    {
        private double _serviceFee;
        // Constructor
        public RedState(RealState state)
        {
            balance = state.Balance;
            account = state.Account;
            Initialize();
        }

        private void Initialize()
        {
            // Should come from a datasource
            interest = 0.0;
            lowerLimit = -100.0;
            upperLimit = 0.0;
            _serviceFee = 15.00;
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            amount = amount - _serviceFee;
            Log.WriteLine("No funds available for withdrawal!");
        }

        public override void PayInterest()
        {
            // No interest is paid
        }

        private void StateChangeCheck()
        {
            if (balance > upperLimit)
            {
                account.State = new SilverState(this);
            }
        }
    }
}