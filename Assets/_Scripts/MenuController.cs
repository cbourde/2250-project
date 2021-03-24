using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    Button newGame; //buttons used in the bain menu
    Button quit;

    // Start is called before the first frame update
    void Start()
    {
        newGame = gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Button>(); //assigning buttons to their respective component
        quit = gameObject.transform.GetChild(0).transform.GetChild(2).GetComponent<Button>();
        
        newGame.onClick.AddListener(startCharCreation); //event listeners for the buttons
        quit.onClick.AddListener(quitGame);
    }

    void startCharCreation()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false); //changes the canvas from the main menu to the character creation menu
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    void quitGame()
    {
        Application.Quit(); //used to close the application if it is not being run in Unity
    }

}
