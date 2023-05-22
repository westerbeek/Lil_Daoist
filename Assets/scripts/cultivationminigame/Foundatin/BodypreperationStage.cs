using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BodypreperationStage : MonoBehaviour
{
    public GameObject scripthub;
    public Image filledprogression;
    public float progression;
    public int progressionmaximum;
    public int xpgivenBodypreperation;
    
    // Start is called before the first frame update
    void Start()
    {
        scripthub = GameObject.Find("ScriptHub");
        xpgivenBodypreperation = 1;
        progressionmaximum = 10;
        filledprogression = GameObject.Find("Foundationloadcircle").GetComponent<Image>();
        resetminigame();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("displaydis shit");
        filledprogression.fillAmount = progression / progressionmaximum;
        for (int i = 0; i < scripthub.GetComponent<Player>().playeranimation.Length; i++)
        {
            if (scripthub.GetComponent<Player>().playeranimation[i] != null)
            {
                scripthub.GetComponent<Player>().playeranimation[i].SetFloat("pushupfloat", progression / 10f);
            }
        }
        if (progression >= progressionmaximum)
        {
            Complete();
        }
        if(progression > 0)
        {
            progression -= Time.deltaTime * 1.25f;
        }
        else
        {
            progression = 0;
        }
    }
    public void Complete()
    {
        scripthub.GetComponent<Cultivation>().Giftxp(xpgivenBodypreperation);
        scripthub.GetComponent<Cultivation>().Giftinspiration(xpgivenBodypreperation);

        //absorbed.SetActive(false);
        resetminigame();
    }
    public void resetminigame()
    {
        progression = 0;
        if (scripthub.GetComponent<Player>().playeranimation != null)
        {
            for (int i = 0; i < scripthub.GetComponent<Player>().playeranimation.Length; i++)
            {
                if (scripthub.GetComponent<Player>().playeranimation[i].GetCurrentAnimatorStateInfo(0).IsName("pushup"))//todo
                {
                    // scripthub.GetComponent<Player>().playeranimation.speed = 0;
                }
            }
        }
    }
    public void kneeup()
    {
        progression++;
    }
}
