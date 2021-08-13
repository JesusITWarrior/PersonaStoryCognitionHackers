using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Unit : MonoBehaviour {
    [SerializeField]
    private GameObject healthBarObject;
    private Image healthBar;
    public GameObject enemyDamagePop, enemyHealPop;
    private int currentHP, currentSP;
    public ShadowBase shadow;
    public EnemyController EC;
    public bool isDown = false;
    //public GameObject model;

    public int ailment = 0; //None=0, ~~Down=1~~, Burn=2, Freeze=3, Shock=4, Dizzy=5, Forget(Memory Error)=6, SleepMode=7, Confuse=8, Fear=9, Despair=10, Rage=11, Brainwash(Hacked)=12, Unoptimized(Hunger)=13
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


    public int TakeDamage(float dmg, int type) {
        int d = 0, h = 0, t = 0;
        switch (type){
            case 0:
            case 1:
                d = (int)(2 * dmg);   //Weak
                currentHP -= d;
                break;
            case 4:
                d = (int)(dmg / 2);       //Strong
                currentHP -= d;
                break;
            case 5:
                break; //Reflect
            case 6:
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
        healthBar.fillAmount = currentHP/shadow.maxHP;  //sets HP to slider value
        
        if (enemyDamagePop && enemyHealPop)
            ShowFloatingText(d, h, t);

        if (currentHP > 0 && (type == 0 || type == 1) && ailment != 1)     //Need to add critical to this
        {
            ailment = 1;
            return 4;
        }
        else if (currentHP <= 0) {
            currentHP = 0;
            //Play death animation and sound
            return 0;
        }
        else if (type == 5)
            return 3;
        else if (type == 1 || type == 0)
            return 2;
        else
            return 1;
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
