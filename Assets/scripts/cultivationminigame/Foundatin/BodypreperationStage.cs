using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BodypreperationStage : MonoBehaviour
{
    [SerializeField] private GameObject Scripthub;
    public GameObject scripthub { get => Scripthub; set => Scripthub = value; }

    [SerializeField] private Image Filledprogression;
    public Image filledprogression { get => Filledprogression; set => Filledprogression = value; }

    [SerializeField] private float Progression;
    public float progression { get => Progression; set => Progression = value; }

    [SerializeField] private int Progressionmaximum;
    public int progressionmaximum { get => Progressionmaximum; set => Progressionmaximum = value; }

    [SerializeField] private int XpgivenBodypreperation;
    public int xpgivenBodypreperation { get => XpgivenBodypreperation; set => XpgivenBodypreperation = value; }

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
        scripthub.GetComponent<Cultivation>().Giftxp(xpgivenBodypreperation,true);
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
