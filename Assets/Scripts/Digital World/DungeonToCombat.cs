using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonToCombat : MonoBehaviour
{
    public void toCombat()          //May need to be changed later to reflect multiplaer
    {
        SceneManager.LoadScene("Combat", LoadSceneMode.Additive);
        Scene scene = SceneManager.GetSceneByName("Combat");
        scene.name = "CombatOG";
        //SceneManager.LoadScene("Combat", LoadSceneMode.Additive);
        
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Combat"));
        SceneManager.UnloadSceneAsync("Gameplay");
    }
}
