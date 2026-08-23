using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    // what object the enemy will shoot
    public GameObject ProjectilePrefab;

    // reference to the player's ball
    private PlayerController player;
    // rate at which the enemy will fire
    // private float fireRate;

    // range around the enemy it will shoot for
    // private float shootRange = GameParameters.EnemyShooterRangeToShootFor;
    public float shootRange = 5f;

    public float fireRate = 1.5f;
    // tracks the time at which the enemy should fire next
    private float nextFire;
    // hard-shutdown switch, enemy will not shoot at all if True
    private bool isSwitchedOff = false;


    // Start is called before the first frame update
    void Start()
    {
        // set the reference to the player's ball
        // player = GameObject.FindWithTag("Player");
        player = GameObject.FindObjectOfType<PlayerController>();

        // set the variables for firing rate
        // fireRate = GameParameters.EnemyShooterFireRate;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(player.transform);

        if (CheckIfShouldFire())
            Fire();

    }


    private bool CheckIfShouldFire()
    {
        if (Time.time > nextFire)
            if (CheckPlayerWithinRange() && player.GetIsAlive() && (!isSwitchedOff))
                return true;
        return false;

    }

    private void Fire()
    {
        Instantiate(ProjectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);
        nextFire = Time.time + fireRate;
    }


    private bool CheckPlayerWithinRange()
    {
        return (Vector3.Distance(new Vector3(transform.position.x, transform.position.y, transform.position.z), player.transform.position) < shootRange);
    }

    private void SwitchOff()
    {
        isSwitchedOff = true;
    }

}
