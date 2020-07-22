using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorMapping[] colorMappings;

    private void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        for(int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    public void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);
        if (pixelColor.a == 0)
            return;
        
        foreach(ColorMapping colorMapping in colorMappings)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x-8, y-5);
                Instantiate(colorMapping.prefab , position , Quaternion.identity, transform);
            }
        }

    }


}
