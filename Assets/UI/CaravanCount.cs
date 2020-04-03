using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CaravanCount : MonoBehaviour
{
    private TextMeshProUGUI CountField;

    void Start()
    {
        CountField = GetComponent<TextMeshProUGUI>();

        var update = Observable.Timer(System.TimeSpan.FromSeconds(1))
            .Subscribe(x => UpdateCount());
    }

    void UpdateCount()
    {
        CountField.text = Caravan.AllCaravans.Count.ToString();

        var update = Observable.Timer(System.TimeSpan.FromSeconds(1))
            .Subscribe(x => UpdateCount());
    }
}
