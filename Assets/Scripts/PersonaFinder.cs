using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonaFinder : MonoBehaviour
{
    private Persona persona;
    private PlayerCombatController pcc;
    private PlayerController pc;
    private AudioSource audioSource;
    [SerializeField] AudioClip[] steps;
    private bool battle=false;
    // Start is called before the first frame update
    void Awake()
    {
        persona = GetComponentInParent<Persona>();
        pc = GetComponentInParent<PlayerController>();
        pcc = GetComponentInParent<PlayerCombatController>();
        audioSource = GetComponent<AudioSource>();
    }

    public void cantMove()
    {
        pc.canMove = false;
    }

    public void canMove()
    {
        pc.canMove = true;
        battle = false;
    }

    public void playSound(AudioClip clip)
    {
        audioSource.volume = 1f;
        audioSource.PlayOneShot(clip);
    }

    public void Step()
    {
        audioSource.volume = 0.8f;
        audioSource.PlayOneShot(randomStepSound());
    }

    private AudioClip randomStepSound()
    {
        return steps[Random.Range(0,steps.Length-1)];
    }

    public void gunShot()
    {
        audioSource.volume = 1f;
        audioSource.PlayOneShot(persona.gun.gunshotSound);
    }

    public void melee(AudioClip clip)
    {
        GameObject bs = GameObject.Find("BattleSystem");
        if (!bs)
        {
            battle = true;
        }
        else
        {
            bs.GetComponent<BattleSystem>().smacked = true;
            audioSource.PlayOneShot(clip);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (battle && other.tag == "Enemy")
        {
            battle = false;
            if (!other.GetComponent<GeneralShadow>().sawPartyAnalyzer(persona.charName))
            {
                persona.triggeredAdvantage = true;
                persona.triggeredCombat = true;
            }
            else
            {
                persona.triggeredAdvantage = false;
                persona.triggeredCombat = true;
            }
            //Load up combat scene
        }
    }
}
