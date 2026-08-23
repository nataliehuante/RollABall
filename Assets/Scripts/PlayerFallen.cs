using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallen : MonoBehaviour
{
    private GameController gameController;
    private PlayerController player;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        player = FindObjectOfType<PlayerController>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (player.getLives() == 0)
        {
            gameController.StateUpdate(GameStates.GameStatesType.GameLost);
        }
        else 
        {
            player.loseLife();
            player.transform.position = new Vector3(0, 0, 0);
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        
    }
}
