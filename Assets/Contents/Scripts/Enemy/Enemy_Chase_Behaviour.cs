using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chase_Behaviour : StateMachineBehaviour
{
    private float turning_speed;
    private Transform transform_ref;
    private Rigidbody rigidbody_ref;

    public Transform player;

    private float degrees_to_rotate;
    private Vector3 axis_to_rotate_around;

    private float chasing_speed = 2;
    private float attack_min_radius = 8;
    private LayerMask whatIsPlayer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform_ref = animator.gameObject.GetComponent<Transform>();
        rigidbody_ref = animator.gameObject.GetComponent<Rigidbody>();
        chasing_speed = animator.gameObject.GetComponent<Enemy_General>().chasing_speed;
        attack_min_radius = animator.gameObject.GetComponent<Enemy_General>().attack_min_radius;
        whatIsPlayer = animator.gameObject.GetComponent<Enemy_General>().whatIsPlayer;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Turn();

        Collider[] found_colliders = Physics.OverlapSphere(transform_ref.position, attack_min_radius, whatIsPlayer);

        if (found_colliders.Length != 0)
        {
            animator.SetBool("bCanAttack", true);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }

    private void Turn()
    {
        LookAt(player);

        if (degrees_to_rotate > turning_speed * Time.deltaTime)
        {
            degrees_to_rotate -= turning_speed * Time.deltaTime;
            transform_ref.Rotate(axis_to_rotate_around, turning_speed * Time.deltaTime);
        }
        else
        {
            transform_ref.LookAt(player.position);
        }

        rigidbody_ref.velocity = transform_ref.forward * chasing_speed;
    }
    public void LookAt(Transform target)
    {
        target = player;
    }
}
