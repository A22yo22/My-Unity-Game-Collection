using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rüstung : MonoBehaviour
{
    [SerializeField] GameObject brustPanzer;
    [SerializeField] GameObject armPanzerLeft;
    [SerializeField] GameObject armPanzerRight;

    [SerializeField] bool holeState;

    private void Update()
    {
        HoleRüstungActive(holeState);
    }

    public void HoleRüstungActive(bool state)
    {
        BrustPanzerActive(state);
        ArmPanzerLeftActive(state);
        ArmPanzerRightActive(state);
    }

    public void BrustPanzerActive(bool state)
    {
        brustPanzer.SetActive(state);
    }

    public void ArmPanzerLeftActive(bool state)
    {
        armPanzerLeft.SetActive(state);
    }

    public void ArmPanzerRightActive(bool state)
    {
        armPanzerRight.SetActive(state);
    }
}
