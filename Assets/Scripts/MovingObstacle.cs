using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class MovingObstacle : MonoBehaviour
{
    public float timer;
    public int newtarget;
    public float speed;
    public NavMeshAgent nav;
    public Vector3 Target;
    public Transform PlayerTransform;
    public SimpleTimer Timer;
    

    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= newtarget)
        {
            newTarget();
            timer = 0;
        }
    }

    void newTarget()
    {
        float myX = PlayerTransform.position.x;
        float myZ = PlayerTransform.position.z;

        float xPos = Random.Range(myX - 8, myX + 8);
        float zPos = Random.Range(myZ - 8, myZ + 8);

        Target = new Vector3(xPos, gameObject.transform.position.y,zPos);

        //nav.SetDestination(Target);
        gameObject.transform.position = Target;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "MovingObstacle")
        {
            print("boom");
            LoseTime();
           // Destroy(col.gameObject);
        }
    }

     public void LoseTime()
     {
         
         Timer.timeLimit--;

     }
 }