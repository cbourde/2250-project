using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpController : MonoBehaviour
{
    public Button STRButton;
    public Button DEXButton;
    public Button CONButton;
    public Button INTButton;
    public Button WISButton;
    public Button CHAButton;

    // Start is called before the first frame update
    void Start()
    {
        STRButton.onClick.AddListener(IncreaseSTR);
        DEXButton.onClick.AddListener(IncreaseDEX);
        CONButton.onClick.AddListener(IncreaseCON);
        INTButton.onClick.AddListener(IncreaseINT);
        WISButton.onClick.AddListener(IncreaseWIS);
        CHAButton.onClick.AddListener(IncreaseCHA);
    }


    public void IncreaseSTR()
    {
        Player.strength++;
        Player.P.UpdateStats();
        CloseMenu();
    }

    public void IncreaseDEX()
    {
        Player.dexterity++;
        Player.P.UpdateStats();
        CloseMenu();
    }

    public void IncreaseCON()
    {
        Player.constitution++;
        Player.P.UpdateStats();
        CloseMenu();
    }

    public void IncreaseINT()
    {
        Player.intelligence++;
        CloseMenu();
    }

    public void IncreaseWIS()
    {
        Player.wisdom++;
        CloseMenu();
    }

    public void IncreaseCHA()
    {
        Player.charisma++;
        CloseMenu();
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
