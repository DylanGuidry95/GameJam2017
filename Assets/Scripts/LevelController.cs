using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerBehaviour>())
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "IsLocked", 0);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "IsComplete", 1);
            SceneManager.LoadScene("13.WorldMap");
        }
    }
}
