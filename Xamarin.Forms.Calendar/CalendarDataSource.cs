using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Diagnostics;

namespace Xamarin.Forms.Calendar
{
    public class CalendarDataSource
    {
        public string Title => "Calendar";

        private List<Day> _calendarData;

        public CalendarDataSource()
        {
        }

        public IEnumerable<Day> DataSource => GetDays(new DateTime(2019, 1, 1), 4);


        public IEnumerable<Day> MappedDataSource => MapDaysToDisplay();

        public List<string> HeaderDataSource { get; set; }

        public List<Day> MapDaysToDisplay()
        {
            var days = DataSource.ToList();

            List<Day> mapped = new List<Day>();

            var displayedDays = 7;
            var startOfWeek = DayOfWeek.Monday;

            // get first day in list.
            var firstDay = days.First();


            // calendar
            // get dates from start to x.
            // create model of dates for view.
            // this model will contain placeholders for empty cells.
            // the empty cells can be used to store the header for the month.

            // calc number of cells needed for first week.
            // lets day the first day of week is monday, but today is wednesday - we need to fill in monday and tuesday with an empty cell.

            var daysTemp = NumOfDaysSince(startOfWeek, firstDay.Date);

            var dates = GetDatesBetweenDates(firstDay.Date.AddDays(-daysTemp), firstDay.Date);

            var tempDays = dates.Select(date => new Day()
            {
                Date = date,
                IsTemp = 1
            });

            var tmp = new List<Day>();
            tmp.AddRange(tempDays);
            tmp.AddRange(days);

            //var week = tmp.Take(7);
            //foreach (var item in week)
            //{
            //    HeaderDataSource.Add(item.Date.DayOfWeek.ToString());
            //}

            List<Day> newList = new List<Day>();

            try
            {

                for (int indx = 0; indx < tmp.Count()-1; indx++)
                {
                    newList.Add(tmp[indx]);

                    var firstTempDay = tmp[indx];
                    var nextTempDay = tmp[indx + 1];

                    if (firstTempDay.Date.Month != nextTempDay.Date.Month)
                    {
                        var temporyDays = CreateTempDays();

                        var lastDay = temporyDays.Last();
                        lastDay.Month = nextTempDay.Date.ToString("MMM");
                        lastDay.IsTemp = 2;

                        newList.AddRange(temporyDays);                        
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return newList; 
        }

        public List<Day> CreateTempDays()
        {            
            var tempDays = Enumerable.Range(0, 7);

            var days = tempDays.Select(date => new Day()
            {                
                IsTemp = 1
            }).ToList();

            return days;
        }

        public int NumOfDaysSince(DayOfWeek dayOfWeek, DateTime date)
        {
            int day = 0;
            while (true)
            {
                var dt = date.AddDays(-day);
               
                if (dt.DayOfWeek != dayOfWeek)
                {                    
                    day++;
                }
                else
                {
                    break;
                }
            }

            return day;
        }




        public IEnumerable<Day> GetDays(DateTime start, DateTime end)
        {
            var dates = GetDatesBetweenDates(start, end);

            var days = dates.Select(date => new Day()
            {
                Date = date
            });

            
            //var days = Enumerable.Range(0, 10)
            //            .Select(offset => new Day()
            //            {
            //                Date = start.AddDays(offset)
            //            });


            return days;
        }

        public IEnumerable<Day> GetDays(DateTime start, int months)
        {
            var end = start.AddMonths(months).AddDays(-1);

            return GetDays(start, end);
        }

        public IEnumerable<DateTime> GetDatesBetweenDates(DateTime start, DateTime end)
        {
            var dates = Enumerable.Range(0, end.Subtract(start).Days)
              .Select(offset => start.AddDays(offset))
              .ToArray();

            return dates;
        }
    }
}
