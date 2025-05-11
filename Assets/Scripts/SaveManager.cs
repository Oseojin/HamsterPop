using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ExistSaveData()
    {
        return PlayerPrefs.GetString("gameData") != "";
    }

    public GameData LoadData()
    {
        return JsonUtility.FromJson<GameData>(PlayerPrefs.GetString("gameData"));
    }

    public void SaveData(GameData gameData)
    {
        PlayerPrefs.SetString("gameData", JsonUtility.ToJson(gameData));
    }

    public void NewGame(int difficulty)
    {
        GameData gameData = new GameData();
        gameData.HamsterList.Add(new HamsterData());
        gameData.HamsterAmount = 1;
        gameData.SeedAmount = 40000 * (difficulty);
        if(difficulty == 4)
        {
            gameData.SeedAmount = -1;
        }
        PlayerPrefs.SetString("gameData", JsonUtility.ToJson(gameData));
        SceneManager.LoadScene("GameScene");
    }
}
