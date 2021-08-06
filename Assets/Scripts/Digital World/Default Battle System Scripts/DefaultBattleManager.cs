using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public enum BattleState { START, PLAYER1TURN, PLAYER2TURN, PLAYER3TURN, PLAYER4TURN, ENEMY1TURN, ENEMY2TURN, ENEMY3TURN, ENEMY4TURN, WON, LOST }

public class DefaultBattleManager : NetworkBehaviour
{
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
    private int who = 0;
    int partyNum = 0;

    System.Random rand = new System.Random();

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {                         //Remember to add another area for spawning players and enemies based on advantage
        if (advantage == -1)
        {
            BG = Instantiate(Ambushed);
            BG.name = "BG Music";
            BG.PlayDelayed(1);
        }
        else
        {
            BG = Instantiate(Normal);
            BG.name = "BG Music";
            BG.PlayDelayed(1);
        }
        #region Enemy Spawner
        int howMany = rand.Next(1, 5);
        int[] which = { 0, 0, 0, 0 };
        for (int i = 0; i < howMany; i++) //Assigns how many enemies and which enemies are spawned
        {
            which[i] = rand.Next(1, 6);
        }
        int holder;
        for (int i = 0; i < which.Length - 1; i++) //Sorts the null enemies to the end of the which array
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
                    break;
                }
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
        switch (which[2])
        {
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
        if (advantage != -1)
        {
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
        else
        {
            //Update spawning to have players be surrounded
            for (int i = 0; i < party.parties[n].Count; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            playerGO = Instantiate(party.parties[n][i], new Vector3(0.22f, 0, -7.122f), Quaternion.identity); //player1
                            playerUnit = party.parties[n][i].GetComponent<Player>();   //TODO: Fix playerSpawns later
                            playerGO.SetActive(true);
                            playerUnit.PCC.LookBattleTurn(1);
                            break;
                        }
                    case 1:         //Player 2 Camera needs to be implemented at 8.91 0.32 -2.71 with rotation 11.552, -82, 0 with FOV of 40
                        {
                            playerGO1 = Instantiate(party.parties[n][i], new Vector3(5.962f, 0, -1.318f), Quaternion.identity);   //Need to test and implement positioning later
                            playerUnit1 = party.parties[n][i].GetComponent<Player>();   //TODO: Fix playerSpawns later
                            playerGO1.SetActive(true);

                            playerUnit1.PCC.LookBattleTurn(2);
                            break;
                        }
                    case 2:         //Player 3 Camera needs to be implemented at 0.1812 0.32 7.4736 with rotation 11.552 185 0
                        {

                            playerGO2 = Instantiate(party.parties[n][i], new Vector3(-0.74f, 0, 4.58f), Quaternion.identity);   //Need to test and implement positioning later
                            playerUnit2 = party.parties[n][i].GetComponent<Player>();   //TODO: Fix playerSpawns later
                            playerGO2.SetActive(true);

                            playerUnit2.PCC.LookBattleTurn(3);
                            break;
                        }
                    case 3:
                        {

                            playerGO3 = Instantiate(party.parties[n][i], new Vector3(-6.05f, 0, -1.78f), Quaternion.identity);   //Need to test and implement positioning later
                            playerUnit3 = party.parties[n][i].GetComponent<Player>();   //TODO: Fix playerSpawns later
                            playerGO3.SetActive(true);

                            playerUnit1.PCC.LookBattleTurn(4);
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

        yield return new WaitForSeconds(2);     //This allows the setup of the battle, then makes us wait 2 seconds. Should be replaced with either players getting up, or running in animation depending on advantage
        nextTurn();
    }

    void nextTurn()
    {
        switch (advantage)
        {
            case -1: //Enemy Ambush or Disadvantage, all enemies go first, then returns to normal battle mode
                switch (state)
                {
                    case BattleState.START:
                        if (enemyUnit)
                        {
                            e1Turn();
                            StartCoroutine(EnemyTurn(enemyUnit));
                        }
                        else if (enemyUnit1)
                        {
                            e2Turn();
                            StartCoroutine(EnemyTurn(enemyUnit1));
                        }
                        else if (enemyUnit2)
                        {
                            e3Turn();
                            StartCoroutine(EnemyTurn(enemyUnit2));
                        }
                        else if (enemyUnit3)
                        {
                            e4Turn();
                            StartCoroutine(EnemyTurn(enemyUnit3));
                        }
                        else
                        {
                            advantage = 0; who = 0; state = BattleState.PLAYER1TURN;
                            nextTurn();
                        }
                        break;
                    case BattleState.ENEMY1TURN:
                        if (enemyUnit1)
                        {
                            e2Turn();
                            StartCoroutine(EnemyTurn(enemyUnit1));
                        }
                        else if (enemyUnit2)
                        {
                            e3Turn();
                            StartCoroutine(EnemyTurn(enemyUnit2));
                        }
                        else if (enemyUnit3)
                        {
                            e4Turn();
                            StartCoroutine(EnemyTurn(enemyUnit3));
                        }
                        else
                        {
                            advantage = 0; who = 0; state = BattleState.PLAYER1TURN;
                            nextTurn();
                        }
                        break;
                    case BattleState.ENEMY2TURN:
                        if (enemyUnit2)
                        {
                            e3Turn();
                            StartCoroutine(EnemyTurn(enemyUnit2));
                        }
                        else if (enemyUnit3)
                        {
                            e4Turn();
                            StartCoroutine(EnemyTurn(enemyUnit3));
                        }
                        else
                        {
                            advantage = 0; who = 0; state = BattleState.PLAYER1TURN;
                            nextTurn();
                        }
                        break;
                    case BattleState.ENEMY3TURN:
                        if (enemyUnit3)
                        {
                            e4Turn();
                            StartCoroutine(EnemyTurn(enemyUnit3));
                        }
                        else
                        {
                            advantage = 0; who = 0; state = BattleState.PLAYER1TURN;
                            nextTurn();
                        }
                        break;
                    case BattleState.ENEMY4TURN:
                        advantage = 0;
                        state = BattleState.START;
                        nextTurn();
                        break;
                }
                break;
            case 0: //Normal Battle Mode
                switch (state)
                {
                    case BattleState.START: //Makes sure a player starts first
                        if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn(playerUnit);
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn(playerUnit1);
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn(playerUnit2);
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn(playerUnit3);
                        }
                        else {
                            Debug.Log("Either all players are unconscious and Battle is lost, or no players exist for some reason");
                        }    //Something bad happened if this is triggered
                        break;
                    case BattleState.PLAYER1TURN: //Next turn should be an enemy after the "leader", but can be a player if the "enemy" died
                        if (enemyUnit)
                        {
                            e1Turn();
                            StartCoroutine(EnemyTurn(enemyUnit));
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn(playerUnit1);
                        }
                        else if (enemyUnit1)
                        {
                            e2Turn();
                            StartCoroutine(EnemyTurn(enemyUnit1));
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn(playerUnit2);
                        }
                        else if (enemyUnit2)
                        {
                            e3Turn();
                            StartCoroutine(EnemyTurn(enemyUnit2));
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn(playerUnit3);
                        }
                        else if (enemyUnit3)
                        {
                            e4Turn();
                            StartCoroutine(EnemyTurn(enemyUnit3));
                        }
                        else { }
                        break;
                    case BattleState.ENEMY1TURN:
                        if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn(playerUnit1);
                        }
                        else if (enemyUnit1)
                        {
                            e2Turn();
                            StartCoroutine(EnemyTurn(enemyUnit1));
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn(playerUnit2);
                        }
                        else if (enemyUnit2)
                        {
                            e3Turn();
                            StartCoroutine(EnemyTurn(enemyUnit2));
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn(playerUnit3);
                        }
                        else if (enemyUnit3)
                        {
                            e4Turn();
                            StartCoroutine(EnemyTurn(enemyUnit3));
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn(playerUnit);
                        }
                        else { }
                        break;
                    case BattleState.PLAYER2TURN:
                        if (enemyUnit1)
                        {
                            e2Turn();
                            StartCoroutine(EnemyTurn(enemyUnit1));
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn(playerUnit2);
                        }
                        else if (enemyUnit2)
                        {
                            e3Turn();
                            StartCoroutine(EnemyTurn(enemyUnit2));
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn(playerUnit3);
                        }
                        else if (enemyUnit3)
                        {
                            e4Turn();
                            StartCoroutine(EnemyTurn(enemyUnit3));
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn(playerUnit);
                        }
                        else if (enemyUnit)
                        {
                            e1Turn();
                            StartCoroutine(EnemyTurn(enemyUnit));
                        }
                        else { }
                        break;
                    case BattleState.ENEMY2TURN:
                        if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn(playerUnit2);
                        }
                        else if (enemyUnit2)
                        {
                            e3Turn();
                            StartCoroutine(EnemyTurn(enemyUnit2));
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn(playerUnit3);
                        }
                        else if (enemyUnit3)
                        {
                            e4Turn();
                            StartCoroutine(EnemyTurn(enemyUnit3));
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn(playerUnit);
                        }
                        else if (enemyUnit)
                        {
                            e1Turn();
                            StartCoroutine(EnemyTurn(enemyUnit));
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn(playerUnit1);
                        }
                        else { }
                        break;
                    case BattleState.PLAYER3TURN:
                        if (enemyUnit2)
                        {
                            e3Turn();
                            StartCoroutine(EnemyTurn(enemyUnit2));
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn(playerUnit3);
                        }
                        else if (enemyUnit3)
                        {
                            e4Turn();
                            StartCoroutine(EnemyTurn(enemyUnit3));
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn(playerUnit);
                        }
                        else if (enemyUnit)
                        {
                            e1Turn();
                            StartCoroutine(EnemyTurn(enemyUnit));
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn(playerUnit1);
                        }
                        else if (enemyUnit1)
                        {
                            e2Turn();
                            StartCoroutine(EnemyTurn(enemyUnit1));
                        }
                        else { }
                        break;
                    case BattleState.ENEMY3TURN:
                        if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn(playerUnit3);
                        }
                        else if (enemyUnit3)
                        {
                            e4Turn();
                            StartCoroutine(EnemyTurn(enemyUnit3));
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn(playerUnit);
                        }
                        else if (enemyUnit)
                        {
                            e1Turn();
                            StartCoroutine(EnemyTurn(enemyUnit));
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn(playerUnit1);
                        }
                        else if (enemyUnit1)
                        {
                            e2Turn();
                            StartCoroutine(EnemyTurn(enemyUnit1));
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn(playerUnit2);
                        }
                        else { }
                        break;
                    case BattleState.PLAYER4TURN:
                        if (enemyUnit3)
                        {
                            e4Turn();
                            StartCoroutine(EnemyTurn(enemyUnit3));
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn(playerUnit);
                        }
                        else if (enemyUnit)
                        {
                            e1Turn();
                            StartCoroutine(EnemyTurn(enemyUnit));
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn(playerUnit1);
                        }
                        else if (enemyUnit1)
                        {
                            e2Turn();
                            StartCoroutine(EnemyTurn(enemyUnit1));
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn(playerUnit2);
                        }
                        else if (enemyUnit2)
                        {
                            e3Turn();
                            StartCoroutine(EnemyTurn(enemyUnit2));
                        }
                        else { }
                        break;
                    case BattleState.ENEMY4TURN:
                        if (playerUnit && !playerUnit.unconscious)
                        {
                            p1Turn();
                            PlayerTurn(playerUnit);
                        }
                        else if (enemyUnit)
                        {
                            e1Turn();
                            StartCoroutine(EnemyTurn(enemyUnit));
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            p2Turn();
                            PlayerTurn(playerUnit1);
                        }
                        else if (enemyUnit1)
                        {
                            e2Turn();
                            StartCoroutine(EnemyTurn(enemyUnit1));
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            p3Turn();
                            PlayerTurn(playerUnit2);
                        }
                        else if (enemyUnit2)
                        {
                            e3Turn();
                            StartCoroutine(EnemyTurn(enemyUnit2));
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            p4Turn();
                            PlayerTurn(playerUnit3);
                        }
                        else { }
                        break;
                }
                break;
            case 1: //Ambush or Advantage attack, all players go first, then returns to normal battle mode
                switch (state)    //Adjust last cases to reflect logical turn
                {
                    case BattleState.START:
                        if (playerUnit)
                        {
                            who = 1;
                            state = BattleState.PLAYER1TURN;
                            PlayerTurn(playerUnit);
                        }
                        else if (playerUnit1)
                        {
                            who = 2;
                            state = BattleState.PLAYER2TURN;
                            PlayerTurn(playerUnit1);
                        }
                        else if (playerUnit2)
                        {
                            who = 3;
                            state = BattleState.PLAYER3TURN;
                            PlayerTurn(playerUnit2);
                        }
                        else if (playerUnit3)
                        {
                            who = 4;
                            state = BattleState.PLAYER4TURN;
                            PlayerTurn(playerUnit3);
                        }
                        else
                        {
                            advantage = 0; who = 0; state = BattleState.START;
                            nextTurn();
                        }
                        break;
                    case BattleState.PLAYER1TURN:
                        if (playerUnit1)
                        {
                            who = 2;
                            state = BattleState.PLAYER2TURN;
                            PlayerTurn(playerUnit1);
                        }
                        else if (playerUnit2)
                        {
                            who = 3;
                            state = BattleState.PLAYER3TURN;
                            PlayerTurn(playerUnit2);
                        }
                        else if (playerUnit3)
                        {
                            who = 4;
                            state = BattleState.PLAYER4TURN;
                            PlayerTurn(playerUnit3);
                        }
                        else
                        {
                            advantage = 0; who = 0; state = BattleState.START;
                            nextTurn();
                        }
                        break;
                    case BattleState.PLAYER2TURN:
                        if (playerUnit2)
                        {
                            who = 3;
                            state = BattleState.PLAYER2TURN;
                            PlayerTurn(playerUnit2);
                        }
                        else if (playerUnit3)
                        {
                            who = 4;
                            state = BattleState.PLAYER3TURN;
                            PlayerTurn(playerUnit3);
                        }
                        else
                        {
                            advantage = 0; who = 0; state = BattleState.START;
                            nextTurn();
                        }
                        break;
                    case BattleState.PLAYER3TURN:
                        if (playerUnit3)
                        {
                            who = 4;
                            state = BattleState.PLAYER3TURN;
                            PlayerTurn(playerUnit3);
                        }
                        else
                        {
                            advantage = 0; who = 0; state = BattleState.START;
                            nextTurn();
                        }
                        break;
                    case BattleState.PLAYER4TURN:
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

    private void e1Turn()
    {
        who = 5;
        state = BattleState.ENEMY1TURN;
    }

    private void e2Turn()
    {
        who = 6;
        state = BattleState.ENEMY2TURN;
    }

    private void e3Turn()
    {
        who = 7;
        state = BattleState.ENEMY3TURN;
    }

    private void e4Turn()
    {
        who = 8;
        state = BattleState.ENEMY4TURN;
    }

    public void oneMore()
    {
        switch (state)
        {
            case BattleState.PLAYER1TURN:
                PlayerTurn(playerUnit);
                break;
            case BattleState.PLAYER2TURN:
                PlayerTurn(playerUnit1);
                break;
            case BattleState.PLAYER3TURN:
                PlayerTurn(playerUnit2);
                break;
            case BattleState.PLAYER4TURN:
                PlayerTurn(playerUnit3);
                break;
                //Show friendly 1 more

            case BattleState.ENEMY1TURN:
                StartCoroutine(EnemyTurn(enemyUnit));
                break;
            case BattleState.ENEMY2TURN:
                StartCoroutine(EnemyTurn(enemyUnit1));
                break;
            case BattleState.ENEMY3TURN:
                StartCoroutine(EnemyTurn(enemyUnit2));
                break;
            case BattleState.ENEMY4TURN:
                StartCoroutine(EnemyTurn(enemyUnit3));
                break;
        }
    }

    public void PlayerTurn(Player player)
    {
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
        else
        {
            int ailment = player.AilmentChecker();
            if (player.isDown)
            {
                //Play animation for standing up
                player.isDown = false;
            }
            #endregion
            //Run a check to make sure the active player has authority, otherwise do nothing.
            if (isLocalPlayer)
            {
                Circle.SetActive(true);
            } else { 
                
            }
            //TODO: Lock the action to whoever's turn it is
        }
    }

        IEnumerator EnemyTurn(Unit enemyO)
    {
        yield return new WaitForSeconds(1);
        int ailment = enemyO.AilmentChecker();
        if (enemyO.isDown)
        {
            //Play animation for standing up
            enemyO.isDown = false;
        }
        switch (ailment)
        {
            case 1:
                enemyO.AilmentClear();
                yield return new WaitForSeconds(1);
                break;
                //TODO: Implement other recoveries for Ailments
        }

        StartCoroutine(EnemyAttack(enemyO));
    }
    IEnumerator EnemyAttack(Unit enemyO)
    {
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
        playerDamageResult = party.parties[partyNum][pRng].GetComponent<Player>().TakeDamage(damage, rng);
        //playerUnit = party.parties[partyNum][0].GetComponent<Player>();
        Debug.Log("Enemy attacks " + party.parties[partyNum][pRng].GetComponent<Player>().name + " and deals " + damage + " damage");

        //Player HP Bar changes
        switch (playerDamageResult)
        {
            case 0:
                if ((playerUnit.unconscious || !playerUnit) && (playerUnit1.unconscious || !playerUnit1) && (playerUnit2.unconscious || !playerUnit2) && (playerUnit3.unconscious || !playerUnit3))
                {
                    yield return new WaitForSeconds(2);
                    state = BattleState.LOST;
                    LostBattle();
                }
                else
                    nextTurn();
                break;

            case 3:
                int enemyDamageResult = enemyO.TakeDamage(damage, rng); ;

                //Enemy HP Bar Changes
                if (enemyDamageResult == 0)
                {
                    //Destroy(enemyUnit);
                    if (!enemyUnit && !enemyUnit1 && !enemyUnit2 && !enemyUnit3)
                    {
                        state = BattleState.WON;
                        EndBattle();
                    }
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

    float enemyDamageCalculator(Player player)
    {
        float damage = 5;   //Adjust to reflect skills and whatnot later
        if (player.guard)
        {
            damage = damage / 2;
            player.guard = false;   
        }
        return damage;
    }

    void EndBattle()
    {
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
