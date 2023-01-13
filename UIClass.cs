using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;

namespace Dawn_Of_Ragnarok
{
    
    internal class BossKilledUI : ModSystem
    {
        
        internal UserInterface killedUI;
        internal BossKilledUIState killedUIState;
        public override void Load()
        {
            if (!Main.dedServ)
            {
            killedUI = new UserInterface();

            killedUIState = new BossKilledUIState();
            killedUIState.Activate();
            }
        }
        private GameTime _lastUpdateUiGameTime;

        public override void UpdateUI(GameTime gameTime)
        {
        _lastUpdateUiGameTime = gameTime;
        if (killedUI?.CurrentState != null)
        {
            killedUI.Update(gameTime);
        }
        }
    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
      int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
      if (mouseTextIndex != -1)
      {
        layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
            "Dawn_Of_Ragnarok: killedUI",
          delegate
          {
            if (_lastUpdateUiGameTime != null && killedUI?.CurrentState != null)
            {
              killedUI.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
            }
            return true;
          },
            InterfaceScaleType.UI));
      }
    }
    internal void ShowKilledUI()
    {
      killedUI?.SetState(killedUIState);
    }

    internal void HideKilledUI()
    {
      killedUI?.SetState(null);
    }
  }
  internal class BossKilledUIState : UIState
  {
        public override void OnInitialize()
        {
            UIPanel panel = new();
            panel.Width.Set(400, 0);
            panel.Height.Set(200, 0);
            panel.HAlign = 0.5f;
            panel.VAlign = 0.1f;
            Append(panel);
            UIText panelText = new("Would you like to consume this boss soul?");
            panel.Append(panelText);
            

            UIPanel consumeButton = new();
            consumeButton.Width.Set(100, 0);
            consumeButton.Height.Set(25, 0);
            consumeButton.VAlign = 0.90f;
            consumeButton.HAlign = 0.95f;
            consumeButton.OnClick += OnConsume;
            panel.Append(consumeButton);

            UIText consumeButtonText = new("Yes");
            consumeButtonText.TextColor = Color.Green;
            consumeButtonText.VAlign = consumeButtonText.HAlign = 0.5f;
            consumeButton.Append(consumeButtonText);

            UIPanel refuseButton = new();
            refuseButton.Width.Set(100, 0);
            refuseButton.Height.Set(25, 0);
            refuseButton.VAlign = 0.90f;
            refuseButton.HAlign = 0.05f;
            refuseButton.OnClick += OnRefuse;
            panel.Append(refuseButton);

            UIText refuseButtonText = new("No");
            refuseButtonText.TextColor = Color.Red;
            refuseButtonText.VAlign = refuseButtonText.HAlign = 0.5f;
            refuseButton.Append(refuseButtonText);
        }

        private void OnConsume(UIMouseEvent evt, UIElement listeningElement)
        {
            ModContent.GetInstance<BossKilledUI>().HideKilledUI();
            switch (ModContent.GetInstance<CallForUI>().GetMinionType())
            {
                case 4:
                    Main.NewTextMultiline("Eye of Cthulhu had been consumed!\nThe Eye is now locked in cage...", c:Color.MediumVioletRed);
                    Globals.consumedBosses.Add(4);
                    break;
                case 35:
                    Main.NewTextMultiline("Skeletron had been consumed!\nMighty skeleton found another prison...", c:Color.SlateGray);
                    Globals.consumedBosses.Add(35);
                    break;
                case 50:
                    Main.NewTextMultiline("King Slime had been consumed!\nPathetic king of all jelly...", c:Color.DeepSkyBlue);
                    Globals.consumedBosses.Add(50);
                    break;
                case 113:
                    Main.NewTextMultiline("Wall Of Flesh had been consumed!\nThe protector of the world falls alas...", c:Color.DarkViolet);
                    Globals.consumedBosses.Add(113);
                    break;
                case 125:
                    Main.NewTextMultiline("The Twins had been consumed!\nMechanical eyes for Him has no future...", c:Color.Red);
                    Globals.consumedBosses.Add(125);
                    break;
                case 126:
                    Main.NewTextMultiline("The Twins had been consumed!\nMechanical eyes for Him has no future...", c:Color.LimeGreen);
                    Globals.consumedBosses.Add(126);
                    break;
                case 127:
                    Main.NewTextMultiline("Skeletorn Prime had been consumed\nMechanical horror with four arms can't terrorize no more...", c:Color.DarkRed);
                    Globals.consumedBosses.Add(127);
                    break;
                case 134:
                    Main.NewTextMultiline("The Destroyer had been consumed!\nWorm of steel won't dig his holes...", c:Color.Coral);
                    Globals.consumedBosses.Add(134);
                    break;
                case 222:
                    Main.NewTextMultiline("Queen Bee had been consumed!\nHives will soon be abandoned...", c:Color.Honeydew );
                    Globals.consumedBosses.Add(222);
                    break;
                case 245:
                    Main.NewTextMultiline("Golem had been consumed!\nProtector of Lihzahrd Temple serves another master now...", c:Color.Brown);
                    Globals.consumedBosses.Add(245);
                    break;
                case 262:
                    Main.NewTextMultiline("Plantera had been consumed!\nJungle terror can't protect anyone...", c:Color.Pink);
                    Globals.consumedBosses.Add(262);
                    break;
                case 266:
                    Main.NewTextMultiline("Brain of Cthulhu had been consumed!\nCrimson lost its mind...", c: Color.Crimson);
                    Globals.consumedBosses.Add(266);
                    break;
                case 370:
                    Main.NewTextMultiline("Duke Fishron had been consumed!\nDuke of seas will never see a sea again...", c: Color.SeaGreen);
                    Globals.consumedBosses.Add(370);
                    break;
                case 398:
                    Main.NewTextMultiline("Moon Lord had been consumed!\nSuch power trapped in another prison", c:Color.DarkTurquoise);
                    Globals.consumedBosses.Add(398);
                    break;
                case 439:
                    Main.NewTextMultiline("Lunatic Cultist had been consumed!\nHis prays won't be heared...", c:Color.DeepSkyBlue);
                    Globals.consumedBosses.Add(439);
                    break;
                case 636:
                    Main.NewTextMultiline("Empress of Light had been consumed!\nA precious butterfly in ugly cage...", c: Color.DeepPink);
                    Globals.consumedBosses.Add(636);
                    break;
                case 657:
                    Main.NewTextMultiline("Queen Slime had been consumed!\nHer majesty found new royal spot...", c:Color.MistyRose);
                    Globals.consumedBosses.Add(657);
                    break;
                default:
                    Main.NewText("Not Included Yet");
                    break;
            }
        }

        private void OnRefuse(UIMouseEvent evt, UIElement listeningElement)
        {
            ModContent.GetInstance<BossKilledUI>().HideKilledUI();
            Main.NewText("Boss had been spared...", Color.Gold);
        }

    }
  }
