using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreManager : MonoBehaviour
{
    public static GameScoreManager Instance { get; private set; }

    public int currentScore = 0;
    public int currentCoins = 0;    // Thêm biến để lưu số coins
    public int currentFlips = 0;    // Thêm biến để lưu số lần flip

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAllData(); // Load tất cả dữ liệu khi khởi tạo
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Phương thức thêm điểm
    public void AddScore(int points)
    {
        currentScore += points;
        SaveAllData();
    }

    // Phương thức thêm coins
    public void AddCoins(int coins)
    {
        currentCoins += coins;
        SaveAllData();
    }

    // Phương thức thêm flips
    public void AddFlips(int flips)
    {
        currentFlips += flips;
        SaveAllData();
    }

    // Lưu tất cả dữ liệu
    public void SaveAllData()
    {
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        PlayerPrefs.SetInt("CurrentCoins", currentCoins);
        PlayerPrefs.SetInt("CurrentFlips", currentFlips);
        PlayerPrefs.Save();
    }

    // Load tất cả dữ liệu
    public void LoadAllData()
    {
        currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        currentCoins = PlayerPrefs.GetInt("CurrentCoins", 0);
        currentFlips = PlayerPrefs.GetInt("CurrentFlips", 0);
    }

    // Reset tất cả dữ liệu
    public void ResetAllData()
    {
        currentScore = 0;
        currentCoins = 0;
        currentFlips = 0;
        PlayerPrefs.DeleteKey("CurrentScore");
        PlayerPrefs.DeleteKey("CurrentCoins");
        PlayerPrefs.DeleteKey("CurrentFlips");
        PlayerPrefs.Save();
    }
}