using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Clickable : MonoBehaviour
{
    [SerializeField] private UnityEvent OnHighlight = default;
    [SerializeField] private UnityEvent OnHighlightOff = default;
    [SerializeField] private UnityEvent OnClick = default;
    [SerializeField] private UnityEvent<Clickable> OnConnect = default;

    public void Highlight() => OnHighlight.Invoke();
    public void HighlightOff() => OnHighlightOff.Invoke();
    public void Click() => OnClick.Invoke();
    public void Connect(Clickable other) => OnConnect.Invoke(other);
}
