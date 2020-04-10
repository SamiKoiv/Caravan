using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        None,
        Food,
        Weapons,
        Armor,
        Clothing,
        Tools,
        Other
    }

    #region ID
    [SerializeField] private int _id;
    public int ID => _id;
    #endregion

    #region Name
    [SerializeField] protected string _name;
    public string Name => _name;
    #endregion

    #region Type

    private ItemType _type;
    public ItemType Type => _type;

    #endregion

    #region Value
    [SerializeField] protected int _value;
    public int Value => _value;
    #endregion

    public void TrySetID(int newID) => _id = ID == 0 ? newID : ID;
    public void SetName(string newName) => _name = newName;
    public void SetType(ItemType type) => _type = type;
    public void SetValue(int newValue) => _value = newValue;

}
