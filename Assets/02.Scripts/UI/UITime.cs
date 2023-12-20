using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITime : MonoBehaviour
{
    private float time;
    public Text timeText;

    void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("N2");
    }
}
