using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeManager : MonoBehaviour
{
    public GameObject panel;
    public Button[] buttons;
    public List<WeaponData> allWeapons;

    private PlayerWeaponController weaponController;

    void Start()
    {
        panel.SetActive(false);
        weaponController = FindObjectOfType<PlayerWeaponController>();
    }

    public void ShowUpgrades()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);

        List<WeaponData> options = new List<WeaponData>();

        // Randomly pick 3 from allWeapons
        int optionCount = Mathf.Min(3, allWeapons.Count);
        List<WeaponData> pool = new List<WeaponData>(allWeapons);

        for (int i = 0; i < optionCount; i++)
        {
            int index = Random.Range(0, pool.Count);
            options.Add(pool[index]);
            pool.RemoveAt(index);
        }



        for (int i = 0; i < buttons.Length; i++)
        {
            if (i >= options.Count)
            {
                buttons[i].gameObject.SetActive(false);
                continue;
            }

            buttons[i].gameObject.SetActive(true);

            var weapon = options[i];
            var btn = buttons[i];


            int level = weaponController.GetWeaponLevel(weapon);
            string weaponName = $"{weapon.weaponName} +{level + 1}";
            string description = $"DMG +{weapon.levels[level].damage}, Count +{weapon.levels[level].projectileCount}";
            btn.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = $"{weaponName}\n{description}";


            Image icon = btn.transform.Find("Icon").GetComponent<Image>();
            icon.sprite = weapon.icon;

            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => SelectUpgrade(weapon));
        }

    }

    void SelectUpgrade(WeaponData weapon)
    {
        weaponController.AddOrUpgradeWeapon(weapon);
        panel.SetActive(false);
        Time.timeScale = 1f;
    }




}
