using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleMenu : MonoBehaviour
{
    public GameObject difficultySelector;
    public TMP_Dropdown difficultyDropdown;
    public GameObject continueButton;

    public void Start()
    {
        if (PlayerPrefs.GetString("gameData") == "")
        {
            continueButton.SetActive(false);
        }
    }

    public void OnClickContinue()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnClickNewGame()
    {
        difficultySelector.SetActive(true);
    }
    public void OnClickCancel()
    {
        difficultySelector.SetActive(false);
    }
    public void OnClickStart()
    {
        GameData gameData = new GameData();
        gameData.HamsterList.Add(new HamsterData());
        gameData.SeedAmount = 4000 * (difficultyDropdown.value + 1);
        gameData.HamsterAmount = 1;
        PlayerPrefs.SetString("gameData", JsonUtility.ToJson(gameData));
        SceneManager.LoadScene("GameScene");
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
}
