using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Simulation.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		public virtual string Description { get; }
		public virtual Sprite CustomIcon { get; }
		public virtual bool IsCamo { get; }
		public virtual bool IsLead { get; }
	}
}
