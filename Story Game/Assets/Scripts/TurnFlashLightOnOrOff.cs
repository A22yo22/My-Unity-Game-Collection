using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnFlashLightOnOrOff : MonoBehaviour
{
    [SerializeField] GameObject taschenlampenLight;

    public void TaschenlampeOnOrOf(bool isOn)
    {
        taschenlampenLight.SetActive(isOn);
    }
}
