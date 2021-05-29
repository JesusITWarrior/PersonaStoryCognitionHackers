using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarInitializer : MonoBehaviour
{
    public Slider HP, SP;
    public Slider health, spirit;
    public Canvas UI;

    public void BarCreate(int maxHP, int maxSP)
    {
        //_UI = Instantiate(UI);
        health = Instantiate(HP);

        health.maxValue = maxHP;
        /*health.transform.parent = UI.transform;
        health.transform.localPosition = new Vector2(266.6f, 168.7f);
        health.transform.localScale = new Vector3(1f, 1f, 1f);*/
        
        spirit = Instantiate(SP);
        spirit.maxValue = maxSP;
        /*spirit.transform.parent = UI.transform;
        spirit.transform.localPosition = new Vector2(266.6f, 159.4f);
        spirit.transform.localScale = new Vector3(1,1,1);*/
    }

    public void DamageUpdate(int life)
    {
        health.value = life;
    }
}
