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
      panel.Width.Set(600, 0);
      panel.Height.Set(250, 0);
      Append(panel);
      UIText text = new("Hi!!");
      panel.Append(text);
        }
    }
  }
