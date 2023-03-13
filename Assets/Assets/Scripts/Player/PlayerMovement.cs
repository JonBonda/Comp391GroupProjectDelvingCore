using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    private bool IsMoving;
    private Vector2 input;
    public LayerMask SolidObjectsLayer;
    public GameObject player;
    private Animator Animation;
    private void Awake()
    {
        Animation = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!IsMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input!= Vector2.zero)
            {
                var TargetPos = transform.position;
                TargetPos.x += input.x;
                TargetPos.y += input.y;

                Animation.SetFloat("MoveX", input.x);
                Animation.SetFloat("MoveY", input.y);

                if (IsWalkable(TargetPos))
                StartCoroutine(Move(TargetPos));
            }
        }

        Animation.SetBool("IsWalking", IsMoving);
    }
    IEnumerator Move(Vector3 TargetPos)
    {
        IsMoving = true;
        while ((TargetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPos, MoveSpeed);
            yield return null;
        }
        transform.position = TargetPos;
        IsMoving = false;
    }
    private bool IsWalkable(Vector3 TargetPos)
    {
        if (Physics2D.OverlapCircle(TargetPos, 0.2f, SolidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }
}
