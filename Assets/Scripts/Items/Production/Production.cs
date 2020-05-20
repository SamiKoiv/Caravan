using ProjectCaravan.Core;
using System.Collections.Generic;
using System.Linq;

namespace ProjectCaravan.Items.Production
{
    [System.Serializable]
    public class Production
    {
        public string key = "";
        private ProductionRecipe _recipe;
        private Item Product => _recipe.Product;
        private List<Requirement> Requirements => _recipe.Requirements;
        private float TimeToProduce => _recipe.TimeToProduce;
        private byte Quality => 100;

        private Inventory _inventory;

        private bool isProducing;
        private float t = 0;

        public Production(ProductionRecipe recipe, Inventory inventory)
        {
            this._recipe = recipe;
            this._inventory = inventory;
            this.key = recipe.Product.Name;
        }

        public void Update()
        {
            if (!isProducing && Requirements.All(x => _inventory.HasEnough(x.Item, x.Amount, x.MinQuality)))
            {
                Requirements.ToList().ForEach(x => _inventory.Withdraw(x.Item, x.Amount));
                isProducing = true;
            }
            else if (isProducing)
            {
                t += MasterClock.InGame.DeltaTime;

                if (t > TimeToProduce)
                {
                    t = 0;
                    isProducing = false;
                    _inventory.Deposit(new Inventory.Content(Product, 1, Quality));
                }
            }
        }
    }

}
