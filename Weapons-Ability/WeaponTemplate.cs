using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Simulation.Towers;
using UnityEngine;

namespace AncientMonkey
{

    public abstract class WeaponTemplate : ModContent 
    {
        public override void Register(){}
        public abstract int SandboxIndex { get; }
        public abstract Rarity WeaponRarity { get; }
        public abstract string WeaponName { get; }
        public abstract string Icon { get; }
        public abstract void EditTower(Tower tower);
        public enum Rarity
        {
            Common,
            Rare,
            Epic,
            Legendary,
            Exotic,
            Godly,
            Omega,
        }
        public float stackIndex = 0;
        public bool enabled = true;
        public bool unlocked = false;
        public virtual bool IsCamo { get; }
        public virtual bool IsLead { get; }
        public virtual bool Is4thPath { get; }
        public virtual bool IsDisabled { get; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public virtual string Description { get; }
        public virtual Sprite CustomIcon { get; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}
