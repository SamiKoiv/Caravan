using ProjectCaravan.Core;
using System.Collections.Generic;
using UnityEngine;
using ProjectCaravan.Locations;
using ProjectCaravan.Items;
using ProjectCaravan.Interfaces;

namespace ProjectCaravan.Units
{
    public class Caravan : MonoBehaviour, IClickable
    {

        #region IClickable

        public bool Highlight
        {
            get => throw new System.NotImplementedException();
            set
            {
                if (value == true)
                    Debug.Log($"Caravan: Highlighting {gameObject.name}");
                else
                    Debug.Log($"Caravan: Highlight off on {gameObject.name}");
            }
        }

        public void LeftClick()
        {
            Debug.Log($"Caravan: Left Clicked {gameObject.name}");
        }

        public void RightClick()
        {
            Debug.Log($"Caravan: Right Clicked {gameObject.name}");
        }
        #endregion

        public enum ActionState
        {
            NA,
            Traveling,
            Loading,
            Unloading,
            Resting
        }

        #region Debugging
        public bool DebugMode;

        private void DebugLog(string msg)
        {
            if (DebugMode)
                Debug.Log($"{nameof(Caravan)}: {msg}");
        }

        #endregion

        #region Static

        private static float arrivalTreshold = 0.2f;

        #region AllCaravans
        public static List<Caravan> _allCaravans;
        public static List<Caravan> AllCaravans
        {
            get
            {
                if (_allCaravans == null)
                    _allCaravans = new List<Caravan>();

                return _allCaravans;
            }
        }
        #endregion

        #region NextCaravanID
        private static int _nextCaravanID;
        private static int NextCaravanID
        {
            get
            {
                _nextCaravanID += 1;
                return _nextCaravanID;
            }
        }
        #endregion

        #endregion

        #region Properties

        #region Public Properties

        #region ID
        private int _ID;
        public int ID => _ID;
        #endregion

        #region Destinations
        public Location DestinationA => waypoints[0];
        public Location DestinationB => waypoints[waypoints.Length - 1];
        #endregion

        #region ActionState
        [SerializeField] private ActionState _state;
        public ActionState State => _state;

        #endregion

        #region Inventory
        [SerializeField] private Inventory _inventory = default;
        public Inventory Inventory => _inventory;
        #endregion

        public Vector2 Position => transform.position;
        public Location CurrentWaypoint => waypoints[WaypointIterator];

        #endregion

        #region Private Properties

        #region Tracking


        [SerializeField] Location[] waypoints = default;

        private int _waypointIterator;
        private int WaypointIterator
        {
            get => _waypointIterator;
            set
            {
                _waypointIterator = value;
                DebugLog($"Caravan heads to {CurrentWaypoint.Name}");
            }
        }

        #endregion

        private float DeltaTime => MasterClock.InGame.DeltaTime;

        [SerializeField] private float moveSpeed = 1;
        //[SerializeField] private float collectionSpeed = 1;
        //[SerializeField] private float collectNext = default;
        [SerializeField] int loadMax = default;

        [SerializeField] int loadToA_Min = default;
        [SerializeField] private int loadToA_Max = default;

        [SerializeField] private int loadToB_Min = default;
        [SerializeField] private int loadToB_Max = default;

        [SerializeField] private int destination;

        private int NextLoad_Min
        {
            get
            {
                if (destination == 0)
                    return loadToB_Min;
                else
                    return loadToA_Min;
            }
        }

        private int NextLoad_Max
        {
            get
            {
                if (destination == 0)
                    return Mathf.Min(loadToB_Max, loadMax);
                else
                    return Mathf.Min(loadToA_Max, loadMax);
            }
        }

        #endregion

        #endregion

        #region Monobehaviour

        private void OnEnable()
        {
            AllCaravans.Add(this);
        }

        private void OnDisable()
        {
            AllCaravans.Remove(this);
        }

        private void Start()
        {
            _ID = NextCaravanID;
            transform.position = waypoints[0].Position;
            _state = ActionState.Loading;
        }

        void Update()
        {
            switch (State)
            {
                case ActionState.Traveling:
                    Travel();
                    break;

                case ActionState.Unloading:
                    Unload();
                    break;

                case ActionState.Resting:
                    Rest();
                    break;

                case ActionState.Loading:
                    Load();
                    break;
            }
        }

        #endregion

        #region Functionality

        void Travel()
        {
            var dir = (CurrentWaypoint.Position - transform.position).normalized;
            transform.Translate(dir * DeltaTime * moveSpeed);

            if (Vector2.Distance(transform.position, CurrentWaypoint.Position) < arrivalTreshold)
                Arrive();
        }

        void Arrive()
        {
            _state = ActionState.Unloading;
        }

        void Unload()
        {
            //CurrentWaypoint.Inventory += _inventory;
            //_inventory = 0;
            _state = ActionState.Resting;
        }

        void Rest()
        {
            _state = ActionState.Loading;
        }

        void Load()
        {
            //if (_inventory == NextLoad_Max)
            //{
            //    collectNext = 0;
            //    EmbarkToNextDestination();
            //    return;
            //}

            //collectNext += DeltaTime * collectionSpeed;

            //if (collectNext > 1)
            //{
            //    if (waypoints[destination].Inventory.HasEnough(null, 0))
            //    {
            //        waypoints[destination].Inventory.Withdraw(null, 1);
            //        _inventory += 1;
            //    }
            //    else if (_inventory >= NextLoad_Min)
            //    {
            //        EmbarkToNextDestination();
            //        return;
            //    }

            //    collectNext -= 1;
            //}

            EmbarkToNextDestination();
        }

        void EmbarkToNextDestination()
        {
            if (WaypointIterator == 0)
            {
                destination = waypoints.Length - 1;
                WaypointIterator += 1;
            }
            else if (WaypointIterator == waypoints.Length - 1)
            {
                destination = 0;
                WaypointIterator -= 1;
            }
            else
            {
                if (destination > WaypointIterator)
                {
                    WaypointIterator = Mathf.Min(WaypointIterator + 1, waypoints.Length - 1);
                }
                else
                {
                    WaypointIterator = Mathf.Max(WaypointIterator - 1, 0);
                }
            }

            _state = ActionState.Traveling;
        }
        #endregion

    }

}