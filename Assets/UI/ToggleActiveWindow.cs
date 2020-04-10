using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActiveWindow : MonoBehaviour
{
    static List<ToggleActiveWindow> _windows;
    static List<ToggleActiveWindow> Windows
    {
        get
        {
            if (_windows == null)
                _windows = new List<ToggleActiveWindow>();

            return _windows;
        }
    }

    [SerializeField] private GameObject Target;
    [SerializeField] private KeyCode Key;
    [SerializeField] private bool ShowByDefault;
    [SerializeField] private bool CloseOthers;

    public bool Visible
    {
        get => Target.activeSelf;
        set => Target.SetActive(value);
    }

    private void OnEnable()
    {
        Windows.Add(this);
    }

    private void OnDisable()
    {
        Windows.Remove(this);
    }

    private void Start()
    {
        Visible = ShowByDefault;
    }

    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            var previousState = Visible;

            if (CloseOthers)
                Windows.ForEach(x => x.Close());

            Visible = !previousState;
        }
    }

    public void Close() => Visible = false;
}
