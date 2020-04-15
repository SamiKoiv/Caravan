using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Location : MonoBehaviour
{
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
    [SerializeField] private List<ProductionRecipe.Production> _productions = new List<ProductionRecipe.Production>();
    #endregion

    public Vector3 Position => transform.position;

    protected virtual void Start()
    {
        _productionRecipes.ForEach(x => _productions.Add(new ProductionRecipe.Production(x, _inventory)));
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
