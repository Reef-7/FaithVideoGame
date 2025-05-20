using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject winPanel;
    private CanvasGroup winCanvasGroup;
    public FmsScript fmsScript;

    private void Awake()
    {
        if (winPanel != null)
        {
            winCanvasGroup = winPanel.GetComponent<CanvasGroup>();
            if (winCanvasGroup == null)
            {
                winCanvasGroup = winPanel.AddComponent<CanvasGroup>();
            }

            
            winCanvasGroup.alpha = 0f;
            winCanvasGroup.interactable = false;
            winCanvasGroup.blocksRaycasts = false;

            winPanel.SetActive(true); 
        }
    }
    public void ShowWinScreen()
    {
        if (winPanel != null && winCanvasGroup != null)
        {
            winCanvasGroup.alpha = 1f;               
            winCanvasGroup.interactable = true;    
            winCanvasGroup.blocksRaycasts = true;    

            Time.timeScale = 0f;

            if (fmsScript != null)
                fmsScript.isPaused = true;

            Cursor.lockState = CursorLockMode.None;  
            Cursor.visible = true;                   

        }
    }

    public void RestartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;
        if (fmsScript != null)
            fmsScript.isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void QuitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit(); 
    }
}
