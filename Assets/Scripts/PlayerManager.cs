using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    AudioSource ac;
    [SerializeField] GameObject exlposion;

    private void Start () {
        ac = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ac.Play();
            Instantiate(exlposion, transform.position,Quaternion.identity);
            Invoke("gameOver", 0.5f);
            
        }
    }

    void gameOver () {
        GameManager.instance.gameOver();
    }
}
