// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Core/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace ProjectCaravan.Core
{
    public class @Controls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""b0180ad1-3f8e-48d9-bbe4-4777a633c2cb"",
            ""actions"": [
                {
                    ""name"": ""MoveCamera"",
                    ""type"": ""Value"",
                    ""id"": ""a24b1551-a3b7-45dd-a117-f6b40b764ab0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ZoomCamera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""45db2a28-4801-45aa-bdf4-632651aabc98"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD Movement"",
                    ""id"": ""4ace1f6b-adf1-4d6c-a25d-dc08333ceb4d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""524d705e-d581-44f4-9b60-9d95f4c62ca8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a8851cb4-ef9a-4a2a-9615-d057f4cb8b8b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a0a94ddd-5320-491b-a926-98f376c1d915"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cf20d174-7b66-44e5-98f2-26f53b67032e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a575b9cd-45ff-403d-aace-3640e8a16ef7"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Gameplay
            m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
            m_Gameplay_MoveCamera = m_Gameplay.FindAction("MoveCamera", throwIfNotFound: true);
            m_Gameplay_ZoomCamera = m_Gameplay.FindAction("ZoomCamera", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Gameplay
        private readonly InputActionMap m_Gameplay;
        private IGameplayActions m_GameplayActionsCallbackInterface;
        private readonly InputAction m_Gameplay_MoveCamera;
        private readonly InputAction m_Gameplay_ZoomCamera;
        public struct GameplayActions
        {
            private @Controls m_Wrapper;
            public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveCamera => m_Wrapper.m_Gameplay_MoveCamera;
            public InputAction @ZoomCamera => m_Wrapper.m_Gameplay_ZoomCamera;
            public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
            public void SetCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
                {
                    @MoveCamera.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveCamera;
                    @MoveCamera.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveCamera;
                    @MoveCamera.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveCamera;
                    @ZoomCamera.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoomCamera;
                    @ZoomCamera.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoomCamera;
                    @ZoomCamera.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoomCamera;
                }
                m_Wrapper.m_GameplayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MoveCamera.started += instance.OnMoveCamera;
                    @MoveCamera.performed += instance.OnMoveCamera;
                    @MoveCamera.canceled += instance.OnMoveCamera;
                    @ZoomCamera.started += instance.OnZoomCamera;
                    @ZoomCamera.performed += instance.OnZoomCamera;
                    @ZoomCamera.canceled += instance.OnZoomCamera;
                }
            }
        }
        public GameplayActions @Gameplay => new GameplayActions(this);
        public interface IGameplayActions
        {
            void OnMoveCamera(InputAction.CallbackContext context);
            void OnZoomCamera(InputAction.CallbackContext context);
        }
    }
}
