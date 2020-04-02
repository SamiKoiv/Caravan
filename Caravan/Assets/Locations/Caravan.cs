using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caravan : MonoBehaviour
{
    static float arrivalTreshold = 0.2f;

    public Location locatedIn;

    public ActionState state;
    public Location[] waypoints;
    private int waypointIterator;
    public Location NextWaypoint => waypoints[waypointIterator];

    public float moveSpeed = 1;
    public float collectionSpeed = 1;
    private float collectNext;
    public int load;
    public int loadMax;

    public int loadToA_Min;
    public int loadToA_Max;

    public int loadToB_Min;
    public int loadToB_Max;

    public TravelingTo destination;

    public enum ActionState
    {
        NA,
        Traveling,
        Loading,
        Unloading,
        Resting
    }

    public enum TravelingTo
    {
        A,
        B
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

    private void Start()
    {
        transform.position = waypoints[0].Position;
        state = ActionState.Loading;
    }

    void Update()
    {
        switch (state)
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

    void Travel()
    {
        transform.LookAt(NextWaypoint.Position, -Vector3.forward);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

        if (Vector2.Distance(transform.position, NextWaypoint.Position) < arrivalTreshold)
            Arrive();
    }

    void Arrive()
    {
        state = ActionState.Unloading;

        if (!reverseDirection && destination == waypoints.Length - 1)
        {
            Unload();
            ChangeDirection();
        }

        if (reverseDirection && destination == 0)
        {
            Unload();
            ChangeDirection();
        }
    }

    void Unload()
    {

        NextWaypoint.Inventory += load;
        load = 0;
    }

    void Rest()
    {

    }

    void ChangeDirection()
    {
        if (destination == 0)
        {
            reverseDirection = false;
        }
        else if (destination == waypoints.Length - 1)
        {
            reverseDirection = true;
        }
    }

    void TravelToNext()
    {

        if (reverseDirection)
            destination = Mathf.Max(destination - 1, 0);
        else
            destination = Mathf.Min(destination + 1, waypoints.Length - 1);

        traveling = true;
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
                TravelToNext();

            collectNext -= 1;
        }

        if (load >= NextLoad_Max)
        {
            load = NextLoad_Max;
            collectNext = 0;
            TravelToNext();
        }

        collectNext += Time.deltaTime * collectionSpeed;
    }
}
