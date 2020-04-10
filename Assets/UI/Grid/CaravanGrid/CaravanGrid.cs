using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CaravanGrid : Grid_Horizontal
{
    void Start()
    {
        MasterClock.UI.TenTimesPerSecond += UpdateView;
    }

    void UpdateView()
    {
        Rows = Caravan.AllCaravans.Count;
        SetupRows();
        var caravanRows = lstRows.Select(x => (CaravanRow)x).ToList();
        var caravans = Caravan.AllCaravans.OrderBy(x => x.ID).ToArray();

        for (int i = 0; i < caravans.Count(); i++)
            caravanRows[i].SetCaravan(caravans[i]);
    }

}
