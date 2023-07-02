using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class Introscreen : MonoBehaviour
{
    public GameObject scripthub;
    [SerializeField]private GameObject introcanvas;
    public GameObject Introcanvas { get { return introcanvas; } set { introcanvas = value; } }
    [SerializeField] private Image background;
    public Image Background { get { return background; } set { background = value; } }
    [SerializeField] private TextAsset introtxtfile;
    public TextAsset Introtxtfile { get { return introtxtfile; } set { introtxtfile = value; } }
    [SerializeField] private string[] introTextstxt;
    public string[] IntroTextstxt { get { return introTextstxt; } set { introTextstxt = value; } }
    [SerializeField] private TMP_Text introText;
    public TMP_Text IntroText { get { return introText; } set { introText = value; } }
    [SerializeField] private int currentIndex = 0;
    public bool Fadebool { get { return fadebool; } set { fadebool = value; } }
    [SerializeField] private bool fadebool;
    public float Fadespeed { get { return fadespeed; } set { fadespeed = value; } }
    [SerializeField] private float fadespeed;
    

    private void Start()
    {
        scripthub = GameObject.Find("ScriptHub");

        Introcanvas = GameObject.Find("Introscreen");
        Background = GameObject.Find("IntroBackground").GetComponent<Image>();
        IntroText = GameObject.Find("introtext").GetComponent<TMP_Text>();
        if (scripthub.GetComponent<Player>().seenintro == true)
        {
            fadebool = true;

        }
        else
        {
            introText.enabled = true;
            splitText(Introtxtfile);
            ShowIntroText(currentIndex);
        }
        
    }
    public void splitText(TextAsset file)
    {
        string temptxt;
        temptxt = file.text.ToString();
        IntroTextstxt = temptxt.Split(new[] { "~~~" }, StringSplitOptions.RemoveEmptyEntries);
        //Debug.Log(cultivationinfotxt[1]);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            currentIndex++;

            if (currentIndex < IntroTextstxt.Length)
            {
                ShowIntroText(currentIndex);
            }
            else
            {
                //scripthub.GetComponent<Player>().seenintro = true;
                Fadebool = true;
         
            }
        }
        if(scripthub.GetComponent<Player>().seenintro == true)
        {
            Fadebool = true;

        }
        if (Fadebool == true)
        {
            HideIntroScreen();
        }
    }

    private void ShowIntroText(int index)
    {
        IntroText.text = IntroTextstxt[index];
    }

    private void HideIntroScreen()
    {
        float Fadeamount = Background.color.a - (Fadespeed * Time.deltaTime);
        Background.color = new Color(Background.color.r, Background.color.g, Background.color.b, Fadeamount); //Time.deltaTime * fadespeed;
        IntroText.enabled = false;
        if(Background.color.a <= 0)
        {
            Introcanvas.SetActive(false);
        }
    }
}



