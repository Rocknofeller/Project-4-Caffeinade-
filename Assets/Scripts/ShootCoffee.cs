using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class ShootCoffee : MonoBehaviour
{
    public GameObject coffee;
    public Transform playerHolder;

    public int bulletSpeed;
    public float despawnTime = 3.0f;

    public bool shootAble = true;
    public float waitBeforeNextShot = 0.25f;

    public float bulletCount;
    public float maxBullets;
    public float reloadTime;
    public Text AmmoCount;

    public int BulletsFired = 0;

    public GameObject pauseCheck;


    private void Start()
    {
        bulletCount = maxBullets;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && pauseCheck.GetComponent<PauseMenu>().GameIsPaused == false)
        {
            if (shootAble)
            {
                shootAble = false;
                Shoot();
                StartCoroutine(ShootingYield());
            }
        }

        AmmoCount.text = bulletCount.ToString("0");
    }

    IEnumerator ShootingYield()
    {
        if (bulletCount != 0)
        {
            yield return new WaitForSeconds(waitBeforeNextShot);
            shootAble = true;
        }

    }
    void Shoot()
    {
        var bullet = Instantiate(coffee, playerHolder.position, playerHolder.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        AnalyticsResult analyticsResult = Analytics.CustomEvent("CoffeeFired", new Dictionary<string, object> { { "bulletsFired", BulletsFired } });
        Debug.Log("analyticsResult: " + analyticsResult);
        BulletsFired++;

        bulletCount -= 1;
        Debug.Log(bulletCount);
        if (bulletCount == 0)
        {
            Debug.Log("Reloading");
            shootAble = false;
            StartCoroutine(ReloadCoroutine());
        }

        Destroy(bullet, despawnTime);
    }

    IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(reloadTime);
        bulletCount = maxBullets;
        shootAble = true;
        Debug.Log("Reloaded");
    }
}
