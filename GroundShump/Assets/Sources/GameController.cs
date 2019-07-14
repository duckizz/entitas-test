using Entitas;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public enum GameState { GameStarted, GameEnded };
    public GameState currentState;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI scoreText;
    public GameObject startButton;
    public int playerScore;
    private Systems _systems;
    private Contexts _contexts;

    void Start()
    {
        currentState = GameState.GameEnded;
        Application.targetFrameRate = 60;
        statusText.text = "GROUND SHMUP";
        scoreText.text = "";
        playerScore = 0;
        _contexts = Contexts.sharedInstance;

    }
    private void Awake()
    {

        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);



    }


    public void StartGame()
    {
        currentState = GameState.GameStarted;
        playerScore = 0;
        statusText.text = "";
        startButton.SetActive(false);
        _systems = CreateSystems(_contexts);
        _systems.Initialize();
    }

    public void EndGame()
    {
        currentState = GameState.GameEnded;
        statusText.text = "GAME OVER";
        startButton.SetActive(true);
    }

    void Update()
    {
        scoreText.text = "KILLS: " + playerScore;
        if (currentState == GameState.GameStarted)
        {
            _systems.Execute();
            _systems.Cleanup();
        }
    }

    private static Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Systems")
            .Add(new InputSystems(contexts))
            .Add(new MovementSystems(contexts))
            .Add(new CreateMoverSystem(contexts))
            .Add(new CreateEnemySystem(contexts))
            .Add(new EnemyMoveSystem(contexts))
            .Add(new ViewSystems(contexts))
            .Add(new VelocitySystem(contexts));

    }
}