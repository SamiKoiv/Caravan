using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caravan : MonoBehaviour
{
    #region Debugging
    public bool DebugMode;

    private void DebugLog(string msg)
    {
        if (DebugMode)
            Debug.Log($"{nameof(Caravan)}: {msg}");
    }

    #endregion

    #region Static

    static float arrivalTreshold = 0.2f;

    #endregion

    #region Properties

    public Location locatedIn;

    public ActionState _state;
    public ActionState State
    {
        get => _state;
        set
        {
            _state = value;
            DebugLog($"State changed to {value.ToString()}");
        }
    }

    public Location[] waypoints;

    private int _waypointIterator;
    public int WaypointIterator
    {
        get => _waypointIterator;
        set
        {
            _waypointIterator = value;
            DebugLog($"Caravan heads to {CurrentWaypoint.Name}");
        }
    }
    public Location CurrentWaypoint => waypoints[WaypointIterator];

    public float moveSpeed = 1;
    public float collectionSpeed = 1;
    private float collectNext;
    public int load;
    public int loadMax;

    public int loadToA_Min;
    public int loadToA_Max;

    public int loadToB_Min;
    public int loadToB_Max;

    public int destination;

    public enum ActionState
    {
        NA,
        Traveling,
        Loading,
        Unloading,
        Resting
    }

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

    #region Monobehaviour

    private void Start()
    {
        transform.position = waypoints[0].Position;
        State = ActionState.Loading;
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
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

        if (Vector2.Distance(transform.position, CurrentWaypoint.Position) < arrivalTreshold)
            Arrive();
    }

    void Arrive()
    {
        State = ActionState.Unloading;
    }

    void Unload()
    {
        CurrentWaypoint.Inventory += load;
        load = 0;
        State = ActionState.Resting;
    }

    void Rest()
    {
        State = ActionState.Loading;
    }

    void Load()
    {
        if (collectNext > 1)
        {
            if (waypoints[destination].Inventory > 0)
            {
                waypoints[destination].Inventory -= 1;
                load += 1;
            }
            else if (load > NextLoad_Min)
            {
                EmbarkToNextDestination();
                return;
            }

            collectNext -= 1;
        }

        if (load >= NextLoad_Max)
        {
            load = NextLoad_Max;
            collectNext = 0;
            EmbarkToNextDestination();
            return;
        }

        collectNext += Time.deltaTime * collectionSpeed;
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

        State = ActionState.Traveling;
    }
    #endregion

}
