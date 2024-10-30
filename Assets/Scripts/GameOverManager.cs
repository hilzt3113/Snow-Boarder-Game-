using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    //public Vector3 respawnOffset = new Vector3(0, 3.5f, 0); 
    //public Vector3 defaultRotation = Vector3.zero; 

    private Transform playerTransform;
    private Rigidbody2D playerRigidbody;

    private GameManagerScript gameManager;

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManagerScript>();
    }

    public void HandleDeath()
    {
        Music.instance.StopMusic();
        Debug.Log("Game Over!");
        gameManager.ShowLosingPanel();
    }

    //private void RespawnPlayer()
    //{
    //    Vector3 respawnPosition = playerTransform.position + respawnOffset;
    //    playerTransform.position = respawnPosition;
    //    playerTransform.rotation = Quaternion.Euler(defaultRotation);
    //    playerRigidbody.velocity = Vector2.zero; 
    //}
}
