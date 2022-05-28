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
                    ""interactions"": ""Press""
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
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""d245b041-c7aa-4bd6-858d-9b5ba2a2dc78"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Return"",
                    ""type"": ""Button"",
                    ""id"": ""c2b5f044-1305-46ce-99c2-8ae659d6d6a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""59d2d5e1-5e78-48ff-9078-caf408417ffb"",
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
                    ""interactions"": ""Press"",
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
                    ""id"": ""f70b44d9-df20-40b7-b48a-60bddaff5444"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00910e07-827d-4cc1-b864-354687030918"",
                    ""path"": ""<Keyboard>/numpadEnter"",
                    ""interactions"": ""Tap"",
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
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""3f551b28-d638-4928-9642-736adddb11c0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1a3a1948-9960-4876-a29a-54156f02f997"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""96482030-666b-4e3a-9288-2b2f9f1c8837"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4794e1b2-b1cf-4e97-b5e5-a73bd3dc05c5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7b24ed1b-a634-4d17-b4c3-b7011d8feadf"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""e056d36d-23bc-469c-ad65-dc6a4d05dc15"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""80ebd069-d453-485b-86c4-c38a45ff924f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ead70e6c-6b99-435e-b067-24b6275520fd"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""95f5a640-c8fb-4f86-8a6e-d795467fa2ef"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""59707294-3b6a-4e62-bb22-82e834d8e0d5"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""4c56a99f-1db0-4473-8e45-2843873e5c7a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2e5f7a2d-c3c1-4157-83ed-c99b696caa7f"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""19cf48b1-c3aa-4787-ba84-ff27ca28e9c8"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a131d53a-4ffd-447d-b6e7-9ffa18eb67c1"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ce403f1c-dc06-484f-9fef-378a05a76c93"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""D-Pad"",
                    ""id"": ""ef5e965a-f5c6-4c4c-b229-70b2d7ce36b3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e4166fe4-d27d-48c5-ab26-0aafcf18fa45"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b86b7e7f-6d6e-41e6-8a88-358ae0c84d92"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8cc7ad68-7196-4462-ac7a-afb5bd0acdd2"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bbe9d533-8c41-4514-8791-42203a9d7eb9"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d8b0c005-6054-43b4-8391-431b1f84d9c9"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf8fe0e7-ddb8-4ce6-93d9-5caa4e01ac64"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd839679-7d95-4429-90d1-4bf37c1102a1"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Start"",
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
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""f89e42f9-09f0-4d26-8b95-3756297a7dc9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""27f55c29-1339-41ad-99e3-ab8fed164b7d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""84da584f-e6e0-47cb-b9e9-453c1bc9ce0a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Commands"",
                    ""type"": ""Button"",
                    ""id"": ""582d9aa4-1298-4ec7-9ddc-208fe7e43acd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""75011c3e-8176-488b-99e6-6986bfd99eb0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""c9b4c685-3cc3-4d0b-96ca-2290b3843be7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
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
                    ""id"": ""5c776f61-0f9c-40ce-b08f-3e0c426945bf"",
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
                    ""id"": ""08a4a9f5-4774-40b0-ab93-e5a3c72b96ca"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81fb73d3-937f-42ea-aec2-22d16dbd52fc"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=20,y=10)"",
                    ""groups"": ""Controller"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""8f25979e-824f-47a9-b713-d14f580f40dc"",
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
                    ""id"": ""3655b0ce-2e4a-4f4a-8e65-06b5a0da1f73"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a8ddd250-d72a-4d73-aed5-14776ad7f576"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a3e481e6-55c1-4ac0-82e1-1e42f74c2c1e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0450b6c0-be3e-4062-8c72-3b8927f1c613"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""ea03b240-d47a-4978-9628-1ab723f411d5"",
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
                    ""id"": ""65001f80-4fe5-4000-9ce9-a6980abd08af"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""13103f71-d850-4ba5-bf65-3386ce7eb81a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a938c923-57f3-4922-ae65-e703cd1b2501"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2ba7d2a8-7a76-4d34-af82-6b471003d02a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""113e46d3-78d7-4165-a91e-b566e646775e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""194a61b2-0c9f-48bd-9a3c-a4d0b51ef751"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fa2e4dd-d470-4c84-956b-ec36aeb3986a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3913d3a1-568f-4824-9040-1824e57e4f30"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3858869b-ea4c-4bd9-9406-4f6a4d72f51b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d345690c-a25e-43a9-9675-514ec07ead26"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Commands"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1cd2da2-898f-4792-8a9d-acfc5b5adad8"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Commands"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ea6cb05-001f-45e4-b2d1-590feecde21f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f47f688-2f82-430a-a877-8b2ea79c9471"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89f19255-c366-4df1-99a5-56cf4fe9165f"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""179698d5-3829-4589-9a68-03520a2d1034"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Sprint"",
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
        m_MenuNavigation_Submit = m_MenuNavigation.FindAction("Submit", throwIfNotFound: true);
        m_MenuNavigation_Confirm = m_MenuNavigation.FindAction("Confirm", throwIfNotFound: true);
        m_MenuNavigation_Misc = m_MenuNavigation.FindAction("Misc", throwIfNotFound: true);
        m_MenuNavigation_Click = m_MenuNavigation.FindAction("Click", throwIfNotFound: true);
        m_MenuNavigation_Drag = m_MenuNavigation.FindAction("Drag", throwIfNotFound: true);
        m_MenuNavigation_Navigate = m_MenuNavigation.FindAction("Navigate", throwIfNotFound: true);
        m_MenuNavigation_Return = m_MenuNavigation.FindAction("Return", throwIfNotFound: true);
        m_MenuNavigation_Start = m_MenuNavigation.FindAction("Start", throwIfNotFound: true);
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Pause = m_Movement.FindAction("Pause", throwIfNotFound: true);
        m_Movement_Look = m_Movement.FindAction("Look", throwIfNotFound: true);
        m_Movement_Movement = m_Movement.FindAction("Movement", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        m_Movement_Attack = m_Movement.FindAction("Attack", throwIfNotFound: true);
        m_Movement_Commands = m_Movement.FindAction("Commands", throwIfNotFound: true);
        m_Movement_Interact = m_Movement.FindAction("Interact", throwIfNotFound: true);
        m_Movement_Sprint = m_Movement.FindAction("Sprint", throwIfNotFound: true);
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
    private readonly InputAction m_MenuNavigation_Submit;
    private readonly InputAction m_MenuNavigation_Confirm;
    private readonly InputAction m_MenuNavigation_Misc;
    private readonly InputAction m_MenuNavigation_Click;
    private readonly InputAction m_MenuNavigation_Drag;
    private readonly InputAction m_MenuNavigation_Navigate;
    private readonly InputAction m_MenuNavigation_Return;
    private readonly InputAction m_MenuNavigation_Start;
    public struct MenuNavigationActions
    {
        private @PlayerControls m_Wrapper;
        public MenuNavigationActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_MenuNavigation_Back;
        public InputAction @Submit => m_Wrapper.m_MenuNavigation_Submit;
        public InputAction @Confirm => m_Wrapper.m_MenuNavigation_Confirm;
        public InputAction @Misc => m_Wrapper.m_MenuNavigation_Misc;
        public InputAction @Click => m_Wrapper.m_MenuNavigation_Click;
        public InputAction @Drag => m_Wrapper.m_MenuNavigation_Drag;
        public InputAction @Navigate => m_Wrapper.m_MenuNavigation_Navigate;
        public InputAction @Return => m_Wrapper.m_MenuNavigation_Return;
        public InputAction @Start => m_Wrapper.m_MenuNavigation_Start;
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
                @Navigate.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnNavigate;
                @Return.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnReturn;
                @Return.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnReturn;
                @Return.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnReturn;
                @Start.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnStart;
            }
            m_Wrapper.m_MenuNavigationActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
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
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Return.started += instance.OnReturn;
                @Return.performed += instance.OnReturn;
                @Return.canceled += instance.OnReturn;
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
            }
        }
    }
    public MenuNavigationActions @MenuNavigation => new MenuNavigationActions(this);

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Pause;
    private readonly InputAction m_Movement_Look;
    private readonly InputAction m_Movement_Movement;
    private readonly InputAction m_Movement_Jump;
    private readonly InputAction m_Movement_Attack;
    private readonly InputAction m_Movement_Commands;
    private readonly InputAction m_Movement_Interact;
    private readonly InputAction m_Movement_Sprint;
    public struct MovementActions
    {
        private @PlayerControls m_Wrapper;
        public MovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Movement_Pause;
        public InputAction @Look => m_Wrapper.m_Movement_Look;
        public InputAction @Movement => m_Wrapper.m_Movement_Movement;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputAction @Attack => m_Wrapper.m_Movement_Attack;
        public InputAction @Commands => m_Wrapper.m_Movement_Commands;
        public InputAction @Interact => m_Wrapper.m_Movement_Interact;
        public InputAction @Sprint => m_Wrapper.m_Movement_Sprint;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnPause;
                @Look.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnLook;
                @Movement.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAttack;
                @Commands.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnCommands;
                @Commands.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnCommands;
                @Commands.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnCommands;
                @Interact.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnInteract;
                @Sprint.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnSprint;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Commands.started += instance.OnCommands;
                @Commands.performed += instance.OnCommands;
                @Commands.canceled += instance.OnCommands;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
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
        void OnSubmit(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnMisc(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
        void OnNavigate(InputAction.CallbackContext context);
        void OnReturn(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
    }
    public interface IMovementActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnCommands(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
    public interface IMovementControllerActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}
