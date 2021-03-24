using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour
{
    TextMeshProUGUI pointDisplay;
    Button finish;
    Dropdown classChoice;
    public static int statPoints;
    [Header("Stat Panels")]
    public GameObject[] statPanels = new GameObject[6];
 
    // Start is called before the first frame update
    void Start()
    {
        pointDisplay = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        finish = gameObject.transform.GetChild(2).GetComponent<Button>();
        classChoice = gameObject.transform.GetChild(3).GetComponent<Dropdown>();
        finish.onClick.AddListener(finishAndLaunch);
        statPoints = 10;
    }

    private void Update()
    {
        pointDisplay.text = "Remaing Points: " + statPoints.ToString();
        if (statPoints == 0)
        {
            finish.gameObject.SetActive(true);
        }
        else
        {
            finish.gameObject.SetActive(false);
        }
    }

    void finishAndLaunch()
    {
        Player.strength = statPanels[0].GetComponent<StatBlock>().getStat();
        Player.dexterity = statPanels[1].GetComponent<StatBlock>().getStat();
        Player.constitution = statPanels[2].GetComponent<StatBlock>().getStat();
        Player.intelligence = statPanels[3].GetComponent<StatBlock>().getStat();
        Player.wisdom = statPanels[4].GetComponent<StatBlock>().getStat();
        Player.charisma = statPanels[5].GetComponent<StatBlock>().getStat();
        Player.charClass = classChoice.options[classChoice.value].text;

        SceneManager.LoadScene("DungeonLevel");
    }

}
