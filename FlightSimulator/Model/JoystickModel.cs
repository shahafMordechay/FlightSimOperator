using FlightSimulator.Models.Interface;
using FlightSimulator.ViewModels;
using System.ComponentModel;

namespace FlightSimulator.Models
{
    class JoystickModel : BaseNotify,IJoystickModel
    {
        const string comma = ",";
       
        public new event PropertyChangedEventHandler PropertyChanged;
        private double throttle;
        public double Throttle
        {
            get { return throttle; }
            set
            {
                throttle = value;
                {
                    NotifyPropertyChanged("Throttle"+comma+ throttle);
                }
            }
        }
        private double aileron;
        public double Aileron
        {
            get { return aileron; }
            set
            {
                aileron = value;
                {
                    NotifyPropertyChanged("Aileron"+comma+ aileron);
                }
            }
        }
        private double elevator;
        public double Elevator
        {
            get { return elevator; }
            set
            {
                elevator = value;
                {
                    NotifyPropertyChanged("Elevator"+comma+ elevator);
                }
            }
        }
        private double rudder;
        public double Rudder
        {
            get { return rudder; }
            set
            {
                rudder = value;
                {
                    NotifyPropertyChanged("Rudder"+comma+rudder);
                }

            }
        }
        public new void NotifyPropertyChanged(string propName){
if (this.PropertyChanged != null)
this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
}


    }
}
