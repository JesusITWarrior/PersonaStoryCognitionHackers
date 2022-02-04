using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Skills/Skills")]
public class Skills : ScriptableObject
{
    public string Description;
    public Texture icon;
    public int cost, power, type, hits;
    public bool multiple, magic;
    public Vector3 textPos, textSize;
}

public class skillList
{
    List<Skills> skills;
}
