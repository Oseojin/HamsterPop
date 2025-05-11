using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleMenu : MonoBehaviour
{
    public SaveManager SaveManager;
    public GameObject difficultySelector;
    public TMP_Dropdown difficultyDropdown;
    public GameObject continueButton;

    public void Start()
    {
        SaveManager = FindFirstObjectByType<SaveManager>();
        if (!SaveManager.ExistSaveData())
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
        SaveManager.NewGame(difficultyDropdown.value + 1);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
}
