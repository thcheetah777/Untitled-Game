using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Shadow : MonoBehaviour
{

    [SerializeField] private GameObject shadowPrefab;
    [SerializeField] private SortingGroup graphics;
    [SerializeField] private ParticleSystem dustParticles;
    [SerializeField] private float shadowSizeHeightChange = 13;

    Transform shadow;
    Collider2D collision;

    void Start() {
        collision = GetComponent<Collider2D>();
        shadow = Instantiate(shadowPrefab, transform.position, Quaternion.identity, transform).transform;
    }

    void Update() {
        if (transform.position.z > 1)
        {
            shadow.gameObject.SetActive(true);
            if (dustParticles != null) dustParticles.gameObject.SetActive(false);

            collision.enabled = false;
            graphics.transform.position = new Vector3(transform.position.x, transform.position.z, transform.position.z);
            shadow.localScale = new Vector2(1, 0.5f) - (Vector2.one * transform.position.z / shadowSizeHeightChange);
            graphics.sortingLayerName = "Flying";
        } else
        {
            shadow.gameObject.SetActive(false);
            collision.enabled = true;
            if (dustParticles != null) dustParticles.gameObject.SetActive(true);

            graphics.sortingLayerName = "Default";
        }
    }

}
