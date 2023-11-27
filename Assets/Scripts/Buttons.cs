using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void LoadSceneButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OpenPanelButton(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void QuitGameButton()
    {
        Application.Quit();
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void SetSoundValue()
    {
        //AudioManager.
    }
}
