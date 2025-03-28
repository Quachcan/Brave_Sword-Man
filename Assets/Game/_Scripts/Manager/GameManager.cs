using Game._Scripts.Player;
using Game.Scripts.Player;
using UnityEngine;

namespace Game._Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        public enum GameState {GameStart, Menu, Playing, Pause, GameOver}
        public GameState currentState;
        
        [Header("Managers")]
        public UIManager uiManager;
        public PlayerManager playerManager;
        [SerializeField] private EnemyManager enemyManagerPrefab;
        [SerializeField] private EnemyManager enemyManager;
        public AudioManager audioManager;
        public MapManager mapManager;
        public SceneLoader sceneLoader;
        
        public bool isRunning;

        private void Awake()
        {
            Debug.Log("GameManager Awake");
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            InitializeAllScripts();
        }

        private void Start()
        {
            currentState = GameState.GameStart;
            isRunning = true;
        }

        private void InitializeAllScripts()
        {
            Debug.Log("Initialized all Scripts");
            
            if (enemyManager == null && enemyManagerPrefab != null)
            {
                enemyManager = Instantiate(enemyManagerPrefab, transform);
                Debug.Log("EnemyManager instantiated: " + enemyManager.name);
            }
            else
            {
                Debug.Log("Not Initialized");
            }
            EnemyManager.Instance = enemyManager;
            playerManager.Initialize();
        }

        public void GameStart()
        {
            isRunning = true;
            currentState = GameState.Menu;
            Debug.Log("Game Start");
        }

        public void GamePlaying()
        {
            isRunning = true;
            currentState = GameState.Playing;
        }

        public void PauseGame()
        {
            isRunning = false;
            currentState = GameState.Pause;
        }

        public void GameOver()
        {
            isRunning = false;
            currentState = GameState.GameOver;
        }
    }
}
