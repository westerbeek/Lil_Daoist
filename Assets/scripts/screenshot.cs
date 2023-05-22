using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;

public class screenshot : MonoBehaviour
{
    public KeyCode screenshotKey = KeyCode.P;
    public int resolutionScale = 1;

    private bool capturing = false;

    private void Update()
    {
        if (Input.GetKeyDown(screenshotKey) && !capturing)
        {
            capturing = true;
            StartCoroutine(TakeScreenshot());
        }
    }

    private IEnumerator TakeScreenshot()
    {
        // Capture the game view as a texture
        RenderTexture rt = new RenderTexture(Screen.width * resolutionScale, Screen.height * resolutionScale, 24);
        Camera.main.targetTexture = rt;
        Texture2D screenshot = new Texture2D(Screen.width * resolutionScale, Screen.height * resolutionScale, TextureFormat.RGB24, false);
        Camera.main.Render();
        RenderTexture.active = rt;
        screenshot.ReadPixels(new Rect(0, 0, Screen.width * resolutionScale, Screen.height * resolutionScale), 0, 0);
        Camera.main.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        // Encode the texture as a PNG
        byte[] bytes = screenshot.EncodeToPNG();
        Destroy(screenshot);

        // Save the PNG to a file
        string filename = "Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
        string path = Application.dataPath + "/" + filename;
        System.IO.File.WriteAllBytes(path, bytes);
        Debug.Log("Screenshot saved to: " + path);

        capturing = false;
        yield return null;
    }
}