using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Simulation.Towers;
using UnityEngine;

namespace AncientMonkey.Weapons
{
    public abstract class AbilityTemplate : ModContent
    {
        public override void Register() { }
        public abstract string AbilityName { get; }
        public abstract string Icon { get; }
        public abstract void EditTower(Tower tower);
        public float stackIndex = 0;
        public bool enabled = true;
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public virtual string Description { get; }
        public virtual Sprite CustomIcon { get; }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public virtual bool IsCamo { get; }
        public virtual bool IsLead { get; }
    }
}
