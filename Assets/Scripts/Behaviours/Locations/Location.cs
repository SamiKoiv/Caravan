using ProjectCaravan.Core;
using System.Collections.Generic;
using UnityEngine;
using ProjectCaravan.Interfaces;
using ProjectCaravan.Items;
using ProjectCaravan.Items.Production;

namespace ProjectCaravan.Locations
{
    public class Location : MonoBehaviour, IClickable
    {
        #region IClickable

        public bool Highlight
        {
            get => throw new System.NotImplementedException();
            set
            {
                if (value == true)
                    Debug.Log($"Location: Highlighting {Name}");
                else
                    Debug.Log($"Location: Highlight off on {Name}");
            }
        }

        public void LeftClick()
        {
            Debug.Log($"Location: Left Clicked {Name}");
        }

        public void RightClick()
        {
            Debug.Log($"Location: Right Clicked {Name}");
        }
        #endregion

        public string Name => gameObject.name;

        private Location selectingLocation;
        private List<Location> ConnectedWith = new List<Location>();

        #region Start Inventory
        [SerializeField] private Inventory _startInventory = default;
        public Inventory StartInventory => _startInventory;
        #endregion

        #region Inventory
        [SerializeField] private Inventory _inventory = new Inventory();
        public Inventory Inventory => _inventory;
        #endregion

        #region Productions
        [SerializeField] public List<ProductionRecipe> _productionRecipes = new List<ProductionRecipe>();
        [SerializeField] private List<Production> _productions = new List<Production>();
        #endregion

        public Vector3 Position => transform.position;

        protected virtual void Start()
        {
            _productionRecipes.ForEach(x => _productions.Add(new Production(x, _inventory)));
        }

        protected virtual void Update()
        {
            _productions.ForEach(x => x.Update());
        }

        private void OnValidate()
        {
            Inventory.RefreshContentNames();
        }

        public void Connect(Location other)
        {
            Debug.Log($"Connecting {gameObject.name} and {other.gameObject.name}");

            if (!IsConnectedTo(other))
                ConnectedWith.Add(other);
        }

        public bool IsConnectedTo(Location other)
        {
            if (ConnectedWith.Contains(other))
                return true;
            else
                return false;
        }

    }


}
