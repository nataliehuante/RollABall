using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayCollider : MonoBehaviour
{
    public GameObject ColliderToMove;
    public bool isEnterTrigger;

    void OnTriggerEnter(Collider other)
    {
        if (isEnterTrigger) // player is coming from the acceptable 'enter' direction, move collider out of way
        {
            ColliderToMove.transform.position = new Vector3 (-371f, -461.4f, 4.83f);   
            print("enter collider triggered");
        }
        else { // player is coming from the unaccepted direction, place collider back
            ColliderToMove.transform.position = new Vector3 (-377.5f, -461.4f, 4.83f);
            print("exit collider triggered");
        }
         
    }

}
