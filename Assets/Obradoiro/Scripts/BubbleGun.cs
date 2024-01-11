using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGun : MonoBehaviour {
    public GameObject bubblePrefab;
    public Transform bubbleSpawnPoint;

    // Start is called before the first frame update
    void Start() {
        if(bubblePrefab == null) {
            Debug.Log("BubbleGun. A variable bubblePrefab non está correctamente inicializada");
        }
        if(bubbleSpawnPoint == null) {
            Debug.Log("BubbleGun. A variable bubbleSpawnPoint non está correctamente inicializada");
        }
       
    }

    // Update is called once per frame
    void Update()  {
        
    }

    public void Shot() {
        Instantiate(bubblePrefab, bubbleSpawnPoint.position, bubbleSpawnPoint.rotation);
    }



}
