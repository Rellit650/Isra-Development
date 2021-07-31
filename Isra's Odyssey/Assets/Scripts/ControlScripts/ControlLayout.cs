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
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""16e4eefe-b7ac-4343-a4c3-5c6cccfb073e"",
                    ""expectedControlType"": ""Button"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""2a484e46-3720-46de-8b35-158dadb80a02"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerAbilities"",
            ""id"": ""032b689f-042b-4748-9b57-aeaddcdcddda"",
            ""actions"": [
                {
                    ""name"": ""CastLightBeam"",
                    ""type"": ""Button"",
                    ""id"": ""5ed9a46b-e62b-42ac-b03f-770ee27290e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Teleport"",
                    ""type"": ""Button"",
                    ""id"": ""a507b76d-b970-4b70-84f0-873c99b7d76a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CancelTeleport"",
                    ""type"": ""Button"",
                    ""id"": ""e505b8c7-9d61-47d0-acf7-2c0f84bcc20f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LightMode"",
                    ""type"": ""Button"",
                    ""id"": ""e4aae941-197a-49b3-84c5-460faf0b5c34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c09f5c14-48c6-4870-a6a7-23dc8724ee8f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastLightBeam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d1ed4c4-2ff6-453b-99b5-353b60cc1a21"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Teleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65ab73b3-8adb-4a56-b047-a5010434c0c1"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelTeleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24b284d0-b3ca-4969-9288-c1612b7fd0dc"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightMode"",
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
        m_PlayerControls_Jump = m_PlayerControls.FindAction("Jump", throwIfNotFound: true);
        // PlayerAbilities
        m_PlayerAbilities = asset.FindActionMap("PlayerAbilities", throwIfNotFound: true);
        m_PlayerAbilities_CastLightBeam = m_PlayerAbilities.FindAction("CastLightBeam", throwIfNotFound: true);
        m_PlayerAbilities_Teleport = m_PlayerAbilities.FindAction("Teleport", throwIfNotFound: true);
        m_PlayerAbilities_CancelTeleport = m_PlayerAbilities.FindAction("CancelTeleport", throwIfNotFound: true);
        m_PlayerAbilities_LightMode = m_PlayerAbilities.FindAction("LightMode", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerControls_Jump;
    public struct PlayerControlsActions
    {
        private @ControlLayout m_Wrapper;
        public PlayerControlsActions(@ControlLayout wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerControls_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerControls_Jump;
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
                @Jump.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);

    // PlayerAbilities
    private readonly InputActionMap m_PlayerAbilities;
    private IPlayerAbilitiesActions m_PlayerAbilitiesActionsCallbackInterface;
    private readonly InputAction m_PlayerAbilities_CastLightBeam;
    private readonly InputAction m_PlayerAbilities_Teleport;
    private readonly InputAction m_PlayerAbilities_CancelTeleport;
    private readonly InputAction m_PlayerAbilities_LightMode;
    public struct PlayerAbilitiesActions
    {
        private @ControlLayout m_Wrapper;
        public PlayerAbilitiesActions(@ControlLayout wrapper) { m_Wrapper = wrapper; }
        public InputAction @CastLightBeam => m_Wrapper.m_PlayerAbilities_CastLightBeam;
        public InputAction @Teleport => m_Wrapper.m_PlayerAbilities_Teleport;
        public InputAction @CancelTeleport => m_Wrapper.m_PlayerAbilities_CancelTeleport;
        public InputAction @LightMode => m_Wrapper.m_PlayerAbilities_LightMode;
        public InputActionMap Get() { return m_Wrapper.m_PlayerAbilities; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerAbilitiesActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerAbilitiesActions instance)
        {
            if (m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface != null)
            {
                @CastLightBeam.started -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnCastLightBeam;
                @CastLightBeam.performed -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnCastLightBeam;
                @CastLightBeam.canceled -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnCastLightBeam;
                @Teleport.started -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnTeleport;
                @Teleport.performed -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnTeleport;
                @Teleport.canceled -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnTeleport;
                @CancelTeleport.started -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnCancelTeleport;
                @CancelTeleport.performed -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnCancelTeleport;
                @CancelTeleport.canceled -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnCancelTeleport;
                @LightMode.started -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnLightMode;
                @LightMode.performed -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnLightMode;
                @LightMode.canceled -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnLightMode;
            }
            m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CastLightBeam.started += instance.OnCastLightBeam;
                @CastLightBeam.performed += instance.OnCastLightBeam;
                @CastLightBeam.canceled += instance.OnCastLightBeam;
                @Teleport.started += instance.OnTeleport;
                @Teleport.performed += instance.OnTeleport;
                @Teleport.canceled += instance.OnTeleport;
                @CancelTeleport.started += instance.OnCancelTeleport;
                @CancelTeleport.performed += instance.OnCancelTeleport;
                @CancelTeleport.canceled += instance.OnCancelTeleport;
                @LightMode.started += instance.OnLightMode;
                @LightMode.performed += instance.OnLightMode;
                @LightMode.canceled += instance.OnLightMode;
            }
        }
    }
    public PlayerAbilitiesActions @PlayerAbilities => new PlayerAbilitiesActions(this);
    public interface IPlayerControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IPlayerAbilitiesActions
    {
        void OnCastLightBeam(InputAction.CallbackContext context);
        void OnTeleport(InputAction.CallbackContext context);
        void OnCancelTeleport(InputAction.CallbackContext context);
        void OnLightMode(InputAction.CallbackContext context);
    }
}
