using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class City : Location
{
    private float timeUntilNext;

    void Start()
    {
        Inventory = StartInventory;
        timeUntilNext = Time.time + 1;
    }
}
