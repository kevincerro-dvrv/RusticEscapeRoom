using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazoBalanza : MonoBehaviour {
    private float maxAngle = 8.0f;
    private float maxWeightDifference = 0.4f;

    public delegate void WeightChangedDelegate(bool correctWeight);
    public WeightChangedDelegate OnWeightChanged;

    private List<SmartWeightProvider> leftDishContent;

    private float targetAngle;
    private float angularSpeed = 80f;

    private float leftDishWeight;
    public float rightDishWeight;
    // Start is called before the first frame update
    void Start() {
        leftDishContent = new List<SmartWeightProvider>();
        leftDishWeight = 0;

        ZonaSensibleHandler.OnObjectEnter += AddObject;
        ZonaSensibleHandler.OnObjectExit += RemoveObject;

        CalculateLeftDishWeight();        
    }

    // Update is called once per frame
    void Update() {

        float angleDiference = transform.localEulerAngles.z - targetAngle;
        angleDiference = angleDiference<180?angleDiference:angleDiference-360f;
        if(Mathf.Abs(angleDiference) < 0.5f) {
            Vector3 newRotation = transform.localEulerAngles;
            newRotation.z = targetAngle;
            transform.localEulerAngles = newRotation;
        } else {
            transform.Rotate(transform.forward * Time.deltaTime * angularSpeed * Mathf.Sign(angleDiference));
        }
        


        
        
    }

    private void AddObject(SmartWeightProvider swp) {
        if(! leftDishContent.Contains(swp)) {
            leftDishContent.Add(swp);
        }

        CalculateLeftDishWeight();
    }

    private void RemoveObject(SmartWeightProvider swp) {
        leftDishContent.Remove(swp);

        CalculateLeftDishWeight();
    }

    private void CalculateLeftDishWeight() {
        leftDishWeight = 0;
        foreach(SmartWeightProvider swp in leftDishContent) {
            leftDishWeight += swp.GetWeigth();
        }

        Debug.Log("[BrazoBalanza] CalculateLeftDishWeight weight" + leftDishWeight);

        targetAngle = CalculateTargetAngle();

        if(OnWeightChanged != null) {
            OnWeightChanged(leftDishWeight == rightDishWeight);
        }
    }


    private float CalculateTargetAngle() {
        float t = Mathf.InverseLerp(-maxWeightDifference, maxWeightDifference, rightDishWeight-leftDishWeight);
        float angle = Mathf.Lerp(-maxAngle, maxAngle, t);
        return angle;
    }
}
