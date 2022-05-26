using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonaFinder : MonoBehaviour
{
    private Persona persona;
    private PlayerCombatController pcc;
    private PlayerController pc;
    // Start is called before the first frame update
    void Awake()
    {
        persona = GetComponentInParent<Persona>();
        pc = GetComponentInParent<PlayerController>();
        pcc = GetComponentInParent<PlayerCombatController>();
    }

    public void cantMove()
    {
        pc.canMove = false;
    }

    public void canMove()
    {
        pc.canMove = true;
    }
}
