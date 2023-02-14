using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MindpreperationStage : MonoBehaviour
{
    public GameObject scripthub;
    public int answer;
    public Image showimage;
    public Image[] colorsimg;

    public float xpamountgivenMindprep;

    // Start is called before the first frame update
    void Start()
    {
        scripthub = GameObject.Find("ScriptHub");

        showimage = GameObject.Find("showimagemindprep").GetComponent<Image>();
        colorsimg = new Image[5];
        colorsimg[0] = GameObject.Find("firemindprep").GetComponent<Image>();
        colorsimg[1] = GameObject.Find("earthmindprep").GetComponent<Image>();
        colorsimg[2] = GameObject.Find("metalmindprep").GetComponent<Image>();
        colorsimg[3] = GameObject.Find("watermindprep").GetComponent<Image>();
        colorsimg[4] = GameObject.Find("woodmindprep").GetComponent<Image>();
        xpamountgivenMindprep = 6;
        resetminigame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Mistake()
    {
        //meridian damage
        scripthub.GetComponent<camerashake>().shakeDuration = 5.2f;
        resetminigame();
    }
    public void Complete()
    {
        scripthub.GetComponent<Cultivation>().Giftxp(xpamountgivenMindprep);
        scripthub.GetComponent<Cultivation>().Giftinspiration(xpamountgivenMindprep);
        //absorbed.SetActive(false);
        resetminigame();
    }
    void check(int givenanswer)
    {
        
        if(givenanswer != answer)
        {
            Mistake();
        }
        else
        {
            Complete();
        }
    }
    public void resetminigame()
    {
        Color color;
        answer = Random.RandomRange(1,5);
        if (answer == 0)
        {
            showimage.color = new Color();
        }
        if (answer == 1)
        {
            showimage.color = colorsimg[0].color;
        }
        if (answer == 2)
        {
            showimage.color = colorsimg[1].color;
        }
        if (answer == 3)
        {
            showimage.color = colorsimg[2].color;
        }
        if (answer == 4)
        {
            showimage.color = colorsimg[3].color;
        }
        if (answer == 5)
        {
            showimage.color = colorsimg[4].color;
        }
       
    }
    public void button1()
    {
        check(1);
    
    }
    public void button2()
    {
        check(2);

    }
    public void button3()
    {
        check(3);

    }
    public void button4()
    {
        check(4);

    }
    public void button5()
    {
        check(5);

    }
}
