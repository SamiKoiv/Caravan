using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProjectCaravan.Items
{
    [System.Serializable]
    public class Inventory
    {
        [SerializeField] private List<InventoryContent> _contents = new List<InventoryContent>();
        private List<InventoryContent> Contents => _contents;

        public int TotalItems => Contents.Sum(x => x.Quantity);

        public void RefreshContentNames() => Contents.ForEach(x => x.RefreshName());
        public bool HasEnough(Item item, int amount) => Contents.Any(x => x.Item == item && x.Quantity >= amount);
        public bool HasEnough(Item item, int amount, float minQuality) => Contents.Any(x => x.Item == item && x.Quantity >= amount && x.Quality >= minQuality);
        public void Deposit(InventoryContent content)
        {
            var existingContent = Contents
                .FirstOrDefault(x => x.Item == content.Item);

            if (existingContent != null)
                existingContent.Add(content);
            else
                Contents.Add(content);
        }
        public InventoryContent Withdraw(Item item, int amount)
        {
            var content = Contents
                .First(x => x.Item == item && x.Quantity >= amount);

            content.Reduce(amount);

            if (content.Quantity == 0)
                Contents.Remove(content);

            return new InventoryContent(item, amount, content.Quality);
        }
    }
}
