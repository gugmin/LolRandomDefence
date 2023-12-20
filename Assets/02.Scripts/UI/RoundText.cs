using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundText : MonoBehaviour
{
    private Text roundText;

    private void Start()
    {
        roundText = transform.GetChild(0).GetComponent<Text>();
    }

    private void Update()
    {
        roundText.text = GameManager.instance.round.ToString();
    }
}
