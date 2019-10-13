using System.ComponentModel;

namespace FlightSimulator.Models.Interface
{
    interface IJoystickModel
    {
        double Throttle { get; set; }
        double Elevator { get; set; }
        double Aileron { get; set; }
        double Rudder { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
    }
}
