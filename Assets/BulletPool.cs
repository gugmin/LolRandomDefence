using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize = 20;

    private List<GameObject> bullets = new List<GameObject>();

    void Start()
    {

        InitializePool();
    }

    void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
    }

    public GameObject GetBullet(Vector3 position, Quaternion rotation)
    {
        Debug.Log("ÃÑ¾ËÃæÀüµÇ°íÀÕ³Ä000000000000");
        foreach (GameObject bullet in bullets)
        {
            
            if (!bullet.activeInHierarchy)
            {
                
                bullet.transform.position = position;
                bullet.transform.rotation = rotation;
                bullet.SetActive(true);
                return bullet;
            }
        }
        return null;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}