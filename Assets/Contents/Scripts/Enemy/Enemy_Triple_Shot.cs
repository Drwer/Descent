using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Triple_Shot : Enemy_General
{
    public float intermediate_shoot_cooldown;
    public int shooted_bullets_counter;

    public override void Shoot()
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

            shooted_bullets_counter++;
            if(shooted_bullets_counter < 3)
            {
                Invoke("Shoot", intermediate_shoot_cooldown);
                return;
            }

            bCanShoot = false;
            Invoke("ShootDelayManager", shooting_cooldown);
        }
    }
}
