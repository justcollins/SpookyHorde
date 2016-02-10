using UnityEngine;
using System.Collections;

/*
Author: Justin Collins
Purpose of Script: Controls the GUI's during gameplay
    */

public class GUI : MonoBehaviour {

    public GameObject gui;
    public GameObject menu;

    private CharacterMovement player;

	void Awake () {
        gui.SetActive(true);
        menu.SetActive(false);
        player = FindObjectOfType<CharacterMovement>();
	}
	
	void Update () {
        ChangeMenu();
	}

    void ChangeMenu() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(gui.activeInHierarchy) {
                gui.SetActive(false);
                player.enabled = false;
                Cursor.visible = true;
                menu.SetActive(true);
                Time.timeScale = 0.0f;
            } else {
                menu.SetActive(false);
                Cursor.visible = false;
                player.enabled = true;
                gui.SetActive(true);
                Time.timeScale = 1.0f;
            }
        }
    }

    public void ContinueGame() {
        menu.SetActive(false);
        Cursor.visible = false;
        player.enabled = true;
        gui.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void MainMenu() {
        Time.timeScale = 1.0f;
        Application.LoadLevel(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
