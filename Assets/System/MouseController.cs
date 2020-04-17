using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController
{
    #region Highlighted
    private Clickable _highlighted;
    private Clickable Highlighted
    {
        get => _highlighted;
        set
        {
            if (_highlighted != null)
                _highlighted.HighlightOff();

            _highlighted = value;

            if (_highlighted != null)
            {
                _highlighted.Highlight();
                Debug.Log($"Highlighted {value.gameObject.name}");
            }
        }
    }
    #endregion

    #region Selected
    private Clickable _selected;
    private Clickable Selected
    {
        get => _selected;
        set
        {
            _selected = value;
        }
    }
    #endregion

    Clickable leftClickingObject;
    Clickable rightClickingObject;

    public void Run()
    {
        var mousePos = Input.mousePosition;
        var screenPos = Camera.main.ScreenToWorldPoint(mousePos);

        var hit = Physics2D.Raycast(screenPos, Vector2.zero);
        if (hit == false) return;

        var clickable = hit.transform.GetComponent<Clickable>();
        if (clickable == null) return;

        if (clickable != leftClickingObject)
            leftClickingObject = null;

        if (clickable != rightClickingObject)
            rightClickingObject = null;

        Highlighted = clickable;

        if (Input.GetMouseButtonDown(0))
        {
            if (rightClickingObject != null) return;

            leftClickingObject = clickable;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (leftClickingObject != null) return;

            rightClickingObject = clickable;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (clickable == leftClickingObject)
            {
                Selected = clickable;
                Selected.LeftClick();
                Debug.Log($"LeftClicked {leftClickingObject.gameObject.name}");
            }

            leftClickingObject = null;
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (clickable == rightClickingObject)
            {
                rightClickingObject.RightClick();
                Debug.Log($"RightClicked {rightClickingObject.gameObject.name}");
            }

            rightClickingObject = null;
        }
    }

    public void ClearSelection() => _selected = null;
    public void ClearHighligh() => _highlighted = null;

}
