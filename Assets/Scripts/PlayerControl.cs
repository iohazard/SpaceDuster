using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private GameState gameState;

    ParticleSystem system
    {
        get
        {
            if (_CachedSystem == null)
            {
                _CachedSystem = GetComponent<ParticleSystem>();
            }

            return _CachedSystem;
        }
    }
    private ParticleSystem _CachedSystem;


    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameObject").GetComponent<GameState>();
    }

    // Update is called once per frame
    // Player controls simply update orbital parameters.
    // Player stays in center
    void Update()
    {
        float dt = Time.deltaTime * GameState.timeScale;
        float horizontalInput = Input.GetAxis("Horizontal");

        float md = horizontalInput * GameState.maxMd;
        float a = GameState.engineImpulse * md / (GameState.structureMass + GameState.propellentMass);
        if (GameState.propellentMass > (md * dt))
        {
            GameState.propellentMass -= Mathf.Abs(md * dt);
            GameState.orbitalVelocity += dt * a;
            GameState.orbitalRadius += GameState.drdv * dt * a;

            if (horizontalInput < -0.1f)
            {
                system.transform.eulerAngles = new Vector3(0, 0, 0);
                system.Play(true);
            }

            if (horizontalInput > 0.1f)
            {
                system.transform.eulerAngles = new Vector3(0, 180, 0);
                system.Play(true);
            }
        }
        else
        {
            gameState.GameOver();
        }

        // Cheat codes
        /*
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameState.propellentMass += 5.0f;
        }
        */
    }
}
