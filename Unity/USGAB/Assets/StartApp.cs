using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityStoGen;

public class StartApp : MonoBehaviour
{
    //public Texture2D img;
    // Start is called before the first frame update
    //GameObject fem1;
    void Start()
    {

        Texture2D img = LoadPNG(@"e:\!CATALOG\PRS\!STO GEN ART\Quuni\DATA\002.png");
        //SpriteRenderer sr = GetComponent<SpriteRenderer>();
        //sr.sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0, 0), 100);
        GameObject fruit = new GameObject();
        fruit.AddComponent<SpriteRenderer>();
        fruit.GetComponent<SpriteRenderer>().sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0, 0), 100);

        //StartCoroutine(LoadImg());
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
        //GUILayout.Label(img);
        
    }

    // ================== To load texture from file 

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

    // ================ to create sprite form texture

    //Sprite.Create(tex, sprite.rect, new Vector2(0.5f,0.5f));

    // to assign sprite to figure ==================

    //// create the object
    //GameObject fruit = new GameObject();
    //// add a "SpriteRenderer" component to the newly created object
    //fruit.AddComponent<SpriteRenderer>();
    //// assign "fruit_9" sprite to it
    //fruit.GetComponent<SpriteRenderer>().sprite = fruitSprites[9];
    //// to assign the 5th frame
    //fruit.GetComponent<SpriteRenderer>().sprite = fruitSprites[5];

    // to find figure ===========================

    //fem1 = GameObject.Find("Female1");
}
