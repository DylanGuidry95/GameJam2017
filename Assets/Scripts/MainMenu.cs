using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text mSaveText;

	public void PlayClick()
    {
        SceneManager.LoadScene("16.WorldMap");
    }

    public void ResetClick()
    {
        PlayerPrefs.DeleteAll();
        StartCoroutine(FadeMessage());
    }

    public void ExitClick()
    {
        Application.Quit();
    }

    IEnumerator FadeMessage()
    {
        while(true)
        {
            mSaveText.text = "Saves Cleared";
            yield return new WaitForSeconds(5.0f);
            mSaveText.text = "";
            break;
        }
    }
}
