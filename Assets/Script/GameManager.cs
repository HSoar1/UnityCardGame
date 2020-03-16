using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //手札にカード生成

    [SerializeField] Transform playerHandTransform;
    [SerializeField] CardController cardPrefab;
    void Start()
    {
        CreateCard(playerHandTransform);

    }

    //カードの生成とデータの受け渡し
    void CreateCard(Transform hand) {
        CardController card = Instantiate(cardPrefab, hand, false);
        card.Init(1);//現在はカード1を生成している
    }

}
