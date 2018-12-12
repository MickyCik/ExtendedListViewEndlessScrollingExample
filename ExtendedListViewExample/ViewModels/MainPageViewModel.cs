using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using ExtendedListViewExample.Models;
using ExtendedListViewExample.Services;
using Xamarin.Forms;

namespace ExtendedListViewExample.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        //Our Datasource for the listview
        public ObservableCollection<UserProfile> Data { get; set; } = new ObservableCollection<UserProfile>();
        // Notify the UI if the app is busy loading data.
        public bool IsBusy { get; set; }

        //Our mock dataservice
        DataService _dataService { get; set; } = new DataService();
        //PageNumber we are currently on (our service should allow us to receive the data paginated
        //for more efficiency.
        public int _pageNumber;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand OnLoadMoreCommand { get; set; }
        public ICommand OnItemTappedCommand { get; set; }

        public MainPageViewModel()
        {
            // Command to load more data from our service
            OnLoadMoreCommand = new Command(async () =>
            {
                IsBusy = true;

                try
                {
                    var users = await _dataService.GetUsersAsync(_pageNumber++, 10);

                    //Add the new data loaded from our service to our existing collection.
                    foreach (var user in users)
                    {
                        Data.Add(user);
                    }

                }
                catch (Exception ex)
                {
                    //Log any errors that might had occured while calling or using your service.
                    Debug.WriteLine(ex.Message);
                }
                finally
                {
                    IsBusy = false;
                }

            });

            // Command to react to taps on the listview
            OnItemTappedCommand = new Command<UserProfile>(async (UserProfile user) =>
            {
                await Application.Current.MainPage.DisplayAlert("Selected User", $"You have selected {user.FullName}", "OK");
            });

            OnLoadMoreCommand.Execute(null);
        }

    }
}
