namespace designPatterns.Domain.DesignPattern.ChainOfResponsabilityPattern
{
    public abstract class Approver
    {
        protected Approver Successor;

        public void SetSuccessor(Approver successor)
        {
            Successor = successor;
        }

        public abstract string ProcessRequest(Purchase purchase);
    }
}