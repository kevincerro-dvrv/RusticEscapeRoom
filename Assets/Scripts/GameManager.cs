using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public Material[] puzzlePieceMaterials;
    public Material materialOne;
    public PuzzlePiece[] puzzlePieces;
    public DoorKeyButton[] doorPanelButtons;

    public BrazoBalanza brazoBalanza;

    private int[] puzzlePieceCode;

    public GameObject[] redLigths;
    public GameObject[] greenLigths;

    public Animator doorAnimator;

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
            //puzzlePiece.SetMaterial(materialOne);
            //puzzlePiece.GetComponent<MeshRenderer>().material = puzzlePieceMaterials[puzzlePieceCode[i]];
            i++;
        }

        brazoBalanza.OnWeightChanged += BalanzaWeightChanged;
        
    }

    // Update is called once per frame
    void Update() {
        if (greenLigths[0].activeSelf && greenLigths[1].activeSelf && greenLigths[2].activeSelf) {
            doorAnimator.SetBool("Open", true);
        } else {
            doorAnimator.SetBool("Open", false);
        }
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

    public void CheckEinsteinPuzzle() {
        redLigths[1].SetActive(false);
        greenLigths[1].SetActive(true);
    }

    private void BalanzaWeightChanged(bool weightCorrect) {
        if(weightCorrect) {
            redLigths[2].SetActive(false);
            greenLigths[2].SetActive(true);
        } else {
            redLigths[2].SetActive(true);
            greenLigths[2].SetActive(false);
        }
     }
}
