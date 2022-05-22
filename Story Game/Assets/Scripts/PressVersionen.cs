using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class PressVersionen : MonoBehaviour
{
    [SerializeField] PlayerMovment playerScript;

    [SerializeField] GameObject interact;
    [SerializeField] GameObject toTalkTo;
    [SerializeField] GameObject toPick;
    [SerializeField] GameObject npcName;
    [SerializeField] GameObject objectName;

    [SerializeField] GameObject TextZeugs;
    [SerializeField] GameObject TextPanelText;

    [SerializeField] GameObject Inventory;

    [SerializeField] PlayableDirector talkZoom;

    [SerializeField] GameObject Camer;

    //Verbirgt alle UI elemente
    public void ResetPressOptions()
    {
        interact.SetActive(false);
        toTalkTo.SetActive(false);
        toPick.SetActive(false);
        npcName.SetActive(false);
        objectName.SetActive(false);
    }

    //setzt das Inventar auf den gewunschnten state
    public void SetStateInventory(bool OnOff)
    {
        Inventory.SetActive(OnOff);
    }

    //Schließt oder geht zum nächsten Panel
    public void ResetTextPanel()
    {
        if(panelNumbersout > panelNumber)
        {
            panelNumber += 1;
        }
        else
        {
            TextZeugs.SetActive(false);

            playerScript.isCutScene = false;

            Camer.GetComponent<Animator>().SetBool("talkZoom", false);
        }
    }

    //Zeigt die Einstellung für das sprechen zu einem NPC an
    public void TalkToNPC(string name)
    {
        interact.SetActive(true);
        toTalkTo.SetActive(true);
        toPick.SetActive(false);
        npcName.SetActive(true);
        objectName.SetActive(false);

        npcName.GetComponent<TMP_Text>().text = name;
    }

    //Zeigt die Einstellung fur das aufheben eines objects
    public void InteractWithObject(string objectname)
    {
        interact.SetActive(true);
        toTalkTo.SetActive(false);
        toPick.SetActive(true);
        npcName.SetActive(false);
        objectName.SetActive(true);

        objectName.GetComponent<TMP_Text>().text = objectname;
    }

    int panelNumber;
    int panelNumbersout;

    //Schreibt auf das Panel den gewünschten Text
    public IEnumerator ShowText(string[] text, int panelNumbers)
    {
        playerScript.isCutScene = true;

        talkZoom.Play();

        yield return new WaitForSeconds(1.25f);

        Camer.GetComponent<Animator>().SetBool("talkZoom", true);

        TextZeugs.SetActive(true);

        panelNumbersout = panelNumbers;

        while (panelNumbers > panelNumber)
        {
            TextPanelText.GetComponent<TMP_Text>().text = text[panelNumber];
            yield return new WaitForSeconds(0.1f);
        }

        TextZeugs.SetActive(false);
        playerScript.isCutScene = false;
        Camer.GetComponent<Animator>().SetBool("talkZoom", false);
        panelNumber = 0;
    }
}
