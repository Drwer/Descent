using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float initialHealth;
    public GameObject explosion;

    private float currentHealth;
    //SHARK 50, MOSQUITO 25, STARFISH 35, BOSS 200

    private void Awake()
    {
        currentHealth = initialHealth;
    }
    public void ApplyDamage(float damage)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damage;

        if (currentHealth <= 0) Destruct();
        Debug.Log(currentHealth);
    }
    private void Destruct()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
