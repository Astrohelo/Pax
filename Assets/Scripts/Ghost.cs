using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float ghostDelay;
    private float ghostDelaySeconds;
    public GameObject ghost;
    public bool canMake;
    // Start is called before the first frame update
    void Start()
    {
        ghostDelaySeconds=ghostDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMake){
                if(ghostDelaySeconds>0){
                    ghostDelaySeconds -= Time.deltaTime;
                }
                else{
                    GameObject current= Instantiate(ghost, transform.position, transform.rotation);
                    Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;
                    current.GetComponent<SpriteRenderer>().sprite = currentSprite;
                    current.transform.localScale = this.transform.localScale;
                    ghostDelaySeconds = ghostDelay;
                    Destroy(current, 1f);
                }
        }
        
    }
}
