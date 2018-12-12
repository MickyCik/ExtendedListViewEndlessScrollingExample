using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ExtendedListViewExample.Models;

namespace ExtendedListViewExample.Services
{
    public class DataService
    {
        public ObservableCollection<UserProfile> _usersDataSource { get; set; } = new ObservableCollection<UserProfile>()
        {
            new UserProfile("Luis", "Pujols"), new UserProfile("Charlin", "Agramonte"),
            new UserProfile("Rendy", "Rosario"), new UserProfile("Andrew", "Marth"),
            new UserProfile("Joseph", "Guzman"), new UserProfile("Jack", "Roberts"),
            new UserProfile("Leyla", "Smith"), new UserProfile("Leo", "Reyes"),
            new UserProfile("Pedro", "Martinez"), new UserProfile("Maria", "Perez"),
            new UserProfile("Gustav", "Malik"), new UserProfile("Patricia", "Smith"),
            new UserProfile("Luis", "Pujols"), new UserProfile("Charlin", "Agramonte"),
            new UserProfile("Rendy", "Rosario"), new UserProfile("Andrew", "Marth"),
            new UserProfile("Joseph", "Guzman"), new UserProfile("Jack", "Roberts"),
            new UserProfile("Leyla", "Smith"), new UserProfile("Leo", "Reyes"),
            new UserProfile("Pedro", "Martinez"), new UserProfile("Maria", "Perez"),
            new UserProfile("Gustav", "Malik"), new UserProfile("Patricia", "Smith"),
        };

        public DataService()
        {
        }

        public async Task<IList<UserProfile>> GetUsersAsync(int pageIndex, int pageSize)
        {
            await Task.Delay(2500);

            return _usersDataSource.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
    }
}
