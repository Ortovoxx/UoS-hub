using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using UoS_Hub.Models;
using UoS_Hub.Services.Database;
using UoS_Hub.Services.Navigation;
using UoS_Hub.ViewModels.Base;
using UoS_Hub.Views;
using Xamarin.Plugin.Calendar.Models;

namespace UoS_Hub.ViewModels
{
    public class TimetableViewModel : BaseViewModel
    {
        public override Type WiredPageType => typeof(TimetableView);
        private Calendar _calendar = new GregorianCalendar(GregorianCalendarTypes.Localized);

        public IRepository<User> _userRepository;

        public ICommand TodayCommand { get; set; }

        private EventCollection _eventCollection = new EventCollection();
        public EventCollection Lectures
        {
            get => _eventCollection;
            set => SetValue(ref _eventCollection, value);
        }

        private int _month = DateTime.Today.Month;
        public int Month
        {
            get => _month;
            set
            {
                SetValue(ref _month, value);
                ExecuteUpdate();
            }
        }

        public int _year = DateTime.Today.Year;
        public int Year
        {
            get => _year;
            set
            {
                SetValue(ref _year, value);
                ExecuteUpdate();
            }
        }

        private DateTime _selectedDate = DateTime.Today;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetValue(ref _selectedDate, value);
        }

        private DateTime _minimumDate = DateTime.Today.AddYears(-1);
        public DateTime MinimumDate
        {
            get => _minimumDate;
            set => SetValue(ref _minimumDate, value);
        }

        private DateTime _maximumDate = DateTime.Today.AddYears(1);
        public DateTime MaximumDate
        {
            get => _maximumDate;
            set => SetValue(ref _maximumDate, value);
        }
        
        public TimetableViewModel(INavigationService navigationService, IRepository<User> userRepository) : base(navigationService)
        {
            _userRepository = userRepository;
        }

        private void MoveToToday()
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;
            SelectedDate = DateTime.Now;
        }

        private async void ExecuteUpdate()
        {
            await AddLectures();
        }

        private async Task AddLectures()
        {
            // var user = await _userRepository.GetItemByIdAsync(1);
            // var lectures = user.Timetable;
            // foreach (var lecture in lectures)
            // {
            // }
        }

        public override async Task Init(object param)
        {
            await AddLectures();
        }
    }
}