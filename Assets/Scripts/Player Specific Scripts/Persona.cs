using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Persona : MonoBehaviour {
    [Header("Stats")]
    public string charName;
    public string personaName;
    public PersonaSO stats;
    
    public int armor;
    public WeaponSO weapon;
    public GunSO gun;
    public short bulletCount;
    public int maxHealth, maxSpirit;        //Do not override
    public int currentHealth, currentSpirit;
    //Add list of equipable items here

    [Header("Dungeon-specific Stats")]
    public int ailment = 0;
    public int reflectSpell = 0;    //0 means no special reflect spell is active, 1 means tetrakarn is active, 2 means makarakarn is active, 3 means both are active
    public bool[] blockSpell = {false, false, false, false, false, false, false, false, false, false, false};
    public bool guard = false;
    public bool unconscious = false;
    public bool isPartyLeader = false, isLeader = false;        //isPartyLeader means player is leader of their respective party. isLeader means they are the leader of the entire group.
    public bool isDown = false;
    public bool triggeredCombat = false, triggeredAdvantage = false, inCombat = false, gotHit = false;

    public LevelTree levelpath;

    [Header("BattleObject")]
    public GameObject battleAvatar = null;

    [Header("Player Controllers")]
    public PlayerController PC;
    public PlayerCombatController PCC;

    public GameObject playerDamagePop, playerHealPop;

    [Header("Active Skills")]
    public Skills[] Skills = new Skills[8];

    public Animator animator;


    // Use this for initialization
    public void Awake() {
        calcMaxHealthAndSpirit();
        currentHealth = maxHealth;          //TODO: modify this to reflect consistant HP and SP over time
        currentSpirit = maxSpirit;
        bulletCount = (short)(gun.magazineSize * 3);
        //healthText.text = currentHealth.ToString(); //Health to text
        //spiritText.text = currentSpirit.ToString();
        animator = GetComponentInChildren<Animator>();
        personaName = stats.name;
    }

    private void Start()
    {
        WeaponManager[] wm = GetComponentsInChildren<WeaponManager>();
        GunManager[] gm = GetComponentsInChildren<GunManager>();
        wm[0].weaponUpdate(weapon, false);
        if (wm.Length > 1)
            wm[1].weaponUpdate(weapon, true);
        gm[0].gunUpdate(gun, false);
        if (gm.Length > 1)
            gm[1].gunUpdate(gun, true);
    }

    private void calcMaxHealthAndSpirit()
    {
        int holder = 0;
        holder = (stats.lv + stats.en) * 6 +60;              //TODO: Modify values based on external factors eg social links
        holder = holder - maxHealth;
        currentHealth += holder;
        maxHealth = (stats.lv + stats.en) * 6 + 60;
        holder = (stats.lv + stats.mag) * 3 + 15;
        holder = holder - maxSpirit;
        currentSpirit += holder;
        maxSpirit = (stats.lv + stats.en) * 3 + 15;
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

    public Skills[] knownSkills(){
        return Skills;
    }

    public void levelUp()
    {
        //TODO: implement check on victory screen
        int i = levelpath.upgrade(stats.lv, stats.str, stats.mag, stats.en, stats.ag, stats.lu);
        stats.lv++;
        //TODO: implement skill fetch
        calcMaxHealthAndSpirit();
    }

    private bool blockCheck(short type)
    {
        if (blockSpell[type])
            return true;
        else
            return false;
    }

    private bool reflectionCheck(short type)
    {
        if (reflectSpell == 0)
            return false;
        else if ((reflectSpell == 1 && (type != 0 || type != 1)) || (reflectSpell == 2 && (type <= 1)) || (reflectSpell == 3 && (type != 10)))
            return false;
        else
        {
            if (reflectSpell == 1 || reflectSpell == 2)
                reflectSpell = 0;
            else if (reflectSpell == 3 && type <= 1)
            {
                reflectSpell = 2;
            }
            else if (reflectSpell == 3 && type > 1)
            {
                reflectSpell = 1;
            }
            return true;
        }
    }

    /*
     * Name: resistanceCheck
     * Parameters: short type - attack element
     * Returns: short: -1 = weak, 2 = reflect, 4 = null, 
     * Description:
     */
    public short resistanceCheck(short type)
    {
        if (stats.weak.Length != 0)
        {
            for (int i = 0; i < stats.weak.Length; i++)
            {
                if (type == stats.weak[i])
                {
                    if (reflectionCheck(type))
                        return 2;
                    else if (blockCheck(type))
                        return 4;
                    else
                        return -1;
                }

            }
        }
        if (stats.resist.Length != 0)
        {
            for (int i = 0; i < stats.resist.Length; i++)
            {
                if (type == stats.resist[i])
                {
                    if (reflectionCheck(type))
                        return 2;
                    else if (blockCheck(type))
                        return 4;
                    else
                        return 1;
                }
            }
        }
        if (stats.block.Length != 00)
        {
            for (int i = 0; i < stats.block.Length; i++)
            {
                if (type == stats.block[i])
                {
                    if (reflectionCheck(type))
                        return 2;
                    else
                        return 4;
                }
            }
            if (stats.reflect.Length != 0)
            {
                for (int i = 0; i < stats.reflect.Length; i++)
                {
                    if (type == stats.reflect[i])
                        return 2;
                    else if (blockCheck(type))
                        return 4;
                }
            }
            if (stats.absorb.Length != 0)
            {
                for (int i = 0; i < stats.absorb.Length; i++)
                {
                    if (type == stats.absorb[i])
                    {

                        if (reflectionCheck(type))
                            return 2;
                        else if (blockCheck(type))
                            return 4;
                        else
                            return 3;
                    }
                }
            }
        }
        return 0;
    }

    public void heal(float heal)
    {
        int h = (int)(heal);
        currentHealth += h;
        if ((float)(currentHealth / maxHealth * 100) > 30)
            animator.SetBool("Injured", false);
    }

    //Needs to be revamped to handle strength, weakness, etc. from player
    public int TakeDamage(float dmg, short type, bool crit) {
        int d=0, h=0, t=0;
        short check = resistanceCheck(type);
        if (!crit)
        {
            switch (check)
            {
                case -1:
                    animator.Play("KnockDown");
                    d = (int)(2 * dmg);   //Weak
                    currentHealth -= d;
                    guard = false;
                    animator.SetBool("isBlocking", false);
                    break;
                case 1:
                    animator.Play("TakeDamage");
                    d = (int)(dmg / 2);       //Strong
                    currentHealth -= d;
                    animator.SetBool("isBlocking", false);
                    guard = false;
                    break;
                case 2:
                    break; //Reflect
                case 3:
                    h = (int)(dmg);       //absorb
                    currentHealth += h;
                    if (currentHealth > maxHealth)              //Check to ensure health cap is not exceeded
                    {
                        currentHealth = maxHealth;
                    }
                    t = 1;
                    break;
                case 4:
                    break; //Block
                default:
                    animator.Play("TakeDamage");
                    d = (int)(dmg);   //Normal
                    currentHealth -= d;
                    guard = false;
                    animator.SetBool("isBlocking", false);
                    break;
            }
            //healthBar.fillAmount = currentHealth / maxHealth;  //sets HP to slider value

            //if (enemyDamagePop && enemyHealPop)
            //    ShowFloatingText(d, h, t);
        }
        else
        {
            switch (check)
            {
                case -1:
                    animator.Play("KnockDown");
                    d = (int)(4 * dmg);   //Weak
                    currentHealth -= d;
                    break;
                case 2:
                    break; //Reflect
                case 3:
                    h = (int)(dmg);       //absorb
                    currentHealth += h;
                    if (currentHealth > maxHealth)              //Check to ensure health cap is not exceeded
                    {
                        currentHealth = maxHealth;
                    }
                    t = 1;
                    break;
                case 4:
                    break; //Block
                default:
                    animator.Play("KnockDown");
                    d = (int)(2 * dmg);   //Normal
                    currentHealth -= d;
                    check = -1;
                    break;
            }
        }

        if(((float)currentHealth / (float)maxHealth * 100) <= 30)
            animator.SetBool("Injured", true);
        else
            animator.SetBool("Injured", false);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            animator.Play("Unconscious");
            unconscious = true;
        }

        if (check == -1 && currentHealth == 0)
            return 4;
        else if (currentHealth == 0)
            return 0;
        else if (check == -1)
            return 2;
        else if (check == 3)
            return 3;
        else if (check == 4)
            return 5;
        else
            return 1;
        //0 = Unconscious
        //1 = Normal
        //2 = Crit/Weak knock down
        //3 = Reflected
        //4 = Crit/Weak knock down and Unconscious

        /*switch (type) {
            case 3:
                break; //Reflect
            case 9:
                d = (int)(2 * dmg);
                currentHealth -= d;
                break;
            default:
                d = (int)(dmg);
                Debug.Log(d);
                Debug.Log(currentHealth);
                currentHealth -= d;
                Debug.Log(currentHealth);
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
            return 1;*/
    }

    private void ShowFloatingText(int damage, int heal, int type)
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

    public void heal()
    {

    }

    public void healPercent()
    {

    }

    private void Update()
    {
        if (battleAvatar)
        {
            currentHealth = battleAvatar.GetComponent<Persona>().currentHealth;
            currentSpirit = battleAvatar.GetComponent<Persona>().currentSpirit;
        }
    }
}
