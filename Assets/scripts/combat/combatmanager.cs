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
    public int amountcardsleft;

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

    void Start()
    {
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
            Playerhealthfill = GameObject.Find("Cenergyplayerfilled").GetComponent<Image>();

        }
        if (Enemyhealthfill == null)
        {
            Playerhealthfill = GameObject.Find("Chealthenemyfilled").GetComponent<Image>();

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
        battlestart();
    }
    void battlestart()
    {
        //decksinplay = new Deck[amountparticipants];
        decksinplay[0].deckinuse = decksinplay[0].decksaved.ToList();
        decksinplay[1].deckinuse = decksinplay[1].decksaved.ToList();
        amountcardsleft = decksinplay[0].deckinuse.Count;
        turn = 1;
        subturn = 0;
        whoseturn = 0;

        shufflecard(decksinplay[0]);
        shufflecard(decksinplay[1]);
        drawcards(0, 5);
        drawcards(1, 5);
        determinfirst();
        bool start = true;
        startturn(whoseturn,start);
    }
    public void Displayplayerhand()
    {

        for (int i = 0; i < playerhand.Count; i++)
        {
            if (playerhandobjs.Count < playerhand.Count)
            {
                int index = i;
                GameObject tmpcard = Instantiate(cardprefab);
                Destroy(tmpcard.GetComponent<Combatcard>());
                Component addedComponent = tmpcard.AddComponent(playerhand[i].GetType());
                var script = addedComponent as Combatcard;
                if (script != null)
                {
                    script.cardimage = playerhand[i].cardimage;
                    script.name = playerhand[i].name;
                    script.description = playerhand[i].description;
                    script.energyCost = playerhand[i].energyCost;
                    tmpcard.transform.Find("Cardname").GetComponent<TMP_Text>().text = script.name;
                    tmpcard.transform.Find("Carddescription").GetComponent<TMP_Text>().text = script.description;
                    tmpcard.transform.Find("Costbg").transform.Find("Costtxt").GetComponent<TMP_Text>().text = "" + script.energyCost;
                    tmpcard.transform.Find("cardimageslot").transform.Find("cardimage").GetComponent<Image>().sprite = script.cardimage;
                }
                else
                {
                    Debug.LogError("player hand Failed to cast the added component to the appropriate type.");
                }
                tmpcard.transform.SetParent(GameObject.Find("playerhand").transform);
                tmpcard.transform.localScale = new Vector3(4.41616869f, 4.52701521f, 4.52701521f);
                tmpcard.GetComponent<Button>().GetComponent<Button>().onClick.AddListener(() => sellecting(index));
                playerhandobjs.Add(tmpcard);
            }
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
            midturn(whichplayer);
            subturn = 1;
        }
        else
        {
            drawcards(whichplayer, 1);
            midturn(whichplayer);
            subturn = 1;
            Debug.Log("startturn");

        }
    }
    public void midturn(int whichplayer)
    {
        if(whichplayer != 0)
        {
            Debug.Log("mudturn");
            //ai
            if (pause == false)
            {
                int randomnumber = Random.Range(0, enemyhand.Count -1);
                if (enemyhandobjs[randomnumber] != null)
                {
                    usecard(whichplayer, enemyhand[randomnumber]);//does only do 1 attack for now
                    endturn(whichplayer);
                    subturn = 2;
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

        subturn = 0;
        whoseturn++;
        if (whoseturn > amountparticipants-1)
        {
            whoseturn = 0;
            turn++;
        }
        startturn(whoseturn,false);

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

        // Draw the specified number of cards from the deck and add them to the player's hand
        for (int i = 0; i < amountcards; i++)
        {
            if (sellecteddeck.deckinuse.Count > 0)
            {
                // Remove the top card from the deck and add it to the player's hand
                Combatcard cardDrawn = sellecteddeck.deckinuse[0];
                hand.Add(cardDrawn);
                sellecteddeck.deckinuse.RemoveAt(0);
                amountcardsleft = decksinplay[0].deckinuse.Count;

            }
            else
            {
                // If there are no more cards in the deck, print a message to the console
                Debug.Log("No more cards in deck!");
            }
        }
        Displayplayerhand();
        Displayenemyhand();
    }
    public void usecard(int whichplayer, Combatcard usedcard)
    {
        usedcard.Use(whichplayer);
        usedcard.used = true;
        Bigcard.SetActive(false);

        add2graveyard(whichplayer,usedcard);
    }
    public void sellecting(int n)
    {
        //tmp
        // whoseturn = 0;
        int F = n ;
        Debug.Log(F);
        if (whoseturn == 0)
        {
            if (playerhand[F] != null)
            {
                Bigcard.SetActive(true);
                BigcardCastbutton.SetActive(true);

                Bigcard.transform.Find("Carddescription").GetComponent<TMP_Text>().text = playerhand[F].description;
                Bigcard.transform.Find("Costbg").transform.Find("Costtxt").GetComponent<TMP_Text>().text = "" + playerhand[F].energyCost;
                Bigcard.transform.Find("cardimageslot").transform.Find("cardimage").GetComponent<Image>().sprite = playerhand[F].cardimage;

                Bigcard.transform.Find("Cardname").GetComponent<TMP_Text>().text = playerhand[F].name;
                BigcardCastbutton.GetComponent<Button>().onClick.RemoveAllListeners();
                BigcardCastbutton.GetComponent<Button>().onClick.AddListener(() => usecard(whoseturn, playerhand[F]));

            }
        }

        else
        {
            if (Bigcard.transform.Find("Cardname").GetComponent<TMP_Text>().text != playerhand[F].name)
            {
                Bigcard.transform.Find("Carddescription").GetComponent<TMP_Text>().text = playerhand[F].description;
                Bigcard.transform.Find("Costbg").transform.Find("Costtxt").GetComponent<TMP_Text>().text = "" + playerhand[F].energyCost;
                Bigcard.transform.Find("cardimageslot").transform.Find("cardimage").GetComponent<Image>().sprite = playerhand[F].cardimage;

                Bigcard.transform.Find("Cardname").GetComponent<TMP_Text>().text = playerhand[F].name;
            }

        }
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

    void Update()
    {
        if(whoseturn != 0)
        {
            if (Bigcard.activeSelf == true)
            {
                //TODO show card enemy plays
            }
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
   
        if(Bigcard.activeSelf == true)
        {
            
        }
    }
    void trackstats()
    {
        
        Playerhealthfill.fillAmount = playerstats.health / playerstats.maxhealth;
       // Enemyhealthfill.fillAmount = enemystats.health / enemystats.maxhealth;
        playername.text = playerstats.playername;


    }
    public void endturnbutton()
    {
        subturn = 2;
        endturn(whoseturn);
    }
}
