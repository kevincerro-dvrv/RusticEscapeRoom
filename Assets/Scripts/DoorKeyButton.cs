using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyButton : MonoBehaviour {
    private int materialIndex;
    public int MaterialIndex { get { return materialIndex; } }
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start() {
        materialIndex = Random.Range(0, GameManager.instance.puzzlePieceMaterials.Length);
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material =  GameManager.instance.puzzlePieceMaterials[materialIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("[DoorKeyButton] Trigger detectado");
        RotateMaterial();
        GameManager.instance.CheckDoorKeyCode();
    }

    private void RotateMaterial() {
        materialIndex = (materialIndex + 1) % GameManager.instance.puzzlePieceMaterials.Length;
        meshRenderer.material =  GameManager.instance.puzzlePieceMaterials[materialIndex];
    }
}
