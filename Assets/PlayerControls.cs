// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Menu Navigation"",
            ""id"": ""f5f5a86d-6eb5-40b4-a94c-042fb772a196"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""267e43b1-912a-4b9c-b8d0-9c4b8a1586b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""2ada4aed-a439-46f2-aaae-2ad12ee102cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""f1c3780a-4eae-4713-b07f-cf659dcb5556"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""fe86bb44-7c85-4c37-bdd2-571601d1fd2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""cd2a9f48-83d8-4271-819c-0c06e24dd00c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""117a676e-6b1a-4085-b24a-b0d37493634f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""efb7af3c-1eca-406f-82fa-4cb46c5240bd"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2279a614-75f3-4a00-af97-d01bce1ef809"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7290e9f-91ec-438b-b7b6-deac40605d62"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f907cbe0-3939-4784-a341-3f85897899ce"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05d97a97-ac69-4da9-b842-3fac1c904d6e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41417248-1d7f-4c70-9526-be6040c17dbf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16141315-65d8-4acb-a7ef-3511b1c26599"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f28d90d5-90d3-43ec-9fc5-cf01bf4b0591"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07a25ed7-a2d8-421e-8e01-9a1096f2dbe5"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f70b44d9-df20-40b7-b48a-60bddaff5444"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": []
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": []
        }
    ]
}");
        // Menu Navigation
        m_MenuNavigation = asset.FindActionMap("Menu Navigation", throwIfNotFound: true);
        m_MenuNavigation_Back = m_MenuNavigation.FindAction("Back", throwIfNotFound: true);
        m_MenuNavigation_Up = m_MenuNavigation.FindAction("Up", throwIfNotFound: true);
        m_MenuNavigation_Down = m_MenuNavigation.FindAction("Down", throwIfNotFound: true);
        m_MenuNavigation_Left = m_MenuNavigation.FindAction("Left", throwIfNotFound: true);
        m_MenuNavigation_Right = m_MenuNavigation.FindAction("Right", throwIfNotFound: true);
        m_MenuNavigation_Submit = m_MenuNavigation.FindAction("Submit", throwIfNotFound: true);
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

    // Menu Navigation
    private readonly InputActionMap m_MenuNavigation;
    private IMenuNavigationActions m_MenuNavigationActionsCallbackInterface;
    private readonly InputAction m_MenuNavigation_Back;
    private readonly InputAction m_MenuNavigation_Up;
    private readonly InputAction m_MenuNavigation_Down;
    private readonly InputAction m_MenuNavigation_Left;
    private readonly InputAction m_MenuNavigation_Right;
    private readonly InputAction m_MenuNavigation_Submit;
    public struct MenuNavigationActions
    {
        private @PlayerControls m_Wrapper;
        public MenuNavigationActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_MenuNavigation_Back;
        public InputAction @Up => m_Wrapper.m_MenuNavigation_Up;
        public InputAction @Down => m_Wrapper.m_MenuNavigation_Down;
        public InputAction @Left => m_Wrapper.m_MenuNavigation_Left;
        public InputAction @Right => m_Wrapper.m_MenuNavigation_Right;
        public InputAction @Submit => m_Wrapper.m_MenuNavigation_Submit;
        public InputActionMap Get() { return m_Wrapper.m_MenuNavigation; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuNavigationActions set) { return set.Get(); }
        public void SetCallbacks(IMenuNavigationActions instance)
        {
            if (m_Wrapper.m_MenuNavigationActionsCallbackInterface != null)
            {
                @Back.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnBack;
                @Up.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnRight;
                @Submit.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnSubmit;
            }
            m_Wrapper.m_MenuNavigationActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
            }
        }
    }
    public MenuNavigationActions @MenuNavigation => new MenuNavigationActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IMenuNavigationActions
    {
        void OnBack(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
    }
}
