using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzleBoard : MonoBehaviour
{
    private XRSocketInteractor[] puzzleSockets;

    private bool isGrabbed = false;
    public bool IsGrabbed {
        get{
            return isGrabbed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        puzzleSockets = GetComponentsInChildren<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivatePuzzlePiecesHandInteraction(bool active)
    {
        isGrabbed = active;
        foreach (XRSocketInteractor xrsi in puzzleSockets) {
            if (xrsi.selectTarget != null) {
                PuzzlePiece puzzlePiece = xrsi.selectTarget.GetComponent<PuzzlePiece>();
                puzzlePiece.ActivateHandsInteraction(active);
            }
        }
    }
}
