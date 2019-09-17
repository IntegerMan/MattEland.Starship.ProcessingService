namespace MattEland.Starship.Logic
{
    public struct GameTime
    {
        public int Day { get; }
        public int Month { get; }
        public int Year { get; }
        public int Hour { get; }
        public int Minute { get; }

        public GameTime( int month, int day, int year, int hour, int minute)
        {
            Day = day;
            Month = month;
            Year = year;
            Hour = hour;
            Minute = minute;
        }

        public GameTime Increment(int minutes)
        {
            int min = this.Minute + minutes;
            int hour = this.Hour;
            int day = this.Day;
            int month = this.Month;
            int year = this.Year;

            while (min >= 60)
            {
                min -= 60;
                hour++;
            }

            while (hour >= 24)
            {
                hour -= 24;
                day++;
            }

            while (day > 30)
            {
                day -= 30;
                month++;
            }

            while (month > 12)
            {
                month -= 12;
                year++;
            }

            return new GameTime(month, day, year, hour, min);
        }

        public override string ToString()
        {
            return $"{this.Month}.${this.Day}.${this.Year} ${this.Hour}:${this.Minute}";
        }
    }
}