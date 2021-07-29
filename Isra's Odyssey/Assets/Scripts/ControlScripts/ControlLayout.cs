// GENERATED AUTOMATICALLY FROM 'Assets/ControlLayout.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ControlLayout : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlLayout()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlLayout"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""5858bdea-1873-4d50-8d0f-a67e799fed07"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""3debf876-7c5f-40b3-a270-4e1d4621829c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""a8c6badb-d6bd-4eb1-b485-e9f34a4143c2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3c443938-cea1-480d-9be6-d5bebb6d9e14"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""edc71b7c-018b-4a27-b196-5fc6c5e9a26b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0415fc54-4794-4b00-908a-7d6fe513c7e3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1039d86c-5587-45fc-9b5a-a6b3ad305ab6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""PlayerAbilities"",
            ""id"": ""032b689f-042b-4748-9b57-aeaddcdcddda"",
            ""actions"": [
                {
                    ""name"": ""LightBeam"",
                    ""type"": ""Button"",
                    ""id"": ""5ed9a46b-e62b-42ac-b03f-770ee27290e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c09f5c14-48c6-4870-a6a7-23dc8724ee8f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightBeam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Movement = m_PlayerControls.FindAction("Movement", throwIfNotFound: true);
        // PlayerAbilities
        m_PlayerAbilities = asset.FindActionMap("PlayerAbilities", throwIfNotFound: true);
        m_PlayerAbilities_LightBeam = m_PlayerAbilities.FindAction("LightBeam", throwIfNotFound: true);
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

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Movement;
    public struct PlayerControlsActions
    {
        private @ControlLayout m_Wrapper;
        public PlayerControlsActions(@ControlLayout wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerControls_Movement;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);

    // PlayerAbilities
    private readonly InputActionMap m_PlayerAbilities;
    private IPlayerAbilitiesActions m_PlayerAbilitiesActionsCallbackInterface;
    private readonly InputAction m_PlayerAbilities_LightBeam;
    public struct PlayerAbilitiesActions
    {
        private @ControlLayout m_Wrapper;
        public PlayerAbilitiesActions(@ControlLayout wrapper) { m_Wrapper = wrapper; }
        public InputAction @LightBeam => m_Wrapper.m_PlayerAbilities_LightBeam;
        public InputActionMap Get() { return m_Wrapper.m_PlayerAbilities; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerAbilitiesActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerAbilitiesActions instance)
        {
            if (m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface != null)
            {
                @LightBeam.started -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnLightBeam;
                @LightBeam.performed -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnLightBeam;
                @LightBeam.canceled -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnLightBeam;
            }
            m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LightBeam.started += instance.OnLightBeam;
                @LightBeam.performed += instance.OnLightBeam;
                @LightBeam.canceled += instance.OnLightBeam;
            }
        }
    }
    public PlayerAbilitiesActions @PlayerAbilities => new PlayerAbilitiesActions(this);
    public interface IPlayerControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface IPlayerAbilitiesActions
    {
        void OnLightBeam(InputAction.CallbackContext context);
    }
}
