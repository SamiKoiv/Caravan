using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CaravanCount : MonoBehaviour
{
    private TextMeshProUGUI CountField;

    void Awake()
    {
        CountField = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        MasterClock.UI.EverySecond += UpdateCount;
    }

    private void OnDisable()
    {
        MasterClock.UI.EverySecond -= UpdateCount;
    }

    void UpdateCount()
    {
        CountField.text = Caravan.AllCaravans.Count.ToString();
    }
}
