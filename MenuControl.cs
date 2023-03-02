using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

    public GameObject ExitButton;

    private void Start()
    {
        #if UNITY_STANDALONE || UNITY_EDITOR
        ExitButton.SetActive(true);
        #endif
    }

    public void PlayGame()
    {
        StartCoroutine(ChangeScene("Game"));
    }

    IEnumerator ChangeScene(string name)
    {
        yield return new WaitForSecondsRealtime(0.3f);
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        StartCoroutine(Exit());
    }

    IEnumerator Exit()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
