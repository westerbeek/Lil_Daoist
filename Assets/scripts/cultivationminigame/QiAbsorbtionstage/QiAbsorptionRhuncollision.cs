using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QiAbsorptionRhuncollision : MonoBehaviour
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
        if (other.name == "QiAbsorb_insert_here")
        {
            minigamehubQistage.GetComponent<QiAbsorptionStage>().absorbed = this.gameObject;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }
}
