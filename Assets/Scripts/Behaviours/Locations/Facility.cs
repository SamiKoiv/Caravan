using ProjectCaravan.Items;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Facility", menuName = "Facility")]
public class Facility : ScriptableObject
{
    //Inventory access
    [SerializeField] private Inventory inventory;

    //Consumption
    [SerializeField] private List<InventoryContent> consumption = new List<InventoryContent>();

    //Production
    [SerializeField] private List<InventoryContent> production = new List<InventoryContent>();

    public void Run()
    {
        //Connects to inventory
        //Consumes items as raw material
        //After production time, outputs end products
        
        if (ConsumptionRequirementsMet)
        {
            RunProduction();
        }
    }

    private bool ConsumptionRequirementsMet => consumption.All(x => inventory.HasEnough(x.Item, x.Quantity));

    private void RunProduction()
    {
        consumption.ForEach(x => inventory.Withdraw(x.Item, x.Quantity));
        production.ForEach(x => inventory.Deposit(x));
    }
}
