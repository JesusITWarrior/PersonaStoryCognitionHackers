using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public enum BattleState { START, PLAYER1TURN, PLAYER2TURN, PLAYER3TURN, PLAYER4TURN, ENEMY1TURN, ENEMY2TURN, ENEMY3TURN, ENEMY4TURN, WON, LOST }

public class BattleSystem : MonoBehaviour {

    public BattleState state;

    public GameObject Circle;
    public GameObject APanel, TPanel, AtPanel, PPanel, IPanel;  //TODO: Reassign these using the instantiated UI rather than use the normal object one
    //public Transform UI;
    public GameObject partyObject;  //These two allow the party to pass into the combat system
    public Party party;             //TODO: clarify which party is being brought into combat, then read the characters. Right now it is defaulted to main party

    public GameObject Nex, Coco, Keese, Reiko;
    public Animator aNex, aCoco, aKeese, aReiko;
    public GameObject enemyPrefab1, enemyPrefab2, enemyPrefab3, enemyPrefab4, enemyPrefab5;
    public Animator ae1, ae2, ae3, ae4, ae5;

    public AudioSource Select;
    public AudioSource BG;
    public AudioSource victory;
    public AudioSource Error;

    public static Player playerUnit, playerUnit1, playerUnit2, playerUnit3;
    public static Unit enemyUnit, enemyUnit1, enemyUnit2, enemyUnit3;         //Unit is the script being run for enemies
    private GameObject enemyGO, enemyGO1, enemyGO2, enemyGO3;
    private GameObject playerGO, playerGO1, playerGO2, playerGO3;

    public static bool callback = false;
    public int advantage;
    private int who=0;

    //private Vector3 enemy1Placement = new Vector3(-0.86f, -1.56f, -3.08f);

    // Use this for initialization
    void Start () {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
	}
	

    IEnumerator SetupBattle() {
        System.Random rand = new System.Random();
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
                    enemyGO = Instantiate(enemyPrefab1, new Vector3(-0.86f, -1.56f, -3.08f), Quaternion.identity);
                    enemyUnit = enemyGO.GetComponent<Unit>();
                    enemyGO.SetActive(true);
                    enemyUnit.EC.Look(who);
                break; }
            case 2:
                {
                    enemyGO = Instantiate(enemyPrefab2, new Vector3(-0.86f, -1.56f, -3.08f), Quaternion.identity);
                    enemyUnit = enemyGO.GetComponent<Unit>();
                    enemyGO.SetActive(true);
                    enemyUnit.EC.Look(who);
                    break;
                }
            case 3:
                {
                    enemyGO = Instantiate(enemyPrefab3, new Vector3(-0.86f, -1.56f, -3.08f), Quaternion.identity);
                    enemyUnit = enemyGO.GetComponent<Unit>();
                    enemyGO.SetActive(true);
                    enemyUnit.EC.Look(who);
                    break;
                }
            case 4:
                {
                    enemyGO = Instantiate(enemyPrefab4, new Vector3(-0.86f, -1.56f, -3.08f), Quaternion.identity);
                    enemyUnit = enemyGO.GetComponent<Unit>();
                    enemyGO.SetActive(true);
                    enemyUnit.EC.Look(who);
                    break;
                }
            case 5:
                {
                    enemyGO = Instantiate(enemyPrefab5, new Vector3(-0.86f, -1.56f, -3.08f), Quaternion.identity);
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
                    enemyGO1 = Instantiate(enemyPrefab1, new Vector3(-1.903f, -1.56f, -0.647f), Quaternion.identity);
                    enemyUnit1 = enemyGO1.GetComponent<Unit>();
                    enemyGO1.SetActive(true);
                    enemyUnit1.EC.Look(who);
                    break;
                }
            case 2:
                {
                    enemyGO1 = Instantiate(enemyPrefab2, new Vector3(-1.903f, -1.56f, -0.647f), Quaternion.identity);
                    enemyUnit1 = enemyGO1.GetComponent<Unit>();
                    enemyGO1.SetActive(true);
                    enemyUnit1.EC.Look(who);
                    break;
                }
            case 3:
                {
                    enemyGO1 = Instantiate(enemyPrefab3, new Vector3(-1.903f, -1.56f, -0.647f), Quaternion.identity);
                    enemyUnit1 = enemyGO1.GetComponent<Unit>();
                    enemyGO1.SetActive(true);
                    enemyUnit1.EC.Look(who);
                    break;
                }
            case 4:
                {
                    enemyGO1 = Instantiate(enemyPrefab4, new Vector3(-1.903f, -1.56f, -0.647f), Quaternion.identity);
                    enemyUnit1 = enemyGO1.GetComponent<Unit>();
                    enemyGO1.SetActive(true);
                    enemyUnit1.EC.Look(who);
                    break;
                }
            case 5:
                {
                    enemyGO1 = Instantiate(enemyPrefab5, new Vector3(-1.903f, -1.56f, -0.647f), Quaternion.identity);
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
                    enemyGO2 = Instantiate(enemyPrefab1, new Vector3(1.75f, -1.56f, -1.84f), Quaternion.identity);
                    enemyUnit2 = enemyGO2.GetComponent<Unit>();
                    enemyGO2.SetActive(true);
                    enemyUnit2.EC.Look(who);
                    break;
                }
            case 2:
                {
                    enemyGO2 = Instantiate(enemyPrefab2, new Vector3(1.75f, -1.56f, -1.84f), Quaternion.identity);
                    enemyUnit2 = enemyGO2.GetComponent<Unit>();
                    enemyGO2.SetActive(true);
                    enemyUnit2.EC.Look(who);
                    break;
                }
            case 3:
                {
                    enemyGO2 = Instantiate(enemyPrefab3, new Vector3(1.75f, -1.56f, -1.84f), Quaternion.identity);
                    enemyUnit2 = enemyGO2.GetComponent<Unit>();
                    enemyGO2.SetActive(true);
                    enemyUnit2.EC.Look(who);
                    break;
                }
            case 4:
                {
                    enemyGO2 = Instantiate(enemyPrefab4, new Vector3(1.75f, -1.56f, -1.84f), Quaternion.identity);
                    enemyUnit2 = enemyGO2.GetComponent<Unit>();
                    enemyGO2.SetActive(true);
                    enemyUnit2.EC.Look(who);
                    break;
                }
            case 5:
                {
                    enemyGO2 = Instantiate(enemyPrefab5, new Vector3(1.75f, -1.56f, -1.84f), Quaternion.identity);
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
                    enemyGO3 = Instantiate(enemyPrefab1, new Vector3(0.35f, -1.56f, 0.44f), Quaternion.identity);
                    enemyUnit3 = enemyGO3.GetComponent<Unit>();
                    enemyGO3.SetActive(true);
                    enemyUnit3.EC.Look(who);
                    break;
                }
            case 2:
                {
                    enemyGO3 = Instantiate(enemyPrefab2, new Vector3(0.35f, -1.56f, 0.44f), Quaternion.identity);
                    enemyUnit3 = enemyGO3.GetComponent<Unit>();
                    enemyGO3.SetActive(true);
                    enemyUnit3.EC.Look(who);
                    break;
                }
            case 3:
                {
                    enemyGO3 = Instantiate(enemyPrefab3, new Vector3(0.35f, -1.56f, 0.44f), Quaternion.identity);
                    enemyUnit3 = enemyGO3.GetComponent<Unit>();
                    enemyGO3.SetActive(true);
                    enemyUnit3.EC.Look(who);
                    break;
                }
            case 4:
                {
                    GameObject enemyGO3 = Instantiate(enemyPrefab4, new Vector3(0.35f, -1.56f, 0.44f), Quaternion.identity);
                    enemyUnit3 = enemyGO3.GetComponent<Unit>();
                    enemyGO3.SetActive(true);
                    enemyUnit3.EC.Look(who);
                    break;
                }
            case 5:
                {
                    enemyGO3 = Instantiate(enemyPrefab5, new Vector3(0.35f, -1.56f, 0.44f), Quaternion.identity);
                    enemyUnit3 = enemyGO3.GetComponent<Unit>();
                    enemyGO3.SetActive(true);
                    enemyUnit3.EC.Look(who);
                    break;
                }
            default:
                enemyUnit3 = null;
                break;
        }

        partyObject = GameObject.Find("Party");         //Makes the party an actual interactable thing
        party = partyObject.GetComponent<Party>();

        for (int i = 0; i < party.parties[1].Count; i++)            //Pass in value "1" during transition from exploration to combat. Needs to be changed later
        {
            switch (i) {
                case 0:
                    {
                        Debug.Log(party.parties[1][0].name);
                        if (party.parties[1][0].name == "Tao Kazuma")
                        {
                            playerGO = Instantiate(Nex, new Vector3(0.22f, -1.559f, -7.122f), Quaternion.identity); //player1
                            playerUnit = playerGO.GetComponent<Player>();   //TODO: Fix playerSpawns later
                            playerGO.SetActive(true);
                        }
                        else if (party.parties[1][0].name == "Haruka")
                        {
                            playerGO = Instantiate(Keese, new Vector3(0.22f, -1.559f, -7.122f), Quaternion.identity); //player1
                            playerUnit = playerGO.GetComponent<Player>();   //TODO: Fix playerSpawns later
                            playerGO.SetActive(true);
                        }
                        else if (party.parties[1][0].name == "Coco")
                        {
                            party.parties[1][0] = Coco.AddComponent<Player>();
                            playerGO = Instantiate(Coco, new Vector3(0.22f, -1.559f, -7.122f), Quaternion.identity);
                            playerUnit = playerGO.GetComponent<Player>();
                        }
                        else if (party.parties[1][0].name == "???")
                        {
                            party.parties[1][0] = Reiko.AddComponent<Player>();
                            playerGO = Instantiate(Reiko, new Vector3(0.22f, -1.559f, -7.122f), Quaternion.identity);
                            playerUnit = playerGO.GetComponent<Player>();
                        }
                        playerUnit.PC.Look(1);
                        break;
                    }
                case 1:         //Player 2 Camera needs to be implemented at 8.91 0.32 -2.71 with rotation 11.552, -82, 0 with FOV of 40
                    {
                        Debug.Log(party.parties[1][1].name);
                        if (party.parties[1][1].name == "Tao Kazuma")
                        {
                            playerGO1 = Instantiate(Nex, new Vector3(5.962f, -1.559f, -1.318f), Quaternion.identity);   //Need to test and implement positioning later
                            playerUnit1 = playerGO1.GetComponent<Player>();   //TODO: Fix playerSpawns later
                            playerGO1.SetActive(true);
                        }
                        else if (party.parties[1][1].name == "Haruka")
                        {
                            party.parties[1][1] = Keese.AddComponent<Player>();
                            playerGO1 = Instantiate(Keese, new Vector3(5.962f, -1.559f, -1.318f), Quaternion.identity);   //Need to test and implement positioning later
                            playerUnit1 = playerGO1.GetComponent<Player>();   //TODO: Fix playerSpawns later
                            playerGO1.SetActive(true);
                            //playerUnit1 = party.parties[1][1];
                        }
                        else if (party.parties[1][1].name == "Coco")
                        {
                            party.parties[1][1] = Coco.AddComponent<Player>();
                            playerGO1 = Instantiate(Coco, new Vector3(5.962f, -1.559f, -1.318f), Quaternion.identity);
                            playerUnit1 = playerGO1.GetComponent<Player>();
                        }else if (party.parties[1][1].name == "???")
                        {
                            party.parties[1][1] = Reiko.AddComponent<Player>();
                            playerGO1 = Instantiate(Reiko, new Vector3(5.962f, -1.559f, -1.318f), Quaternion.identity);
                            playerUnit1 = playerGO1.GetComponent<Player>();
                        }
                        playerUnit1.PC.Look(2);
                        break;
                    }
                case 2:         //Player 3 Camera needs to be implemented at 0.1812 0.32 7.4736 with rotation 11.552 185 0
                    {
                        Debug.Log(party.parties[1][2].name);
                        if (party.parties[1][2].name == "Tao Kazuma")
                        {
                            playerGO2 = Instantiate(Nex, new Vector3(0, 0, 0), Quaternion.identity);   //Need to test and implement positioning later
                            playerUnit2 = playerGO2.GetComponent<Player>();   //TODO: Fix playerSpawns later
                            playerGO2.SetActive(true);
                        }
                        else if (party.parties[1][2].name == "Haruka")
                        {
                            party.parties[1][2] = Keese.AddComponent<Player>();
                            playerGO2 = Instantiate(Keese, new Vector3(0, 0, 0), Quaternion.identity);   //Need to test and implement positioning later
                            playerUnit2 = playerGO2.GetComponent<Player>();   //TODO: Fix playerSpawns later
                            playerGO2.SetActive(true);
                            //playerUnit1 = party.parties[1][1];
                        }
                        else if (party.parties[1][2].name == "Coco")
                        {
                            party.parties[1][2] = Coco.AddComponent<Player>();
                            playerGO2 = Instantiate(Coco, new Vector3(0, 0, 0), Quaternion.identity);
                            playerUnit2 = playerGO2.GetComponent<Player>();
                        }
                        else if (party.parties[1][2].name == "???")
                        {
                            party.parties[1][2] = Reiko.AddComponent<Player>();
                            playerGO2 = Instantiate(Reiko, new Vector3(0, 0, 0), Quaternion.identity);
                            playerUnit2 = playerGO2.GetComponent<Player>();
                        }
                        playerUnit2.PC.Look(3);
                        break;
                    }
                case 3:
                    {
                        Debug.Log(party.parties[1][3].name);
                        if (party.parties[1][3].name == "Tao Kazuma")
                        {
                            playerGO3 = Instantiate(Nex, new Vector3(0, 0, 0), Quaternion.identity);   //Need to test and implement positioning later
                            playerUnit3 = playerGO3.GetComponent<Player>();   //TODO: Fix playerSpawns later
                            playerGO3.SetActive(true);
                        }
                        else if (party.parties[1][3].name == "Haruka")
                        {
                            party.parties[1][3] = Keese.AddComponent<Player>();
                            playerGO3 = Instantiate(Keese, new Vector3(0, 0, 0), Quaternion.identity);   //Need to test and implement positioning later
                            playerUnit3 = playerGO3.GetComponent<Player>();   //TODO: Fix playerSpawns later
                            playerGO3.SetActive(true);
                            //playerUnit1 = party.parties[1][1];
                        }
                        else if (party.parties[1][3].name == "Coco")
                        {
                            party.parties[1][3] = Coco.AddComponent<Player>();
                            playerGO3 = Instantiate(Coco, new Vector3(0, 0, 0), Quaternion.identity);
                            playerUnit3 = playerGO3.GetComponent<Player>();
                        }
                        else if (party.parties[1][3].name == "???")
                        {
                            party.parties[1][3] = Reiko.AddComponent<Player>();
                            playerGO3 = Instantiate(Reiko, new Vector3(0, 0, 0), Quaternion.identity);
                            playerUnit3 = playerGO3.GetComponent<Player>();
                        }
                        playerUnit3.PC.Look(4);
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
        

        yield return new WaitForSeconds(2);     //This allows the setup of the battle, then makes us wait 2 seconds.
        nextTurn();
    }

    public void PlayerTurn() {
        if (enemyUnit)
            enemyUnit.EC.Look(who);
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
            Circle.SetActive(true);
        }
       
        
    }

    public void OnPhysicalAttack() {
        GameObject goSelect = GameObject.Find("Select");
        Select = goSelect.GetComponent<AudioSource>();
        Select.Play();

        AtPanel.SetActive(false);
        StartCoroutine(PlayerAttack(0));
    }

    public void OnGunAttack()
    {
        GameObject goSelect = GameObject.Find("Select");
        Select = goSelect.GetComponent<AudioSource>();
        Select.Play();
        GameObject goPanel = GameObject.Find("AttackMenu");
        goPanel.SetActive(false);
        //AtPanel.SetActive(false);
        StartCoroutine(PlayerAttack(1));
    }

    //Applies guarding effect
    public void OnGuard() {
        Circle.SetActive(false);
        playerUnit.guard = true;
        nextTurn();
    }

    //Button scripts for Skills begins here
    //public void clickPhys(int level)
    //{
    //    Spells skill = new Spells();
    //    int power;
    //    bool isMagic;
    //    power = skill.Phys(level);
    //    isMagic = false;
    //    magicChecker(power, 0, isMagic, skill);
    //}

    //public void clickGun(int level)
    //{
    //    Spells skill = new Spells();
    //    int power;
    //    bool isMagic;
    //    power = skill.Fire(level);
    //    isMagic = false;
    //    magicChecker(power, 1, isMagic, skill);
    //}
    //public void clickFire(int level)
    //{
    //    Spells skill = new Spells();
    //    int power;
    //    bool isMagic;
    //    power = skill.Fire(level);
    //    isMagic = true;
    //    magicChecker(power, 2, isMagic, skill);
    //}

    //public void clickIce(int level)
    //{
    //    Spells skill = new Spells();
    //    int power;
    //    bool isMagic;
    //    power = skill.Ice(level);
    //    isMagic = true;
    //    magicChecker(power, 3, isMagic, skill);
    //}

    //public void clickLightning(int level)
    //{
    //    Spells skill = new Spells();
    //    int power;
    //    bool isMagic;
    //    power = skill.Lightning(level);
    //    isMagic = true;
    //    magicChecker(power, 4, isMagic, skill);
    //}

    //public void clickWind(int level)
    //{
    //    Spells skill = new Spells();
    //    int power;
    //    bool isMagic;
    //    power = skill.Wind(level);
    //    isMagic = true;
    //    magicChecker(power, 5, isMagic, skill);
    //}

    //public void clickPsychic(int level)
    //{
    //    Spells skill = new Spells();
    //    int power;
    //    bool isMagic;
    //    power = skill.Psychic(level);
    //    isMagic = true;
    //    magicChecker(power, 6, isMagic, skill);
    //}

    //public void clickNuclear(int level)
    //{
    //    Spells skill = new Spells();
    //    int power;
    //    bool isMagic;
    //    power = skill.Nuclear(level);
    //    isMagic = true;
    //    magicChecker(power, 7, isMagic, skill);
    //}

    //public void clickBless(int level)
    //{
    //    Spells skill = new Spells();
    //    int power;
    //    bool isMagic;
    //    power = skill.Bless(level);
    //    isMagic = true;
    //    magicChecker(power, 8, isMagic, skill);
    //}

    //public void clickCurse(int level)
    //{
    //    Spells skill = new Spells();
    //    int power;
    //    bool isMagic;
    //    power = skill.Curse(level);
    //    isMagic = true;
    //    magicChecker(power, 9, isMagic, skill);
    //}
    //Button scripts for skills ends here

    //Checks for what cost to apply
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
                GameObject goPanel = GameObject.Find("PersonaMenu");
                goPanel.SetActive(false); // already a game object
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
        float damage = enemyDamageCalculator();
        
        int playerIsDead = playerUnit.TakeDamage(damage, rng);
        //Player HP Bar changes
        switch(playerIsDead){
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
                int enemyIsDead = enemyUnit.TakeDamage(damage, rng);
                //Enemy HP Bar Changes
                if (enemyIsDead == 0)
                {
                    //Destroy(enemyUnit);
                    state = BattleState.WON;
                    EndBattle();
                }
                nextTurn();
                break;
            case 4:
                if ((playerUnit.unconscious || !playerUnit) && (playerUnit1.unconscious || !playerUnit1) && (playerUnit2.unconscious || !playerUnit2) && (playerUnit3.unconscious || !playerUnit3))
                {
                    yield return new WaitForSeconds(2);
                    state = BattleState.LOST;
                    EndBattle();
                }
                else
                    oneMore();
                break;

            default:
                nextTurn();
                break;
        }
    }

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
    float enemyDamageCalculator() {
        float damage = 5;
        if (playerUnit.guard)
        {
            damage = damage / 2;
            playerUnit.guard = false;   //Implement into Enemy damage calculator
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
                            //enemyUnit = GameObject.transform.LookAt(playerUnit);
                            who = 1;
                            state = BattleState.PLAYER1TURN;
                            PlayerTurn();
                        }
                        else if (playerUnit1 && !playerUnit1.unconscious)
                        {
                            who = 2;
                            state = BattleState.PLAYER2TURN;
                            PlayerTurn();
                        }
                        else if (playerUnit2 && !playerUnit2.unconscious)
                        {
                            who = 3;
                            state = BattleState.PLAYER3TURN;
                            PlayerTurn();
                        }
                        else if (playerUnit3 && !playerUnit3.unconscious)
                        {
                            who = 4;
                            state = BattleState.PLAYER4TURN;
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
                            who = 2;
                            state = BattleState.PLAYER2TURN;
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
                            who = 3;
                            state = BattleState.PLAYER3TURN;
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
                            who = 4;
                            state = BattleState.PLAYER4TURN;
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
                            who = 2;
                            state = BattleState.PLAYER2TURN;
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
                            who = 3;
                            state = BattleState.PLAYER3TURN;
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
                            who = 4;
                            state = BattleState.PLAYER4TURN;
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
                            who = 1;
                            state = BattleState.PLAYER1TURN;
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
                            who = 3;
                            state = BattleState.PLAYER3TURN;
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
                            who = 4;
                            state = BattleState.PLAYER4TURN;
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
                            who = 1;
                            state = BattleState.PLAYER1TURN;
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
                            who = 3;
                            state = BattleState.PLAYER3TURN;
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
                            who = 4;
                            state = BattleState.PLAYER4TURN;
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
                            who = 1;
                            state = BattleState.PLAYER1TURN;
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
                            who = 2;
                            state = BattleState.PLAYER2TURN;
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
                            who = 4;
                            state = BattleState.PLAYER4TURN;
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
                            who = 1;
                            state = BattleState.PLAYER1TURN;
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
                            who = 2;
                            state = BattleState.PLAYER2TURN;
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
                            who = 4;
                            state = BattleState.PLAYER4TURN;
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
                            who = 1;
                            state = BattleState.PLAYER1TURN;
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
                            who = 2;
                            state = BattleState.PLAYER2TURN;
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
                            who = 3;
                            state = BattleState.PLAYER3TURN;
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
                            who = 1;
                            state = BattleState.PLAYER1TURN;
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
                            who = 2;
                            state = BattleState.PLAYER2TURN;
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
                            who = 3;
                            state = BattleState.PLAYER3TURN;
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
                            who = 1;
                            state = BattleState.PLAYER1TURN;
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
                            who = 2;
                            state = BattleState.PLAYER2TURN;
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
                            who = 3;
                            state = BattleState.PLAYER3TURN;
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
                            who = 4;
                            state = BattleState.PLAYER4TURN;
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
        victory.Play();
    }
}
