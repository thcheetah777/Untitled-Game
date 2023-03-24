using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float maxHealth = 1000;
    private float health;

    SpriteGraphics[] graphics;

    void Start() {
        health = maxHealth;

        graphics = transform.GetComponentsInChildren<SpriteGraphics>();
    }

    private void GetHurt(float damage) {
        HurtGraphics();
        health -= damage;
        if (health <= 0) Die();
    }

    private void Die() {
        Destroy(gameObject);
    }

    private void HurtGraphics() {
        foreach (SpriteGraphics graphic in graphics)
        {
            graphic.Flash();
            graphic.Bump();
        }
    }

    void OnTriggerEnter2D(Collider2D trigger) {
        if (trigger.CompareTag("Bullet"))
        {
            Destroy(trigger.gameObject);
            GetHurt(PlayerShooting.Instance.damage);
        }
    }

}
