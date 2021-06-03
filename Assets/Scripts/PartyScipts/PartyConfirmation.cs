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
                switch (pan2.y)
                {
                    case -7.106201f:
                        pan2.z = 2;
                        break;
                    case -173.4937f:
                        pan2.z = 3;
                        break;
                    case -339.8814f:
                        pan2.z = 4;
                        break;
                }
                switch (pan3.y)
                {
                    case -7.106201f:
                        pan3.z = 2;
                        break;
                    case -173.4937f:
                        pan3.z = 3;
                        break;
                    case -339.8814f:
                        pan3.z = 4;
                        break;
                }
                switch (pan4.y)
                {
                    case -7.106201f:
                        pan4.z = 2;
                        break;
                    case -173.4937f:
                        pan4.z = 3;
                        break;
                    case -339.8814f:
                        pan4.z = 4;
                        break;
                }
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
                switch (pan2.y)
                {
                    case 171.7141f:
                        pan2.z = 2;
                        break;
                    case 68.47693f:
                        pan2.z = 3;
                        break;
                    case -175.4038f:
                        pan2.z = 5;
                        break;
                    case -279.6384f:
                        pan2.z = 6;
                        break;
                    case -382.8756f:
                        pan2.z = 7;
                        break;
                }
                switch (pan3.y)
                {
                    case 171.7141f:
                        pan3.z = 2;
                        break;
                    case 68.47693f:
                        pan3.z = 3;
                        break;
                    case -175.4038f:
                        pan3.z = 5;
                        break;
                    case -279.6384f:
                        pan3.z = 6;
                        break;
                    case -382.8756f:
                        pan3.z = 7;
                        break;
                }
                switch (pan4.y)
                {
                    case 171.7141f:
                        pan4.z = 2;
                        break;
                    case 68.47693f:
                        pan4.z = 3;
                        break;
                    case -175.4038f:
                        pan4.z = 5;
                        break;
                    case -279.6384f:
                        pan4.z = 6;
                        break;
                    case -382.8756f:
                        pan4.z = 7;
                        break;
                }
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
                
                if (pan2.z == 5)
                {
                    parties.parties[1][1].isPartyLeader = true;
                    placeholder1.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 5)
                {
                    parties.parties[1][2].isPartyLeader = true;
                    placeholder1.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 5)
                {
                    parties.parties[1][3].isPartyLeader = true;
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
                if (pan2.z == 7)
                {
                    placeholder1.Add(parties.parties[1][1]);
                }
                else if (pan3.z == 7)
                {
                    placeholder1.Add(parties.parties[1][2]);
                }
                else if (pan4.z == 7)
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
                switch (pan2.y)
                {
                    case 156.0361f:
                        pan2.z = 2;
                        break;
                    case -268.5559f: //Team 3
                        pan2.z = 5;
                        break;
                    case -375.0813f:
                        pan2.z = 6;
                        break;
                    case -3.96991f:
                        pan2.z = 3;
                        break;
                    case -110.4954f:
                        pan2.z = 4;
                        break;
                }
                switch (pan3.y)
                {
                    case 156.0361f:
                        pan3.z = 2;
                        break;
                    case -268.5559f: //Team 3
                        pan3.z = 5;
                        break;
                    case -375.0813f:
                        pan3.z = 6;
                        break;
                    case -3.96991f:
                        pan3.z = 3;
                        break;
                    case -110.4954f:
                        pan3.z = 4;
                        break;
                }
                switch (pan4.y)
                {
                    case 156.0361f:
                        pan4.z = 2;
                        break;
                    case -268.5559f: //Team 3
                        pan4.z = 5;
                        break;
                    case -375.0813f:
                        pan4.z = 6;
                        break;
                    case -3.96991f:
                        pan4.z = 3;
                        break;
                    case -110.4954f:
                        pan4.z = 4;
                        break;
                }
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
                switch (pan2.y)
                {
                    case 63.20197f:
                        pan2.z = 2;
                        break;
                    case -156.6379f: //Team 3
                        pan2.z = 3;
                        break;
                    case -377.4504f:
                        pan2.z = 4;
                        break;
                }
                switch (pan3.y)
                {
                    case 63.20197f:
                        pan3.z = 2;
                        break;
                    case -156.6379f: //Team 3
                        pan3.z = 3;
                        break;
                    case -377.4504f:
                        pan3.z = 4;
                        break;
                }
                switch (pan4.y)
                {
                    case 63.20197f:
                        pan4.z = 2;
                        break;
                    case -156.6379f: //Team 3
                        pan4.z = 3;
                        break;
                    case -377.4504f:
                        pan4.z = 4;
                        break;
                }
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
        
    }
}
