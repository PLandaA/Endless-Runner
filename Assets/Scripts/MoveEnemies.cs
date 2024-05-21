using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemies : MonoBehaviour {

    [SerializeField] float scrollSpeed;

    void Start () {

    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.left * scrollSpeed*Time.deltaTime);

    }


    private void OnBecameInvisible () {
        gameObject.SetActive(false);


    }
}
