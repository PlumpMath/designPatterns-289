using System;

namespace designPatterns.Domain.DesignPattern.ChainOfResponsabilityPattern
{
    public class President : Approver
    {
        public override string ProcessRequest(Purchase purchase)
        {
            return !(purchase.Amount < 100000.0) ? 
                string.Format("Request# {0} requires an executive meeting!", purchase.Number) :
                string.Format("{0} approved request# {1}", GetType().Name, purchase.Number);
        }
    }
}