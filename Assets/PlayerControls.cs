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
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""6155698e-8780-4b41-9e42-991001960ef1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Misc"",
                    ""type"": ""Button"",
                    ""id"": ""dd55d2c0-0817-46d7-b761-2e52dc7c4cf7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""a6660d11-62a0-4a9e-a201-9a545227b3f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""Value"",
                    ""id"": ""bcfadffb-3aea-4839-aedc-4561bdaac762"",
                    ""expectedControlType"": ""Vector2"",
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
                    ""id"": ""4304b7db-1836-4c80-bd4f-ee75abf0ed9d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
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
                    ""id"": ""1d5d8e29-e1d5-4a91-805c-f09916216468"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffa0478b-8500-4571-85ae-b0db6b7cda6a"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
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
                    ""id"": ""1295bc4c-5e9b-40bf-a510-a87db0424918"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae0b9cda-4c82-4856-a619-da77138f422c"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
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
                    ""id"": ""870ca06c-8317-4150-b190-df28fae33dc6"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bce4f075-98ad-41f6-9043-2874a7379846"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
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
                    ""id"": ""e3fe1bde-4647-4c79-af3a-84814ff448d4"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d190abfd-380f-4b31-a6a4-db70f714bca0"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""e4f8b239-ee5d-4e77-9f02-fab27c924fd9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d45ad934-e3d3-47bc-8233-e54e7ab0a94f"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Misc"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f239bd27-04aa-40ab-95a4-069f8c1bafb1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c86472f3-8b37-41a5-b639-20eb0124e8e2"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Movement"",
            ""id"": ""f9f03554-539c-45cf-a2d2-7e000efc76cd"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""825b27a9-a46e-44c9-9398-82d99a867c40"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""52f2da80-0fab-452d-80c3-900dfd398318"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""eafed6af-4583-47c9-af88-6722650693d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Backwards"",
                    ""type"": ""Value"",
                    ""id"": ""438a6732-153f-4754-a105-64652b4e46a5"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""07377057-8441-419a-9002-6e136b4451ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""5b9fcb41-bd51-4985-a375-40e61754d7e4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7370440d-df82-4329-8459-3febc727da0e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4345bcd-3212-47b0-9ada-547fe9d5da74"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19100c34-0278-4184-b968-798e887aacb7"",
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
                    ""id"": ""336e829f-56fe-4ee4-af6e-425885e0524e"",
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
                    ""id"": ""4de0eebc-fdb0-432d-8e18-0c5002183209"",
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
                    ""id"": ""c50546ec-b8ed-4eaa-9f93-acfde538edf2"",
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
                    ""id"": ""9cd5248a-b671-4b7f-803f-f4858037cf0f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Backwards"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08006539-fe80-45db-a684-ac2ba1dbe418"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Backwards"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4a30020-77bb-420c-bc6e-c9d131613f5d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70547a82-6763-497c-ae70-1fa0719df7b7"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08a4a9f5-4774-40b0-ab93-e5a3c72b96ca"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MovementController"",
            ""id"": ""9987b52f-1e8e-4468-a25f-7a9147b28072"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""d75bbcb4-567c-4e0f-b045-212171197829"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1dcf6fd4-28e8-42fb-a54b-6ac2e7e43746"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""85512e9b-236f-416b-acbb-6fd311f3b92a"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8818994a-db54-4a2a-8eef-43f7195607b8"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75762f57-1945-49d3-8a37-a27d5c33625e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1734a0e1-f495-485d-aed2-9ec81ebaa840"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Look"",
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
        m_MenuNavigation_Confirm = m_MenuNavigation.FindAction("Confirm", throwIfNotFound: true);
        m_MenuNavigation_Misc = m_MenuNavigation.FindAction("Misc", throwIfNotFound: true);
        m_MenuNavigation_Click = m_MenuNavigation.FindAction("Click", throwIfNotFound: true);
        m_MenuNavigation_Drag = m_MenuNavigation.FindAction("Drag", throwIfNotFound: true);
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Forward = m_Movement.FindAction("Forward", throwIfNotFound: true);
        m_Movement_Left = m_Movement.FindAction("Left", throwIfNotFound: true);
        m_Movement_Right = m_Movement.FindAction("Right", throwIfNotFound: true);
        m_Movement_Backwards = m_Movement.FindAction("Backwards", throwIfNotFound: true);
        m_Movement_Pause = m_Movement.FindAction("Pause", throwIfNotFound: true);
        m_Movement_Look = m_Movement.FindAction("Look", throwIfNotFound: true);
        // MovementController
        m_MovementController = asset.FindActionMap("MovementController", throwIfNotFound: true);
        m_MovementController_Pause = m_MovementController.FindAction("Pause", throwIfNotFound: true);
        m_MovementController_Move = m_MovementController.FindAction("Move", throwIfNotFound: true);
        m_MovementController_Look = m_MovementController.FindAction("Look", throwIfNotFound: true);
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
    private readonly InputAction m_MenuNavigation_Confirm;
    private readonly InputAction m_MenuNavigation_Misc;
    private readonly InputAction m_MenuNavigation_Click;
    private readonly InputAction m_MenuNavigation_Drag;
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
        public InputAction @Confirm => m_Wrapper.m_MenuNavigation_Confirm;
        public InputAction @Misc => m_Wrapper.m_MenuNavigation_Misc;
        public InputAction @Click => m_Wrapper.m_MenuNavigation_Click;
        public InputAction @Drag => m_Wrapper.m_MenuNavigation_Drag;
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
                @Confirm.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnConfirm;
                @Misc.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnMisc;
                @Misc.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnMisc;
                @Misc.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnMisc;
                @Click.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnClick;
                @Drag.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnDrag;
                @Drag.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnDrag;
                @Drag.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnDrag;
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
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @Misc.started += instance.OnMisc;
                @Misc.performed += instance.OnMisc;
                @Misc.canceled += instance.OnMisc;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
            }
        }
    }
    public MenuNavigationActions @MenuNavigation => new MenuNavigationActions(this);

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Forward;
    private readonly InputAction m_Movement_Left;
    private readonly InputAction m_Movement_Right;
    private readonly InputAction m_Movement_Backwards;
    private readonly InputAction m_Movement_Pause;
    private readonly InputAction m_Movement_Look;
    public struct MovementActions
    {
        private @PlayerControls m_Wrapper;
        public MovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Movement_Forward;
        public InputAction @Left => m_Wrapper.m_Movement_Left;
        public InputAction @Right => m_Wrapper.m_Movement_Right;
        public InputAction @Backwards => m_Wrapper.m_Movement_Backwards;
        public InputAction @Pause => m_Wrapper.m_Movement_Pause;
        public InputAction @Look => m_Wrapper.m_Movement_Look;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnForward;
                @Left.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRight;
                @Backwards.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnBackwards;
                @Backwards.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnBackwards;
                @Backwards.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnBackwards;
                @Pause.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnPause;
                @Look.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Backwards.started += instance.OnBackwards;
                @Backwards.performed += instance.OnBackwards;
                @Backwards.canceled += instance.OnBackwards;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // MovementController
    private readonly InputActionMap m_MovementController;
    private IMovementControllerActions m_MovementControllerActionsCallbackInterface;
    private readonly InputAction m_MovementController_Pause;
    private readonly InputAction m_MovementController_Move;
    private readonly InputAction m_MovementController_Look;
    public struct MovementControllerActions
    {
        private @PlayerControls m_Wrapper;
        public MovementControllerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_MovementController_Pause;
        public InputAction @Move => m_Wrapper.m_MovementController_Move;
        public InputAction @Look => m_Wrapper.m_MovementController_Look;
        public InputActionMap Get() { return m_Wrapper.m_MovementController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementControllerActions set) { return set.Get(); }
        public void SetCallbacks(IMovementControllerActions instance)
        {
            if (m_Wrapper.m_MovementControllerActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnPause;
                @Move.started -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_MovementControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public MovementControllerActions @MovementController => new MovementControllerActions(this);
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
        void OnConfirm(InputAction.CallbackContext context);
        void OnMisc(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
    }
    public interface IMovementActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnBackwards(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
    public interface IMovementControllerActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}
