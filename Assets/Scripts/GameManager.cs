using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] enemyPrefabs = new GameObject[2];
    public GameObject tokenPrefab;
    public GameObject gameOverScreen;

    // ENCAPSULATION
    public int level { get; private set; }
    private float bound = 8;

    private void Start()
    {
        instance = this;
        level = 0;
    }

    private void Update()
    {
        int tokens = GameObject.FindGameObjectsWithTag("Token").Length;
        if (tokens == 0)
        {
            level++;
            Spawn(level);
        }
    }

    // ABSTRACTION
    private void Spawn(int count)
    {
        for (int i = 0; i<count; i++)
        {
            SpawnOne(tokenPrefab);
        }
        if (count % 2 == 1)
        {
            SpawnOne(enemyPrefabs[0]);
        } else {
            SpawnOne(enemyPrefabs[1]);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    // ABSTRACTION
    private Vector3 GetRandomPos()
    {
        return new Vector3(Random.Range(-bound, bound), 0, Random.Range(-bound, bound));
    }

    // ABSTRACTION
    private void SpawnOne(GameObject prefab)
    {
        Instantiate(prefab, GetRandomPos(), prefab.transform.rotation);
    }
}
