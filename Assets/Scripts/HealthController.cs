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
    //public Transform respawnPoint;
    private PlayerController playerMovement;
    public GameObject gameOverMenu;

    void Start()
    {
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
        yield return new WaitForSeconds(2.5f);

        gameOverMenu.SetActive(true);
    }


    void Die()
    {
        // Disable player movement
        if (playerMovement != null)
            playerMovement.enabled = false;

        // Stop player velocity
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.velocity = Vector2.zero;

        // Death animation
        playerAnim.SetTrigger("isDead");  
        playerAnim.SetBool("isrunning", false);
        Debug.Log("Player died!");
    }


}