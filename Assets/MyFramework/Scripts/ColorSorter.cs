using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSorter : MonoBehaviour
{
    [Header("variable setup")]
    public ColorTile colorTilePrefab;
    public Transform tileParent;
    private ColorTile[] colorTiles = new ColorTile[100];
    public InputField colorInputFieldR, colorInputFieldG, colorInputFieldB;
    public Text searchOutputText;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 100; i++)
        {
            ColorTile newTile = Instantiate(colorTilePrefab, tileParent);
            colorTiles[i] = newTile;
        }
        StartCoroutine(BubbleSort());
    }
    /// <summary>
    /// Coroutine that compares each color tile with every color tile in the array
    /// </summary>
    /// <returns>colorTiles</returns>
    IEnumerator BubbleSort()
    {
        for(int i = 0; i < colorTiles.Length - 1; i++)
        {
            for(int j = 0; j < colorTiles.Length - 1; j++)
            {
                if(colorTiles[j].CompareTo(colorTiles[j + 1]) == 1)
                {
                    ColorTile t = colorTiles[j + 1];
                    colorTiles[j + 1] = colorTiles[j];
                    colorTiles[j] = t;
                    colorTiles[j+1].transform.SetSiblingIndex(Array.IndexOf(colorTiles,colorTiles[j+1]));
                    colorTiles[j].transform.SetSiblingIndex(Array.IndexOf(colorTiles,colorTiles[j]));
                    yield return new WaitForSeconds(0.001f);
                }
            }
        }
    }

    /// <summary>
    /// Method for linear search of colors by R, G, and B that runs on button pressed 
    /// </summary>
    public void OnSearchButtonPress()
    {
        int searchR = int.Parse(colorInputFieldR.text);
        int searchG = int.Parse(colorInputFieldG.text);
        int searchB = int.Parse(colorInputFieldB.text);
        for(int i = 0; i < colorTiles.Length; i++)
        { 
            if(colorTiles[i].tileColor.r == searchR && colorTiles[i].tileColor.g == searchG && colorTiles[i].tileColor.b == searchB)
            {
                searchOutputText.text = "Color found at position: " + i;
                return;
            }
        }
        searchOutputText.text = "Can't Find Color";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
