using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EntityBehaviour : MonoBehaviour
{
    public float mMovementForce;
    public float mJumpForce;
    [Tooltip("Inverts the movement of the object")]
    public bool mIsInvert;
    public string mName;

    protected Rigidbody mRigidbody;
    [SerializeField]
    protected Vector3 mGravityForce;

    // Use this for initialization
    protected void Start()
    {
        if (gameObject.name != mName)
            gameObject.name = mName;
        mRigidbody = GetComponent<Rigidbody>();
        mRigidbody.useGravity = false;
        mGravityForce = new Vector3(0, -9.81f, 0) * mRigidbody.mass;
        if (mName == "")
            mName = "Defualt";
        gameObject.name = mName;
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
}
