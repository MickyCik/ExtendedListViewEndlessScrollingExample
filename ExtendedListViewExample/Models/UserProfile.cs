using System;
using System.ComponentModel;

namespace ExtendedListViewExample.Models
{
    public class UserProfile : INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public UserProfile(string firstName, string lastname)
        {
            FirstName = firstName;
            LastName = lastname;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
