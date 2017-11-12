using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapCamera : MonoBehaviour
{
    public Transform mInitialTransform;
    public Transform mLookAtPosition;
    public Transform mMapPosition;
    public Vector3 mOffSet;

    private void Start()
    {
        mInitialTransform = transform;
        transform.position = mLookAtPosition.transform.position + mOffSet;
    }

    private void Update()
    {
        if (mLookAtPosition != null)
        {

            transform.LookAt(mLookAtPosition.transform.position);
            transform.Translate(Vector3.right  * Time.deltaTime);
        }
        else
        {
            transform.LookAt(mMapPosition.transform.position);
            transform.Translate(Vector3.right * Time.deltaTime);
        }
    }
}
