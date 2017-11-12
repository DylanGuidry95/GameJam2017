using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : EntityBehaviour
{
    public void Update()
    {
        mRigidbody.AddForce(mGravityForce);
        float horizontal = Input.GetAxis("Horizontal") * mMovementForce;

        Vector3 movementForce = new Vector3(horizontal, 0, 0);

        if (mIsInvert)
            movementForce *= -1;

        bool canJump = CanJump();
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
            mRigidbody.AddForce(transform.up * mJumpForce);        

        mRigidbody.AddForce(movementForce);
    }

    private bool CanJump()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {            
            if (hit.transform.tag == "Solid")
            {
                if (Vector3.Distance(hit.transform.position, transform.position) <= transform.lossyScale.y / 2)
                    return true;
            }
        }
        return false;
    }
}
