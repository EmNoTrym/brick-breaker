using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSessionLoader : MonoBehaviour
{
    // state
    private GameSession _gameSession;
    [SerializeField] private LoadCSV loadCSV;
    /**
     * Before first frame.
     */
    void Start()
    {
        this._gameSession = GameSession.Instance;
        StartGameSession();
    }

    /**
     * Starts a game session from scratch (based only on the game mode options). In the future,
     * this method can be used to start a game session from a saved game file.
     */
    public void StartGameSession()
    {
        this._gameSession.PlayerLives = loadCSV.lives;
        this._gameSession.GameSpeed = loadCSV.gameSpeed;
        this._gameSession.PointsPerBlock = 300;
        this._gameSession.PlayerScore = 0;
        if (!GameObject.Find("GameSession"))
        {
            this._gameSession.GameLevel = PlayerPrefs.GetInt("PickedLevel");
        }
        else
        {
            this._gameSession.GameLevel = loadCSV.level;
        }
        
    }
}
