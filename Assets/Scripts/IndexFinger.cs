using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IndexFinger : MonoBehaviour {
    public ActionBasedController actionBasedController;

    public void HapticFeedback() {
        actionBasedController.SendHapticImpulse(0.1f, 0.1f);
    }    
}
