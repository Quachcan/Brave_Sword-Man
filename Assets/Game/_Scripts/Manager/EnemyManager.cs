using System;
using System.Collections.Generic;
using Game._Scripts.Enemies.State_Machine;
using UnityEngine;

namespace Game._Scripts.Manager
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager Instance { get;  private set ; }
        
        [SerializeField] private List<Entity> enemies = new List<Entity>();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void RegisterEnemy(Entity enemy)
        {
            if (!enemies.Contains(enemy))
            {
                enemies.Add(enemy);
                Debug.Log($"Resgistered enemey: {enemy.name}");
            }
        }

        public void UnregisterEnemy(Entity enemy)
        {
            if (enemies.Contains(enemy))
            {
                enemies.Remove(enemy);
            }
        }

        public void RespawnAllEnemies()
        {
            Debug.Log($"Respawning enemey");
            Debug.Log(enemies.Count);
            foreach (var enemy in enemies)
            {
                if (!enemy.gameObject.activeSelf)
                {
                    enemy.ResetState();
                    enemy.gameObject.SetActive(true);
                    Debug.Log("Respawned enemy: " + enemy.gameObject.name);
                }
            }
        }
    }

    [System.Serializable]
    public class EnemyData
    {
        public GameObject enemyPrefab;
        public Vector3 spawnPosition;
    }
}
