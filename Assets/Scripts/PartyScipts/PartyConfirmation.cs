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
    

    public void read()
    {
        parties = GameObject.Find("Party").GetComponent<Party>();
        //Vector3 pan1 = C1.transform.position;           //Don't need to read this, it's already the randomly assigned leader
        Vector3 pan2 = C2.transform.localPosition;
        Vector3 pan3 = C3.transform.localPosition;
        Vector3 pan4 = C4.transform.localPosition;
        List<Player> placeholder = new List<Player>();
        List<Player> placeholder1 = new List<Player>();
        List<Player> placeholder2 = new List<Player>();
        List<Player> placeholder3 = new List<Player>();

        placeholder.Add(parties.parties[1][0]);
        for(int i = 1; i < 4; i++)
        {
            if(parties.parties[1][i])
                parties.parties[1][i].isPartyLeader = false;
        }

        switch (int.Parse(numOfTeams.text))
        {
            case 1:
                pan2.z = read1Party(pan2.y);
                pan3.z = read1Party(pan3.y);
                pan4.z = read1Party(pan4.y);
                if(pan2.z == 2)
                {
                    placeholder.Add(parties.parties[1][1]);
                }else if (pan3.z == 2)
                {
                    placeholder.Add(parties.parties[1][2]);
                }else if (pan4.z == 2)
                {
                    placeholder.Add(parties.parties[1][3]);
                }
                if (pan2.z == 3)
                {
                    placeholder.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 3)
                {
                    placeholder.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 3)
                {
                    placeholder.Add(parties.parties[1][3]);
                }
                if (pan2.z == 4)
                {
                    placeholder.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 4)
                {
                    placeholder.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 4)
                {
                    placeholder.Add(parties.parties[1][3]);
                }
                parties.parties.Clear();
                parties.AddCharacters(placeholder, 1);
                //for (int i = 0; i < 4; i++)
                //{
                //    Debug.Log(placeholder[i].name);
                //}
                placeholder.Clear();
                break;
            case 2:
                pan2.z = read2Party(pan2.y);
                pan3.z = read2Party(pan3.y);
                pan4.z = read2Party(pan4.y);
                if (pan2.z == 2)
                {
                    placeholder.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 2)
                {
                    placeholder.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 2)
                {
                    placeholder.Add(parties.parties[1][3]);
                }
                if (pan2.z == 3)
                {
                    placeholder.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 3)
                {
                    placeholder.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 3)
                {
                    placeholder.Add(parties.parties[1][3]);
                }
                
                if (pan2.z == 4)
                {
                    parties.parties[1][1].isPartyLeader = true;
                    placeholder1.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 4)
                {
                    parties.parties[1][2].isPartyLeader = true;
                    placeholder1.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 4)
                {
                    parties.parties[1][3].isPartyLeader = true;
                    placeholder1.Add(parties.parties[1][3]);
                }
                if (pan2.z == 5)
                {
                    placeholder1.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 5)
                {
                    placeholder1.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 5)
                {
                    placeholder1.Add(parties.parties[1][3]);
                }
                if (pan2.z == 6)
                {
                    placeholder1.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 6)
                {
                    placeholder1.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 6)
                {
                    placeholder1.Add(parties.parties[1][3]);
                }
                parties.parties.Clear();
                parties.AddCharacters(placeholder, 1);
                parties.AddCharacters(placeholder1, 2);
                //placeholder.Clear();
                //placeholder1.Clear();
                break;
            case 3:
                pan2.z = read3Party(pan2.y);
                pan3.z = read3Party(pan3.y);
                pan4.z = read3Party(pan4.y);
                if (pan2.z == 2)
                {
                    placeholder.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 2)
                {
                    placeholder.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 2)
                {
                    placeholder.Add(parties.parties[1][3]);
                }

                if (pan2.z == 3)
                {
                    parties.parties[1][1].isPartyLeader = true;
                    placeholder1.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 3)
                {
                    parties.parties[1][2].isPartyLeader = true;
                    placeholder1.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 3)
                {
                    parties.parties[1][3].isPartyLeader = true;
                    placeholder1.Add(parties.parties[1][3]);
                }
                if (pan2.z == 4)
                {
                    placeholder1.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 4)
                {
                    placeholder1.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 4)
                {
                    placeholder1.Add(parties.parties[1][3]);
                }

                if (pan2.z == 5)
                {
                    parties.parties[1][1].isPartyLeader = true;
                    placeholder2.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 5)
                {
                    parties.parties[1][2].isPartyLeader = true;
                    placeholder2.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 5)
                {
                    parties.parties[1][3].isPartyLeader = true;
                    placeholder2.Add(parties.parties[1][3]);
                }
                if (pan2.z == 6)
                {
                    placeholder2.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 6)
                {
                    placeholder2.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 6)
                {
                    placeholder2.Add(parties.parties[1][3]);
                }

                parties.parties.Clear();
                parties.AddCharacters(placeholder, 1);
                parties.AddCharacters(placeholder1, 2);
                parties.AddCharacters(placeholder2, 3);
                //placeholder.Clear(); placeholder1.Clear(); placeholder2.Clear();
                break;
            case 4:
                for (int i = 1; i < 4; i++)
                {
                    parties.parties[1][i].isPartyLeader = true;
                }
                pan2.z = read4Party(pan2.x, pan2.y);
                pan3.z = read4Party(pan3.x, pan3.y);
                pan4.z = read4Party(pan4.x, pan4.y);
                if (pan2.z == 2)
                {
                    placeholder1.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 2)
                {
                    placeholder1.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 2)
                {
                    placeholder1.Add(parties.parties[1][3]);
                }
                if (pan2.z == 3)
                {
                    placeholder2.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 3)
                {
                    placeholder2.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 3)
                {
                    placeholder2.Add(parties.parties[1][3]);
                }
                if (pan2.z == 4)
                {
                    placeholder3.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 4)
                {
                    placeholder3.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 4)
                {
                    placeholder3.Add(parties.parties[1][3]);
                }
                parties.parties.Clear();
                parties.AddCharacters(placeholder, 1);
                Debug.Log(placeholder[0].name);
                parties.AddCharacters(placeholder1, 2);
                Debug.Log(placeholder1[0].name);
                parties.AddCharacters(placeholder2, 3);
                Debug.Log(placeholder2[0].name);
                parties.AddCharacters(placeholder3, 4);
                Debug.Log(placeholder3[0].name);
                //placeholder.Clear(); placeholder1.Clear(); placeholder2.Clear(); placeholder3.Clear();
                        
                Debug.Log(parties.parties[1][0].name);
                
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
