namespace designPatterns.Domain.DesignPattern.FacadePattern
{
    public class Customer
    {
        private readonly string _name;

        public Customer(string name)
        {
            _name = name;
        }
        public string Name
        {
            get { return _name; }
        }
    }
}