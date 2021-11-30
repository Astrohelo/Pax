using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeBoss : MonoBehaviour
{
    public int hp;
    [SerializeField] private float leftEnd;
    [SerializeField] private float rightEnd;
    [SerializeField] private LayerMask ground;

    private bool facingLeft = true;
    private Collider2D coll;
    private Rigidbody2D rb;

    [SerializeField] private int maxhp = 90;

    public Slider healthbar;

    
    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = hp;
    }
}
