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
    public int chanceAilmentInflict, ailmentToInflict;
    public Vector3 textPos, textSize;
}

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