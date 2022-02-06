﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.InputSystem;
using UnityEngine.Video;

//TODO: Implement multiplayer using Clientside rendering for the battle.
//TODO: playerMissChecker and critChecker should have a faux number that boosts luck depending if a crit boost skill is in effect
//TODO: Add armor scriptable object into the factoring for missing, critting, evading, and just overall defense

public enum BattleState { START, PLAYER1TURN, PLAYER2TURN, PLAYER3TURN, PLAYER4TURN, ENEMY1TURN, ENEMY2TURN, ENEMY3TURN, ENEMY4TURN, WON, LOST }

public class BattleSystem : MonoBehaviour {
    //NOTE: Use the party's stats for any damage calcuation and whatnot, and use the Game Object Instantiated to deal with animations and whatnot
    //TODO: Ensure that communication between server and client is taken into account
    //TODO: Change from MonoBehaviour to NetworkBehaviour
    //TODO: Make changes from this BattleSystem and modify them for NetworkBehaviour in the DefaultBattleManager program
    //TODO: Add Cinemachine functionality, switching between which game object to focus on depending on situation
    //SUGGESTION: Add some handheld Perlin noise to make the camera seem a bit more dynamic.... maybe when the player's health gets low or something
    //SUGGESTION: Utilize a Dictionary of Lists for each enemy prefab. Depending on the area will point to a result in the dictionary which should hold the list of prefabs associated with the area

    public BattleState state;

    public GameObject Circle;
    public GameObject APanel, TPanel, AtPanel, PPanel, IPanel;
    public Party party;
    [SerializeField]
    private SkillReader sr;
    private Skills skillHolder;
    public TargetManager targetSelect;
    public Camera cam;
    [SerializeField]
    private GameObject HUDOutline, LowHPOutline;
    [SerializeField]
    private GameObject staticObject, staticObject2, staticObject3;

    //public GameObject Nex, Coco, Keese, Reiko;
    public GameObject enemyPrefab1, enemyPrefab2, enemyPrefab3, enemyPrefab4, enemyPrefab5;


    public AudioSource Select, Back;
    public AudioSource Normal, Ambushed, Ambushing, BG;
    public AudioSource victory, defeat;
    public AudioSource Error, Navigate;
    public CinemachineCombatHandler cinema;

    public Persona playerUnit, playerUnit1, playerUnit2, playerUnit3;
    public Unit enemyUnit, enemyUnit1, enemyUnit2, enemyUnit3;         //Unit is the script being run for enemies
    private GameObject enemyGO, enemyGO1, enemyGO2, enemyGO3;
    private GameObject playerGO, playerGO1, playerGO2, playerGO3;

    public Transform p1Look, p2Look, p3Look, p4Look, pSelectLook;

    private Vector3 p1Pos, p2Pos, p3Pos, p4Pos;
    private bool isDisadvantage, isTargettingSingle = false, isTargettingMultiple = false, isMelee = false, isShooting = false, gunDown = false, baton = false, isSkill = false, isItem = false;
    public short advantage, bullets = 0;
    [SerializeField]
    private byte who = 0, batonCount = 0;
    int partyNum = 0;
    private byte staticGONum;

    System.Random rand = new System.Random();

    void Awake() {
        party = GameObject.Find("Party").GetComponent<Party>();         //Makes the party an actual interactable thing
        party.Start();      //REMOVE: Get rid of this later, it's for testing purposes
        partyNum = party.getPartyNum();
        for (int i = 0; i < party.parties[partyNum].Count; i++)
        {
            //party.parties[partyNum][i].GetComponent<Persona>().inCombat = true;
        }
        if (party.parties[partyNum][0].GetComponent<Persona>().triggeredAdvantage)
        {
            advantage = 1;
            isDisadvantage = false;
            p1Pos = new Vector3(0.22f, 0, -11.10f);
            p2Pos = new Vector3(8.52f, 0, -1.32f);
            p3Pos = new Vector3(-0.74f, 0, 7.29f);
            p4Pos = new Vector3(-9.05f, 0, -1.78f);
        }
        else if (party.parties[partyNum][0].GetComponent<Persona>().triggeredCombat)
        {
            advantage = 0;
            isDisadvantage = false;
            p1Pos = new Vector3(0.22f, 0, -11.10f);
            p2Pos = new Vector3(8.52f, 0, -1.32f);
            p3Pos = new Vector3(-0.74f, 0, 7.29f);
            p4Pos = new Vector3(-9.05f, 0, -1.78f);
        }
        else
        {
            advantage = -1;
            isDisadvantage = true;
        }

        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    void Update()
    {
        GameObject p = getPlayerObject();
        Persona pu = getPlayerInParty();
        if (pu && pu.PCC.isTurn) {
            if (isTargettingSingle)             //Make additional check to ensure the player whose turn it is is the one who gets to target
            {
                GameObject enemy = null, enemy1 = null;
                //Next if statements check to see if the game object exists, then checks if it has the target icon active
                if (enemyGO && enemyGO.transform.Find("Target Icon").gameObject.activeSelf)
                    enemy1 = enemyGO;
                else if (enemyGO1 && enemyGO1.transform.Find("Target Icon").gameObject.activeSelf)
                    enemy1 = enemyGO1;
                else if (enemyGO2 && enemyGO2.transform.Find("Target Icon").gameObject.activeSelf)
                    enemy1 = enemyGO2;
                else if (enemyGO3 && enemyGO3.transform.Find("Target Icon").gameObject.activeSelf)
                    enemy1 = enemyGO3;
                else if (playerGO && playerGO.transform.Find("Target Icon").gameObject.activeSelf)
                    enemy1 = playerGO;
                else if (playerGO1 && playerGO1.transform.Find("Target Icon").gameObject.activeSelf)
                    enemy1 = playerGO1;
                else if (playerGO2 && playerGO2.transform.Find("Target Icon").gameObject.activeSelf)
                    enemy1 = playerGO2;
                else if (playerGO3 && playerGO3.transform.Find("Target Icon").gameObject.activeSelf)
                    enemy1 = playerGO3;

                RaycastHit goRead;
                if (Physics.Raycast(cam.ScreenPointToRay(Mouse.current.position.ReadValue()), out goRead, Mathf.Infinity))      //Checks to see if mouse is over an enemy game object
                {
                    enemy = goRead.transform.gameObject;

                    if (!GameObject.ReferenceEquals(enemy, enemy1) && enemy.tag == "Enemy")
                    {
                        targetSelect.targetShow(enemy1, enemy);
                        Navigate.Play();
                    } else if (!GameObject.ReferenceEquals(enemy, enemy1))
                    {
                        targetSelect.targetClear(enemy1);
                    }
                }
                if (pu.PCC.back.action.triggered && (isMelee || isSkill || isItem))
                {
                    camReset();
                    Back.Play();
                    targetSelect.targetClear(enemy);
                    isTargettingSingle = false;
                    if (isMelee)
                    {
                        isMelee = false;
                        AtPanel.SetActive(true);
                    }
                    else if (isSkill)
                    {
                        isSkill = false;
                        PPanel.SetActive(true);
                    }
                    else if (isItem)
                    {
                        isItem = false;
                        IPanel.SetActive(true);
                    }
                } 
                else if (pu.PCC.back.action.triggered && isShooting)
                {
                    if (bullets < p.GetComponent<Persona>().gun.magazineSize)       //if bullets > 0 and bullets < p.gun.maxBullets
                    {
                        Debug.Log("Ended shooting with used magazine");
                        p.GetComponent<Persona>().bulletCount += bullets;
                        bullets = 0;
                        pu.PCC.isTurn = false;
                        Back.Play();
                        targetSelect.targetClear(enemy);
                        isTargettingSingle = false;
                        isShooting = false;
                        p.GetComponent<Persona>().PCC.isShooting = false;
                        camReset();
                        gunDespawn(p);
                        p.GetComponent<Persona>().PCC.animator.SetBool("GunIdle", false);
                        if (gunDown)
                            oneMore();
                        else
                            nextTurn();
                    } else
                    {
                        switch (state)
                        {
                            case BattleState.PLAYER1TURN:
                                cinema.animator.Play("Player 1");
                                cinema.camState.LookAt = p1Look;
                                break;
                            case BattleState.PLAYER2TURN:
                                cinema.animator.Play("Player 2");
                                cinema.camState.LookAt = p2Look;
                                break;
                            case BattleState.PLAYER3TURN:
                                cinema.animator.Play("Player 3");
                                cinema.camState.LookAt = p3Look;
                                break;
                            case BattleState.PLAYER4TURN:
                                cinema.animator.Play("Player 4");
                                cinema.camState.LookAt = p4Look;
                                break;
                        }
                        Back.Play();
                        targetSelect.targetClear(enemy);
                        isTargettingSingle = false;
                        isShooting = false;
                        p.GetComponent<Persona>().PCC.isShooting = false;
                        camReset();
                        gunDespawn(p);
                        p.GetComponent<Persona>().PCC.animator.SetBool("GunIdle", false);
                        p.GetComponent<Persona>().bulletCount += bullets;
                        bullets = 0;
                        AtPanel.SetActive(true);
                    }
                }
                if (pu.PCC.click.action.triggered)
                {
                    if (isMelee)
                    {
                        if (enemy)
                        {
                            if (enemy.transform.Find("Target Icon") != null)
                            {
                                targetSelect.targetClear(enemy);
                                isTargettingSingle = false;
                                Select.Play();
                                StartCoroutine(PlayerAttack(enemy));
                            }
                        }
                    }
                    else if (isShooting)
                    {
                        bullets--;
                        p.GetComponent<Persona>().PCC.animator.SetTrigger("isShooting");        //May need to update this for Tao specifically
                        p.transform.Find("SoundEffect").gameObject.GetComponent<AudioSource>().clip = p.GetComponent<Persona>().gun.gunshotSound;
                        p.transform.Find("SoundEffect").gameObject.GetComponent<AudioSource>().Play();
                        if (enemy)
                        {
                            if (enemy.transform.Find("Target Icon") != null && enemy.GetComponent<Unit>() != null)
                            {
                                PlayerShoot(enemy);
                            } else if (enemy.transform.Find("Target Icon") != null && enemy.GetComponent<Persona>() != null)
                            {
                                PlayerShoot(enemy.GetComponent<Persona>());
                            }
                        }
                        if (bullets == 0)
                        {
                            Debug.Log("Ended shooting with empty magazine");
                            pu.PCC.isTurn = false;
                            targetSelect.targetClear(enemy);
                            isTargettingSingle = false;
                            isShooting = false;
                            p.GetComponent<Persona>().PCC.isShooting = false;
                            camReset();
                            gunDespawn(p);
                            p.GetComponent<Persona>().PCC.animator.SetBool("GunIdle", false);
                            AtPanel.SetActive(true);
                            if (gunDown)
                                oneMore();
                            else
                                nextTurn();
                        }
                    } else if (isSkill)
                    {
                        if (skillHolder.support)
                        {
                            if (enemy)
                            {
                                if (enemy.transform.Find("Target Icon") != null)
                                {
                                    targetSelect.targetClear(enemy);
                                    isTargettingSingle = false;
                                    isSkill = false;
                                    //Start
                                }

                            }
                        }
                        else
                        {
                            if (enemy)
                            {
                                if (enemy.transform.Find("Target Icon") != null)
                                {
                                    targetSelect.targetClear(enemy);
                                    isTargettingSingle = false;
                                    //Select.Play();
                                    StartCoroutine(playerMagicAttack(enemy));
                                }
                            }
                        }
                    }
                }
            } else if (isTargettingMultiple)
            {
                if (pu.PCC.back.action.triggered && (isSkill || isItem))
                {
                    camReset();
                    Back.Play();
                    GameObject ally = null, ally1 = null, ally2 = null, ally3 = null, enemy = null, enemy1 = null, enemy2 = null, enemy3 = null;
                    if (playerGO)
                        ally = playerGO;
                    if (playerGO1)
                        ally1 = playerGO1;
                    if (playerGO2)
                        ally2 = playerGO2;
                    if (playerGO3)
                        ally3 = playerGO3;
                    if (enemyGO)
                        enemy = enemyGO;
                    if (enemyGO1)
                        enemy1 = enemyGO1;
                    if (enemyGO2)
                        enemy2 = enemyGO2;
                    if (enemyGO3)
                        enemy3 = enemyGO3;
                    GameObject[] targets = new GameObject[8];
                    targets[0] = ally; targets[1] = ally1; targets[2] = ally2; targets[3] = ally3; targets[4] = enemy; targets[5] = enemy1; targets[6] = enemy2; targets[7] = enemy3;

                    targetSelect.targetClear(targets);
                    isTargettingMultiple = false;
                    if (isSkill)
                    {
                        isSkill = false;
                        PPanel.SetActive(true);
                    }
                    else if (isItem)
                    {
                        isItem = false;
                        IPanel.SetActive(true);
                    }
                }
                if (pu.PCC.click.action.triggered)
                {
                    if (isSkill)
                    {
                        if (skillHolder.magic)
                        {
                            pu.magicCast(skillHolder.cost);
                            if (skillHolder.support)
                            {
                                GameObject ally = null, ally1 = null, ally2 = null, ally3 = null;
                                if (playerGO)
                                    ally = playerGO;
                                if (playerGO1)
                                    ally1 = playerGO1;
                                if (playerGO2)
                                    ally2 = playerGO2;
                                if (playerGO3)
                                    ally3 = playerGO3;

                                GameObject[] a = getTargetArray(ally, ally1, ally2, ally3);
                                targetSelect.targetClear(a);
                                isTargettingMultiple = false;
                                isSkill = false;
                                //Start
                            }
                            else
                            {
                                pu.physCast(skillHolder.cost);
                                GameObject enemy = null, enemy1 = null, enemy2 = null, enemy3 = null;
                                if (enemyGO)
                                    enemy = enemyGO;
                                if (enemyGO1)
                                    enemy1 = enemyGO1;
                                if (enemyGO2)
                                    enemy2 = enemyGO2;
                                if (enemyGO3)
                                    enemy3 = enemyGO3;

                                GameObject[] a = getTargetArray(enemy, enemy1, enemy2, enemy3);
                                targetSelect.targetClear(a);

                                isTargettingMultiple = false;
                                isSkill = false;
                                StartCoroutine(playerMagicAttack(a));
                            }
                        }
                        else
                        {
                            pu.physCast(skillHolder.cost);
                            GameObject enemy = null, enemy1 = null, enemy2 = null, enemy3 = null;
                            if (enemyGO)
                                enemy = enemyGO;
                            if (enemyGO1)
                                enemy1 = enemyGO1;
                            if (enemyGO2)
                                enemy2 = enemyGO2;
                            if (enemyGO3)
                                enemy3 = enemyGO3;

                            GameObject[] a = getTargetArray(enemy, enemy1, enemy2, enemy3);
                            targetSelect.targetClear(a);

                            isTargettingMultiple = false;
                            isSkill = false;
                            StartCoroutine(playerMagicAttack(a));
                        }
                    }
                }
                if (isSkill)
                {
                    if (skillHolder.support)
                    {
                        GameObject ally = null, ally1 = null, ally2 = null, ally3 = null;
                        if (playerGO)
                            ally = playerGO;
                        if (playerGO1)
                            ally1 = playerGO1;
                        if (playerGO2)
                            ally2 = playerGO2;
                        if (playerGO3)
                            ally3 = playerGO3;

                        GameObject[] a = getTargetArray(ally, ally1, ally2, ally3);
                        targetSelect.targetShow(a);
                    }
                    else
                    {
                        GameObject enemy = null, enemy1 = null, enemy2 = null, enemy3 = null;
                        if (enemyGO)
                            enemy = enemyGO;
                        if (enemyGO1)
                            enemy1 = enemyGO1;
                        if (enemyGO2)
                            enemy2 = enemyGO2;
                        if (enemyGO3)
                            enemy3 = enemyGO3;

                        GameObject[] a = getTargetArray(enemy, enemy1, enemy2, enemy3);
                        targetSelect.targetShow(a);
                    }
                }
                else if (isItem)
                {
                    //TO BE FILLED IN LATER
                }
            }
        }
    }

    private GameObject enemySpawner(GameObject e, Vector3 pos, int prefab)
    {
        switch (prefab) {
            case 1:
                e = Instantiate(enemyPrefab1, pos, Quaternion.identity);
                break;
            case 2:
                e = Instantiate(enemyPrefab2, pos, Quaternion.identity);
                break;
            case 3:
                e = Instantiate(enemyPrefab3, pos, Quaternion.identity);
                break;
            case 4:
                e = Instantiate(enemyPrefab4, pos, Quaternion.identity);
                break;
            case 5:
                e = Instantiate(enemyPrefab5, pos, Quaternion.identity);
                break;
            default:
                e = null;
                break;
        }
        if (e != null)
        {
            e.SetActive(true);
            return e;
        }
        return null;
    }

    private void playerSpawner(int adv, Party party, GameObject p, Persona pu)
    {
        switch (adv)
        {
            case -1:

                break;
            case 0:
            case 1:

                break;
        }
    }

    IEnumerator SetupBattle() {
        if (advantage == -1)
        {
            BG = Instantiate(Ambushed);         //TODO: Fix delay issue with looper. Disadvan. has problem with waiting
            BG.PlayDelayed(1);
        } else if (advantage == 0)
        {
            BG = Instantiate(Normal);
            BG.PlayDelayed(1);
        }
        else
        {
            BG = Instantiate(Ambushing);
            BG.PlayDelayed(1);
        }
        int howMany = rand.Next(1, 5);
        int[] which = { 0, 0, 0, 0 };

        //SUGGESTION: If go with list route, then will need to alter the numbers of enemies to be picked from
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
        enemyGO = enemySpawner(enemyGO, new Vector3(-0.5f, 0, -3.3599999f), which[0]);
        enemyGO1 = enemySpawner(enemyGO1, new Vector3(-1.903f, 0, -0.49f), which[1]);
        enemyGO2 = enemySpawner(enemyGO2, new Vector3(1.75f, 0, -2.04f), which[2]);
        enemyGO3 = enemySpawner(enemyGO3, new Vector3(0.35f, 0, 0.79f), which[3]);
        if (enemyGO)
        {
            enemyUnit = enemyGO.GetComponent<Unit>();
            enemyUnit.EC.Look(who);

        }
        if (enemyGO1)
        {
            enemyUnit1 = enemyGO1.GetComponent<Unit>();
            enemyUnit1.EC.Look(who);
        }
        if (enemyGO2)
        {
            enemyUnit2 = enemyGO2.GetComponent<Unit>();
            enemyUnit2.EC.Look(who);
        }
        if (enemyGO3)
        {
            enemyUnit3 = enemyGO3.GetComponent<Unit>();
            enemyUnit3.EC.Look(who);
        }


        #region Party Spawner
        if (!isDisadvantage) {
            for (int i = 0; i < party.parties[partyNum].Count; i++)
            {
                switch (i) {
                    case 0:
                        {
                            playerGO = Instantiate(party.parties[partyNum][i], p1Pos, Quaternion.identity); //player1
                            playerUnit = playerGO.GetComponent<Persona>();
                            playerUnit.PCC.LookBattleTurn(1, isDisadvantage);
                            playerUnit.PCC.returnToSpawn(1, isDisadvantage);
                            playerUnit.PCC.toSpawn = true;
                            playerUnit.PCC.playerNum = 1;
                            playerUnit.PCC.isDis = isDisadvantage;
                            break;
                        }
                    case 1:         //Player 2 Camera needs to be implemented at 8.91 0.32 -2.71 with rotation 11.552, -82, 0 with FOV of 40
                        {
                            playerGO1 = Instantiate(party.parties[partyNum][i], p2Pos, Quaternion.identity);
                            playerUnit1 = playerGO1.GetComponent<Persona>();
                            playerUnit1.PCC.LookBattleTurn(2, isDisadvantage);
                            playerUnit1.PCC.returnToSpawn(2, isDisadvantage);
                            playerUnit1.PCC.toSpawn = true;
                            playerUnit1.PCC.playerNum = 2;
                            playerUnit1.PCC.isDis = isDisadvantage;
                            break;
                        }
                    case 2:         //Player 3 Camera needs to be implemented at 0.1812 0.32 7.4736 with rotation 11.552 185 0
                        {

                            playerGO2 = Instantiate(party.parties[partyNum][i], p3Pos, Quaternion.identity);
                            playerUnit2 = playerGO2.GetComponent<Persona>();
                            playerUnit2.PCC.LookBattleTurn(3, isDisadvantage);
                            playerUnit2.PCC.returnToSpawn(3, isDisadvantage);
                            playerUnit2.PCC.toSpawn = true;
                            playerUnit2.PCC.playerNum = 3;
                            playerUnit2.PCC.isDis = isDisadvantage;
                            break;
                        }
                    case 3:
                        {

                            playerGO3 = Instantiate(party.parties[partyNum][i], p4Pos, Quaternion.identity);
                            playerUnit3 = playerGO3.GetComponent<Persona>();
                            playerUnit3.PCC.LookBattleTurn(4, isDisadvantage);
                            playerUnit3.PCC.returnToSpawn(4, isDisadvantage);
                            playerUnit3.PCC.toSpawn = true;
                            playerUnit3.PCC.playerNum = 4;
                            playerUnit3.PCC.isDis = isDisadvantage;
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
            for (int i = 0; i < party.parties[partyNum].Count; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            playerGO = Instantiate(party.parties[partyNum][i], new Vector3(0.22f, 0, -7.122f), Quaternion.identity); //player1
                            playerUnit = playerGO.GetComponent<Persona>();   //TODO: Fix playerSpawns later
                            playerUnit.PCC.LookBattleTurn(1, isDisadvantage);
                            playerUnit.PCC.returnToSpawn(1, isDisadvantage);
                            playerUnit.PCC.toSpawn = true;
                            break;
                        }
                    case 1:         //Player 2 Camera needs to be implemented at 8.91 0.32 -2.71 with rotation 11.552, -82, 0 with FOV of 40
                        {
                            playerGO1 = Instantiate(party.parties[partyNum][i], new Vector3(5.962f, 0, -1.318f), Quaternion.identity);
                            playerUnit1 = playerGO1.GetComponent<Persona>();   //TODO: Fix playerSpawns later
                            playerUnit1.PCC.LookBattleTurn(2, isDisadvantage);
                            playerUnit1.PCC.returnToSpawn(2, isDisadvantage);
                            playerUnit1.PCC.toSpawn = true;
                            break;
                        }
                    case 2:         //Player 3 Camera needs to be implemented at 0.1812 0.32 7.4736 with rotation 11.552 185 0
                        {

                            playerGO2 = Instantiate(party.parties[partyNum][i], new Vector3(-0.74f, 0, 4.58f), Quaternion.identity);
                            playerUnit2 = playerGO2.GetComponent<Persona>();   //TODO: Fix playerSpawns later
                            playerUnit2.PCC.LookBattleTurn(3, isDisadvantage);
                            playerUnit2.PCC.returnToSpawn(3, isDisadvantage);
                            playerUnit2.PCC.toSpawn = true;
                            break;
                        }
                    case 3:
                        {

                            playerGO3 = Instantiate(party.parties[partyNum][i], new Vector3(-6.05f, 0, -1.78f), Quaternion.identity);
                            playerUnit3 = playerGO3.GetComponent<Persona>();   //TODO: Fix playerSpawns later
                            playerUnit3.PCC.LookBattleTurn(4, isDisadvantage);
                            playerUnit3.PCC.returnToSpawn(4, isDisadvantage);
                            playerUnit3.PCC.toSpawn = true;
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
        cinema.lookTarget(state, p1Look);
        //TODO: Add enemy spawning animation
        //SUGGESTION: Move camera up to spawning enemy, setting leader's alpha to 0 over time, removing other players, and crossfade scene background into combat, then when zooming to battle scene, replace all players with combat counterparts
        //TODO: Add getting up from being knocked down animation from disadvantage
        //TODO: Add very brief pause between enemy spawn animation and players running up, perhaps altering the players' alpha level as well to seem as if they are running in
        cinema.moveDolly(1, 0, 1);
        yield return new WaitForSeconds(2);     //This allows the setup of the battle, then makes us wait 2 seconds.
        p1Pos = new Vector3(0.22f, 0, -7.122f);
        p2Pos = new Vector3(5.962f, 0, -1.318f);
        p3Pos = new Vector3(-0.74f, 0, 4.58f);
        p4Pos = new Vector3(-6.05f, 0, -1.78f);
        nextTurn();
    }

    public void PlayerTurn() {
        #region Setting Up Turn

        if (enemyGO)
            enemyGO.GetComponent<Unit>().EC.Look(who);
        if (enemyGO1)
            enemyGO1.GetComponent<Unit>().EC.Look(who);
        if (enemyGO2)
            enemyGO2.GetComponent<Unit>().EC.Look(who);
        if (enemyGO3)
            enemyGO3.GetComponent<Unit>().EC.Look(who);
        int ailment;
        GameObject p = getPlayerObject();
        Persona pp = getPlayerInParty();
        ailment = pp.AilmentChecker();
        p.GetComponent<Persona>().PCC.playerSpeed = 6;
        if (p.GetComponent<Persona>().isDown)
        {
            //TODO: Play animation for standing up
            p.GetComponent<Persona>().isDown = false;
        }
        //TODO: Implement all ailment checks here as cases
        if ((float)(pp.getHealth() / pp.getMaxHealth() * 100) <= 25)
        {
            //TODO: Play injured animation
            //cinema.startPerlin(); //TODO: Run Perlin check for injured player with previous code
        }
        #endregion
        pp.PCC.isTurn = true;
        cinema.camState.Follow = null;
        camReset();
        if ((float)(pp.GetComponent<Persona>().currentHealth) / (float)(pp.GetComponent<Persona>().maxHealth) <= 0.3f)
        {
            HUDOutline.SetActive(false);
            LowHPOutline.SetActive(true);
        }
        else
        {
            HUDOutline.SetActive(true);
            LowHPOutline.SetActive(false);
        }
        p.GetComponent<PlayerCombatController>().animator.SetBool("isBlocking", false);
        sr.cleanUpSkills();
        sr.createSkillObjects(partyNum, who);
        Circle.SetActive(true);
    }

    public void OnPhysicalAttack() {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();
        AtPanel.SetActive(false);
        targetCam();
        cinema.camState.LookAt = pSelectLook;
        GameObject enemy = null;
        if (enemyGO)
            enemy = enemyGO;
        else if (enemyGO1)
            enemy = enemyGO1;
        else if (enemyGO2)
            enemy = enemyGO2;
        else if (enemyGO3)
            enemy = enemyGO3;

        isTargettingSingle = true;
        isMelee = true;
    }

    public void OnGunAttack()
    {
        GameObject p = getPlayerObject();

        if (p.GetComponent<Persona>().bulletCount == 0)
        {
            Error.Play();
            Debug.Log("No bullets left!");
        }
        else {
            p.GetComponent<Persona>().PCC.animator.SetBool("GunIdle", true);
            Select.Play();

            AtPanel.SetActive(false);
            //Set Shooting UI to active
            isTargettingSingle = true;
            isShooting = true;
            p.GetComponent<Persona>().PCC.isShooting = true;
            switch (state) {
                case BattleState.PLAYER1TURN:
                    cinema.animator.Play("Player 1 Shoot");
                    break;
                case BattleState.PLAYER2TURN:
                    cinema.animator.Play("Player 2 Shoot");
                    break;
                case BattleState.PLAYER3TURN:
                    cinema.animator.Play("Player 3 Shoot");
                    break;
                case BattleState.PLAYER4TURN:
                    cinema.animator.Play("Player 4 Shoot");
                    break;
            }
            cinema.camState.LookAt = pSelectLook;
            if (p.GetComponent<Persona>().charName == "Tao Kazuma")
            {
                p.transform.Find("Tao Kazuma/Armature/Hips/Spine/Chest/Left shoulder/Left arm/Left elbow/Left wrist/Weapon Placeholder").gameObject.SetActive(false);
                GameObject gunRef = p.transform.Find("Tao Kazuma/Armature/Hips/Spine/Chest/Left shoulder/Left arm/Left elbow/Left wrist/Gun Placeholder").gameObject;
                gunRef.SetActive(true);
                gunRef.transform.GetChild(0).localPosition = p.GetComponent<Persona>().gun.position;
                gunRef.transform.GetChild(0).localRotation = Quaternion.Euler(p.GetComponent<Persona>().gun.rotation);
                gunRef = p.transform.Find("Tao Kazuma/Armature/Hips/Spine/Chest/Right shoulder/Right arm/Right elbow/Right wrist/Gun2 Placeholder").gameObject;
                gunRef.SetActive(true);
                gunRef.transform.GetChild(0).localPosition = p.GetComponent<Persona>().gun.position2;
                gunRef.transform.GetChild(0).localRotation = Quaternion.Euler(p.GetComponent<Persona>().gun.rotation2);
            }
            else if (p.GetComponent<Persona>().charName == "Haruka")
            {
                p.transform.Find("Haruka/Armature/Hips/Spine/Chest/Left Shoulder/Left elbow/Right wrist/Weapon Placeholder").gameObject.SetActive(false);
                p.transform.Find("Haruka/Armature/Hips/Spine/Chest/Left Shoulder/Left elbow/Right wrist/Gun Placeholder").gameObject.SetActive(true);
            }
            else if (p.GetComponent<Persona>().charName == "Reiko")
            {
                p.transform.Find("Reiko/Armature/Hips/Spine/Chest/Left Shoulder/Left elbow/Right wrist/Weapon Placeholder").gameObject.SetActive(false);
                p.transform.Find("Reiko/Armature/Hips/Spine/Chest/Left Shoulder/Left elbow/Right wrist/Gun Placeholder").gameObject.SetActive(true);
            }
            else if (p.GetComponent<Persona>().charName == "Coco")
            {
                /*p.transform.Find("Haruka/Armature/Hips/Spine/Chest/Left Shoulder/Left elbow/Right wrist/Weapon Placeholder").gameObject.SetActive(true);
                p.transform.Find("Haruka/Armature/Hips/Spine/Chest/Left Shoulder/Left elbow/Right wrist/Gun Placeholder").gameObject.SetActive(false);*/
            }
            else
            {
                Debug.Log("Looks like your character weapon finder failed");
            }
            for (int i = 1; i <= p.GetComponent<Persona>().bulletCount && i <= p.GetComponent<Persona>().gun.magazineSize; i++)
            {
                bullets++;
                p.GetComponent<Persona>().bulletCount--;
            }
        }
    }

    private void targetCam()
    {
        switch (state)
        {
            case BattleState.PLAYER1TURN:
                cinema.animator.Play("Player 1 Select");
                break;
            case BattleState.PLAYER2TURN:
                cinema.animator.Play("Player 2 Select");
                break;
            case BattleState.PLAYER3TURN:
                cinema.animator.Play("Player 3 Select");
                break;
            case BattleState.PLAYER4TURN:
                cinema.animator.Play("Player 4 Select");
                break;
        }
    }

    void gunDespawn(GameObject p)
    {
        if (p.GetComponent<Persona>().charName == "Tao Kazuma")
        {
            p.transform.Find("Tao Kazuma/Armature/Hips/Spine/Chest/Left shoulder/Left arm/Left elbow/Left wrist/Weapon Placeholder").gameObject.SetActive(true);
            p.transform.Find("Tao Kazuma/Armature/Hips/Spine/Chest/Left shoulder/Left arm/Left elbow/Left wrist/Gun Placeholder").gameObject.SetActive(false);
            p.transform.Find("Tao Kazuma/Armature/Hips/Spine/Chest/Right shoulder/Right arm/Right elbow/Right wrist/Gun2 Placeholder").gameObject.SetActive(false);
        }
        else if (p.GetComponent<Persona>().charName == "Haruka")
        {
            p.transform.Find("Haruka/Armature/Hips/Spine/Chest/Left Shoulder/Left elbow/Right wrist/Weapon Placeholder").gameObject.SetActive(true);
            p.transform.Find("Haruka/Armature/Hips/Spine/Chest/Left Shoulder/Left elbow/Right wrist/Gun Placeholder").gameObject.SetActive(false);
        }
        else if (p.GetComponent<Persona>().charName == "Reiko")
        {
            p.transform.Find("Reiko/Armature/Hips/Spine/Chest/Left Shoulder/Left elbow/Right wrist/Weapon Placeholder").gameObject.SetActive(true);
            p.transform.Find("Reiko/Armature/Hips/Spine/Chest/Left Shoulder/Left elbow/Right wrist/Gun Placeholder").gameObject.SetActive(false);
        }
        else if (p.GetComponent<Persona>().charName == "Coco")
        {
            /*p.transform.Find("Haruka/Armature/Hips/Spine/Chest/Left Shoulder/Left elbow/Right wrist/Weapon Placeholder").gameObject.SetActive(true);
            p.transform.Find("Haruka/Armature/Hips/Spine/Chest/Left Shoulder/Left elbow/Right wrist/Gun Placeholder").gameObject.SetActive(false);*/
        }
        else
        {
            Debug.Log("Looks like your character weapon finder failed");
        }
    }

    public void OnGuard() {
        Circle.SetActive(false);
        GameObject p = getPlayerObject();
        Persona pp = getPlayerInParty();
        pp.guard = true;
        p.GetComponent<PlayerCombatController>().animator.SetBool("isBlocking", true);
        //TODO: Add guarding animation here
        pp.PCC.isTurn = false;
        nextTurn();
    }

    public void onSkillAttack(Skills skill)
    {
        bool t = magicChecker(skill);
        if (t)
        {
            targetCam();
            cinema.camState.LookAt = pSelectLook;
            isSkill = true;
            skillHolder = skill;
            if (skill.multiple)
                isTargettingMultiple = true;
            else
                isTargettingSingle = true;
            PPanel.SetActive(false);
        }
    }

    public bool magicChecker(Skills skill)
    {
        if (skill.magic)
        {
            if (playerUnit.getSP() < skill.cost)
            {
                //checks SP cost to current SP
                Error.Play();
                //Print not enough SP
                return false;
            }
            else
            {
                // Get the game object by finding our Select audio object
                Select.Play();
                PPanel.SetActive(false);
                return true;
            }
        }
        else if (!skill.magic)
        {
            Persona var = new Persona();

            if (playerUnit.getHealth() < (int)(playerUnit.getMaxHealth() * (float)(skill.cost / 100)))
            { //Checks HP cost to current HP
                Error.Play();
                return false;
            }
            else
            {
                Select.Play();
                PPanel.SetActive(false);
                return true;
            }
        }
        return false;   //This should never be hit
    }

    public void OnItemUse(int item) {
        IPanel.SetActive(false);
        GameObject p = getPlayerObject();

        cinema.lookTarget(state, p.transform.Find("Spine"));
        //Write in code for Item use
    }

    IEnumerator playerMagicAttack(GameObject enemy) {
        GameObject p = getPlayerObject();
        Unit eu = enemy.GetComponent<Unit>();
        p.GetComponent<Persona>().PCC.isAttacking = true;

        if (GameObject.ReferenceEquals(enemy, enemyGO))
        {
            //p.GetComponent<Persona>().PCC.goTo(enemyGO.transform);
            enemyGO.transform.LookAt(p.transform);
        }
        else if (GameObject.ReferenceEquals(enemy, enemyGO1))
        {
            //p.GetComponent<Persona>().PCC.goTo(enemyGO1.transform);
            enemyGO1.transform.LookAt(p.transform);
        }
        else if (GameObject.ReferenceEquals(enemy, enemyGO2))
        {
            //p.GetComponent<Persona>().PCC.goTo(enemyGO2.transform);
            enemyGO2.transform.LookAt(p.transform);
        }
        else
        {
            //p.GetComponent<Persona>().PCC.goTo(enemyGO3.transform);
            enemyGO3.transform.LookAt(p.transform);
        }
        castCam();
        if (p.GetComponent<Persona>().charName == "Tao Kazuma")
        {
            cinema.camState.LookAt = p.transform.Find("Tao Kazuma/Armature/Hips");
        }
        else if (p.GetComponent<Persona>().charName == "Haruka")
        {
            cinema.camState.LookAt = p.transform.Find("Haruka/Armature/Hips");          //Change these last 3 later
        }
        else if (p.GetComponent<Persona>().charName == "Reiko")
        {
            cinema.camState.LookAt = p.transform.Find("Reiko/Armature/Hips");
        }
        else if (p.GetComponent<Persona>().charName == "Coco")
        {

        }
        yield return new WaitForSeconds(3f);

        bool isMiss = playerMissChecker(enemy, (short)(skillHolder.type));

        if (!isMiss)
        {
            float damage = playerMagicDamageCalculator(p.GetComponent<Persona>(), eu);
            //TODO: Accommodate for miss/dodge chance here
            //TODO: Add Player attack animation here
            yield return new WaitForSeconds(0.75f);
            int enemyDamaged = eu.TakeDamage(damage, (short)(skillHolder.type), critChecker(0));
            cinema.camState.LookAt = enemy.transform.Find("CamTarget");                 //TODO: Add "CamTarget" locations to ALL enemy Prefabs
            StartCoroutine(damageHandler(damage, enemy, p, enemyDamaged, (short)(skillHolder.type)));
        }
        else
        {
            StartCoroutine(enemyDodge(enemy));
            getPlayerInParty().PCC.isTurn = false;
            nextTurn();
        }
    }

    IEnumerator playerMagicAttack(GameObject[] e)
    {
        GameObject p = getPlayerObject();
        p.GetComponent<Persona>().PCC.isAttacking = true;
        castCam();
        if (p.GetComponent<Persona>().charName == "Tao Kazuma")
        {
            cinema.camState.LookAt = p.transform.Find("Tao Kazuma/Armature/Hips");
        }
        else if (p.GetComponent<Persona>().charName == "Haruka")
        {
            cinema.camState.LookAt = p.transform.Find("Haruka/Armature/Hips");          //Change these last 3 later
        }
        else if (p.GetComponent<Persona>().charName == "Reiko")
        {
            cinema.camState.LookAt = p.transform.Find("Reiko/Armature/Hips");
        }
        else if (p.GetComponent<Persona>().charName == "Coco")
        {

        }
        yield return new WaitForSeconds(3f);

        bool anotherOne = false;
        foreach (GameObject i in e)
        {
            Unit eu = i.GetComponent<Unit>();
            bool isMiss = playerMissChecker(i, (short)(skillHolder.type));

            if (!isMiss)
            {
                float damage = playerMagicDamageCalculator(p.GetComponent<Persona>(), eu);
                //TODO: Accommodate for miss/dodge chance here
                //TODO: Add Player attack animation here
                yield return new WaitForSeconds(0.75f);
                int enemyDamaged = eu.TakeDamage(damage, (short)(skillHolder.type), critChecker(0));
                cinema.camState.LookAt = i.transform.Find("CamTarget");                 //TODO: Add "CamTarget" locations to ALL enemy Prefabs
                StartCoroutine(damageHandler(damage, i, p, enemyDamaged, (short)(skillHolder.type)));
            }
            else
            {
                StartCoroutine(enemyDodge(i));
                getPlayerInParty().PCC.isTurn = false;
            }
        }

        if (anotherOne)
            oneMore();
        else if (state == BattleState.WON) ;
        else
            nextTurn();
            

    }

    void PlayerShoot(GameObject enemy)
    {
        Unit eu = enemy.GetComponent<Unit>();
        GameObject p = getPlayerObject();
        Persona pp = getPlayerInParty();
        bool isMiss = playerMissChecker(enemy, 1);
        if (!isMiss)
        {
            float damage = playerDamageCalculator(pp, eu, true);
            int enemyDamaged = eu.TakeDamage(damage, 1, critChecker(1));
            switch (enemyDamaged)
            {
                case 2:
                    if (!eu.isDown)
                    {
                        if (eu.currentHP <= 0)
                        {
                            //TODO: Add Enemy death animation
                            if (enemyCheck())
                            {
                                state = BattleState.WON;
                                pp.GetComponent<Persona>().PCC.isTurn = false;
                                EndBattle();
                                break;
                            }
                        }
                        else
                        {
                            //TODO: Add Enemy Knocked Down Animation
                            eu.isDown = true;
                            gunDown = true;
                        }
                        break;
                    }
                    else
                    {
                        if (eu.currentHP <= 0)
                        {
                            //TODO: Add Enemy death animation
                            if (enemyCheck())
                            {
                                state = BattleState.WON;
                                pp.GetComponent<Persona>().PCC.isTurn = false;
                                EndBattle();
                                break;
                            }
                        }
                    }
                    break;
            }
        }
        else
        {
            StartCoroutine(enemyDodge(enemy));
        }
    }

    void PlayerShoot(Persona player)
    {
        playerDodge();
        //Make the player say an angry line at the shooter
    }
    IEnumerator PlayerAttack(GameObject enemy)
    {
        GameObject p = getPlayerObject();               //TODO: Alter how damage works by making checks and with the box collider on the weapon object
        Unit eu = enemy.GetComponent<Unit>();
        p.GetComponent<Persona>().PCC.playerSpeed = 6;
        p.GetComponent<Persona>().PCC.isAttacking = true;
        if (GameObject.ReferenceEquals(enemy, enemyGO))
        {
            p.GetComponent<Persona>().PCC.goTo(enemyGO.transform);
            enemyGO.transform.LookAt(p.transform);
        }
        else if (GameObject.ReferenceEquals(enemy, enemyGO1))
        {
            p.GetComponent<Persona>().PCC.goTo(enemyGO1.transform);
            enemyGO1.transform.LookAt(p.transform);
        }
        else if (GameObject.ReferenceEquals(enemy, enemyGO2))
        {
            p.GetComponent<Persona>().PCC.goTo(enemyGO2.transform);
            enemyGO2.transform.LookAt(p.transform);
        }
        else
        {
            p.GetComponent<Persona>().PCC.goTo(enemyGO3.transform);
            enemyGO3.transform.LookAt(p.transform);
        }
        castCam();
        if (p.GetComponent<Persona>().charName == "Tao Kazuma") {
            cinema.camState.LookAt = p.transform.Find("Tao Kazuma/Armature/Hips");
        } else if (p.GetComponent<Persona>().charName == "Haruka")
        {
            cinema.camState.LookAt = p.transform.Find("Haruka/Armature/Hips");          //Change these last 3 later
        } else if (p.GetComponent<Persona>().charName == "Reiko")
        {
            cinema.camState.LookAt = p.transform.Find("Reiko/Armature/Hips");
        } else if (p.GetComponent<Persona>().charName == "Coco")
        {

        }

        yield return new WaitForSeconds(2f);
        bool isMiss = playerMissChecker(enemy, 0);
        if (!isMiss)
        {
            float damage = playerDamageCalculator(p.GetComponent<Persona>(), eu, false);
            //TODO: Accommodate for miss/dodge chance here
            //TODO: Add Player attack animation here
            yield return new WaitForSeconds(0.75f);
            int enemyDamaged = eu.TakeDamage(damage, 0, critChecker(0));
            cinema.camState.LookAt = enemy.transform.Find("CamTarget");                 //TODO: Add "CamTarget" locations to ALL enemy Prefabs
            StartCoroutine(damageHandler(damage, enemy, p, enemyDamaged, 0));
        }
        else
        {
            StartCoroutine(enemyDodge(enemy));
            System.Random rnd = new System.Random();
            int fallChance = rnd.Next(1, 21);
            if (fallChance == 1)
            {
                //Player player stumble to down position
                p.GetComponent<Persona>().isDown = true;
                yield return new WaitForSeconds(1.5f);
                p.transform.position = p1Pos;
                getPlayerInParty().PCC.isTurn = false;
                nextTurn();
            }
            else
            {
                p.GetComponent<Persona>().PCC.returnToSpawn(who, isDisadvantage);
                getPlayerInParty().PCC.isTurn = false;
                nextTurn();
            }

        }
    }

    private bool playerMissChecker(GameObject enemy, short type)            //P=0, G=1, F=2, I=3, L=4, W=5, Ps=6, N=7, B=8, C=9, A=10, AIL = 11
    {
        Persona p = getPlayerInParty();
        //Crazy miss checking math
        int hitChance = 0;
        switch (type)
        {
            case 0:
                hitChance = (int)(p.ag + p.weapon.hit * 0.75f);
                break;
            case 1:
                hitChance = (int)(p.ag + p.gun.hit * 0.75f);
                break;
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
                break;
        }
        hitChance += p.lu;
        int evadeChance = enemy.GetComponent<Unit>().shadow.ag + enemy.GetComponent<Unit>().shadow.lu;
        int overallChance = hitChance - evadeChance;
        System.Random rnd = new System.Random();
        if (overallChance <= 0 || overallChance < (int)(rnd.Next(0, 101)))
            return false;
        else
            return true;
    }

    IEnumerator enemyDodge(GameObject enemy)
    {
        enemy.transform.position = Vector3.Lerp(enemy.transform.position, -enemy.transform.right, 3 * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
        enemy.transform.position = Vector3.Lerp(enemy.transform.position, enemy.transform.right, 3 * Time.deltaTime);
    }

    private void playerDodge()
    {
        getPlayerObject().GetComponent<Persona>().PCC.animator.SetTrigger("Dodge");
    }

    private bool critChecker(short type)
    {
        Persona p = getPlayerInParty();
        int critChance = 0;
        switch (type)
        {
            case 0:
                if (p.weapon.critBoost)
                {
                    critChance += p.weapon.chance;
                }
                break;
            case 1:
                if (p.gun.critBoost)
                {
                    critChance += p.gun.chance;
                }
                break;
        }
        critChance += p.lu;
        System.Random rnd = new System.Random();
        if ((int)(rnd.Next(0, 101)) > critChance)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool specialDamageHandler(float damage, GameObject enemy, GameObject p, int enemyDamaged, short type) {
        Unit eu = enemy.GetComponent<Unit>();
        Persona pu = getPlayerInParty();
        //Enemy HP bar changes
        switch (enemyDamaged) {
            case 0: //enemy is dead
                eu.die();       //plays enemy death animation and removes them
                if (enemyCheck())
                {
                    state = BattleState.WON;
                    pu.PCC.isTurn = false;
                    EndBattle();
                    return false; //May break
                }
                else
                {
                    p.GetComponent<Persona>().PCC.isAttacking = false;
                    pu.PCC.isTurn = false;
                    return true;
                }
            case 2: //weak or crit
                //Player crit animation is followed up. Should be a seperate animation that smoothly transfers from normal attack to it
                p.GetComponent<Persona>().PCC.isAttacking = false;
                if (!eu.isDown)
                {
                    if (eu.currentHP <= 0)
                    {
                        eu.die();
                        if (enemyCheck())
                        {
                            p.GetComponent<Persona>().PCC.isAttacking = false;
                            state = BattleState.WON;
                            EndBattle();
                            pu.PCC.isTurn = false;
                            return false; //May break
                        }
                    }
                    else
                    {
                        //TODO: Add Enemy Knocked Down Animation
                        eu.isDown = true;
                    }
                    p.GetComponent<Persona>().PCC.isAttacking = false;
                    return true;
                }
                else
                {
                    if (eu.currentHP <= 0)
                    {
                        eu.die();
                        if (enemyCheck())
                        {
                            p.GetComponent<Persona>().PCC.isAttacking = false;
                            state = BattleState.WON;
                            EndBattle();
                            return false;
                        }
                    }
                    p.GetComponent<Persona>().PCC.isAttacking = false;
                    return false;
                }

            case 3: //reflect
                int i = pu.TakeDamage(damage, type);
                //Interrupt attack animation/Play damaged animation
                p.GetComponent<Persona>().PCC.isAttacking = false;
                pu.PCC.isTurn = false;
                return false;
            default:
                p.GetComponent<Persona>().PCC.isAttacking = false;
                pu.PCC.isTurn = false;
                return false;
        }

    }

    IEnumerator damageHandler(float damage, GameObject enemy, GameObject p, int enemyDamaged, short type) {
        Unit eu = enemy.GetComponent<Unit>();
        Persona pu = getPlayerInParty();
        //Enemy HP bar changes
        switch (enemyDamaged) {
            case 0: //enemy is dead
                eu.die();
                if (enemyCheck())
                {
                    yield return new WaitForSeconds(2);
                    state = BattleState.WON;
                    pu.PCC.isTurn = false;
                    EndBattle();
                    break;
                }
                else
                {
                    p.GetComponent<Persona>().PCC.isAttacking = false;
                    p.GetComponent<Persona>().PCC.returnToSpawn(who, isDisadvantage);
                    p.GetComponent<Persona>().PCC.toSpawn = true;
                    //yield return new WaitForSeconds(2);
                    pu.PCC.isTurn = false;
                    nextTurn();
                    break;
                }
            case 2: //weak or crit
                //Player crit animation is followed up. Should be a seperate animation that smoothly transfers from normal attack to it
                yield return new WaitForSeconds(3);
                p.GetComponent<Persona>().PCC.isAttacking = false;
                if (!eu.isDown)
                {
                    if (eu.currentHP <= 0)
                    {
                        eu.die();
                        if (enemyCheck())
                        {
                            p.GetComponent<Persona>().PCC.isAttacking = false;
                            state = BattleState.WON;
                            EndBattle();
                            pu.PCC.isTurn = false;
                            break;
                        }
                    }
                    else
                    {
                        //TODO: Add Enemy Knocked Down Animation
                        eu.isDown = true;
                        switch (state)
                        {
                            case BattleState.PLAYER1TURN:
                                p.transform.position = p1Pos;
                                break;
                            case BattleState.PLAYER2TURN:
                                p.transform.position = p2Pos;
                                break;
                            case BattleState.PLAYER3TURN:
                                p.transform.position = p3Pos;
                                break;
                            case BattleState.PLAYER4TURN:
                                p.transform.position = p4Pos;
                                break;
                        }
                        p.GetComponent<Persona>().PCC.targetPos = Vector3.zero;
                    }
                    p.GetComponent<Persona>().PCC.isAttacking = false;
                    oneMore();
                    break;
                }
                else
                {
                    if (eu.currentHP <= 0)
                    {
                        eu.die();
                        if (enemyCheck())
                        {
                            p.GetComponent<Persona>().PCC.isAttacking = false;
                            state = BattleState.WON;
                            EndBattle();
                            break;
                        }
                        p.GetComponent<Persona>().PCC.isAttacking = false;
                        p.GetComponent<Persona>().PCC.returnToSpawn(who, isDisadvantage);
                        p.GetComponent<Persona>().PCC.toSpawn = true;
                        nextTurn();
                        break;
                    }
                    else
                    {
                        p.GetComponent<Persona>().PCC.isAttacking = false;
                        p.GetComponent<Persona>().PCC.returnToSpawn(who, isDisadvantage);
                        p.GetComponent<Persona>().PCC.toSpawn = true;
                        nextTurn();
                        break;
                    }
                }

            case 3: //reflect
                int i = pu.TakeDamage(damage, type);
                //Interrupt attack animation/Play damaged animation
                yield return new WaitForSeconds(1);
                p.GetComponent<Persona>().PCC.isAttacking = false;
                p.GetComponent<Persona>().PCC.returnToSpawn(who, isDisadvantage);
                p.GetComponent<Persona>().PCC.toSpawn = true;
                pu.PCC.isTurn = false;
                nextTurn();
                break;
            default:
                p.GetComponent<Persona>().PCC.isAttacking = false;
                p.GetComponent<Persona>().PCC.returnToSpawn(who, isDisadvantage);
                p.GetComponent<Persona>().PCC.toSpawn = true;
                //yield return new WaitForSeconds(2);
                pu.PCC.isTurn = false;
                nextTurn();
                break;
        }

    }

    bool enemyCheck()
    {
        if (enemyGO)
            return false;
        else if (enemyGO1)
            return false;
        else if (enemyGO2)
            return false;
        else if (enemyGO3)
            return false;
        return true;
    }

    IEnumerator EnemyTurn() {
        yield return new WaitForSeconds(1);
        GameObject e = getEnemyObject();
        Unit eu = getEnemy();
        cinema.lookTarget(state, e.transform);          //TODO: This uses wrong method. Need to correct it
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
        short rng = 4; //random.Random(0,10);   //For testing damage types, will be used eventually for selecting people and abilities
        int pRng = 0;
        while (true)
        {
            pRng = rand.Next(0, party.parties[partyNum].Count);
            if (!party.parties[partyNum][pRng].GetComponent<Persona>().unconscious)
            {
                break;
            }

        }
        //Need to add reference to enemy's skill here to add to the enemyDamageCalculator
        int playerDamageResult = 0;
        float damage = enemyDamageCalculator(party.parties[partyNum][pRng].GetComponent<Persona>());
        playerDamageResult = party.parties[partyNum][pRng].GetComponent<Persona>().TakeDamage(damage, rng);
        playerUnit = party.parties[partyNum][0].GetComponent<Persona>();
        Debug.Log("Enemy attacks " + party.parties[partyNum][pRng].GetComponent<Persona>().name + " and deals " + damage + " damage");

        //Player HP Bar changes
        switch (playerDamageResult) {
            case 0:
                if ((playerUnit.unconscious || !playerUnit) && (playerUnit1.unconscious || !playerUnit1) && (playerUnit2.unconscious || !playerUnit2) && (playerUnit3.unconscious || !playerUnit3))
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
                        enemyDamageResult = enemyUnit.TakeDamage(damage, rng, false);
                        break;
                    case 6:
                        enemyDamageResult = enemyUnit1.TakeDamage(damage, rng, false);
                        break;
                    case 7:
                        enemyDamageResult = enemyUnit2.TakeDamage(damage, rng, false);
                        break;
                    case 8:
                        enemyDamageResult = enemyUnit3.TakeDamage(damage, rng, false);
                        break;
                }

                //Enemy HP Bar Changes
                if (enemyDamageResult == 0)
                {
                    //Destroy(enemyGO);
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
    float playerDamageCalculator(Persona p, Unit e, bool gun) {
        float damage;
        System.Random rnd = new System.Random();
        if (!gun)
            damage = (float)(p.weapon.attack * Math.Sqrt(p.str));
        else
            damage = (float)(p.gun.attack * Math.Sqrt(p.str));
        damage = damage / (float)(Math.Sqrt((e.shadow.en * 8))) + (float)(0.5);
        //This should give anywhere between -5% and 5% variance between the calculated damage value
        int rand = rnd.Next(0, 11);
        rand -= 5;
        float variance = damage * ((float)(rand) / 100);
        damage = damage + variance;
        return damage;
    }

    float playerMagicDamageCalculator(Persona p, Unit e) {
        float damage = 0;
        System.Random rnd = new System.Random();
        switch (skillHolder.type) {
            case 0: case 1:
                damage = (float)(skillHolder.power * Math.Sqrt(playerUnit.str));        //For gun and phys damage
                break;
            case 2: case 3: case 4: case 5: case 6: case 7: case 8: case 9:
                damage = (float)(skillHolder.power + (skillHolder.power * (float)(playerUnit.mag / 30)));   //For magic damage
                /*int getAilment = ailmentCalculator(skillHolder.type);
                if (getAilment != 0)
                    e.ailment = getAilment;*/
                break;
                //Create ailment status code here
                //Create support status code here
        }
        damage = damage / (float)(Math.Sqrt((e.shadow.en * 8))) + (float)(0.5);
        int rand = rnd.Next(0, 21);
        rand -= 10;
        float variance = damage * ((float)(rand) / 100);
        damage = damage + variance;
        return damage;
    }

    public int ailmentCalculator(int type) {
        //Fill this in later
        return 0;
    }
    float enemyDamageCalculator(Persona player) {
        float damage = 40;
        if (player.guard)
        {
            damage = damage / 2;
        }
        return damage;
    }
    void nextTurn()
    {
        baton = false;
        batonCount = 0;
        switch (advantage)
        {
            case -1: //Enemy Ambush or Disadvantage, all enemies go first, then returns to normal battle mode
                switch (who)
                {
                    case 0:
                        if (enemyGO)
                        {
                            who = 5;
                            state = BattleState.ENEMY1TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (enemyGO1)
                        {
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (enemyGO2)
                        {
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (enemyGO3)
                        {
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else { advantage = 0; who = 0; state = BattleState.PLAYER1TURN;
                            throw new Exception("Uh oh! nextTurn() failed!!!");         //Only gets here if the enemies didn't spawn
                        }
                        break;
                    case 5:
                        toggleStateTransitionStatic();
                        if (enemyGO1)
                        {

                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (enemyGO2)
                        {

                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (enemyGO3)
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
                        toggleStateTransitionStatic();
                        if (enemyGO2)
                        {

                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (enemyGO3)
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
                        toggleStateTransitionStatic();
                        if (enemyGO3)
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
                        toggleStateTransitionStatic();
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
                        toggleStateTransitionStatic();
                        if (enemyGO)
                        {
                            //
                            who = 5;
                            state = BattleState.ENEMY1TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {

                            p2Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO1)
                        {
                            //
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {

                            p3Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO2)
                        {
                            //
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {

                            p4Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO3)
                        {
                            //
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else { }
                        break;
                    case 5:
                        toggleStateTransitionStatic();
                        if (playerUnit1 && !playerUnit1.unconscious)
                        {

                            p2Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO1)
                        {
                            //
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {

                            p3Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO2)
                        {
                            //
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {

                            p4Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO3)
                        {
                            //
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
                        toggleStateTransitionStatic();
                        if (enemyGO1)
                        {
                            //
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {

                            p3Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO2)
                        {
                            //
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {

                            p4Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO3)
                        {
                            //
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {

                            p1Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO)
                        {
                            //
                            who = 5;
                            state = BattleState.ENEMY1TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else { }
                        break;
                    case 6:
                        toggleStateTransitionStatic();
                        if (playerUnit2 && !playerUnit2.unconscious)
                        {

                            p3Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO2)
                        {
                            //
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {

                            p4Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO3)
                        {
                            //
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {

                            p1Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO)
                        {
                            //
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
                        toggleStateTransitionStatic();
                        if (enemyGO2)
                        {
                            //
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {

                            p4Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO3)
                        {
                            //
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {

                            p1Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO)
                        {
                            //
                            who = 5;
                            state = BattleState.ENEMY1TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {

                            p2Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO1)
                        {
                            //
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else { }
                        break;
                    case 7:
                        toggleStateTransitionStatic();
                        if (playerUnit3 && !playerUnit3.unconscious)
                        {

                            p4Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO3)
                        {
                            //
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {

                            p1Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO)
                        {
                            //
                            who = 5;
                            state = BattleState.ENEMY1TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {

                            p2Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO1)
                        {
                            //
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
                        toggleStateTransitionStatic();
                        if (enemyGO3)
                        {
                            //
                            who = 8;
                            state = BattleState.ENEMY4TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit && !playerUnit.unconscious)
                        {

                            p1Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO)
                        {
                            //
                            who = 5;
                            state = BattleState.ENEMY1TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {

                            p2Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO1)
                        {
                            //
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {

                            p3Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO2)
                        {
                            //
                            who = 7;
                            state = BattleState.ENEMY3TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else { }
                        break;
                    case 8:
                        toggleStateTransitionStatic();
                        if (playerUnit && !playerUnit.unconscious)
                        {

                            p1Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO)
                        {
                            //
                            who = 5;
                            state = BattleState.ENEMY1TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {

                            p2Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO1)
                        {
                            //
                            who = 6;
                            state = BattleState.ENEMY2TURN;
                            StartCoroutine(EnemyTurn());
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {

                            p3Turn();
                            PlayerTurn();
                        }
                        else if (enemyGO2)
                        {
                            //
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
                            state = BattleState.PLAYER3TURN;
                            PlayerTurn();
                        }
                        else if (playerUnit3)
                        {

                            who = 4;
                            state = BattleState.PLAYER4TURN;
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
                            state = BattleState.PLAYER4TURN;
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
        //TODO: Add animation of the player unguarding
        party.parties[partyNum][0].GetComponent<Persona>().guard = false;
        party.parties[partyNum][0].GetComponent<Persona>().PCC.isTurn = true;
    }

    private void p2Turn()
    {
        who = 2;
        state = BattleState.PLAYER2TURN;
        //TODO: Add animation of the player unguarding
        party.parties[partyNum][1].GetComponent<Persona>().guard = false;
        party.parties[partyNum][1].GetComponent<Persona>().PCC.isTurn = true;
    }

    private void p3Turn()
    {
        who = 3;
        state = BattleState.PLAYER3TURN;
        //TODO: Add animation of the player unguarding
        party.parties[partyNum][2].GetComponent<Persona>().guard = false;
        party.parties[partyNum][2].GetComponent<Persona>().PCC.isTurn = true;
    }

    private void p4Turn()
    {
        who = 4;
        state = BattleState.PLAYER4TURN;
        //TODO: Add animation of the player unguarding
        party.parties[partyNum][3].GetComponent<Persona>().guard = false;
        party.parties[partyNum][3].GetComponent<Persona>().PCC.isTurn = true;
    }
    private void toggleStateTransitionStatic()      //will toggle the game object that is playing static
    {
        byte s = (byte)(UnityEngine.Random.Range(0, 2));
        switch (s)
        {
            case 0:
                staticObject.SetActive(true);
                staticObject.GetComponent<VideoPlayer>().Play();
                break;
            case 1:
                staticObject2.SetActive(true);
                staticObject2.GetComponent<VideoPlayer>().Play();
                break;
            case 2:

                staticObject3.SetActive(true);
                staticObject3.GetComponent<VideoPlayer>().Play();
                break;
        }
        staticGONum = (byte)(s + 1);
        cinema.staticAnimator.SetTrigger("Static");
        StartCoroutine(toggleStateTransitionStatic(false));
    }

    IEnumerator toggleStateTransitionStatic(bool f)
    {
        yield return new WaitForSeconds(1);
        switch (staticGONum)
        {
            case 1:
                staticObject.GetComponent<VideoPlayer>().Stop();
                staticObject.SetActive(false);
                break;
            case 2:
                staticObject2.GetComponent<VideoPlayer>().Stop();
                staticObject2.SetActive(false);
                break;
            case 3:
                staticObject3.GetComponent<VideoPlayer>().Stop();
                staticObject3.SetActive(false);
                break;
        }
    }

    void BatonPass()                    //TODO: Do more with this method later
    {
        baton = false;
        batonCount++;
    }

    public void oneMore()
    {
        switch (who)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                //Show friendly 1 more splash screen
                baton = true;
                PlayerTurn();
                break;
            case 5:
            case 6:
            case 7:
            case 8:
                //Show enemy 1 more splash screen
                StartCoroutine(EnemyTurn());
                break;
        }
    }

    GameObject getPlayerObject()
    {
        switch (state)
        {
            case BattleState.PLAYER1TURN:
                return playerGO;
            case BattleState.PLAYER2TURN:
                return playerGO1;
            case BattleState.PLAYER3TURN:
                return playerGO2;
            case BattleState.PLAYER4TURN:
                return playerGO3;
        }
        return null;
    }

    Persona getPlayerInParty()
    {
        switch (state)
        {
            case BattleState.PLAYER1TURN:
                return party.parties[partyNum][0].GetComponent<Persona>();
            case BattleState.PLAYER2TURN:
                return party.parties[partyNum][1].GetComponent<Persona>();
            case BattleState.PLAYER3TURN:
                return party.parties[partyNum][2].GetComponent<Persona>();
            case BattleState.PLAYER4TURN:
                return party.parties[partyNum][3].GetComponent<Persona>();
        }
        return null;
    }

    GameObject getEnemyObject()
    {
        switch (state)
        {
            case BattleState.ENEMY1TURN:
                return enemyGO;
            case BattleState.ENEMY2TURN:
                return enemyGO1;
            case BattleState.ENEMY3TURN:
                return enemyGO2;
            case BattleState.ENEMY4TURN:
                return enemyGO3;
        }
        return null;
    }

    Unit getEnemy()
    {
        switch (state)
        {
            case BattleState.ENEMY1TURN:
                return enemyUnit;
            case BattleState.ENEMY2TURN:
                return enemyUnit1;
            case BattleState.ENEMY3TURN:
                return enemyUnit2;
            case BattleState.ENEMY4TURN:
                return enemyUnit3;
        }
        return null;
    }

    private GameObject[] getTargetArray(GameObject e, GameObject e1, GameObject e2, GameObject e3)
    {
        GameObject[] a = new GameObject[4];
        a[0] = e;
        a[1] = e1;
        a[2] = e2;
        a[3] = e3;

        return a;
    }

    private void castCam()
    {
        switch (state)
        {
            case BattleState.PLAYER1TURN:
                cinema.animator.Play("Player 1 Cast");
                break;
            case BattleState.PLAYER2TURN:
                cinema.animator.Play("Player 2 Cast");
                break;
            case BattleState.PLAYER3TURN:
                cinema.animator.Play("Player 3 Cast");
                break;
            case BattleState.PLAYER4TURN:
                cinema.animator.Play("Player 4 Cast");
                break;
        }
    }

    void camReset()
    {
        switch (state)
        {
            case BattleState.PLAYER1TURN:
                cinema.animator.Play("Player 1");
                cinema.camState.LookAt = p1Look;
                break;
            case BattleState.PLAYER2TURN:
                cinema.animator.Play("Player 2");
                cinema.camState.LookAt = p2Look;
                break;
            case BattleState.PLAYER3TURN:
                cinema.animator.Play("Player 3");
                cinema.camState.LookAt = p3Look;
                break;
            case BattleState.PLAYER4TURN:
                cinema.animator.Play("Player 4");
                cinema.camState.LookAt = p4Look;
                break;
        }
    }

    void EndBattle() {
        BG.Stop();
        Instantiate(victory);
        victory.Play();
        party.parties[partyNum][0].GetComponent<Persona>().triggeredCombat = false;
        party.parties[partyNum][0].GetComponent<Persona>().triggeredAdvantage = false;
        for (int i = 0; i < party.parties[partyNum].Count; i++)
        {
            party.parties[partyNum][i].GetComponent<Persona>().inCombat = false;
        }
    }
    void LostBattle()
    {
        BG.Stop();
        Instantiate(defeat);
        Debug.Log("You lost!");
        defeat.Play();
        party.parties[partyNum][0].GetComponent<Persona>().triggeredCombat = false;
        party.parties[partyNum][0].GetComponent<Persona>().triggeredAdvantage = false;
        for (int i = 0; i < party.parties[partyNum].Count; i++)
        {
            party.parties[partyNum][i].GetComponent<Persona>().inCombat = false;
        }
    }
}
