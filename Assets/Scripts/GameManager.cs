using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

    //publicにするときは  [SerializeField] public;
    [SerializeField] Transform playerHandTransform;
    [SerializeField] Transform playerFieldTransform;
    [SerializeField] Transform enemyHandTransform;
    [SerializeField] Transform enemyFieldTransform;
    [SerializeField] CardController cardPrefab;

    public bool isPlayerTurn;//どっちのターンか判断するのに使用
    
    //カードリスト(山札)の決め打ち
    List<int> playerDeck = new List<int>() {3, 1, 2, 2,1 ,2, 2, 3 ,3};
    List<int> enemyDeck = new List<int>() {2, 1, 3, 1, 3, 3, 2, 3,1};

    int playerHeroHp;
    int enemyHeroHp;
    [SerializeField] Text playerHeroHpText;
    [SerializeField] Text enemyHeroHpText;

    public int playerManaCost;
    public int enemyManaCost;
    [SerializeField] Text playerManaCostText;
    [SerializeField] Text enemyManaCostText;

    [SerializeField] GameObject resultPanel;
    [SerializeField] Text resultText;

    int playerDefaultManaCost;
    int enemyDefaultManaCost;

    [SerializeField] Transform playerHero;

    //ターンの時間管理に使用
    [SerializeField] Text timeCountText;
    int timeCount;

    //シングルトン化(どこからでもアクセスできるようにする)
    public static GameManager instance;

    private void Awake(){ //起きたバグAwakwやawakeの綴ミスで動かない=>Awakeは自分で名前を付けた関数ではなく、もともと用意されているもの
    
    if(instance == null) {//これがよくわからない　シングルトン化と合わせて後で調べる

            instance = this;//thisに関することを調べる
        }
    }
    
    void Start(){//Awake同様用意されたもの
  
        StartGame();
    }

    /*ゲーム起動時(勝負開始時)の処理*/
    void StartGame() {

        //結果画面を非表示にする
        resultPanel.SetActive(false);

        //プレイヤーヒーローのHPを10にする
        playerHeroHp = 10;
        
        //敵ヒーローのHPを10にする
        enemyHeroHp = 10;
        
        //プレイヤーコストを試験的に10にする(実際は先攻は1、後攻は0スタートのほうがいいと思う)
        playerManaCost = 10;//本来の値は0
        
        //敵のコストを試験的に10にする
        enemyManaCost = 10;//本来の値は0
        
        //プレイヤーが持っているコストを保存する　初期のplayerNamaCost = playerDefaultManaCost
        //(playerManaCostは処理に応じて減らすので保存するものが必要)
        playerDefaultManaCost = 10;//本来の値は0
        
        //敵が持っているコストを保存する　初期のenemyManaCost = enemyDefaultManaCost
        enemyDefaultManaCost = 10;//本来の値は0
        
        //HPの表示を更新
        ShowHeroHp();
        
        //コストの表示を更新
        ShowNamaCost();
        
        //プレイヤーと敵にカードを配る
        SettingInitHand();
        
        //プレイヤーのターンにする(後々これはランダムで割り振って初期のマナコストを決める)
        isPlayerTurn = true;
        
        //ターンの処理をする(今はプレイヤーターン確定なのでその処理)
        TurnCalc();
    }

    /*マナコストの表示*/
    void ShowNamaCost() {

        //playerManaCostのtext要素にplayerManaCostをString型にしたものを代入する
        playerManaCostText.text = playerManaCost.ToString();

        //enemyManaCostのtext要素にenemyManaCostをString型にしたものを代入する
        enemyManaCostText.text = enemyManaCost.ToString();
    }

    /*マナコストを減らす処理*/
    public void ReduceManaCost(int cost, bool isPlayerCard) {

        if (isPlayerCard) {//どっちのカードを使うかの判定
        
            //プレイヤーカード分のコストをプレイヤーのマナコストから減らす
            playerManaCost -= cost;
        } else {
            
            //敵カード分のコストを敵のマナコストから減らす
            enemyManaCost -= cost;
        }
        
        //表示しているマナコストの更新
        ShowNamaCost();
    }

    //対戦終了後のリスタートの処理
    public void Restert() {

        /*handとfieldのカードの削除*/

        //プレイヤーの手札を削除
        foreach (Transform card in playerHandTransform) {

            //指定したGameObjectを破壊(削除)する
            Destroy(card.gameObject);
        }

        //プレイヤーのフィールドカードを削除
        foreach (Transform card in playerFieldTransform) {

            Destroy(card.gameObject);
        }

        //敵の手札を削除
        foreach (Transform card in enemyHandTransform) {

            Destroy(card.gameObject);
        }

        //敵のフィールドカードを削除
        foreach (Transform card in enemyFieldTransform) {

            Destroy(card.gameObject);
        }

        //デッキの再生成
        playerDeck = new List<int>() { 3, 1, 2, 2, 1, 2, 2, 3, 3 };//List<int> playerDeck～～～にするとなぜか手札、場に存在したカードがデッキリストから削除された状態でリスタートされる（要検証
        enemyDeck = new List<int>() { 2, 1, 3, 1, 3, 3, 2, 3, 1 };//上記と同じ

        //ゲームをスタート
        StartGame();
    }

    /*ゲーム開始時のカード配布*/
    void SettingInitHand() {

        //カードをそれぞれ三枚配る
        for (int i = 0; i < 3; i++) {

            //プレイヤーのデッキからプレイヤーのハンドに一枚加える
            GiveCardToHand(playerDeck,playerHandTransform);

            //敵のデッキから敵のハンドにカードを一枚加える
            GiveCardToHand(enemyDeck,enemyHandTransform);
        }
    }

    /*ターン開始時の処理*/
    void TurnCalc() {//このタイミングでターン側のカードを動かせるようにする方がいい
        

        //コルーチンをいったんリセットする(しないと減る数がバグる)
        StopAllCoroutines();//カウントを初めてそれを止めずに同じ関数,変数で重ねてカウントダウンしているからだと思われる

        //カウントダウンスタート
        StartCoroutine(CountDown());//関数に時間制御(Coroutine)が使われている場合は呼び出すときにSetCoroutine()が必要


        if (isPlayerTurn) {//プレイヤーターンなら

            //プレイヤーターンの処理
            PlayerTurn();
        }else {//敵ターンなら

            //敵ターンの処理
            StartCoroutine(EnemyTurn());
        }
    }

    /*カードが攻撃可能かどうかの処理*/
    void SettingCanAttackView(CardController[] fieldCardList, bool canAttack) {

        foreach (CardController playerFieldCard in fieldCardList) {//foreachがよくわかっていない

            //カードを攻撃可能にする
            playerFieldCard.SetCanAttack(canAttack);
        }
    }

    /*カウントダウンに関する処理*/
    IEnumerator CountDown() {//コルーチン(Coroutine,時間制御関数)を使うときはvoidじゃなくてIEnumeratorを使う

        //制限時間を1設定する(初期設定、リセット時の再設定)
        timeCount = 10;//とりあえず10秒とせてい

        //制限時間を表示する(初期表示、リセット時の再表示)
        timeCountText.text = timeCount.ToString();//imeCountTextのtext要素にtimeCountをストリング化したものを代入

        //毎秒の処理
        while (timeCount > 0) {//制限時間を過ぎているかどうかの処理
            
            //一秒待機する
            yield return new WaitForSeconds(1);
            
            //制限時間を1減らす
            timeCount--;

            //制限時間の表示を更新する
            timeCountText.text = timeCount.ToString();//timeCoutTextのtext成分にtimeCountをString型にしたものを代入する
        }

        //ターンエンド , もっと制限時間を長くして10秒前から警告を出すなどしてもいいかもしれない
        ChangeTurn();
    }

    public void OnClickTurnEndButton() {

        if (isPlayerTurn) {

            ChangeTurn();
        }
    }

    /*ターンエンド時の処理*/
    public void ChangeTurn() {//このタイミングでターンエンドした側のカードを動かせないようにした方がいい
        
        /*攻撃可能表示を攻撃不可表示にする*/

        //プレイヤーのフィールドのカードを取得
        CardController[] playerFieldCardList = playerFieldTransform.GetComponentsInChildren<CardController>();
        
        //取得したプレイヤーのフィールドのカードを攻撃不可表示にする
        SettingCanAttackView(playerFieldCardList, false);
        
        //敵のフィールドのカードを取得
        CardController[] enemyFieldCardList = enemyFieldTransform.GetComponentsInChildren<CardController>();
        
        //取得した敵のフィールドのカードを攻撃不可表示にする
        SettingCanAttackView(enemyFieldCardList, false);

        //ターンを交代する
        isPlayerTurn = !isPlayerTurn;

        //ターン開始の処理をする
        TurnCalc();
    }

    /*プレイヤーのターンの処理*/
    void PlayerTurn() {
        
        //プレイヤーのターン開始時のLog
        Debug.Log("Playerのターン");

        /*プレイヤーのマナを増やす*/

        //保存するプレイヤーのマナコスト(規定値のマナコスト)を1増やす
        playerDefaultManaCost++;

        //表示するプレイヤーのマナコストを(可変値のマナコスト)を変更する(最大マナコストが１増えたのと同じ)
        playerManaCost = playerDefaultManaCost;

        //マナコストの表示を更新する
        ShowNamaCost();

        //プレイヤーの手札に山札からカードを一枚持ってくる
        GiveCardToHand(playerDeck, playerHandTransform);

        /*フィールドのカードを攻撃可能にする*/

        //プレイヤーのフィールドにあるカードを取得する
        CardController[] playerFieldCardList = playerFieldTransform.GetComponentsInChildren<CardController>();
        
        //取得したカードを攻撃可能にする
        SettingCanAttackView(playerFieldCardList, true);
    }
    
    /*敵のターンの処理*/
    IEnumerator EnemyTurn() {

        //敵のターン開始時のLog
        Debug.Log("Enemyのターン");

        //保存する敵のマナコスト(規定値のマナコスト)を1増やす
        enemyDefaultManaCost++;

        //表示する敵のマナコスト(可変値のマナコスト)を変更する(最大マナコストが1増えたのと同じ)
        enemyManaCost = enemyDefaultManaCost;

        //マナコストの表示を更新する
        ShowNamaCost();

        //敵の手札に敵の山札からカードを一枚持ってくる
        GiveCardToHand(enemyDeck, enemyHandTransform);
       

        /*フィールドのカードを攻撃可能にする*/

        //フィールドのカードを取得
        CardController[] enemyFieldCardList = enemyFieldTransform.GetComponentsInChildren<CardController>();
        
        //攻撃できるように可視化
        SettingCanAttackView(enemyFieldCardList, true);

        yield return new WaitForSeconds(1);

        /*場にカードを出す*/
        
        //手札のカードリストを取得
        CardController[] enemyHandCardList = enemyHandTransform.GetComponentsInChildren<CardController>();

        //コスト以下のカードがあれば場にカードを出し続ける
        while (Array.Exists(enemyHandCardList, card => card.model.cost <= enemyManaCost)) {
            
            //コスト以下のカードリストを取得
            CardController[] enemySeletableCardList = Array.FindAll(enemyHandCardList, card => card.model.cost <= enemyManaCost);
            
            //場に出すカードを選択
            CardController enemyCard = enemySeletableCardList[0];

            /*カードを移動*/

            //カードの移動
            StartCoroutine(enemyCard.movement.MoveToField(enemyFieldTransform));

            //敵のコストを減らす
            ReduceManaCost(enemyCard.model.cost, false);

            //出したカードをフィールドにいる判定にする
            enemyCard.model.isFieldCard = true;

            //手札にあるカードリストを再取得
            enemyHandCardList = enemyHandTransform.GetComponentsInChildren<CardController>();

            yield return new WaitForSeconds(1);
        }
        
        /*攻撃*/

        //フィールドのカードリストを取得
        CardController[] fieldCardList = enemyFieldTransform.GetComponentsInChildren<CardController>();

        //攻撃可能カードがあれば攻撃を繰り返す
        while (Array.Exists(fieldCardList, card => card.model.canAttack)) {

            /*攻撃可能カードを取得*/

            //取得した敵のフィールドのカードリストから攻撃可能なカードを選んで取得する
            CardController[] enemyCanAttackCardList = Array.FindAll(fieldCardList, card => card.model.canAttack);//検索:Array.FindAll card=>のcardは変数
            
            //プレイヤーのフィールドにあるカードを取得する
            CardController[] playerFieldCardList = playerFieldTransform.GetComponentsInChildren<CardController>();

            //attackerを選択
            CardController attacker = enemyCanAttackCardList[0];//今回は取得した攻撃可能なカードリストの一番上を選んで選択する
            if (playerFieldCardList.Length > 0) {//プレイヤーのフィールドにカードがあるとき

                //defenderを選択
                CardController defender = playerFieldCardList[0];//今回は取得したプレイヤーのフィールドのカードリストの一番上を選んで選択する

                //defenderを攻撃するモーションを開始する
                StartCoroutine(attacker.movement.MoveToTarget(defender.transform));
         
                yield return new WaitForSeconds(0.51f);
                
                //攻撃判定をして、判定したカードを攻撃不可にする
                CardsBattle(attacker, defender);
            } else {

                //プレイヤーのヒーローを攻撃するモーションを開始する
                StartCoroutine(attacker.movement.MoveToTarget(playerHero));
                
                yield return new WaitForSeconds(0.25f);
                
                //攻撃判定をして、攻撃したカードを攻撃不可にする
                AttackToHero(attacker, false);

                yield return new WaitForSeconds(0.26f);

                //ヒーローが生きているかの判定をする
                CheckHeroHp();

            }

            //フィールドのカードリストを再取得
            fieldCardList = enemyFieldTransform.GetComponentsInChildren<CardController>();

            yield return new WaitForSeconds(1);
        }

        //ターンエンド
        ChangeTurn();
    }

    //カード同士のバトルの処理
    public void CardsBattle(CardController attacker, CardController defender) {
       
        /*攻撃前のHPのLog*/
        
        //バトル開始の合図
        Debug.Log("CardsBattle");
        
        //攻撃前のアタッカーのHP
        Debug.Log("attacker HP:" + attacker.model.hp);
        
        //攻撃前のディフェンダーのHP
        Debug.Log("defender HP:" + defender.model.hp);
        
        /*アタック時のHP等の処理*/

        //アタッカーがディフェンダーに攻撃する処理
        attacker.Attack(defender);

        //ディフェンダーがアタッカーに反撃(攻撃)する処理
        defender.Attack(attacker);
        
        /*攻撃後のHPのLog*/

        //攻撃後のアタッカーのHP
        Debug.Log("attacker HP:" + attacker.model.hp);
  
        //攻撃後のディフェンダーのHP
        Debug.Log("defender HP:" + defender.model.hp);

        /*攻撃したカードが生きているかどうかの判定*/

        //アタッカーが生きてるかどうかの判定と処理
        attacker.CheckAleve();
        
        //ディフェンダーが生きているかどうかの判定と処理
        defender.CheckAleve();
    }

    /*カードの生成とデータの受け渡し*/
    void GiveCardToHand(List<int> deck, Transform hand) {

        if(deck.Count == 0) {//デッキにカードがあるかないかの判定　カードがあるとき

            //カードがないので受け渡せない => return , 後々敗北処理やカードがない、山札の見た目を変えるなどをしてもいいと思う
            return;
        }

        /*デッキにカードがあるとき*/

        //カードIDを決める(とりあえず配列の先頭)
        int cardID = deck[0];

        //選んだカードをデッキから取り除く
        deck.RemoveAt(0);

        //カードを手札に渡す
        CreateCard(cardID, hand);
    }

    /*カードを手札に渡す処理*/
    void CreateCard(int cardID, Transform hand) {

        CardController card = Instantiate(cardPrefab, hand, false);//これよくわからない
        if (hand.name == "PlayerHand") {

            card.Init(cardID, true);
        } else {

            card.Init(cardID, false);//シャッフルするときは配列自体をシャッフルした方が楽かもしれない
        }
    }

    /*ヒーローのHPの表示に関する処理*/
    void ShowHeroHp() {

        //プレイヤーヒーローのHPを更新する
        playerHeroHpText.text = playerHeroHp.ToString();

        //敵ヒーローのHPを更新する
        enemyHeroHpText.text = enemyHeroHp.ToString();
    }

    /*ヒーローに攻撃する処理*/
    public void AttackToHero(CardController attacker, bool isPlayerCard){

        if(isPlayerCard){//プレイヤーカードなら

            enemyHeroHp -= attacker.model.at;//プレイヤーヒーローのHPからアタッカーの攻撃力を引く
        }else{//敵カードなら

            playerHeroHp -= attacker.model.at;//敵ヒーローのHPからアタッカーの攻撃力を引く
        }

        //ヒーローのHPを更新する
        ShowHeroHp();

        //攻撃したカードを攻撃不可判定にする
        attacker.SetCanAttack(false);
    }

   
    void CheckHeroHp() {

        if (playerHeroHp <= 0 || enemyHeroHp <= 0) {

            ShowResultPanel(playerHeroHp);
    }

    void ShowResultPanel(int heroHp) {

            StopAllCoroutines();

            resultPanel.SetActive(true);

            /*勝敗の判定*/
            if (heroHp <= 0) {//プレイヤーのヒーローのHPが0以下のとき

                //負け
                resultText.text = "LOSE";
            } else {//敵のヒーローのHPが0以下のとき

                //勝ち
                resultText.text = "WIN";
            }
        }

    }
}
