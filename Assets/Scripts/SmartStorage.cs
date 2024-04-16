using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartStorage : MonoBehaviour {
    private List<SmartObject> storedObjects;

    // Start is called before the first frame update
    void Start() {
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
            so.Activate(false);
            storedObjects.Add(so);
        }
    }

    void OnTriggerExit(Collider other) {
        Debug.Log(other.gameObject.name);
        SmartObject so = other.GetComponent<SmartObject>();
        if(so != null) {
            storedObjects.Remove(so);
        }
    }

    public void Lock(bool locked) {
        Debug.Log("[SmartStorage] Lock " + locked);
    }
}
