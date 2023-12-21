using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzlePiece : MonoBehaviour
{
    private XRSocketInteractor[] puzzleSockets;

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
        foreach(XRSocketInteractor xrsi in puzzleSockets) {
            if (xrsi.selectTarget != null) {
                PuzzlePiece puzzlePiece = xrsi.selectTarget.GetComponent<PuzzlePiece>();
            }
        }
    }
}
