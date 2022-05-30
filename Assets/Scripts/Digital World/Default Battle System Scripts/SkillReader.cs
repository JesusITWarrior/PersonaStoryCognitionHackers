using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillReader : MonoBehaviour
{
    [SerializeField]
    private Party party;
    [SerializeField]
    private GameObject skillButton;


    [SerializeField]
    private GameObject[] SkillObjects = new GameObject[8];
    [SerializeField]
    private Skills[] skillsObjects;
    private Vector3[] vec = new Vector3[8];

    public void cleanUpSkills()
    {
        for(int i = 0; i < 8; i++)
        {
            //GameObject r = GameObject.Find(SkillObjects[i].name);
            if (SkillObjects[i])
                Destroy(SkillObjects[i]);
        }
    }

    public void createSkillObjects(int partyNum, int player)
    {
        party = GameObject.Find("Party").GetComponent<Party>();
        vec[0] = new Vector3(0, 95, 0);
        player -= 1;
        int f = 0;
        skillsObjects = party.parties[partyNum][player].GetComponent<Persona>().knownSkills();
        foreach (Skills i in skillsObjects)
        {
            if (i)
            {
                //Creation and positioning of skill button for use. Renaming it out of convenience
                GameObject p = Instantiate(skillButton, this.gameObject.transform, false);
                if (f != 0)
                    vec[f].y = vec[f - 1].y - 32;
                p.transform.localPosition = vec[f];
                p.name = i.name;

                //Creating Hover Sound effect and starting player magic attack effect
                EventTrigger trigger = p.GetComponent<EventTrigger>();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback.AddListener((functionIwant) => { GameObject.Find("Hover").GetComponent<AudioSource>().Play(); });
                trigger.triggers.Add(entry);

                EventTrigger.Entry entry1 = new EventTrigger.Entry();   //Creates new EventTrigger Entry
                entry1.eventID = EventTriggerType.PointerClick; //Makes EventTrigger of type "click"
                entry1.callback.AddListener((functionIwant) => {
                    //GameObject.Find("Select").GetComponent<AudioSource>().Play();
                    //GameObject.Find("BattleSystem").GetComponent<BattleSystem>().magicChecker(i);
                    BattleSystem bs = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
                    bs.onSkillAttack(i);
                });  //Adds a listener on EventSystem. When triggered, will run the "function I want" called "clickSoundEffect"
                trigger.triggers.Add(entry1);   //Adds the variable listed into the triggers, making it usable


                //Set the game objects' details to match the SO
                p.transform.GetChild(0).GetComponent<RawImage>().texture = i.icon;
                p.transform.GetChild(1).GetComponent<Text>().text = i.name;
                p.transform.GetChild(1).localPosition = i.textPos;
                p.transform.GetChild(1).localScale = i.textSize;

                //Add newly created object into object array for cleanup later
                SkillObjects[f] = p;
                f++;
            }
        }
    }
}
