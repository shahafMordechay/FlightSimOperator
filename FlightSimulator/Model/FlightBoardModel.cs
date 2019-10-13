using FlightSimulator.Connection;
using FlightSimulator.ViewModels;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Models
{
    class FlightBoardModel : BaseNotify
    {
        private Info info;

        public new event PropertyChangedEventHandler PropertyChanged;

        public FlightBoardModel(Info info)
        {
            this.info = info;
        }

        private double lon;
        public double Lon
        {
            get { return lon; }

            set
            {
                lon = value;
                NotifyPropertyChanged("Lon");
            }
        }

        private double lat;
        public double Lat
        {
            get { return lat; }

            set
            {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        // tell server to open and start reading
        public void Open(string ip, int port)
        {
            info.Open(ip, port);
            StartRead();
        }

        // read input in a new task, notify view model about the new data
        void StartRead()
        {
            new Task(delegate ()
            {
                while (!info.Stop)
                {
                    string[] args = info.Read();
                    Lon = Convert.ToDouble(args[0]);
                    Lat = Convert.ToDouble(args[1]);
                }
            }).Start();
        }

        //connected or not.
        public bool IsConnected() { return info.Connected; }

        // can stop the reading
        public void StopRead() { info.Stop = true; }
        public void DisConnect() { info.Close(); }

        public new void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
