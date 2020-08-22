using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectCaravan.Interfaces;
using UnityEngine.InputSystem;

namespace ProjectCaravan.Core.Input
{
    public class MouseClickController
    {
        Controls ctrl;

        public MouseClickController()
        {
            ctrl = new Controls();
            ctrl.Enable();

            ctrl.Gameplay.Select.performed += Select;
        }

        #region Highlighted
        private IClickable _highlighted;
        private IClickable Highlighted
        {
            get => _highlighted;
            set
            {
                if (_highlighted == value) return;

                if (_highlighted != null)
                    _highlighted.Highlight = false;

                _highlighted = value;

                if (_highlighted != null)
                {
                    _highlighted.Highlight = true;
                }
            }
        }
        #endregion

        #region LeftClickingObject
        IClickable _leftClickingObject;
        IClickable LeftClickingObject
        {
            get => _leftClickingObject;
            set
            {
                if (value == _leftClickingObject) return;

                _leftClickingObject = value;
            }
        }
        #endregion

        #region RightClickingObject
        IClickable _rightClickingObject;
        IClickable RightClickingObject
        {
            get => _rightClickingObject;
            set
            {
                if (value == _rightClickingObject) return;

                _rightClickingObject = value;
            }
        }
        #endregion

        public void Run()
        {
            //var mousePos = ctrl.Gameplay.MousePosition.ReadValue<Vector2>();
            //var screenPos = Camera.main.ScreenToWorldPoint(mousePos);
            //var hit = Physics2D.Raycast(screenPos, Vector2.zero);

            //if (hit == false)
            //{
            //    ClearClickables();
            //    return;
            //}

            //var clickable = hit.transform.GetComponent<IClickable>();
            //if (clickable == null)
            //{
            //    ClearClickables();
            //    return;
            //}

            //if (clickable != LeftClickingObject)
            //    LeftClickingObject = null;

            //if (clickable != RightClickingObject)
            //    RightClickingObject = null;

            //Highlighted = clickable;

            //if (ctrl.Gameplay.Select.(0))
            //{
                
            //}

            //if (Input.GetMouseButtonDown(1))
            //{
            //    if (LeftClickingObject != null) return;

            //    RightClickingObject = clickable;
            //}

            //if (Input.GetMouseButtonUp(0))
            //{
            //    if (clickable == LeftClickingObject)
            //        LeftClickingObject.LeftClick();

            //    LeftClickingObject = null;
            //}

            //if (Input.GetMouseButtonUp(1))
            //{
            //    if (clickable == RightClickingObject)
            //        RightClickingObject.RightClick();

            //    RightClickingObject = null;
            //}
        }

        private void Select(InputAction.CallbackContext context)
        {
            if (RightClickingObject != null) return;

            //LeftClickingObject = clickable;
        }

        public void ClearHighligh()
        {
            Highlighted = null;
        }

        void ClearClickables()
        {
            Highlighted = null;
            LeftClickingObject = null;
            RightClickingObject = null;
        }

    }

}