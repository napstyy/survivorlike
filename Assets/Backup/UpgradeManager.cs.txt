using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public GameObject panel;
    public Button[] buttons;

    void Start()
    {
        panel.SetActive(false);

        // Hook up buttons
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => SelectUpgrade(btn.name));
        }
    }

    public void ShowUpgrades()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

    void SelectUpgrade(string upgradeName)
    {
        var player = FindObjectOfType<PlayerController>();

        switch (upgradeName)
        {
            case "Damage":
                
                player.IncreaseDamage(1);
                break;
            case "Rate":
                player.IncreaseFireRate(0.1f);
                break;
            case "Number":
                player.IncreaseProjectileCount(1);
                break;
        }

        panel.SetActive(false);
        Time.timeScale = 1f;
    }

}
