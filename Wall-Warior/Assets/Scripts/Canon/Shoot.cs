using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform Spawn;

    public void Start()
    {
        StartCoroutine(ShootBullet());
    }
    IEnumerator ShootBullet()
    {
        yield return new WaitForSeconds(1);
        GameObject bulletSettings = Instantiate(bullet, Spawn);
        bulletSettings.AddComponent<Rigidbody>().AddForce(new Vector3(100, 0, 0), ForceMode.Impulse);
        StartCoroutine(ShootBullet());
        StartCoroutine(WaitLong(bulletSettings));
    }

    IEnumerator WaitLong(GameObject x)
    {
        yield return new WaitForSeconds(30);
        Destroy(x.gameObject);
    }
}
