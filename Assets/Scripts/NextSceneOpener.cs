using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneOpener : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    private IEnumerator LoadNextSceneAfterDelay()
    {
        // ∆дЄм указанное количество секунд
        yield return new WaitForSeconds(5f);


        SceneManager.LoadScene(PlayerPrefs.GetString("EndingScene", "Menu"));

    } 
}
