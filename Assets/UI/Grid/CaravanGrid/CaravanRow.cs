using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CaravanRow : Row
{
    [SerializeField] private TextMeshProUGUI Field_ID = default;
    [SerializeField] private TextMeshProUGUI Field_DestinationA = default;
    [SerializeField] private TextMeshProUGUI Field_DestinationB = default;
    [SerializeField] private TextMeshProUGUI Field_State = default;
    [SerializeField] private TextMeshProUGUI Field_Load = default;

    private Caravan caravan;

    private void OnEnable()
    {
        MasterClock.UI.TwoTimesPerSecond += UpdateRow;
    }

    private void OnDisable()
    {
        MasterClock.UI.TwoTimesPerSecond -= UpdateRow;
    }

    public void SetCaravan(Caravan caravan)
    {
        this.caravan = caravan;
    }

    private void UpdateRow()
    {
        if (caravan == null) return;

        Field_ID.text = caravan.ID.ToString();
        Field_DestinationA.text = caravan.DestinationA.Name;
        Field_DestinationB.text = caravan.DestinationB.Name;
        Field_State.text = caravan.State.ToString();
        Field_Load.text = caravan.Inventory.ToString();
    }
}
