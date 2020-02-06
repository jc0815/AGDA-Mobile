using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Entered Stack");
        if (other.gameObject.tag == "Obstacle") // this string is your newly created tag
        {
            Debug.Log("Destroying");
            Destroy(this);
        }
    }
}
