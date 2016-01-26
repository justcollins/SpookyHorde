using UnityEngine;
using System.Collections;

/*
Author: Justin Collins
Purpose of Script: Manages the main menu
    */

public class MainMenu : MonoBehaviour {

    public void Start() {
        Cursor.visible = true;
    }

    public void StartGame() {
        Application.LoadLevel(1);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
