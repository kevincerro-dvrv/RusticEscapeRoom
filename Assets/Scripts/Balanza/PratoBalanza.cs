using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PratoBalanza : MonoBehaviour {
    public Transform attachTransform;

    // Update is called once per frame
    void Update() {
        transform.position = attachTransform.position;
        transform.rotation = Quaternion.identity;
    }
}
