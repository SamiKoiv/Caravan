using UnityEngine;
using TMPro;
using ProjectCaravan.Locations;
using ProjectCaravan.Core;

namespace ProjectCaravan.UI.CustomControls
{
    public class DisplayStored : MonoBehaviour
    {
        [SerializeField] TextMeshPro textField = default;
        [SerializeField] Location location = default;

        void Start()
        {
            MasterClock.UI.TenTimesPerSecond += () => textField.text = location.Inventory.TotalItems.ToString();
        }
    }
}
