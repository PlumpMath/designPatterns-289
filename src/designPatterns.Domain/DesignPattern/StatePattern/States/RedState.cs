namespace designPatterns.Domain.DesignPattern.StatePattern.States
{
    public class RedState : TraficLightState
    {
        private const string Color = "Thrid and last Red Color.";

        public RedState(TraficLight state)
        {
            TraficLight = state;
        }

        public override string GetNextState()
        {
            return Color;
        }
    }
}
