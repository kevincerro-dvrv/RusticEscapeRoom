using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinsteinPortrait : MonoBehaviour {
    private int bubbleCount = 0;
    private float t0;

    void Update() {
        //Se pasaron máis de 10 segundos dende o último impacto
        //reseteamos a cero o contador de impactos
        if(Time.time - t0 > 10f) {
            bubbleCount = 0;
        }
    }

    void OnCollisionEnter(Collision other) {
        Debug.Log($"[EinsteinPortrait] {other.gameObject.tag}");
        if(other.gameObject.CompareTag("Bubble")) {
            bubbleCount++;
            t0 = Time.time;
        }

        if(bubbleCount == 2) {
            GameManager.instance.CheckEinsteinPuzzle();
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        } 
    }

}
