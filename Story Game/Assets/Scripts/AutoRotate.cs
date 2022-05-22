using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    Quaternion rot1;
    private int a;

    private void Awake()
    {
        a = 1;
        rot1 = transform.rotation;
    }
    // Start is called before the first frame update
    void Start()
    {

        switch (a)
        {
            case 0:
                transform.rotation = rot1;
                Debug.Log("case 0");
                break;
            case 1:
                rot1 = Quaternion.AngleAxis(90, Vector3.up);
                transform.rotation = rot1;
                transform.GetChild(0).transform.localPosition = new Vector3(transform.GetChild(0).transform.localPosition.x + 100, transform.GetChild(0).transform.localPosition.y, transform.GetChild(0).transform.localPosition.z);
                Debug.Log("case 1");
                break;
            case 2:
                rot1 = Quaternion.AngleAxis(180, Vector3.up);
                transform.rotation = rot1;
                transform.GetChild(0).transform.localPosition = new Vector3(transform.GetChild(0).transform.localPosition.x + 100, transform.GetChild(0).transform.localPosition.y, transform.GetChild(0).transform.localPosition.z + 100);
                Debug.Log("case 2");
                break;
            case 3:
                rot1 = Quaternion.AngleAxis(270, Vector3.up);
                transform.rotation = rot1;
                transform.GetChild(0).transform.localPosition = new Vector3(transform.GetChild(0).transform.localPosition.x, transform.GetChild(0).transform.localPosition.y, transform.GetChild(0).transform.localPosition.z + 100);
                Debug.Log("case 3");
                break;
        }
    }
}
