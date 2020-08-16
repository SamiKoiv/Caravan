using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Calendar : MonoBehaviour
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

    private float secondsPerDay;
    private int daysPerWeek = 6;
    private int daysPerMonth = 30;
    private int daysPerSeason = 90;
    private int daysPerYear = 360;
    private int seasons = 4;

    public int day = 1;
    public int week = 1;
    public int month = 1;
    public Seasons season = (Seasons)1;
    public int year = 1;

    public float timeSpeedMultiplier = 1;
    private float t = 0;

    private void Start()
    {
        day = 1;
        year = 1328;
    }

    private void Update()
    {
        t += Time.deltaTime * timeSpeedMultiplier;

        while (t > 1)
        {
            NextDay();
            t--;
        }
    }

    private void NextDay()
    {
        day++;
        if (day % daysPerWeek == 1) NextWeek();

        DayChanged?.Invoke(this, new EventArgs());
    }

    private void NextWeek()
    {
        week++;
        if (day % daysPerMonth == 1) NextMonth();

        WeekChanged?.Invoke(this, new EventArgs());
    }

    private void NextMonth()
    {
        month++;
        if (day % daysPerSeason == 1) NextSeason();
        if (day % daysPerYear == 1) NextYear();

        MonthChanged?.Invoke(this, new EventArgs());
    }

    private void NextSeason()
    {
        season++;
        SeasonChanged?.Invoke(this, new EventArgs());
    }

    private void NextYear()
    {
        year++;
        day = 1;
        week = 1;
        month = 1;
        season = (Seasons)1;

        YearChanged?.Invoke(this, new EventArgs());
    }

}
