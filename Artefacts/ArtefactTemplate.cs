using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace AncientMonkey.Artefacts
{
    public abstract class ArtefactTemplate : ModContent
    {
        public override void Register() { }
        public abstract string ArtefactName { get; }
        public abstract string Icon { get; }
        public abstract void EditModel(Model model);
        public abstract string ArtefactDescription { get; }
        public bool enabled;
    }
}
