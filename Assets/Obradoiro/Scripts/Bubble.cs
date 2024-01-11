using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
    float speed = 2;

    // Start is called before the first frame update
    void Start() {
     
    }

    // Update is called once per frame
    void Update() {
        transform.position += transform.forward * speed * Time.deltaTime;
    }




    public void OnCollisionEnter(Collision other) {
        Debug.Log("Bubble OnCollisionEnter");
        
        Destroy(gameObject);
        
    }
}
