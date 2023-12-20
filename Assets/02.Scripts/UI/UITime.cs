using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITime : MonoBehaviour
{
    private Text timeText;

    private float currentTime;

    private void Start()
    {
        timeText = transform.GetChild(0).GetComponent<Text>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        timeText.text = currentTime.ToString("N2");
    }

    public void Reset()
    {
        currentTime = 0f;
    }
}
