using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QiRefiningStage : MonoBehaviour
{
    public GameObject scripthub;
    public GameObject[] Rhuns;
    public int rhunamount;
    public int maxrhuns;

    public int xpgivenQiRefinement;//xp per rhune
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
        scripthub.GetComponent<Cultivation>().Giftxp(xpgivenQiRefinement);
        GameObject newrhun = Instantiate(Rhuns[number]);
        newrhun.gameObject.transform.SetParent(GameObject.Find("Rhunparent").transform, false);
        newrhun.gameObject.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-15, 15), Random.Range(-15, 15));
        // newrhun.GetComponent<RectTransform>().position = new Vector3();
    }
}
