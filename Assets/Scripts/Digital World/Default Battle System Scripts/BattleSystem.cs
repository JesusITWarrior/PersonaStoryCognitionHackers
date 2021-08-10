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
    //TODO: Add Cinemachine functionality, switching between which game object to focus on depending on situation
    //SUGGESTION: Add some handheld Perlin noise to make the camera seem a bit more dynamic.... maybe when the player's health gets low or something

    public BattleState state;

    public GameObject Circle;
    public GameObject APanel, TPanel, AtPanel, PPanel, IPanel;
    public Party party;
    

    //public GameObject Nex, Coco, Keese, Reiko;
    public GameObject enemyPrefab1, enemyPrefab2, enemyPrefab3, enemyPrefab4, enemyPrefab5;


    public AudioSource Select;
    public AudioSource Normal, Ambushed, BG;
    public AudioSource victory, defeat;
    public AudioSource Error;
    public CinemachineCombatHandler cinema;

    public Player playerUnit, playerUnit1, playerUnit2, playerUnit3;
    public static Unit enemyUnit, enemyUnit1, enemyUnit2, enemyUnit3;         //Unit is the script being run for enemies
    private GameObject enemyGO, enemyGO1, enemyGO2, enemyGO3;
    private GameObject playerGO, playerGO1, playerGO2, playerGO3;
    [SerializeField]
    private Transform p1Look, p2Look, p3Look, p4Look;

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
                            playerGO = Instantiate(party.parties[n][i], new Vector3(0.22f, 0, -11.10f), Quaternion.identity); //player1
                            playerUnit = playerGO.GetComponent<Player>();   //TODO: Fix playerSpawns later
                            playerUnit.PCC.LookBattleTurn(1);
                            playerUnit.PCC.returnToSpawn(1);
                            break;
                        }
                    case 1:         //Player 2 Camera needs to be implemented at 8.91 0.32 -2.71 with rotation 11.552, -82, 0 with FOV of 40
                        {
                            playerGO1 = Instantiate(party.parties[n][i], new Vector3(8.52f, 0, -1.32f), Quaternion.identity);   
                            playerUnit1 = playerGO1.GetComponent<Player>();   
                            playerUnit1.PCC.LookBattleTurn(2);
                            playerUnit1.PCC.returnToSpawn(2);
                            break;
                        }
                    case 2:         //Player 3 Camera needs to be implemented at 0.1812 0.32 7.4736 with rotation 11.552 185 0
                        {

                            playerGO2 = Instantiate(party.parties[n][i], new Vector3(-0.74f, 0, 7.29f), Quaternion.identity);
                            playerUnit2 = playerGO2.GetComponent<Player>();
                            playerUnit2.PCC.LookBattleTurn(3);
                            playerUnit2.PCC.returnToSpawn(3);
                            break;
                        }
                    case 3:
                        {

                            playerGO3 = Instantiate(party.parties[n][i], new Vector3(-8.28f, 0, -1.78f), Quaternion.identity);
                            playerUnit3 = playerGO3.GetComponent<Player>();
                            playerUnit3.PCC.LookBattleTurn(4);
                            playerUnit3.PCC.returnToSpawn(4);
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
                                throw new Exception("Tried to start a battle without a leader and party members");
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
        cinema.lookTarget(state, 1, p1Look);
        //TODO Add enemy spawning animation
        //TODO: Add getting up from being knocked down animation from disadvantage
        //TODO: Add very brief pause between enemy spawn animation and players running up, perhaps altering the players' alpha level as well to seem as if they are running in
        cinema.moveDolly(1, 0, 1);
        yield return new WaitForSeconds(2);     //This allows the setup of the battle, then makes us wait 2 seconds.
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
            Player p = getPlayer();
            ailment = p.AilmentChecker();
            if (p.isDown)
            {
                //TODO: Play animation for standing up
                p.isDown = false;
            }
            //TODO: Implement all ailment checks here as cases
            if ((float)(p.getHealth() / p.getMaxHealth() * 100) <= 25)
            {
                //TODO: Play injured animation
                //cinema.startPerlin(); //TODO: Run Perlin check for injured player with previous code
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
        StartCoroutine(PlayerAttack());
    }

    //Applies guarding effect, need to apply it to whoever is guarding
    public void OnGuard() {
        Circle.SetActive(false);
        GameObject p = getPlayerObject();
        p.GetComponent<Player>().guard = true;
        //TODO: Add guarding animation here

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
        GameObject p = getPlayerObject();
        
        cinema.lookTarget(state, 3, p.transform.Find("Spine"));
        //Write in code for Item use
    }

    IEnumerator playerMagicAttack(int power, int type) {
        GameObject p = getPlayerObject();
        
        cinema.lookTarget(state, 3, p.transform.Find("Spine"));
        yield return new WaitForSeconds(1);
        cinema.moveDolly(0.25f, 2, 3);
        //TODO: Add casting animation
        yield return new WaitForSeconds(2);
        //TODO: Add Persona attacking animation and particle effects depending on type
        
        
        if (p)      //TODO: Add check, if the spell is all enemies on the battle field, the "target" should be all and hence damage them all and run checks on them all
        {
            float damage;
            int eD=0, eD1=0, eD2=0, eD3=0;
            if (enemyGO)
            {
                damage = playerMagicDamageCalculator(power, type, enemyUnit);
                eD = enemyUnit.TakeDamage(damage, type);
            }
            if (enemyGO1)
            {
                damage = playerMagicDamageCalculator(power, type, enemyUnit1);
                eD1 = enemyUnit1.TakeDamage(damage, type);
            }
            if (enemyGO2)
            {
                damage = playerMagicDamageCalculator(power, type, enemyUnit2);
                eD2 = enemyUnit2.TakeDamage(damage, type);
            }
            if (enemyGO3)
            {
                damage = playerMagicDamageCalculator(power, type, enemyUnit3);
                eD3 = enemyUnit3.TakeDamage(damage, type);
            }

            if (eD == 2 || eD1 == 2 || eD2 == 2 || eD3 == 2)
            {
                //TODO: add falling animations to all the enemies that are down, and just normal damage animations for whoever is not
                if (eD == 2 && !enemyUnit.isDown)
                {
                    enemyUnit.isDown = true;
                    oneMore();
                }
                else if (eD1 == 2 && !enemyUnit1.isDown)
                {
                    enemyUnit1.isDown = true;
                    oneMore();
                }
                else if (eD2 == 2 && !enemyUnit2.isDown)
                {
                    enemyUnit2.isDown = true;
                    oneMore();
                }
                else if (eD3 == 2 && !enemyUnit3.isDown)
                {
                    enemyUnit3.isDown = true;
                    oneMore();
                }
                else
                {
                    nextTurn();
                }
            }
        }
        else
        {
            GameObject e = null;
            //TODO: change "enemyUnit" to be whoever is targetted (e). Utilize some sort of "check" for this, perhaps not a switch statement
            float damage = playerMagicDamageCalculator(power, type, enemyUnit);
            int enemyDamaged = enemyUnit.TakeDamage(damage, type);
            //enemyDamage.SetActive(true);
            //enemyDamage.text = damage.ToString();
            switch (enemyDamaged)
            {
                case 0: //enemy is dead and was not knocked down
                        //TODO: Either fade enemy out or play dying animation. 
                        //yield return new WaitForSeconds(1);
                    Destroy(enemyGO); Destroy(enemyUnit);
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
                        //TODO: Either fade enemy out or play dying animation
                        //yield return new WaitForSeconds(1);
                    Destroy(enemyGO); Destroy(enemyUnit);
                    //enemyDamage.SetActive(false);
                    //yield return new WaitForSeconds(2);

                    oneMore();

                    break;
                default:
                    //yield return new WaitForSeconds(2);
                    nextTurn();
                    break;
            }
        }
    }

    IEnumerator PlayerShoot()
    {
        //TODO: Handle the shooting event here
        GameObject e = null; Unit eu = null;
        GameObject p = getPlayerObject(); Player pu = getPlayer();
        yield return new WaitForSeconds(1); //Remove later
        float damage = playerDamageCalculator(pu, eu, true);
        int enemyDamaged = enemyUnit.TakeDamage(damage, 1);
    }
    IEnumerator PlayerAttack()
    {
        GameObject p = getPlayerObject(); Player pu = getPlayer();
        GameObject e = null; Unit eu = null;        //Change this to whatever the targetted enemy is
        yield return new WaitForSeconds(2);
        float damage = playerDamageCalculator(pu, eu, false);
        //Accommodate for miss/dodge chance here
        int enemyDamaged = eu.TakeDamage(damage, 0);
        //Enemy HP bar changes
        switch (enemyDamaged) {
            case 0: //enemy is dead
                //Destroy(enemyUnit);
                //yield return new WaitForSeconds(2);
                state = BattleState.WON;
                EndBattle();
                break;
            case 2: //weak or crit
                if (!enemyUnit.isDown)
                {
                    enemyUnit.isDown = true;
                    oneMore();
                    break;
                }
                else
                {
                    nextTurn();
                    break;
                }
            case 3: //reflect
                int playerDamaged = pu.TakeDamage(damage, 0);
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
        GameObject e = getEnemyObject();
        Unit eu = getEnemy();
        cinema.lookTarget(1, e.transform);          //TODO: This uses wrong method. Need to correct it
        int ailment = eu.AilmentChecker();
        switch (ailment) {
            case 1:
                eu.AilmentClear();
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
    float playerDamageCalculator(Player p, Unit e, bool gun) {
        float damage;
        if (!gun)
            damage = (float)(p.weapon * Math.Sqrt(p.str));
        else
            damage = (float)(p.gun * Math.Sqrt(p.str));
        damage = damage / (float)(Math.Sqrt((e.shadow.en * 8))) + (float)(0.5);
        //TODO: insert random 5% variance to damage
        return damage;
    }

    //TODO: 
    float playerMagicDamageCalculator(int power, int type, Unit e) {
        float damage = 0;
        switch (type) {
            case 0: case 1:
                damage = (float)(power * Math.Sqrt(playerUnit.str));        //For gun and phys damage
                break;
            case 2: case 3: case 4: case 5: case 6: case 7: case 8: case 9:
                damage = (float)(power + (power * (float)(playerUnit.mag / 30)));   //For magic damage
                int getAilment = ailmentCalculator(type);
                if (getAilment != 0)
                    e.ailment = getAilment;
                break;
        }
        damage = damage / (float)(Math.Sqrt((e.shadow.en * 8))) + (float)(0.5);
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

    GameObject getPlayerObject()
    {
        GameObject p = null;
        switch (state)
        {
            case BattleState.PLAYER1TURN:
                p = playerGO;
                break;
            case BattleState.PLAYER2TURN:
                p = playerGO1;
                break;
            case BattleState.PLAYER3TURN:
                p = playerGO2;
                break;
            case BattleState.PLAYER4TURN:
                p = playerGO3;
                break;
        }
        return p;
    }

    Player getPlayer()
    {
        Player p = null;
        switch (state)
        {
            case BattleState.PLAYER1TURN:
                p = playerUnit;
                break;
            case BattleState.PLAYER2TURN:
                p = playerUnit1;
                break;
            case BattleState.PLAYER3TURN:
                p = playerUnit2;
                break;
            case BattleState.PLAYER4TURN:
                p = playerUnit3;
                break;
        }
        return p;
    }

    GameObject getEnemyObject()
    {
        GameObject e = null;
        switch (state)
        {
            case BattleState.ENEMY1TURN:
                e = enemyGO;
                break;
            case BattleState.ENEMY2TURN:
                e = enemyGO1;
                break;
            case BattleState.ENEMY3TURN:
                e = enemyGO2;
                break;
            case BattleState.ENEMY4TURN:
                e = enemyGO3;
                break;
        }
        return e;
    }

    Unit getEnemy()
    {
        Unit e = null;
        switch (state)
        {
            case BattleState.ENEMY1TURN:
                e = enemyUnit;
                break;
            case BattleState.ENEMY2TURN:
                e = enemyUnit1;
                break;
            case BattleState.ENEMY3TURN:
                e = enemyUnit2;
                break;
            case BattleState.ENEMY4TURN:
                e = enemyUnit3;
                break;
        }
        return e;
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
