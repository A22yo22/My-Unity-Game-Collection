using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaktbal : MonoBehaviour
{
    [Header("Brauch man nicht für die Programmierung des Object/NPC´s Component")]
    [SerializeField] Inventory inventoryScript;
    bool inCollider = false;
    [SerializeField] PressVersionen pressVerion;

    [Header("True = NPC, False = Object")]
    [SerializeField] bool npcORObject;

    [Header("True = text panel, False = object pick up")]
    [SerializeField] bool textPanelORObjectPickUp;

    [Header("Gib den Text für jedes Panel ein")]
    [SerializeField] string[] textpanelText;

    [Header("Name des NPC`s")]
    [SerializeField] string npcName;

    [Header("Name des Objects")]
    [SerializeField] string objectName;

    [Header("Refercen zu item")]
    [SerializeField] GameObject item;

    [Header("Wie viele items")]
    [SerializeField] int itemAnzahl;
    //Prüft ob Player in den Interact Collider gekommen ist und startet die jewalige Function 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Prüft ob es ein NPC ist
            if (npcORObject)
            {
                //Startet TalkToNPC Fucton und übergibt den NPC Namen
                pressVerion.TalkToNPC(npcName);
            }
            //wenn es kein NPC ist starte die Interact with object functon
            else
            {
                //übergibt der InteractWithObject function den Namen des objectes
                pressVerion.InteractWithObject(objectName);
            }

            //Vergirg das Inventar
            pressVerion.SetStateInventory(false);

            //sagt das man im collider ist
            inCollider = true;
        }
    }

    //Prüft ob der spieler den Interact Collider verlassen hat
    private void OnTriggerExit(Collider other)
    {
        //Sagt das der spieler verlassten hat
        inCollider = false;
        //Disabeld alle Interact UI elemente
        pressVerion.ResetPressOptions();

        //Zeigt das Inventar wieder an
        pressVerion.SetStateInventory(true);
    }

    private void Update()
    {
        //Wenn Player im Interact Collider ist und den E butten gedrückt hat 
        if(inCollider && Input.GetKeyDown(KeyCode.E))
        {
            //Disabeld alle Interact UI elemente
            pressVerion.ResetPressOptions();

            //Prüft ob es ein text oder ein object ist
            if (textPanelORObjectPickUp)
            {
                //öffnet text Panel und schreibt text rein
                StartCoroutine(pressVerion.ShowText(textpanelText, textpanelText.Length));
            }
            else
            {
                //Gibt dem player das item;
                StartCoroutine(inventoryScript.SetInventory(item, itemAnzahl));
                Destroy(gameObject);
            }
        }
    }
}
