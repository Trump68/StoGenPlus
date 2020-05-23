using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityStoGen;

public class StartApp : MonoBehaviour
{
    //public Texture2D img;
    // Start is called before the first frame update
    //GameObject fem1;
    void Start()
    {
        //CenterMainCamera();

        //Scenario scen = Scenario.LoadFrom(@"e:\!CATALOG\PRS\!STO GEN STORY\Story 001\Story 001.epcatsi");
        //var sceneData = scen.GetGroupedList();
        //var firstCadre = sceneData.First();

        //foreach (var item in firstCadre)
        //{
        //    if (item.Kind == 9) // background
        //    {
        //        CreateBackground(item);
        //    }
        //}
    
    }

    //private void CreateBackground(Info_Scene item)
    //{
    //    Texture2D img = LoadPNG(item.File);        
    //    var background = GameObject.Find("Background");
    //    background.GetComponent<SpriteRenderer>().sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0, 0), 100);
    //    ResizeSpriteToScreen(background);
    //}

    private void ResizeSpriteToScreen(GameObject gameobject)
    {
        var sr = gameobject.GetComponent<SpriteRenderer>();
        if (sr == null) return;
        var trans = gameobject.GetComponent<Transform>();        
        var width = sr.sprite.bounds.size.x;
        var height = sr.sprite.bounds.size.y;
        float worldScreenHeight = Camera.main.orthographicSize * (float)2.0;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        var vector = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 1);
        trans.localScale = vector;
    }

    private void CenterMainCamera()
    {
        float worldScreenHeight = Camera.main.orthographicSize * (float)2.0;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        Camera.main.transform.localPosition = new Vector3(worldScreenWidth / 2, worldScreenHeight / 2, -10);
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

    //img = LoadPNG(@"e:\!CATALOG\PRS\!STO GEN ART\Quuni\DATA\001.png");
    //img = LoadPNG(UnityAPI.GetFileName());

    //private void OnGUI()
    //{
    //    //GUILayout.Label(img);

    //}

    //Texture2D img = LoadPNG(@"e:\!CATALOG\PRS\!STO GEN ART\Quuni\DATA\002.png");
    //SpriteRenderer sr = GetComponent<SpriteRenderer>();
    //GameObject fruit = new GameObject();
    //fruit.AddComponent<SpriteRenderer>();
    //fruit.GetComponent<SpriteRenderer>().sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0, 0), 100);
    //StartCoroutine(LoadImg());

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
