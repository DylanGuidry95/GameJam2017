using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour
{
    public List<LevelSelector> mLevels;

    private void Start()
    {
        mLevels.Sort((a, b) => a.mLevelNumber.CompareTo(b.mLevelNumber));
    }

    private void Update()
    {
        if (mLevels[mLevels.Count - 1].mIsComplete)
            Debug.Log("Vicotry");
    }
}