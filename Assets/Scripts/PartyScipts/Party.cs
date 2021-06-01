using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Party : MonoBehaviour
{
    public Player Leader;
    //public List<Player> members;
    public Dictionary<int, List<Player>> parties = new Dictionary<int, List<Player>>();

    
    public List<Player> unassigned;

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
        List<Player> placeholder = new List<Player>();
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
        placeholder.Add(Leader);
        Leader.isLeader = true;
        Leader.isPartyLeader = true;
        //Leader.
        unassigned.Remove(Leader);
        for (int i = 0; i < 3; i++) {
            placeholder.Add(unassigned[0]);
            unassigned.Remove(unassigned[0]);
        }
        parties.Add(1, placeholder);
        //placeholder.Add(Leader);
        //unassigned.Remove(Leader);
        //placeholder.Add(unassigned[0]);
        //placeholder.Add(unassigned[1]);
        //placeholder.Add(unassigned[2]);
        //unassigned.Remove(unassigned[0]);
        //unassigned.Remove(unassigned[0]);
        //unassigned.Remove(unassigned[0]);
        //parties.Remove(1);
        //parties.Add(1, placeholder);
    }

    public void splitUp()
    {
        createParties(4);

    }

    public void createParties(int p)
    {
        //Debug.Log("I am making "+p+" parties.");
        if (p == 1)
        {
            reassembleParty();
        }
        else
        {
            for (int i = 2; i <= p; i++)
            {
                parties.Add(i, null);
            }
        }
    }

    public void resetParties()
    {
        //Clears all parties from game except the leader
        parties.Clear();
        List<Player> placeholder = new List<Player>();
        placeholder.Add(Leader);
        parties.Add(1, placeholder);
    }

    public void reassembleParty()
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
    }

    public void AddCharacters(List<Player> member)
    {
        //TODO: Implement this
    }

    public void RemoveCharacters(Player member)
    {
        //TODO: Implement this
    }

    public void spawnCharacter()
    {

    }
}