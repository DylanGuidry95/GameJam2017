using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform mTargetPosition;
    public Vector3 mOffsets;
    public float mFollowSpeed;

    private void Update()
    {
        if (mTargetPosition != null)
            transform.position = Vector3.Lerp(transform.position,
                mTargetPosition.position - mOffsets, mFollowSpeed * Time.deltaTime);
    }

    [ContextMenu("Set Camera Position")]
    void SetCamera()
    {
        if (mTargetPosition != null)
            transform.position = mTargetPosition.position - mOffsets;
    }
}
