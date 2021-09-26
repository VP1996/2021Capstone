using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBeh : MonoBehaviour
{
    public float speed;
    public GameObject effect;
    public LayerMask whatIsDestructable;
    public int damage;


    private void Update()
    {
        transform.position += transform.right * Time.deltaTime*speed;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag==("Destructable"))
        {

            collision.gameObject.GetComponent<Destructable>().health -= damage;
        }
        
        Instantiate(effect, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("Baam");
        Destroy(gameObject);
    }

    
}
