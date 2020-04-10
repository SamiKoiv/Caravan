using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class City : Location
{
    private float timeUntilNext;

    public override int Inventory
    {
        get => _inventory;
        set
        {
            _inventory = value;
        }
    }

    void Start()
    {
        Inventory = StartInventory;
        timeUntilNext = Time.time + 1;
    }
}
