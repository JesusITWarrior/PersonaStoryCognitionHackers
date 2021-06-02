using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour {
    public string charName;
    public int lv, xp, str, mag, en, ag, lu;
    public int weapon, armor;//
    public int maxHealth, maxSpirit;
    public int currentHealth, currentSpirit;

    public int partyIdentity;   //This is used at start of battle to determine where UI health bar should go
    public int ailment = 0;
    public int reflectSpell = 0;    //0 means no special reflect spell is active, 1 means tetrakarn is active, 2 means makarakarn is active, 3 means both are active
    public bool guard = false;
    public bool unconscious = false;
    public bool isPartyLeader = false, isLeader = false;
    public bool isDown = false;

    public LevelTree levelpath;

    public PlayerController PC;

    public GameObject playerDamagePop, playerHealPop;

    public GameObject Skill1;
    public GameObject Skill2;
    public GameObject Skill3;
    public GameObject Skill4;
    public GameObject Skill5;
    public GameObject Skill6;
    public GameObject Skill7;
    public GameObject Skill8;


    // Use this for initialization
    public void Awake() {
        calcMaxHealthAndSpirit();
        Debug.Log(maxHealth + " "+ currentHealth + " " + maxSpirit + " " + currentSpirit);
        currentHealth = maxHealth;          //TODO: modify this to reflect consistant HP and SP over time
        currentSpirit = maxSpirit;
       
        //healthText.text = currentHealth.ToString(); //Health to text
        //spiritText.text = currentSpirit.ToString();

    }

    private void calcMaxHealthAndSpirit()
    {
        int holder = 0;
        holder = (lv + en) * 6 +60;              //TODO: Modify values based on external factors eg social links
        holder = holder - maxHealth;
        currentHealth += holder;
        maxHealth = (lv + en) * 6 + 60;
        holder = (lv + mag) * 3 + 15;
        holder = holder - maxSpirit;
        currentSpirit += holder;
        maxSpirit = (lv + en) * 3 + 15;
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public int getSP()
    {
        return currentSpirit;
    }

    public int getMaxSP()
    {
        return maxSpirit;
    }

    public void knownSkills(){
        
    }

    public void levelUp()
    {
        //TODO: implement check on victory screen
        int i = levelpath.upgrade(lv, str, mag, en, ag, lu);
        lv++;
        //TODO: implement skill fetch
        calcMaxHealthAndSpirit();
    }

    public int TakeDamage(float dmg, int type) {
        int d=0, h=0, t=0;
        switch (type) {
            case 3:
                break; //Reflect
            case 9:
                d = (int)(2 * dmg);
                currentHealth -= d;
                break;
            default:
                d = (int)(dmg);
                currentHealth -= d;
                break;
        }
        //bar.DamageUpdate(currentHealth); //healthBarSlider.value = currentHealth;  //sets HP to slider value
        //healthText.text = currentHealth.ToString(); //Health to text

        if (playerDamagePop && playerHealPop)
            ShowFloatingText(d, h, t);

        if (currentHealth <= 0 && (type == 0 || type == 1) && ailment != 1)
            {
            currentHealth = 0;
            unconscious = true;
            return 4;
        }
        else if (currentHealth <= 0)
        {
            currentHealth = 0;
            unconscious = true;
            return 0;
        }
        else if (type == 3)
            return 3;
        else if (type == 9)
            return 2;
        else
            return 1;
    }

    void ShowFloatingText(int damage, int heal, int type)
    {
        switch (type)
        {
            case 0:
                var go = Instantiate(playerDamagePop, transform.position, Quaternion.identity, transform);
                go.GetComponent<TextMesh>().text = damage.ToString();
                break;
            case 1:
                var GO = Instantiate(playerHealPop, transform.position, Quaternion.identity, transform);
                GO.GetComponent<TextMesh>().text = heal.ToString();
                break;
            default:
                break;
        }
    }

    public void magicCast(int cost) {
        currentSpirit -= cost;
        //spiritBarSlider.value = currentSpirit;
        //spiritText.text = currentSpirit.ToString();
    }

    public void physCast(int cost)
    {
        currentHealth -= cost;
        //healthBarSlider.value = currentHealth;
        //healthText.text = currentHealth.ToString();
    }

    void Unconscious() {
        //Destroy(gameObject);    //Testing death
    }

    public int AilmentChecker()
    {
        switch (ailment)
        {
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

    public void AilmentClear() {
        ailment = 0;
    }

    public bool downChecker()
    {
        return isDown;
    }
}
