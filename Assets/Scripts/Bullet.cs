using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D trigger) {
        if (trigger.CompareTag("Wall"))
        {
            Destroy(gameObject);
            ParticleManager.Instance.Play(ParticleManager.Instance.missImpactEffect, transform.position, Quaternion.identity);
        }
    }

}
