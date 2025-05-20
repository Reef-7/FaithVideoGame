using UnityEngine;
using TMPro;

public class PlayMusicTrigger : MonoBehaviour
{
    public bool playerInRange = false; // Flag to check if player is in range of the goblet
    public AudioSource musicSource; // AudioSource that will play the music
    public TextMeshProUGUI messageText;

    void Update()
    {
        // Check if the player is in range and presses the X key
        if (playerInRange && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("X key pressed, music will play");
            // Ensure the musicSource exists and is not already playing
            if (musicSource != null && !musicSource.isPlaying)
            {
                musicSource.Play(); // Play the music

                if (messageText != null)
                {
                    messageText.gameObject.SetActive(false); // Hide the TMP text
                }

            }
            else
            {
                Debug.Log("Cannot play music: AudioSource is either missing or already playing");
            }
        }
    }

    // Trigger event when the player enters the range of the goblet
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; // Set playerInRange to true when the player is near the goblet
            Debug.Log("Player is in range of the goblet");
        }
    }

    // Trigger event when the player exits the range of the goblet
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; // Set playerInRange to false when the player is no longer near the goblet
            Debug.Log("Player exited the range of the goblet");
        }
    }
}
