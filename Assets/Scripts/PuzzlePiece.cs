using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzlePiece : MonoBehaviour {
    private MeshRenderer meshRenderer;

    private InteractionLayerMask initialInteractionLayerMask;
    private InteractionLayerMask noHandsInteraction;

    private XRGrabInteractable xrGrabInteractable;

    // Start is called before the first frame update
    void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
        if(meshRenderer == null) {
            Debug.Log("[PuzzlePiece] " + gameObject.name + " Non se atopou o meshRenderer");
        }


        xrGrabInteractable = GetComponent<XRGrabInteractable>();
        initialInteractionLayerMask = xrGrabInteractable.interactionLayers;
        noHandsInteraction = initialInteractionLayerMask & ~InteractionLayerMask.GetMask("Default");
    }

    // Update is called once per frame
    void Update() {

    }

    public void SetMaterial(Material newMaterial) {
        meshRenderer.material = newMaterial;
    }

    public void OnSelectEntered(SelectEnterEventArgs args) {
        PuzzleBoard puzzleBoard = args.interactor.GetComponentInParent<PuzzleBoard>();
        if (puzzleBoard != null && puzzleBoard.IsGrabbed) {
            ActivateHandsInteraction(false);
        }
    }

    public void ActivateHandsInteraction(bool active) {
        if (active) {
            xrGrabInteractable.interactionLayers = initialInteractionLayerMask;
        } else {
            xrGrabInteractable.interactionLayers = noHandsInteraction;
        }
    }
}
