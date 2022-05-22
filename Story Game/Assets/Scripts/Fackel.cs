using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fackel : MonoBehaviour
{
    [SerializeField] ParticleSystem paticle1;
    [SerializeField] ParticleSystem paticle2;

    [SerializeField] GameObject lights;

    [Header("0 = nichts, 1 = On, 2 = Off")]
    public int isOn;
    private void Update()
    {
        if (isOn == 1)
        {
            paticle1.Play();
            paticle2.Play();
            lights.SetActive(true);
            isOn = 0;
        }
        else if (isOn == 2)
        {
            paticle1.Stop();
            paticle2.Stop();
            lights.SetActive(false);
            isOn = 0;
        }
    }
}
