using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public static UIController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public Slider expLvlSlider;
    public TMP_Text expLvlText;

    public LevelUpSelectionButton[] levelUpButtons;

    public GameObject levelUpPanel;

    public TMP_Text coinText;

    public PlayerStatUpgradeDisplay moveSpeedUpgradeDisplay, healthUpgradeDisplay, pickupRangeUpgradeDisplay, maxWeaponsUpgradeDisplay;

    public TMP_Text timeText;

    public GameObject levelEndScreen;
    public TMP_Text endTimeText;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateExperience(int currentExp, int levelExp, int currentLvl )
    {
        expLvlSlider.maxValue = levelExp;
        expLvlSlider.value = currentExp;

        expLvlText.text = "Level: " + currentLvl;

    }

    public void SkipLevelUp()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void UpdateCoins()
    {
        coinText.text = "Recycling: " + CoinController.instance.currentCoins;
    }

    public void PurchaseMoveSpeed()
    {
        PlayerStatController.instance.PurchaseMoveSpeed();
        SkipLevelUp();
    }

    public void PurchaseHealth()
    {
        PlayerStatController.instance.PurchaseHealth();
        SkipLevelUp();
    }

    public void PurchasePickupRange()
    {
        PlayerStatController.instance.PurchasePickupRange();
        SkipLevelUp();
    }

    public void PurchaseMaxWeapons()
    {
        PlayerStatController.instance.PurchaseMaxWeapons();
        SkipLevelUp();
    }

    public void UpdateTimer(float time)
    {
        float minutes = Mathf.FloorToInt( time / 60f);
        float seconds = Mathf.FloorToInt( time % 60);

        timeText.text = "Time: " + minutes + ":" + seconds.ToString("00");
    }

    public void GoToMainMenu()
    {

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
