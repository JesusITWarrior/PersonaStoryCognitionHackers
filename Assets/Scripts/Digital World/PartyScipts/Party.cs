using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Party : MonoBehaviour
{
    public GameObject Leader;
    [SerializeField] public Dictionary<int, List<GameObject>> parties = new Dictionary<int, List<GameObject>>();


    public List<GameObject> unassigned;
    public List<GameObject> party1 = new List<GameObject>();
    public List<GameObject> party2 = new List<GameObject>();
    public List<GameObject> party3 = new List<GameObject>();
    public List<GameObject> party4 = new List<GameObject>();

    public void Start()
    {
        autoSetLeader();
        DontDestroyOnLoad(this.gameObject);
    }
    public void manualAssignLeader(GameObject player)  //Leader is old Leader, player is new Leader
    {
        if (parties[0].Contains(player))
            parties[0].Remove(player);
        parties[1].Remove(Leader);
        parties[0].Add(Leader);
        Leader.GetComponent<Persona>().isLeader = false;
        Leader.GetComponent<Persona>().isPartyLeader = false;

        Leader = player;
        parties[1].Insert(0, Leader);
        Leader.GetComponent<Persona>().isLeader = true;
        Leader.GetComponent<Persona>().isPartyLeader = true;
    }

    private void autoSetLeader()
    {
        
        System.Random rand = new System.Random();
        int LeaderDetermine = rand.Next(1, 4);
        switch (LeaderDetermine)
        {
            case 1:
                Leader = unassigned[LeaderDetermine - 1];
                break;
            case 2:
                Leader = unassigned[LeaderDetermine - 1];
                break;
            case 3:
                Leader = unassigned[LeaderDetermine - 1];
                break;
        }
        Leader.GetComponent<Persona>().Awake();     //Remove after testing
        party1.Add(Leader);
        Leader.GetComponent<Persona>().isLeader = true;
        Leader.GetComponent<Persona>().isPartyLeader = true;
        //Leader.
        unassigned.Remove(Leader);
        for (int i = 0; i < 3; i++) {
            party1.Add(unassigned[0]);
            unassigned[0].GetComponent<Persona>().Awake();  //may need to remove this after testing
            unassigned.Remove(unassigned[0]);
        }
        parties.Add(1, party1);
    }

    public void splitUp()
    {
        //Split into 4 parties

    }

    /*public void reassembleParty()
    {
        List<GameObject> members;
        members = parties[1];
        for (int i = 2; i < parties.Count; i++)      //Searches all the parties and adds them to the main party
        {
            for (int j = 0; j < parties[i].Count; j++)
                members.Add(parties[i][j]);
        }
        if (members.Count > 4)      //if the number of party members exceeds 4 for some reason, it will reassign party members 5 and up to unassigned
        {
            for (int i = members.Count - 1; i > 3; i--)
            {
                unassigned.Add(members[i]);
                members.Remove(members[i]);
            }
        }
        parties.Clear();
        parties.Add(0, unassigned);
        parties.Add(1, members);
    }*/

    public void submitToDict()
    {
        parties.Add(1, party1);
        parties.Add(2, party2);
        parties.Add(3, party3);
        parties.Add(4, party4);
        if (party4.Count == 0)
        {
            parties.Remove(4);
        }
        if (party3.Count == 0)
        {
            parties.Remove(3);
        }
        if (party2.Count == 0) {
            parties.Remove(2);
        }
        if (party1.Count == 0)
        {
            throw new Exception("party 1 is Empty!");
        }
    }

    public int getPartyNum()                //NOTE: This method willl not 
    {
        for (int i = 1; i <= parties.Count; i++)
        {
            if ((parties[i][0].GetComponent<Persona>().triggeredCombat || parties[i][0].GetComponent<Persona>().triggeredAdvantage) && !parties[i][0].GetComponent<Persona>().inCombat)
            {
                return i;
            }
        }
        throw new Exception("This character doesn't exist.");
    }
}