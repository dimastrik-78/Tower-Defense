using UnityEngine;

namespace _Source.TowerSystem
{
    public interface IPeople
    {
        GameObject WeaponPrefab { get; set; }
        double SpeedAttack { get; set; }
        int Damage { get; set; }
        double AttackRadius { get; set; }
    }
}
