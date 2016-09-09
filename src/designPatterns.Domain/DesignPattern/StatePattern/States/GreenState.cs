namespace designPatterns.Domain.DesignPattern.StatePattern.States
{
    public class GreenState : TraficLightState
    {
        private const string Color = "First Step Green Color, ";

        public GreenState(TraficLight state)
        {
            TraficLight = state;
        }

        public override string GetNextState()
        {
            TraficLight.CurrentState = new YellowState(TraficLight);
            return Color;
        }
    }
}