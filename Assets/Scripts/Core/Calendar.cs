using System;
using UnityEngine;

namespace ProjectCaravan.Core
{
    public class Calendar : IUpdate
    {
        public event EventHandler DayChanged;
        public event EventHandler WeekChanged;
        public event EventHandler MonthChanged;
        public event EventHandler SeasonChanged;
        public event EventHandler YearChanged;

        public enum Seasons
        {
            Spring = 1,
            Summer = 2,
            Autumn = 3,
            Winter = 4
        }

        private float secondsPerDay = 1;
        private int daysPerWeek = 6;
        private int daysPerMonth = 30;
        private int daysPerSeason = 90;
        private int daysPerYear = 360;
        private int seasons = 4;

        public int Day { get; private set; } = 1;
        public int Week { get; private set; } = 1;
        public int Month { get; private set; } = 1;
        public Seasons Season { get; private set; } = (Seasons)1;
        public int Year { get; private set; } = 1;

        public int DayInWeek { get => Day - daysPerWeek * (Week - 1); }
        public int WeekInMonth { get => Week - (Month - 1) * daysPerMonth / daysPerWeek; }

        public float timeSpeedMultiplier = 1;
        private float t = 0;

        public Calendar(int startingYear)
        {
            Year = startingYear;
            Day = 1;
        }

        public void Update(float time)
        {
            t += time * timeSpeedMultiplier;

            while (t > secondsPerDay)
            {
                Debug.Log("Day passes");
                NextDay();
                t--;
            }
        }

        private void NextDay()
        {
            Day++;
            if (Day % daysPerWeek == 1) NextWeek();

            DayChanged?.Invoke(this, new EventArgs());
        }

        private void NextWeek()
        {
            Week++;
            if (Day % daysPerMonth == 1) NextMonth();

            WeekChanged?.Invoke(this, new EventArgs());
        }

        private void NextMonth()
        {
            Month++;
            if (Day % daysPerSeason == 1) NextSeason();
            if (Day % daysPerYear == 1) NextYear();

            MonthChanged?.Invoke(this, new EventArgs());
        }

        private void NextSeason()
        {
            Season++;
            SeasonChanged?.Invoke(this, new EventArgs());
        }

        private void NextYear()
        {
            Year++;
            Day = 1;
            Week = 1;
            Month = 1;
            Season = (Seasons)1;

            YearChanged?.Invoke(this, new EventArgs());
        }

    } 
}
