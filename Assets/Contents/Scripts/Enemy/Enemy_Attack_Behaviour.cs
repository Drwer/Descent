using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack_Behaviour : StateMachineBehaviour
{
    private Transform transform_ref;
    private Enemy_General enemy_scr;

    public Transform target_transform;
    private float chasing_max_radius;
    private LayerMask whatIsPlayer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform_ref = animator.gameObject.GetComponent<Transform>();
        enemy_scr = animator.gameObject.GetComponent<Enemy_General>();
        chasing_max_radius = animator.gameObject.GetComponent<Enemy_General>().attack_min_radius;
        whatIsPlayer = animator.gameObject.GetComponent<Enemy_General>().whatIsPlayer;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy_scr.Shoot();

        Collider[] found_colliders = Physics.OverlapSphere(transform_ref.position, chasing_max_radius, whatIsPlayer);

        if (found_colliders.Length != 0)
        {
            animator.SetBool("bCanAttack", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
