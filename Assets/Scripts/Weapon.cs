using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData data;
    public int currentLevel = 0;

    private float timer = 0f;

    public Transform firePoint;

    void Update()
    {
        if (data == null || data.levels.Count <= currentLevel) return;

        timer += Time.deltaTime;

        if (timer >= data.levels[currentLevel].cooldown)
        {
            Fire();
            timer = 0f;
        }
    }

    void Fire()
    {
        var levelData = data.levels[currentLevel];
        for (int i = 0; i < levelData.projectileCount; i++)
        {
            Instantiate(data.prefab, firePoint.position, Quaternion.identity);
        }
    }

    public void Upgrade()
    {
        if (currentLevel < data.levels.Count - 1)
        {
            currentLevel++;
        }
    }
}
