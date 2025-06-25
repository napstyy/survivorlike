using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int currentXP = 0;
    public int currentLevel = 1;
    public int xpToNextLevel = 5;

    public void AddXP(int amount)
    {
        currentXP += amount;
        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentXP -= xpToNextLevel;
        currentLevel++;
        xpToNextLevel += 5;

        Debug.Log("Level Up! Now level " + currentLevel);

        //FindObjectOfType<UpgradeManager>().ShowUpgrades();
    }

}
