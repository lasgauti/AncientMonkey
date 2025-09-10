using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Simulation.Towers;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models;

namespace AncientMonkey.Weapons
{
    public abstract class AbilityTemplate : ModContent
    {
        public override void Register() { }
        public abstract string AbilityName { get; }
        public abstract string Icon { get; }
        public abstract int MaxLevel { get; }
        public abstract float StartingUpgradeCost { get; }
        public abstract void EditTower(TowerModel towerModel);
        public abstract void Upgrade(List<Model> models, Tower tower);
        public float stackIndex = 0;
        public bool enabled = true;
        public float upgradeCost;
        public float upgradesCount;
        public virtual string Description { get; }
        public virtual Sprite CustomIcon { get; }
       
        public virtual bool IsCamo { get; }
        public virtual bool IsLead { get; }
    }
}
