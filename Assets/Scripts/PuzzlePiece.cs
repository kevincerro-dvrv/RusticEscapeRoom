using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzlePiece : MonoBehaviour {
    private MeshRenderer meshRenderer;

    private InteractionLayerMask initialInteractionLayerMask;
    private InteractionLayerMask noHandsInteraction;
    // Start is called before the first frame update
    void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
        if(meshRenderer == null) {
            Debug.Log("[PuzzlePiece] " + gameObject.name + " Non se atopou o meshRenderer");
        }


        XRGrabInteractable xrGrabInteractable = GetComponent<XRGrabInteractable>();
        initialInteractionLayerMask = xrGrabInteractable.interactionLayers;
        noHandsInteraction = initialInteractionLayerMask & ~InteractionLayerMask.GetMask("Default");

    }

    // Update is called once per frame
    void Update() {
        
    }

    public void SetMaterial(Material newMaterial) {
        meshRenderer.material = newMaterial;
    }
}
