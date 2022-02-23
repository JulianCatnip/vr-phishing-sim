using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ScoreSystem scoreSystem;
    public Transform scoreDisplay;

    private enum GameState {
        START,
        PLAYING,
        GAMEOVER,
        WIN,
        END
    }
    private GameState gameState;

    void Start()
    {
        scoreSystem = GetComponent<ScoreSystem>();
        gameState = GameState.START;
    }

    void Update()
    {
        switch (gameState)
        {
            case GameState.START:
                // Start logic
                break;
            case GameState.PLAYING:
                // Play logic
                break;
            case GameState.GAMEOVER:
                // gameover logic
                break;
            case GameState.WIN:
                // win logic
                break;
            case GameState.END:
                // end logic
                break;
        }
    }
}
