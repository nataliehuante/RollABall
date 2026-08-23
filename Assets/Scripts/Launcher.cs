using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Launcher
{
    public static void LaunchProjectile(GameObject sourceObject, Vector3 targetObjectPosition, float speed, Rigidbody rigidbody)
    {
        Vector3 moveDirection = (targetObjectPosition - sourceObject.transform.position).normalized * speed;
        rigidbody.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
    }
}