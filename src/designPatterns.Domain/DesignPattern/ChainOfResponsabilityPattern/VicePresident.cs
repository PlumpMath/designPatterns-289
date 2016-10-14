using System;

namespace designPatterns.Domain.DesignPattern.ChainOfResponsabilityPattern
{
    public class VicePresident : Approver
    {
        public override string ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 45000.0)
            {
                return string.Format("{0} approved request# {1}", GetType().Name, purchase.Number);
            }
            return Successor != null ? Successor.ProcessRequest(purchase) : "";
        }
    }
}