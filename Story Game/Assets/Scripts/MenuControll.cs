using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class MenuControll : MonoBehaviour
{
    [SerializeField] GameObject Options;
    [SerializeField] GameObject Menu;
    [SerializeField] Volume volume;
    [SerializeField] Toggle toggle;

    //wenn Start Button gedrückt wurde Start Spiel
    public void OnStart()
    {
        SceneManager.LoadScene("Test");
    }

    //wenn Optons Button gedrückt wurde öffne Options Menu
    public void OnOptions()
    {
        Menu.SetActive(false);
        Options.SetActive(true);
    }

    //wenn Exit Button gedrückt wurde Schließe spiel
    public void OnExit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    //öffnet Main Meue
    public void ResetMenu()
    {
        Menu.SetActive(true);
        Options.SetActive(false);
    }

    //disabeld Bloom
    public void OnBloom()
    {
        volume.enabled = toggle.isOn;
    }
}
