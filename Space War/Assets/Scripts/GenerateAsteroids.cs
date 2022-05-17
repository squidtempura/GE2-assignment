using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAsteroids : MonoBehaviour
{
    public Transform asteroidPrefab;
    public int fieldRadius = 500;
    public int asteroidCount = 200;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < asteroidCount; i ++)
        {
            Transform temp = Instantiate(asteroidPrefab,Random.insideUnitSphere * fieldRadius, Random.rotation);
            temp.localScale = temp.localScale * Random.Range(0.55f,5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
