using UnityEngine;

namespace ProjectCaravan.Items
{
    [System.Serializable]
    public class InventoryContent
    {
        [HideInInspector] public string key = "Content";

        #region Item
        [SerializeField] private Item _item = default;
        public Item Item => _item;
        #endregion

        #region Amount
        [SerializeField] private int _amount = default;
        public int Quantity => _amount;
        #endregion

        #region Quality
        //Max quality = 255
        [SerializeField] private byte _quality = default;
        public byte Quality => _quality;
        #endregion

        public InventoryContent(Item item, int quantity, byte quality)
        {
            this._item = item;
            this._amount = quantity;
            this._quality = quality;

            key = _item.Name;
        }

        public void RefreshName() => key = Item.Name;

        public bool Add(InventoryContent newContent)
        {
            if (newContent.Item != this.Item)
                return false;

            int totalAmount = this.Quantity + newContent.Quantity;
            float totalQuality = this.Quality * this.Quantity + newContent.Quality * newContent.Quantity;
            this._quality = (byte)Mathf.RoundToInt(totalQuality / totalAmount);
            this._amount = totalAmount;

            return true;
        }

        public bool Reduce(int amount)
        {
            if (this.Quantity < amount)
                return false;

            this._amount -= amount;

            return true;
        }

    }

}
