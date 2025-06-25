using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public Transform firePoint;
    public List<Weapon> activeWeapons = new List<Weapon>();

    public void AddOrUpgradeWeapon(WeaponData newWeaponData)
    {
        // Check if player already has this weapon
        foreach (Weapon weapon in activeWeapons)
        {
            if (weapon.data == newWeaponData)
            {
                weapon.Upgrade();
                return;
            }
        }

        // Add new weapon
        GameObject weaponObj = new GameObject(newWeaponData.weaponName);
        weaponObj.transform.parent = this.transform;
        weaponObj.transform.position = firePoint.position;

        Weapon weaponComponent = weaponObj.AddComponent<Weapon>();
        weaponComponent.data = newWeaponData;
        weaponComponent.firePoint = firePoint;

        activeWeapons.Add(weaponComponent);
    }

    public int GetWeaponLevel(WeaponData data)
    {
        foreach (var weapon in activeWeapons)
            if (weapon.data == data)
                return weapon.currentLevel;

        return 0;
    }

}
