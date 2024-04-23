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
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.z = targetAngle;
        transform.localEulerAngles = newRotation;
        
    }

    private void AddObject(SmartWeightProvider swp) {
        leftDishContent.Add(swp);

        CalculateLeftDishWeight();
    }

    private void RemoveObject(SmartWeightProvider swp) {
        leftDishContent.Remove(swp);

        CalculateLeftDishWeight();
    }

    private void CalculateLeftDishWeight() {
        
        leftDishWeight = 0;
        foreach(SmartWeightProvider swp in leftDishContent) {
            leftDishWeight += swp.weigth;
        }

        Debug.Log("[BrazoBalanza] CalculateLeftDishWeight weight" + leftDishWeight);

        targetAngle = CalculateTargetAngle();
    }


    private float CalculateTargetAngle() {
        float t = Mathf.InverseLerp(-maxWeightDifference, maxWeightDifference, leftDishWeight-rightDishWeight);
        float angle = Mathf.Lerp(t, -maxAngle, maxAngle);
        return angle;
    }
}
