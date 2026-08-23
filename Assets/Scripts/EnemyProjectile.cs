using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    private float moveSpeed = GameParameters.ProjectileSpeedSlow;
    private Rigidbody Rigidbody;
    private PlayerController player;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindObjectOfType<PlayerController>();
        Launcher.LaunchProjectile(gameObject, player.gameObject.transform.position, moveSpeed, Rigidbody);
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "Barrier") || (collision.gameObject.tag == "Ground") )
        {
            Destroy(gameObject);
        }
        
    }
}
