using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineTrigger : MonoBehaviour
{
    private GameManagerScript gameManager;
    private AudioSource audioSource; // Thêm AudioSource
    [SerializeField] private AudioClip finishSound;

    void Start()
    {
        gameManager = FindObjectOfType<GameManagerScript>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            audioSource.PlayOneShot(finishSound);
            gameManager.ShowWinningPanel(); 
        }
    }
}
