using System.Collections;
using UnityEngine;
using System.Collections.Generic;
//using System.Numerics;

public class PlayerJumpMechanic : MonoBehaviour 
{
    private Rigidbody rb;
    private int count = 0;
    // private GameController gameController;
    public float jumpForce = 7f;


    // Start is called before the first frame update
    void Start()
    {
        // gameController = GetComponentInParent<GameController>();
        rb = GetComponent<Rigidbody>();
        count = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Given the player presses Space Bar, Jump
        // Player can only jump up to three times in a row
        if ((Input.GetKeyDown(KeyCode.Space)) && (count == 0))
        {
            print("space button pressed");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            count++;
        }
    }

    // Upon a collision with the ground, triple jump is reset
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Ground")
        {
            count = 0;
        }
    }
    
}
