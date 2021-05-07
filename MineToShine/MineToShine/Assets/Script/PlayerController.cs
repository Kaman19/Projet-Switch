// GENERATED AUTOMATICALLY FROM 'Assets/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""b559cd3f-5b09-42e8-80d0-ba67facb9e35"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""9b7d9bba-bc19-4ee5-9780-0d0346464b4d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""d232f42c-a9a3-423c-9556-ca469ba6b9d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Light"",
                    ""type"": ""Value"",
                    ""id"": ""63d522d5-39cd-448b-acc8-398641d126e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeDroit"",
                    ""type"": ""Value"",
                    ""id"": ""029451f2-8c9b-49df-8dc1-a86707de1cde"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeGauche"",
                    ""type"": ""Value"",
                    ""id"": ""1e7fb4ed-93b1-4d49-a591-a93722920a27"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PoseLum"",
                    ""type"": ""Value"",
                    ""id"": ""aafaa8fc-5647-469c-993d-f9dfaeacd7a3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""RetireLum"",
                    ""type"": ""Value"",
                    ""id"": ""5f71e496-49ef-45ff-89e3-08cd0fba87b8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DirectionLum"",
                    ""type"": ""Value"",
                    ""id"": ""b36aa476-df8b-4443-b348-4d601eb62a80"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ecd6d9f7-8486-4294-b5b7-26fc42f983f7"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dde04550-c41f-419b-9aec-251688167ef6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1836ad8e-bc1a-4c7c-b725-7a760091dbe6"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Light"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77091945-c59a-4821-b971-0557b07336e2"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeDroit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""877d3d6b-c861-4278-8cd8-d043da0ff817"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeGauche"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45ea6515-428e-48f3-a992-ca8b66ea52cc"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PoseLum"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0fd24065-3ef9-4227-af23-9342e8a2bdc7"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RetireLum"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b510f717-c9df-4ffe-86ff-e1cb18c50898"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DirectionLum"",
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
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Light = m_Gameplay.FindAction("Light", throwIfNotFound: true);
        m_Gameplay_ChangeDroit = m_Gameplay.FindAction("ChangeDroit", throwIfNotFound: true);
        m_Gameplay_ChangeGauche = m_Gameplay.FindAction("ChangeGauche", throwIfNotFound: true);
        m_Gameplay_PoseLum = m_Gameplay.FindAction("PoseLum", throwIfNotFound: true);
        m_Gameplay_RetireLum = m_Gameplay.FindAction("RetireLum", throwIfNotFound: true);
        m_Gameplay_DirectionLum = m_Gameplay.FindAction("DirectionLum", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Light;
    private readonly InputAction m_Gameplay_ChangeDroit;
    private readonly InputAction m_Gameplay_ChangeGauche;
    private readonly InputAction m_Gameplay_PoseLum;
    private readonly InputAction m_Gameplay_RetireLum;
    private readonly InputAction m_Gameplay_DirectionLum;
    public struct GameplayActions
    {
        private @PlayerController m_Wrapper;
        public GameplayActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Light => m_Wrapper.m_Gameplay_Light;
        public InputAction @ChangeDroit => m_Wrapper.m_Gameplay_ChangeDroit;
        public InputAction @ChangeGauche => m_Wrapper.m_Gameplay_ChangeGauche;
        public InputAction @PoseLum => m_Wrapper.m_Gameplay_PoseLum;
        public InputAction @RetireLum => m_Wrapper.m_Gameplay_RetireLum;
        public InputAction @DirectionLum => m_Wrapper.m_Gameplay_DirectionLum;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Light.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLight;
                @Light.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLight;
                @Light.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLight;
                @ChangeDroit.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeDroit;
                @ChangeDroit.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeDroit;
                @ChangeDroit.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeDroit;
                @ChangeGauche.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeGauche;
                @ChangeGauche.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeGauche;
                @ChangeGauche.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeGauche;
                @PoseLum.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPoseLum;
                @PoseLum.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPoseLum;
                @PoseLum.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPoseLum;
                @RetireLum.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRetireLum;
                @RetireLum.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRetireLum;
                @RetireLum.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRetireLum;
                @DirectionLum.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDirectionLum;
                @DirectionLum.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDirectionLum;
                @DirectionLum.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDirectionLum;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Light.started += instance.OnLight;
                @Light.performed += instance.OnLight;
                @Light.canceled += instance.OnLight;
                @ChangeDroit.started += instance.OnChangeDroit;
                @ChangeDroit.performed += instance.OnChangeDroit;
                @ChangeDroit.canceled += instance.OnChangeDroit;
                @ChangeGauche.started += instance.OnChangeGauche;
                @ChangeGauche.performed += instance.OnChangeGauche;
                @ChangeGauche.canceled += instance.OnChangeGauche;
                @PoseLum.started += instance.OnPoseLum;
                @PoseLum.performed += instance.OnPoseLum;
                @PoseLum.canceled += instance.OnPoseLum;
                @RetireLum.started += instance.OnRetireLum;
                @RetireLum.performed += instance.OnRetireLum;
                @RetireLum.canceled += instance.OnRetireLum;
                @DirectionLum.started += instance.OnDirectionLum;
                @DirectionLum.performed += instance.OnDirectionLum;
                @DirectionLum.canceled += instance.OnDirectionLum;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLight(InputAction.CallbackContext context);
        void OnChangeDroit(InputAction.CallbackContext context);
        void OnChangeGauche(InputAction.CallbackContext context);
        void OnPoseLum(InputAction.CallbackContext context);
        void OnRetireLum(InputAction.CallbackContext context);
        void OnDirectionLum(InputAction.CallbackContext context);
    }
}
