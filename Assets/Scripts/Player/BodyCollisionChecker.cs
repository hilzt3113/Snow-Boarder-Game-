using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollisionChecker : MonoBehaviour
{
    public Collider2D bodyCollider;
    public Collider2D boardCollider;
    public GameOverManager gameOverManager;
    private AudioSource audioSource;
    [SerializeField] private AudioClip crashSound; // Thêm AudioClip

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Lấy component AudioSource

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (collision.otherCollider == bodyCollider)
            {
                Debug.Log("Body touched the ground!");
                PlayCrashSound();
                gameOverManager.HandleDeath();
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rock"))
        {
            if (collision.otherCollider == bodyCollider)
            {
                Debug.Log("Body hit the rock!");
                PlayCrashSound();
                gameOverManager.HandleDeath();
            }
            else if (collision.otherCollider == boardCollider)
            {
                Debug.Log("Board hit the rock!");
                PlayCrashSound();
                gameOverManager.HandleDeath();
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Canyon"))
        {
            if (collision.otherCollider == bodyCollider)
            {
                Debug.Log("Body hit the canyon!");
                PlayCrashSound();
                gameOverManager.HandleDeath();
            }
            else if (collision.otherCollider == boardCollider)
            {
                Debug.Log("Board hit the canyon!");
                PlayCrashSound();
                gameOverManager.HandleDeath();
            }
        }
    }

    private void PlayCrashSound()
    {
        if (crashSound != null)
        {
            audioSource.PlayOneShot(crashSound);
        }
    }
}