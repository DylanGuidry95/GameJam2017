using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : EntityMovement
{
    //Max Jump DIstance is 6 units
    public float mMaxSpeed;
    public void Update()
    {
        bool canJump = CanJump();
        mRigidbody.AddForce(mGravityForce);
        float horizontal = Input.GetAxis("Horizontal") * mMovementForce;

        if (!canJump)
            horizontal = 0;
        Vector3 movementForce = new Vector3(horizontal, 0, 0);

        if (mIsInvert)
            movementForce *= -1;

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
            mRigidbody.AddForce(transform.up * mJumpForce);

        mRigidbody.AddForce(movementForce);
        if(mRigidbody.velocity.x > mMaxSpeed)
            mRigidbody.velocity = new Vector3(5, mRigidbody.velocity.y, 0);
        transform.right = new Vector3(mRigidbody.velocity.x, 0, 0);
    }

    private bool CanJump()
    {
        RaycastHit hit;
        if (Physics.BoxCast(transform.position, new Vector3(transform.lossyScale.x, 0,0),
            -transform.up, out hit))
        {
            if (hit.transform.tag == "Solid")
            {
                if (transform.position.y - hit.transform.position.y <= transform.lossyScale.y)
                    return true;
            }
        }
        return false;
    }
}
