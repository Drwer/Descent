using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Bullet_Type
{
    Big_death_laser,
    Rapid_fire_laser,
    Laser,
    Double_laser,
    Big_missile
}

public struct BulletData
{
    public Bullet_Type type;
    public Material material;
    public Vector3 direction;
    public float damage;
    public float speed;
    public float cooldown;
    public bool bIsEnemyBullet;
}
