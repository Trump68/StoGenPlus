using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using StoGen.Classes.Unity;
public class StartApp : MonoBehaviour
{
    public Texture2D img;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadImg());
    }

    IEnumerator LoadImg()
    {
        yield return 0;
        //img = LoadPNG(@"e:\!CATALOG\PRS\!STO GEN ART\Quuni\DATA\001.png");
        //img = LoadPNG(UnityAPI.GetFileName());
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnGUI()
    {
        GUILayout.Label(img);
    }


    public static Texture2D LoadPNG(string filePath)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }

}
