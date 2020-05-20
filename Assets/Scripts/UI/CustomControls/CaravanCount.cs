using ProjectCaravan.Core;
using TMPro;
using UnityEngine;
using ProjectCaravan.Units;

namespace ProjectCaravan.UI.CustomControls
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CaravanCount : MonoBehaviour
    {
        private TextMeshProUGUI CountField;

        void Awake()
        {
            CountField = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            MasterClock.UI.EverySecond += UpdateCount;
        }

        private void OnDisable()
        {
            MasterClock.UI.EverySecond -= UpdateCount;
        }

        void UpdateCount()
        {
            CountField.text = Caravan.AllCaravans.Count.ToString();
        }
    }
}

