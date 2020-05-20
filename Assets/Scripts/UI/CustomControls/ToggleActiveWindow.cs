using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectCaravan.UI.CustomControls
{
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

        [SerializeField] private GameObject Target = default;
        [SerializeField] private KeyCode Key = default;
        [SerializeField] private bool ShowByDefault = default;
        [SerializeField] private bool CloseOthers = default;

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
}

