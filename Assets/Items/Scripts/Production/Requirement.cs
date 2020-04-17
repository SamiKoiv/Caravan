using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[System.Serializable]
public class Requirement
{
    [HideInInspector] public string key = "key";

    [SerializeField] private Item _item = default;
    public Item Item => _item;

    [SerializeField] private int _amount = default;
    public int Amount => _amount;

    [SerializeField] private byte _minQuality = default;
    public byte MinQuality => _minQuality;
}