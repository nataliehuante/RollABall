using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingWall : MonoBehaviour
{

    [SerializeField] float distanceToCover;
    [SerializeField] float speed;

    private Vector3 startingPosition;
    
    
    void Start()
    {
        startingPosition = transform.position;
    }
    
    void Update()
    {
        Vector3 y = startingPosition;
        y.y += distanceToCover * Mathf.Sin(Time.time * speed);
        transform.position = y;
    }
}
