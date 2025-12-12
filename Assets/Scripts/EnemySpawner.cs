using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int numberEnemies = 5;

    public enum SpawnMode
    {
        Line,
        Points,
    }

    [SerializeField] SpawnMode spawnMode;

    [SerializeField] Transform spawnLineTop;
    [SerializeField] Transform spawnLineBottom;

    [SerializeField] Transform[] spawnPoints;

    void Start()
    {
        if (spawnMode == SpawnMode.Line)
        {
            StartCoroutine(LineSpawning());
        }
        else if (spawnMode == SpawnMode.Points)
        {
            int numPoints = spawnPoints.Length;
            int j = Random.Range(0, numPoints);

            Vector3 startPosition = spawnPoints[j].position;

            Instantiate(enemyPrefab, startPosition, Quaternion.identity);
        }
    }

    IEnumerator LineSpawning()
    {
        Vector3 lineTop = spawnLineTop.position;
        Vector3 lineBottom = spawnLineBottom.position;

        for (int i = 0; i < numberEnemies; i++)
        {
            float t = Random.Range(0f, 1f);
            Vector3 startPosition = Vector3.Lerp(lineTop, lineBottom, t);

            Instantiate(enemyPrefab, startPosition, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }

    void Update()
    {
        
    }
}
