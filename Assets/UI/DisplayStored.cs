using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayStored : MonoBehaviour
{
    [SerializeField] TextMeshPro textField;
    [SerializeField] Location location;

    void Start()
    {
        MasterClock.UI.TenTimesPerSecond += () => textField.text = location.Inventory.ToString();
    }

}
