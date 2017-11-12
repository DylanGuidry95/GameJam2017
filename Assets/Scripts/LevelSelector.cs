using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public string mName;
    public int mLevelNumber;
    public bool mIsLocked;
    public bool mIsComplete;
    public bool mDefaultLockedState;
    PlayerPrefs mSaveData;

    private void Awake()
    {
        mIsLocked = PlayerPrefs.GetInt(mName + "IsLocked") == 1 ? true : false;
        mIsComplete =  PlayerPrefs.GetInt(mName + "IsComplete") == 1 ? true : false;
    }

    [ContextMenu("clear")]
    void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        GetComponent<Renderer>().material.color = Color.blue;
        mIsLocked = mDefaultLockedState;
        mIsComplete = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            ClearSave();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(mName + "IsLocked", (mIsLocked) ? 1 : 0);
        PlayerPrefs.SetInt(mName + "IsComplete", (mIsComplete) ? 1 : 0);
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(mName);
    }
}
