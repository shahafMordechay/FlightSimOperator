using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Models.EventArgs {
    public class ArgumentsInfo  {
    
        public ArgumentsInfo(double longtitude, double latitude) {
            Lon = longtitude;
            Lat = latitude;
        }
        double Lon { get; set; }
        double Lat { get; set; }
    }
}
