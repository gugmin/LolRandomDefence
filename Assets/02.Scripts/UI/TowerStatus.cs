using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatus : MonoBehaviour
{
    [SerializeField] private Image towerImage;
    [SerializeField] private Text towerPower;
    [SerializeField] private Text towerAttackSpeed;
    [SerializeField] private Text towerRange;

    private void OnEnable()
    {
        towerImage = transform.GetChild(1).GetComponent<Image>();
        towerPower = transform.GetChild(2).GetComponentInChildren<Text>();
        towerAttackSpeed = transform.GetChild(3).GetComponentInChildren<Text>();
        towerRange = transform.GetChild(4).GetComponentInChildren<Text>();
    }
}
