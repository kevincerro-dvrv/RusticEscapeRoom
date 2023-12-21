using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Puzzle
    public Material[] puzzlePieceColors;
    public PuzzlePiece[] puzzlePieces;
    private int[] puzzleCode;

    // Start is called before the first frame update
    void Start()
    {
        InitPuzzleGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitPuzzleGame()
    {
        for (int i = 0; i < puzzlePieces.Length; i++) {
            int randomIndex = Random.Range(0, puzzlePieceColors.Length);

            // Set piece color
            puzzlePieces[i].SetMaterial(puzzlePieceColors[randomIndex]);

            // Store code
            puzzleCode[i] = randomIndex;
        }
    }
}
