using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatBlock : MonoBehaviour
{
    Button leftArrowBtn;
    Button rightArrowBtn;
    TextMeshProUGUI textDisplay;
    private int statNum;

    private void Start()
    {
        leftArrowBtn = gameObject.transform.GetChild(0).gameObject.GetComponent<Button>();
        rightArrowBtn = gameObject.transform.GetChild(1).gameObject.GetComponent<Button>();
        textDisplay = gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        statNum = 1;

        leftArrowBtn.onClick.AddListener(LeftOnClick);
        rightArrowBtn.onClick.AddListener(RightOnClick);
    }

    private void Update()
    {
        textDisplay.text = statNum.ToString();
    }

    public int getStat () { return statNum;  }

    void LeftOnClick()
    {
        if (statNum > 1)
        {
            statNum--;
            CharacterCreation.statPoints++;
        }
        
    }

    void RightOnClick()
    {
        if (statNum < 5 && CharacterCreation.statPoints > 0)
        {
            statNum++;
            CharacterCreation.statPoints--;
        }
    }

}
