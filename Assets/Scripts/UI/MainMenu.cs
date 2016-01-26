using UnityEngine;
using System.Collections;

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
