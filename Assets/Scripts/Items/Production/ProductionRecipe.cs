using System.Collections.Generic;
using UnityEngine;

namespace ProjectCaravan.Items.Production
{
    [CreateAssetMenu(fileName = "New Production", menuName = "Items/Production")]
    public class ProductionRecipe : ScriptableObject
    {
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
}

