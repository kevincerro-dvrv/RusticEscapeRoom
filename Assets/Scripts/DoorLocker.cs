using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorLocker : MonoBehaviour {
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody rb;
    private RigidbodyConstraints rbConstraints;
    
    public Collider grabCollider;

    public UnityEvent<bool> onDoorLockedChanged = new UnityEvent<bool>();
    // Start is called before the first frame update
    void Start() {
        startPosition = transform.position;
        startRotation = transform.rotation;        
        rb = GetComponent<Rigidbody>();
        rbConstraints = rb.constraints;
        Lock(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lock(bool locked) {
        onDoorLockedChanged.Invoke(locked);

        if(locked) {
            transform.position = startPosition;
            transform.rotation = startRotation;
            grabCollider.enabled = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        } else {
            grabCollider.enabled = true;
            rb.constraints = rbConstraints;
        }
    }
}
