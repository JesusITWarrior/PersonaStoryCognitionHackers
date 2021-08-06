using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


//TODO: Implement multiplayer using Clientside rendering for the battle.

//public enum BattleState { START, PLAYER1TURN, PLAYER2TURN, PLAYER3TURN, PLAYER4TURN, ENEMY1TURN, ENEMY2TURN, ENEMY3TURN, ENEMY4TURN, WON, LOST }

public class BattleSystem : MonoBehaviour {
    //NOTE: Use the party's stats for any damage calcuation and whatnot, and use the Game Object Instantiated to deal with animations and whatnot
    //TODO: Ensure that communication between server and client is taken into account
    //TODO: Change from MonoBehaviour to NetworkBehaviour
    //TODO: Make changes from this BattleSystem and modify them for NetworkBehaviour in the DefaultBattleManager program

    public BattleState state;

    public GameObject Circle;
    public GameObject APanel, TPanel, AtPanel, PPanel, IPanel;
    public Party party;       
    

    public GameObject Nex, Coco, Keese, Reiko;
    public GameObject enemyPrefab1, enemyPrefab2, enemyPrefab3, enemyPrefab4, enemyPrefab5;


    public AudioSource Select;
    public AudioSource Normal, Ambushed, BG;
    public AudioSource victory, defeat;
    public AudioSource Error;

    public Player playerUnit, playerUnit1, playerUnit2, playerUnit3;
    public static Unit enemyUnit, enemyUnit1, enemyUnit2, enemyUnit3;         //Unit is the script being run for enemies
    private GameObject enemyGO, enemyGO1, enemyGO2, enemyGO3;
    private GameObject playerGO, playerGO1, playerGO2, playerGO3;

    public static bool callback = false;
    public int advantage;
    private int who=0;
    int partyNum=0;

    System.Random rand = new System.Random();

    void Start () {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
	}

    IEnumerator SetupBattle() {
        if (advantage == -1)
        {
            BG = Instantiate(Ambushed);         //TODO: Fix delay issue with looper. Disadvan. has problem with waiting
            BG.PlayDelayed(1);
        }else
        {
            BG = Instantiate(Normal);
            BG.PlayDelayed(1);
        }
        #region Enemy Spawner
        int howMany = rand.Next(1,5);
        int[] which = {0,0,0,0};
        for (int i=0; i < howMany; i++) //Assigns how many enemies and which enemies are spawned
        {
            which[i] = rand.Next(1, 6);
        }
        int holder;
        for (int i=0; i < which.Length-1; i++) //Sorts the null enemies to the end of the which array
        {
            for (int j = 0; j < which.Length - 1; j++)
            {
                if (which[j] < which[j + 1])
                {
                    holder = which[j];
                    which[j] = which[j + 1];
                    which[j + 1] = holder;
                }
            }
        }
        switch (which[0])
        {
            case 1:
                {
                    enemyGO = Instantiate(enemyPrefab1, new Vector3(-0.5f, 0, -3.3599999f), Quaternion.identity);
                    enemyUnit = enemyGO.GetComponent<Unit>();
                    enemyGO.SetActive(true);
                    enemyUnit.EC.Look(who);
                break; }
            case 2:
                {
                    enemyGO = Instantiate(enemyPrefab2, new Vector3(-0.5f, 0, -3.3599999f), Quaternion.identity);
                    enemyUnit = enemyGO.GetComponent<Unit>();
                    enemyGO.SetActive(true);
                    enemyUnit.EC.Look(who);
                    break;
                }
            case 3:
                {
                    enemyGO = Instantiate(enemyPrefab3, new Vector3(-0.5f, 0, -3.3599999f), Quaternion.identity);
                    enemyUnit = enemyGO.GetComponent<Unit>();
                    enemyGO.SetActive(true);
                    enemyUnit.EC.Look(who);
                    break;
                }
            case 4:
                {
                    enemyGO = Instantiate(enemyPrefab4, new Vector3(-0.5f, 0, -3.3599999f), Quaternion.identity);
                    enemyUnit = enemyGO.GetComponent<Unit>();
                    enemyGO.SetActive(true);
                    enemyUnit.EC.Look(who);
                    break;
                }
            case 5:
                {
                    enemyGO = Instantiate(enemyPrefab5, new Vector3(-0.5f, 0, -3.3599999f), Quaternion.identity);
                    enemyUnit = enemyGO.GetComponent<Unit>();
                    enemyGO.SetActive(true);
                    enemyUnit.EC.Look(who);
                    break;
                }
            default:
                enemyUnit = null;
                break;
        }
        switch (which[1])
        {
            case 1:
                {
                    enemyGO1 = Instantiate(enemyPrefab1, new Vector3(-1.903f, 0, -0.49f), Quaternion.identity);
                    enemyUnit1 = enemyGO1.GetComponent<Unit>();
                    enemyGO1.SetActive(true);
                    enemyUnit1.EC.Look(who);
                    break;
                }
            case 2:
                {
                    enemyGO1 = Instantiate(enemyPrefab2, new Vector3(-1.903f, 0, -0.49f), Quaternion.identity);
                    enemyUnit1 = enemyGO1.GetComponent<Unit>();
                    enemyGO1.SetActive(true);
                    enemyUnit1.EC.Look(who);
                    break;
                }
            case 3:
                {
                    enemyGO1 = Instantiate(enemyPrefab3, new Vector3(-1.903f, 0, -0.49f), Quaternion.identity);
                    enemyUnit1 = enemyGO1.GetComponent<Unit>();
                    enemyGO1.SetActive(true);
                    enemyUnit1.EC.Look(who);
                    break;
                }
            case 4:
                {
                    enemyGO1 = Instantiate(enemyPrefab4, new Vector3(-1.903f, 0, -0.49f), Quaternion.identity);
                    enemyUnit1 = enemyGO1.GetComponent<Unit>();
                    enemyGO1.SetActive(true);
                    enemyUnit1.EC.Look(who);
                    break;
                }
            case 5:
                {
                    enemyGO1 = Instantiate(enemyPrefab5, new Vector3(-1.903f, 0, -0.49f), Quaternion.identity);
                    enemyUnit1 = enemyGO1.GetComponent<Unit>();
                    enemyGO1.SetActive(true);
                    enemyUnit1.EC.Look(who);
                    break;
                }
            default:
                enemyUnit1 = null;
                break;
        }
        switch (which[2]) {
            case 1:
                {
                    enemyGO2 = Instantiate(enemyPrefab1, new Vector3(1.75f, 0, -2.04f), Quaternion.identity);
                    enemyUnit2 = enemyGO2.GetComponent<Unit>();
                    enemyGO2.SetActive(true);
                    enemyUnit2.EC.Look(who);
                    break;
                }
            case 2:
                {
                    enemyGO2 = Instantiate(enemyPrefab2, new Vector3(1.75f, 0, -2.04f), Quaternion.identity);
                    enemyUnit2 = enemyGO2.GetComponent<Unit>();
                    enemyGO2.SetActive(true);
                    enemyUnit2.EC.Look(who);
                    break;
                }
            case 3:
                {
                    enemyGO2 = Instantiate(enemyPrefab3, new Vector3(1.75f, 0, -2.04f), Quaternion.identity);
                    enemyUnit2 = enemyGO2.GetComponent<Unit>();
                    enemyGO2.SetActive(true);
                    enemyUnit2.EC.Look(who);
                    break;
                }
            case 4:
                {
                    enemyGO2 = Instantiate(enemyPrefab4, new Vector3(1.75f, 0, -2.04f), Quaternion.identity);
                    enemyUnit2 = enemyGO2.GetComponent<Unit>();
                    enemyGO2.SetActive(true);
                    enemyUnit2.EC.Look(who);
                    break;
                }
            case 5:
                {
                    enemyGO2 = Instantiate(enemyPrefab5, new Vector3(1.75f, 0, -2.04f), Quaternion.identity);
                    enemyUnit2 = enemyGO2.GetComponent<Unit>();
                    enemyGO2.SetActive(true);
                    enemyUnit2.EC.Look(who);
                    break;
                }
            default:
                enemyUnit2 = null;
                break;
        }
        switch (which[3])
        {
            case 1:
                {
                    enemyGO3 = Instantiate(enemyPrefab1, new Vector3(0.35f, 0, 0.79f), Quaternion.identity);
                    enemyUnit3 = enemyGO3.GetComponent<Unit>();
                    enemyGO3.SetActive(true);
                    enemyUnit3.EC.Look(who);
                    break;
                }
            case 2:
                {
                    enemyGO3 = Instantiate(enemyPrefab2, new Vector3(0.35f, 0, 0.79f), Quaternion.identity);
                    enemyUnit3 = enemyGO3.GetComponent<Unit>();
                    enemyGO3.SetActive(true);
                    enemyUnit3.EC.Look(who);
                    break;
                }
            case 3:
                {
                    enemyGO3 = Instantiate(enemyPrefab3, new Vector3(0.35f, 0, 0.79f), Quaternion.identity);
                    enemyUnit3 = enemyGO3.GetComponent<Unit>();
                    enemyGO3.SetActive(true);
                    enemyUnit3.EC.Look(who);
                    break;
                }
            case 4:
                {
                    GameObject enemyGO3 = Instantiate(enemyPrefab4, new Vector3(0.35f, 0, 0.79f), Quaternion.identity);
                    enemyUnit3 = enemyGO3.GetComponent<Unit>();
                    enemyGO3.SetActive(true);
                    enemyUnit3.EC.Look(who);
                    break;
                }
            case 5:
                {
                    enemyGO3 = Instantiate(enemyPrefab5, new Vector3(0.35f, 0, 0.79f), Quaternion.identity);
                    enemyUnit3 = enemyGO3.GetComponent<Unit>();
                    enemyGO3.SetActive(true);
                    enemyUnit3.EC.Look(who);
                    break;
                }
            default:
                enemyUnit3 = null;
                break;
        }
        #endregion
        party = GameObject.Find("Party").GetComponent<Party>();         //Makes the party an actual interactable thing
        #region Party Spawner
        int n = party.getPartyNum();        //Remember to set leader's triggeredCombat to true during the exploration part
        partyNum = n;
        if (advantage != -1) {
            for (int i = 0; i < party.parties[n].Count; i++)
            {
                switch (i) {
                    case 0:
                        {
                            playerGO = Instantiate(party.parties[n][i], new Vector3(0.22f, 0, -7.122f), Quaternion.identity); //player1
                            playerUnit = playerGO.GetComponent<Player>();   //TODO: Fix playerSpawns later
                            playerUnit.PCC.LookBattleTurn(1);
                            break;
                        }
                    case 1:         //Player 2 Camera needs to be implemented at 8.91 0.32 -2.71 with rotation 11.552, -82, 0 with FOV of 40
                        {
                            playerGO1 = Instantiate(party.parties[n][i], new Vector3(5.962f, 0, -1.318f), Quaternion.identity);   //Need to test and implement positioning later
                            playerUnit1 = playerGO1.GetComponent<Player>();   //TODO: Fix playerSpawns later

                            playerUnit1.PCC.LookBattleTurn(2);
                            break;
                        }
                    case 2:         //Player 3 Camera needs to be implemented at 0.1812 0.32 7.4736 with rotation 11.552 185 0
                        {

                            playerGO2 = Instantiate(party.parties[n][i], new Vector3(-0.74f, 0, 4.58f), Quaternion.identity);   //Need to test and implement positioning later
                            playerUnit2 = playerGO2.GetComponent<Player>();   //TODO: Fix playerSpawns later

                            playerUnit2.PCC.LookBattleTurn(3);
                            break;
                        }
                    case 3:
                        {

                            playerGO3 = Instantiate(party.parties[n][i], new Vector3(-6.05f, 0, -1.78f), Quaternion.identity);   //Need to test and implement positioning later
                            playerUnit3 = playerGO3.GetComponent<Player>();   //TODO: Fix playerSpawns later

                            playerUnit3.PCC.LookBattleTurn(4);
                            break;
                        } 
                     default:
                    switch (i)
                        {
                            case 1:
                                playerUnit1 = null; playerUnit2 = null; playerUnit3 = null;
                                break;
                            case 2:
                                playerUnit2 = null; playerUnit3 = null;
                                break;
                            case 3:
                                playerUnit3 = null;
                                break;
                            default:
                                throw new Exception("Tried to start a battle without a leader or party members");
                        }
                        break;
                }
            }
        }
        else {
            //Update spawning to have players be surrounded
            for (int i = 0; i < party.parties[n].Count; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            playerGO = Instantiate(party.parties[n][i], new Vector3(0.22f, 0, -7.122f), Quaternion.identity); //player1
                            playerUnit = playerGO.GetComponent<Player>();   //TODO: Fix playerSpawns later
                            playerUnit.PCC.LookBattleTurn(1);
                            break;
                        }
                    case 1:         //Player 2 Camera needs to be implemented at 8.91 0.32 -2.71 with rotation 11.552, -82, 0 with FOV of 40
                        {
                            playerGO1 = Instantiate(party.parties[n][i], new Vector3(5.962f, 0, -1.318f), Quaternion.identity);   //Need to test and implement positioning later
                            playerUnit1 = playerGO1.GetComponent<Player>();   //TODO: Fix playerSpawns later

                            playerUnit1.PCC.LookBattleTurn(2);
                            break;
                        }
                    case 2:         //Player 3 Camera needs to be implemented at 0.1812 0.32 7.4736 with rotation 11.552 185 0
                        {

                            playerGO2 = Instantiate(party.parties[n][i], new Vector3(-0.74f, 0, 4.58f), Quaternion.identity);   //Need to test and implement positioning later
                            playerUnit2 = playerGO2.GetComponent<Player>();   //TODO: Fix playerSpawns later

                            playerUnit2.PCC.LookBattleTurn(3);
                            break;
                        }
                    case 3:
                        {

                            playerGO3 = Instantiate(party.parties[n][i], new Vector3(-6.05f, 0, -1.78f), Quaternion.identity);   //Need to test and implement positioning later
                            playerUnit3 = playerGO3.GetComponent<Player>();   //TODO: Fix playerSpawns later

                            playerUnit3.PCC.LookBattleTurn(4);
                            break;
                        }
                    default:
                        switch (i)
                        {
                            case 1:
                                playerUnit1 = null; playerUnit2 = null; playerUnit3 = null;
                                break;
                            case 2:
                                playerUnit2 = null; playerUnit3 = null;
                                break;
                            case 3:
                                playerUnit3 = null;
                                break;
                            default:
                                throw new Exception("Tried to start a battle without a leader or party members");
                        }
                        break;
                }
            }
        }
        #endregion

        //TODO Add enemy spawning animation
        //TODO: Add allies running up on enemies, or getting up from being knocked down

        yield return new WaitForSeconds(2);     //This allows the setup of the battle, then makes us wait 2 seconds. Should be replaced with either players getting up, or running in animation depending on advantage
        nextTurn();
    }

    public void PlayerTurn() {
        #region Setting Up Turn
        if (enemyUnit)
            enemyUnit.EC.Look(who);
        if (enemyUnit1)
            enemyUnit1.EC.Look(who);
        if (enemyUnit2)
            enemyUnit2.EC.Look(who);
        if (enemyUnit3)
            enemyUnit3.EC.Look(who);
        
        if (callback)
            callback = false;
        else {
            int ailment;
            switch(who){
                case 1:
                    ailment = playerUnit.AilmentChecker();
                    if (playerUnit.isDown)
                    {
                        //Play animation for standing up
                        playerUnit.isDown = false;
                    }
                    //TODO: Implement all ailment checks here as cases
                    break;
                case 2:
                    ailment = playerUnit1.AilmentChecker();
                    if (playerUnit1.isDown)
                    {
                        //Play animation for standing up
                        playerUnit1.isDown = false;
                    }
                    break;
                case 3:
                    ailment = playerUnit2.AilmentChecker();
                    if (playerUnit2.isDown)
                    {
                        //Play animation for standing up
                        playerUnit2.isDown = false;
                    }
                    break;
                case 4:
                    ailment = playerUnit3.AilmentChecker();
                    if (playerUnit3.isDown)
                    {
                        //Play animation for standing up
                        playerUnit3.isDown = false;
                    }
                    break;
                default:
                    throw new Exception("Player Turn initiated without it being player turn");
            }
            #endregion
            Circle.SetActive(true);
            //TODO: Lock the action to whoever's turn it is
        }
       
        
    }

    public void OnPhysicalAttack() {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();

        AtPanel.SetActive(false);
        //StartCoroutine(Targetting());
        //StartCoroutine(PlayerAttack(0));
    }

    /*public IEnumerator Targetting()
    {
        //Test Code
        yield return new WaitUntil(targetsSelected);
    }*/

    public void OnGunAttack()
    {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();

        AtPanel.SetActive(false);
        StartCoroutine(PlayerAttack(1));
    }

    //Applies guarding effect, need to apply it to whoever is guarding
    public void OnGuard() {
        Circle.SetActive(false);
        switch (who)
        {
            case 1:
                playerUnit.guard = true;
                break;
            case 2:
                playerUnit1.guard = true;
                break;
            case 3:
                playerUnit2.guard = true;
                break;
            case 4:
                playerUnit3.guard = true;
                break;
    }
        nextTurn();
    }

    public void magicChecker(int power, int type, bool isMagic, Spells skill)
    {
        if (isMagic)
        {
            if (playerUnit.getSP() < skill.cost)
            {
                //checks SP cost to current SP
                Error.Play();
                //Print not enough SP
                callback = true;
                PlayerTurn();
            }
            else
            {
                // Get the game object by finding our Select audio object
                Select.Play();
                playerUnit.magicCast(skill.cost);
                PPanel.SetActive(false);
                StartCoroutine(playerMagicAttack(power, type));   //Adjust
            }
        }
        else if (!isMagic)
        {
            Player var = new Player();

            if (playerUnit.getHealth() < (int)(playerUnit.getMaxHealth() * (float)(skill.cost / 100)))
            { //Checks HP cost to current HP
                Error.Play();
                //Print not enough HP
                callback = true;
                PlayerTurn();
            }
            else
            {
                Select.Play();
                playerUnit.physCast(skill.cost);
                GameObject goPanel = GameObject.Find("PersonaMenu");
                goPanel.SetActive(false); // already a game object
                StartCoroutine(playerMagicAttack(power, type));   //Adjust
            }
        }

    }

    public void OnItemUse(int item) {
        IPanel.SetActive(false);
        //Write in code for Item use
    }

    IEnumerator playerMagicAttack(int power, int type) {
        yield return new WaitForSeconds(2);
        float damage = playerMagicDamageCalculator(power, type);
        int enemyDamaged = enemyUnit.TakeDamage(damage, type);      //need to change target
        //enemyDamage.SetActive(true);
        //enemyDamage.text = damage.ToString();
        switch (enemyDamaged)
        {
            case 0: //enemy is dead and was not knocked down
                //Destroy(enemyUnit);
                //yield return new WaitForSeconds(1);
                //enemyDamage.SetActive(false);
                //yield return new WaitForSeconds(2);

                state = BattleState.WON;
                EndBattle();
                
                break;
            case 2: //weak or crit
                if (enemyUnit.ailment != 1)
                {
                    enemyUnit.ailment = 1;
                    //yield return new WaitForSeconds(2);
                    //enemyDamage.SetActive(false);
                    oneMore();
                    break;
                }
                else
                    //yield return new WaitForSeconds(1);
                    //enemyDamage.SetActive(false);
                    nextTurn();
                    break;
            case 3: //reflect
                int playerDamaged = playerUnit.TakeDamage(damage, type);
                //yield return new WaitForSeconds(1);
                //Implement player damage or heal
                nextTurn();
                break;
            case 4: //enemy died and was knocked down
                oneMore();

                break;
            default:
                //yield return new WaitForSeconds(2);
                nextTurn();
                break;
        }
    }
    IEnumerator PlayerAttack(int type)
    {
        yield return new WaitForSeconds(2);
        float damage = playerDamageCalculator();
        int enemyDamaged = enemyUnit.TakeDamage(damage, type);
        //Enemy HP bar changes
        switch (enemyDamaged) {
            case 0: //enemy is dead
                //Destroy(enemyUnit);
                //yield return new WaitForSeconds(2);
                state = BattleState.WON;
                EndBattle();
                break;
            case 2: //weak or crit
                if (enemyUnit.ailment != 1)
                {
                    enemyUnit.ailment = 1;
                    oneMore();
                    break;
                }
                else
                {
                    nextTurn();
                    break;
                }
            case 3: //reflect
                int playerDamaged = playerUnit.TakeDamage(damage, type);
                yield return new WaitForSeconds(1);
                nextTurn();
                break;
            case 4:
                oneMore();
                break;
            default:
                //yield return new WaitForSeconds(2);
                nextTurn();
                break;
        }
    }


    IEnumerator EnemyTurn() {
        yield return new WaitForSeconds(1);
        int ailment = enemyUnit.AilmentChecker();
        switch (ailment) {
            case 1:
                enemyUnit.AilmentClear();
                yield return new WaitForSeconds(1);
                break;
        }
        
        StartCoroutine(EnemyAttack());
    }
    IEnumerator EnemyAttack() {
        int rng = 4; //random.Random(0,10);   //For testing damage types, will be used eventually for selecting people and abilities
        int pRng = 0;
        while (true)
        {
            pRng = rand.Next(0, party.parties[partyNum].Count);
            if (!party.parties[partyNum][pRng].GetComponent<Player>().unconscious)
            {
                break;
            }
            
        }
        //Need to add reference to enemy's skill here to add to the enemyDamageCalculator
        int playerDamageResult = 0;
        float damage = enemyDamageCalculator(party.parties[partyNum][pRng].GetComponent<Player>());
        playerDamageResult = party.parties[partyNum][pRng].GetComponent<Player>().TakeDamage(damage,rng);
        playerUnit = party.parties[partyNum][0].GetComponent<Player>();
        Debug.Log("Enemy attacks " +party.parties[partyNum][pRng].GetComponent<Player>().name+ " and deals "+damage+" damage");
        
        //Player HP Bar changes
        switch(playerDamageResult){
            case 0:
                if ((playerUnit.unconscious||!playerUnit) && (playerUnit1.unconscious||!playerUnit1) && (playerUnit2.unconscious||!playerUnit2) && (playerUnit3.unconscious||!playerUnit3))
                {
                    yield return new WaitForSeconds(2);
                    state = BattleState.LOST;
                    EndBattle();
                }
                else
                    nextTurn();
                break;
            
            case 3:
                int enemyDamageResult = 0;
                switch (who)
                {
                    case 5:
                        enemyDamageResult = enemyUnit.TakeDamage(damage, rng);
                        break;
                    case 6:
                        enemyDamageResult = enemyUnit1.TakeDamage(damage, rng);
                        break;
                    case 7:
                        enemyDamageResult = enemyUnit2.TakeDamage(damage, rng);
                        break;
                    case 8:
                        enemyDamageResult = enemyUnit3.TakeDamage(damage, rng);
                        break;
                }

                //Enemy HP Bar Changes
                if (enemyDamageResult == 0)
                {
                    //Destroy(enemyUnit);
                    state = BattleState.WON;
                    EndBattle();
                }
                else
                {
                    nextTurn();
                }
                break;
            case 4:
                if ((playerUnit.unconscious || !playerUnit) && (playerUnit1.unconscious || !playerUnit1) && (playerUnit2.unconscious || !playerUnit2) && (playerUnit3.unconscious || !playerUnit3))
                {
                    yield return new WaitForSeconds(2);
                    state = BattleState.LOST;
                    LostBattle();
                }
                else
                    oneMore();
                break;

            default:
                nextTurn();
                break;
        }
    }

    //TODO: fix this to not be specific to a single player and/or enemy
    //TODO: implement gun stat here instead of *just* melee weapon
    float playerDamageCalculator() {
        float damage;
        damage = (float)(playerUnit.weapon * Math.Sqrt(playerUnit.str));
        damage = damage / (float)(Math.Sqrt((enemyUnit.shadow.en * 8))) + (float)(0.5);
        //TODO: insert random 5% variance to damage
        return damage;
    }

    float playerMagicDamageCalculator(int power, int type) {
        float damage = 0;
        switch (type) {
            case 0: case 1:
                damage = (float)(power * Math.Sqrt(playerUnit.str));        //For gun and phys damage
                break;
            case 2: case 3: case 4: case 5: case 6: case 7: case 8: case 9:
                damage = (float)(power + (power * (float)(playerUnit.mag / 30)));   //For magic damage
                int getAilment = ailmentCalculator(type);
                if (getAilment != 0)
                    enemyUnit.ailment = getAilment;
                break;
        }
        damage = damage / (float)(Math.Sqrt((enemyUnit.shadow.en * 8))) + (float)(0.5);
        return damage;
    }

    public int ailmentCalculator(int type) {
        //Fill this in later
        return 0;
    }
    float enemyDamageCalculator(Player player) {
        float damage = 5;
        if (player.guard)
        {
            damage = damage / 2;
            player.guard = false;   //Implement into Enemy damage calculator
        }
        return damage;
    }
    void nextTurn()
    {
        switch (advantage) 
        {
            case -1: //Enemy Ambush or Disadvantage, all enemies go first, then returns to normal battle mode
                switch (who)
                {
                    case 0:
                        if (enemyUnit)
                        {
                            who = 5;
                            state = BattleState.ENEMY1TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (enemyUnit1)
                        {
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (enemyUnit2)
                        {
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (enemyUnit3)
                        {
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else { advantage = 0; who = 0; state = BattleState.PLAYER1TURN;
                            nextTurn();
                        }
                        break;
                    case 5:
                        if (enemyUnit1)
                        {
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (enemyUnit2)
                        {
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (enemyUnit3)
                        {
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else
                        {
                            advantage = 0; who = 0; state = BattleState.PLAYER1TURN;
                            nextTurn();
                        }
                        break;
                    case 6:
                        if (enemyUnit2)
                        {
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (enemyUnit3)
                        {
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else
                        {
                            advantage = 0; who = 0; state = BattleState.PLAYER1TURN;
                            nextTurn();
                        }
                        break;
                    case 7:
                        if (enemyUnit3)
                        {
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else
                        {
                            advantage = 0; who = 0; state = BattleState.PLAYER1TURN;
                            nextTurn();
                        }
                        break;
                    case 8:
                        advantage = 0;
                        who = 0;
                        nextTurn();
                        break;
                }
                break;
            case 0: //Normal Battle Mode
                switch (who)
                {
                    case 0: //Makes sure a player starts first
                        if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn();
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn();
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn();
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn();
                        }
                        else { }    //Something bad happened if this is triggered
                        break;
                    case 1: //Next turn should be an enemy after the "leader", but can be a player if the "enemy" died
                        if (enemyUnit)
                        {
                            who = 5;
                            state = BattleState.ENEMY1TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit1)
                        {
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit2)
                        {
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit3)
                        {
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else { }
                        break;
                    case 5: 
                        if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit1)
                        {
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit2)
                        {
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit3)
                        {
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn();
                        }
                        else { }
                        break;
                    case 2:
                        if (enemyUnit1)
                        {
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit2)
                        {
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit3)
                        {
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit)
                        {
                            who = 5;
                            state = BattleState.ENEMY1TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else { }
                        break;
                    case 6:
                        if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit2)
                        {
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit3)
                        {
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit)
                        {
                            who = 5;
                            state = BattleState.ENEMY1TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn();
                        }
                        else { }
                        break;
                    case 3:
                        if (enemyUnit2)
                        {
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit3)
                        {
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit)
                        {
                            who = 5;
                            state = BattleState.ENEMY1TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit1)
                        {
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else { }
                        break;
                    case 7:
                        if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit3)
                        {
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit)
                        {
                            who = 5;
                            state = BattleState.ENEMY1TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit1)
                        {
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn();
                        }
                        else { }
                        break;
                    case 4:
                        if (enemyUnit3)
                        {
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit)
                        {
                            who = 5;
                            state = BattleState.ENEMY1TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit1)
                        {
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit2)
                        {
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else { }
                        break;
                    case 8:
                        if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit)
                        {
                            who = 5;
                            state = BattleState.ENEMY1TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit1)
                        {
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn();
                        }
                        else if (enemyUnit2)
                        {
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn();
                        }
                        else { }
                        break;
                }
                break;
            case 1: //Ambush or Advantage attack, all players go first, then returns to normal battle mode
                switch (who)    //Adjust last cases to reflect logical turn
                {
                    case 0:
                        if (playerUnit) {
                            who = 1;
                            state = BattleState.PLAYER1TURN;
                            PlayerTurn();
                        } else if (playerUnit1)
                        {
                            who = 2;
                            state = BattleState.PLAYER2TURN;
                            PlayerTurn();
                        } else if (playerUnit2)
                        {
                            who = 3;
                            state = BattleState.PLAYER3TURN;
                            PlayerTurn();
                        } else if (playerUnit3)
                        {
                            who = 4;
                            state = BattleState.PLAYER4TURN;
                            PlayerTurn();
                        }
                        else { advantage = 0; who = 0; state = BattleState.PLAYER1TURN;
                            nextTurn();
                        }
                        break;
                    case 1:
                        if (playerUnit1)
                        {
                            who = 2;
                            state = BattleState.PLAYER2TURN;
                            PlayerTurn();
                        }
                        else if (playerUnit2)
                        {
                            who = 3;
                            state = BattleState.PLAYER3TURN;
                            PlayerTurn();
                        }
                        else if (playerUnit3)
                        {
                            who = 4;
                            state = BattleState.PLAYER4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else { advantage = 0; who = 0; state = BattleState.PLAYER1TURN;
                            nextTurn();
                        }
                        break;
                    case 2:
                        if (playerUnit2)
                        {
                            who = 3;
                            state = BattleState.PLAYER2TURN;
                            PlayerTurn();
                        }
                        else if (playerUnit3)
                        {
                            who = 4;
                            state = BattleState.PLAYER3TURN;
                            PlayerTurn();
                        }
                        else { advantage = 0; who = 0; state = BattleState.PLAYER1TURN;
                            nextTurn();
                        }
                        break;
                    case 3:
                        if (playerUnit3)
                        {
                            who = 4;
                            state = BattleState.PLAYER3TURN;
                            PlayerTurn();
                        }
                        else { advantage = 0; who = 0; state = BattleState.PLAYER1TURN;
                            nextTurn();
                        }
                        break;
                    case 4:
                        advantage = 0;
                        who = 0;
                        state = BattleState.PLAYER1TURN;
                        nextTurn();
                        break;
                }
                break;
        }
    }

    private void p1Turn()
    {
        who = 1;
        state = BattleState.PLAYER1TURN;
        playerUnit.guard = false;
    }

    private void p2Turn()
    {
        who = 2;
        state = BattleState.PLAYER2TURN;
        playerUnit1.guard = false;
    }

    private void p3Turn()
    {
        who = 3;
        state = BattleState.PLAYER3TURN;
        playerUnit2.guard = false;
    }

    private void p4Turn()
    {
        who = 4;
        state = BattleState.PLAYER4TURN;
        playerUnit3.guard = false;
    }

    public void oneMore()
    {
        switch (who)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                //Show friendly 1 more
                PlayerTurn();
                break;
            case 5:
            case 6:
            case 7:
            case 8:
                //Show enemy 1 more
                StartCoroutine(EnemyTurn());
                break;
        }
    }

    void EndBattle() {
        BG.Stop();
        Instantiate(victory);
        victory.Play();
    }
    void LostBattle()
    {
        BG.Stop();
        Instantiate(defeat);
        Debug.Log("You lost!");
        defeat.Play();
    }
}
