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
    public Transform respawnPoint;
    private PlayerController playerMovement;

    void Start()
    {
        if (playerAnim == null)
        {
            Debug.LogError("[ERROR] Player Animator field is empty in Inspector.");
        }

        playerMovement = player.GetComponent<PlayerController>();
        if (playerMovement == null)
        {
            Debug.LogError("[ERROR] srcPlayer script not found on player object!");
        }
        playerHealth = 3;
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

        if (playerHealth <= 0)
        {
            StartCoroutine(DieAndRespawn());
        }
    }

    IEnumerator DieAndRespawn()
    {
        Die();
        
        // Wait for the death animation to finish
        yield return new WaitForSeconds(2f);
        
        Respawn();
    }

    void Die()
    {
        /// Disable player movement
        if (playerMovement != null)
            playerMovement.enabled = false;

        // Stop player velocity
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.velocity = Vector2.zero;

        // Trigger death animation
        playerAnim.SetBool("isDead", true);
        playerAnim.SetBool("isrunning", false);  // Stop running animation
        Debug.Log("Player died!");

    }

    void Respawn()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}