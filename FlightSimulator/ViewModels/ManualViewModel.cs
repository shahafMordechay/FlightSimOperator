using FlightSimulator.Models;
using System;

namespace FlightSimulator.ViewModels.Windows
{
    class ManualViewModel
    {
        private ManualModel model = new ManualModel();


        // set commands to the simulator, value missing.
        private readonly string throttlePath = "set /controls/engines/current-engine/throttle ";
        private readonly string rudderePath = "set /controls/flight/rudder ";
        private readonly string aileronPath = "set /controls/flight/aileron ";
        private readonly string elevatorPath = "set /controls/flight/elevator ";

        public double Throttle
        {
            set => model.Setter(throttlePath + Convert.ToString(value));
        }

        public double Rudder
        {
            set => model.Setter(rudderePath + Convert.ToString(value));
        }

        public double Aileron
        {
            set => model.Setter(aileronPath + Convert.ToString(value));
        }

        public double Elevator
        {
            set => model.Setter(elevatorPath + Convert.ToString(value));
        }
    }
}
