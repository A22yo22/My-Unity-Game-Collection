using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class Web : MonoBehaviour
{
    [SerializeField] EventsForButtons EventScripts;

    [SerializeField] TMP_Text Fehler;

    void Start()
    {
        //StartCoroutine(Login("A22yo22", "123456"));
    }

    IEnumerator GetDate()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/UnityBackendTutorial/GetDate.php"))
        {
            yield return www.Send();

            if (!www.isNetworkError || !www.isHttpError)
            {
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }
        }
    }

    IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/UnityBackendTutorial/GetUsers.php"))
        {
            yield return www.Send();

            if (!www.isNetworkError || !www.isHttpError)
            {
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }
        }
    }

    public void LogIn(string username, string password)
    {
        StartCoroutine(LoginIE(username, password));
    }

    IEnumerator LoginIE(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackendTutorial/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                EventScripts.LogInCanvas.SetActive(false);
                EventScripts.GameCanvas.SetActive(true);

                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public void Register(string username, string password)
    {
        StartCoroutine(RegisterIE(username, password));
    }

    IEnumerator RegisterIE(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackendTutorial/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                
                string x = www.downloadHandler.text;
                Fehler.text = x;

                if (x == "Username already exists.  ")
                {
                    EventScripts.RegisterCanvas.SetActive(false);
                    EventScripts.GameCanvas.SetActive(true);
                }
                else
                {
                    Fehler.text = x;
                }
            }
        }
    }


}
