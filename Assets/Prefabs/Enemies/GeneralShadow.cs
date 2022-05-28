using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralShadow : MonoBehaviour
{
    public bool[] partiesSeen;
    private Party party;
    // Start is called before the first frame update
    void Start()
    {
        party = GameObject.Find("Party").GetComponent<Party>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool sawPartyAnalyzer(string name)
    {
        for (int i = 0; i < party.parties.Count;i++)
        {
            if (party.parties[i][0].GetComponent<Persona>().name == name)
                return partiesSeen[i];
        }
        return false;
    }

    private void sawPartyReport()
    {
        /*
         * If seen party, set associated array to true
         * If not seen party, set associated array to false
         */
    }
}
