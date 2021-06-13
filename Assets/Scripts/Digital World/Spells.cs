using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outDatedSpells
{
    public static bool multiple;
    public static int hits;
    public int cost;
    public int Phys(int level)
    {
        switch (level)
        {
            case 1: //lunge
                multiple = false;
                hits = 1;
                cost = 5;
                return 60;   //Power=60 of phys type at 5% HP
            case 2: //Cleave
                multiple = false;
                hits = 1;
                cost = 6;
                return 65; //Power=65 of phys type at 6% HP
            default:
                return 0;
        }
        
    }

    public int Gun(int level)
    {
        switch (level)
        {
            case 1: //Snap
                multiple = false;
                hits = 1;
                cost = 9;
                return 80;   //Power=80 of phys type at 9% HP
            case 2: //Triple Down
                multiple = false;
                hits = 3;
                cost = 16;
                return 30; //Power=30 of phys type at 16% HP
            default:
                return 0;
        }

    }

    public int Fire(int level)
    {
        switch (level)
        {
            case 1: //Agi
                multiple = false;
                hits = 1;
                cost = 4;
                return 23;   //Power=23 of fire type at 4 SP
            case 2: //Maragi
                multiple = true;
                hits = 1;
                cost = 10;
                return 19; //Power=19 of fire type at 10 SP
            default:
                return 0;
        }

    }

    public int Ice(int level)
    {
        switch (level)
        {
            case 1: //Bufu
                multiple = false;
                hits = 1;
                cost = 4;
                return 23;   //Power=23 of ice type at 4 SP
            case 2: //Mabufu
                multiple = true;
                hits = 1;
                cost = 10;
                return 19; //Power=19 of ice type at 10 SP
            default:
                return 0;
        }

    }

    public int Lightning(int level)
    {
        switch (level)
        {
            case 1: //Zio
                multiple = false;
                hits = 1;
                cost = 4;
                return 23;   //Power=23 of lightning type at 4 SP
            case 2: //Mazio
                multiple = true;
                hits = 1;
                cost = 10;
                return 19; //Power=19 of lightning type at 10 SP
            default:
                return 0;
        }

    }

    public int Wind(int level)
    {
        switch (level)
        {
            case 1: //Garu
                multiple = false;
                hits = 1;
                cost = 3;
                return 23;   //Power=23 of wind type at 3 SP
            case 2: //Magaru
                multiple = true;
                hits = 1;
                cost = 8;
                return 19; //Power=19 of wind type at 8 SP
            default:
                return 0;
        }

    }

    public int Psychic(int level)
    {
        switch (level)
        {
            case 1: //Psi
                multiple = false;
                hits = 1;
                cost = 4;
                return 23;   //Power=23 of psychic type at 4 SP
            case 2: //Mapsi
                multiple = true;
                hits = 1;
                cost = 10;
                return 19; //Power=19 of psychic type at 10 SP
            default:
                return 0;
        }

    }

    public int Nuclear(int level)
    {
        switch (level)
        {
            case 1: //Frei
                multiple = false;
                hits = 1;
                cost = 4;
                return 23;   //Power=23 of nuclear type at 4 SP
            case 2: //Mafrei
                multiple = true;
                hits = 1;
                cost = 10;
                return 19; //Power=19 of nuclear type at 10 SP
            default:
                return 0;
        }

    }

    public int Bless(int level)
    {
        switch (level)
        {
            case 1: //Kouha
                multiple = false;
                hits = 1;
                cost = 4;
                return 23;   //Power=23 of bless type at 4 SP
            case 2: //Makouha
                multiple = true;
                hits = 1;
                cost = 10;
                return 19; //Power=19 of bless type at 10 SP
            default:
                return 0;
        }

    }

    public int Curse(int level)
    {
        switch (level)
        {
            case 1: //Eiha
                multiple = false;
                hits = 1;
                cost = 4;
                return 23;   //Power=23 of curse type at 4 SP
            case 2: //Maeiha
                multiple = true;
                hits = 1;
                cost = 10;
                return 19; //Power=19 of curse type at 10 SP
            default:
                return 0;
        }

    }

    public void Healing(int level)
    {
        //type.OnSpellSupport(1, level);
    }

    public void Debuff(int level)
    {
        //type.OnSpellAttack(1, level);
    }

    public void Buff(int level)
    {
        //type.OnSpellSupport(1, level);
    }

    public void Ailment()
    {
        //Fill this in later
    }
}

public class EnemySpells
{
    public static bool multiple;
    public static int hits;
    public int Phys(int level)
    {
        switch (level)
        {
            case 1: //lunge
                multiple = false;
                hits = 1;
                return 60;   //Power=60 of phys type at no HP cost
            case 2: //Cleave
                multiple = false;
                hits = 1;
                return 65; //Power=65 of phys type at no HP cost
            default:
                return 0;
        }

    }

    public int Gun(int level)
    {
        switch (level)
        {
            case 1: //Snap
                multiple = false;
                hits = 1;
                return 80;   //Power=80 of phys type at no HP cost
            case 2: //Triple Down
                multiple = false;
                hits = 3;
                return 30; //Power=30 of phys type at no HP cost
            default:
                return 0;
        }

    }
}