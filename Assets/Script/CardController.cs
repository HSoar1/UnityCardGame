using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    
    CardView view; //見かけに(view)関することの操作
    CardModel model;//データ(model)に関することの操作

    public void Awakw() {
        view = GetComponent<CardView>();
    }
    
    public void Init(int cardId) {
       
        model = new CardModel(cardId);
        view.Show(model);
    }
}

