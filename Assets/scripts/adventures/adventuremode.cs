using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class adventuremode : MonoBehaviour
{
    [SerializeField] private bool Activated;
    public bool activated { get => Activated; set => Activated = value; }

    [SerializeField] private Image Map;
    public Image map { get => Map; set => Map = value; }

    [SerializeField] private GameObject Scripthub;
    public GameObject scripthub { get => Scripthub; set => Scripthub = value; }

    [SerializeField] private Player Player;
    public Player player { get => Player; set => Player = value; }

    [SerializeField] private stats Stat;
    public stats stat { get => Stat; set => Stat = value; }

    /*
    [SerializeField] private Vector2 Playercoords;
    public Vector2 playercoords { get => Playercoords; set => Playercoords = value; }

    [SerializeField] private Vector2 Headed;
    public Vector2 headed { get => Headed; set => Headed = value; }
    */

    private Vector2 mouse;

    [SerializeField] private List<Vector2> Eventlocations;
    public List<Vector2> eventlocations { get => Eventlocations; set => Eventlocations = value; }

    [SerializeField] private List<string> Eventtypes;
    public List<string> eventtypes { get => Eventtypes; set => Eventtypes = value; }

    [SerializeField] private List<bool> Known;
    public List<bool> known { get => Known; set => Known = value; }

    [SerializeField] private List<bool> Rumorconfirmed;
    public List<bool> rumorconfirmed { get => Rumorconfirmed; set => Rumorconfirmed = value; }

    [SerializeField] private List<bool> Completedevent;
    public List<bool> completedevent { get => Completedevent; set => Completedevent = value; }

    [SerializeField] private List<GameObject> Placesofinterests;
    public List<GameObject> placesofinterests { get => Placesofinterests; set => Placesofinterests = value; }

    [SerializeField] private GameObject[] Icons;
    public GameObject[] icons { get => Icons; set => Icons = value; }

    [SerializeField] private GameObject Playerlocicon;
    public GameObject playerlocicon { get => Playerlocicon; set => Playerlocicon = value; }

    [SerializeField] private GameObject Ingameplayerlocicon;
    public GameObject ingameplayerlocicon { get => Ingameplayerlocicon; set => Ingameplayerlocicon = value; }

    [SerializeField] private Vector3 Playerscale;
    public Vector3 playerscale { get => Playerscale; set => Playerscale = value; }

    [SerializeField] private bool Moving;
    public bool moving { get => Moving; set => Moving = value; }

    [SerializeField] private TMP_Text Mousecoorstxt;
    public TMP_Text mousecoorstxt { get => Mousecoorstxt; set => Mousecoorstxt = value; }

    [SerializeField] private TMP_Text Playercoordstxt;
    public TMP_Text playercoordstxt { get => Playercoordstxt; set => Playercoordstxt = value; }

    [SerializeField] private int Sellectedadventure;
    public int sellectedadventure { get => Sellectedadventure; set => Sellectedadventure = value; }

    //zoom
    [SerializeField] private float StartSize = 1;
    public float startSize { get => StartSize; set => StartSize = value; }

    [SerializeField] private float MinSize = .5f;
    public float minSize { get => MinSize; set => MinSize = value; }

    [SerializeField] private float MaxSize = 10;
    public float maxSize { get => MaxSize; set => MaxSize = value; }

    [SerializeField] private float Zoomscale;
    public float zoomscale { get => Zoomscale; set => Zoomscale = value; }

    [SerializeField] private float Timetillarival;
    public float timetillarival { get => Timetillarival; set => Timetillarival = value; }

    [SerializeField] private bool Startadventuring;
    private bool startadventuring { get => Startadventuring; set => Startadventuring = value; }

    [SerializeField] private bool Reachedbool;
    private bool reachedbool { get => Reachedbool; set => Reachedbool = value; }

    [SerializeField] private bool Setdestination;
    public bool setdestination { get => Setdestination; set => Setdestination = value; }

    [SerializeField] private bool Adventuring;
    public bool adventuring { get => Adventuring; set => Adventuring = value; }

    [SerializeField] private TMP_Text Timetilltxt;
    public TMP_Text timetilltxt { get => Timetilltxt; set => Timetilltxt = value; }

    // Start is called before the first frame update
    void Awake()
    {
        //tmp
        Activated = true;
        //tmp

        zoomscale = .5f;
        Reachedbool = false;
        Scripthub = GameObject.Find("ScriptHub");
        Player = scripthub.GetComponent<Player>();
        Stat = scripthub.GetComponent<Player>();
        Mousecoorstxt = GameObject.Find("Adventuremousecoordstxt").GetComponent<TMP_Text>();
        Map = GameObject.Find("AdventureMap").GetComponent<Image>();
        Timetilltxt = GameObject.Find("timetilladventure").GetComponent<TMP_Text>();
        GenerateEvents(250);
        if(Player.olddatafound == false)
        {
            Player.currentplayercoords = new Vector2(Random.RandomRange(-200, 200), Random.RandomRange(-200, 200));
            if(Ingameplayerlocicon == null)
            {

                Ingameplayerlocicon = Instantiate(Playerlocicon);
                Ingameplayerlocicon.transform.SetParent(Map.transform);
                Playerscale = ingameplayerlocicon.transform.lossyScale;
                Ingameplayerlocicon.GetComponent<RectTransform>().localPosition = player.currentplayercoords;
                Ingameplayerlocicon.transform.localScale = new Vector3(4, 4, 1);

            }
            for (int i = 0; i < Eventlocations.Count; i++)
            {
                float distance = Vector2.Distance(Player.currentplayercoords, Eventlocations[i]);
                if(distance <= 150)
                {
                    Known[i] = true;
                }
                else
                {
                    Known[i] = false;
                }
            }
        }
    }

    void GenerateEvents(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            eventtypes.Add("encounter");
            eventlocations.Add(new Vector2(Random.Range(-800, 800), Random.Range(-1100, 1100)));
            GameObject Eventobj = Instantiate(Icons[Random.Range(0, Icons.Length)]);
            Eventobj.transform.SetParent(Map.transform);
            eventtypes[i] = "Basic";
            known.Add(false);
            completedevent.Add(false);

            Eventobj.GetComponent<RectTransform>().localPosition = eventlocations[i];
            int index = i; // create a local variable that holds the current value of i

            Eventobj.GetComponent<Button>().onClick.AddListener(() =>
                GameObject.Find("UIhub").GetComponent<UImanager>().addventurestart(index));

            placesofinterests.Add(Eventobj);

        }
        checkdiscovered();

    }

    private void SetZoommap(float targetSize)
    {
        Ingameplayerlocicon.transform.parent = null;
        Map.rectTransform.localScale = new Vector3(targetSize, targetSize, 1);
        Ingameplayerlocicon.transform.parent = Map.transform;
       Ingameplayerlocicon.GetComponent<RectTransform>().localPosition = player.currentplayercoords;
 
    }
    void checkdiscovered()
    {
        for (int i = 0; i < Eventlocations.Count; i++)
        {
            if (Placesofinterests[i] != null)
            {
                Placesofinterests[i].SetActive(Known[i]);
            }
            else
            {
                Placesofinterests.Remove(Placesofinterests[i]);
            }
        }
    }
    public void gotowards(int c)
    {
        Sellectedadventure = c;
        player.heading2 = Eventlocations[c];
        Setdestination = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Activated == true)
        {
            checkdiscovered();

            if (Input.mouseScrollDelta.y > 0)
            {
                SetZoommap(Mathf.Clamp(Map.rectTransform.localScale.y * zoomscale, minSize, maxSize));
               // Debug.Log("in" + Mathf.Clamp(Map.rectTransform.localScale.y * zoomscale, minSize, maxSize));
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                SetZoommap(Mathf.Clamp(Map.rectTransform.localScale.y / zoomscale, minSize, maxSize));
               // Debug.Log("out" + Mathf.Clamp(Map.rectTransform.localScale.y / zoomscale, minSize, maxSize));

            }
            Vector3[] corners = new Vector3[4];
            Map.rectTransform.GetWorldCorners(corners);
            Rect newRect = new Rect(corners[0], corners[2] - corners[0]);
            //Debug.Log(newRect.Contains(Input.mousePosition));
            Vector2 oldmouse = Input.mousePosition;
            if (newRect.Contains(Input.mousePosition))
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(Map.rectTransform, oldmouse, null, out mouse);
                mouse.x *= 10;
                mouse.y *= 10;
                Mathf.FloorToInt(mouse.x);
                Mathf.FloorToInt(mouse.y);
                Mousecoorstxt.text = "x: " + Mathf.FloorToInt(mouse.x) + "  y: " + Mathf.FloorToInt(mouse.y); 

                //Vector2 posInImage = oldmouse - new Vector2(Map.transform.position.x, Map.transform.position.y);
                //RectTransformUtility.ScreenPointToLocalPointInRectangle(Map.rectTransform, mouse, null,  out Vector2 uiPosition);
                // Map.transform.position(RectTransform rect, Vector2 screenPoint, Camera cam, out Vector2 localPoint);

            }
        }

        if (GameObject.Find("UIhub").GetComponent<UImanager>().adventurebool == true && Setdestination == true)
        {
            if (Startadventuring == false)
            {
                player.oldplayercoords = player.currentplayercoords;
                Startadventuring = true;
            }
            else
            {
                if (player.currentplayercoords != player.heading2)
                {
                    float distance = Vector2.Distance(player.currentplayercoords, player.heading2);
                    Vector2 direction = player.heading2 - player.currentplayercoords;
                    float speed = stat.adventuringspeed;
                    float timeToDestination = distance / speed;

                    Vector2 newPosition = Vector2.MoveTowards(player.currentplayercoords, player.heading2, speed * Time.deltaTime);
                    player.currentplayercoords = newPosition;
                    Ingameplayerlocicon.GetComponent<RectTransform>().localPosition = player.currentplayercoords;

                    Timetillarival = timeToDestination - Time.deltaTime;
                    int remainingSeconds = Mathf.FloorToInt(timetillarival);
                    int minutes = remainingSeconds / 60;
                    int seconds = remainingSeconds % 60;
                    int hours = minutes / 60;
                    minutes %= 60;
                    Timetilltxt.text = ""+hours+" H "+minutes+" M "+seconds+" S";
                }

                if (player.currentplayercoords == player.heading2)
                {
                    Startadventuring = false;
                    Reachedbool = true;
                    reachdestination();
                }
            }
        }
    }
    public void reachdestination()
    {
        Debug.Log("finished adventure");
        if(Eventtypes[Sellectedadventure] == "Basic")
        {
            GameObject.Find("UIhub").GetComponent<bubblenotification>().notificationtype = "adventurecomplete";
           

        }
        
    }
    public void adventurecomplete()
    {
        GameObject.Find("UIhub").GetComponent<UImanager>().choicesenable = true;
        GameObject.Find("UIhub").GetComponent<UImanager>().eventtype = Eventtypes[Sellectedadventure];

        Setdestination = false;
        Reachedbool = false;
        Eventlocations.Remove(player.heading2);

        Destroy(Placesofinterests[Sellectedadventure]);

    }

}
