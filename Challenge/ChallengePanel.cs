using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Unity.Effects;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.Towers.Upgrades;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using Il2CppNinjaKiwi.Common;
using Il2CppTMPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AncientMonkey.Challenge
{
	public class ChallengePanel : ModGameMenu<ExtraSettingsScreen>
	{

		ModHelperScrollPanel ScrollPanel;
		public override bool OnMenuOpened(Il2CppSystem.Object data)
		{
			CommonForegroundScreen.instance.heading.SetActive(true);
			CommonForegroundHeader.SetText("Ancients Challenges");
			var panelTransform = GameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
			var panel = panelTransform.gameObject;
			panel.DestroyAllChildren();
			var MainPanel = panel.AddModHelperPanel(new Info("AncientsChallengesMenu", 3600, 1900));
			CreateChallengesListPanel(MainPanel);

			return false;
		}
		private void CreateChallengesListPanel(ModHelperPanel MainPanel)
		{
			ScrollPanel = MainPanel.AddScrollPanel(new Info("MainScrollMenu", 0, 0, 3300, 2000), RectTransform.Axis.Vertical, VanillaSprites.MainBgPanel, 50, 50);
			LoadChallengesPanels();
		}
		public void LoadChallengesPanels()
		{
			ScrollPanel.ScrollContent.transform.DestroyAllChildren();

			foreach (var challenge in GetContent<ChallengeTemplate>().OrderByDescending(c => c.mod == mod))
			{
				ScrollPanel.AddScrollContent(CreateChallenge(challenge));
			}
		}
		public ModHelperPanel CreateChallenge(ChallengeTemplate challenge)
		{
			var panel = ModHelperPanel.Create(new Info("ChallengePanel" + challenge.ChallengeName, 0, 0, 3150, 250), challenge.Background);
			var name = panel.AddText(new Info("ChallengeName", -1150, 0, 800, 100), challenge.ChallengeName, 80, TextAlignmentOptions.MidlineLeft);
			var difficulty = panel.AddText(new Info("ChallengeDifficulty", -200, 0, 800, 100), challenge.ChallengeDifficulty.ToString(), 80, TextAlignmentOptions.MidlineLeft);
			var image = panel.AddImage(new Info("image", 400, 0, 225, 225), challenge.Icon);

			var button = panel.AddButton(new Info("ChallengeIcon", 780, 0, 500, 150), VanillaSprites.GreenBtnLong, new System.Action(() =>
			{
				AncientMonkey.mod.selectedChallenge = challenge;
				LoadChallengesPanels();
			}));
			ModHelperText select = button.AddText(new Info("select", 0, 0, 700, 160), "Select", 80);
			if (challenge.UsingCustomSprite)
			{
				image.Image.SetSprite(challenge.CustomSprite);
			}
			if (AncientMonkey.mod.selectedChallenge.Name == challenge.Name)
			{
				panel.SetInfo(new Info("ChallengePanel" + challenge.ChallengeName, 0, 0, 3150, 250 + challenge.DescriptionPanelHeight));
				name.SetInfo(new Info("ChallengeName", -1150, challenge.DescriptionPanelHeight / 2, 800, 100));
				difficulty.SetInfo(new Info("ChallengeDifficulty", -200, challenge.DescriptionPanelHeight / 2, 800, 100));
				image.SetInfo(new Info("image", 400, challenge.DescriptionPanelHeight / 2, 225, 225));
				button.SetInfo(new Info("ChallengeIcon", 780, challenge.DescriptionPanelHeight / 2, 500, 150));
				select.Text.text = "Selected";
				var descriptionText = panel.AddText(new Info("descriptionText", 0, -75, 3100, challenge.DescriptionPanelHeight), challenge.Description, 80, TextAlignmentOptions.TopLeft);
			}
			return panel;
		}
	}
}
