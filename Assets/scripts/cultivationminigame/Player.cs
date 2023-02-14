using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject scripthub;
    public string name;
    public string[] titles;
    public string[] paths;

    public Animator playeranimation;
    public GameObject bookanimation;
    public float booktimer;
    float maxbooktimer;
    float bookrecharge;
    // Start is called before the first frame update
    void Start()
    {
        maxbooktimer = 15;
        bookrecharge = maxbooktimer;
        booktimer = maxbooktimer;
        scripthub = GameObject.Find("ScriptHub");
        playeranimation = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        bookanimation = GameObject.Find("book");
        titles = new string[10];
        paths = new string[10];
        name = "West";

    }

    // Update is called once per frame
    void Update()
    {
        //animation
        bookanimation.transform.position = new Vector3(bookanimation.transform.position.x, 500, bookanimation.transform.position.z);//1.24285

        if (scripthub.GetComponent<Cultivation>().Cultivate == true)
        {
            if (scripthub.GetComponent<Cultivation>().Realm == 0)
            {
                playeranimation.SetBool("train", true);
                if (scripthub.GetComponent<Cultivation>().Subrealm == 1)
                {
                    bookanimation.transform.position = new Vector3(bookanimation.transform.position.x, 1.242f, bookanimation.transform.position.z);//1.24285


                    playeranimation.SetBool("read", true);
                    booktimer -= Time.deltaTime;
                    if (booktimer <= 0)
                    {
                        bookanimation.GetComponent<Animator>().SetBool("turnpage", true);
                        bookrecharge -= Time.deltaTime;
                        if(bookrecharge <= 0)
                        {
                            booktimer = maxbooktimer;
                            bookrecharge = maxbooktimer;
                        }
                    }
                    else
                    {
                        bookanimation.GetComponent<Animator>().SetBool("turnpage", false);

                    }

                }
                else
                {
                    bookanimation.transform.position = new Vector3(bookanimation.transform.position.x, 500, bookanimation.transform.position.z);//1.24285

                }


            }
                if (scripthub.GetComponent<Cultivation>().Realm == 1)
                {
                    playeranimation.SetBool("cultivate", true);
                  playeranimation.SetBool("train", false);
                playeranimation.SetBool("read", false);


            }
        }
        else
        {
            playeranimation.SetBool("cultivate", false);
                playeranimation.SetBool("train", false);
                playeranimation.SetBool("read", false);


        }
        //animationoff
    }
}
