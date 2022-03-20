using UnityEngine;

public class BreakSquare : MonoBehaviour
{
    public Sprite[] squares;
    public int count;
    private float spawnBuffer = 3f;
    public bool blocked = false;

    private void Update()
    {
        if (spawnBuffer > 0f)
            spawnBuffer--;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (spawnBuffer > 0f || blocked)
            return;

        if (GetComponent<SpriteRenderer>().sprite == squares[0])
        {
            Destroy(gameObject);
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = squares[count - 1];
            count--;
        }
    }
}
