using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeFountainFurniture : FountainFurniture
{

    public override void SecondaryAction(PlayerManager playerManager)
    {
        {
            if (GetIsContentPackable())
            {
                PackFurniture();
            }
            else
            {
                playerManager.uiManager.infoPanel.ShowPanel("You can't pack it up.");
                SoundManager.instance.PlayErrorSound();
            }
        }
    }

	
}
