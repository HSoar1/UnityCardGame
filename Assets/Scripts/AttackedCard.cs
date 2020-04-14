using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//攻撃される側
public class AttackedCard : MonoBehaviour, IDropHandler {

    public void OnDrop(PointerEventData eventData) {

        /*攻撃*/
        //attackerカード選択
        CardController attacker = eventData.pointerDrag.GetComponent<CardController>();
        //defenderカード選択
        CardController defender = GetComponent<CardController>();
 
        if (attacker == null || defender == null) {
            return;
        }

        if(attacker.model.isPlayerCard == defender.model.isPlayerCard) {
            return;
        }

        if (attacker.model.canAttack) {
            //attckerとdefenderを戦わせる
            GameManager.instance.CardsBattle(attacker, defender);

        }
    }
}
