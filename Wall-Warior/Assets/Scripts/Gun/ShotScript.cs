using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    [SerializeField] Transform spawnBullet;
    [SerializeField] Transform spawnRayCast;
    public GameObject bullet;
    AudioSource sound;
    [SerializeField] LayerMask targetLayer;

    public void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        GameObject settings = Instantiate(bullet, spawnBullet);
        settings.AddComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 200), ForceMode.Impulse);
        settings.GetComponent<Rigidbody>().useGravity = false;
        sound.Play();

        ShootRayCast();

        StartCoroutine(WaitLong(settings));
    }

    private void ShootRayCast()
    {
        RaycastHit hit;

        if (Physics.Raycast(spawnRayCast.position, spawnRayCast.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, targetLayer))
        {
            Debug.Log("Hit  target " + hit.transform.name);
            Destroy(hit.collider.gameObject);
        }
    }

    IEnumerator WaitLong(GameObject x)
    {
        yield return new WaitForSeconds(20);
        Destroy(x.gameObject);
    }
}
