using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public GameObject ESCMenu;
    private bool isESC = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameData = JsonUtility.FromJson<GameData>(PlayerPrefs.GetString("gameData"));
        Debug.Log(gameData.SeedAmount);
    }

    // Update is called once per frame
    void Update()
    {
        OnESCMenu();
    }

    private void OnESCMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isESC = !isESC;
            ESCMenu.SetActive(isESC);
            Time.timeScale = isESC ? 0.0f : 1.0f;
        }
    }
}
