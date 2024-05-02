using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    public Rigidbody2D coin;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bone"))
        {
            Destroy(other.gameObject);
            Instantiate(coin, transform.position, Quaternion.identity);
            
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 5f);
    }
}
