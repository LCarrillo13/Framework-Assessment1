using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Random = System.Random;


    public class ColorTile : MonoBehaviour, IComparable
    {
        public Color32 tileColor;
        public Image tileImage;

        private void Awake()
        {
            tileColor = UnityEngine.Random.ColorHSV();
            Debug.Log(tileColor);
            tileImage.color = tileColor;
        }

        /// <summary>
        /// Gets 2 color tiles, x and y, if the value of x is greater than y, return 1, if less, return -1, if the same, return 0
        /// </summary>
        /// <param name="x">color tile 1</param>
        /// <param name="y">color tile 2</param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            ColorTile colorTile1 = (ColorTile) x;
            ColorTile colorTile2 = (ColorTile) y;
            if(colorTile1.Value > colorTile2.Value)
            {
                return 1;
            }

            if(colorTile1.Value < colorTile2.Value)
            {
                return -1;
            }

            return 0;

        }

        /// <summary>
        /// returns the combined RGB value of the tilecolor as a float
        /// </summary>
        public float Value
        {
            get { return tileColor.r + tileColor.g + tileColor.b; }
        }

        /// <summary>
        /// the Comparer
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            ColorTile tile = (ColorTile) obj;
            return Compare(this, tile);
        }
    
}
