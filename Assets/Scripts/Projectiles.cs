using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public void DestroyAll(string tag)
    {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < projectiles.Length; i++)
        {
            GameObject.Destroy(projectiles[i]);
        }
    }
}
