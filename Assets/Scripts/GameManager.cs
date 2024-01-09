using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public Material[] puzzlePieceMaterials;
    public Material materialOne;
    public PuzzlePiece[] puzzlePieces;
    public DoorKeyButton[] doorPanelButtons;

    private int[] puzzlePieceCode;

    public GameObject[] redLigths;
    public GameObject[] greenLigths;


    void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start() {
        puzzlePieceCode = new int[puzzlePieces.Length];
        int i=0;
        foreach(PuzzlePiece puzzlePiece in puzzlePieces) {
            puzzlePieceCode[i] = Random.Range(0, puzzlePieceMaterials.Length);
            puzzlePiece.SetMaterial(puzzlePieceMaterials[puzzlePieceCode[i]]);
            i++;
        }
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void CheckDoorKeyCode() {
        bool valid = true;
        for(int i=0; i< puzzlePieceCode.Length; i++) {
            if(puzzlePieceCode[i] != doorPanelButtons[i].MaterialIndex) {
                valid = false;
                break;
            }
        }

        redLigths[0].SetActive( ! valid);
        greenLigths[0].SetActive(valid);

    }

    public void UnlockEinsteinPuzzle()
    {
        redLigths[1].SetActive(false);
        greenLigths[1].SetActive(true);
    }
}
