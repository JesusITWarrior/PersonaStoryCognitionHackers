using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public void Look(int getTurn)
    {
        switch (getTurn) {
            case 0: //Battle Start
            case 1: //Leader
                this.transform.rotation = Quaternion.identity;
                this.transform.Rotate(0, 180, 0);
                break;
            case 2: //secondary
                this.transform.rotation = Quaternion.identity;
                this.transform.Rotate(0,90,0);
                break;
            case 3: //tertiary
                this.transform.rotation = Quaternion.identity;
                break;
            case 4: //fourth player
                this.transform.rotation = Quaternion.identity;
                this.transform.Rotate(0,-90,0);
                break;
        }
    }


}
