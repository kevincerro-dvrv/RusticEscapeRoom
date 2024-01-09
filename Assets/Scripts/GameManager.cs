using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public Material[] puzzlePieceMaterials;
    public Material materialOne;
    public PuzzlePiece[] puzzlePieces;
    private int[] puzzlePieceCode;
    
    public GameObject[] greenLights;
    public GameObject[] redLights;

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
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
