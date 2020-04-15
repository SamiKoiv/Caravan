using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New Production", menuName = "Items/Production")]
public class ProductionRecipe : ScriptableObject
{
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

    public class Production
    {
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
        }

        public void StartProduction()
        {
            MasterClock.InGame.EveryFrame -= Update;

            MasterClock.InGame.EveryFrame += Update;
            Debug.Log($"Started producing {_recipe.Product.Name}");
        }

        public void StopProduction()
        {
            MasterClock.InGame.EveryFrame -= Update;
            Debug.Log($"Stopped producing {_recipe.Product.Name}");
        }

        private void Update()
        {
            Debug.Log($"{_recipe.Product.Name} production update");

            if (!isProducing && Requirements.All(x => _inventory.HasEnough(x.Item, x.Amount, x.MinQuality)))
            {
                Requirements.ToList().ForEach(x => _inventory.Withdraw(x.Item, x.Amount));
                isProducing = true;

                Debug.Log($"{_recipe.Product.Name} production gathered ingredients");
            }
            else if (isProducing)
            {
                t += MasterClock.InGame.DeltaTime;

                if (t > TimeToProduce)
                {
                    t = 0;
                    isProducing = false;
                    _inventory.Deposit(new Inventory.Content(Product, 1, Quality));

                    Debug.Log($"new {_recipe.Product.Name} ready");
                }
            }
            else
            {
                Debug.Log($"{_recipe.Product.Name} production waiting");
            }
        }
    }

    #region Product
    [SerializeField] private Item _product = default;
    public Item Product => _product;
    #endregion

    #region Time to Produce
    [SerializeField] private float _timeToProduce = default;
    public float TimeToProduce => _timeToProduce;
    #endregion

    #region Requirements
    [SerializeField] private List<Requirement> _requirements = new List<Requirement>();
    public List<Requirement> Requirements => _requirements;
    #endregion

    private void OnValidate()
    {
        Requirements.ForEach(x => x.key = x.Item != null ? $"{x.Item.Name}({x.Amount})" : "Empty");
    }

}
