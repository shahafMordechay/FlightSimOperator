using FlightSimulator.Connection;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Models
{
    class AutoPilotModel
    {
        // set values
        public void SetVals(string command)
        {
            if (Commands.Instance.Connected)
            {
                new Task(delegate ()
                {
                    Commands.Instance.ChangeValues(command);
                }).Start();
            }

        }

    }
}

