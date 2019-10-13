using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Views.Windows;
using System.Threading;
using FlightSimulator.Connection;
using FlightSimulator.Models;
using System.ComponentModel;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private Settings settingsWindow;
        private FlightBoardModel model;

        public FlightBoardViewModel()
        {
            settingsWindow = new Settings();
            model = new FlightBoardModel(new Info());
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "Lat") Lat = model.Lat;
                else if (e.PropertyName == "Lon") Lon = model.Lon;
                NotifyPropertyChanged(e.PropertyName);
            };
        }

        public double Lon
        {
            get;
            set;
        }

        public double Lat
        {
            get;
            set;
        }

        #region SettingsCommand
        private ICommand settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return settingsCommand ?? (settingsCommand = new CommandHandler(() =>
                {
                    if (!settingsWindow.IsLoaded)
                    {
                        settingsWindow = new Settings();
                    }
                    settingsWindow.Show();

                }));
            }
        }
        #endregion

        #region ConnectCommand
        private ICommand connectCommand;
        public ICommand ConnectsCommand
        {
            get
            {
                return (connectCommand = new CommandHandler(() =>
                {
                    // disable connect button
                    connectOrNot = false;
                    new Task(delegate ()
                    {
                        Commands.Instance.Connect(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightCommandPort);
                    }).Start();
                    model.Open(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightInfoPort);
                }));
            }
        }
        #endregion
        #region ConnectOrNot
        public bool trig = true;
        public bool connectOrNot
        {
            get
            {
                return trig;
            }
            set
            {
                trig = value;
                NotifyPropertyChanged("connectOrNot");
            }
        }
        #endregion

        #region disConnect
        private ICommand disconnection;
        public ICommand DisCommand
        {
            get
            {
                return (disconnection = new CommandHandler(() =>
                 {
                    // there is active connection.
                    if (Commands.Instance.Connected)
                     {
                        //stop with reading.
                        model.StopRead();
                         Commands.Instance.Reset();
                         Thread.Sleep(2000);
                         model.DisConnect();
                        //enable reconnect
                        connectOrNot = true;
                     }
                 }));
            }
        }
        #endregion
    }
}
