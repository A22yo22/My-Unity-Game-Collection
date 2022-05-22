using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartCutScene : MonoBehaviour
{
    [SerializeField] PlayableDirector CutScene;
    [SerializeField] bool OnColEnter;
    [SerializeField] float cutSceneLenghs;
    [SerializeField] PlayerMovment playerScript;

    //Prüft ob player in Cut Scene Collider ist wenn ja startet Cut Scene
    private void OnTriggerEnter(Collider other)
    {
        if (OnColEnter)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                StartCutSceneFunc();
            }
        }
    }

    //Startrt Cut Scene
    public void StartCutSceneFunc()
    {
        //Startet animation
        CutScene.Play();
        //setzt im Player Script isCutScene auf true damit der spieler sich ncht bewegen kann
        playerScript.isCutScene = true;

        //ruft die function cutSceneEnded auf
        StartCoroutine(CutSceneEnded());
    }

    //Wartet bis die Cut Scene vorbei ist und setzt dann isCutScene zu false
    IEnumerator CutSceneEnded()
    {
        yield return new WaitForSeconds(cutSceneLenghs);
        playerScript.isCutScene = false;
    }
}
