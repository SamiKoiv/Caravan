// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Core/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace ProjectCaravan.Core.Input
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
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""a7345ef3-6d71-4191-8c0c-db085abdca6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Deselect"",
                    ""type"": ""Button"",
                    ""id"": ""c35a4d51-3360-47cb-9fef-35b0c6387db0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""46e79679-c9d8-4b5c-bf2b-162cda6392da"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""83db93f5-50a2-42f3-ad10-0a1200d367a3"",
                    ""expectedControlType"": ""Vector2"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""c30a698f-7777-4237-9cde-356035275020"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c060698-92f7-4851-9f95-011cee158d9d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deselect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92ce5d59-8c4e-45b3-a74d-3c9cf1eccb80"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9b662ba-c072-42dc-baa9-65de937ffe2d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
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
            m_Gameplay_Select = m_Gameplay.FindAction("Select", throwIfNotFound: true);
            m_Gameplay_Deselect = m_Gameplay.FindAction("Deselect", throwIfNotFound: true);
            m_Gameplay_MousePosition = m_Gameplay.FindAction("MousePosition", throwIfNotFound: true);
            m_Gameplay_MouseDelta = m_Gameplay.FindAction("MouseDelta", throwIfNotFound: true);
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
        private readonly InputAction m_Gameplay_Select;
        private readonly InputAction m_Gameplay_Deselect;
        private readonly InputAction m_Gameplay_MousePosition;
        private readonly InputAction m_Gameplay_MouseDelta;
        public struct GameplayActions
        {
            private @Controls m_Wrapper;
            public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveCamera => m_Wrapper.m_Gameplay_MoveCamera;
            public InputAction @ZoomCamera => m_Wrapper.m_Gameplay_ZoomCamera;
            public InputAction @Select => m_Wrapper.m_Gameplay_Select;
            public InputAction @Deselect => m_Wrapper.m_Gameplay_Deselect;
            public InputAction @MousePosition => m_Wrapper.m_Gameplay_MousePosition;
            public InputAction @MouseDelta => m_Wrapper.m_Gameplay_MouseDelta;
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
                    @Select.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelect;
                    @Select.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelect;
                    @Select.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelect;
                    @Deselect.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDeselect;
                    @Deselect.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDeselect;
                    @Deselect.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDeselect;
                    @MousePosition.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                    @MousePosition.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                    @MousePosition.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                    @MouseDelta.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseDelta;
                    @MouseDelta.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseDelta;
                    @MouseDelta.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseDelta;
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
                    @Select.started += instance.OnSelect;
                    @Select.performed += instance.OnSelect;
                    @Select.canceled += instance.OnSelect;
                    @Deselect.started += instance.OnDeselect;
                    @Deselect.performed += instance.OnDeselect;
                    @Deselect.canceled += instance.OnDeselect;
                    @MousePosition.started += instance.OnMousePosition;
                    @MousePosition.performed += instance.OnMousePosition;
                    @MousePosition.canceled += instance.OnMousePosition;
                    @MouseDelta.started += instance.OnMouseDelta;
                    @MouseDelta.performed += instance.OnMouseDelta;
                    @MouseDelta.canceled += instance.OnMouseDelta;
                }
            }
        }
        public GameplayActions @Gameplay => new GameplayActions(this);
        public interface IGameplayActions
        {
            void OnMoveCamera(InputAction.CallbackContext context);
            void OnZoomCamera(InputAction.CallbackContext context);
            void OnSelect(InputAction.CallbackContext context);
            void OnDeselect(InputAction.CallbackContext context);
            void OnMousePosition(InputAction.CallbackContext context);
            void OnMouseDelta(InputAction.CallbackContext context);
        }
    }
}
