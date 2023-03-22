using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShakeMode
{
    Fixed,
    Dynamic
}

public enum ShakeAmount
{
    Small,
    Medium,
    Large
}

public class Shake : MonoBehaviour
{

    [SerializeField] private ShakeMode shakeMode = ShakeMode.Fixed;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.7f;
    private float dampingSpeed = 1.0f;
    Vector3 initialPosition;

    void Start() {
        if (shakeMode == ShakeMode.Fixed) initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeMode == ShakeMode.Dynamic) initialPosition = transform.localPosition;
        if (shakeDuration > 0) {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.unscaledDeltaTime * dampingSpeed;
        } else {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void ShakeIt(ShakeAmount amount) {
        switch (amount)
        {
            case ShakeAmount.Small: {
                shakeDuration = 0.2f;
                shakeMagnitude = 0.2f;
                break;
            }
            case ShakeAmount.Medium: {
                shakeDuration = 0.3f;
                shakeMagnitude = 0.5f;
                break;
            }
            case ShakeAmount.Large: {
                shakeDuration = 0.5f;
                shakeMagnitude = 0.8f;
                break;
            }
        }
    }

}
