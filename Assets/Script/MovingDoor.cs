using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDoor : MonoBehaviour
{

    public Transform door;
    public Transform startingPoint;
    public Transform endingPoint;


    // Start is called before the first frame update
    private void Start()
    {
        door.position = startingPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        door.position = Vector3.MoveTowards(door.position, endingPoint.position, Time.deltaTime);
    }
}
