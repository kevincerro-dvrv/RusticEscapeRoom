using System.Collections.Generic;
using UnityEngine;

public class CabinetObjectDetector : MonoBehaviour
{
    public static CabinetObjectDetector instance;
    private List<SmartObject> objectsInside = new();
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        Debug.Log(other.gameObject);

        SmartObject smartObject = other.gameObject.GetComponent<SmartObject>();
        if (smartObject && !objectsInside.Contains(smartObject)) {
            Debug.Log("Añade objeto");
            objectsInside.Add(smartObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");

        SmartObject smartObject = other.gameObject.GetComponent<SmartObject>();
        if (smartObject && objectsInside.Contains(smartObject)) {
            Debug.Log("Elimina objeto");
            objectsInside.Remove(smartObject);
        }
    }

    public void ActivateObjectsInside(bool activate) {
        objectsInside.ForEach(o => o.Activate(activate));
    }
}
