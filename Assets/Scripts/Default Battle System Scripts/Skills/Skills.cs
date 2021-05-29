using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Skills/Spells")]
public class Spells : ScriptableObject
{
    public string Description;
    public Sprite icon;
    public int cost, power, type;
    public bool multiple;
}

[CreateAssetMenu (menuName = "Skills/Physical")]
public class Skills : ScriptableObject
{
    public string Description;
    public Sprite icon;
    public int cost, power, type, hits;
    public bool multiple;
}

public class skillList
{
    List<Spells> spells;
    List<Skills> skills;
}
