using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mine : Location
{
    private float timer;

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
    }

    void Update()
    {
        timer += MasterClock.InGame.DeltaTime;

        if (timer > 1)
        {
            Inventory += 1;
            timer -= 1;
        }
    }
}
