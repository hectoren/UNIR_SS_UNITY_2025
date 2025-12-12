using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    private int enemiesAlive = 0;

    [Header("UI del nivel completado")]
    [SerializeField] private GameObject levelClearedUI;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void RegisterEnemy()
    {
        enemiesAlive++;
    }

    public void UnregisterEnemy()
    {
        enemiesAlive--;

        if (enemiesAlive <= 0)
        {
            LevelCompleted();
        }
    }

    private void LevelCompleted()
    {
        if (levelClearedUI != null)
        {
            levelClearedUI.SetActive(true);
            Time.timeScale = 0f;
        }

        Debug.Log("Nivel Superado");
    }
}
