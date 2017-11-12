using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : EntityBehaviour {

	// Use this for initialization
	void Start () {
        base.Start();
	}

	// Update is called once per frame
	void Update () {
        base.Update();
        CheckForPlayer();
    }

    bool CheckForPlayer()
    {
        RaycastHit hit;
        if(Physics.SphereCast(transform.position, 0.5f, -transform.up, out hit))
        {
            if (hit.transform.GetComponent<PlayerBehaviour>())
            {
                if ((transform.position - hit.point).magnitude < transform.lossyScale.y + 0.1f)
                {
                    hit.transform.GetComponent<PlayerBehaviour>().TakeDamage(mDamage);
                    hit.transform.GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity);
                    return true;
                }
            }
        }

        if(Physics.SphereCast(transform.position, 0.5f, transform.right, out hit))
        {
            if (hit.transform.GetComponent<PlayerBehaviour>())
            {
                if ((transform.position - hit.point).magnitude < transform.lossyScale.x + 0.1f)
                {
                    hit.transform.GetComponent<PlayerBehaviour>().TakeDamage(mDamage);
                    hit.transform.GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity * 2);
                    return true;
                }
            }
        }

        if (Physics.SphereCast(transform.position, 0.5f, -transform.right, out hit))
        {

            if (hit.transform.GetComponent<PlayerBehaviour>())
            {
                if ((transform.position - hit.point).magnitude < transform.lossyScale.x + 0.1f)
                {
                    hit.transform.GetComponent<PlayerBehaviour>().TakeDamage(mDamage);
                    hit.transform.GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity * 2);
                    return true;
                }
            }
        }
        return false;
    }
}
