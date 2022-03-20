using UnityEngine;
using UnityEngine.SceneManagement;

public class Flood : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        transform.localScale = Vector2.Lerp(transform.localScale,
            new Vector2(transform.localScale.x, transform.localScale.y * 2), 0.07f * Time.deltaTime);
    }
}
