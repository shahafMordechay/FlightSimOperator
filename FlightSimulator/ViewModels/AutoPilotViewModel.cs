using FlightSimulator.Model;
using FlightSimulator.Models;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private AutoPilotModel model = new AutoPilotModel();

        private Brush background = Brushes.White; 

        private string commands; 
        public string Commands
        {
            get { return commands; }

            set
            {
                // typings.
                commands = value;
                if (!string.IsNullOrEmpty(Commands) && Background == Brushes.White) Background = Brushes.LightPink;
                else if (string.IsNullOrEmpty(Commands)) Background = Brushes.White;
                NotifyPropertyChanged("Commands");
            }
        }
        public Brush Background
        {
            get
            {
                return background;
            }
            set
            {
                background = value;
                NotifyPropertyChanged("Background");
            }

        }

        #region okCommand
        private ICommand okCommand; // ok button.
        public ICommand OkCommand
        {
            get
            {
                return okCommand ?? (okCommand = new CommandHandler(() =>
                {
                    string toBeSent = Commands;
                    // clear window
                    Commands = "";
                    Background = Brushes.White; 
                    // send to simulator.
                    model.SetVals(toBeSent);

                }));
            }
        }

        #endregion


        #region clearCommand
        private ICommand clearCommand; // Clear command for clear button
        public ICommand ClearCommand
        {
            get
            {
                return clearCommand ?? (clearCommand = new CommandHandler(() =>
                {
                    Commands = "";
                    Background = Brushes.White;
                }));
            }
        }

        #endregion

        public void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
