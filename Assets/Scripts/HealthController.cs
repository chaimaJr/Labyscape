using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthController : MonoBehaviour
{
    public int playerHealth;
    public Image[] hearts;
    public Animator playerAnim;
    public GameObject player;
    private PlayerController playerMovement;
    public GameObject gameOverMenu;
    private AudioController audioController;
    private bool isDead = false; // Prevent multiple death triggers

    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }

    void Start()
    {
        playerHealth = 3;
        // Get the PlayerController component
        playerMovement = player.GetComponent<PlayerController>();
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i >= playerHealth)
            {
                hearts[i].color = Color.gray;
            }
        }

        // Only trigger death once
        if (playerHealth <= 0 && !isDead)
        {
            isDead = true;
            StartCoroutine(DieAndRespawn());
        }
    }

    IEnumerator DieAndRespawn()
    {
        Die();

        // Wait for the death animation to finish
        yield return new WaitForSeconds(2.5f);
        gameOverMenu.SetActive(true);
    }

    void Die()
    {
        // Sound
        audioController.PlaySFX(audioController.gameOver);

        // Disable player movement
        if (playerMovement != null)
            playerMovement.enabled = false;

        // Stop player velocity
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true; // Prevent physics from moving the player
        }

        // Death animation
        playerAnim.SetTrigger("isDead");
        playerAnim.SetBool("isrunning", false);

        Debug.Log("Player died");
    }
}