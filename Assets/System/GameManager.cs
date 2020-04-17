using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Instance

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance != null)
                return _instance;
            else
            {
                var newObject = new GameObject("GameManager");
                _instance = (GameManager)newObject.AddComponent(typeof(GameManager));
                return _instance;
            }
        }
        set
        {
            if (_instance == null)
                _instance = value;
        }
    }

    #endregion

    public Material RoadMaterial;

    private Location selectedLocation;

    private MouseController mouseController = new MouseController();

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        mouseController.Run();
    }

    public void Select(Location location)
    {
        Debug.Log($"Selecting {location.gameObject.name}");

        if (selectedLocation == null)
        {
            selectedLocation = location;
        }
        else
        {
            if (!selectedLocation.IsConnectedTo(location))
            {
                selectedLocation.Connect(location);
                location.Connect(selectedLocation);

                Road.MakeRoadBetween(selectedLocation, location);
            }

            selectedLocation = null;
        }

        if (selectedLocation != null)
            Debug.Log($"Selected location = {selectedLocation.gameObject.name}");
        else
            Debug.Log($"Selected location = Nothing");
    }

}
