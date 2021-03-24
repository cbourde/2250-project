using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour
{
    TextMeshProUGUI pointDisplay; //initializing needed variables
    Button finish;
    Dropdown classChoice;
    public static int statPoints;
    [Header("Stat Panels")] //array to add all the stat panels to
    public GameObject[] statPanels = new GameObject[6];
 
    // Start is called before the first frame update
    void Start()
    {
        pointDisplay = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>(); //assigning all components to their respective variables
        finish = gameObject.transform.GetChild(2).GetComponent<Button>();
        classChoice = gameObject.transform.GetChild(3).GetComponent<Dropdown>();
        finish.onClick.AddListener(finishAndLaunch);
        statPoints = 10; //sets default amount of stat allocation points to 10
    }

    private void Update()
    {
        pointDisplay.text = "Remaing Points: " + statPoints.ToString(); //updates text telling user how many points to allocate are remaining
        if (statPoints == 0) //set of code to activate/deactivate the finish character creation when there are no stats left to allocate
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
        Player.strength = statPanels[0].GetComponent<StatBlock>().getStat(); //sets all the static stats in the Player class to the chosen stats
        Player.dexterity = statPanels[1].GetComponent<StatBlock>().getStat();
        Player.constitution = statPanels[2].GetComponent<StatBlock>().getStat();
        Player.intelligence = statPanels[3].GetComponent<StatBlock>().getStat();
        Player.wisdom = statPanels[4].GetComponent<StatBlock>().getStat();
        Player.charisma = statPanels[5].GetComponent<StatBlock>().getStat();
        Player.charClass = classChoice.options[classChoice.value].text;

        SceneManager.LoadScene("DungeonLevel"); //changes scene to the dungeon level
    }

}
