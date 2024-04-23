using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazoBalanza : MonoBehaviour
{
    private float maxAngle = 8f;
    private float maxWeightDifference = 0.4f;

    private List<SmartWeightProvider> leftDishWeigthObjects = new();
    private float leftDishWeigth = 0;
    public float rightDishWeigth = 10;

    private float targetAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        CalculateTargetAngle();
        ZonaSensibleHandler.OnObjectEnter += AddObject;
        ZonaSensibleHandler.OnObjectExit += RemoveObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localRotation = transform.localEulerAngles;

        localRotation.z = targetAngle;

        transform.localEulerAngles = localRotation; 
    }

    void AddObject(SmartWeightProvider swp)
    {
        if (leftDishWeigthObjects.Contains(swp)) {
            return;
        }

        Debug.Log("AddObject");
        leftDishWeigthObjects.Add(swp);
        leftDishWeigth += swp.getWeigth();

        Debug.Log("TotalWeight: " + leftDishWeigth);
        targetAngle = CalculateTargetAngle();
    }

    void RemoveObject(SmartWeightProvider swp)
    {
        if (!leftDishWeigthObjects.Contains(swp)) {
            return;
        }

        Debug.Log("RemoveObject");
        leftDishWeigthObjects.Remove(swp);
        leftDishWeigth -= swp.getWeigth();

        Debug.Log("TotalWeight: " + leftDishWeigth);
    }

    private float CalculateTargetAngle()
    {
        float t = Mathf.InverseLerp(-maxWeightDifference, maxWeightDifference,  rightDishWeigth - leftDishWeigth);
        float angle = Mathf.Lerp(-8f, 8f, t);


        return angle;
    }
}
