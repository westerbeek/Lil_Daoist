using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combatcard : MonoBehaviour
{
    public Sprite cardimage;
    private combatmanager cmanager;
    public combatmanager CManager
    {
        get { return cmanager; }
        set { cmanager = value; }
    }
    [TextArea(1,3)]
    public string name;
    [TextArea(15, 20)]
    public string description;
    public int energyCost;
    public bool used;
    // Start is called before the first frame update

    private void Start()
    {
        cmanager = GameObject.Find("Combatmanagerobj").GetComponent<combatmanager>();
    }
    public virtual void Use(int user)
    {
    }

    // Update is called once per frame
    public virtual void Disgard(int user)
    {
    }
}
