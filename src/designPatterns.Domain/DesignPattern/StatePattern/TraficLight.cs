using designPatterns.Domain.DesignPattern.StatePattern.States;

namespace designPatterns.Domain.DesignPattern.StatePattern
{
    public class TraficLight
    {
        public TraficLightState CurrentState;
        public TraficLight()
        {
            CurrentState = new GreenState(this);
        }
        public string StartTheTraficLight()
        {
            var traficLightProcess = "";
            while (!traficLightProcess.Contains("Red"))
            {
                traficLightProcess += CurrentState.GetNextState();
            }
            
            return traficLightProcess;
        }
    }
}