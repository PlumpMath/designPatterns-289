using System;

namespace designPatterns.Domain.DesignPattern.ChainOfResponsabilityPattern
{
    public class Director : Approver
    {
        public override string ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                return string.Format("{0} approved request# {1}", GetType().Name, purchase.Number);
            }
            return Successor != null ? Successor.ProcessRequest(purchase) : "";
        }
    }
}