using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EntityMovement
{
    [SerializeField]
    private Vector3 mMovementDirection;
    public bool mIsRight;

    private new void Start()
    {
        base.Start();
        mMovementDirection = new Vector3(1, 0, 0);
        mIsRight = true;
    }

    // Update is called once per frame
    void Update ()
    {
        base.Update();

        bool onGround = IsGrounded();


        if (CheckFront())
        {
            Vector3 curDir = mMovementDirection;
            if (curDir != -mMovementDirection)
            {
                mMovementDirection = -mMovementDirection;
                mIsRight = !mIsRight;
            }
        }

        if(onGround)
            mRigidbody.AddForce(mMovementDirection * mMovementForce);
        else
            mRigidbody.AddForce(-mRigidbody.velocity);
    }

    private bool CheckFront()
    {
        RaycastHit hit;
        Vector3 dir = transform.right;
        if (!mIsRight)
            dir = -transform.right;
        if (Physics.SphereCast(transform.position, 0.5f,
            dir, out hit))
        {
            if (hit.transform.tag == "Solid")
            {
                if (mIsRight)
                {
                    if (Mathf.Abs(hit.point.x - transform.position.x) <
                        transform.lossyScale.x)
                    {
                        return true;
                    }
                }
                else
                {
                    if (Mathf.Abs(hit.point.x - transform.position.x) <=
                        transform.lossyScale.x)
                    {
                        return true;
                    }
                }

            }
        }
        return false;
    }
}
