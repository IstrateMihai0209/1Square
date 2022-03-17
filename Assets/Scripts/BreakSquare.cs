using UnityEngine;
using System;

public class BreakSquare : MonoBehaviour
{
    public Sprite[] squares;
    public int count;

    private void OnCollisionEnter2D(Collision2D col)
    {
        //ANUNT: Put a support at the start of the level and destroy it after jumping to prevent decreasing
        //a point on the first square
        if(GetComponent<SpriteRenderer>().sprite == squares[0])
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
