using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    //public Image[] lives;
    public GameObject losingPanel;
    public GameObject winningPanel;
    public TextMeshProUGUI losingScoreText;
    public TextMeshProUGUI winningScoreText;

    void Start()
    {
        losingPanel.SetActive(false);
        winningPanel.SetActive(false);
        Time.timeScale = 1f; // Đảm bảo game chạy với tốc độ bình thường khi bắt đầu scene
        Music.instance.PlayMusic();
    }

    public void ShowLosingPanel()
    {
        Time.timeScale = 0;
        if (losingScoreText != null && GameScoreManager.Instance != null)
        {
            losingScoreText.text = "Score: " + GameScoreManager.Instance.currentScore.ToString();
            // Lưu điểm số khi thua
            GameScoreManager.Instance.SaveAllData();
        }
        losingPanel.SetActive(true);
    }

    public void ShowWinningPanel()
    {
        Time.timeScale = 0;
        if (winningScoreText != null && GameScoreManager.Instance != null)
        {
            // Thêm 1000 điểm khi thắng
            //GameScoreManager.Instance.AddScore(1000);
            winningScoreText.text = "Score: " + GameScoreManager.Instance.currentScore.ToString();
            // Lưu điểm số khi thắng
            GameScoreManager.Instance.SaveAllData();
        }
        winningPanel.SetActive(true);
    }

    public void Restart()
    {
        // Reset điểm số khi restart từ đầu
        if (GameScoreManager.Instance != null)
        {
            GameScoreManager.Instance.ResetAllData();
        }
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
        Music.instance.PlayMusic();
    }

    public void Home()
    {
        // Reset điểm từ đầu
        if (GameScoreManager.Instance != null)
        {
            GameScoreManager.Instance.ResetAllData();
        }
        SceneManager.LoadScene("HomeScene");
        Time.timeScale = 1f;
        Music.instance.PlayMusic();
    }

    public void NextLevel()
    {
        // Lưu điểm trước khi chuyển màn
        if (GameScoreManager.Instance != null)
        {
            GameScoreManager.Instance.SaveAllData();
        }
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Kiểm tra xem còn level tiếp theo không
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Nếu đã hết level, có thể chuyển về màn hình chính hoặc màn hình kết thúc game
            SceneManager.LoadScene("HomeScene");
        }
        Time.timeScale = 1f;
    }
}