using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public Camera cam;

    public void targetShow(GameObject old, GameObject target)       //Used for toggling targets between individual game objects. Will make sure the new target 
    {

        if (old != null)
        {
            float temp = old.transform.Find("Target Icon").localPosition.y;
            old.transform.Find("Target Icon").gameObject.SetActive(false);
            old.transform.Find("Target Icon").localPosition = new Vector3(0,temp,0);
        }
        Transform pos = target.transform.Find("Target Icon");
        pos.LookAt(cam.transform);
        pos.gameObject.SetActive(true);
        float distance = Mathf.Sqrt((Mathf.Pow(cam.transform.position.x - pos.position.x,2))+(Mathf.Pow(cam.transform.position.y - pos.position.y,2))+(Mathf.Pow(cam.transform.position.z - pos.position.z,2)));        //Uses distance formula of 2 3D points, in this case, the camera and current targetPos

        Debug.Log(distance);
        pos.Translate(new Vector3(0,0,distance*0.1f));       //Pulls the target icon out in front of the designated target enough to potentially makes sure it doesn't clip through parent object.
                                                             //NOTE: The number may need to be altered a little bit for boss fights assuming the animations end up clipping through the object
    }

    public void targetClear(GameObject old)             //For clearing target data upon mouse leaving
    {
        float temp = old.transform.Find("Target Icon").localPosition.y;
        old.transform.Find("Target Icon").gameObject.SetActive(false);
        old.transform.Find("Target Icon").localPosition = new Vector3(0, temp, 0);
    }

    public void targetShow()                //Used for toggling targets for multiple game objects
    {
        
    }
}

