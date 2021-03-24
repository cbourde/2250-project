using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//this class is used for individual sets of stat editors, including a display and 2 button for num down and num up. to be placed on a stat panel
public class StatBlock : MonoBehaviour
{
    Button leftArrowBtn; //initializing needed objects
    Button rightArrowBtn;
    TextMeshProUGUI textDisplay;
    private int statNum;

    private void Start()
    {
        leftArrowBtn = gameObject.transform.GetChild(0).gameObject.GetComponent<Button>(); //assigning objects to the gameobjects and components
        rightArrowBtn = gameObject.transform.GetChild(1).gameObject.GetComponent<Button>();
        textDisplay = gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        statNum = 1; //setting the base number for stats

        leftArrowBtn.onClick.AddListener(LeftOnClick); //event listeners for the left and right buttons
        rightArrowBtn.onClick.AddListener(RightOnClick);
    }

    private void Update()
    {
        textDisplay.text = statNum.ToString(); //updates the current stat number to display to user
    }

    public int getStat () { return statNum;  } //getter for the stat number

    void LeftOnClick() //will decrease stat if it is not 1
    {
        if (statNum > 1)
        {
            statNum--;
            CharacterCreation.statPoints++; //update remaining stat point total in CharacterCreation
        }
        
    }

    void RightOnClick()
    {
        if (statNum < 5 && CharacterCreation.statPoints > 0) //increases current stat number if it is not 5 and there are remaining points to allocate in CharacterCreation
        {
            statNum++;
            CharacterCreation.statPoints--; //update remaining stat point total in CharacterCreation
        }
    }

}
