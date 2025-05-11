using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TMP_Text HamppyText;
    [SerializeField] private HamsterData hamsterData;

    private int decreaseSeedCalInitPrice = 10;
    private int incrementSeedQaulityInitPrice = 10;
    private int addHamsterInitPrice = 10;
    private int seedPopSpeedInitPrice = 10;
    private int seedEatSpeedInitPrice = 10;
    private int hamsterStomachCapacityInitPrice = 10;
    private int hamsterDigestionSpeedInitPrice = 10;
    private int autoGetSeedInitPrice = 10;

    [Header("CommandUpgradeButtons")]
    public TMP_Text decreaseSeedCalLvText;
    public TMP_Text decreaseSeedCalPriceText;
    public TMP_Text increaseSeedQualityLvText;
    public TMP_Text increaseSeedQualityPriceText;
    public TMP_Text addHamsterLvText;
    public TMP_Text addHamsterPriceText;
    [Header("IndividualUpgradeButtons")]
    public GameObject individualText;
    public GameObject seedPopSpeedButton;
    public TMP_Text seedPopSpeedLvText;
    public TMP_Text seedPopSpeedPriceText;
    public GameObject seedEatSpeedButton;
    public TMP_Text seedEatSpeedLvText;
    public TMP_Text seedEatSpeedPriceText;
    public GameObject hamsterStomachCapacityButton;
    public TMP_Text hamsterStomachCapacityLvText;
    public TMP_Text hamsterStomachCapacityPriceText;
    public GameObject hamsterDigestionSpeedButton;
    public TMP_Text hamsterDigestionSpeedLvText;
    public TMP_Text hamsterDigestionSpeedPriceText;
    public GameObject autoGetSeedButton;
    public TMP_Text autoGetSeedLvText;
    public TMP_Text autoGetSeedPriceText;

    private void Start()
    {
        individualText.SetActive(false);
        seedPopSpeedButton.SetActive(false);
        seedEatSpeedButton.SetActive(false);
        hamsterStomachCapacityButton.SetActive(false);
        hamsterDigestionSpeedButton.SetActive(false);
        autoGetSeedButton.SetActive(false);
    }

    void Update()
    {
        HamppyText.text = gameManager.gameData.Hamppy.ToString();
    }

    public void UpdateButton()
    {
        GameData gameData = gameManager.gameData;

        IsLvMax(gameData.DecreaseSeedCal, decreaseSeedCalLvText);
        decreaseSeedCalPriceText.text = (decreaseSeedCalInitPrice * Mathf.Pow(1.2f, gameData.DecreaseSeedCal)) + " Hamppy";

        IsLvMax(gameData.IncreaseSeedQuality, increaseSeedQualityLvText);
        increaseSeedQualityPriceText.text = (incrementSeedQaulityInitPrice * Mathf.Pow(1.2f, gameData.IncreaseSeedQuality)) + " Hamppy";

        IsLvMax(gameData.HamsterAmount - 1, addHamsterLvText);
        addHamsterPriceText.text = (addHamsterInitPrice * Mathf.Pow(1.2f, gameData.HamsterAmount - 1)) + " Hamppy";

        bool isHamsterSelect = hamsterData != null;
        individualText.SetActive(isHamsterSelect);
        seedPopSpeedButton.SetActive(isHamsterSelect);
        seedEatSpeedButton.SetActive(isHamsterSelect);
        hamsterStomachCapacityButton.SetActive(isHamsterSelect);
        hamsterDigestionSpeedButton.SetActive(isHamsterSelect);
        autoGetSeedButton.SetActive(isHamsterSelect);
        if (isHamsterSelect)
        {
            // 개별 업그레이드
            IsLvMax(hamsterData.SeedPopSpeed, seedPopSpeedLvText);
            seedPopSpeedPriceText.text = (seedPopSpeedInitPrice * Mathf.Pow(1.2f, hamsterData.SeedPopSpeed)) + " Hamppy";

            IsLvMax(hamsterData.SeedEatSpeed, seedEatSpeedLvText);
            seedEatSpeedPriceText.text = (seedEatSpeedInitPrice * Mathf.Pow(1.2f, hamsterData.SeedEatSpeed)) + " Hamppy";

            IsLvMax(hamsterData.HamsterStomachCapacity, hamsterStomachCapacityLvText);
            hamsterStomachCapacityPriceText.text = (hamsterStomachCapacityInitPrice * Mathf.Pow(1.2f, hamsterData.HamsterStomachCapacity)) + " Hamppy";

            IsLvMax(hamsterData.HamsterDigestionSpeed, hamsterDigestionSpeedLvText);
            hamsterDigestionSpeedPriceText.text = (hamsterDigestionSpeedInitPrice * Mathf.Pow(1.2f, hamsterData.HamsterDigestionSpeed)) + " Hamppy";

            autoGetSeedLvText.text = hamsterData.AutoGetSeed ? "Lv.MAX" : "Lv.0";
            autoGetSeedPriceText.text = autoGetSeedInitPrice + " Hamppy";
        }
    }

    private void IsLvMax(int lv, TMP_Text text)
    {
        if(lv >= 20)
        {
            text.text = "Lv.MAX";
        }
        else
        {
            text.text = "Lv." + lv;
        }
    }

    public void SelectHamster(HamsterData _hamsterData = null)
    {
        hamsterData = _hamsterData;
        UpdateButton();
    }

    public void OnClickDecreaseSeedCalUpgrade()
    {
        if(gameManager.gameData.DecreaseSeedCal < 20)
        {
            gameManager.gameData.DecreaseSeedCal++;
            UpdateButton();
        }
    }

    public void OnClickAddHamsterUpgrade()
    {
        if(gameManager.gameData.HamsterAmount < 20)
        {
            gameManager.AddHamster();
            UpdateButton();
        }
    }
}
