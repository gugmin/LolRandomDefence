using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OnStartButtonClick()
    {
         SceneManager.LoadScene("gugminScene");
    }

    public void OnContinueClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
