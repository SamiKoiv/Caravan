using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

[System.Serializable]
[CreateAssetMenu(fileName = "New ItemDB", menuName = "Items/ItemDB")]
public class ItemDB : ScriptableObject
{
    public int NextID => Items.Aggregate(0, (top, item) => Mathf.Max(top, item.ID)) + 1;

    #region Items
    [SerializeField] List<Item> _items;
    public List<Item> Items
    {
        get
        {
            if (_items == null) _items = new List<Item>();
            return _items;
        }
    }
    #endregion

    public void AddItem(Item item)
    {
        item.TrySetID(NextID);
        _items.Add(item);
    }

    public void DeleteItem(Item item)
    {
        _items.Remove(item);
    }

    public void ClearMissing()
    {
        _items = _items.Where(x => x != null).ToList();
    }
}
