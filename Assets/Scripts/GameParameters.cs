using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParameters : MonoBehaviour
{

    // enemy shooter
    public static float EnemyShooterFireRate = 1.5f;
    public static float EnemyShooterRangeToShootFor = 8f;

    // projectile
    public static float ProjectileSpeedSlow = 2.5f;
    public static float ProjectileSpeedNormal = 5f;
    public static float ProjectileSpeedFast = 10f;

    // timer 
    public static int TimerLimitLevel1 = 60;
    public static int TimerLimitLevel2 = 90;
    public static int TimerLimitLevel3 = 90;
}
