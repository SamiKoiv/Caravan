using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Clickable : MonoBehaviour
{
    [SerializeField] private UnityEvent OnHighlight = default;
    [SerializeField] private UnityEvent OnHighlightOff = default;
    [SerializeField] private UnityEvent OnLeftClick = default;
    [SerializeField] private UnityEvent OnRightClick = default;
    [SerializeField] private UnityEvent<Clickable> OnConnect = default;

    public void Highlight() => OnHighlight.Invoke();
    public void HighlightOff() => OnHighlightOff.Invoke();
    public void LeftClick() => OnLeftClick.Invoke();
    public void RightClick() => OnRightClick.Invoke();
    public void Connect(Clickable other) => OnConnect.Invoke(other);
}
