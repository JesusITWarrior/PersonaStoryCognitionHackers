using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Skills/Skills")]
public class Skills : ScriptableObject
{
    public string Description;
    public Texture icon;
    public int cost, power, type, hits;
    public bool multiple, magic, support, heal, revive, ailment, recoverPhys, recoverMent, spHeal, typeBlock;
    public int chanceAilmentInflict, ailmentToInflict, blockType;
    public int[] ailmentsToCure;
    public Vector3 textPos, textSize;
}


/* Explanations for all the bools
 * multiple - hits everyone
 * magic - true = magic skill (uses SP), false = physical skill (uses HP)
 * support - true = targets allies, false = targets enemies
 * heal - heals, should be paired with support unless it's a draining attack
 * revive - ONLY targets unconscious players. If no one is unconscious, it should fail to cast
 * Ailment - Inflicts ailment skill. Should be paired with the chanceAilmentInflict and ailmentToInflict variables
 * recoverPhys - Skill allows to recover all physical ailments on a player, codes 1-4 and 12
 * recoverMent - Skill allows to recover all mental ailments on a player, codes 5-11
 * spHeal - Recovers SP. ONLY used to pull SP from enemies unless decided otherwise
 * typeBlock - Should be paired with support and blockType to nullify a type of damage for 1 turn
 * 
 */

/*
    Skill codes:
    Phys = 0
    Gun = 1
    Fire = 2
    Ice = 3
    Elec = 4
    Wind = 5
    Nuke = 6
    Psy = 7
    Curse = 8
    Bless = 9
    Almighty = 10
    Heal = 11
    Buff/Debuff = 12
    Passive = 13
    
    Ailment Codes:
    None=0
    Burn=1
    Freeze=2
    Shock=3
    Dizzy=4
    Forget(Memory Error)=5
    SleepMode=6
    Bugged(Confuse)=7
    Fear=8
    Despair=9
    Rage=10
    Brainwash(Hacked)=11
    Unoptimized(Hunger)=12
*/