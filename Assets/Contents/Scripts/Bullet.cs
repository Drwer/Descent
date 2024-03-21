using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;

    public MeshRenderer MeshRenderer_ref;
    public Rigidbody Rigidbody_ref;

    private void Awake()
    {
        MeshRenderer_ref = GetComponent<MeshRenderer>();
        Rigidbody_ref = GetComponent<Rigidbody>();
    }

    public void OnEnable()
    {
        MeshRenderer_ref.material = bulletData.material;
        transform.rotation = Quaternion.Euler(bulletData.direction);
        Rigidbody_ref.velocity = bulletData.direction * bulletData.speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<I_BulletHit>()?.OnBulletHit(bulletData);
        gameObject.SetActive(false);
    }
}
