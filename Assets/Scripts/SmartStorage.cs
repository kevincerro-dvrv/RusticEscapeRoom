using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartStorage : MonoBehaviour {
    private List<SmartObject> storedObjects;
    private bool doorLocked;


    void Awake() {
        storedObjects = new List<SmartObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.name);
        SmartObject so = other.GetComponent<SmartObject>();
        if(so != null) {
            if(doorLocked) {
                so.Activate(false);
            }
            if( ! storedObjects.Contains(so)) {
                storedObjects.Add(so);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        Debug.Log("[SmartStorage] OnTriggerExit " + other.gameObject.name);
        SmartObject so = other.GetComponent<SmartObject>();
        if(so != null) {
            storedObjects.Remove(so);
        }
    }

    public void Lock(bool locked) {
        Debug.Log("[SmartStorage] Lock " + locked);
        doorLocked = locked;
        if(locked) {
            foreach(SmartObject so in storedObjects) {
                so.Activate(false);
            }
        } else {
            foreach(SmartObject so in storedObjects) {
                so.Activate(true);
                Debug.Log("[SmartStorage] Lock activando " + so.label);
            }
        }
    }
}
