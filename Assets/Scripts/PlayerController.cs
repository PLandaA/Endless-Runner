using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 3.89)
        {
            if (Input.GetMouseButton(0))
            {
                rb2d.AddForce(Vector2.up * Time.deltaTime * speed, ForceMode2D.Impulse);
                

            }
        }
    }

  
}
