using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatusPanel : MonoBehaviour
{
    private GameObject tower;

    private Image towerImage;
    private Text towerPowerText;
    private Text towerAttackSpeedText;
    private Text towerRangeText;

    private void OnEnable()
    {
        tower = GameObject.Find("ObjectDetector").GetComponent<ObjectDetector>().clickTower;
        towerImage = transform.GetChild(0).GetComponentInChildren<Image>();
        towerPowerText = transform.GetChild(1).GetComponentInChildren<Text>();
        towerAttackSpeedText = transform.GetChild(2).GetComponentInChildren<Text>();
        towerRangeText = transform.GetChild(3).GetComponentInChildren<Text>();

        towerImage.sprite = tower.GetComponent<SpriteRenderer>().sprite;
        towerPowerText.text = tower.GetComponent<TowerStatsHandler>().CurrentStates.power.ToString();
        towerAttackSpeedText.text = tower.GetComponent<TowerStatsHandler>().CurrentStates.delay.ToString();
        towerRangeText.text = tower.GetComponent<TowerStatsHandler>().CurrentStates.attackRange.ToString();
    }
}
