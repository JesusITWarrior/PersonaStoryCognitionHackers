using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Unit : MonoBehaviour {
    [SerializeField]
    private GameObject healthBarObject;
    private Image healthBar;
    public GameObject enemyDamagePop, enemyHealPop;
    public int currentHP, currentSP;
    public ShadowBase shadow;
    public EnemyController EC;
    public bool isDown = false;
    //public GameObject model;

    public int ailment = 0; //None=0, Burn=1, Freeze=2, Shock=3, Dizzy=4, Forget(Memory Error)=5, SleepMode=6, Bugged(Confuse)=7, Fear=8, Despair=9, Rage=10, Brainwash(Hacked)=11, Unoptimized(Hunger)=12
    void Start () {
        currentHP = shadow.maxHP;
        currentSP = shadow.maxSP;
        healthBar = healthBarObject.GetComponent<Image>();
        healthBar.fillAmount = 1;   //Sets max slider value to HP, don't remove.
    }

    //private void Update()
    //{
    //    healthBarSlider.value = currentHP;
    //}

    public short resistanceCheck(short type)
    {
        if (shadow.weak.Length != 0)
        {
            for (int i = 0; i < shadow.weak.Length; i++)
            {
                if (type == shadow.weak[i])
                    return -1;
            }
        }
        if (shadow.resist.Length != 0)
        {
            for (int i = 0; i < shadow.resist.Length; i++)
            {
                if (type == shadow.resist[i])
                    return 1;
            }
        }
        if (shadow.reflect.Length != 0)
        {
            for (int i = 0; i < shadow.reflect.Length; i++)
            {
                if (type == shadow.reflect[i])
                    return 2;
            }
        }
        if (shadow.absorb.Length != 0)
        {
            for (int i = 0; i < shadow.absorb.Length; i++)
            {
                if (type == shadow.absorb[i])
                    return 3;
            }
        }
           return 0;
    }
    public int TakeDamage(float dmg, short type, bool crit)
    {
        int d = 0, h = 0, t = 0;
        short check = resistanceCheck(type);
        if (!crit) {
            switch (check)
            {
                case -1:
                    d = (int)(2 * dmg);   //Weak
                    currentHP -= d;
                    break;
                case 1:
                    d = (int)(dmg / 2);       //Strong
                    currentHP -= d;
                    break;
                case 2:
                    break; //Reflect
                case 3:
                    h = (int)(dmg);       //absorb
                    currentHP += h;
                    if (currentHP > shadow.maxHP)              //Check to ensure health cap is not exceeded
                    {
                        currentHP = shadow.maxHP;
                    }
                    t = 1;
                    break;
                default:
                    d = (int)(dmg);   //Normal
                    currentHP -= d;
                    break;
            }
        }
        else
        {
            switch (check)
            {
                case -1:
                    d = (int)(4 * dmg);   //Weak
                    currentHP -= d;
                    break;
                case 2:
                    break; //Reflect
                case 3:
                    h = (int)(dmg);       //absorb
                    currentHP += h;
                    if (currentHP > shadow.maxHP)              //Check to ensure health cap is not exceeded
                    {
                        currentHP = shadow.maxHP;
                    }
                    t = 1;
                    break;
                default:
                    d = (int)(2 * dmg);   //Normal
                    currentHP -= d;
                    check = -1;
                    break;
            }
        }
        healthBar.fillAmount = currentHP / shadow.maxHP;  //sets HP to slider value

        if (enemyDamagePop && enemyHealPop)
            ShowFloatingText(d, h, t);

        if (check == -1)     //Need to add critical to this
        {
            return 2;
        }
        else if (currentHP <= 0)
        {
            currentHP = 0;
            //Play death animation and sound
            return 0;
        }else if (check == 3)
        {
            return 1;
        }else
            return check;       //Remove in a second
    }

    void ShowFloatingText(int damage, int heal, int type) {
        switch (type) {
            case 0:
                var go = Instantiate(enemyDamagePop, transform.position, Quaternion.identity, transform);
                go.GetComponent<TextMesh>().text = damage.ToString();
                break;
            case 1:
                var GO = Instantiate(enemyHealPop, transform.position, Quaternion.identity, transform);
                GO.GetComponent<TextMesh>().text = heal.ToString();
                break;
        }
    }
    public int AilmentChecker() {
        switch (ailment) {
            case 1: return 1;
            case 2: return 2;
            case 3: return 3;
            case 4: return 4;
            case 5: return 5;
            case 6: return 6;
            case 7: return 7;
            case 8: return 8;
            case 9: return 9;
            case 10: return 10;
            case 11: return 11;
            case 12: return 12;
            default: return 0;
        }
    }
    public void AilmentClear()
    {
        ailment = 0;
    }
}
