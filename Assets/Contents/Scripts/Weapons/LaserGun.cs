using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private LineRenderer beam;
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private float range;

    [SerializeField] private ParticleSystem muzzleParticles;
    [SerializeField] private ParticleSystem hitParticles;

    [SerializeField] private float damage;

    private void Awake()
    {
        beam.enabled = false;
    }
    private void Activate()
    {
        beam.enabled = true;

        muzzleParticles.Play();
        hitParticles.Play();
    }
    private void Deactivate()
    {
        beam.enabled = false;
        beam.SetPosition(0, muzzlePoint.position);
        beam.SetPosition(1, muzzlePoint.position);

        muzzleParticles.Stop();
        hitParticles.Stop();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) Activate();
        else if(Input.GetMouseButtonUp(0)) Deactivate();
    }
    private void FixedUpdate()
    {
        if(!beam.enabled) return;
        Ray ray = new Ray(muzzlePoint.position, muzzlePoint.forward);
        bool cast = Physics.Raycast(ray, out RaycastHit hit, range);
        Vector3 hitPosition = cast ? hit.point : muzzlePoint.position + muzzlePoint.forward * range;

        beam.SetPosition(0, muzzlePoint.position);
        beam.SetPosition(1, hitPosition);

        hitParticles.transform.position = hitPosition;

        if(cast && hit.collider.TryGetComponent(out EnemyHealth damagable))
        {
            damagable.ApplyDamage(damage * Time.deltaTime);
        }
    }
}
