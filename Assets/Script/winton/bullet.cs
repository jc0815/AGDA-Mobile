using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidbody2D;
    public float speed = 20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        Destroy(gameObject);
    }
}
