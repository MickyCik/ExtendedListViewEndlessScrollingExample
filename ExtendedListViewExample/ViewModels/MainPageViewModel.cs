using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ExtendedListViewExample.Models;
using Xamarin.Forms;

namespace ExtendedListViewExample.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<UserProfile> Data { get; set; } =  new ObservableCollection<UserProfile>()
        {
            new UserProfile("Luis", "Pujols"), new UserProfile("Charlin", "Agramonte"),
            new UserProfile("Rendy", "Rosario"), new UserProfile("Andrew", "Marth"),
            new UserProfile("Joseph", "Guzman"), new UserProfile("Jack", "Roberts"),
            new UserProfile("Leyla", "Smith"), new UserProfile("Leo", "Reyes"),
            new UserProfile("Pedro", "Martinez"), new UserProfile("Maria", "Perez"),
            new UserProfile("Gustav", "Malik"), new UserProfile("Patricia", "Smith")
        };

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand OnLoadMoreCommand { get; set; }

        public MainPageViewModel()
        {
            OnLoadMoreCommand = new Command(async () =>
            {


            });
        }

    }
}
