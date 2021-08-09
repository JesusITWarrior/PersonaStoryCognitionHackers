using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyConfirmation : MonoBehaviour
{
    //private PlayerControls keyboard; //May implement this at a later time
    public InputField numOfTeams;

    public GameObject C1, C2, C3, C4;                       //Character panel positions
    public Transform A1, A2, A3, A4;                        //1 team, 4 slots
    public Transform L1, L2, L3, L4, L5, L6;                //2 teams, 6 slots
    public Transform S1, S2, S3, S4, S5, S6;                //3 teams, 6 slots
    public Transform T1, T2, T3, T4;                        //4 teams, 4 slots
    public Canvas menu;

    public Party parties;
    public GameObject TeamMenu, MenuOpener;

    public void read()
    {
        parties = GameObject.Find("Party").GetComponent<Party>();
        //Don't need to read the first panel, it's already the randomly assigned leader
        A1.transform.parent = menu.transform;
        A2.transform.parent = menu.transform;
        A3.transform.parent = menu.transform;
        A4.transform.parent = menu.transform;
        L1.transform.parent = menu.transform;                                           //Setting the panels to be universal
        L2.transform.parent = menu.transform;
        L3.transform.parent = menu.transform;
        L4.transform.parent = menu.transform;
        L5.transform.parent = menu.transform;
        L6.transform.parent = menu.transform;
        S1.transform.parent = menu.transform;
        S2.transform.parent = menu.transform;
        S3.transform.parent = menu.transform;
        S4.transform.parent = menu.transform;
        S5.transform.parent = menu.transform;
        S6.transform.parent = menu.transform;
        T1.transform.parent = menu.transform;
        T2.transform.parent = menu.transform;
        T3.transform.parent = menu.transform;
        T4.transform.parent = menu.transform;
        Vector3 pan2 = C2.transform.localPosition;
        Vector3 pan3 = C3.transform.localPosition;
        Vector3 pan4 = C4.transform.localPosition;

        for (int i = 1; i <= parties.parties.Count; i++)         //Reads through the parties and moves the Players to unassigned list
        {
            for (int j = 0; j < parties.parties[i].Count ; j += 0)
            {
                parties.unassigned.Add(parties.parties[i][j]);
                parties.parties[i].Remove(parties.parties[i][j]);
            }
        }
        parties.party1.Clear(); parties.party2.Clear(); parties.party3.Clear(); parties.party4.Clear();
        parties.party1.Add(parties.Leader);     //Ensures the overall leader is still assigned to slot 1 of party 1
        parties.unassigned.Remove(parties.Leader);
        for (int i = 0; i < parties.unassigned.Count; i++)
        {
            parties.unassigned[i].GetComponent<Player>().isPartyLeader = false;
        }

        parties.parties.Clear();


        switch (int.Parse(numOfTeams.text))
        {
            case 1:
                pan2.z = read1Party(pan2.y);
                pan3.z = read1Party(pan3.y);
                pan4.z = read1Party(pan4.y);

                if (pan2.z == 2)
                {
                    parties.party1.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 2)
                {
                    parties.party1.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 2)
                {
                    parties.party1.Add(parties.unassigned[2]);
                }
                if (pan2.z == 3)
                {
                    parties.party1.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 3)
                {
                    parties.party1.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 3)
                {
                    parties.party1.Add(parties.unassigned[2]);
                }
                if (pan2.z == 4)
                {
                    parties.party1.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 4)
                {
                    parties.party1.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 4)
                {
                    parties.party1.Add(parties.unassigned[2]);
                }
                //Debug.Log(parties.party1[1] + " " + parties.party1[2] + " " + parties.party1[3]);
                parties.unassigned.Clear();
                parties.submitToDict();
                break;
            case 2:
                pan2.z = read2Party(pan2.y);
                pan3.z = read2Party(pan3.y);
                pan4.z = read2Party(pan4.y);
                if (pan2.z == 2)
                {
                    parties.party1.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 2)
                {
                    parties.party1.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 2)
                {
                    parties.party1.Add(parties.unassigned[2]);
                }
                if (pan2.z == 3)
                {
                    parties.party1.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 3)
                {
                    parties.party1.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 3)
                {
                    parties.party1.Add(parties.unassigned[2]);
                }

                if (pan2.z == 4)
                {
                    parties.unassigned[0].GetComponent<Player>().isPartyLeader = true;
                    parties.party2.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 4)
                {
                    parties.unassigned[1].GetComponent<Player>().isPartyLeader = true;
                    parties.party2.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 4)
                {
                    parties.unassigned[2].GetComponent<Player>().isPartyLeader = true;
                    parties.party2.Add(parties.unassigned[2]);
                }
                if (pan2.z == 5)
                {
                    parties.party2.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 5)
                {
                    parties.party2.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 5)
                {
                    parties.party2.Add(parties.unassigned[2]);
                }
                if (pan2.z == 6)
                {
                    parties.party2.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 6)
                {
                    parties.party2.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 6)
                {
                    parties.party2.Add(parties.unassigned[2]);
                }
                parties.unassigned.Clear();
                parties.submitToDict();
                break;
            case 3:
                pan2.z = read3Party(pan2.y);
                pan3.z = read3Party(pan3.y);
                pan4.z = read3Party(pan4.y);
                if (pan2.z == 2)
                {
                    parties.party1.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 2)
                {
                    parties.party1.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 2)
                {
                    parties.party1.Add(parties.unassigned[2]);
                }

                if (pan2.z == 3)
                {
                    parties.unassigned[0].GetComponent<Player>().isPartyLeader = true;
                    parties.party2.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 3)
                {
                    parties.unassigned[1].GetComponent<Player>().isPartyLeader = true;
                    parties.party2.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 3)
                {
                    parties.unassigned[2].GetComponent<Player>().isPartyLeader = true;
                    parties.party2.Add(parties.unassigned[2]);
                }
                if (pan2.z == 4)
                {
                    parties.party2.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 4)
                {
                    parties.party2.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 4)
                {
                    parties.party2.Add(parties.unassigned[2]);
                }

                if (pan2.z == 5)
                {
                    parties.unassigned[0].GetComponent<Player>().isPartyLeader = true;
                    parties.party3.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 5)
                {
                    parties.unassigned[1].GetComponent<Player>().isPartyLeader = true;
                    parties.party3.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 5)
                {
                    parties.unassigned[2].GetComponent<Player>().isPartyLeader = true;
                    parties.party3.Add(parties.unassigned[2]);
                }
                if (pan2.z == 6)
                {
                    parties.party3.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 6)
                {
                    parties.party3.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 6)
                {
                    parties.party3.Add(parties.unassigned[2]);
                }
                parties.unassigned.Clear();
                parties.submitToDict();
                break;
            case 4:
                for (int i = 0; i < 3; i++)
                {
                    parties.unassigned[i].GetComponent<Player>().isPartyLeader = true;
                }
                pan2.z = read4Party(pan2.x, pan2.y);
                pan3.z = read4Party(pan3.x, pan3.y);
                pan4.z = read4Party(pan4.x, pan4.y);
                if (pan2.z == 2)
                {
                    parties.party2.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 2)
                {
                    parties.party2.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 2)
                {
                    parties.party2.Add(parties.unassigned[2]);
                }
                if (pan2.z == 3)
                {
                    parties.party3.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 3)
                {
                    parties.party3.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 3)
                {
                    parties.party3.Add(parties.unassigned[2]);
                }
                if (pan2.z == 4)
                {
                    parties.party4.Add(parties.unassigned[0]);
                }
                else if (pan3.z == 4)
                {
                    parties.party4.Add(parties.unassigned[1]);
                }
                else if (pan4.z == 4)
                {
                    parties.party4.Add(parties.unassigned[2]);
                }
                parties.submitToDict();
                

                parties.unassigned.Clear();

                break;
        }
        Instantiate(MenuOpener);
        Destroy(TeamMenu);
    }

    private float read1Party(float coord)
    {
        int cord = (int)(coord);
        if (cord == (int)(A2.localPosition.y))
            return 2;
        else if (cord == (int)(A3.localPosition.y))
            return 3;
        else if (cord == (int)(A4.localPosition.y))
            return 4;
        else
            throw new System.Exception("Fricc, read1Party failed for some reason :(");
    }

    private float read2Party(float coord)
    {
        int cord = (int)(coord);
        if (cord == (int)(L2.localPosition.y))
            return 2;
        else if (cord == (int)(L3.localPosition.y))
            return 3;
        else if (cord == (int)(L4.localPosition.y))
            return 4;
        else if (cord == (int)(L5.localPosition.y))
            return 5;
        else if (cord == (int)(L6.localPosition.y))
            return 6;
        else
            throw new System.Exception("Fricc, read2Party failed for some reason :(");
    }

    private float read3Party(float coord)
    {
        int cord = (int)(coord);
        if (cord == (int)(S2.localPosition.y))
            return 2;
        else if (cord == (int)(S3.localPosition.y))     //Team 2
            return 3;
        else if (cord == (int)(S4.localPosition.y))
            return 4;
        else if (cord == (int)(S5.localPosition.y))    //Team 3
            return 5;
        else if (cord == (int)(S6.localPosition.y))
            return 6;
        else
            throw new System.Exception("Fricc, read1Party failed for some reason :(");
    }

    private float read4Party(float x, float y)
    {

        if ((int)(x) == (int)(T2.localPosition.x))
            return 2;
        else if ((int)(y) == (int)(T3.localPosition.y))
            return 3;
        else if ((int)(y) == (int)(T4.localPosition.y))
            return 4;
        else {
            throw new System.Exception("Fricc read4Party failed for some reason :(");
        }
    }
}
