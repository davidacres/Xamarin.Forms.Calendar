using System;

namespace Xamarin.Forms.Calendar
{
    public class Day : ViewModelBase
    {
        public int IsTemp { get; set; } = 0;

        public DateTime Date { get; set; } = DateTime.MinValue;

        public string DisplayDate => Date.ToString("dd");

        private string month = string.Empty;
        public string Month { get => month; set => Set(ref month, value);  }

        public Day()
        {

        }

    }
}
