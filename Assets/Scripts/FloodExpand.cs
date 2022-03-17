using UnityEngine;

public class FloodExpand : MonoBehaviour
{
    void Update()
    {
        transform.localScale = Vector2.Lerp(transform.localScale,
            new Vector2(transform.localScale.x, transform.localScale.y * 2), 0.07f * Time.deltaTime);
    }
}
