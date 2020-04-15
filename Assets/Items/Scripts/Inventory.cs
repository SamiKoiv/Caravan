using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Content
    {
        [HideInInspector] public string key = "Content";

        #region Item
        [SerializeField] private Item _item = default;
        public Item Item => _item;
        #endregion

        #region Amount
        [SerializeField] private int _amount = default;
        public int Amount => _amount;
        #endregion

        #region Quality
        //Max quality = 255
        [SerializeField] private byte _quality = default;
        public byte Quality => _quality;
        #endregion

        public Content(Item item, int quantity, byte quality)
        {
            this._item = item;
            this._amount = quantity;
            this._quality = quality;

            key = _item.Name;
        }

        public void RefreshName() => key = Item.Name;

        public bool Add(Content newContent)
        {
            if (newContent.Item != this.Item)
                return false;

            int totalAmount = this.Amount + newContent.Amount;
            float totalQuality = this.Quality * this.Amount + newContent.Quality * newContent.Amount;
            this._quality = (byte)Mathf.RoundToInt(totalQuality / totalAmount);
            this._amount = totalAmount;

            return true;
        }

        public bool Reduce(int amount)
        {
            if (this.Amount < amount)
                return false;

            this._amount -= amount;

            return true;
        }

    }

    [SerializeField] private List<Content> _contents = new List<Content>();
    private List<Content> Contents => _contents;

    public int TotalItems => Contents.Sum(x => x.Amount);

    public void RefreshContentNames() => Contents.ForEach(x => x.RefreshName());
    public bool HasEnough(Item item, int amount) => Contents.Any(x => x.Item == item && x.Amount >= amount);
    public bool HasEnough(Item item, int amount, float minQuality) => Contents.Any(x => x.Item == item && x.Amount >= amount && x.Quality >= minQuality);
    public void Deposit(Content content)
    {
        var existingContent = Contents
            .FirstOrDefault(x => x.Item == content.Item);

        if (existingContent != null)
            existingContent.Add(content);
        else
            Contents.Add(content);
    }
    public Content Withdraw(Item item, int amount)
    {
        var content = Contents
            .First(x => x.Item == item && x.Amount >= amount);

        content.Reduce(amount);

        if (content.Amount == 0)
            Contents.Remove(content);

        return new Content(item, amount, content.Quality);
    }
}
