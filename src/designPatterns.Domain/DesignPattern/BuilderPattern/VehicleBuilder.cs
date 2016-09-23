namespace designPatterns.Domain.DesignPattern.BuilderPattern
{
    public abstract class VehicleBuilder
    {
        public Vehicle vehicle;
 
        public Vehicle Vehicle
        {
            get { return vehicle; }
        }
 
        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }
}