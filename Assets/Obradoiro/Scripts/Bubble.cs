using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
    public float speed = 2;

    private float t;
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        transform.position += gameObject.transform.forward * speed * Time.deltaTime;
    }

    public void OnCollisionEnter(Collision other) {
        Debug.Log("Bubble OnCollisionEnter");
        Destroy(gameObject);
    }
}
