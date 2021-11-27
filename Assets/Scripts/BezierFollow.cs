using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;

    private int routeToGo;

    private float tParam;

    public GameObject player;
    private Vector2 objectPosition;

    private float speedModifier;

    private bool coroutineAllowed;

    public GameObject fallingGrass;

    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.5f;
    }

   private void OnCollisionEnter2D (Collision2D other)
    {
        coroutineAllowed=true;
        objectPosition = player.transform.position;
    }
    public void setCoroutineFalse(){
        coroutineAllowed=false;
    }
    void Update()
    {
        if (coroutineAllowed)
        {
            Invoke("makeGrassFall", 0.72f);
            StartCoroutine(GoByTheRoute(routeToGo));
        }
    }

    void makeGrassFall(){
            fallingGrass.GetComponent<Animator> ().SetBool("isFalling",true);
    }

    private IEnumerator GoByTheRoute(int routeNum)
    {
        coroutineAllowed = false;

        Vector2 p0 = routes[routeNum].GetChild(0).position;
        Vector2 p1 = routes[routeNum].GetChild(1).position;
        Vector2 p2 = routes[routeNum].GetChild(2).position;
        Vector2 p3 = routes[routeNum].GetChild(3).position;

        while(tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

            player.transform.position = objectPosition;
            yield return new WaitForEndOfFrame();
        }
        /*

        tParam = 0f;

        routeToGo += 1;

        if(routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }*/


    }
}
