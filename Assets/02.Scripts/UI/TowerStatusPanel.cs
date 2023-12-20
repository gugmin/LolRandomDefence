using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatusPanel : MonoBehaviour
{
    private TowerStatsHandler towerStatsHandler;
    [SerializeField] private Image towerImage;
    [SerializeField] private Text towerPowerText;
    [SerializeField] private Text towerAttackSpeedText;
    [SerializeField] private Text towerRangeText;

    private void OnEnable()
    {
        towerImage.sprite = towerStatsHandler.gameObject.GetComponent<SpriteRenderer>().sprite;
        towerPowerText.text = towerStatsHandler.CurrentStates.power.ToString();
        towerAttackSpeedText.text = towerStatsHandler.CurrentStates.delay.ToString();
        towerRangeText.text = towerStatsHandler.CurrentStates.attackRange.ToString();
    }

    public void SetTowerStatusHandler(Transform stat)
    {
        towerStatsHandler = stat.GetComponent<TowerStatsHandler>();
        this.gameObject.SetActive(true);
    }
}
