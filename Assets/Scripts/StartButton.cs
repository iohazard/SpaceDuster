using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button startButton;
    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(GameButton);

        gameState = GameObject.Find("GameObject").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameButton()
    {
        Debug.Log(gameObject.name);

        if(gameObject.name == "Start Button")
            gameState.StartGame(1.0f);

        if (gameObject.name == "Restart Button")
            gameState.RestartGame();

    }

}
