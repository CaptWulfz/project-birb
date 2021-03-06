//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""3a9888c1-3e14-4d66-a074-f2acb812edad"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""c142cc9d-9fd0-4c54-a306-e5cf4fc89a6d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PlayMusic"",
                    ""type"": ""Button"",
                    ""id"": ""95ad666d-5fae-4261-a6cf-3ac4d4d79d49"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Note1"",
                    ""type"": ""Button"",
                    ""id"": ""bdd7731d-2b81-4ac1-ae5c-4b88bf808f08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Note2"",
                    ""type"": ""Button"",
                    ""id"": ""37d8d3e8-de77-4e9f-93a5-091eb7cb2b25"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FaceUp"",
                    ""type"": ""Button"",
                    ""id"": ""0083aa52-d773-4552-a31a-4febe2faa686"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FaceDown"",
                    ""type"": ""Button"",
                    ""id"": ""641e9aaf-049b-4d59-9cf5-e4f9b61eb330"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FaceLeft"",
                    ""type"": ""Button"",
                    ""id"": ""a5dbe1fa-e08d-4f5f-8f7e-100b67af0544"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FaceRight"",
                    ""type"": ""Button"",
                    ""id"": ""2272b377-773f-4bb0-808f-c31ca2ae746f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3d1b72f0-9b2a-4baf-af3e-21d2f56222e5"",
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
                    ""id"": ""d3e0d268-d780-4dd7-b5ca-8389a40027b9"",
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
                    ""id"": ""4e1d35f9-3535-4fd2-a9b5-fec9e7e83fb2"",
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
                    ""id"": ""c89df633-f2a0-4ac8-a4e7-115c1923c3fb"",
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
                    ""id"": ""7e8ce098-7793-41d7-921d-f26a2951e613"",
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
                    ""id"": ""646a4ab3-0be5-432b-b161-b3485f78c315"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayMusic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b95d6c08-e53a-41ce-ab0a-8ea5ef6026f8"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Note1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5165252-0d95-4848-90a4-41eeca0f90ad"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Note2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7473504-ebc0-4b11-99a3-659cedd773eb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FaceUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2c1650b-8e40-4509-9d40-3a39cfa03446"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FaceDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3593e423-bcb3-460e-aebd-bf5c15b7e3bc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FaceLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ed123ce-1697-4c0f-aead-b11c79574150"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FaceRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Phoenix"",
            ""id"": ""0cc9e5dd-8cff-4d41-a6f5-bd8456e8b925"",
            ""actions"": [
                {
                    ""name"": ""ToggleHold"",
                    ""type"": ""Button"",
                    ""id"": ""49bbec26-f88e-4f4e-b49d-98665d308fa6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""49ad4832-121e-4611-8834-1008c9d53e93"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""22cca46d-86b4-4edd-b758-f51d33a8be43"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72fe70f9-9e31-4fcf-9cc3-9836fa60a671"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_PlayMusic = m_Player.FindAction("PlayMusic", throwIfNotFound: true);
        m_Player_Note1 = m_Player.FindAction("Note1", throwIfNotFound: true);
        m_Player_Note2 = m_Player.FindAction("Note2", throwIfNotFound: true);
        m_Player_FaceUp = m_Player.FindAction("FaceUp", throwIfNotFound: true);
        m_Player_FaceDown = m_Player.FindAction("FaceDown", throwIfNotFound: true);
        m_Player_FaceLeft = m_Player.FindAction("FaceLeft", throwIfNotFound: true);
        m_Player_FaceRight = m_Player.FindAction("FaceRight", throwIfNotFound: true);
        // Phoenix
        m_Phoenix = asset.FindActionMap("Phoenix", throwIfNotFound: true);
        m_Phoenix_ToggleHold = m_Phoenix.FindAction("ToggleHold", throwIfNotFound: true);
        m_Phoenix_Move = m_Phoenix.FindAction("Move", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_PlayMusic;
    private readonly InputAction m_Player_Note1;
    private readonly InputAction m_Player_Note2;
    private readonly InputAction m_Player_FaceUp;
    private readonly InputAction m_Player_FaceDown;
    private readonly InputAction m_Player_FaceLeft;
    private readonly InputAction m_Player_FaceRight;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @PlayMusic => m_Wrapper.m_Player_PlayMusic;
        public InputAction @Note1 => m_Wrapper.m_Player_Note1;
        public InputAction @Note2 => m_Wrapper.m_Player_Note2;
        public InputAction @FaceUp => m_Wrapper.m_Player_FaceUp;
        public InputAction @FaceDown => m_Wrapper.m_Player_FaceDown;
        public InputAction @FaceLeft => m_Wrapper.m_Player_FaceLeft;
        public InputAction @FaceRight => m_Wrapper.m_Player_FaceRight;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @PlayMusic.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayMusic;
                @PlayMusic.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayMusic;
                @PlayMusic.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayMusic;
                @Note1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNote1;
                @Note1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNote1;
                @Note1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNote1;
                @Note2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNote2;
                @Note2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNote2;
                @Note2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNote2;
                @FaceUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFaceUp;
                @FaceUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFaceUp;
                @FaceUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFaceUp;
                @FaceDown.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFaceDown;
                @FaceDown.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFaceDown;
                @FaceDown.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFaceDown;
                @FaceLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFaceLeft;
                @FaceLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFaceLeft;
                @FaceLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFaceLeft;
                @FaceRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFaceRight;
                @FaceRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFaceRight;
                @FaceRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFaceRight;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @PlayMusic.started += instance.OnPlayMusic;
                @PlayMusic.performed += instance.OnPlayMusic;
                @PlayMusic.canceled += instance.OnPlayMusic;
                @Note1.started += instance.OnNote1;
                @Note1.performed += instance.OnNote1;
                @Note1.canceled += instance.OnNote1;
                @Note2.started += instance.OnNote2;
                @Note2.performed += instance.OnNote2;
                @Note2.canceled += instance.OnNote2;
                @FaceUp.started += instance.OnFaceUp;
                @FaceUp.performed += instance.OnFaceUp;
                @FaceUp.canceled += instance.OnFaceUp;
                @FaceDown.started += instance.OnFaceDown;
                @FaceDown.performed += instance.OnFaceDown;
                @FaceDown.canceled += instance.OnFaceDown;
                @FaceLeft.started += instance.OnFaceLeft;
                @FaceLeft.performed += instance.OnFaceLeft;
                @FaceLeft.canceled += instance.OnFaceLeft;
                @FaceRight.started += instance.OnFaceRight;
                @FaceRight.performed += instance.OnFaceRight;
                @FaceRight.canceled += instance.OnFaceRight;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Phoenix
    private readonly InputActionMap m_Phoenix;
    private IPhoenixActions m_PhoenixActionsCallbackInterface;
    private readonly InputAction m_Phoenix_ToggleHold;
    private readonly InputAction m_Phoenix_Move;
    public struct PhoenixActions
    {
        private @Controls m_Wrapper;
        public PhoenixActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleHold => m_Wrapper.m_Phoenix_ToggleHold;
        public InputAction @Move => m_Wrapper.m_Phoenix_Move;
        public InputActionMap Get() { return m_Wrapper.m_Phoenix; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PhoenixActions set) { return set.Get(); }
        public void SetCallbacks(IPhoenixActions instance)
        {
            if (m_Wrapper.m_PhoenixActionsCallbackInterface != null)
            {
                @ToggleHold.started -= m_Wrapper.m_PhoenixActionsCallbackInterface.OnToggleHold;
                @ToggleHold.performed -= m_Wrapper.m_PhoenixActionsCallbackInterface.OnToggleHold;
                @ToggleHold.canceled -= m_Wrapper.m_PhoenixActionsCallbackInterface.OnToggleHold;
                @Move.started -= m_Wrapper.m_PhoenixActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PhoenixActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PhoenixActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_PhoenixActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleHold.started += instance.OnToggleHold;
                @ToggleHold.performed += instance.OnToggleHold;
                @ToggleHold.canceled += instance.OnToggleHold;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public PhoenixActions @Phoenix => new PhoenixActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnPlayMusic(InputAction.CallbackContext context);
        void OnNote1(InputAction.CallbackContext context);
        void OnNote2(InputAction.CallbackContext context);
        void OnFaceUp(InputAction.CallbackContext context);
        void OnFaceDown(InputAction.CallbackContext context);
        void OnFaceLeft(InputAction.CallbackContext context);
        void OnFaceRight(InputAction.CallbackContext context);
    }
    public interface IPhoenixActions
    {
        void OnToggleHold(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
