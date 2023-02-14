using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    public bool drag;
    // Start is called before the first frame update
    void Start()
    {
        drag = false;
    }
    private void Update()
    {
     if(drag == true)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //transform.position = new Vector2(Input.mousePosition.x + Offset.x, Input.mousePosition.y + Offset.y);

        }
    }

    // Update is called once per frame
    public void pointerdown()
    {
        drag = true;
    }
    public void pointerup()
    {
        drag = false;

    }
    //For triggers you need rigidbody AND  
/*    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
    }
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Triggered");
    }*/
}
