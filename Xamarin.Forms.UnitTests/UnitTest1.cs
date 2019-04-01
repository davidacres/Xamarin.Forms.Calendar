using Xamarin.Forms.Calendar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Diagnostics;

namespace Xamarin.Forms.Calendar.UnitTests
{
    [TestClass]
    public class CalendarDataSource_Tests
    {
        [TestMethod]
        public void Testing()
        {
            //var startOfWeek = (int)DayOfWeek.Wednesday;

            //var max = 7;

            //var dtInfo = new System.Globalization.DateTimeFormatInfo();

            //for (int cnt = startOfWeek; cnt< startOfWeek + 7; cnt++)
            //{

            //    int pos = (cnt % max);

            //    var r = dtInfo.GetShortestDayName((DayOfWeek)pos);

            //    Debug.WriteLine($"Position: {pos} Weekday {r}");
            //}            


            var rr = Header(DayOfWeek.Wednesday);


        }

        private string[] Header(DayOfWeek startOfWeek)
        {
            var max = 7;
            var dtInfo = new System.Globalization.DateTimeFormatInfo();
            var start = (int)startOfWeek;

            string[] items = new string[7];
            var indx = 0;

            for (int cnt = start; cnt < start + max; cnt++)
            {
                int pos = (cnt % max);

                var r = dtInfo.GetShortestDayName((DayOfWeek)pos);

                Debug.WriteLine($"Position: {pos} Weekday {r}");

                items[indx] = r;


                indx++;

            }

            return items;
        }



        [TestMethod]
        public void CalendarDataSource_GetDatesBetweenDates_Returns31()
        {
            var data = new CalendarDataSource();

            var start = new DateTime(2019, 1, 1);
            var end = start.AddMonths(1).AddDays(-1);

            var dates = data.GetDatesBetweenDates(start, end);

            Assert.AreEqual(31, dates.Count());


        }

        [TestMethod]
        public void CalendarDataSource_GetDays_WithStartAndEnd_Returns31()
        {
            var data = new CalendarDataSource();
            var start = new DateTime(2019, 1, 1);
            var end = start.AddMonths(1).AddDays(-1);

            var days = data.GetDays(start, end);

            Assert.AreEqual(31, days.Count());
        }

        [TestMethod]
        public void CalendarDataSource_GetDays_With_1Month_Returns31()
        {
            var data = new CalendarDataSource();
            var start = new DateTime(2019, 1, 1);
     
            var days = data.GetDays(start, 1);

            Assert.AreEqual(31, days.Count());
        }

        [TestMethod]
        public void CalendarDataSource_CreateTempDays_Returns7()
        {
            // Jan 2019
            // how many records do we need for display purposes.

            var cds = new CalendarDataSource();

            var days = cds.CreateTempDays();

            Assert.AreEqual(7, days.Count());

          //  cds.mapDaysToDisplay();


        }

        [TestMethod]
        public void CalendarDaysNumOfDaysSince1()
        {
            var cds = new CalendarDataSource();

            var startDate = new DateTime(2019, 01, 01);

            var days = cds.NumOfDaysSince(DayOfWeek.Monday, startDate);
            Assert.AreEqual(1, days);

            var pp = cds.MapDaysToDisplay();

            var data = cds.MappedDataSource;

            


        }



        [TestMethod]
        public void CalendarDaysNumOfDaysSince()
        {
            var cds = new CalendarDataSource();

            var startDate = new DateTime(2019, 03, 11);

            var days = cds.NumOfDaysSince(DayOfWeek.Sunday, startDate);
            Assert.AreEqual(1, days);

            days = cds.NumOfDaysSince(DayOfWeek.Saturday, startDate);
            Assert.AreEqual(2, days);

            days = cds.NumOfDaysSince(DayOfWeek.Friday, startDate);
            Assert.AreEqual(3, days);

            days = cds.NumOfDaysSince(DayOfWeek.Thursday, startDate);
            Assert.AreEqual(4, days);

            days = cds.NumOfDaysSince(DayOfWeek.Wednesday, startDate);
            Assert.AreEqual(5, days);

            days = cds.NumOfDaysSince(DayOfWeek.Tuesday, startDate);
            Assert.AreEqual(6, days);

            days = cds.NumOfDaysSince(DayOfWeek.Monday, startDate);
            Assert.AreEqual(0, days);



        }


    }
}