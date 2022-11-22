using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneCollectionScript : MonoBehaviour
{

    public GameObject Player;
    private CharacterController pm;

    



    void Start()
    {
        pm = Player.GetComponent<CharacterController>();
        
        
    }



    void OnTriggerEnter(Collider other)
    {

        if (gameobject) 
        {
            pm.canClimb = true;
        }
        
        Destroy(gameObject);

    }
}
