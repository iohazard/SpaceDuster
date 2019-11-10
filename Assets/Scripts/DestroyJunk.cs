using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyJunk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Mathf.Abs(transform.position.x) > 30.0)
       {
            GameState.missedMass += gameObject.GetComponent<OrbitalMove>().junkMass;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameState.scoreMass += gameObject.GetComponent<OrbitalMove>().junkMass;
        GameState.propellentMass += gameObject.GetComponent<OrbitalMove>().junkMass;
        Destroy(gameObject);
    }
}