using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{

    public GameObject winMenu;
    private PlayerController playerMovement;
    public GameObject player;
    private AudioController audioController;


    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Sound
            audioController.PlaySFX(audioController.gameWon);
            
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
