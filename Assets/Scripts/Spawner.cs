using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int width, height;
    public GameObject BushPrefab;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = BushPrefab.GetComponent<SpriteRenderer>();
        _Spawner();
    }

    void _Spawner()     // el for recorre la anchura y la altura e instancia un arbusto por cada vuelta que da
    { 
        for (int i = 0; i < width; i++) 
        {
            for (int j = 0; j < height; j++) 
            { 
                GameObject gameObject1 = Instantiate(BushPrefab, new Vector3(i * spriteRenderer.bounds.size.x, j * spriteRenderer.bounds.size.y, 0), Quaternion.identity);
            }
        }
    }
}
