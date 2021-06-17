using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public HealthBar healthBar;
    public float currentHealth;

    public bool isInvincible = false;
    public SpriteRenderer spriteRenderer;
    public float damageBlinkTime;
    public float invincibilityDuration;
    

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(InvincibilityTime());
        }
    }
    
    IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(damageBlinkTime);
            spriteRenderer.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(damageBlinkTime);
        }
    }

    IEnumerator InvincibilityTime()
    {
        if (isInvincible)
        {
            yield return new WaitForSeconds(invincibilityDuration);
            isInvincible = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }
}
