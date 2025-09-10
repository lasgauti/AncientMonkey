using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models;

namespace AncientMonkey.StrongerWeapons
{
    public abstract class StrongerWeaponTemplate : ModContent
    {
        public override void Register() { }
        public abstract WeaponTemplate.Rarity Rarity { get; }
        public abstract int BuffMinCount { get; }
        public abstract int BuffMaxCount { get; }
        public abstract List<BuffKey> BuffKeys();
        public BuffKey GetRandomBuffKey()
        {
            List<BuffKey> buffKeys = BuffKeys();
            Random random = new Random();

            BuffKey randomBuff = buffKeys[random.Next(buffKeys.Count)];
            return randomBuff;
        }
    }
}
