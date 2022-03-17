using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SelectLevel(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void NextScene()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
