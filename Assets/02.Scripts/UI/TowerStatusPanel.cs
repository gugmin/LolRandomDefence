using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatusPanel : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    private Image towerImage;
    private Text towerPowerText;
    private Text towerAttackSpeedText;
    private Text towerRangeText;

    private void OnEnable()
    {
        tower = GameObject.Find("ObjectDetector").GetComponent<ObjectDetector>().clickTower;
        towerImage = transform.GetChild(0).GetComponent<Image>();
        towerPowerText = transform.GetChild(1).GetComponent<Text>();
        towerAttackSpeedText = transform.GetChild(2).GetComponent<Text>();
        towerRangeText = transform.GetChild(3).GetComponent<Text>();

        towerImage.sprite = tower.GetComponent<SpriteRenderer>().sprite;
        towerPowerText.text = tower.GetComponent<TowerStatsHandler>().CurrentStates.power.ToString();
        towerAttackSpeedText.text = tower.GetComponent<TowerStatsHandler>().CurrentStates.delay.ToString();
        towerRangeText.text = tower.GetComponent<TowerStatsHandler>().CurrentStates.attackRange.ToString();
    }
}
