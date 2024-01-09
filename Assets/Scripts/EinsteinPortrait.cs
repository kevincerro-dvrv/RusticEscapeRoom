using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinsteinPortrait : MonoBehaviour {
    private int hitCounter = 0;
    private float t0 = 0;
    private bool solved = false;

    void Update() {
        if (solved) {
            return;
        }

        if (Time.time - t0 > 10f) {
            hitCounter = 0;
        }
    }

    public void OnCollisionEnter(Collision other) {
        Debug.Log("EinsteinPortrait OnCollisionEnter");
        if(other.gameObject.CompareTag("Bubble")) {
            hitCounter++;
            t0 = Time.time;

            if (hitCounter == 2) {
                solved = true;
                GameManager.instance.UnlockEinsteinPuzzle();
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
