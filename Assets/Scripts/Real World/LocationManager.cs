using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject worldManagerSpawner;
    public WorldManager wm;
    public GameObject[] npcsInArea;
    private GameObject[] crowdSpawns;
    [SerializeField]
    private float[] crowdSpawnTimers;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < crowdSpawnTimers.Length; i++)
        {
            crowdSpawnTimers[i] = Random.Range(0, 7);
        }
        if (!GameObject.Find("World Manager"))
        {
            GameObject t = Instantiate(worldManagerSpawner);
            t.name = "World Manager";
        }
        wm = GameObject.Find("World Manager").GetComponent<WorldManager>();

        foreach(GameObject i in npcsInArea)
        {
            bondCharacterInfo c = i.GetComponent<bondCharacterInfo>();
            bool t = c.canSpawn(wm.dayName);
            if (t)
                c.spawnChar();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < crowdSpawnTimers.Length; i++)
        {
            crowdSpawnTimers[i] += Time.deltaTime;
            if(crowdSpawnTimers[i] >= 7)
            {
                //spawn group of NPCs
                crowdSpawnTimers[i] = 0;
            }
        }
    }
}
