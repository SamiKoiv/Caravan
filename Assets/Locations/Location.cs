using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public abstract class Location : MonoBehaviour
{
    public string Name => gameObject.name;

    private Location selectingLocation;
    private List<Location> ConnectedWith = new List<Location>();

    #region Start Inventory
    [SerializeField] private Inventory _startInventory = default;
    public Inventory StartInventory => _startInventory;
    #endregion

    #region Inventory
    [SerializeField] private Inventory _inventory = default;
    public Inventory Inventory { get; set; }
    #endregion

    #region Productions
    [SerializeField] public List<ProductionRecipe> _productionRecipes = new List<ProductionRecipe>();
    private List<ProductionRecipe.Production> _productions = new List<ProductionRecipe.Production>();
    #endregion

    private void Update()
    {
        if (_productionRecipes.Count > 0)
            Debug.Log($"Updating {gameObject.name}");

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log($"Pressed O");

            _productionRecipes.ForEach(x =>
            {
                var production = new ProductionRecipe.Production(x, _inventory);
                production.StartProduction();
                _productions.Add(production);
            });
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log($"Pressed P");
            _productions.ForEach(x => x.StopProduction());
            _productions.Clear();
        }
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

    public Vector3 Position => transform.position;

    #region Mouse Commands

    private void OnMouseDown()
    {
        selectingLocation = this;
    }

    private void OnMouseUp()
    {
        Debug.Log($"{gameObject.name} clicked");

        if (selectingLocation == this)
            GameManager.Instance.Select(this);

        selectingLocation = null;
    }

    private void OnMouseExit()
    {
        selectingLocation = null;
    }

    #endregion
}
