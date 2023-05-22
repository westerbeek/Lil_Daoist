using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qisensingtrigger : MonoBehaviour
{
    public GameObject minigamehubQistage;
    // Start is called before the first frame update
    void Start()
    {
        minigamehubQistage = GameObject.Find("Qigatheringstagegamehub");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "rhun2sense")
        {
            minigamehubQistage.GetComponent<QiSensingStage>().found = true;
        }
        else
        {
            minigamehubQistage.GetComponent<QiSensingStage>().found = false;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "rhun2sense")
        {
            minigamehubQistage.GetComponent<QiSensingStage>().found = false;
        }
      
    }

        private void OnCollisionStay2D(Collision2D collision)
    {

    }
}