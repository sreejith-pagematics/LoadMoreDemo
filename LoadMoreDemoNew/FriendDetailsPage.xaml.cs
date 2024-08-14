using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Messaging;
using Controls.UserDialogs.Maui;
using GeolocatorPlugin;
using GeolocatorPlugin.Abstractions;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Essentials;
using static System.Net.Mime.MediaTypeNames;
using DeviceInfo = Microsoft.Maui.Devices.DeviceInfo;
using DevicePlatform = Microsoft.Maui.Devices.DevicePlatform;
using Email = Microsoft.Maui.ApplicationModel.Communication.Email;
using EmailMessage = Microsoft.Maui.ApplicationModel.Communication.EmailMessage;
using FeatureNotSupportedException = Microsoft.Maui.ApplicationModel.FeatureNotSupportedException;
using Launcher = Microsoft.Maui.ApplicationModel.Launcher;
using Location = Microsoft.Maui.Devices.Sensors.Location;
using MainThread = Microsoft.Maui.ApplicationModel.MainThread;
using PhoneDialer = Microsoft.Maui.ApplicationModel.Communication.PhoneDialer;
using Preferences = Microsoft.Maui.Storage.Preferences;

namespace NeedHelp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FriendDetailsPage : ContentPage
    {
        string name, inital;
        double lat, longi;
        public ObservableCollection<UserLocationHistoryHBList> allHistoryList;
        public ObservableCollection<UserLocationHistoryHBList> sosHistoryList;
        public ObservableCollection<UserLocationHistoryHBList> watchMeHistoryList;
        Polyline geovalue;
        Pin geopin;
        double latitude, longitude;
        string keyString;
        List<string> dictionary;
        bool loadMoreHistory = false;
        bool haveHistoryItemsToLoad = false;
        int i = 1;
        public FriendDetailsPage()
        {
            InitializeComponent();
            allHistoryList = new ObservableCollection<UserLocationHistoryHBList>();
            sosHistoryList = new ObservableCollection<UserLocationHistoryHBList>();
            watchMeHistoryList = new ObservableCollection<UserLocationHistoryHBList>();
            name = "Edward";
            Label_title.Text = name;
            Name_label.Text = name;
            Number_label.Text = "963 125 4582" ;
            Inital_label.Text = "EL";
            StartBackgroundTasks("933");            
        }

        void LoadMoreHistory(object sender, EventArgs e)
        {
            if (haveHistoryItemsToLoad)
            {
                haveHistoryItemsToLoad = false;
                i = i + 1;
                SetHistoryListItems("933");
            }
            
        }

        private async void StartBackgroundTasks(string monitorId)
        {
            try
            {
                await Task.Run(async () => await FriendDetail(monitorId));
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception:>>" + e);
            }
        }

        private async Task FriendDetail(string monitorId)
        {
            try
            {
                Email_label.Text = "edwardliv@gmail.com";
                Address_label.Text = "Mr Edwad. 132, My Street, Kingston, New York 12401.";
                Location location = new Location(latitude, longitude);
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(29.482080, -98.763020), Distance.FromMiles(1)));
                Pin pin = new Pin
                {
                    Label = "",
                    // Address = "The city with a boardwalk",
                    Type = PinType.Place,
                    Location = new Location(29.482080, -98.763020)
                };
                map.Pins.Add(pin);
                geopin = pin;
                map_layout.IsVisible = true;
                await Task.Run(async () => await SetHistoryListItems(monitorId));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("outer Exception:>" + ex);
            }
        }


        /*Used to list the history of the selected friend from the list*/
        public async Task SetHistoryListItems(string selecteduserId)
        {
            try
            {
                if (i == 1)
                {
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 1", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 2", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 3", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 4", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 5", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 6", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 7", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 8", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 9", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 10", date = "13/08/2024", triggerType = "type 1" });
                    haveHistoryItemsToLoad = true;
                }
                else if (i == 2)
                {
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 11", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 12", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 13", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 14", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 15", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 16", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 17", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 18", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 19", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 20", date = "13/08/2024", triggerType = "type 1" });
                    haveHistoryItemsToLoad = true;
                }
                else if (i == 3)
                {
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 21", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 22", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 23", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 24", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 25", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 26", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 27", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 28", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 29", date = "13/08/2024", triggerType = "type 1" });
                    allHistoryList.Add(new UserLocationHistoryHBList() { AllAudits = "Audit 30", date = "13/08/2024", triggerType = "type 1" });
                    haveHistoryItemsToLoad = false;
                }

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    Debug.WriteLine("count:>>" + allHistoryList.Count);
                    historylistview.ItemsSource = allHistoryList;
                    UserDialogs.Instance.HideHud();
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception:>" + ex);
            }
        }

        private void SetNoHistoryAlert()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                UserDialogs.Instance.HideHud();
                historylistview.IsVisible = false;
                no_history_label.IsVisible = true;
            });
        }

        /*Used to navigate to the previous page*/
        async void BacktoPreviousPage(object sender, EventArgs args)
        {
            try
            {
                await Navigation.PopModalAsync(false);
                //OnBackButtonPressed();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception:>" + ex);
            }
        }
    }

    public class LocationHistory
    {
        public List<UserLocationHistoryHBList> userLocationHistoryHBList { get; set; }
    }

    public class UserLocationHistoryHBList : INotifyPropertyChanged
    {
        public string triggerType { get; set; }
        public string date { get; set; }
        public UserLocationTO userLocationTO { get; set; }
        public List<AuditList> auditList { get; set; }
        public string username { get; set; }
        private string iconType;
        public string IconType
        {
            set
            {
                if (value != null)
                {
                    iconType = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return iconType;
            }
        }
        private string allAudits;
        public string AllAudits
        {
            set
            {
                if (value != null)
                {
                    allAudits = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return allAudits;
            }
        }

        private string historyuername;
        public string HistoryUsername
        {
            set
            {
                if (value != null)
                {
                    historyuername = value;
                    NotifyPropertyChanged();
                }
            }
            get
            {
                return historyuername;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AuditList
    {
        public string message { get; set; }
        public string username { get; set; }
    }

    public class UserLocationTO
    {
        public string triggerType { get; set; }
        public double lattitude { get; set; }
        public double longitude { get; set; }
        public long createdTime { get; set; }
        public string userLocationId { get; set; }
        public bool emergencyTriggered { get; set; }
        public Location CurrentPosition { get; set; }
        public ObservableCollection<Location> positionList { get; set; }
    }
}