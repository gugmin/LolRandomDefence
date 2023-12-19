using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OnStartButtonClick()
    {
         SceneManager.LoadScene("BinheeScene");
    }

    public void OnContinueClick()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnEndClick()
    {
        SceneManager.LoadScene("EndScene");
    }
}
