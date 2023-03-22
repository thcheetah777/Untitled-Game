using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePointer : MonoBehaviour
{

    [SerializeField] private float clickingSize = 0.5f;
    [SerializeField] private float turnSmoothing = 0.1f;

    private float normalSize = 1;
    private float targetRotation;

    #region Singleton
    
    static public MousePointer Instance = null;
    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    
    #endregion

    Camera cam;
    Rigidbody2D mouseBody;

    void Start() {
        cam = Camera.main;
        mouseBody = GetComponent<Rigidbody2D>();

        normalSize = transform.localScale.x;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update() {
        transform.position = Vector2.Lerp(transform.position, cam.ScreenToWorldPoint(Mouse.current.position.ReadValue()), 0.5f);

        if (Mouse.current.leftButton.isPressed)
        {
            transform.localScale = Vector2.one * clickingSize;
        } else {
            transform.localScale = Vector2.one * normalSize;
        }

        mouseBody.rotation = Mathf.Lerp(mouseBody.rotation, targetRotation, turnSmoothing);
    }

    public void Turn(float angle) {
        targetRotation += angle;
    }

}
