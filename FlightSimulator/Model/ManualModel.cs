using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightSimulator.Connection;

namespace FlightSimulator.Models
{
    class ManualModel
    {
        public void Setter(string command)
        {
            if (Commands.Instance.Connected)
            {
                new Thread(delegate ()
                {
                    Commands.Instance.ChangeValues(command);
                }).Start();
            }
        }
    }
}
