using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bola")
        Destroy(gameObject);
    }
}
