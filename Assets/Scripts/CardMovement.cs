using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class CardMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    public Transform defaultParent;

    public bool isDraggable;

    public void OnBeginDrag(PointerEventData eventData) {
        //カードのコストとplayerのコストを比較
        CardController card = GetComponent<CardController>();
        if(card.model.isPlayerCard && GameManager.instance.isPlayerTurn == true && !card.model.isFieldCard && card.model.cost <= GameManager.instance.playerManaCost) {

            isDraggable = true;
        } else if(card.model.isPlayerCard && GameManager.instance.isPlayerTurn == true && card.model.isFieldCard && card.model.canAttack) {
            
            isDraggable = true;
        } else {

            isDraggable = false;
        }

        if (!isDraggable) {
            
            return;
        }

        defaultParent = transform.parent;
        transform.SetParent(defaultParent.parent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        if (!isDraggable) {

            return;
        }
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (!isDraggable) {

            return;
        }
        transform.SetParent(defaultParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public IEnumerator MoveToField(Transform field) {

        //一度親をキャンバスに変更する
        transform.SetParent(defaultParent.parent);//defaultParent.parent => defaultParentにするとカードがかさなるバグが発生
        //DOTweenでカードをフィールドに移動
        transform.DOMove(field.position, 0.25f);
        yield return new WaitForSeconds(0.25f);

        defaultParent = field;
        transform.SetParent(defaultParent);
    }

    public IEnumerator MoveToTarget(Transform target) {

    /*
        修正すべきバグ
        ターゲットが元の位置に戻るときにdestroyされているとエラー出ている
        <とりあえずの修正>  0.51fの処理待ちを作ることで移動にかかる時間（0.5f）を待つ
    */

        //現在の位置と並びを取得
        Vector3 currentPosition = transform.position;
        int setSiblingIndex = transform.GetSiblingIndex();
            
        //一度親をキャンバスに変更する
        transform.SetParent(defaultParent.parent);//defaultParent.parent => defaultParentにするとカードがかさなるバグが発生
        //DOTweenでカードをターゲットに移動
        transform.DOMove(target.position, 0.25f);
        yield return new WaitForSeconds(0.25f);

        //元の位置と並びに戻る
        transform.DOMove(currentPosition, 0.25f);
        yield return new WaitForSeconds(0.25f);
        transform.SetParent(defaultParent);
        transform.SetSiblingIndex(setSiblingIndex);
    }


    void Start() {

        defaultParent = transform.parent;
    }
}
