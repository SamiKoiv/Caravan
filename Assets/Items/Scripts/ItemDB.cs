using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

[CreateAssetMenu(fileName = "New ItemDB", menuName = "Database/ItemDB")]
public class ItemDB : ScriptableObject
{
    public int NextID => Items.Aggregate(0, (top, item) => Mathf.Max(top, item.ID)) + 1;

    #region Items
    [SerializeField] List<Item> _items = new List<Item>();
    public List<Item> Items => _items;
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
