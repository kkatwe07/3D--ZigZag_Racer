using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject Platform;
    [SerializeField] Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPosition;

    bool stop;

 
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = lastPlatform.position;

        StartCoroutine(SpawnPlatforms());
    }

    // Update is called once per frame
    void Update()
    {



    }


    IEnumerator SpawnPlatforms()
    {
        while (!stop)
        {
            GeneratePosition();

            Instantiate(Platform, newPosition, Quaternion.identity);

            lastPosition = newPosition;

            yield return new WaitForSeconds(0.05f);
        }
        

        
    }


    void GeneratePosition()
    {
        newPosition = lastPosition;

        int random = Random.Range(0, 2);

        if (random > 0)
        {
            newPosition.x += 2f;
        }
        else
        {
            newPosition.z += 2f;
        }
    }
}
