using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Party : MonoBehaviour
{
    public Player Leader;
    [SerializeField] public Dictionary<int, List<Player>> parties = new Dictionary<int, List<Player>>();


    public List<Player> unassigned;
    public List<Player> party1 = new List<Player>();
    public List<Player> party2 = new List<Player>();
    public List<Player> party3 = new List<Player>();
    public List<Player> party4 = new List<Player>();

    void Awake()
    {
        autoSetLeader();
        DontDestroyOnLoad(this.gameObject);
    }
    public void manualAssignLeader(Player player)  //Leader is old Leader, player is new Leader
    {
        if (parties[0].Contains(player))
            parties[0].Remove(player);
        parties[1].Remove(Leader);
        parties[0].Add(Leader);
        Leader.isLeader = false;
        Leader.isPartyLeader = false;

        Leader = player;
        parties[1].Insert(0, Leader);
        Leader.isLeader = true;
        Leader.isPartyLeader = true;
    }

    public void autoSetLeader()
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
        Leader.Awake();     //Remove after testing
        party1.Add(Leader);
        Leader.isLeader = true;
        Leader.isPartyLeader = true;
        //Leader.
        unassigned.Remove(Leader);
        for (int i = 0; i < 3; i++) {
            party1.Add(unassigned[0]);
            unassigned[0].Awake();  //may need to remove this after testing
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
        List<Player> members;
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
}