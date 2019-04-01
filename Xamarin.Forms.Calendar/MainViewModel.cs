using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.Calendar
{
    public class MainViewModel : ViewModelBase
    {
        public string Title { get; set; } = "Hello There";

        public List<string> Header = new List<string>() { "M", "T", "W", "T", "F", "S", "S" };

        private CalendarDataSource _calendarDataSource;

        public MainViewModel()
        {
            CalendarSource = new CalendarDataSource();

            //Monkeys = new List<Monkey>();
            //Monkeys.Add(new Monkey() { Name = "Fred 1" });
            //Monkeys.Add(new Monkey() { Name = "Fred 2" });
            //Monkeys.Add(new Monkey() { Name = "Fred 3" });
            //Monkeys.Add(new Monkey() { Name = "Fred 4" });
            //Monkeys.Add(new Monkey() { Name = "Fred 5" });
        }

        public CalendarDataSource CalendarSource
        {
            get => _calendarDataSource;
            set => Set(ref _calendarDataSource, value);
        }

        //private IList<Monkey> _monkeys;

        //public IList<Monkey> Monkeys
        //{
        //    get
        //    {
        //        return _monkeys;
        //    }
        //    set
        //    {
        //        _monkeys = value;
        //    }
        //}



        

    }

    public class Monkey
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
    }
}
