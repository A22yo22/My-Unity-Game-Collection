using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject Stone;

    [SerializeField] GameObject[] positions;

    [SerializeField] GameObject notgenugPlaceText;

    [SerializeField] GameObject inventoryGM;

    [SerializeField] int itemMaxCapacity = 0;
    [SerializeField] string[] pl�tzeBesetzt;

    [SerializeField] GameObject[] itemList;


    public IEnumerator SetInventory(GameObject item, int itemAnzahl)
    {

        inventoryGM.SetActive(true);

        if (itemMaxCapacity < 5)
        {
            if (ItemExists(item))
            {
                item.GetComponentInChildren<TMP_Text>().text = (SearchForItem(item) + itemAnzahl).ToString();

            }
            else
            {
                Debug.Log(ItemExists(item));
                if (pl�tzeBesetzt[0] == "1")
                {
                    item.SetActive(true);
                    item.transform.position = positions[0].transform.position;
                    pl�tzeBesetzt[0] = item.name;
                    item.GetComponentInChildren<TMP_Text>().text =  itemAnzahl.ToString();
                }
                else if (pl�tzeBesetzt[1] == "1")
                {
                    item.SetActive(true);
                    item.transform.position = positions[1].transform.position;
                    pl�tzeBesetzt[1] = item.name;
                    item.GetComponentInChildren<TMP_Text>().text = itemAnzahl.ToString();
                }
                else if (pl�tzeBesetzt[2] == "1")
                {
                    item.SetActive(true);
                    item.transform.position = positions[2].transform.position;
                    pl�tzeBesetzt[2] = item.name;
                    item.GetComponentInChildren<TMP_Text>().text = itemAnzahl.ToString();
                }
                else if (pl�tzeBesetzt[3] == "1")
                {
                    item.SetActive(true);
                    item.transform.position = positions[3].transform.position;
                    pl�tzeBesetzt[3] = item.name;
                    item.GetComponentInChildren<TMP_Text>().text = itemAnzahl.ToString();
                }
                else if (pl�tzeBesetzt[4] == "1")
                {
                    item.SetActive(true);
                    item.transform.position = positions[4].transform.position;
                    pl�tzeBesetzt[4] = item.name;
                    item.GetComponentInChildren<TMP_Text>().text = itemAnzahl.ToString();
                }


                itemMaxCapacity += 1;
            }

            yield return new WaitForSeconds(0.5f);
        }
        else
        {
            StartCoroutine(ShowInventoryFullText());
        }
    }

    //Search usw. Functions

    //Sucht nach ein item
    int xSFI;
    int SearchForItem(GameObject item)
    {
        if (pl�tzeBesetzt[0] == item.name)
        {
            int.TryParse(item.GetComponentInChildren<TMP_Text>().text, out xSFI);
        }
        else if (pl�tzeBesetzt[1] == item.name)
        {
            int.TryParse(item.GetComponentInChildren<TMP_Text>().text, out xSFI);
        }
        else if (pl�tzeBesetzt[2] == item.name)
        {
            int.TryParse(item.GetComponentInChildren<TMP_Text>().text, out xSFI);
        }
        else if (pl�tzeBesetzt[3] == item.name)
        {
            int.TryParse(item.GetComponentInChildren<TMP_Text>().text, out xSFI);
        }
        else if (pl�tzeBesetzt[4] == item.name)
        {
            int.TryParse(item.GetComponentInChildren<TMP_Text>().text, out xSFI);
        }
        return xSFI;
    }

    //Schaut ob item existiert
    bool ItemExists(GameObject item)
    {
        bool itemExists;
        if (pl�tzeBesetzt[0] == item.name)
        {
            itemExists = true;
        }
        else if (pl�tzeBesetzt[1] == item.name)
        {
            itemExists = true;
        }
        else if (pl�tzeBesetzt[2] == item.name)
        {
            itemExists = true;
        }
        else if (pl�tzeBesetzt[3] == item.name)
        {
            itemExists = true;
        }
        else if (pl�tzeBesetzt[4] == item.name)
        {
            itemExists = true;
        }
        else
        {
            itemExists = false;
        }
        return itemExists;
    }

    /*Sucht den plaz vom item
    int xIP;
    int ItemPlace(GameObject item)
    {
        if (pl�tzeBesetzt[0] == item.name)
        {
            xIP = 0;
        }
        else if (pl�tzeBesetzt[1] == item.name)
        {
            xIP = 0;
        }
        else if (pl�tzeBesetzt[2] == item.name)
        {
            xIP = 0;
        }
        else if (pl�tzeBesetzt[3] == item.name)
        {
            xIP = 0;
        }
        else if (pl�tzeBesetzt[4] == item.name)
        {
            xIP = 0;
        }
        return xIP;
    }
    */

    IEnumerator ShowInventoryFullText()
    {
        notgenugPlaceText.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        notgenugPlaceText.SetActive(false);
    }
}
