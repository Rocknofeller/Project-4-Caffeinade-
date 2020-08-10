using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCoffee : MonoBehaviour
{
    public GameObject coffee;
    public Transform playerHolder;

    public int bulletSpeed;
    public float despawnTime = 3.0f;

    public bool shootAble = true;
    public float waitBeforeNextShot = 0.25f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (shootAble)
            {
                shootAble = false;
                Shoot();
                StartCoroutine(ShootingYield());
            }
        }
    }

    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(waitBeforeNextShot);
        shootAble = true;
    }
    void Shoot()
    {
        var bullet = Instantiate(coffee, playerHolder.position, playerHolder.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        Destroy(bullet, despawnTime);
    }
}
