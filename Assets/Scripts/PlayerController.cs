using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerControls controls;
    /*public CharacterController controller;
    float playerSpeed = 2;
    float gravityValue = -9.81f;*/

    private void OnEnable()
    {
        controls = new PlayerControls();
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }



    public void LookBattleTurn(int faceEnemies)
    {
        switch (faceEnemies)
        {
            case 1: //Leader
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2: //secondary
                this.transform.rotation = Quaternion.identity;
                this.transform.Rotate(0, -90, 0);// = Quaternion.Euler(0,-90,0);
                break;
            case 3: //tertiary
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case 4: //fourth player
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
        }
    }
}
