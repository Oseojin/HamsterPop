using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SaveManager SaveManager;
    public GameData gameData;
    public GameObject hamsterPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SaveManager = FindFirstObjectByType<SaveManager>();
        gameData = SaveManager.LoadData();
        StartCoroutine(AutoSave());
        SpawnHamsters();
    }

    public void SaveGame()
    {
        SaveManager.SaveData(gameData);
        Debug.Log("저장");
    }

    IEnumerator AutoSave()
    {
        SaveManager.SaveData(gameData);
        Debug.Log("자동 저장");
        yield return new WaitForSeconds(60f);
    }

    public int rowCount = 4;         // 행 수 (세로)
    public int columnCount = 5;      // 열 수 (가로)
    public float spacing = 1.5f;     // 햄스터 간격
    public Transform startPosition; // 생성 시작 위치

    private List<GameObject> hamsterList = new List<GameObject>();

    public void SpawnHamsters()
    {
        ClearHamsters(); // 기존 햄스터 삭제

        int count = 0;

        for (int row = 0; row < rowCount; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                if(count >= gameData.HamsterAmount)
                {
                    return;
                }
                Vector2 spawnPosition = new Vector2(
                    startPosition.position.x + column * spacing,
                    startPosition.position.y - row * spacing
                );

                GameObject newHamster = Instantiate(hamsterPrefab, spawnPosition, Quaternion.identity, transform);
                hamsterList.Add(newHamster);
                count++;
            }
        }
    }

    public void AddHamster()
    {
        if(gameData.HamsterAmount >= 20)
        {
            return;
        }
        Vector2 spawnPosition = new Vector2(
            startPosition.position.x + (gameData.HamsterAmount % 5) * spacing,
            startPosition.position.y - (gameData.HamsterAmount / 5) * spacing
        );

        GameObject newHamster = Instantiate(hamsterPrefab, spawnPosition, Quaternion.identity, transform);
        hamsterList.Add(newHamster);
        gameData.HamsterAmount++;
    }

    private void ClearHamsters()
    {
        foreach (var hamster in hamsterList)
        {
            if (hamster != null)
                Destroy(hamster);
        }

        hamsterList.Clear();
    }
}
