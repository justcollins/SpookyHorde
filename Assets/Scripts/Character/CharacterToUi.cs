using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (CharacterHealth))]
[RequireComponent (typeof (CharacterInventory))]
public class CharacterToUi : MonoBehaviour {

    public Shoot ammoRef;
    public Text ammoText;
    public Text healthText;
    public Slider healthSlider;
    public Text inventoryText;

    private CharacterHealth health;
    private CharacterInventory inventory;

    void Start () {
        health = GetComponent<CharacterHealth>();
        inventory = GetComponent<CharacterInventory>();
        healthSlider.maxValue = health.health;
    }
	
	void Update () {
        SethealthText();
        SetAmmoText();
        SetInventoryText();
    }

    public void SethealthText()
    {
        healthSlider.value = health.getCurrentHealth();
        healthText.text = health.getCurrentHealth().ToString() + "/" + health.health.ToString();
    }

    public void SetAmmoText()
    {
        ammoText.text = "Ammo: " + ammoRef.ammo.ToString();
    }

    public void SetInventoryText() {
        inventoryText.text = "Flares: " + inventory.getCurrentFlares().ToString();
    }
}
