using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalMove : MonoBehaviour
{
    private float orbitalVelocity;
    private float orbitalRadius;
    public float junkMass = 0.25f;
    public float tumbleMax = 90.0f;
    public float tumbleRate = 0.0f;
    public Vector3 tumbleAxis;

    // Start is called before the first frame update
    void Start()
    {
        orbitalRadius = GameState.orbitalRadius+transform.position.y;
        orbitalVelocity = (orbitalRadius-GameState.orbitalRadius)/GameState.drdv;

        // junkMass = Random.Range(0.1f, 1.0f);
        // transform.localScale = new Vector3(Mathf.Sqrt(junkMass), Mathf.Sqrt(junkMass), Mathf.Sqrt(junkMass));

        tumbleRate = Random.Range(0, tumbleMax);

        tumbleAxis = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        tumbleAxis.Normalize();
    }

    // Update is called once per frame
    // All debris etc. Have velocities relative to the player
    void Update()
    {
        float dt = Time.deltaTime * GameState.timeScale;

        orbitalVelocity = (orbitalRadius - GameState.orbitalRadius) / GameState.drdv;

        transform.position = new Vector3(
            transform.position.x + orbitalVelocity * dt,
            orbitalRadius - GameState.orbitalRadius, 
            transform.position.z);

        transform.Rotate(tumbleAxis, tumbleRate * Time.deltaTime);
    }
}


