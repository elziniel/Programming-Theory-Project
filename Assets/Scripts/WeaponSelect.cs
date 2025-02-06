using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelect : MonoBehaviour
{
    public WeaponType[] AvailableWeapons;
    public WeaponType SelectedWeapon;
    public Button WeaponButtonPrefab;
    public System.Action<WeaponType> onWeaponChanged;

    private List<Button> WeaponButtons = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (WeaponType weapon in AvailableWeapons)
        {
            Button button = Instantiate(WeaponButtonPrefab, transform);
            button.GetComponentInChildren<TextMeshProUGUI>().text = weapon.name;

            button.onClick.AddListener(() =>
            {
                SelectedWeapon = weapon;
                foreach (var button in WeaponButtons)
                {
                    button.interactable = true;
                }

                button.interactable = false;

                onWeaponChanged?.Invoke(SelectedWeapon);
            });

            WeaponButtons.Add(button);
        }
    }
}
