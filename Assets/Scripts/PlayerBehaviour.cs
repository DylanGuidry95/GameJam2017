using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerBehaviour : EntityBehaviour {

	// Use this for initialization
	void Start () {
        base.Start();
	}

	// Update is called once per frame
	void Update () {
        base.Update();
        CheckForEnemy();
	}

    void CheckForEnemy()
    {
        RaycastHit hit;
        if(Physics.SphereCast(transform.position, 0.5f, -transform.up, out hit))
        {
            if (hit.transform.GetComponent<EnemyBehaviour>())
            {
                if ((transform.position - hit.point).magnitude < transform.lossyScale.y + 0.1f)
                {
                    hit.transform.GetComponent<EnemyBehaviour>().TakeDamage(mDamage);
                    GetComponent<Rigidbody>().AddForce(transform.up * 200);
                }
            }
        }
    }
}
