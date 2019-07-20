// GENERATED AUTOMATICALLY FROM 'Assets/Scenes/MovementControll.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class MovementControll : IInputActionCollection
{
    private InputActionAsset asset;
    public MovementControll()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MovementControll"",
    ""maps"": [
        {
            ""name"": ""Gamepad"",
            ""id"": ""454c6b5a-197e-486a-9d9f-efa59d8fe8c1"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""id"": ""9c0b2b02-1ffe-48c8-a97d-52df305cc60c"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""03fbc003-c5f9-45fe-bca5-2f33ccb863bf"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b16f19c4-9c70-4307-ac4a-ca3236720316"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1bf74ed6-e13d-4220-bb65-ef2665cd384e"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8e795bff-55eb-4876-b31d-ddf529b826c5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""left"",
                    ""id"": ""30b4f525-1d6f-4380-b7ba-2ef8a712bf28"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""right"",
                    ""id"": ""97bfbe82-5bc4-42bf-82f2-575f89a6c537"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gamepad
        m_Gamepad = asset.GetActionMap("Gamepad");
        m_Gamepad_Movement = m_Gamepad.GetAction("Movement");
    }

    ~MovementControll()
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

    public ReadOnlyArray<InputControlScheme> controlSchemes
    {
        get => asset.controlSchemes;
    }

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

    // Gamepad
    private InputActionMap m_Gamepad;
    private IGamepadActions m_GamepadActionsCallbackInterface;
    private InputAction m_Gamepad_Movement;
    public struct GamepadActions
    {
        private MovementControll m_Wrapper;
        public GamepadActions(MovementControll wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement { get { return m_Wrapper.m_Gamepad_Movement; } }
        public InputActionMap Get() { return m_Wrapper.m_Gamepad; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(GamepadActions set) { return set.Get(); }
        public void SetCallbacks(IGamepadActions instance)
        {
            if (m_Wrapper.m_GamepadActionsCallbackInterface != null)
            {
                Movement.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnMovement;
                Movement.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnMovement;
                Movement.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_GamepadActionsCallbackInterface = instance;
            if (instance != null)
            {
                Movement.started += instance.OnMovement;
                Movement.performed += instance.OnMovement;
                Movement.canceled += instance.OnMovement;
            }
        }
    }
    public GamepadActions @Gamepad
    {
        get
        {
            return new GamepadActions(this);
        }
    }
    public interface IGamepadActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
}
