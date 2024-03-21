using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Shooting_Sign(Transform delta_shooting_position);

public class Enemy_General : MonoBehaviour
{
    public Shooting_Sign Shooting_Del;

    public List<Vector3> patrolling_points = new List<Vector3>();
    public float patrolling_speed;
    public float enraging_radius;
    public LayerMask whatIsPlayer;

    public float chasing_speed;
    public float attack_min_radius;

    public List<GameObject> bullets = new List<GameObject>();
    public Transform shooting_position;
    public bool bCanShoot;
    public float shooting_cooldown;
    public float chasing_max_radius;

    private void Start()
    {
        shooting_cooldown = bullets[0].GetComponent<Bullet>().bulletData.cooldown;
    }

    public void StartEnemyCoroutine(string coroutine)
    {
        StartCoroutine(coroutine);
    }

    public virtual void Shoot()
    {
        if (bCanShoot)
        {
            foreach (GameObject delta_bullet in bullets)
            {
                if (gameObject.activeSelf)
                {
                    transform.position = shooting_position.position;
                    gameObject.SetActive(true);
                }
            }

            bCanShoot = false;
            Invoke("ShootDelayManager", shooting_cooldown);
        }        
    }

    public void ShootDelayManager()
    {
        bCanShoot = true;
    }
}
