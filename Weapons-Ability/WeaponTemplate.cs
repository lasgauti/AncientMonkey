using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Simulation.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AncientMonkey
{

	public abstract class WeaponTemplate : ModContent
	{
		public override void Register() { }
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
		public virtual bool IsCamo { get; }
		public virtual bool IsLead { get; }
		public virtual string Description { get; }
		public virtual Sprite CustomIcon { get; }

	}
}
