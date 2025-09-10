using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models;

namespace AncientMonkey.Mutators
{
    public abstract class MutatorTemplate : ModContent
    {
        public override void Register() { }
        public abstract string MutatorName { get; }
        public abstract string Icon { get; }
        public abstract void EditModel(Model model);
        public abstract string MutatorDescription { get; }
        public bool enabled;
    }
}
