using UnityEngine;
using UnityEngine.SceneManagement;

public class SquareCounter : MonoBehaviour
{
    private void Update()
    {
        if (transform.childCount == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
