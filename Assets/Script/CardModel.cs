using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//カードデータとその処理
public class CardModel
{
    public string name;
    public int hp;
    public int at;
    public int cost;
    public Sprite icon;

    public CardModel(int cardId) {
        CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card" + cardId);
        name = cardEntity.name;
        hp = cardEntity.hp;
        at = cardEntity.at;
        cost = cardEntity.cost;
        icon = cardEntity.icon;
    }

}
