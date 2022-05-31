using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public void gunUpdate(GunSO gun, bool isSecond)
    {
        if(transform.childCount == 1)
            Destroy(transform.GetChild(0).gameObject);
        GameObject s = Instantiate(gun.model, transform);
        if (!isSecond)
        {
            s.transform.localPosition = gun.position;
            s.transform.localRotation = Quaternion.Euler(gun.rotation);
        }
        else
        {
            s.transform.localPosition = gun.position2;
            s.transform.localRotation = Quaternion.Euler(gun.rotation2);
        }
        if (gun.scale != Vector3.zero)
            s.transform.localScale = gun.scale;
        s.SetActive(false);
    }

    public void gunSwapO()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void gunSwapI()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
