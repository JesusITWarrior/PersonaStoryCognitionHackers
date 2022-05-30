using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CreateAssetMenu(fileName = "Enemies", menuName = "Shadows/ShadowCreator", order = 1)]
[System.Serializable]
public class ShadowBase : ScriptableObject
{
    [Header("General Properties")]
    public GameObject model;
    public string unitName;
    public int maxHP, maxSP;
    public int str, mag, en, ag, lu;
    public short[] weak, resist, absorb, reflect;    //0=weak, 1=normal, 2=strong, 3=reflect, 4=absorb
    //P=0, G=1, F=2, I=3, L=4, W=5, Ps=6, N=7, B=8, C=9, A=10
    public AnimatorOverrideController specificAnimator;
    [Header("3DModel Properties")]
    public Vector3 scale;
    [Header("Collider Properities")]
    public float radius, height;
    public int direction;
}
