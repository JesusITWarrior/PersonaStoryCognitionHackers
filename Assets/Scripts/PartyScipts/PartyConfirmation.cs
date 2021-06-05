using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyConfirmation : MonoBehaviour
{
    //private PlayerControls keyboard; //May implement this at a later time
    public InputField numOfTeams;
    public GameObject C1, C2, C3, C4;
    public Party parties;
    public GameObject TeamMenu, MenuOpener;

    int pa = 1, pl = 0;

    public void read()
    {
        parties = GameObject.Find("Party").GetComponent<Party>();
        //Don't need to read the first panel, it's already the randomly assigned leader
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
        switch (coord)
        {
            case 57.67982f:
                return 2;
            case -91.63171f:
                return 3;
            case -240.9435f:
                return 4;
            default:
                throw new System.Exception("Fricc, read1Party failed for some reason :(");
        }
    }

    private float read2Party(float coord)
    {
        switch (coord)
        {
            case 149.1474f:
                return 2;
            case 43.00002f:
                return 3;
            case -45.67943f:
                return 4;
            case -152.8526f:
                return 5;
            case -258.9999f:
                return 6;
            default:
                throw new System.Exception("Fricc read2Party failed for some reason :(");
        }
    }

    private float read3Party(float coord)
    {
        switch (coord)
        {
            case 151.1473f:
                return 2;
            case -151.6794f: //Team 3
                return 5;
            case -258.8527f:
                return 6;
            case 51.3206f:
                return 3;
            case -55.85268f:
                return 4;
            default:
                throw new System.Exception("Fricc read3Party failed for some reason :(");
        }
    }

    private float read4Party(float x, float y)
    {
        if (x == -524.5577f)
        {
            return 2;
        }
        else if (y == 198.6f)
        {
            return 3;
        }
        else if (y == -75.40001f)
        {
            return 4;
        }
        else {
            throw new System.Exception("Fricc read4Party failed for some reason :(");
        }
    }
}
