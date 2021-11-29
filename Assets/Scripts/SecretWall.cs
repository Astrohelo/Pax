using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
