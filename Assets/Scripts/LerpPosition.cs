using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPosition : MonoBehaviour
{

    [SerializeField] private float smoothing = 0.1f;

    Vector2 startingPos;

    void Start() {
        startingPos = transform.position;
    }

    void Update() {
        transform.position = Vector2.Lerp(transform.position, startingPos, smoothing);
    }

}
