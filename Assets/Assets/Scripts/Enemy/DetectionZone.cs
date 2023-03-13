using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{

    public float speed = 1f;
    public float MinimumDistance = 1;
    private Transform EnemyTarget;
    private Vector2 direct;
    private Animator Animation;
    private bool EnemyIsMoving;
    public float attackDelay;
    public float passedTime;

    private void Awake()
    {
        Animation = GetComponent<Animator>();
    }

    private void Update()
    {
        if (EnemyTarget != null)
        {
            float EnemyMovement = speed * Time.deltaTime;
            if (Vector2.Distance(transform.position, EnemyTarget.position) > MinimumDistance)
                //Checks to see if enemy is at a certain distance before stopping.
            {
                transform.position = Vector2.MoveTowards(transform.position, EnemyTarget.position, EnemyMovement);
                //Logic that makes the enemy move towards the player
                Animation.SetBool("hasTarget", true);
            }
            else
            {
                //Attack Logic will go here
                if(passedTime >= attackDelay)
                {
                    passedTime = 0;
                    Animation.SetBool("inRange", true);
                }
            }
        }
        if(passedTime < attackDelay)
        {
            passedTime += Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            EnemyTarget = other.transform;
            //Logic that checks for another game Object that carries the tag of 'player'. Once condition is met the Transform variable is set to the other object's transform.
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyTarget = null;
    }
}
