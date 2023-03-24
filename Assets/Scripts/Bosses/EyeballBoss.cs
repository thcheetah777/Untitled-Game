using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballBoss : MonoBehaviour
{

    [SerializeField] private float speed = 1;
    [SerializeField] private LineRenderer laser;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float laserSpeed = 0.2f;

    [Header("Animation")]
    [SerializeField] private Transform eye;
    [SerializeField] private Transform pupil;
    [SerializeField] private Transform graphics;
    [SerializeField] private ParticleSystem laserParticles;
    [SerializeField] private float blinkDelay;
    [SerializeField] private float blinkSmoothing = 0.1f;
    [SerializeField] private float pupilSmoothing = 0.1f;
    
    private Vector2 targetEyeScale;
    private Vector2 originalEyeSize;
    private Vector2 originalPos;
    private Vector2 targetPupilPos;

    Rigidbody2D bossBody;

    void Start() {
        originalEyeSize = eye.localScale;
        targetEyeScale = originalEyeSize;
        originalPos = transform.position;

        bossBody = GetComponent<Rigidbody2D>();

        StartCoroutine(BlinkRoutine());
        StartCoroutine(LaserEyes());
    }

    void Update() {
        eye.localScale = Vector2.Lerp(eye.localScale, targetEyeScale, blinkSmoothing);
        bossBody.velocity = bossBody.velocity.normalized * speed;
        pupil.localPosition = Vector2.Lerp(pupil.localPosition, targetPupilPos, pupilSmoothing);
    }

    private void Move() {
        bossBody.AddForce(Random.insideUnitCircle.normalized * speed, ForceMode2D.Impulse);
    }

    private IEnumerator LaserEyes() {
        bossBody.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        laser.gameObject.SetActive(true);

        float angle = 0;
        while (true)
        {
            float radian = angle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
            targetPupilPos = direction * (eye.localScale - pupil.localScale / 2);
            RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, 100, wallLayer);

            laser.SetPosition(1, ray.point);
            laser.SetPosition(0, graphics.position);
            laserParticles.transform.position = ray.point;

            angle += laserSpeed;
            if (angle >= 360)
            {
                break;
            }
            yield return null;
        }

        targetPupilPos = Vector2.zero;
        laser.gameObject.SetActive(false);
    }

    private IEnumerator BlinkRoutine() {
        while (true)
        {
            yield return new WaitForSeconds(blinkDelay);
            if (eye.localScale.y >= 0)
            {
                targetEyeScale = new Vector2(originalEyeSize.x, -originalEyeSize.y);
            } else
            {
                targetEyeScale = new Vector2(originalEyeSize.x, originalEyeSize.y);
            }
        }
    }

}
