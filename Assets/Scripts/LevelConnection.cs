using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelSelector), typeof(LineRenderer))]
public class LevelConnection : MonoBehaviour
{
    public List<LevelSelector> mConnections;
    public LineRenderer mPath;
    public Color mLockedPathColor;
    public Color mUnLockedPathColor;
    public Material mPathMaterial;
    // Use this for initialization
    void Start ()
    {
        if (mPath == null)
            mPath = GetComponent<LineRenderer>();
        mPath.positionCount = (mConnections.Count * 2);
        mPath.SetPosition(0, new Vector3(transform.position.x, 0.5f, transform.position.z));
        int counter = 1;
        foreach(var connection in mConnections)
        {
            Vector3 newpos = new Vector3(connection.transform.position.x, 0.5f,
                connection.transform.position.z);
            mPath.SetPosition(counter++, newpos);
            if(counter <= mConnections.Count)
                mPath.SetPosition(counter++, mPath.GetPosition(0));
        }
        mPathMaterial = new Material(mPathMaterial.shader);
        mPathMaterial.name = "Test";
        mPath.material = mPathMaterial;
	}

	// Update is called once per frame
	void Update ()
    {
        if (GetComponent<LevelSelector>().mIsComplete)
        {
            mPathMaterial.color = mUnLockedPathColor;
        }
        else if(!GetComponent<LevelSelector>().mIsComplete &&
            mPathMaterial.color != mLockedPathColor)
        {
            mPathMaterial.color = mLockedPathColor;
        }
	}
}
