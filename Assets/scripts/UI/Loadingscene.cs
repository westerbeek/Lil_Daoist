using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Loadingscene : MonoBehaviour
{
    public Image loadingbar;
    public float fillspeed;//todo 0.3f
    public TMP_Text loadingtxt;
    private void Start()
    {
        // Start the coroutine to load the scene asynchronously
        loadingtxt = GameObject.Find("loadingtxt").GetComponent<TMP_Text>();
        loadingbar = GameObject.Find("LoadingImage").GetComponent<Image>();
        loadingbar.fillAmount = 0;
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("game");
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            loadingbarsmooth();

            if (asyncOperation.progress >= 0.9f)
            {
                if (loadingbar.color.a <= 0)
                {
                    asyncOperation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
    private void loadingbarsmooth()
    {
        loadingbar.fillAmount += fillspeed * Time.deltaTime;
        if(loadingbar.fillAmount > 0 && loadingbar.fillAmount < 0.33f)
        {
            loadingtxt.text = "Loading cultivation!";

        }
        if (loadingbar.fillAmount > 0.33f && loadingbar.fillAmount < 0.66f)
        {
            loadingtxt.text = "Loading spiritual energy!";

        }
        if (loadingbar.fillAmount > 0.66f && loadingbar.fillAmount < 1f)
        {
            loadingtxt.text = "Loading Great path!";

        }
        if (loadingbar.fillAmount >= 1)//checks if loading bar is filled
        {
            loadingtxt.text = "Finished loading!";
            float Fadeamount = loadingbar.color.a - (0.5f * Time.deltaTime);
            loadingbar.color = new Color(loadingbar.color.r, loadingbar.color.g, loadingbar.color.b, Fadeamount); //fades the loading bar after completed
        }
    }
}
