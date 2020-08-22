using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectCaravan.Items
{
    [CreateAssetMenu(fileName = "New Needs", menuName = "Items/Needs")]
    public class Needs : ScriptableObject
    {
        #region Water
        [SerializeField] private int _water = default;
        public int Water => _water;
        #endregion

        #region Raw Meat
        [SerializeField] private int _rawMeat = default;
        public int RawMeat => _rawMeat;
        #endregion

        #region Food
        [SerializeField] private int _food = default;
        public int Food => _food;
        #endregion

        #region Refreshments
        [SerializeField] private int _refreshments = default;
        public int Refreshments => _refreshments;
        #endregion

        #region Ore
        [SerializeField] private int _ore = default;
        public int Ore => _ore;
        #endregion

        #region Coal
        [SerializeField] private int _coal = default;
        public int Coal => _coal;
        #endregion

        #region Processed Metal
        [SerializeField] private int _processedMetal = default;
        public int ProcessedMetal => _processedMetal;
        #endregion

        #region Wood
        [SerializeField] private int _wood = default;
        public int Wood => _wood;
        #endregion

        #region Processed Wood
        [SerializeField] private int _processedWood = default;
        public int ProcessedWood => _processedWood;
        #endregion

        #region Paper
        [SerializeField] private int _paper = default;
        public int Paper => _paper;
        #endregion

        #region Wool
        [SerializeField] private int _wool = default;
        public int Wool => _wool;
        #endregion

        #region Leather
        [SerializeField] private int _leather = default;
        public int Leather => _leather;
        #endregion

        #region Fabric
        [SerializeField] private int _fabric = default;
        public int Fabric => _fabric;
        #endregion

        #region Clothing
        [SerializeField] private int _clothing = default;
        public int Clothing => _clothing;
        #endregion
    }

}
