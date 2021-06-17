using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Animator animator;
    public float destroyDelay;
    public int scoreOnPickup;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("isCollected");
            Inventory.instance.addPoints(scoreOnPickup);
            StartCoroutine(DestroyOnPickup());
        }
    }

    IEnumerator DestroyOnPickup()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}
