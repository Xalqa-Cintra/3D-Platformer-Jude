using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   
    public bool spawnObject = false;

    //put bones in here
    public GameObject[] objectsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnObject = true)
        {
           Instantiate(objectsToSpawn[selection], transform.position, Quaternion.identity); 
        }
        
    }
}
