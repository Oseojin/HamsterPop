using System.Collections.Generic;
using UnityEngine;

public class HamsterSpawner : MonoBehaviour
{
    public GameObject hamsterPrefab; // �ܽ��� ������
    public int rowCount = 5;         // �� �� (����)
    public int columnCount = 4;      // �� �� (����)
    public float spacing = 1.5f;     // �ܽ��� ����
    public Vector2 startPosition = new Vector2(-3, 2); // ���� ���� ��ġ

    private List<GameObject> hamsterList = new List<GameObject>();

    public void SpawnHamsters()
    {
        ClearHamsters(); // ���� �ܽ��� ����

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
