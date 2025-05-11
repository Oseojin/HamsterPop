using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCMenuManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject EscMenu;
    private bool isESC = false;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TurnESCMenu();
        }
    }

    public void TurnESCMenu()
    {
        isESC = !isESC;
        EscMenu.SetActive(isESC);
        Time.timeScale = isESC ? 0.0f : 1.0f;
    }
    public void OnCancel()
    {
        TurnESCMenu();
    }

    public void OnExit()
    {
        gameManager.SaveGame();
        SceneManager.LoadScene("TitleScene");
    }
}
