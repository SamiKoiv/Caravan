using ProjectCaravan.Core;
using System.Linq;
using UnityEngine;

namespace ProjectCaravan.Locations
{
    public class Road : MonoBehaviour
    {
        private LineRenderer line;
        private Location[] _locations;

        public Location[] Locations
        {
            get => _locations;
            set
            {
                if (_locations == null)
                {
                    _locations = value;
                    line.SetPositions(Locations.Select(x => x.Position).ToArray());
                }
            }
        }

        void Start()
        {
            line = GetComponent<LineRenderer>();
            line.positionCount = 2;
        }

        public void SetLineRenderer(LineRenderer line)
        {
            line.startWidth = 0.1f;
            line.endWidth = 0.1f;
            line.material = GameManager.Instance.RoadMaterial;

            this.line = line;
        }

        public static void MakeRoadBetween(Location a, Location b)
        {
            var newObject = new GameObject("Road");
            var road = (Road)newObject.AddComponent(typeof(Road));
            var line = (LineRenderer)newObject.AddComponent(typeof(LineRenderer));
            road.SetLineRenderer(line);
            road.Locations = new Location[2] { a, b };
            road.transform.position = -Vector3.forward * 0.5f;
        }

    }

}