using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	// Create public variables 
	public float speed;
	public bool isAlive = true;
	public GameView gameView;
	
	// Create private references to the rigidbody component on the player, and the collectibleCount of pick up objects picked up so far
	private Rigidbody rb;
	public int collectibleCount;
	private GameController gameController;
	private Sounds sounds;
	public int lives = 3;


	// At the start of the game..
	void Start ()
	{
		// gameController = GetComponentInParent<GameController>();
		gameController = FindObjectOfType<GameController>();
		gameView = FindObjectOfType<GameView>();
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();
		sounds = FindObjectOfType<Sounds>();

		// Set the collectibleCount to zero 
		collectibleCount = 0;
	}

	// Each physics step..
	void FixedUpdate ()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

        

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		rb.AddForce (movement * speed);
	}

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive (false);

			// Add one to the score variable 'collectibleCount'
			collectibleCount = collectibleCount + 1;

			// Run the GameController function for picking up a collectible
			gameController.OnPickUpCollectible(collectibleCount);

			sounds.PlayCollectPickUp();
		}

	}


	public bool GetIsAlive(){
        return isAlive;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) 
        {
			loseLife();
        }
		if (collision.gameObject.CompareTag("Barrier")) 
		{
			sounds.PlayWallHit();
			print("wall hit");
		}
    }

	public int getLives()
	{
		return lives;
	}

	public void loseLife()
	{
		--lives;
		gameView.UpdateLivesView(lives);
			if (lives <= 0)
			{	
				gameController.StateUpdate(GameStates.GameStatesType.GameLost);
			}
			else{
				sounds.PlayLoseLife();
			}
	}

	public void setLives(int newLives)
	{
		lives = newLives;
	}

}