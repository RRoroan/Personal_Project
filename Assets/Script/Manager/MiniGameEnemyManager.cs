using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameEnemyManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyPrefabs;
    [SerializeField]
    private List<Rect> spawnArea;
    private Color gizmoColor = new Color(1, 0, 0, 0.3f);
    private List<MiniGameEnemy> activeEnemies = new List<MiniGameEnemy>();


    GameManager manager;

    public void Init(GameManager gameManager)
    {
        this.manager = gameManager;
    }

    private void SpawnRandomEnemy()
    {
        GameObject randomPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        Rect randomArea = spawnArea[Random.Range(0, spawnArea.Count)];

        Vector2 randomPosition = new Vector2(
            Random.Range(randomArea.xMin, randomArea.xMax),
            Random.Range(randomArea.yMin, randomArea.yMax)
            );
        GameObject spawnedEnemy = Instantiate(randomPrefab, new Vector3(randomPosition.x, randomPosition.y), Quaternion.identity);
        MiniGameEnemy miniGameEnemy = spawnedEnemy.GetComponent<MiniGameEnemy>();
        
    }

    private void OnDrawGizmosSelected()
    {
        if (spawnArea == null) return;

        Gizmos.color = gizmoColor;
        foreach (var area in spawnArea)
        {
            Vector3 center = new Vector3(area.x + area.width / 2, area.y + area.height / 2);
            Vector3 size = new Vector3(area.width, area.height);
            Gizmos.DrawCube(center, size);
        }
    }
}
