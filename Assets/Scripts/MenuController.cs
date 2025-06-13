using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public InputField playerNameInput;
    public TextMeshProUGUI bestScoreText;

    void Start()
    {
        if (DataManager.Instance == null)
        {
            Debug.LogError("DataManager.Instance is null in MenuController.Start");
        }
        else
        {
            DataManager.Instance.LoadData();
            bestScoreText.text = "Best Score: " + DataManager.Instance.currentBestPlayer + " -> " + DataManager.Instance.currentBestScore; 
        }
    }
    public void StartGame()
    {
        if (playerNameInput.text == "")
        {
            SceneManager.LoadScene(1);
            DataManager.Instance.playerName = "No-name";
        }
        else
        {
            SceneManager.LoadScene(1);
            DataManager.Instance.playerName = playerNameInput.text;
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); 
#else
        Application.Quit();
#endif
    }
}
