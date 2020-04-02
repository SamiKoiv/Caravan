using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public abstract class Location : MonoBehaviour
{
    private Location selectingLocation;
    private List<Location> ConnectedWith = new List<Location>();

    public int StartInventory;

    public int _inventory;
    public abstract int Inventory { get; set; }

    public void Connect(Location other)
    {
        Debug.Log($"Connecting {gameObject.name} and {other.gameObject.name}");

        if (!IsConnectedTo(other))
            ConnectedWith.Add(other);
    }

    public bool IsConnectedTo(Location other)
    {
        if (ConnectedWith.Contains(other))
            return true;
        else
            return false;
    }

    public Vector3 Position => transform.position;

    #region Mouse Commands

    private void OnMouseDown()
    {
        selectingLocation = this;
    }

    private void OnMouseUp()
    {
        Debug.Log($"{gameObject.name} clicked");

        if (selectingLocation == this)
            GameManager.Instance.Select(this);

        selectingLocation = null;
    }

    private void OnMouseExit()
    {
        selectingLocation = null;
    }

    #endregion
}
