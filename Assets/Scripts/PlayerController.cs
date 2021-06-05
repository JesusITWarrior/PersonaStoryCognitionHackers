using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void Look(int faceEnemies)
    {
        switch (faceEnemies)
        {
            case 1: //Leader
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2: //secondary
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0,-90,0);
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
