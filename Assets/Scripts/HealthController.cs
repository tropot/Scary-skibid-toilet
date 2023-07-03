using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private bool isDead;

    private MeshRenderer meshRenderer;

    private float minX = -19f;
    private float maxX = 19f;
    private float minY = 50f;
    private float maxY = 61f;

    private float currentHealth;

    [SerializeField]
    private float maxHealth = 3;

    [SerializeField]
    private float respawnTime = 5;


    void Start()
    {
        RandomnPos();
        meshRenderer = GetComponent<MeshRenderer>();
        currentHealth = maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            meshRenderer.enabled = false;
            StartCoroutine(RespawnAfterTime());
        }

    }

    private void ResetHealth()
    {
        isDead = false;
        meshRenderer.enabled = true;
        currentHealth = maxHealth;
    }

    private IEnumerator RespawnAfterTime()
    {
        RandomnPos();
        yield return new WaitForSeconds(respawnTime);
        ResetHealth();
    }
    private void RandomnPos()
    {
        transform.position = new Vector3(Random.Range(minX, maxX), 1.2f, Random.Range(minY, maxY));
    }

    
}
