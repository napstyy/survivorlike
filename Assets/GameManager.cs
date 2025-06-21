using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float surviveTime = 60f;
    private float timer;


    public TMP_Text timerText;
    public GameObject winPanel;



    void Update()
    {
        timer += Time.deltaTime;

        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }

        if (timer >= surviveTime)
        {
            Win();
        }
    }

    void Win()
    {
        Debug.Log("You win!");
        Time.timeScale = 0f;

        if (winPanel != null)
            winPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
