using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectCaravan.Items
{
    [System.Serializable]
    //[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
    public class Item : ScriptableObject
    {
        public enum ItemType
        {
            None,
            Money,
            RawMaterials,
            ProcessedMaterials,
            Food,
            Refreshments,
            Water,
            Weapons,
            Equipment,
            Clothing,
            Tools,
            Other
        }

        public bool IsUnfinished
        {
            get
            {
                if (ID == 0) return true;
                if (Name == string.Empty) return true;
                if (Type == ItemType.None) return true;
                if (Value == 0) return true;
                if (Icon == null) return true;

                return false;
            }
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

        [SerializeField] private ItemType _type;
        public ItemType Type => _type;

        #endregion

        #region Value
        [SerializeField] protected int _value;
        public int Value => _value;
        #endregion

        #region Icon
        [SerializeField] private Sprite _icon;
        public Sprite Icon => _icon;
        #endregion

        public void TrySetID(int newID) => _id = ID == 0 ? newID : ID;
        public void SetName(string newName) => _name = newName;
        public void SetType(ItemType type) => _type = type;
        public void SetValue(int newValue) => _value = newValue;
        public void SetIcon(Sprite sprite) => _icon = sprite;

    }

}
