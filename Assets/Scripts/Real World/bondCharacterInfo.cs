using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bondCharacterInfo : MonoBehaviour
{
    public string charName;
    public bool[] availability = new bool[7];       //Whether or not the character can spawn on the given day
    private Vector3 spawningLocation, spawningRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool canSpawn(WorldManager.daysOfWeek day)
    {
        int i = 0;
        switch (day)
        {
            case WorldManager.daysOfWeek.Monday:
                i = 0;
                break;
            case WorldManager.daysOfWeek.Tuesday:
                i = 1;
                break;
            case WorldManager.daysOfWeek.Wednesday:
                i = 2;
                break;
            case WorldManager.daysOfWeek.Thursday:
                i = 3;
                break;
            case WorldManager.daysOfWeek.Friday:
                i = 4;
                break;
            case WorldManager.daysOfWeek.Saturday:
                i = 5;
                break;
            case WorldManager.daysOfWeek.Sunday:
                i = 6;
                break;
        }
        return availability[i];
    }

    public bool canSpawn(WorldManager.daysOfWeek day, int a)        //This will make certain criteria force someone to not spawn, like not spawning on exam days and stuff
    {
        return false;
    }

    public void spawnChar()
    {
        Instantiate(gameObject, spawningLocation, Quaternion.Euler(spawningRotation));
    }
}
