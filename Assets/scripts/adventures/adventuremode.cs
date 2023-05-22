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
    public bool activated;
    public Image Map;
    public GameObject scripthub;
    public Player player;
    public stats stat;
    /*
    public Vector2 playercoords;
    public Vector2 headed;*/
    public Vector2 mouse;
    public List<Vector2> eventlocations;
    public List<string> eventtypes;//todo
    public List<bool> known;
    public List<bool> rumorconfirmed;//todo
    public List<bool> completedevent;//todo
    public List<GameObject> placesofinterests;

    public GameObject[] icons;
    public GameObject playerlocicon;
    public GameObject ingameplayerlocicon;
    public Vector3 playerscale;
    public bool moving;
    public TMP_Text mousecoorstxt;
    public TMP_Text playercoordstxt;
    public int sellectedadventure;
    //zoom
    [SerializeField] float startSize = 1;
    [SerializeField] float minSize = .5f;
    [SerializeField] float maxSize = 10;
    public float zoomscale;

    public float timetillarival;
    private bool startadventuring;
    private bool reachedbool;
    public bool setdestination;
    public bool adventuring;

    public TMP_Text timetilltxt;
    // Start is called before the first frame update
    void Awake()
    {
        reachedbool = false;
        scripthub = GameObject.Find("ScriptHub");
        player = scripthub.GetComponent<Player>();
        stat = scripthub.GetComponent<Player>();
        mousecoorstxt = GameObject.Find("Adventuremousecoordstxt").GetComponent<TMP_Text>();
        Map = GameObject.Find("AdventureMap").GetComponent<Image>();
        timetilltxt = GameObject.Find("timetilladventure").GetComponent<TMP_Text>();
        GenerateEvents(150);
        if(player.olddatafound == false)
        {
            player.currentplayercoords = new Vector2(Random.RandomRange(-200, 200), Random.RandomRange(-200, 200));
            if(ingameplayerlocicon == null)
            {

                ingameplayerlocicon = Instantiate(playerlocicon);
                ingameplayerlocicon.transform.parent = Map.transform;
                playerscale = ingameplayerlocicon.transform.lossyScale;
                ingameplayerlocicon.GetComponent<RectTransform>().localPosition = player.currentplayercoords;
                ingameplayerlocicon.transform.localScale = new Vector3(4, 4, 1);

            }
            for (int i = 0; i < eventlocations.Count; i++)
            {
                float distance = Vector2.Distance(player.currentplayercoords, eventlocations[i]);
                if(distance <= 150)
                {
                    known[i] = true;
                }
                else
                {
                    known[i] = false;
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
            GameObject Eventobj = Instantiate(icons[Random.Range(0, icons.Length)]);
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
        ingameplayerlocicon.transform.parent = null;
        Map.rectTransform.localScale = new Vector3(targetSize, targetSize, 1);
        ingameplayerlocicon.transform.parent = Map.transform;
        ingameplayerlocicon.GetComponent<RectTransform>().localPosition = player.currentplayercoords;

    }
    void checkdiscovered()
    {
        for (int i = 0; i < eventlocations.Count; i++)
        {
            if (placesofinterests[i] != null)
            {
                placesofinterests[i].SetActive(known[i]);
            }
            else
            {
                placesofinterests.Remove(placesofinterests[i]);
            }
        }
    }
    public void gotowards(int c)
    {
        sellectedadventure = c;
        player.heading2 = eventlocations[c];
        setdestination = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (activated == true)
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
                mousecoorstxt.text = "x: " + Mathf.FloorToInt(mouse.x) + "  y: " + Mathf.FloorToInt(mouse.y); 

                //Vector2 posInImage = oldmouse - new Vector2(Map.transform.position.x, Map.transform.position.y);
                //RectTransformUtility.ScreenPointToLocalPointInRectangle(Map.rectTransform, mouse, null,  out Vector2 uiPosition);
                // Map.transform.position(RectTransform rect, Vector2 screenPoint, Camera cam, out Vector2 localPoint);

            }
        }

        if (GameObject.Find("UIhub").GetComponent<UImanager>().adventurebool == true && setdestination == true)
        {
            if (startadventuring == false)
            {
                player.oldplayercoords = player.currentplayercoords;
                startadventuring = true;
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
                    ingameplayerlocicon.GetComponent<RectTransform>().localPosition = player.currentplayercoords;

                    timetillarival = timeToDestination - Time.deltaTime;
                    int remainingSeconds = Mathf.FloorToInt(timetillarival);
                    int minutes = remainingSeconds / 60;
                    int seconds = remainingSeconds % 60;
                    int hours = minutes / 60;
                    minutes %= 60;
                    timetilltxt.text = ""+hours+" H "+minutes+" M "+seconds+" S";
                }

                if (player.currentplayercoords == player.heading2)
                {
                    startadventuring = false;
                    reachedbool = true;
                    reachdestination();
                }
            }
        }
    }
    public void reachdestination()
    {
        Debug.Log("finished adventure");
        if(eventtypes[sellectedadventure] == "Basic")
        {
            GameObject.Find("UIhub").GetComponent<bubblenotification>().notificationtype = "adventurecomplete";
           

        }
        
    }
    public void adventurecomplete()
    {
        GameObject.Find("UIhub").GetComponent<UImanager>().choicesenable = true;
        GameObject.Find("UIhub").GetComponent<UImanager>().eventtype = eventtypes[sellectedadventure];

        setdestination = false;
        reachedbool = false;
        eventlocations.Remove(player.heading2);

        Destroy(placesofinterests[sellectedadventure]);

    }

}
