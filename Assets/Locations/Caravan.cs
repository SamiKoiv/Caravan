using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caravan : MonoBehaviour
{
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


    #region Load
    [SerializeField] private int _currentLoad;
    public int CurrentLoad => _currentLoad;
    #endregion

    public Vector2 Position => transform.position;
    public Location CurrentWaypoint => waypoints[WaypointIterator];

    #endregion

    #region Private Properties

    #region Tracking


    [SerializeField] Location[] waypoints;

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
    [SerializeField] private float collectionSpeed = 1;
    [SerializeField] private float collectNext;
    [SerializeField] int loadMax;

    [SerializeField] int loadToA_Min;
    [SerializeField] private int loadToA_Max;

    [SerializeField] private int loadToB_Min;
    [SerializeField] private int loadToB_Max;

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
        transform.LookAt(CurrentWaypoint.Position, -Vector3.forward);
        transform.Translate(Vector3.forward * DeltaTime * moveSpeed);

        if (Vector2.Distance(transform.position, CurrentWaypoint.Position) < arrivalTreshold)
            Arrive();
    }

    void Arrive()
    {
        _state = ActionState.Unloading;
    }

    void Unload()
    {
        CurrentWaypoint.Inventory += _currentLoad;
        _currentLoad = 0;
        _state = ActionState.Resting;
    }

    void Rest()
    {
        _state = ActionState.Loading;
    }

    void Load()
    {
        if (_currentLoad == NextLoad_Max)
        {
            collectNext = 0;
            EmbarkToNextDestination();
            return;
        }

        collectNext += DeltaTime * collectionSpeed;

        if (collectNext > 1)
        {
            if (waypoints[destination].Inventory > 0)
            {
                waypoints[destination].Inventory -= 1;
                _currentLoad += 1;
            }
            else if (_currentLoad >= NextLoad_Min)
            {
                EmbarkToNextDestination();
                return;
            }

            collectNext -= 1;
        }
    }

    void EmbarkToNextDestination()
    {
        if (destination == 0)
        {
            destination = waypoints.Length - 1;
            WaypointIterator += 1;
        }
        else if (destination == waypoints.Length - 1)
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
