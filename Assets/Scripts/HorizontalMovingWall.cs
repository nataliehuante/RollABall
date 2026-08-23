using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovingWall : MonoBehaviour
{
    [SerializeField] float distanceToCover;
    [SerializeField] float speed;
    [SerializeField] bool movesRightFirst = true;

    private Vector3 startingPosition;
    
    
    void Start()
    {
        startingPosition = transform.position;
    }
    
    void Update()
    {
        Vector3 x = startingPosition;
        if (movesRightFirst){
            x.x += distanceToCover * Mathf.Sin(Time.time * speed);
        }
        else {
            x.x += distanceToCover * Mathf.Cos(Time.time * speed);
        }
        transform.position = x;
        
    }
}
