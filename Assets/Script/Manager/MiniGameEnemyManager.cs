using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MiniGameEnemyManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyPrefabs;
    [SerializeField]
    private List<Rect> spawnArea;
    [SerializeField]
    private Color gizmoColor = new Color(1, 0, 0, 0.3f);
    public PlayerController player { get; private set; }
    private Coroutine spawnWaveCoroutine;
    private List<MiniGameEnemy> activeEnemies = new List<MiniGameEnemy>();

    public void StartGame()
    {
        if (spawnWaveCoroutine == null)
        {
            spawnWaveCoroutine = StartCoroutine(SpawnWave());
        }
    }

    public void StopGame()
    {
        StopAllCoroutines();
        RemoveEnemy();
    }

    private void RemoveEnemy()
    {
        foreach (MiniGameEnemy enemy in activeEnemies)
        {
            Destroy(enemy.gameObject);
        }
        activeEnemies.Clear();
    }


    private IEnumerator SpawnWave()
    {
        while (true)
        {
            SpawnRandomEnemy();
            yield return new WaitForSeconds(3f);
        }
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
        activeEnemies.Add(miniGameEnemy);
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
