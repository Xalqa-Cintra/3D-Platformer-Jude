using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneCollectionScript : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject);

    }
}
