namespace designPatterns.Domain.DesignPattern.StatePattern.States
{
    public class YellowState : TraficLightState
    {
        private const string Color = "Second Step Yellow Color, ";

        public YellowState(TraficLight state)
        {
            TraficLight = state;
        }

        public override string GetNextState()
        {
            TraficLight.CurrentState = new RedState(TraficLight);
            return Color;
        }
    }
}