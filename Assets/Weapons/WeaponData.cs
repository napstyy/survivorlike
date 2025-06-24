using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public GameObject prefab;
    public Sprite icon;

    public List<WeaponLevel> levels;
    public List<WeaponEvolution> evolutions;
}
