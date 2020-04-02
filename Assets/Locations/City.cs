using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class City : Location
{
    public TextMeshPro DisplayedStored;

    private float timeUntilNext;

    public override int Inventory
    {
        get => _inventory;
        set
        {
            _inventory = value;
            DisplayedStored.text = Inventory.ToString();
        }
    }

    void Start()
    {
        Inventory = StartInventory;
        timeUntilNext = Time.time + 1;
    }
}
