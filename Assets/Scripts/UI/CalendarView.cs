using System;
using UnityEngine;
using TMPro;

public class CalendarView : MonoBehaviour
{
    public Calendar calendar;
    public TextMeshProUGUI yearValueField;

    private void OnEnable()
    {
        calendar.DayChanged += Refresh;
    }

    private void OnDisable()
    {
        calendar.DayChanged += Refresh;
    }

    private void Refresh(object sender, EventArgs e)
    {

    }
}
