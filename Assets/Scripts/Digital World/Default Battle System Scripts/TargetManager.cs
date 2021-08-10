using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public void targetShow(GameObject old, GameObject target)
    {
        if(old != null)
            old.transform.Find("Target Icon").gameObject.SetActive(false);
        target.transform.Find("Target Icon").gameObject.SetActive(true);
    }

    public void targetShow()
    {

    }
}
