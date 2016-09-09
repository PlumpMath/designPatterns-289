namespace designPatterns.Domain.DesignPattern.StatePattern.States
{
    public abstract class TraficLightState
    {
        public TraficLight TraficLight { get; set; }
        public abstract string GetNextState();
    }
}