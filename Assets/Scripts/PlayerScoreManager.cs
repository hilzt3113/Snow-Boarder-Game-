using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreManager : MonoBehaviour
{
    public int pointsPerFullRotation = 50;
    public int pointsPerGold = 10;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinCollected;
    public TextMeshProUGUI rotationCounter; // Thêm Text cho số lần quay

    private float lastRotation = 0f;
    private float totalRotation = 0f;
    private bool isGrounded = true;
    private HashSet<int> collectedGolds = new HashSet<int>();
    private int totalCoins = 0;
    private int totalFullRotations = 0; // Thêm biến đếm số lần quay đủ 360 độ

    private void Start()
    {
        lastRotation = transform.eulerAngles.z;
        // Load và hiển thị dữ liệu khi bắt đầu
        if (GameScoreManager.Instance != null)
        {
            totalCoins = GameScoreManager.Instance.currentCoins;
            totalFullRotations = GameScoreManager.Instance.currentFlips;
        }
        UpdateScoreText();
    }

    private void Update()
    {
        if (!isGrounded)
        {
            CalculateRotations();
        }
    }

    private void CalculateRotations()
    {
        float currentRotation = transform.eulerAngles.z;
        float rotationDifference = currentRotation - lastRotation;

        if (rotationDifference > 180)
        {
            rotationDifference -= 360;
        }
        else if (rotationDifference < -180)
        {
            rotationDifference += 360;
        }

        totalRotation += rotationDifference;

        if (Mathf.Abs(totalRotation) >= 360)
        {
            int completeRotations = Mathf.FloorToInt(Mathf.Abs(totalRotation) / 360);
            totalFullRotations += completeRotations;
            int pointsToAdd = completeRotations * pointsPerFullRotation;

            if (GameScoreManager.Instance != null)
            {
                GameScoreManager.Instance.AddScore(pointsToAdd);
                GameScoreManager.Instance.AddFlips(completeRotations); // Lưu số lần flip
            }

            totalRotation %= 360;
            UpdateScoreText();
        }

        lastRotation = currentRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            totalRotation = 0f;
            lastRotation = transform.eulerAngles.z;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            CollectGold(collision.gameObject);
        }
    }

    private void CollectGold(GameObject goldObject)
    {
        int goldId = goldObject.GetInstanceID();

        if (!collectedGolds.Contains(goldId))
        {
            collectedGolds.Add(goldId);
            totalCoins++;

            if (GameScoreManager.Instance != null)
            {
                GameScoreManager.Instance.AddScore(pointsPerGold);
                GameScoreManager.Instance.AddCoins(1); // Lưu số coins
                UpdateScoreText();
                Destroy(goldObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            totalRotation = 0f;
            lastRotation = transform.eulerAngles.z;
        }
    }

    private void UpdateScoreText()
    {
        if (GameScoreManager.Instance != null)
        {
            if (scoreText != null)
            {
                scoreText.text = "Score: " + GameScoreManager.Instance.currentScore;
            }
            if (coinCollected != null)
            {
                coinCollected.text = "Coins: " + GameScoreManager.Instance.currentCoins;
            }
            if (rotationCounter != null)
            {
                rotationCounter.text = "Flips: " + GameScoreManager.Instance.currentFlips;
            }
        }
    }
}