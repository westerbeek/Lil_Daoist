using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;

public class combatmanager : MonoBehaviour
{
    public GameObject scripthub;
    public rewards reward;
    public bool gotfighters;
    public int turn;
    public int subturn;//0draw phase//1 playface// 2 end phase//3 other turn
    public int whoseturn;//0player//1other
    public bool whobegins;//true = player

    public int amountparticipants;
    public int[] healths;//0 = player
    public float[] energys;
    public float[] maxenergys;

    public List<Combatcard> playerhand;
    public bool isenemyai = true;
    public List<Combatcard> enemyhand;
    public List<Combatcard> playergraveyard;
    public List<Combatcard> enemygraveyard;

    public GameObject cardprefab;
    public GameObject enemycardprefab;
    public List<GameObject> playerhandobjs;
    public List<GameObject> enemyhandobjs;
    public List<Deck> decksinplay;
    public int[] amountcardsleft;

    public Combatcard sellectedcard;
    public GameObject Bigcard;
    public GameObject BigcardCastbutton;
    public bool pause;
    // Start is called before the first frame update
    public Image Playerhealthfill;
    public Image PlayerEnergyfill;
    public Image Enemyhealthfill;
    public Enemy enemystats;
    public Player playerstats;
    public TMP_Text playername;
    public TMP_Text Enemyname;
    public bool combatactive;

    private bool startofthegame;
    public int playeramountcardsplayed;
    public int playermaxcardsplayable;
    public int enemyamountcardsplayed;
    public int enemymaxcardsplayable;

    private bool pickcardonce;
    private int randomnumber;
    [SerializeField]private bool next;
    [SerializeField]private bool showenemycard;

    //objects
    public GameObject canvas;
    public GameObject combatarena;
    public GameObject winlossscreen;
    public GameObject wintext;
    public GameObject losetext;
    private bool addrewards;
    void Start()
    {

        winlossscreen = GameObject.Find("winloss");
        wintext = GameObject.Find("CWintext");
        losetext = GameObject.Find("CLosetext");
        reward = GameObject.Find("UIhub").GetComponent<rewards>();
        winlossscreen.SetActive(false);
        enemymaxcardsplayable = 1;
        playermaxcardsplayable = 99;
        amountcardsleft = new int[2];
        scripthub = GameObject.Find("ScriptHub");
        if(playerstats == null)
        {
            playerstats = scripthub.GetComponent<Player>();
        }
        if(enemystats == null)
        {
            enemystats = GameObject.Find("Enemy").GetComponent<Enemy>();
        }
        if(Playerhealthfill == null)
        {
            Playerhealthfill = GameObject.Find("Chealthplayerfilled").GetComponent<Image>();
        }
        if(PlayerEnergyfill == null)
        {
            PlayerEnergyfill = GameObject.Find("Cenergyplayerfilled").GetComponent<Image>();

        }
        if (Enemyhealthfill == null)
        {
            Enemyhealthfill = GameObject.Find("Chealthenemyfilled").GetComponent<Image>();

        }
        if (playername == null)
        {
            playername = GameObject.Find("CPlayerName").GetComponent<TMP_Text>();
        }
        if (Enemyname == null)
        {
            Enemyname = GameObject.Find("CEnemyName").GetComponent<TMP_Text>();
        }
        Bigcard = GameObject.Find("LargeCard");
        BigcardCastbutton = GameObject.Find("CombatCastButton");
        Bigcard.SetActive(false);
        playerstats = scripthub.GetComponent<Player>();
        combatarena = GameObject.Find("combat");
        canvas = GameObject.Find("Combatcanvas");

        combatarena.SetActive(false);
        canvas.SetActive(false);

        //GameObject.Find("Combatcanvas").SetActive(false);
    }
    void battlestart()
    {
        winlossscreen.SetActive(false);
        addrewards = false;
        //decksinplay = new Deck[amountparticipants];
        foreach (GameObject obj in playerhandobjs)
        {
            Destroy(obj);
        }
        foreach (GameObject obj in enemyhandobjs)
        {
            Destroy(obj);
        }
        // Clear the list

        playerhandobjs.Clear();
        enemyhandobjs.Clear();
        playerhand.Clear();
        enemyhand.Clear();
        decksinplay[0].deckinuse = decksinplay[0].decksaved.ToList();
        decksinplay[1].deckinuse = decksinplay[1].decksaved.ToList();
        amountcardsleft[0] = decksinplay[0].deckinuse.Count;
        amountcardsleft[1] = decksinplay[1].deckinuse.Count;
        turn = 1;
        subturn = 0;
        whoseturn = 0;
        enemystats.health = enemystats.maxhealth;

        shufflecard(decksinplay[0]);
        shufflecard(decksinplay[1]);
        drawcards(0, 5);
        drawcards(1, 5);
        determinfirst();
        pickcardonce = false;
        startofthegame = true;

    }
    public void Displayplayerhand()
    {

        for (int i = 0; i < playerhand.Count; i++)
        {
            int index = i;
            GameObject tmpcard = null;

            if (i < playerhandobjs.Count)
            {
                // Use the existing card object from the playerhandobjs list
                tmpcard = playerhandobjs[i];
            }
            else
            {
                // Create a new card object
                tmpcard = GameObject.Instantiate(cardprefab, GameObject.Find("playerhand").transform);
                playerhandobjs.Add(tmpcard);
            }

            Destroy(tmpcard.GetComponent<Combatcard>());
            Component addedComponent = tmpcard.AddComponent(playerhand[i].GetType());
            var script = addedComponent as Combatcard;

            if (script != null)
            {
                // Update the card properties
                script.cardimage = playerhand[i].cardimage;
                script.name = playerhand[i].name;
                script.description = playerhand[i].description;
                script.energyCost = playerhand[i].energyCost;

                TMP_Text cardNameText = tmpcard.transform.Find("cardimageslot").transform.Find("Cardname").GetComponent<TMP_Text>();
                TMP_Text cardDescriptionText = tmpcard.transform.Find("Carddescription").GetComponent<TMP_Text>();
                TMP_Text costText = tmpcard.transform.Find("Costbg").transform.Find("Costtxt").GetComponent<TMP_Text>();
                Image cardImage = tmpcard.transform.Find("cardimageslot").transform.Find("cardimage").GetComponent<Image>();

                cardNameText.text = script.name;
                cardDescriptionText.text = script.description;
                costText.text = script.energyCost.ToString();
                cardImage.sprite = script.cardimage;
            }
            else
            {
                Debug.LogError("Player hand failed to cast the added component to the appropriate type.");
            }

            tmpcard.transform.localScale = new Vector3(4.41616869f, 4.52701521f, 4.52701521f);
            tmpcard.GetComponent<Button>().onClick.RemoveAllListeners();
            tmpcard.GetComponent<Button>().onClick.AddListener(() => sellecting(index));
        }
    }
    public void Displayenemyhand()
    {

        for (int i = 0; i < enemyhand.Count; i++)
        {
            if (enemyhandobjs.Count < enemyhand.Count)
            {
                int index = i;
                GameObject tmpcard = Instantiate(enemycardprefab);
                Destroy(tmpcard.GetComponent<Combatcard>());
                Component addedComponent = tmpcard.AddComponent(enemyhand[i].GetType());
                var script = addedComponent as Combatcard;
                if (script != null)
                {
                    script.cardimage = enemyhand[i].cardimage;
                    script.name = enemyhand[i].name;
                    script.description = enemyhand[i].description;
                    script.energyCost = enemyhand[i].energyCost;
                }
                else
                {
                    Debug.LogError("enemy hand Failed to cast the added component to the appropriate type.");
                }
                tmpcard.transform.SetParent(GameObject.Find("enemyhand").transform);
                tmpcard.transform.localScale = new Vector3(4.41616869f, 4.52701521f, 4.52701521f);
                // tmpcard.GetComponent<Button>().GetComponent<Button>().onClick.AddListener(() => sellecting(index));
                enemyhandobjs.Add(tmpcard);
            }
        }
    }
    public void startturn(int whichplayer,bool startofgame)
    {
        if(startofgame == true)
        {
            startofthegame = false;
            subturn = 1;
            Debug.Log("startofgame");

        }
        else
        {
            drawcards(whichplayer, 1);
            subturn = 1;
            Debug.Log("startturn");

        }
    }
    public void midturn(int whichplayer)
    {

        if (whichplayer == 0)
        {
            if (next == true)
            {
                subturn = 2;
                next = false;
            }
        }
        else
        {
            Debug.Log("mudturn");
            //ai
            if (pause == false)
            {
               
                if (pickcardonce == false)
                {
                    randomnumber = Random.Range(0, enemyhand.Count - 1);
                    pickcardonce = true;
                }
                if (enemymaxcardsplayable > enemyamountcardsplayed && pickcardonce == true)
                {
                    if (enemyhandobjs[randomnumber] != null)
                    {
                        if (showenemycard == false)
                        {
                            sellecting(randomnumber);
                            Debug.Log("enemy using card no.  "+randomnumber);
                        }
                        else
                        {
                            if (next == true)
                            {
                                usecard(whichplayer, enemyhand[randomnumber]);//does only do 1 attack for now
                                enemyamountcardsplayed++;
                                pickcardonce = false;
                                if(enemymaxcardsplayable == enemyamountcardsplayed)
                                {
                                    showenemycard = false;

                                    subturn = 2;

                                }
                                next = false;
                            }

                            //
                        }
                    }
                }
                else
                {
                    if (next == true)
                    {
                        usecard(whichplayer, enemyhand[randomnumber]);//does only do 1 attack for now
                        enemyamountcardsplayed++;
                        showenemycard = false;

                        pickcardonce = false;
                        subturn = 2;
                        next = false;
                    }
                }
            }
        }
    }
    public IEnumerator waitforframe()
    {
        yield return new WaitForEndOfFrame();
    }
    public void endturn(int whichplayer)
    {
       Debug.Log("endturn");
        if(whichplayer == 0)
        {
            playerstats.energy += 20;
        }
        else
        {
            enemystats.energy += 20;
        }
        subturn = 0;
        whoseturn++;
        if (whoseturn > amountparticipants-1)
        {
            whoseturn = 0;
            turn++;
        }
        enemyamountcardsplayed = 0;
        playeramountcardsplayed = 0;
        pickcardonce = false;
                        showenemycard = false;

        next = false;
        Displayenemyhand();
        Displayplayerhand();
    }
    public void determinfirst()
    {
        whoseturn = Random.Range(0, amountparticipants);//TODO ACTUALLY MAKE THIS STAT BASED OR SOMETHING ELSE
    }
    // Update is called once per frame
    public void shufflecard(Deck sellecteddeck)
    {
        
        int length = sellecteddeck.deckinuse.Count;
        for (int i = 0; i < length; i++)
        {
            int rand = Random.Range(i, length);
            Combatcard temp = sellecteddeck.deckinuse[i];
            sellecteddeck.deckinuse[i] = sellecteddeck.deckinuse[rand];
            sellecteddeck.deckinuse[rand] = temp;
        }
    }
    public void drawcards(int whichplayer, int amountcards)
    {
        // Determine which hand to modify and which deck to draw from
        List<Combatcard> hand = whichplayer == 0 ? playerhand : enemyhand;
        Deck sellecteddeck = whichplayer == 0 ? decksinplay[0] : decksinplay[1];
        List<Combatcard> graveyard = whichplayer == 0 ? playergraveyard : enemygraveyard;

        // Draw the specified number of cards from the deck and add them to the player's hand
        for (int i = 0; i < amountcards; i++)
        {
            if (sellecteddeck.deckinuse.Count > 0)
            {
                // Remove the top card from the deck and add it to the player's hand
                Combatcard cardDrawn = sellecteddeck.deckinuse[0];
                hand.Add(cardDrawn);
                sellecteddeck.deckinuse.RemoveAt(0);
                amountcardsleft[whichplayer] = decksinplay[whichplayer].deckinuse.Count;

            }
            else
            {
                sellecteddeck.deckinuse = graveyard.ToList();
                amountcardsleft[whichplayer] = decksinplay[whichplayer].deckinuse.Count;


                graveyard.Clear();

                shufflecard(sellecteddeck);
                 
                
                // If there are no more cards in the deck, print a message to the console
                Debug.Log("No more cards in deck!");

            }
        }
        Displayplayerhand();
        Displayenemyhand();
    }
    public void usecard(int whichplayer, Combatcard usedcard)
    {
        if (whichplayer == 0)
        {
            if (usedcard.energyCost <= playerstats.energy)
            {
                usedcard.Use(whichplayer);
                usedcard.used = true;
                add2graveyard(whichplayer, usedcard);
                Bigcard.SetActive(false);
                playerstats.energy -= usedcard.energyCost;
            }
        }
        else
        {
            usedcard.Use(whichplayer);
            usedcard.used = true;
            add2graveyard(whichplayer, usedcard);
            Bigcard.SetActive(false);
        }

    }
    public void sellecting(int n)
    {
        //tmp

        Displayplayerhand();
        Displayenemyhand();
        // whoseturn = 0;
        int F = n ;
        Debug.Log(F);
        if (whoseturn == 0)//player
        {
            if (playerhand[F] != null)
            {
                Bigcard.SetActive(true);
                BigcardCastbutton.SetActive(true);

                Bigcard.transform.Find("Carddescription").GetComponent<TMP_Text>().text = playerhand[F].description;
                Bigcard.transform.Find("Costbg").transform.Find("Costtxt").GetComponent<TMP_Text>().text = "" + playerhand[F].energyCost;
                Bigcard.transform.Find("cardimageslot").transform.Find("cardimage").GetComponent<Image>().sprite = playerhand[F].cardimage;

                Bigcard.transform.Find("cardimageslot").transform.Find("Cardname").GetComponent<TMP_Text>().text = playerhand[F].name;
                BigcardCastbutton.GetComponent<Button>().onClick.RemoveAllListeners();
                BigcardCastbutton.GetComponent<Button>().onClick.AddListener(() => usecard(whoseturn, playerhand[F]));
                Bigcard.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            }
        }

        else//enemy
        {
            Bigcard.SetActive(true);
            BigcardCastbutton.SetActive(false);

            if (Bigcard.transform.Find("cardimageslot").transform.Find("Cardname").GetComponent<TMP_Text>().text != enemyhand[F].name)
            {
                Bigcard.transform.Find("Carddescription").GetComponent<TMP_Text>().text = enemyhand[F].description;
                Bigcard.transform.Find("Costbg").transform.Find("Costtxt").GetComponent<TMP_Text>().text = "" + enemyhand[F].energyCost;
                Bigcard.transform.Find("cardimageslot").transform.Find("cardimage").GetComponent<Image>().sprite = enemyhand[F].cardimage;

                Bigcard.transform.Find("cardimageslot").transform.Find("Cardname").GetComponent<TMP_Text>().text = enemyhand[F].name;
                Bigcard.GetComponent<Image>().color = new Color32(255,100,100,255);
            }
            showenemycard = true;
        }

        Displayplayerhand();
        Displayenemyhand();
    }
    public void disgardcard(int whichplayer, Combatcard disgardcard)
    {
        disgardcard.Disgard(whichplayer);
        add2graveyard(whichplayer,disgardcard);
    }
    public void add2graveyard(int whichplayer, Combatcard card)
    {
        bool once= false;
        if (once == false)
        {
            List<Combatcard> hand = whichplayer == 0 ? playerhand : enemyhand;
            List<GameObject> handobj = whichplayer == 0 ? playerhandobjs : enemyhandobjs;
            List<Combatcard> graveyard = whichplayer == 0 ? playergraveyard : enemygraveyard;

            int index = hand.IndexOf(card);
            if (index >= 0 && index < handobj.Count)
            {
                GameObject objToRemove = handobj[index];
                hand.Remove(card);
                handobj.RemoveAt(index);
                graveyard.Add(card);
                Destroy(objToRemove);
            }
            else
            {
                Debug.Log(enemyhand.Count +" and "+ enemyhandobjs.Count);
                Debug.LogError("Index: "+ index+" __Failed to find the corresponding GameObject in handobj list.");
            }
            Displayplayerhand();
            Displayenemyhand();
        }
    }

    public void activatecombat()
    {
        combatarena.SetActive(true);
        canvas.SetActive(true);

        playerstats.health = playerstats.maxhealth;
        enemystats.health = enemystats.maxhealth;
        battlestart();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            combatarena.SetActive(true);
            canvas.SetActive(true);

            playerstats.health = playerstats.maxhealth;
            enemystats.health = enemystats.maxhealth;
            battlestart();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            playerstats.health = 0;
           
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            enemystats.health = 0;
        }
        if (subturn == 0)
        {
            startturn(whoseturn, startofthegame);
        }
        if (subturn == 1)
        {
            midturn(whoseturn);
        }
        if (subturn == 2)
        {
            endturn(whoseturn);
        }
        
        Displayplayerhand();
        Displayenemyhand();
        trackstats();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            drawcards(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            disgardcard(0, playerhand[playerhand.Count - 1]);

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            usecard(0, playerhand[playerhand.Count - 1]);

        }
   
    }
    void trackstats()
    {
        
        Playerhealthfill.fillAmount = playerstats.health / playerstats.maxhealth;
        PlayerEnergyfill.fillAmount = playerstats.energy / playerstats.maxenergy;
        Enemyhealthfill.fillAmount = enemystats.health / enemystats.maxhealth;
        playername.text = playerstats.playername;
        Enemyname.text = enemystats.playername;

        if(playerstats.health <= 0)
        {
            endcombat(false);

        }
        if (enemystats.health <= 0)
        {
            endcombat(true);


        }
    }
    public void Nextbutton()
    {
        next = true;
        //subturn = 2;
        //endturn(whoseturn);
    }

    public void endcombat(bool winloss)
    {
        
        if (winloss == true)
        {
            Debug.Log("victory!");
            winlossscreen.SetActive(true);
            wintext.SetActive(true);
            losetext.SetActive(false);

            // reward screen
            if (addrewards == false)
            {
                if (decksinplay[1].finalloot.Count >= 1)
                {
                    for (int i = 0; i < decksinplay[1].finalloot.Count; i++)
                    {
                        reward.Addrewards(decksinplay[1].finalloot[i].id, decksinplay[1].finalloot[i].name, decksinplay[1].amounts[i], decksinplay[1].finalloot[i].Quality);
                    }
                }
                decksinplay[1].finalloot.Clear();

                reward.showrewards(reward.revealint);
                addrewards = true;
            }
            //close combat

        }
        else
        {
            Debug.Log("Loser!");
            //lose screen
            //close combat
            winlossscreen.SetActive(true);
            wintext.SetActive(false);
            losetext.SetActive(true);
        }
    }
    public void endcombatbutton()
    {
        winlossscreen.SetActive(false);

        combatarena.SetActive(false);
        canvas.SetActive(false);
    }
}
