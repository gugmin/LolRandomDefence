using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void OnStartButtonClick()
    {
         SceneManager.LoadScene("gugminScene");
    }
}
