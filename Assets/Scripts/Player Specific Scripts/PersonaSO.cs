using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Players", menuName = "Personas", order = 1)]
[System.Serializable]
public class PersonaSO : ScriptableObject
{
    public int lv, xp, str, mag, en, ag, lu;
    public GameObject model;
    public short[] weak, resist, absorb, reflect; //0=weak, 1=normal, 2=strong, 3=reflect, 4=absorb
    //P=0, G=1, F=2, I=3, L=4, W=5, Ps=6, N=7, B=8, C=9, A=10
}
