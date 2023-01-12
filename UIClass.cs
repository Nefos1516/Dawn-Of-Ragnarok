using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
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
