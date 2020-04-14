using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmXCPunkConcertCustomQuests : FsmBaseState, IQuestInitiator
{

    public override void Init(BaseNpcManager myNpc)
    {
        this.npc = myNpc;
    }

    public override void StartAction()
    {
        npc.FaceTarget();
        PickQuest(npc.target.GetComponent<PlayerManager>());
    }

    public override void ExecuteAction()
    {

    }

    public void PickQuest(PlayerManager playerManager)
    {
        int d100 = Random.Range(0,100); 
        
        string questToStart = "civilian_asks_for_pot";
        
        if(d100 < 10){
            questToStart = "civilian_asks_for_cocaine";
        }else if(d100 >= 10 && d100 < 30){
            questToStart = "civilian_asks_for_ecstasy";
        }else if(d100 >= 30 && d100 < 50){
            questToStart = "civilian_asks_for_ganja";
        }else if(d100 >= 50 && d100 < 70){
            questToStart = "civilian_asks_for_pot";
        }else if(d100 >= 70 && d100 < 85){
            questToStart = "civilian_asks_for_pizza";
        }else if(d100 >= 85 && d100 < 100){
            questToStart = "civilian_asks_for_popcorn";
        }        
        
        playerManager.GetComponent<PlayerQuestsManager>().StartQuest(questToStart, this);

        npc.SetState(new FsmWander());
    }

    public override void FinishAction()
    {
       
    }


}
