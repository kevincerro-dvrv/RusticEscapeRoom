using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SmartWeightProvider : MonoBehaviour {
    [SerializeField]
    private float weigth;
    private bool isGraviting;
    // Start is called before the first frame update
    void Start() {
        isGraviting = true;
        XRGrabInteractable xrgi = GetComponent<XRGrabInteractable>();

        if(xrgi == null) {
            xrgi = transform.parent.GetComponent<XRGrabInteractable>();
        }

        xrgi.selectEntered.AddListener(SelectEnter);
        xrgi.selectExited.AddListener(SelectExit);
    }

    public float GetWeigth() {
        if(isGraviting) {
            return weigth;
        }
        return 0;
    }

    private void SelectEnter(SelectEnterEventArgs args) {
        SetGraviting(false);
    }

    private void SelectExit(SelectExitEventArgs args) {
        SetGraviting(true);
    }
 
    public void SetGraviting (bool graviting) {
        isGraviting = graviting;
    }
}
