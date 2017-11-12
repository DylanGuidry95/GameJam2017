using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EntityMovement : MonoBehaviour
{
    public float mMovementForce;
    public float mJumpForce;
    [Tooltip("Inverts the movement of the object")]
    public bool mIsInvert;

    protected Rigidbody mRigidbody;
    [SerializeField]
    protected Vector3 mGravityForce;

    // Use this for initialization
    protected void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
        mRigidbody.useGravity = false;
        mGravityForce = new Vector3(0, -9.81f, 0) * mRigidbody.mass;
        mRigidbody.freezeRotation = true;
    }

    protected void Update()
    {
        mRigidbody.AddForce(mGravityForce);
    }

    public void InvertMovement()
    {
        bool currentMovementState = mIsInvert;
        mIsInvert = !mIsInvert;
        if (mIsInvert != currentMovementState)
        {
            transform.up = -transform.up;
            mGravityForce = -mGravityForce;
        }
    }

    protected bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.BoxCast(transform.position, new Vector3(transform.lossyScale.x, 0, 0),
            -transform.up, out hit))
        {
            if (hit.transform.tag == "Solid")
            {
                if (!mIsInvert)
                {
                    if (transform.position.y - hit.point.y <= transform.lossyScale.y)
                        return true;
                }
                else
                {
                    if (hit.point.y - transform.position.y <= transform.lossyScale.y)
                        return true;
                }
            }
        }
        return false;
    }
}
