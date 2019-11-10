using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySatellite : MonoBehaviour
{
    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameObject").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) > 30.0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        gameState.GameOver();
    }
}
