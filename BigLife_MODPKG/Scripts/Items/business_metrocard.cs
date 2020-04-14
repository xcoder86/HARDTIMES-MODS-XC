using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class business_metrocard : BaseItem
{
	//this will be declared as an extra at json level
    public int maxUses;

	//must override void UseItem(PlayerManager playerManager) if you want it to actually do something meaningful
    public override void UseItem(PlayerManager playerManager)
    {
		//unlock an achievement if you declared one in 'achievementsOnUse' at item json level
        Utilities.UnlockAchievements(playerManager, achievementsOnUse);
		
		//add an active effect if you declared one in 'itemEffectOnUse' at item json level
        playerManager.GetComponent<PlayerEffectsManager>().AddActiveEffect(GetEffectOnUse());
		
		//do something
		if(maxUses > 0){
			maxUses--;
			playerManager.uiManager.infoPanel.ShowPanel("YOU USED YOUR METRO CARD! ({?} uses left)",2f,new List<string>() { (maxUses + "") });
			//max the player's stamina!
			playerManager.staminaManager.StatValue = playerManager.staminaManager.maxStatValue;
			SoundManager.instance.PlaySound("magic_restfull_staff.ogg");
		}else{
			//the staff has no more uses left
			playerManager.uiManager.infoPanel.ShowPanel("METRO CARD USED UP!");
			//beep in despair
			SoundManager.instance.PlayErrorSound();
		}
    }
}