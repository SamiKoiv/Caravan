using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagedUpdate : MonoBehaviour
{
    public delegate void UpdateEvent();
    public static event UpdateEvent EveryUpdate;
    public static event UpdateEvent EverySecond;
}
