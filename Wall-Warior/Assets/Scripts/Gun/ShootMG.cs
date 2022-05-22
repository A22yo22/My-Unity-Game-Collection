using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootMG : MonoBehaviour
{
    public ShotScript shotScript;
    public InputActionReference toggleReference = null;

    bool canShoot = true;

    public float value = 0;

    private void Update()
    {
        value = toggleReference.action.ReadValue<float>();
        ShootMGFunc(value);
    }

    public void ShootMGFunc(float x)
    {
        if(x != 0 && canShoot)
        {
            canShoot = false;
            StartCoroutine(ShootTimer());
        }
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(0.05f);
        shotScript.Shoot();
        canShoot = true;
    }
}
