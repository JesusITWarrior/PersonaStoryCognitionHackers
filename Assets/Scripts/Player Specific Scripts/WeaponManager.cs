using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public void weaponUpdate(WeaponSO weapon, bool isSecond)
    {
        if (transform.childCount == 1)
            Destroy(transform.GetChild(0).gameObject);
        GameObject s = Instantiate(weapon.model, transform);
        if (!isSecond)
        {
            s.transform.localPosition = weapon.position;
            s.transform.localRotation = Quaternion.Euler(weapon.rotation);
        }
        else
        {
            s.transform.localPosition = weapon.position2;
            s.transform.localRotation = Quaternion.Euler(weapon.rotation2);
        }

        if (weapon.scale != Vector3.zero)
            s.transform.localScale = weapon.scale;
    }

    public void weaponSwapO()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void weaponSwapI()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
