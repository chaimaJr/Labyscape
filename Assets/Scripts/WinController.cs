using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{

    public GameObject winMenu;
    private PlayerController playerMovement;
    public GameObject player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player won!");

            winMenu.SetActive(true);

            // Disable player movement
            if (playerMovement != null)
                playerMovement.enabled = false;

            // Stop player velocity
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = Vector2.zero;

        }
    }
}
