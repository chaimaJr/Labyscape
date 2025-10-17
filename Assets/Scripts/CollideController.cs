using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollideController : MonoBehaviour
{
    public int keysNumber;
    public Image[] keys;
    private AudioController audioController;

    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        keysNumber = 0;
        UpdateKeyNumber();

    }

    void UpdateKeyNumber()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            if (i < keysNumber)
                keys[i].color = Color.white;
            else
                keys[i].color = Color.gray;
        }

        // Open door
        if (keysNumber == 3)
        {
            GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
            foreach (GameObject door in doors)
            {
                door.SetActive(false);
            }
            Debug.Log("Door unlocked");
        }

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            // Sound
            audioController.PlaySFX(audioController.keyCollected);

            collision.gameObject.SetActive(false);
            keysNumber++;
            UpdateKeyNumber();

        }
    }
}
