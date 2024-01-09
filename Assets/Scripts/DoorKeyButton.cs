using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyButton : MonoBehaviour
{
    private int materialIndex;
    private MeshRenderer meshRenderer;


    // Start is called before the first frame update
    void Start()
    {
        materialIndex = Random.Range(0, GameManager.instance.puzzlePieceMaterials.Length);
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = GameManager.instance.puzzlePieceMaterials[materialIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
