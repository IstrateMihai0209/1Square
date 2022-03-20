using UnityEngine;

public class PressSwitch : MonoBehaviour
{
    private GameObject Block;
    public GameObject[] Squares;

    private void Start()
    {
        Block = GameObject.Find("Square Block");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            foreach(GameObject square in Squares)
            {
                square.GetComponent<BreakSquare>().blocked = false;
            }

            Destroy(Block);
            Destroy(gameObject);
        }
    }
}
