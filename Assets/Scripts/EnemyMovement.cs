using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EntityMovement
{
    [SerializeField]
    private Vector3 mMovementDirection;

    private new void Start()
    {
        base.Start();
        mMovementDirection = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update ()
    {
        if (CheckFront())
        {
            mMovementDirection = -mMovementDirection;
            transform.right = -transform.right;
        }

        mRigidbody.AddForce(mMovementDirection * mMovementForce);
	}

    private bool CheckFront()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit))
        {
            if (hit.transform.tag == "Solid")
            {
                if (Vector3.Distance(hit.transform.position, transform.position) <=
                    transform.lossyScale.x)
                    return true;
            }
        }
        return false;
    }
}
