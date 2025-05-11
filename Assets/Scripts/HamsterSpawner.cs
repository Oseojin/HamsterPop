using System.Collections.Generic;
using UnityEngine;

public class HamsterSpawner : MonoBehaviour
{
    public GameObject hamsterPrefab; // 햄스터 프리팹
    public int rowCount = 5;         // 행 수 (세로)
    public int columnCount = 4;      // 열 수 (가로)
    public float spacing = 1.5f;     // 햄스터 간격
    public Vector2 startPosition = new Vector2(-3, 2); // 생성 시작 위치

    private List<GameObject> hamsterList = new List<GameObject>();

    public void SpawnHamsters()
    {
        ClearHamsters(); // 기존 햄스터 삭제

        for (int row = 0; row < rowCount; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                Vector2 spawnPosition = new Vector2(
                    startPosition.x + column * spacing,
                    startPosition.y - row * spacing
                );

                GameObject newHamster = Instantiate(hamsterPrefab, spawnPosition, Quaternion.identity, transform);
                hamsterList.Add(newHamster);
            }
        }
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
