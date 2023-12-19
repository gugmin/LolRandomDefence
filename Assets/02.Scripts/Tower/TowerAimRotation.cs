using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _armRenderer;
    [SerializeField] private Transform _armPivot;

    [SerializeField] private SpriteRenderer _towerRenderer;

    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }
    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;

        _armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        _towerRenderer.flipX = _armRenderer.flipY;
        _armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }

}
