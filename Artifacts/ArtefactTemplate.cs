using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace AncientMonkey.Artifacts
{
    public abstract class ArtifactTemplate : ModContent
    {
        public override void Register() { }
        public abstract string ArtifactName { get; }
        public abstract string Icon { get; }
        public abstract void EditModel(Model model);
        public abstract string ArtifactDescription { get; }
        public bool enabled;
    }
}
