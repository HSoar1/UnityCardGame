using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {

    //見かけに(view)関することの操作
    CardView view;

    //データ(model)に関することの操作
    public CardModel model;

    //移動（movement）に関することの操作
    public CardMovement movement;

    public void Awake() {

        //CardViewから情報を取得する
        view = GetComponent<CardView>();//viewにCardViewのComponent(要素,情報)を取得

        //CardMovementから情報を取得する
        movement = GetComponent<CardMovement>();//movementにCardMovementのComponent(要素,情報)を取得
    }

    public void Init(int cardID, bool isPlayer) {
       
        //CardModelから情報を取得する
        model = new CardModel(cardID, isPlayer);


        view.Show(model);
    }

    public void Attack(CardController enemyCard) {


        model.Attack(enemyCard);//これよくわかってないAttackの中にAttackを書くの? => 
                                //解決?)CardModel.csのAttackだと思う(Cardmodel.cs/Attackの参照を見た感じそうだと思う) 
                                //関数の重複は良くないかな？ 修正の必要ありかも

        //攻撃したカードを攻撃不可にする
        SetCanAttack(false);
    }

    public void SetCanAttack(bool canAttack) {

        model.canAttack = canAttack;
        view.SetActiveSelectablePanel(canAttack);
    }

    public void CheckAleve() {

        if (model.isAlive) {

            view.Refresh(model);
        }
        else {

            Destroy(this.gameObject);
        }
    }
}