using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shadow))]
public class Float : MonoBehaviour
{

    [SerializeField] private float floatSpeed = 1;
    [SerializeField] private float floatMagnitude = 1;
    [SerializeField] private float startingFloatHeight = 2;

    void Update() {
        Floating();
    }

    private void Floating() {
        transform.position = Vector3.forward * floatMagnitude * Mathf.Sin(Time.time * floatSpeed) + Vector3.forward * (floatMagnitude + startingFloatHeight);
    }

}
