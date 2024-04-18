using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartObject : MonoBehaviour {
    public GameObject mainObject;
    public string label;
 

    public void Activate(bool activate) {
        mainObject.SetActive(activate);
    }
}
