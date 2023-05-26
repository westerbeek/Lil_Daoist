using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QiRefiningStage : MonoBehaviour
{
    [SerializeField] private GameObject Scripthub;
    public GameObject scripthub { get => Scripthub; set => Scripthub = value; }

    [SerializeField] private GameObject[] Rhuns;
    public GameObject[] rhuns { get => Rhuns; set => Rhuns = value; }

    [SerializeField] private int Rhunamount;
    public int rhunamount { get => Rhunamount; set => Rhunamount = value; }

    [SerializeField] private int Maxrhuns;
    public int maxrhuns { get => Maxrhuns; set => Maxrhuns = value; }

    [SerializeField] private int XpgivenQirefinement;
    public int xpgivenQiRefinement { get => XpgivenQirefinement; set => XpgivenQirefinement = value; }//xp per rhune
    // Start is called before the first frame update
    void Start()
    {
        xpgivenQiRefinement = 20;
        scripthub = GameObject.Find("ScriptHub");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void rhuncomplete(string name)
    {
        int number = Random.Range(0, Rhuns.Length);
        scripthub.GetComponent<Cultivation>().Giftxp(xpgivenQiRefinement,true);
        GameObject newrhun = Instantiate(Rhuns[number]);
        newrhun.gameObject.transform.SetParent(GameObject.Find("Rhunparent").transform, false);
        newrhun.gameObject.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-15, 15), Random.Range(-15, 15));
        // newrhun.GetComponent<RectTransform>().position = new Vector3();
    }
}
