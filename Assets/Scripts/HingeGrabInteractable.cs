using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HingeGrabInteractable : XRGrabInteractable {
    public Transform hingeTransform;
    public Transform knobTransform;

    private Transform handTransform;
    // Start is called before the first frame update
    void Start() {
        if(attachTransform == null) {
            GameObject attach = new GameObject("Attach");
            attach.transform.parent = transform;
            attachTransform = attach.transform;
        }
        
    }

    protected override void OnSelectEntering(XRBaseInteractor interactor) {
        handTransform = interactor.transform;
        attachTransform.position = handTransform.position;
        attachTransform.rotation = handTransform.rotation;

        base.OnSelectEntering(interactor);
    }

    protected override void OnSelectExiting(XRBaseInteractor interactor) {
        base.OnSelectExiting(interactor);
        handTransform = null;
    }

    // Update is called once per frame
    void Update() {
        ProcessAttach();
    }


    private void ProcessAttach() {
        if(handTransform == null) {
            return;
        }

        //Calculamos a dirección dende a bisagra ó punto de agarre (knob)
        Vector3 hingeKnobDirection = (knobTransform.position - hingeTransform.position);
        //Proxectamos o vector posición do agarre da porta dende a bisagra sobre o plano perpendicular
        //ó eixo de rotación da bisagra (que é o plano polo que se moven o pomo polo que agarramos
        //a tapa e o seu pivote)
        hingeKnobDirection = Vector3.ProjectOnPlane(hingeKnobDirection, hingeTransform.up).normalized;

        //Calculamos a dirección dende a bisagra á man que ten agarrado o obxecto
        Vector3 hingeHandDirection = (handTransform.position - hingeTransform.position);

        //Proxectamos o vector posición da man dende a bisagra sobre o plano perpendicular
        //ó eixo de rotación da bisagra (que é o plano polo que se moven o pomo polo que agarramos
        //a tapa e o seu pivote)
        hingeHandDirection = Vector3.ProjectOnPlane(hingeHandDirection, hingeTransform.up).normalized;

        //Calculamos o quaternion que representa a rotación dende o vector bisagra-tirador
        //ó vector bisagra-man
        Quaternion handRotation = Quaternion.FromToRotation(hingeKnobDirection, hingeHandDirection);

        //Calculamos o vector posición do pivote respecto da bisagra
        Vector3 hingePivotDirection = (transform.position - hingeTransform.position);
 
        //Aplicámoslle a este vector a rotación que calculamos antes
        hingePivotDirection = handRotation * hingePivotDirection;

        //A posición na que queda o pivote do obxecto é o resultado de sumar este vector á 
        //posición da bisagra
        transform.position = hingeTransform.position + hingePivotDirection;
        //Rotamos a tapa aplicando a mesma rotación que calculamos antes
        transform.rotation = handRotation * transform.rotation;

        attachTransform.position = handTransform.position;
        attachTransform.rotation = handTransform.rotation;

    }
}


