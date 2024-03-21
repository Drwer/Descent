using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol_Behaviour : StateMachineBehaviour
{
    private List<Vector3> patrolling_points = new List<Vector3>();
    private float patroling_speed;
    private float turning_speed;
    private Transform transform_ref;
    private Rigidbody rigidbody_ref;

    private float degrees_to_rotate;
    private Vector3 axis_to_rotate_around;

    private Transform target_transform;
    private float enraging_radius;
    private LayerMask whatIsPlayer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patrolling_points = animator.gameObject.GetComponent<Enemy_General>().patrolling_points;
        patroling_speed = animator.gameObject.GetComponent<Enemy_General>().patrolling_speed;
        enraging_radius = animator.gameObject.GetComponent<Enemy_General>().enraging_radius;
        whatIsPlayer = animator.gameObject.GetComponent<Enemy_General>().whatIsPlayer;
        transform_ref = animator.gameObject.GetComponent<Transform>();
        rigidbody_ref = animator.gameObject.GetComponent<Rigidbody>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Physics.OverlapSphere(patrolling_points[0], 0.1f, animator.gameObject.layer).Length != 0)
        {
            animator.gameObject.GetComponent<Enemy_General>().StartCoroutine("SwitchPatrollingPoint");
        }

        Collider[] found_colliders = Physics.OverlapSphere(transform_ref.position, enraging_radius, whatIsPlayer);
        if (found_colliders.Length != 0)
        {
            target_transform = found_colliders[0].transform;
            animator.SetTrigger("start_chase");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetBehaviour<Enemy_Chase_Behaviour>().target_transform = target_transform;
        animator.GetBehaviour<Enemy_Attack_Behaviour>().target_transform = target_transform;
    }

    IEnumerator SwitchPatrollingPoint()
    {
        rigidbody_ref.velocity = Vector3.zero;

        Vector3 switched_point = patrolling_points[0];
        patrolling_points.RemoveAt(0);
        patrolling_points.Add(switched_point);

        degrees_to_rotate = Vector3.Angle(transform_ref.forward, patrolling_points[0] - transform_ref.position);
        axis_to_rotate_around = Vector3.Cross(transform_ref.forward, patrolling_points[0] - transform_ref.position);
        yield return new WaitUntil(Turn);

        rigidbody_ref.velocity = transform_ref.forward * patroling_speed;
        yield return null;
    }

    private bool Turn()
    { 
        if (degrees_to_rotate > turning_speed * Time.deltaTime)
        {
            degrees_to_rotate -= turning_speed * Time.deltaTime;
            transform_ref.Rotate(axis_to_rotate_around, turning_speed * Time.deltaTime);
            return true;
        }
        else
        {
            transform_ref.LookAt(patrolling_points[0]);
            return false;
        }
    }
}
