using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICollisiontrigger : MonoBehaviour
{
    // Start is called before the first frame update

    //FOR TRIGGER OR COLLISION YOU NEED RIGID BODIES AND COLLIDERS ON THE OBJECT!   
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Triggered");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

}
