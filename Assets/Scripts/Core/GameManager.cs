using UnityEngine;
using ProjectCaravan.Core.UserInput;
using ProjectCaravan.Locations;
using System.Net.Configuration;
using System.Collections.Generic;

namespace ProjectCaravan.Core
{
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

        List<IUpdate> Updatables = new List<IUpdate>();

        public Material RoadMaterial;

        private Location selectedLocation;

        private MouseController mouseController = new MouseController();

        public Calendar Calendar { get; } = new Calendar(1328);

        float deltaTime;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(gameObject);

            Updatables.Add(Calendar);
        }

        private void Update()
        {
            mouseController.Run();

            deltaTime = Time.deltaTime;
            Updatables.ForEach(x => x.Update(deltaTime));
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
}
