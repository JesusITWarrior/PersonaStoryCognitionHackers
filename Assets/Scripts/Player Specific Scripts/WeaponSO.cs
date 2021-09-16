using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Melee", menuName = "Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header("Basic stats")]
    public new string name;
    public string description;
    
    public GameObject model;

    public int attack, hit;
    public int buyPrice;

    public string effectDesc;

    [Header("Effect variables")]
    [SerializeField]
    private bool ailEffect, randomAilEffect, statBoost, critBoost, typeBoost, HPBoost, SPBoost, passiveSkill, reduceDamage;

    [Header("ailEffect or randomAilEffect = true")]
    public short ailment;
    public float chance;             //Used for both ailment AND critboost

    [Header("statBoost = true")]
    public int whichStat, statBoostAmount;

    [Header("typeBoost = true or reduceDamage = true")]    
    public short type;
    public int typeBoostAmount;

    [Header("Health or SPBoost variables = true")]
    public int healthBoost, spiritBoost;

    [Header("Passive Skill")]
    public byte whichSkillBoost;

    

    public byte checkBoost()
    {
        if (ailEffect && randomAilEffect)
        {
            return 2;
        }else if (ailEffect)
        {
            return 1;
        }else if (statBoost)
        {
            return 3;
        }else if (critBoost)
        {
            return 4;
        }else if (typeBoost)
        {
            return 5;
        }else if (HPBoost)
        {
            return 6;
        }else if (SPBoost)
        {
            return 7;
        }else if (passiveSkill)
        {
            return 8;
        }else if (reduceDamage)
        {
            return 9;
        }else
        {
            return 0;
        }
    }
    
}
