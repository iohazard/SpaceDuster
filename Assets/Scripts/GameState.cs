using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public GameObject[] junkPrefabs;

    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI junkText;

    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject gameHud;
    public GameObject player;

    public static bool gameOn = true;

    public static float drdv = -1.756e3f; // m / (m/s)
    public static float timeScale = 1000.0f; 
    public static float orbitalVelocity = 0.0f;
    public static float orbitalRadius  = 0.0f;
    public static float structureMass  = 5.0f;
    public static float maxMd          = 1.5e-3f; // kg/s max
    public static float engineImpulse  = 30e-3f; // N / kg/s


    public static float propellentMass;
    public static float scoreMass;
    public static float missedMass;


    public float spawnX = 20.0f;
    public float spawnY = 10.0f;

    private bool gameIsOn;

    // Start is called before the first frame update
    void Start()
    {
        gameIsOn = false;
    }

    public void StartGame(float difficulty)
    {
        gameIsOn = true;
        propellentMass = 5.0f;
        scoreMass = 0.0f;
        missedMass = 0.0f;

        titleScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        gameHud.gameObject.SetActive(true);

        InvokeRepeating("SpawnJunk", 1.0f, 2.0f / difficulty);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  
    public void GameOver()
    {
        gameIsOn = false;
        propellentMass = 0.0f;

        titleScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
        gameHud.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Generate random ball index and random spawn position
    void SpawnJunk()
    {
        int spawnJunk = Random.Range(0, junkPrefabs.Length);

        float orbit = Random.Range(0.5f, spawnY);
        float side = Random.Range(-1.0f, 1.0f);
        Vector3 spawnPos = new Vector3(spawnX, orbit, 0);

        // Make sure stuff will make it on screen
        // Also need a destroyer...
        if (side < 0.0f)
        {
            spawnPos = -spawnPos;
        }

        // instantiate ball at random spawn location
        Instantiate(junkPrefabs[spawnJunk], spawnPos, junkPrefabs[spawnJunk].transform.rotation);

    }

    void OnGUI()
    {
        fuelText.text = string.Format("Fuel {0:0.##} kg", propellentMass);
        junkText.text = string.Format("Collected {0:0.##}/{1:0.##} kg", scoreMass, (missedMass+scoreMass));
    }
}
