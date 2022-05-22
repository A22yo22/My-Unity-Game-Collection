using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventsForButtons : MonoBehaviour
{
    [SerializeField] Web webScript;

    public InterstitialAd InterstitialLoader;
    public Button InterButton;

    public RewardedAdsButton RewardLoader;

    public GameObject LogInCanvas;
    public GameObject RegisterCanvas;
    public GameObject GameCanvas;

    public int Score;

    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text ScoreText2;

    [SerializeField] TMP_InputField usernameLogIn;
    [SerializeField] TMP_InputField usernameRegister;
    [SerializeField] TMP_InputField passwordLogIn;
    [SerializeField] TMP_InputField passwordRegister;

    private void Update()
    {
        ScoreText2.text = Score.ToString() + "$";
    }

    public void InterstitalAd()
    {
        //disabeld Button
        InterButton.enabled = false;

        //Started AD
        InterstitialLoader.ShowAd();

        //Warted für 10 Sec und zeigt dann Ad
        StartCoroutine(InterWaitSec());
    }

    IEnumerator InterWaitSec()
    {
        //wartrt 10 sekund damit man dass Wlan nicht einfach auschaltetd
        yield return new WaitForSeconds(10);

        InterButton.enabled = true;

        //fügt 100$ zu Score
        Score += 100;

        //setst Score int zu Score Text
        ScoreText.text = Score.ToString() + "$";
        ScoreText2.text = Score.ToString() + "$";
    }

    public void RewardedAd()
    {
        RewardLoader.ShowAd();
        Score += 200;
        ScoreText2.text = Score.ToString() + "$";
    }

    public void OnLogIn()
    {
        string username = usernameLogIn.text;
        string password = passwordLogIn.text;

        webScript.LogIn(username, password);
    }

    public void OnLogInChanger()
    {
        LogInCanvas.SetActive(true);
        RegisterCanvas.SetActive(false);
    }

    public void OnRegisterChanger()
    {
        LogInCanvas.SetActive(false);
        RegisterCanvas.SetActive(true);
    }
    
    public void OnRegister()
    {
        string username = usernameRegister.text;
        string password = passwordRegister.text;

        webScript.Register(username, password);
    }
}
