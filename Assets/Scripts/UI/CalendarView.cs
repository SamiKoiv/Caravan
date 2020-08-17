using System;
using UnityEngine;
using TMPro;
using ProjectCaravan.Core;

public class CalendarView : MonoBehaviour
{
    public TextMeshProUGUI yearValueField;
    public TextMeshProUGUI seasonValueField;
    public TextMeshProUGUI monthValueField;
    public TextMeshProUGUI weekValueField;
    public TextMeshProUGUI dayValueField;

    private Calendar calendar;

    private void OnEnable()
    {
        if (calendar == null)
            calendar = GameManager.Instance.Calendar;

        calendar.DayChanged += Refresh;
    }

    private void OnDisable()
    {
        calendar.DayChanged -= Refresh;
    }

    private void Refresh(object sender, EventArgs e)
    {
        yearValueField.text = calendar.Year.ToString();
        seasonValueField.text = calendar.Season.ToString();
        monthValueField.text = calendar.Month.ToString();
        weekValueField.text = calendar.WeekInMonth.ToString();
        dayValueField.text = calendar.DayInWeek.ToString();
    }
}
