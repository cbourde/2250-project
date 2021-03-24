using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    Button newGame;
    Button quit;

    // Start is called before the first frame update
    void Start()
    {
        newGame = gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Button>();
        quit = gameObject.transform.GetChild(0).transform.GetChild(2).GetComponent<Button>();
        newGame.onClick.AddListener(startCharCreation);
        quit.onClick.AddListener(quitGame);
    }

    void startCharCreation()
    {
        //finish.gameObject.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    void quitGame()
    {
        Application.Quit();
    }

}
