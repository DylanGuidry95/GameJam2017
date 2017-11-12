using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : EntityMovement
{
    //Max Jump DIstance is 6 units
    public float mMaxSpeed;
    public void Update()
    {
        base.Update();
        bool canJump = IsGrounded();

        float horizontal = Input.GetAxis("Horizontal") * mMovementForce;

        if (!canJump)
            horizontal = 0;

        Vector3 movementForce = new Vector3(horizontal, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
            mRigidbody.AddForce(transform.up * mJumpForce);

        if (mIsInvert)
            movementForce = -movementForce;

        mRigidbody.AddForce(movementForce);

        if(mRigidbody.velocity.x > mMaxSpeed)
            mRigidbody.velocity = new Vector3(mMaxSpeed, mRigidbody.velocity.y, 0);
        if (mRigidbody.velocity.x < -mMaxSpeed)
            mRigidbody.velocity = new Vector3(-mMaxSpeed, mRigidbody.velocity.y, 0);
    }
}