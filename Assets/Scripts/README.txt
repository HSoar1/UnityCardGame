/*目次*/
1.コードに関するメモ(L.50 - L.4031)
        L.100   - L.203  GetComponentsInChildren
                L.114  - L.140  public Component[] GetComponentsInChildren (Type type, bool includeInactive = false / true);
                L.140  - L.176  public T[] GetComponentsInChildren ();
                                public T[] GetComponentsInChildren (bool includeInactive);
                L.176  - L.203  public void GetComponentsInChildren (List<T> results);
                                public void GetComponentsInChildren (bool includeInactive, List<T> results);
        L.203  - L.331  staticとシングルトンパターン
                L.217  - L.242  public static class ClassSample{}   静的クラス
                L.242  - L.271  public static void MethodSample();  静的メソッド
                L.271  - L.301  シングルトンパターン
                L.301  - L.321  staticクラスとシングルトンパターンの違い
        L.321  - L.376  SetActive
                L.329  - L.351  SetActive (bool);
                L.351  - L.376  SetActiveの注意点
        L.376  - L.413 foreach
                L.384  - L.413  foreach (型名 オブジェクト名 in コレクション)
        L.413  - L.470  Destroy
                L.422  - L.449  Destroy (obj);
                L.449  - L.470  Destroy (Object obj, floot);
        L.470  - L.597  Coroutine(コルーチン)
                L.484  - L.500  コルーチンとは
                L.500  - L.523  コルーチンの使い方
                L.523  - L.557  yield return null;
                                yield return new WaitForSeconds (floot);
                L.557  - L.597  コルーチンを止めるとき
        L.597  - L.1126 Findメソッド
                L.625  - L.662  List<T>.Find (Predicate<T> match)
                L.662  - L.696  Array.Find (T[] array, Predicate<T> match)
                L.696  - L.739  List<T>.FindIndex (Predicate<T> match)
                L.739  - L.782  List<T>.FindIndex (int startIndex, Predicate<T> match)
                L.782  - L.827  List<T>.FindIndex (int startIndex, int count, Predicate<T> match)
                L.827  - L.869  Array.FindIndex (T[] array, Predicate<T> match)
                L.869  - L.912  Array.FindIndex (T[] array, int startIndex, Predicate<T> match)
                L.912  - L.956  Array.FindIndex (T[] array, int startIndex, int count, Predicate<T> match)
                L.956  - L.1000 List<T>.FindLast (Predicate<T> match)
                L.1000 - L.1043 Array.FindLast (T[] array, Predicate<T> match)
                L.1043 - L.1085 List<T>.FindAll (Predicate<T> match)
                L.1085 - L.1126 Array.FindAll (T[] array, Predicate<T> match)
        L.1126 - L.1199 RemoveAt
                L.1137 - L.1172 ArrayList.RemoveAt (Int32)
                L.1172 - L.1199 Collection<T>.RemoveAt (Int32)
        L.1199 - L.1246 Instantiate
                L.1208 - L.1246 Instantiate (Object original, Transform parent, bool instantiateInWorldSpace)
        L.1246 - L.1326 IDropHandler
                L.1257 - L.1294 IDropHandler
                L.1294 - L.1326 OnDrop (EventSystems.PointerEventData eventData)
        L.1326 - L. IDragHandler
                L.1349 - L.1368 IDragHandler
                L.1368 - L.1401 OnDrag (EventSystems.PointerEventData eventData)
                L.1401 - L.1421 IBeginDragHandler
                L.1421 - L.1453 OnBeginDrag (EventSystems.PointerEventData eventData)
                L.1453 - L.1472 IEndDragHandler
                L.1472 - L.1504 OnEndDrag (EventSystems.PointerEventData eventData)
        L.1504 - L.1511 BaseInputModule
                L.1511 - L.2839 BaseInputModuleに関連するもの
        L.2839 - L.2846 MonoBehaviour
                L.2846 - L.3929 MonoBehaviourに関連するもの
        L.3929 - L.3936 GetSiblingIndex
                L.3936 - L.3961 GetSiblingIndex ()
        L.3961 - L.3968 SetSiblingIndex
                L.3968 - L.4000 SetSiblingIndex (int index)
        L.4000 - L.4014 CreateAssetMenu
                L.4014 - L.4031 [CreateAssetMenu(fileName = "", menuName = "",order = )]
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L. 
        L. - L.
        L. - L.






--------------------------------------------------------------------------------------------------------------------

/* GetComponentsInChildren
参照
GetComponentsInChildren
https://docs.unity3d.com/ja/current/ScriptReference/GameObject.GetComponentsInChildren.html

ジェネリック関数
https://docs.unity3d.com/ja/current/Manual/GenericFunctions.html

HingeJoint
https://docs.unity3d.com/ja/current/ScriptReference/HingeJoint.html
*/

--------------------------------------------------------------------------------------------------------------------

/*
   public Component[] GetComponentsInChildren (Type type, bool includeInactive);
*/
---
[パラメーター]

type  :  取得するコンポーネントの型
includeInactive  :  非アクティブのコンポーネントも含めるかどうか
---

---
[説明]

ゲームオブジェクトまたはゲームオブジェクトの子たちから type のすべてのコンポーネントを取得する。
コンポーネントの検索は子オブジェクトで再帰的に行われていくので、子の子(孫)というように含まれていく。
---

---
[使用例]

Component[] hingeJoints;
hingeJoints = GetComponentsInChildren (typeof(HingeJoint));
---

--------------------------------------------------------------------------------------------------------------------

/*
   public T[] GetComponentsInChildren ();
   public T[] GetComponentsInChildren (bool includeInactive);
*/

---
[パラメーター]

includeInactive  :  非アクティブのゲームオブジェクトも含めるかどうか
---

---
[戻り値]

T[] 指定した型に一致したすべてのコンポーネントのリスト
---

---
[説明]

ジェネリック版
関数の呼び出し時にパラメーターのタイプや戻り値の型を指定することができる

ジェネリック関数
関数名の後ろに山型括弧で囲まれた文字 T または型名を持つバリアントを持つ関数
---

---
[使用例]

HingeJoint[] hingeJoints;
hingeJoints = GetComponentsInChildren<HingeJoint> ();
---

--------------------------------------------------------------------------------------------------------------------

/*
   public void GetComponentsInChildren (List<T> results);
   public void GetComponentsInChildren (bool includeInactive, List<T> results);
*/

---
[パラメーター]

results  :  見つかったコンポーネントを受け取るリスト
includeInactive  :  非アクティブのゲームオブジェクトも含めるかどうか
---

---
[説明]

見つかったすべてのコンポーネントをリスト results へ返す。
---

---
[使用例]

List<HingeJoint> hingeJoints = new List<HingeJoint> ();
GetComponentsInChildren<HingeJoint> (false, hingeJoints);
---

--------------------------------------------------------------------------------------------------------------------

/* static(静的)とシングルトンパターン
参照
static
https://qiita.com/kohzy/items/2ad386aa8738dd77ffc7

シングルトンパターン
https://qiita.com/rohinomiya/items/6bca22211d1bddf581c4

staticとシングルトンの違いについて
https://takachan.hatenablog.com/entry/2016/01/04/211414
*/

--------------------------------------------------------------------------------------------------------------------

/*
   public static class ClassSample{}
*/

---
[説明]

静的クラス
クラスのメンバー（フィールドやメソッド）はすべて static にしなければならない。
また静的クラスはインスタンス化することができない。
static キーワードを忘れると静的クラスでインスタンスのメンバーを宣言することはできません」と怒られる
---

---
[使用例]

public static class ClassSample { // ここがstaticになっているもののこと
    public static void Method_A () { // ここもstaticにする必要がある
        // 処理
    }
}
---

--------------------------------------------------------------------------------------------------------------------

/*
   public static void MethodSample ();
*/

---
[説明]

静的メソッド
クラスをインスタンス化しなくても呼び出すことだできる、ユーティリティ的なメソッドを書いたりする。
静的クラスではない、通常のクラス内にも記述することができる。
同じクラス内には通常のインスタンスメソッドも記述でき、それはクラスをインスタンス化してから呼び出す。
---

---
[使用例]

public class ClassSample {
    public static void Method_A () {// 静的メソッド -> インスタンス化せずに呼び出せる
            // 処理を実装
    }
    
    public void Method_B () { // インスタンスメソッド -> インスタンス化してから呼び出す
            // 処理を実装
    }
}
---

--------------------------------------------------------------------------------------------------------------------

/*
   シングルトンパターン
*/

---
[説明]

デザインパターンのうち、１つしかインスタンスを生成しないもの
コンストラクタのスコープを private に変更し、GetInstance()メソッドでインスタンスを取得するようにするのが肝。
---

---
[使用例]

public sealed class SingletonClass {

    private static SingletonClass _singleInstance = new SingletonClass();

    public static SingletonClass GetInstance () {
        return _singleInstance;
    }

    private SingletonClass () {
        //TODO: initialization
    }
}
---

--------------------------------------------------------------------------------------------------------------------

/*
   staticクラスとシングルトンパターンの違い
*/

---
[説明]

                 継承         仮想メンバー         抽象メンバー         インターフェイス         コード量

staticクラス   できない         持てない             持てない               持てない              少ない

シングルトン    できる           持てる               持てる                 持てる                多い

staticクラスの場合、派生クラスによる差し替えもできないため実装がシングルトンに比べ固くなります。
シングルトンは派生クラスによってメソッドをオーバーライドできるので、
テストのときにダミーデータ応答をするテストオブジェクトに差し替えるなど柔軟な対応が可能です。
---

--------------------------------------------------------------------------------------------------------------------

/* SetActive
参照
SetActive
https://www.sejuku.net/blog/53536
*/

--------------------------------------------------------------------------------------------------------------------

/*
   SetActive (bool);
*/

---
[説明]

アクティブ、非アクティブの切り替えに使う
---

---
[使用例]

//ゲームオブジェクトをアクティブにする
this.GameObject.SetActive (false);

//ゲームオブジェクトを非アクティブにする
this.GameObject.SetActive (true);
---

--------------------------------------------------------------------------------------------------------------------

/*
   SetActiveの注意点
*/

---
[説明]

①親が非アクティブだと、子供も非アクティブな状態になる
    これには注意点があって、子は実際に非アクティブな状態に変更されたわけではないという点
    どういうことかというと、親が非アクティブになると、子はアクティブな状態を保持しつつ、
    非アクティブなオブジェクトの挙動をするということ
    つまり親をアクティブに戻すと子もアクティブに戻ってくれる

②コンポーネントが無効になる。
    つまり判定や表示の処理もすべて無効になる

③スクリプトがUpdate関数など呼ばなくなる
    コンポーネントが無効になるすなわちスクリプトも無効になるのでよく考えればわかるが、
    回り続けているUpdate関数や、特定のタイミングで発生するメソッドはすべて稼働しなくなるので注意。

④注意点ではないがアクティブ、非アクティブになた時に呼びだす関数もあるので使う場面があるなら使ってみること
---

--------------------------------------------------------------------------------------------------------------------

/* foreach
参照
foreach
https://www.sejuku.net/blog/41892
*/

--------------------------------------------------------------------------------------------------------------------

/*
   foreach (型名 オブジェクト名 in コレクション)
*/

---
[説明]

foreach文とはfor文のように繰り返しループ処理を行う構文。
for文より簡潔に書くことができる場合があるというメリットがある
コレクションの要素数を取得する必要がないことや、制御変数を宣言する必要がないなどのメリットがある
また、ループごとにインクリメント(i++など)する必要がない
---

---
[使用例]

//foreachで書くと
foreach (型名 オブジェクト名 in コレクション) {
    処理文
}

//forで書くと
for (int i = 0; i < コレクションの要素数; i++) {
    処理文
}
---

--------------------------------------------------------------------------------------------------------------------

/* Destroy
参照
Destroy
https://docs.unity3d.com/ScriptReference/Object.Destroy.html
https://www.sejuku.net/blog/53555
*/

--------------------------------------------------------------------------------------------------------------------

/*
   Destory (obj);
*/

---
[説明]

ゲームオブジェクトやコンポーネント、アセットを削除する。
Componentの場合、GameObjectからコンポーネントを削除し、破壊する。
GameObjectの場合、GameObjectならびにすべてのコンポーネント、GameObjectの子であるすべてのオブジェクトを破壊する。
オブジェクトの破壊は、現在のフレームのアップデート（Update）処理後に行われるが、常にレンダリング前に実行される。
---

---
[使用例]

//ゲームオブジェクトの破壊
Destroy (this.gameObject);

//Deleteという名前のオブジェクトを取得
GameObject obj = GameObject.Find ("Delete");
//指定したオブジェクトを削除
Destroy (obj);
---

--------------------------------------------------------------------------------------------------------------------

/*
   Destroy (Object obj, floot);
*/

---
[説明]

主にDestroy(Object obj)と同じ
違う点は、どのタイミングでDestroyするかを決めることができるという点
flootに数値(ex. 0.5f)をいれると関数が呼ばれてからその数値後にDestroyしてくれる
---

---
[使用例]

//0.5フレーム後にgemaObjectを破壊する
Destroy (this.gameObject,0.5f);
---

--------------------------------------------------------------------------------------------------------------------

/* コルーチン(Coroutine)
参照
Samurai blog コルーチン
https://www.sejuku.net/blog/83712

Unityマニュアル コルーチン
https://docs.unity3d.com/ja/2018.4/Manual/Coroutines.html

StopAllCoroutines
https://docs.unity3d.com/ScriptReference/MonoBehaviour.StopAllCoroutines.html
*/

--------------------------------------------------------------------------------------------------------------------

/*
   コルーチンとは
*/

---
[説明]

コルーチンとは実行を停止して Unity へ制御を戻し
続行するときは停止したところから次のフレームで実行を継続することができる関数の事。
つまり
フレームを跨いで処理を中断・再開させることが出来る仕組みを持った、関数のようなもの
主に非同期処理、時間制御、数秒後に何か処理を行いたいときに使うといい
---

--------------------------------------------------------------------------------------------------------------------

/*
   コルーチンの使い方
*/

---
[説明、使い方]

コルーチンを使うには宣言が必要
using System.Collections;
IEnumerator 関数名 () {}

呼び出すときは
StartCoroutine ("関数名");
にする

注意点
MonoBehaviourが無効の場合でも、MonoBehaviourが完全に破棄されない限りは、コルーチンは停止しない。
MonoBehaviour.StopCoroutineとMonoBehaviour.StopAllCoroutinesを使ってコルーチンを停止することができる。
MonoBehaviourが破棄されるとコルーチンも停止する。
---

--------------------------------------------------------------------------------------------------------------------

/*
   yield return null;
   yield return new WaitForSeconds (floot);
*/

---
[説明]

yield return null;
1フレーム処理を止めて次フレームから処理を開始する

yield return new WaitForSeconds (floot);
指定したフレームだけ処理を止めて次フレームから処理を開始する
---

---
[使い方]

void Start () {
    StartCoroutine (Sample);
}

IEnumerator Sample () {
    //処理1
    yield return null;
    //処理2
    yield return new WaitForSeconds (0.5f);
    //処理3
}
//処理1 -1フレーム待つ- 処理2 -0.5フレーム待つ- 処理3
---

--------------------------------------------------------------------------------------------------------------------

/*
   コルーチンを止めるとき
*/

---
[説明、使い方]

コルーチンを時は
StopCoroutine (Enumerator型);
StopAllCoroutines ();
を使う

注意点
StopCoroutine (hoge);をしたあとStartCoroutine (hoge);をするとStopしたあとすぐから処理が再開してしまう

void Start () {
    IEnumerator coroutine = ExampleCoroutine ();
    StartCoroutine (coroutine);

    // 処理

    StopCoroutine (coroutine);
    StartCoroutine (coroutine); //続きから実行される
}

改善方法
void Start () {
    IEnumerator coroutine = ExampleCoroutine ();
    StartCoroutine (coroutine);

    // 何らかの処理が挟まる

    StopCoroutine (coroutine); 
    coroutine = ExampleCoroutine ();
    StartCoroutine (coroutine); //最初から開始
}
---

--------------------------------------------------------------------------------------------------------------------

/* Findメソッド
参照
Findメソッド
https://www.sejuku.net/blog/45252
https://araramistudio.jimdo.com/2019/07/10/c-%E3%81%AE%E9%85%8D%E5%88%97%E3%82%84list%E3%82%92%E6%A4%9C%E7%B4%A2%E3%81%99%E3%82%8B-find-findall-findindex/

Predicate<T>
https://docs.microsoft.com/ja-jp/dotnet/api/system.predicate-1?view=netframework-4.8

Find
https://docs.microsoft.com/ja-jp/dotnet/api/system.collections.generic.list-1.find?view=netframework-4.8
https://docs.microsoft.com/ja-jp/dotnet/api/system.array.find?view=netframework-4.8

FindAll
https://docs.microsoft.com/ja-jp/dotnet/api/system.collections.generic.list-1.findall?view=netframework-4.8
https://docs.microsoft.com/ja-jp/dotnet/api/system.array.findall?view=netframework-4.8

FindIndex
https://docs.microsoft.com/ja-jp/dotnet/api/system.collections.generic.list-1.findindex?view=netframework-4.8
https://docs.microsoft.com/ja-jp/dotnet/api/system.array.findindex?view=netframework-4.8

FindLast
https://docs.microsoft.com/ja-jp/dotnet/api/system.collections.generic.list-1.findlast?view=netframework-4.8
https://docs.microsoft.com/ja-jp/dotnet/api/system.array.findlast?view=netframework-4.8
*/

--------------------------------------------------------------------------------------------------------------------

/*
   List<T>.Find (Predicate<T>)
*/

---
[パラメーター]

Predicate<T>  :  検索する要素の条件を定義する 
---

---
[戻り値]

T  :  見つかった場合は、指定された述語によって定義された条件と一致する最初の要素。それ以外の場合は、型 T の既定値。
---

---
[説明]

List<T>の中から指定した条件(Predicate<T>)を満たすもので一番先頭のものを抜き出す
using System.Collections.Generic;が必要
---

---
[使用例]

using System;
using System.Collections.Generic;

void Start () {
    var list = new List<int> { 1, 2, 3, 7, 8, 9 };
    int result = list.Find (n => n % 2 == 0);//偶数を見つける result == 2
}
---

--------------------------------------------------------------------------------------------------------------------

/*
   Array.Find(T[] array, Predicate<T> match) 
*/

---
[パラメーター]

T[]  :  検索する1次元の配列。インデックス番号が0から始まる必要がある。
Predicate<T>  :  検索する要素の条件を定義する
---

---
[説明]

T[]の中から指定した条件(Predicate<T>)を満たすもので一番先頭のものを抜き出す
Predicate<T> は、メソッドまたはラムダ式へのデリゲートで、
渡されたオブジェクトがデリゲートまたはラムダ式で定義された条件に一致する場合に true を返す。
array の要素は、最初の要素から最後の要素まで、Predicate<T>に個別に渡される。
一致が見つかった場合、処理は停止される。
---

---
[使用例]

using System;

void Sample(){
    int[] n = new int[] { 1, 2, 3, 4, 5 };
    int result = Array.Find (n, n => n > 3); // 4
}
---

--------------------------------------------------------------------------------------------------------------------

/*
   List<T>.FindIndex(Predicate<T> match)
*/

---
[パラメーター]

Predicate<T>  :  検索する要素の条件を定義する
---

---
[戻り値]

Int32  :  定義された条件と一致する要素が存在した場合、最もインデックス番号の小さいインデックスを返す。
          それ以外の場合は -1。
---

---
[説明]

List<T>全体から、指定した述語によって定義される条件に一致する要素を検索し、
最もインデックス番号の小さいインデックスを返す。
List<T>は最初の要素から最後の要素まで順に検索される。
Predicate<T> は、メソッドまたはラムダ式へのデリゲートで、
渡されたオブジェクトがデリゲートまたはラムダ式で定義された条件に一致する場合に true を返す。
現在の List<T> の要素は、最初の要素から最後の要素まで、Predicate<T>に個別に渡される。
using System.Collections.Generic;が必要
---

---
[使用例]

using System;
using System.Collections.Generic;
 
void Start() {
    var list = new List<int> { 1, 2, 3, 7, 8, 9 };
    int result = list.FindIndex (n => n % 2 == 0);
}
---

--------------------------------------------------------------------------------------------------------------------

/*
   List.FindIndex (int startIndex, Predicate<T> match)
*/

---
[パラメーター]

Int(int32)  :  検索の開始位置を示す
Predicate<T>  :  検索する要素の条件を定義する
---

---
[戻り値]

Int32  :  定義された条件と一致する要素が存在した場合、最もインデックス番号の小さいインデックスを返す。
          それ以外の場合は -1。
---
 
---
[説明]

List<T> の指定したインデックスから最後の要素までの範囲内で、
指定した述語にで定義される条件に一致する要素を検索し、最初に見つかったインデックスを返す。
Predicate<T> は、メソッドまたはラムダ式へのデリゲートで、
渡されたオブジェクトがデリゲートまたはラムダ式で定義された条件に一致する場合に true を返す。
List<T> の要素は、最初の要素から最後の要素まで、Predicate<T>に個別に渡される。
using System.Collections.Generic;が必要
---

---
[使用例]

using System;
using System.Collections.Generic;
 
void Start() {
    var list = new List<int> { 1, 2, 3, 7, 8, 9 };
    int result = list.FindIndex (3, n => n % 2 == 0);
}
---

--------------------------------------------------------------------------------------------------------------------


/*
   List<T>.FindIndex (int startIndex, int count, Predicate<T> match)
*/

---
[パラメーター]

Int(Int32, startIndex)  :  検索の開始位置を示す
Int(Int32, count)  :  検索対象の範囲内にある要素の数
Predicate<T>  :  検索する要素の条件
---

---
[戻り値]

Int32  :  定義された条件と一致する要素が存在した場合、最もインデックス番号の小さいインデックスを返す。
          それ以外の場合は -1。
---

---
[説明]

List<T> の指定したインデックスの範囲内で、
指定した述語にで定義される条件に一致する要素を検索し、最初に見つかったインデックスを返す。
Predicate<T> は、メソッドまたはラムダ式へのデリゲートで、
渡されたオブジェクトがデリゲートまたはラムダ式で定義された条件に一致する場合に true を返す。
List<T> の要素は、最初の要素から最後の要素まで、Predicate<T>に個別に渡される。
using System.Collections.Generic;が必要
---

---
[使用例]

using System;
using System.Collections.Generic;
 
void Start() {
    var list = new List<int> { 1, 2, 3, 7, 8, 9 };
    int result = list.FindIndex (3, 5, n => n % 2 == 0);
}
---

--------------------------------------------------------------------------------------------------------------------

/*
   Array.FindIndex (T[] array, Predicate<T> match)
*/

---
[パラメーター]

T[]  :  検索する1次元の配列
Predicate<T>  :  検索する要素の条件を定義する
---

---
[戻り値]

Int32  :  定義された条件と一致する要素が存在した場合、最もインデックス番号の小さいインデックス。
          それ以外の場合は -1。
---

---
[説明]

Array.全体から、指定した述語によって定義される条件に一致する要素を検索し、
最もインデックス番号の小さいインデックスを返す。
Array は、最初の要素から最後の要素まで順に検索される。
Predicate<T> は、メソッドまたはラムダ式へのデリゲートで、
渡されたオブジェクトがデリゲートまたはラムダ式で定義された条件に一致する場合に true を返す。
Array は、最初の要素から最後の要素までPredicate<T>に個別に渡される。
---

---
[使用例]

using System;

void Sample(){
    int[] n = new int[] { 1, 2, 3, 4, 5 };
    int result = Array.Findindex (n, n => n > 2); // 3
}
---

--------------------------------------------------------------------------------------------------------------------

/*
   Array.FindIndex (T[] array, int startIndex, Predicate<T> match)
*/

---
[パラメーター]

T[]  :  検索する1次元の配列
int(Int32)  :  検索の開始位置
Predicate<T>  :  検索する要素の条件を定義する
---

---
[戻り値]

Int32  :  定義された条件と一致する要素が存在した場合、最もインデックス番号の小さい要素のインデックス。
          それ以外の場合は -1。
---

---
[説明]

Array は、int(startIndex)から最後の要素までの順に検索され、
最もインデックス番号の小さいインデックスを返す。
Array は、から最後の要素まで順に検索される。
Predicate<T> は、メソッドまたはラムダ式へのデリゲートで、
渡されたオブジェクトがデリゲートまたはラムダ式で定義された条件に一致する場合に true を返す。
Array は、最初の要素から最後の要素までPredicate<T>に個別に渡される。
---

---
[使用例]

using System;

void Sample () {//index  :  0  1  2  3  4
    int[] n = new int[] { 1, 2, 3, 4, 5 };
    int result = Array.Findindex (n, 3, n => n > 2); // 4
}
---

--------------------------------------------------------------------------------------------------------------------

/*
   Array.FindIndex (T[] array, int startIndex, int count, Predicate<T> match)
*/

---
[パラメーター]

T[]  :  検索する1次元の配列
Int(Int32, startIndex)  :  検索の開始位置を示す
Int(Int32, count)  :  検索対象の範囲内にある要素の数
Predicate<T>  :  検索する要素の条件
---

---
[戻り値]

Int32  :  定義された条件と一致する要素が存在した場合、最もインデックス番号の小さい要素のインデックス。
          それ以外の場合は -1。
---

---
[説明]

Array は、int(startIndex)から指定された要素内を検索され、
最もインデックス番号の小さいインデックスを返す。
Array は、から最後の要素まで順に検索される。
Predicate<T> は、メソッドまたはラムダ式へのデリゲートで、
渡されたオブジェクトがデリゲートまたはラムダ式で定義された条件に一致する場合に true を返す。
Array は、最初の要素から最後の要素までPredicate<T>に個別に渡される。
---

---
[使用例]

using System;

void Sample(){//index  :  0  1  2  3  4
    int[] n = new int[] { 1, 2, 3, 4, 5 };
    int result = Array.Findindex (n, 2, 2, n => n > 4); // -1
}
---

--------------------------------------------------------------------------------------------------------------------

/*
   List<T>.FindLast (Predicate<T> match)
*/

---
[パラメーター]

Predicate<T>  :  検索する要素の条件
---

---
[戻り値]

T  :  見つかった場合は、指定された述語によって定義された条件と一致する最後の要素
      それ以外の場合は、型Tの既定値
---

---
[説明]

最後の要素から始まり、最初の要素で終わる。
指定された述語によって定義された条件と一致する要素を、
List<T>全体を対象に検索し、最もインデックス番号の大きい要素を返す。
一致が見つかった場合、処理は停止される。
Predicate<T> は、メソッドまたはラムダ式へのデリゲートで、
渡されたオブジェクトがデリゲートまたはラムダ式で定義された条件に一致する場合に true を返す。
List<T> の要素は、最初の要素から最後の要素まで、Predicate<T>に個別に渡される。
System.Collections.Genericが必要
---

---
[使用例]

using System;
using System.Collections.Generic;

void Start () {
    var list = new List<int> { 1, 2, 3, 7, 8, 9 };
    int result = list.FindLast (n => n % 2 == 0);//偶数を見つける result == 8
}
---

--------------------------------------------------------------------------------------------------------------------

/*
   Array.FindLast (T[] array, Predicate<T> match)
*/

---
[パラメーター]

T[]  :  検索する1次元の配列
Predicate<T>  :  検索する要素の条件
---

---
[戻り値]

T  :  見つかった場合は、指定された述語によって定義された条件と一致する最後の要素
      それ以外の場合は、型 T の既定値
---

---
[説明]

最後の要素から始まり、最初の要素で終わる。
指定された述語によって定義された条件と一致する要素を、
Array.全体を対象に検索し、最もインデックス番号の大きい要素を返す。
一致が見つかった場合、処理は停止される。
Predicate<T> は、メソッドまたはラムダ式へのデリゲートで、
渡されたオブジェクトがデリゲートまたはラムダ式で定義された条件に一致する場合に true を返す。
Array.の要素は、最初の要素から最後の要素まで、Predicate<T>に個別に渡される。
---

---
[使用例]

using System;

void Sample(){
    int[] n = new int[] { 1, 2, 3, 4, 5 };
    int result = Array.Find (n, n => n > 3); // 5
}
---

--------------------------------------------------------------------------------------------------------------------

/*
   List<T>.FindAll (Predicate<T> match)
*/

---
[パラメーター]

Predicate<T>  :  検索する要素の条件
---

---
[戻り値]

List<T>  :  条件に一致する要素が見つかった場合は、そのすべての要素を格納するList<T>。
            それ以外の場合は、空の List<T>。
---

---
[説明]

指定された述語によって定義された条件と一致する要素を、
List<T>全体を対象に検索し、条件に合うすべてのインデックスの要素を返す。
Predicate<T> は、メソッドまたはラムダ式へのデリゲートで、
渡されたオブジェクトがデリゲートまたはラムダ式で定義された条件に一致する場合に true を返す。
List<T> の要素は、最初の要素から最後の要素まで、Predicate<T>に個別に渡される。
System.Collections.Genericが必要
---

---
[使用例]

using System;
using System.Collections.Generic;

void Start () {
    var list = new List<int> {1, 2, 3, 7, 8, 9};
    int [] result = list.FindAll (n => n % 2 == 0);//すべての偶数を見つける result == {2, 8}
}
---

--------------------------------------------------------------------------------------------------------------------

/*
   Array.FindAll (T[] array, Predicate<T> match)
*/

---
[パラメーター]

T[]  :  検索する1次元の配列
Predicate<T>  :   検索する要素の条件
---

---
[戻り値]

T[]  :  指定した述語によって定義される条件に一致する要素が見つかった場合は、そのすべての要素を格納するArray。
        それ以外の場合は、空のArray。
---

---
[説明]

指定された述語によって定義された条件と一致する要素を、
Array.全体を対象に検索し、条件に合うすべてのインデックスの要素を返す。
Predicate<T> は、メソッドまたはラムダ式へのデリゲートで、
渡されたオブジェクトがデリゲートまたはラムダ式で定義された条件に一致する場合に true を返す。
Arrayの要素は、最初の要素から最後の要素まで、Predicate<T>に個別に渡される。
---

---
[使用例]

using System;

void Sample () {
    int [] n = new int[] { 1, 2, 3, 4, 5 };
    int [] result = Array.FindAll (n, n => n > 3); // result == {4, 5}
}
---

--------------------------------------------------------------------------------------------------------------------

/*　RemoveAt
参照
ArrayList.RemoveAt (Int32)
https://docs.microsoft.com/ja-jp/dotnet/api/system.collections.arraylist.removeat?view=netframework-4.8

Collection<T>.RemoveAt (Int32)
https://docs.microsoft.com/ja-jp/dotnet/api/system.collections.objectmodel.collection-1.removeat?view=netframework-4.8
*/

--------------------------------------------------------------------------------------------------------------------

/*
   ArrayList.RemoveAt (Int32)
*/

---
[パラメーター]

Int32  :  削除する要素のインデックス
---

---
[説明]

ArrayListの指定したインデックスにある要素を削除
System.Collectionsライブラリ
---

---
[使用例]

ArrayList myAL = new ArrayList ();
myAL.Add ( "The" );
myAL.Add ( "quick" );
myAL.Add ( "brown" );
myAL.Add ( "fox" );
myAL.Add ( "jumps" );
myAL.Add ( "over" );
myAL.Add ( "the" );
myAL.Add ( "lazy" );
myAL.Add ( "dog" );
myAL.RemoveAt (5);//overが消える
---

--------------------------------------------------------------------------------------------------------------------

/*
   Collection<T>.RemoveAt (Int32)
*/


---
[パラメーター]

Int32  :  削除する要素のインデックス
---

---
[説明]

Collection<T>の指定したインデックスにある要素を削除
System.Collections.ObjectModel
---

---
[使用例]

   List<int> Deck = new List<int> () {2, 1, 3, 1, 3, 3, 2, 3,1};
   Deck.RemoveAt (0);
---

-----------------------------------------------------------------------------------------------------------------------

/* Instantiate
参照
Instantiate
https://docs.unity3d.com/ja/2018.4/ScriptReference/Object.Instantiate.html
https://www.sejuku.net/blog/48180
*/

--------------------------------------------------------------------------------------------------------------------

/*
   Instantiate (Object original, Transform parent, bool instantiateInWorldSpace)
*/

---
[パラメーター]

original  :  コピーしたい既存オブジェクト
parent  :  新しいオブジェクトに割り振られる親
instantiateInWorldSpace  :  true  => world positionで位置を設定するとき
                            false => 新しい親(parent)と比較して位置を設定するとき
---

---
[戻り値]

オブジェクト(インスタンス化されたクローン)
原文  :  Object  The instantiated clone.
---

---
[説明]

原文(英語)は参照の一個目
要約、簡略化：
表示されるオブジェクトを生成する関数
複製方法はコマンドのDuplicate command(CTRL＋Dのこと)と同じ方法
非アクティブなオブジェクトを持ってくると持ってきたものも非アクティブなオブジェクトになる
---

---
[使い方]

CardController card = Instantiate(cardPrefab, hand, false)
---

--------------------------------------------------------------------------------------------------------------------

/* IDropHandler
参照
IDropHandler
https://docs.unity3d.com/ja/2018.3/ScriptReference/EventSystems.IDropHandler.html

IDropHandler.OnDrop
https://docs.unity3d.com/ja/2018.3/ScriptReference/EventSystems.IDropHandler.OnDrop.html
*/

--------------------------------------------------------------------------------------------------------------------

/*
   IDropHandler
*/

---
[説明]

OnDropのコールバックを受け取りたいときのインターフェースを実装
UnityEngine.EventSystemsのインターフェイス
---

---
[テンプレート]

using UnityEngine;
using UnityEngine.EventSystems;

public class Example : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData data)
    {
        if (data.pointerDrag != null)
        {
            Debug.Log("Dropped object was: " + data.pointerDrag);
        }
    }
}
---

---
[public関数]

OnDrop  :  ドロップを受ける事ができ、ターゲット上のBaseInputModuleによって呼び出される
---

--------------------------------------------------------------------------------------------------------------------

/*
   OnDrop (EventSystems.PointerEventData eventData)
   IDropHandler.OnDrop
*/

---
[パラメーター]

eventData  :  現在のイベントデータ
---

---
[説明]

ドロップを受ける事ができ、ターゲット上のBaseInputModuleによって呼び出される
---

---
[使用例]

using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler {
    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
    }
}
---

--------------------------------------------------------------------------------------------------------------------

/* IDragHandler
参照
IDragHandler
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.IDragHandler.html

IDragHandler.OnDrag
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.IDragHandler.OnDrag.html

IBeginDragHandler
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.IBeginDragHandler.html

IBeginDragHandler.OnBeginDrag
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.IBeginDragHandler.OnBeginDrag.html

IEndDragHandler
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.IEndDragHandler.html

IEndDragHandler.OnEndDrag
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.IEndDragHandler.OnEndDrag.html
*/

--------------------------------------------------------------------------------------------------------------------

/*
   IDragHandler

*/

---
[説明]

OnDrag のコールバックを受け取りたいときのインターフェースを実装する
---

---
[public関数]

OnDrag  :  ドラッグが発生しているとき、カーソルが移動するたびに呼び出される
---

--------------------------------------------------------------------------------------------------------------------

/*
   OnDrag (EventSystems.PointerEventData eventData)
   IDragHandler.OnDrag
*/

---
[パラメーター]

eventData  :  現在のイベントデータ
---

---
[説明]

ドラッグが発生しているとき、カーソルが移動するたびに呼び出される
UnityEngine.EventSystemsのインターフェイス
---

---
[使用例]

using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler {
    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
    }
}
---

--------------------------------------------------------------------------------------------------------------------

/*
   IBeginDragHandler
*/

---
[説明]

OnBeginDrag のコールバックを受け取りたいときのインターフェースを実装する。
IBeginDragHandlerに加えIDragHandlerを実装する必要がある。
UnityEngine.EventSystemsのインターフェイス
---

---
[public関数]

OnBeginDrag  : ドラッグが開始される前にBaseInputModuleによって呼び出される。
---

--------------------------------------------------------------------------------------------------------------------

/*
   OnBeginDrag (EventSystems.PointerEventData eventData)
   IBeginDragHandler.OnBeginDrag
*/

---
[パラメーター]

eventData  :  現在のイベントデータ
---

---
[説明]

ドラッグが開始される前にBaseInputModuleによって呼び出される
---

---
[使用例]

using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler, IBeginDragHandler {
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
    }
}
---

--------------------------------------------------------------------------------------------------------------------

/*
   IEndDragHandler
*/

---
[説明]

OnEndDrag のコールバックを受け取りたいときのインターフェースを実装する
IEndDragHandlerに加えIDragHandlerを実装する必要がある
---

---
[public関数]

OnEndDrag  :  ドラッグ終了時にBaseInputModuleが呼び出される
---

--------------------------------------------------------------------------------------------------------------------

/*
   OnEndDrag (EventSystems.PointerEventData eventData)
   IEndDragHandler.OnEndDrag
*/

---
[パラメーター]

eventData  :  現在のイベントデータ
---

---
[説明]

ドラッグ終了時にBaseInputModuleが呼び出されます
---

---
[使用例]

using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler, IBeginDragHandler {
    public void OnEndDrag (PointerEventData eventData) {
        Debug.Log("OnEndDrag");
    }
}
---

--------------------------------------------------------------------------------------------------------------------

/* BaseInputModule
参照
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.html
*/

--------------------------------------------------------------------------------------------------------------------

/*
   BaseInputModule
*/

---
[説明]

UnityEngine.EventSystemsのクラス
ベースモジュールはイベントを発生させゲームオブジェクトに送信する
入力モジュールは、EventSystemのコンポーネントであり、イベントを発生させ、それらをイベントハンドリングのためにゲームオブジェクトへ伝える役割をしている
EventSystem のすべての入力モジュールは、BaseInputModuleから継承している
提供されるTouchInputModuleやStandaloneInputModuleなどのモジュールではプロジェクトにとって不十分である場合は、
BaseInputModule から拡張して独自のものを作成することができる
以下の説明に関してはリファレン(説明、リンク共に)がMonoBehaviorと同じである場合がある。
---

---
[変数]

input  :  入力モジュールによって使用されている現在のBaseInput
          public EventSystems.BaseInput input ;
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule-input.html
<EventSystems.BaseInput>
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInput.html


inputOverride  :  入力モジュールのデフォルトのBaseInputをオーバーライドするために使用される
                  独自の入力システムをバイパスしながら、同じInputModuleを使用することができる
                  偽の入力をUIにフィードしたり、別の入力システムとインターフェースしたりするために使用できる
                  public EventSystems.BaseInput inputOverride ;
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule-inputOverride.html
<EventSystems.BaseInput>
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInput.html
---

---
[public関数]


ActivateModule  :  モジュールがアクティべートされたときに呼び出される
                   モジュールをアクティべートする際にカスタマイズしたコードを実行したい場合は、オーバーライドする必要がある
                   public void ActivateModule ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.ActivateModule.html


DeactivateModule  :  モジュールが非アクティブにされたときに呼び出される
                     モジュールを非アクティブにしたときにカスタマイズしたコードを実行したい場合は、オーバーライドする必要がある
                     public void DeactivateModule ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.DeactivateModule.html


IsModuleSupported  :  モジュールがサポートされているかどうかを確認する
                      スタンドアロンでアクティベートしたくないプラットフォーム固有のモジュール(例えばTouchInputModule)がある場合は、これをオーバーライドする必要がある
                      public bool IsModuleSupported ()
                      
                      [戻り値]
                      bool   モジュールがサポートされているか
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.IsModuleSupported.html


IsPointerOverGameObject  :  ポインターが、EventSystemオブジェクト上で指定されたIDを持っているか
                            モジュールがポインターベースの場合、ポインターがEventSystemオブジェクト上にある場合は、オーバーライドしてtrueを返すことができる
                            public bool IsPointerOverGameObject (int pointerId)
                            
                            [パラメーター]
                            pointerId   ポインターのID.
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.IsPointerOverGameObject.html


Process  :  モジュールの現状況のチェックを行う
            アップデート処理ごとに一度実行される
            カスタム処理のためにオーバーライドする
            public void Process ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.Process.html


ShouldActivateModule  :  アクティベートするべきかどうか
                         追加したカスタムロジックをオーバーロード
                         public bool ShouldActivateModule ()
                         
                         [戻り値]
                         bool   モジュールをアクティベートするべきかどうか
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.ShouldActivateModule.html


UpdateModule  :  モジュールの内部状態をアップデート
                 アクティベートされたモジュールに処理が送信される前に、すべてのモジュールに対して呼び出される
                 public void UpdateModule ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.UpdateModule.html
---

---
[protected関数]


GetAxisEventData  :  入力データを与え、イベントシステムで使用するAxisEventDataを生成する
                     protected EventSystems.AxisEventData GetAxisEventData (float x, float y, float moveDeadZone)
                     
                     [パラメーター]
                     x              x方向の移動
                     y              y方向の移動
                     moveDeadZone   デッドゾーン
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.GetAxisEventData.html
<EventSystems.AxisEventData>
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.AxisEventData.html


GetBaseEventData  :  EventSystemで使用するBaseEventDataを生成する
                     protected EventSystems.BaseEventData GetBaseEventData ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.GetBaseEventData.html
<EventSystems.BaseEventData>
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseEventData.html


HandlePointerExitAndEnter  :  newEnterTargetが見つかったときに、EnterイベントとExitイベントの送信を処理する
                              protected void HandlePointerExitAndEnter (EventSystems.PointerEventData currentPointerData, GameObject newEnterTarget)
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.HandlePointerExitAndEnter.html


OnDisable  :  動作が無効になったときに呼び出される
              オブジェクトを破棄し、任意なクリーンアップのコードを実行したいときにも呼び出される
              コンパイルが完了した後にスクリプトがリロードされるときOnDisableが呼び出され、スクリプトがロードされた後にOnEnableが呼び出される
              protected void OnDisable ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.OnDisable.html
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnDisable.html


OnEnable  :  この関数はオブジェクトが有効/アクティブになったときに呼び出される
             protected void OnEnable ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.OnEnable.html
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnEnable.html
---

---
[Static関数]


DetermineMoveDirection  :  与えられた移動に対し、最適なMoveDirectionが決定される
                           protected static EventSystems.MoveDirection DetermineMoveDirection (float x, float y)
                           protected static EventSystems.MoveDirection DetermineMoveDirection (float x, float y, float deadZone)
                           
                           [パラメーター]
                           x          x方向の移動
                           y          y方向の移動
                           deadZone   デッドゾーン
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.DetermineMoveDirection.html
<EventSystems.MoveDirection>
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.MoveDirection.html


FindCommonRoot  :  与えられた2つのGameObjectに対し、共通のルートであるGameObjectとnullのどちらかを返す
                   protected static GameObject FindCommonRoot (GameObject g1, GameObject g2)
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.FindCommonRoot.html


FindFirstRaycast  :  最初にヒットした有効なRaycastResultを返す
                     protected static EventSystems.RaycastResult FindFirstRaycast (List<RaycastResult> candidates)
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.BaseInputModule.FindFirstRaycast.html
<EventSystems.RaycastResult>
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.RaycastResult.html
---

<継承メンバー>

---
[変数]


enabled  :  有効であれば更新され、無効であれば更新されない
            インスペクター上ではチェックボックスとして表示される
            public bool enabled ;
https://docs.unity3d.com/ja/current/ScriptReference/Behaviour-enabled.html


isActiveAndEnabled  :  Behaviorはアクティブで有効になっているか
                       GameObjectはアクティブまたは非アクティブにできる
                       同様に、スクリプトを有効または無効にすることができる
                       GameObjectがアクティブで、スクリプトが有効になっている場合、isActiveAndEnabledが返されtrueになる
                       それ以外の場合falseは返される
                       public bool isActiveAndEnabled ;
https://docs.unity3d.com/ja/current/ScriptReference/Behaviour-isActiveAndEnabled.html


gameObject  :  コンポーネントはゲームオブジェクトにアタッチされる
               コンポーネントは常にゲームオブジェクトにアタッチされている
               public GameObject gameObject ;
https://docs.unity3d.com/ja/current/ScriptReference/Component-gameObject.html


tag  :  ゲームオブジェクトのタグ
        タグはゲームオブジェクトを見分けるために使用することができる
        タグを使用する前にTags and Layersマネージャーでタグ名を宣言する必要がある
        public string tag ;
https://docs.unity3d.com/ja/current/ScriptReference/Component-tag.html


transform  :  GameObjectに付随したtransform
              public Transform transform ;
https://docs.unity3d.com/ja/current/ScriptReference/Component-transform.html


runInEditMode  :  MonoBehaviourの特定のインスタンスを編集モードで実行できるようにする（エディターでのみ使用可能）
                  デフォルトでは、スクリプトコンポーネントは再生モードでのみ実行される
                  このプロパティを設定すると、MonoBehaviourは、エディターがプレイモードにないときにコールバック関数が実行される
                  public bool runInEditMode ;
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour-runInEditMode.html


useGUILayout  :  これを無効にすると、GUIのレイアウトフェーズをスキップすることができる
                 このOnGUI呼び出し内でGUI.WindowおよびGUILayoutを使用しない場合にのみ使用できる
                 public bool useGUILayout ;
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour-useGUILayout.html


hideFlags  :  オブジェクトを非表示にするか、シーンに保存するか、ユーザーが変更できるようにするか
              public HideFlags hideFlags ;
https://docs.unity3d.com/ja/current/ScriptReference/Object-hideFlags.html
<HideFlags>
https://docs.unity3d.com/ja/current/ScriptReference/HideFlags.html


name  :  オブジェクト名
         コンポーネントは、ゲームオブジェクトとすべてのアタッチされたコンポーネントと同じ名前を共有する
         クラスがMonoBehaviourから派生する場合、クラスはMonoBehaviourから「名前」フィールドを継承する
         このクラスがGameObjectにもアタッチされている場合、「name」フィールドはそのGameObjectの名前に設定される
         public string name ;
https://docs.unity3d.com/ja/current/ScriptReference/Object-name.html
---

---
[public関数]


BroadcastMessage  :  ゲームオブジェクトまたは子オブジェクトにあるすべてのMonoBehaviourを継承したクラスにあるmethodName名のメソッドを呼び出す
                     受信メソッドはparameterの引数をゼロにすることで無視することができる
                     optionsがSendMessageOptions.RequireReceiverに設定されている場合、メッセージがどのコンポーネントによっても取得されないときにエラーが出力されます。
                     public void BroadcastMessage (string methodName, object parameter = null, SendMessageOptions options = SendMessageOptions.RequireReceiver)
                     public void BroadcastMessage (string methodName, SendMessageOptions options)
                     
                     [パラメーター]
                     methodName   呼び出すメソッド名
                     parameter    呼び出すメソッドに渡すオプショナルパラメーター（どのような値でも可）
                     options      目的のオブジェクトに指定したメソッドが存在しない場合、エラーを発生させるかどうか
https://docs.unity3d.com/ja/current/ScriptReference/Component.BroadcastMessage.html
<SendMessageOptions>
https://docs.unity3d.com/ja/current/ScriptReference/SendMessageOptions.html
<SendMessageOptions.RequireReceiver>
https://docs.unity3d.com/ja/current/ScriptReference/SendMessageOptions.RequireReceiver.html
<SendMessageOptions.DontRequireReceiver>
https://docs.unity3d.com/ja/current/ScriptReference/SendMessageOptions.DontRequireReceiver.html


CompareTag  :  このゲームオブジェクトがtagとタグ付けされているかどうか
               public bool CompareTag (string tag)
               
               [パラメーター]
               tag   比較するタグ
https://docs.unity3d.com/ja/current/ScriptReference/Component.CompareTag.html


GetComponent  :  ゲームオブジェクトにtypeがアタッチされている場合はtypeのタイプを使用してコンポーネントを返す
                 ない場合はnullを返す
                 public Component GetComponent (Type type)
                 
                 [パラメーター]
                 type   取得するコンポーネントの型
https://docs.unity3d.com/ja/current/ScriptReference/Component.GetComponent.html
<Component>
https://docs.unity3d.com/ja/current/ScriptReference/Component.html


GetComponentInChildren  :  GameObjectや深さ優先探索を活用して、親子関係にある子オブジェクトからtypeのタイプのコンポーネントを取得する
                           GameObjectでアクティブと判定された場合のみコンポーネントを返す
                           public Component GetComponentInChildren (Type t)
                           
                           [パラメーター]
                           t   取得するコンポーネントの型

                           [戻り値]
                           Component   見つかった場合、型に一致したコンポーネントを返す
https://docs.unity3d.com/ja/current/ScriptReference/Component.GetComponentInChildren.html


GetComponentInParent  :  GameObjectや深さ優先探索を活用して、親子関係にある親オブジェクトからtypeのタイプのコンポーネントを取得する
                         GameObjectでアクティブと判定された場合のみコンポーネントを返す
                         public Component GetComponentInParent (Type t)
                         
                         [パラメーター]
                         t   取得するコンポーネントの型

                         [戻り値]
                         Component   見つかった場合、型に一致したコンポーネントを返す
https://docs.unity3d.com/ja/current/ScriptReference/Component.GetComponentInParent.html


GetComponents  :  GameObjectからtypeのタイプのコンポーネントをすべて取得する
                  public Component[] GetComponents (Type type)
                  
                  [パラメーター]
                  type   取得するコンポーネントの型
https://docs.unity3d.com/ja/current/ScriptReference/Component.GetComponents.html


GetComponentsInChildren  :  GameObjectや深さ優先探索を活用して、親子関係にある子オブジェクトからtypeのタイプのコンポーネントをすべて取得する
                            public Component[] GetComponentsInChildren (Type t, bool includeInactive)

                            [パラメーター]
                            t                 取得するコンポーネントの型
                            includeInactive   非アクティブのコンポーネントも含めるかどうか
https://docs.unity3d.com/ja/current/ScriptReference/Component.GetComponentsInChildren.html


GetComponentsInParent  :  GameObjectや深さ優先探索を活用して、親子関係にある親オブジェクトからtypeのタイプのコンポーネントをすべて取得する
                          public Component[] GetComponentsInParent (Type t, bool includeInactive = false)
                          
                          [パラメーター]
                          t   取得するコンポーネントの型
                          includeInactive   非アクティブのコンポーネントも含めるかどうか
https://docs.unity3d.com/ja/current/ScriptReference/Component.GetComponentsInParent.html


SendMessage  :  ゲームオブジェクトにアタッチされているすべてのMonoBehaviourにあるmethodNameと名付けたメソッドを呼び出す
                このメッセージは非アクティブのオブジェクトには送信されないことに注意
                public void SendMessage (string methodName)
                public void SendMessage (string methodName, object value)
                public void SendMessage (string methodName, object value, SendMessageOptions options)
                public void SendMessage (string methodName, SendMessageOptions options)

                [パラメーター]
                methodName   呼び出すメソッド名
                value        呼び出すメソッドに引数として渡すパラメーター
                options      目的のオブジェクトにメソッドが実装されていない場合、エラーを発生させるかどうか
https://docs.unity3d.com/ja/current/ScriptReference/Component.SendMessage.html
<SendMessageOptions>
https://docs.unity3d.com/ja/current/ScriptReference/SendMessageOptions.html
<SendMessageOptions.RequireReceiver>
https://docs.unity3d.com/ja/current/ScriptReference/SendMessageOptions.RequireReceiver.html
<SendMessageOptions.DontRequireReceiver>
https://docs.unity3d.com/ja/current/ScriptReference/SendMessageOptions.DontRequireReceiver.html


SendMessageUpwards  :  ゲームオブジェクトと親（の親、さらに親 ... ）にアタッチされているすべてのMonoBehaviourにあるmethodNameと名付けたメソッドを呼び出す
                       このメッセージは非アクティブのオブジェクトには送信されないことに注意
                       public void SendMessageUpwards (string methodName, SendMessageOptions options)
                       public void SendMessageUpwards (string methodName, object value= null, SendMessageOptions options= SendMessageOptions.RequireReceiver)

                       [パラメーター]
                       methodName   呼び出すメソッド名
                       value        呼び出すメソッドに引数として渡すパラメーター
                       options      目的のオブジェクトにメソッドが存在しない場合、エラーを発生させるかどうか
https://docs.unity3d.com/ja/current/ScriptReference/Component.SendMessageUpwards.html


CancelInvoke  :  すべてのInvokeをキャンセルする
                 public void CancelInvoke ()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.CancelInvoke.html


Invoke  :  設定した時間（単位は秒）にメソッドを呼び出す
           public void Invoke (string methodName, float time)
           
           [パラメーター]
           methodName   呼び出すメソッド名
           time         呼び出す時間
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Invoke.html


InvokeRepeating  :  設定した時間（単位は秒）にメソッドを呼び出し、repeatRate秒ごとにリピートする
                    public void InvokeRepeating (string methodName, float time, float repeatRate)

                    [パラメーター]
                    methodName   呼び出すメソッド名
                    time         呼び出す時間
                    repeatRate   リピートする間隔の時間
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.InvokeRepeating.html


IsInvoking  :  メソッドの呼出が保留中かどうか
               public bool IsInvoking (string methodName)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.IsInvoking.html


StartCoroutine  :  コルーチンを開始する
                   コルーチンの実行は、yieldステートメントを使用していつでも一時停止できる
                   yieldステートメントが使用されるとコルーチンは実行を一時停止し次のフレームで自動的に再開する
                   Yieldingは、コルーチンの実行が完了するまで待機する
                   同じフレームで終了する場合でも、コルーチンが開始されたのと同じ順序で終了するという保証はない
                   public Coroutine StartCoroutine (IEnumerator routine)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.StartCoroutine.html
<Coroutine>
https://docs.unity3d.com/ja/current/ScriptReference/Coroutine.html


StopAllCoroutines  :  Behaviour上で実行されているコルーチンをすべて停止する
                      このアクションは、複数のコルーチンを実行するスクリプトで使用することができる
                      スクリプトのすべてのコルーチンが停止されるので、引数は必要ない
                      public void StopAllCoroutines ()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.StopAllCoroutines.html


StopCoroutine  :  このBehaviour上で実行されているmethodNameという名のコルーチン、またはroutineとして保持されているコルーチンをすべて停止する
                  public void StopCoroutine (string methodName)
                  public void StopCoroutine (IEnumerator routine)
                  public void StopCoroutine (Coroutine routine)
                  
                  [パラメーター]
                  methodName   ストップするメソッド名
                  routine      保持しているコルーチン(routine = WaitAndPrint(3.0f);とか)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.StopCoroutine.html


GetInstanceID  :  オブジェクトのインスタンスIDを返す
                  オブジェクトのインスタンスIDは、常にユニーク
                  public int GetInstanceID ()
https://docs.unity3d.com/ja/current/ScriptReference/Object.GetInstanceID.html


ToString  :  GameObjectの名前を返す
             public string ToString ()

             [戻り値]
             string   ToStringによって返される名前
https://docs.unity3d.com/ja/current/ScriptReference/Object.ToString.html


IsActive  :  GameObjectとComponentがアクティブになっている場合はtrueを返す
             public bool IsActive ()

             [戻り値]
             bool   アクティブの場合はtrue
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.UIBehaviour.IsActive.html


IsDestroyed  :  ネイティブ表示のBehaviourが破棄された場合はtrueを返す
                public bool IsDestroyed ()

                [戻り値]
                bool   破棄された場合はtrue
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.UIBehaviour.IsDestroyed.html
---

---
[protected関数]


Awake  :  スクリプトのインスタンスがロードされたときに呼び出される
          ゲームが開始する前に変数またはゲームの状態を初期化するために使用される
          スクリプトインスタンスの有効期間中に一度だけ呼び出される
          すべてのオブジェクトが初期化された後にAwakeが呼び出される
          各GameObjectのAwakeは、オブジェクト間でランダムな順序で呼び出される => Awakeを使用してスクリプト間の参照を設定し、Startを使用して情報をやり取りする必要がある 
          Awakeは常にStart関数の前に呼び出される => スクリプトの初期化を要求できる
          Awakeはコルーチンとして機能することはできない
          protected void Awake ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.UIBehaviour.Awake.html
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Awake.html


OnBeforeTransformParentChanged  :  こいつに関してはどんだけリファレンスとか探しても情報がなかった許して
                                   MonoBehaviour.OnBeforeTransformParentChangedに関する記述無し
                                   使い方だけ
                                   protected void OnBeforeTransformParentChanged ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.UIBehaviour.OnCanvasGroupChanged.html
<OnTransformParentChanged> <- 名前が似てるやつ
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTransformParentChanged.html


OnCanvasGroupChanged  :  こいつに関してはどんだけリファレンスとか探しても情報がなかった許して
                         MonoBehaviour.OnCanvasGroupChangedに関する記述無し
                         使い方だけ
                         protected void OnCanvasGroupChanged ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.UIBehaviour.OnCanvasGroupChanged.html


OnCanvasHierarchyChanged  :  親のCanvasの状態が変更されたとき呼び出される
                             親のCanvasが有効、無効、ネストされたCanvasのOverrideSortingが変更されたときに、この関数が呼び出される
                             protected void OnCanvasHierarchyChanged ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.UIBehaviour.OnCanvasHierarchyChanged.html


OnDestroy  :  アタッチされたBehaviorを破棄すると、ゲームまたはシーンがOnDestroyを受け取る
              シーンまたはゲームの終了時に発生する
              エディター内から実行中に再生モードを停止すると、アプリケーションが終了する
              この終了が発生すると、OnDestroyが実行される
              また、シーンが閉じて新しいシーンが読み込まれると、OnDestroy呼び出しが行われる
              スタンドアロンアプリケーションとして構築した場合、シーンの終了時にOnDestroy呼び出しが行われる
              シーンの終了は通常、新しいシーンが読み込まれることを意味する
              注  :  OnDestroyは、以前にアクティブであったゲームオブジェクトでのみ呼び出される
              protected void OnDestroy ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.UIBehaviour.OnDestroy.html
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnDestroy.html


OnDidApplyAnimationProperties  :  プロパティーがアニメーションによる変更が行われたときのコールバック
                                  protected void OnDidApplyAnimationProperties ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.UIBehaviour.OnDidApplyAnimationProperties.html
https://docs.unity3d.com/ja/current/ScriptReference/UI.LayoutGroup.OnDidApplyAnimationProperties.html


OnRectTransformDimensionsChange  :  このコールバックは、関連付けられたRectTransformの寸法が変更された場合に呼び出される
                                    呼び出しは、子トランスフォーム自体が変更されない場合でも、すべての子rect(Rect構造体?)トランスフォームに対して行われる
                                    protected void OnRectTransformDimensionsChange ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.UIBehaviour.OnRectTransformDimensionsChange.html
<RectTransform>
https://docs.unity3d.com/ja/current/ScriptReference/RectTransform.html


OnTransformParentChanged  :  この関数はGameObjectのTransformのparentプロパティーに変更があったときに呼び出される
                             MonoBehaviour.OnRectTransformParentChangedに関する記述無し
                             protected void OnTransformParentChanged ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.UIBehaviour.OnTransformParentChanged.html
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTransformParentChanged.html


OnValidate  :  この関数はスクリプトがロードされた時やインスペクターの値が変更されたときに呼び出される（呼出しはエディター上のみ）
               この関数を使用して、MonoBehavioursのデータを検証する
               エディターでデータを変更するときに、データが特定の範囲内に留まるようにすることができる
               protected void OnValidate ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.UIBehaviour.OnValidate.html
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnValidate.html


Reset  :  デフォルト値にリセットする
          ResetはインスペクターのコンテキストメニューにあるResetボタンやコンポーネントを初めて追加するときに呼び出される
          エディターモードのみで呼び出される
          Resetはインスペクターでデフォルト値を設定するときに使用される
          protected void Reset ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.UIBehaviour.Reset.html
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Reset.html


Start  :  StartはUpdateメソッドが初めて呼び出される直前にスクリプトが有効になったときに、フレームで呼び出される
          Awake関数と同様にStartはスクリプトの有効期間中に1回だけ呼び出される
          ただし、スクリプトが有効化されているかどうかに関係なく、スクリプトオブジェクトが初期化されるとAwakeが呼び出される
          スクリプトが初期化時に有効になっていない場合、Awakeと同じフレームでStartが呼び出されない場合がある
          Awake任意のオブジェクトのStart関数が呼び出される前に関数がシーン内のすべてのオブジェクトで呼び出される
          protected void Start ()
https://docs.unity3d.com/ja/current/ScriptReference/EventSystems.UIBehaviour.Start.html
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Start.html
---

---
[Static関数]


print  :  Unity コンソールにログを出力する (Debug.Log 同じ)
          public static void print (object message)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour-print.html
<Debug.Log>
https://docs.unity3d.com/ja/current/ScriptReference/Debug.Log.html
<Debug.LogWarning>
https://docs.unity3d.com/ja/current/ScriptReference/Debug.LogWarning.html
<Debug.LogError>
https://docs.unity3d.com/ja/current/ScriptReference/Debug.LogError.html


Destroy  :  ゲームオブジェクトやコンポーネント、アセットを削除する
            t秒後にオブジェクトのobjを破壊する
            objはComponentの場合、GameObjectからコンポーネントを削除し、破壊する
            objがGameObjectの場合、GameObjectならびにすべてのコンポーネント、GameObjectの子であるすべてのオブジェクトを破壊する
            オブジェクトの破壊は、現在のフレームのアップデート（Update）処理後に行われますが、常にレンダリング前に実行される
            public static void Destroy (Object obj, float t= 0.0F)

            [パラメーター]
            obj   破壊するオブジェクト
            t     オブジェクトを破壊するまでのディレイ時間
https://docs.unity3d.com/ja/current/ScriptReference/Object.Destroy.html


DestroyImmediate  :  オブジェクトをobjすぐに破棄する。
                     代わりにDestroyを使用する方がよい。というかこっちは使う必要でない限り極力使わない方がいい。
                     遅延破棄は編集モードでは呼び出されないので、この関数はエディターコードを記述する場合以外で使用してはいけない
                     ゲームコードでは、代わりにObject.Destroyを使用する必要がある
                     破棄は常に遅延する（ただし、同じフレーム内で実行される）
                     この機能はObjectを永久に破壊する可能性がある
                     また、配列を繰り返し処理したり繰り返し処理している要素を破棄していけない
                     public static void DestroyImmediate (Object obj, bool allowDestroyingAssets = false)

                     [パラメーター]
                     obj                     破壊されるオブジェクト
                     allowDestroyingAssets   アセットを破棄できるようにするには、trueに設定
https://docs.unity3d.com/ja/current/ScriptReference/Object.DestroyImmediate.html
<Object.Destroy>
https://docs.unity3d.com/ja/current/ScriptReference/Object.Destroy.html


DontDestroyOnLoad  :  新しいシーンをロードするときにターゲットオブジェクトを破棄したくないときに使用
                      新しいシーンをロードすると、現在のシーンオブジェクトがすべて破棄される
                      Object.DontDestroyOnLoadを呼び出して、レベルの読み込み中にオブジェクトを保持する
                      ターゲットオブジェクトがコンポーネントまたはGameObjectの場合、UnityはTransformの子もすべて保持する
                      Object.DontDestroyOnLoadは値を返さない
                      typeof演算子を使用して引数のタイプを変更する
                      public static void DontDestroyOnLoad (Object target)
                      
                      [パラメーター]
                      target   シーンの変更時に破壊されないようにするオブジェクト
https://docs.unity3d.com/ja/current/ScriptReference/Object.DontDestroyOnLoad.html


FindObjectOfType  :  タイプtypeから最初に見つけたアクティブのオブジェクトを返す
                     アセット（メッシュ、テクスチャ、プレハブなど）または非アクティブなオブジェクトを返さない
                     GameObjectを見つけるために使用される
                     HideFlags.DontSaveが設定されているオブジェクトは返さない
                     Object.FindObjectOfTypeを呼び出し、型に一致するオブジェクトを返す
                     型に一致するオブジェクトがない場合はnullを返す
                     この機能は非常に遅い => この関数をフレームごとに使用することは非推奨
                     public static Object FindObjectOfType (Type type)

                     [パラメーター]
                     type   見つけるオブジェクトの型

                     [戻り値]
                     Object   指定されたタイプと一致するオブジェクトを返す
                              タイプに一致するオブジェクトがない場合は、nullを返す
https://docs.unity3d.com/ja/current/ScriptReference/Object.FindObjectOfType.html


FindObjectsOfType  :  タイプtypeから見つかったすべてのアクティブのオブジェクトを返す
                      アセット（メッシュ、テクスチャ、プレハブなど）または非アクティブなオブジェクトを返さない
                      非アクティブなオブジェクトなどを含めたい場合はFindObjectsOfTypeAllを使用する
                      GameObjectを見つけるために使用される
                      HideFlags.DontSaveが設定されているオブジェクトは返さない
                      Object.FindObjectsOfTypeを呼び出し、型に一致するオブジェクトを返す
                      型に一致するオブジェクトがない場合はnullを返す
                      この機能は非常に遅い => この関数をフレームごとに使用することは非推奨
                      public static Object[] FindObjectsOfType (Type type)

                      [パラメーター]
                      type   見つけるオブジェクトの型

                      [戻り値]
                      Object[]   指定した型で見つかったオブジェクトの配列を返す
https://docs.unity3d.com/ja/current/ScriptReference/Object.FindObjectsOfType.html
<Resources.FindObjectsOfTypeAll>
https://docs.unity3d.com/ja/current/ScriptReference/Resources.FindObjectsOfTypeAll.html


Instantiate  :  originalのオブジェクトをクローンする
                この関数は、エディターの複製コマンド(CTRL + D)と同様の方法でオブジェクトのコピーを作成する
                GameObjectのクローンを作成する場合は、オプションでその位置と回転を指定することができる（これらはデフォルトでは元のGameObjectの位置と回転）
                コンポーネントのクローンを作成している場合は、それが接続されているGameObjectもクローンされる
                GameObjectまたはComponentのクローンを作成すると、すべての子オブジェクトとコンポーネントも、元のオブジェクトのプロパティと同様にプロパティが設定されてクローンされる
                新しいオブジェクトのnullはnullになるため、元のオブジェクトの兄弟にはならない
                ただし、オーバーロードされたメソッドを使用して親を設定することはできる
                親が指定され、位置と回転が指定されていない場合、クローンのオブジェクトのローカルの位置と回転、またはinstantiateInWorldSpaceパラメーターがtrueの場合はそのワールドの位置と回転に、元の位置と回転が使用されます。
                位置と回転が指定されている場合、それらはワールドスペースでのオブジェクトの位置と回転として使用されます。
                クローン作成時のGameObjectのアクティブステータスが渡されるため、オリジナルが非アクティブの場合、クローンも非アクティブな状態で作成されます。
                public static Object Instantiate (Object original)
                public static Object Instantiate (Object original, Transform parent)
                public static Object Instantiate (Object original, Transform parent, bool instantiateInWorldSpace)
                public static Object Instantiate (Object original, Vector3 position, Quaternion rotation)
                public static Object Instantiate (Object original, Vector3 position, Quaternion rotation, Transform parent)

                [パラメーター]
                original                  コピーしたい既存オブジェクト
                position                  新しいオブジェクトの位置
                rotation                  新しいオブジェクトの向き
                parent                    新しいオブジェクトに割り当てられる親
                instantiateInWorldSpace   ture  => 新しい親に相対的な位置を設定するのではなく、オブジェクトのワールド位置を維持するために親オブジェクトを割り当てる
                                          false => 新しい親を基準にしてオブジェクトの位置を設定

                [戻り値]
                Object   インスタンス化されたクローン
https://docs.unity3d.com/ja/current/ScriptReference/Object.Instantiate.html
---

---
[Operator]


bool  :  オブジェクトが存在するかどうか
https://docs.unity3d.com/ja/current/ScriptReference/Object-operator_Object.html


operator !=  :  二つのオブジェクトが異なるオブジェクトを参照しているか比較する(つまりだたの !=)
                public static bool operator != (Object x, Object y);

                [パラメーター]
                x   最初のオブジェクト
                y   比較対象のオブジェクト
https://docs.unity3d.com/ja/current/ScriptReference/Object-operator_ne.html


operator ==  :  2つのオブジェクト参照が同じオブジェクトを参照しているか比較する(つまりただの ==)
                public static bool operator == (Object x, Object y);

                [パラメーター]
                x   最初のオブジェクト
                y   比較対象のオブジェクト
https://docs.unity3d.com/ja/current/ScriptReference/Object-operator_eq.html
---

---
[メッセージ]


Awake  :  スクリプトのインスタンスがロードされたときに呼び出される
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Awake.html


FixedUpdate  :  物理計算のためのフレームレートに依存しないMonoBehaviour.FixedUpdateメッセージ
                MonoBehaviour.FixedUpdateには、物理システムの頻度がある => すべての固定フレームレートフレームと呼ばれる
                計算物理学の後のシステムの計算
                0.02秒（50コール/秒）が、コール間のデフォルトの時間 => この値にアクセスするには、Time.fixedDeltaTimeを使用
                スクリプト内で適切な値に設定して変更するか、Edit > Settings > Time > Fixed Timestepそこに移動して設定する
                Application.targetFrameRateを使用してフレームレートを設定する
                Rigidbodyを使用する場合はFixedUpdateを使用する必要がある
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.FixedUpdate.html
<Update>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Update.html
<Physics>
https://docs.unity3d.com/ja/current/ScriptReference/Physics.html
<Time.fixedDeltaTime>
https://docs.unity3d.com/ja/current/ScriptReference/Time-fixedDeltaTime.html
<Application.targetFrameRate>
https://docs.unity3d.com/ja/current/ScriptReference/Application-targetFrameRate.html
<Rigidbody>
https://docs.unity3d.com/ja/current/ScriptReference/Rigidbody.html


LateUpdate  :  Behaviourが有効の場合LateUpdateは毎フレーム呼びだされる
               LateUpdateはUpdate関数が呼び出された後に実行される
               これはスクリプトの実行順を決める時に使用できる
               例えばカメラを追従するにはUpdateで移動された結果を基に常にLateUpdateで位置を更新する必要がある
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.LateUpdate.html


OnAnimatorIK  :  アニメーションIK（インバースキネマティクス）をセットアップするときのコールバック
                 OnAnimatorIK() はAnimatorコンポーネントが内部IKシステムを更新する直前により呼び出される
                 このコールバックはIKGoalのポジションおよび関連するWeight（重み付け) を設定するために使用することができる
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnAnimatorIK.html


OnAnimatorMove  :  ルートモーションを修正するアニメーション動作を処理するコールバック
                   このコールバックは、ステートマシンとアニメーションが評価された後、OnAnimatorIKの前に各フレームで呼び出される
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnAnimatorMove.html
<MonoBehaviour.OnAnimatorIK(int)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnAnimatorIK.html


OnApplicationFocus  :  bool値
                       プレイヤーがフォーカスを取得、または、失ったときに、すべてのゲームオブジェクトに送信される
                       OnApplicationFocusはアプリケーションがフォーカスを失ったとき、またはフォーカスを取得したときに呼び出される
                       Alt-tabbingまたはCmd-tabbingは、Unityアプリケーションから別のデスクトップアプリケーションにフォーカスを移すことができる
                       これにより、GameObject は引数がfalseに設定されたOnApplicationFocus呼び出しを受け取る
                       ユーザーがUnityアプリケーションに戻ると、GameObjects は引数がtrueに設定されたOnApplicationFocus呼び出しを受け取ります。
                       OnApplicationFocusはコルーチンにできる => 関数でyieldステートメントを使用する
                       この方法で実装され、最初のフレーム中に2回評価される => 1つ目は早期通知、2つ目は通常のコルーチン更新ステップ中に評価される
                       Androidでは、スクリーンキーボードが有効になっていると、OnApplicationFocus（false）イベントが発生する
                       さらに、キーボードが有効になっているときにHomeを押すと、OnApplicationFocus（）イベントは呼び出されず、代わりにOnApplicationPause（）が呼び出される
                       MonoBehaviour.OnApplicationFocus (hasFocus)

                       [パラメーター]
                       hasFocus   true  :  ゲームオブジェクトにフォーカスがあるとき
                                  false :  ゲームオブジェクトにフォーカスがないとき
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnApplicationFocus.html


OnApplicationPause  :  bool値
                       プレイヤーが一時停止したときにすべてのゲームオブジェクトに送信される
                       OnApplicationPauseはtrueまたはfalseに設定される
                       通常、OnApplicationPauseメッセージによって返される値はfalse => ゲームがエディターで正常に実行されていることを意味する
                       インスペクターなどのエディターウィンドウが選択されている場合、ゲームは一時停止され、OnApplicationPauseはtrueを返す
                       ゲームウィンドウが選択され、アクティブなOnApplicationPauseが再びfalseを返す場合 => trueは、ゲームがアクティブでないことを意味する(ここ誤訳してるかも)
                       参照) Player Settings...のResolutionとPresentation、Run in BackgroundとVisible in Backgroundの解除
                       OnApplicationPauseエディターとは別に実行される独立したゲームで使用できる
                       実行中のゲームはウィンドウ表示され、全画面よりも小さい必要がある
                       ゲームが別のアプリケーションによって（完全にまたは部分的に）非表示になっている場合、OnApplicationPauseはtrueを返す
                       ゲームが現在の状態に戻ると、一時停止されなくなり、 OnApplicationPauseがfalseに戻る
                       OnApplicationPauseコルーチンにすることができる => 関数でyieldステートメントを使用する
                       この方法で実装され、最初のフレーム中に2回評価される => 1つは早期通知として、2つ目は通常のコルーチン更新ステップ中に評価される
                       Androidでは、スクリーンキーボードが有効になっていると、OnApplicationFocus（false）イベントが発生する
                       また、キーボードが有効になっているときに「Home」を押すと、OnApplicationFocus（）イベントは呼び出されず、代わりにOnApplicationPause（）が呼び出される
                       注： MonoBehaviour.OnApplicationPauseは、ゲームオブジェクトの開始時に呼び出される
                            呼び出しはAwakeの後に行われる
                            各GameObjectにより、この呼び出しが行われる
                       MonoBehaviour.OnApplicationPause (pauseStatus)

                       [パラメーター]
                       pauseStatus   true  :  アプリケーションが起動している
                                     false :  アプリケーションが起動していない
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnApplicationPause.html


OnApplicationQuit  :  アプリケーションが終了する前に、すべてのゲームオブジェクトに送信される
                      エディターでは、ユーザーが再生モードを停止したときに呼び出される
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnApplicationQuit.html


OnAudioFilterRead  :  OnAudioFilterReadが実装されている場合、UnityはDSPチェーンにカスタムフィルターを挿入する
                      フィルターは、MonoBehaviourスクリプトがインスペクターに表示されるのと同じ順序で挿入される
                      OnAudioFilterReadは、オーディオのチャンクがフィルターに送信されるたびに呼び出されます（これは、サンプルレートとプラットフォームに応じて、20msごとの頻度で発生する）
                      オーディオデータは[-1.0f、1.0F】の範囲の浮動小数点数のアレイであり、チェーン内の前のフィルタ又はAudioClipのAudioSourceからなる
                      これがチェーンの最初のフィルターであり、クリップがオーディオソースに接続されていない場合、このフィルターはオーディオソースとして再生される
                      このようにして、フィルターをオーディオクリップとして使用し、手続き的にオーディオを生成できる
                      複数のチャネルがある場合、チャネルデータはインターリーブされる
                      つまり、配列内の連続する各データサンプルは、チャネルが不足して最初のループに戻るまで、異なるチャネルから取得される
                      data.Lengthはデータの合計サイズを報告する => チャンネルあたりのサンプル数を見つけるには、data.Lengthをchannelsで割る
                      OnAudioFilterReadが実装されている場合、VUメーターがインスペクターに表示され、出力サンプルレベルを表示する
                      フィルターの処理時間も測定され、費やされたミリ秒がVUメーターの横に表示される
                      フィルターの処理に時間がかかりすぎると、数値が赤(警告)に変わる
                      また、OnAudioFilterReadはメインスレッド（つまりオーディオスレッド）とは別のスレッドで呼び出されるため、この関数からは多くのUnity関数を呼び出すことができない（実行しようとすると、実行時に警告が表示される）
                      MonoBehaviour.OnAudioFilterRead(data[], channels)

                      [パラメーター]
                      data       オーディオデータを持つ   float配列
                      channels   デリゲートに渡されたオーディオデータのチャネルの数を格納する   int型  
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnAudioFilterRead.html
<AudioClip>
https://docs.unity3d.com/ja/current/ScriptReference/AudioClip.html
<AudioSource>
https://docs.unity3d.com/ja/current/ScriptReference/AudioSource.html
<Audio Filter>
https://docs.unity3d.com/ja/current/Manual/class-AudioEffect.html


OnBecameInvisible  :  レンダラーがカメラから見えなくなったときに呼び出される
                      このメッセージは、レンダラーに接続されているすべてのスクリプトに送信される
                      OnBecameVisibleおよびOnBecameInvisibleは、オブジェクトが表示されている場合にのみ必要な計算を回避する事ができる
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnBecameInvisible.html
<MonoBehaviour.OnBecameVisible()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnBecameVisible.html
<MonoBehaviour.OnBecameInvisible()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnBecameInvisible.html


OnBecameVisible  :  レンダラーが任意のカメラから見えるようになると呼び出されます
                    このメッセージは、レンダラーに接続されているすべてのスクリプトに送信される
                    OnBecameVisibleおよびOnBecameInvisibleは、オブジェクトが表示されている場合にのみ必要な計算を回避することができる
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnBecameVisible.html
<MonoBehaviour.OnBecameVisible()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnBecameVisible.html
<MonoBehaviour.OnBecameInvisible()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnBecameInvisible.html


OnCollisionEnter  :  このcollider/rigidbodyは他のcollider/rigidbodyに触れたときにOnCollisionEnterは呼び出される
                     OnTriggerEnterのコントラストに応じてOnCollisionEnterはCollision classでなくColliderを渡す
                     Collision classは衝撃(impact)、速度(velocity)etc.に関する情報を含んでいる
                     もしcollisionInfoの機能を使わないならクラスは、接点、衝突速度などに関する情報が含まれている
                     注：Collisionイベントは、Colliderの1つに非キネマティックリジッドボディも接続されている場合にのみ送信される
                     Collisionイベントは無効化されたMonoBehavioursに送信され、Colliderに応答して動作を有効化できるようにする
                     MonoBehaviour.OnCollisionEnter(Collision)

                     [パラメーター]
                     other   このCollisionに関連付けられているCollisionデータ
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionEnter.html
<Collider>
https://docs.unity3d.com/ja/current/ScriptReference/Collider.html
<Collision>
https://docs.unity3d.com/ja/current/ScriptReference/Collision.html


OnCollisionEnter2D  :  オブジェクトのコライダーが別のコライダーに衝突したときに呼び出される（2D 物理挙動のみ）
                       衝突に関する詳細情報は、呼び出し中に渡されるCollision2Dパラメーターで報告される
                       この情報が必要ない場合は、パラメーターなしでOnCollisionEnter2Dを宣言できる
                       MonoBehaviour.OnCollisionEnter2D(Collision2D)

                       [パラメーター]
                       other   この衝突に関係のあるCollision2Dデータ
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionEnter2D.html
<Collision2D>
https://docs.unity3d.com/ja/current/ScriptReference/Collision2D.html
<MonoBehaviour.OnCollisionExit2D(Collision2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionExit2D.html
<MonoBehaviour.OnCollisionStay2D(Collision2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionStay2D.html


OnCollisionExit  :  Colliderがotherのトリガーに触れるのをやめたときに呼び出される
                    このメッセージは、トリガーとトリガーに触れるColliderに送信される
                    注：1つにもリジッドボディがアタッチされている場合にのみ、トリガーイベントが送信される
                        トリガーイベントは無効化されたMonoBehavioursに送信され、衝突に対応して動作を有効化できるようにする
                    MonoBehaviour.OnTriggerExit(Collider)

                    [パラメーター]
                    other   この衝突に含まれるその他のCollider
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerExit.html


OnCollisionExit2D  :  オブジェクトのコライダーと別のオブジェクトコライダーが衝突から離れた瞬間に呼び出される（2D 物理挙動のみ）
                      衝突についての詳しい情報は、呼び出されるときにパラメーターとして取得できるCollision2Dで取得することができる
                      この情報が必要ない場合はパラメーターなしのOnCollisionExit2Dを使用することができる
                      MonoBehaviour.OnCollisionExit2D(Collision2D)

                      [パラメーター]
                      other   この衝突に関係のあるCollision2Dデータ
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionExit2D.html
<Collision2D>
https://docs.unity3d.com/ja/current/ScriptReference/Collision2D.html
<MonoBehaviour.OnCollisionExit2D(Collision2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionExit2D.html
<MonoBehaviour.OnCollisionStay2D(Collision2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionStay2D.html


OnCollisionStay  :  OnCollisionStayは、collider/rigidbodyに接触しているすべてのcollider/rigidbodyについて、フレームごとに1回呼び出される
                    OnTriggerStayとは対照的に、OnCollisionStayにはColliderではなくCollisionクラスが渡される
                    Collision classは衝撃(impact)、速度(velocity)etc.に関する情報を含んでいる
                    もしcollisionInfoの機能を使わないならクラスは、接点、衝突速度などに関する情報が含まれている
                    注：衝突イベントは、コライダーの1つに非キネマティックリジッドボディも接続されている場合にのみ送信される
                    衝突イベントは無効化されたMonoBehavioursに送信され、衝突に応答して動作を有効化できるようにする
                    OnCollisionStayイベントは、スリープ中のrigidbodyには送信されない
                    MonoBehaviour.OnCollisionStay(Collision)

                    [パラメーター]
                    other   衝突と関連するCollisionデータ
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionStay.html
<Collider>
https://docs.unity3d.com/ja/current/ScriptReference/Collider.html
<Collision>
https://docs.unity3d.com/ja/current/ScriptReference/Collision.html


OnCollisionStay2D  :  オブジェクトのコライダーと別のオブジェクトのコライダーが衝突している間、毎フレーム呼び出され続ける（2D 物理挙動のみ）
                      衝突についての詳しい情報は、呼び出されるときにパラメーターとして取得できるCollision2Dで取得することができる
                      この情報が必要ない場合はパラメーターなしのOnCollisionStay2Dを使用することができる
                      MonoBehaviour.OnCollisionStay2D(Collision2D)

                      [パラメーター]
                      other   この衝突に関係のあるCollision2Dデータ
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionStay2D.html
<Collision2D>
https://docs.unity3d.com/ja/current/ScriptReference/Collision2D.html
<MonoBehaviour.OnCollisionExit2D(Collision2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionExit2D.html
<MonoBehaviour.OnCollisionEnter2D(Collision2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionEnter2D.html


OnConnectedToServer  :  サーバーとの接続に成功したときにクライアント上で呼び出されます
                        MonoBehaviour.OnControllerColliderHit(ControllerColliderHit)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnConnectedToServer.html


OnControllerColliderHit  :  OnControllerColliderHitはキャラクターコントローラーが移動中にコライダーに衝突した際に、呼び出される
                            これはキャラクターと衝突したときにオブジェクトを押すのに使用することができる
                            MonoBehaviour.OnControllerColliderHit(ControllerColliderHit)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnControllerColliderHit.html


OnDestroy  :  アタッチされたBehaviorを破棄すると、ゲームまたはシーンがOnDestroyを受け取る
              OnDestroyは、シーンまたはゲームの終了時に発生する
              エディター内から実行中に再生モードを停止すると、アプリケーションが終了する
              この終了が発生すると、OnDestroyが実行される
              シーンが閉じて新しいシーンが読み込まれると、OnDestroy呼び出しが行われる
              スタンドアロンアプリケーションとして構築した場合、シーンの終了時にOnDestroy呼び出しが行われる
              シーンの終了は通常、新しいシーンが読み込まれることを意味する
              MonoBehaviour.OnDestroy()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnDestroy.html


OnDisconnectedFromServer  :  サーバーとの接続が失われたか切断されたときにクライアント上で呼びされる
                             MonoBehaviour.OnDisconnectedFromServer(NetworkDisconnection)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnDisconnectedFromServer.html


OnDrawGizmos  :  選択可能にしたり、常に描画したいギズモを描画するにはOnDrawGizmosを使用する
                 OnDrawGizmosはシーンビューから相対的なマウス位置を使用することに注意
                 この関数はインスペクター上でコンポーネントが折りたたまれている場合、「ない」を取得して呼び出されない
                 ゲームオブジェクトを選択するとき、ギズモを描画するのにOnDrawGizmosSelectedを利用する
                 MonoBehaviour.OnDrawGizmos()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnDrawGizmos.html
<MonoBehaviour.OnDrawGizmosSelected()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnDrawGizmosSelected.html


OnDrawGizmosSelected  :  オブジェクトが選択されている場合は、ギズモを描画するためにOnDrawGizmosSelectedを実装する
                         Gizmosはオブジェクトを選択している時のみ描画される
                         ギズモは選択可能ではない
                         これはセットアップを簡単に実行するために使用される
                         MonoBehaviour.OnDrawGizmosSelected()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnDrawGizmosSelected.html
<Gizmos>
https://docs.unity3d.com/ja/current/ScriptReference/Gizmos.html


OnFailedToConnect  :  接続試行がなんらかの理由で失敗したときにクライアント上で呼び出される
                      失敗した理由はNetworkConnectionErrorとして取得できる
                      MonoBehaviour.OnFailedToConnect(NetworkConnectionError)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnFailedToConnect.html


OnFailedToConnectToMasterServer  :  MasterServer への接続に問題がある場合に、クライアントまたはサーバーで呼び出される
                                    エラーの理由はNetworkConnectionErrorとして取得できる
                                    MonoBehaviour.OnFailedToConnectToMasterServer(NetworkConnectionError)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnFailedToConnectToMasterServer.html


OnGUI  :  OnGUI はレンダリングと GUI イベントのハンドリングのために呼び出される
          OnGUIを実装した際には毎フレーム複数回（イベントごとに1回）呼び出されることを意味する
          MonoBehaviourのenabledプロパティーをfalseにした場合、OnGUI()が呼び出されることはない
          MonoBehaviour.OnGUI()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnGUI.html
<Event>
https://docs.unity3d.com/ja/current/ScriptReference/Event.html


OnJointBreak  :  ゲームオブジェクトに対するジョイントが外れたとき呼び出される
                 ジョイントのbreakForceよりも大きな力がかかると、ジョイントは壊れる
                 ジョイントが壊れると、OnJointBreakが呼び出され、ジョイントに適用されたブレークフォースが渡される
                 OnJointBreakの後で、ジョイントはゲームオブジェクトから自動的に削除され、削除される
                 MonoBehaviour.OnJointBreak(float)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnJointBreak.html


OnJointBreak2D  :  ゲームオブジェクトにアタッチした Joint2D が壊れたときに呼び出される
                   Joint2D.reactionForceがJoint2D.breakForceより高いまたはJoint2D.reactionTorqueがJoint2D.breakTorqueのジョイントより高いときジョイントは破損する
                   ジョイントが壊れると、OnJointBreak2Dが呼び出され、壊れた特定のJoint2Dが渡される
                   OnJointBreak2Dが呼び出された後、ジョイントはゲームオブジェクトから自動的に削除される
                   MonoBehaviour .OnJointBreak2D（Joint2D）
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnJointBreak2D.html
<Joint2D.breakForce>
https://docs.unity3d.com/ja/current/ScriptReference/Joint2D-breakForce.html
<Joint2D.breakTorque>
https://docs.unity3d.com/ja/current/ScriptReference/Joint2D-breakTorque.html
<Joint2D.reactionForce>
https://docs.unity3d.com/ja/current/ScriptReference/Joint2D-reactionForce.html
<Joint2D.reactionTorque>
https://docs.unity3d.com/ja/current/ScriptReference/Joint2D-reactionTorque.html


OnMasterServerEvent  :  MasterServer からイベントを報告してくるときにクライアントやサーバー上で呼び出される
                        例えば、ホストのリストを受信したり、ホストの登録が成功したとき
                        MonoBehaviour.OnMasterServerEvent(MasterServerEvent)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMasterServerEvent.html


OnMouseDown  :  OnMouseDownは、ユーザーがGUIElementまたはCollider上でマウスボタンを押したときに呼び出される
                このイベントはColliderまたはGUIElementにアタッチされているすべてのスクリプトに送信される
                MonoBehaviour .OnMouseDown（）
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseDown.html
<GUIElement>
https://docs.unity3d.com/ja/current/ScriptReference/GUIElement.html
<Collider>
https://docs.unity3d.com/ja/current/ScriptReference/Collider.html


OnMouseDrag  :  ユーザーがGUIElementまたはColliderをマウスでクリックし、ドラッグしている間呼び出される
                OnMouseDragはマウスを押している間、毎フレーム呼び出される
                MonoBehaviour.OnMouseDrag()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseDrag.html


OnMouseEnter  :  GUIElementまたはCollider上にマウスが乗ったときに呼び出される
                 オブジェクトの上にマウスが重なっている間、対応する.OnMouseOver関数が呼び出され、マウスがオブジェクトから離れたとき、OnMouseExit関数が呼び出される
                 MonoBehaviour.OnMouseEnter()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseEnter.html
<MonoBehaviour.OnMouseExit()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseExit.html


OnMouseExit  :  GUIElementまたはCollider上からマウス離れたときに呼び出される
                OnMouseExitの呼び出しは、OnMouseEnterとOnMouseOver に対応する呼び出しの後に続く
                この関数はレイヤーが「Ignore Raycast」のゲームオブジェクトでは呼び出されない
                MonoBehaviour.OnMouseExit()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseExit.html
<MonoBehaviour.OnMouseOver()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseOver.html
<Physics.queriesHitTriggers>
https://docs.unity3d.com/ja/current/ScriptReference/Physics-queriesHitTriggers.html


OnMouseOver  :  GUIElementまたはCollider上にマウスがあり続ける限り毎フレーム呼び出され続ける
                OnMouseEnterの呼び出しは、マウスがオブジェクト上にある最初のフレームで発生する
                その後、マウスが離れるまでOnMouseOverがフレームごとに呼び出され、その時点でOnMouseExitが呼び出される
                この関数はレイヤーが「Ignore Raycast」のゲームオブジェクトでは呼び出されない
                この関数はレイヤーが「Ignore Raycast」のゲームオブジェクトではトリガーされない
                Physics.queriesHitTriggersはtrue
                OnMouseOverはコルーチンにできる => 関数でyieldステートメントを使用する
                このイベントは、コライダーまたはGUIElementに接続されているすべてのスクリプトに送信される
                MonoBehaviour.OnMouseOver()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseOver.html


OnMouseUp  :  OnMouseUpはユーザーがマウスボタンを離したときに呼び出される
              OnMouseUpはマウスを押した時と同じGUIElementやCollider上にない場合でも呼び出されることに注意
              MonoBehaviour.OnMouseUp()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseUp.html
<MonoBehaviour.OnMouseUpAsButton()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseUpAsButton.html


OnMouseUpAsButton  :  マウスを押した時と同じGUIElementやCollider上でマウスを離した時のみに呼び出される
                      MonoBehaviour.OnMouseUpAsButton()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseUpAsButton.html
<MonoBehaviour.OnMouseUp()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseUp.html


OnNetworkInstantiate  :  Network.Instantiateでインスタンス化されたオブジェクトに対して呼び出される
                         こインスタンス化されたオブジェクトのコンポーネントを無効または有効にすることができる
                         それらの動作は、ローカルに所有されているかリモートに所有されているかによって異なる
                         MonoBehaviour.OnNetworkInstantiate(NetworkMessageInfo)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnNetworkInstantiate.html


OnParticleCollision  :  パーティクルがコライダーにヒットしたときにOnParticleCollisionが呼び出される
                        パーティクルがヒットしたときにゲームオブジェクトにダメージを適用させるために使用することができる
                        このメッセージはパーティクルシステムにアタッチされたスクリプトとヒットしたColliderに対して送信される
                        インスペクターにあるParticle System CollisionモジュールのSend Collision Messagesを有効にした場合のみ、メッセージは送信される
                        OnParticleCollisionは関数の中にシンプルなyield文を使用して、コルーチンにすることができる
                        MonoBehaviour.OnParticleCollision(GameObject)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnParticleCollision.html
<ParticlePhysicsExtensions.GetCollisionEvents>
https://docs.unity3d.com/ja/current/ScriptReference/ParticlePhysicsExtensions.GetCollisionEvents.html
<ParticleSystem>
https://docs.unity3d.com/ja/current/ScriptReference/ParticleSystem.html


OnParticleSystemStopped  :  システム内のすべてのパーティクルが消滅し、新しいパーティクルが発生しないときに呼び出される
                            新しいパーティクルは、Stopが呼び出された後、または非ループシステムの継続時間プロパティを超えたときに作成されなくなる
                            これは、パーティクルシステムが終了したことをスクリプトに通知するために使用できる
                            コールバックを受信するには、ParticleSystem.MainModule.stopActionプロパティをCallbackに設定する必要がある
                            MonoBehaviour.OnParticleSystemStopped()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnParticleSystemStopped.html
<ParticleSystem.MainModule.stopAction>
https://docs.unity3d.com/ja/current/ScriptReference/ParticleSystem.MainModule-stopAction.html


OnParticleTrigger  :  パーティクルシステムのパーティクルがトリガーモジュールの条件を満たすときに呼び出される
                      これは、衝突範囲の内側か外側にあるパーティクルを削除、または、修正するために使用される
                      MonoBehaviour.OnParticleTrigger（）
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnParticleTrigger.html


OnPlayerConnected  :  新しいプレイヤーが接続に成功したときにサーバー上で呼び出される
                      MonoBehaviour.OnPlayerConnected(NetworkPlayer)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnPlayerConnected.html


OnPlayerDisconnected  :  プレイヤーがサーバーから接続が切断されるたびにサーバー上で呼び出される
                         MonoBehaviour.OnPlayerDisconnected(NetworkPlayer)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnPlayerDisconnected.html


OnPostRender  :  カメラがシーンのレンダリングを完了した後に呼び出される
                 この関数は、スクリプトがカメラにアタッチされ、有効になっている場合にのみ呼び出される
                 OnPostRenderはコルーチンにすることができ、関数でyieldステートメントを使用する
                 OnPostRenderは、カメラがすべてのオブジェクトをレンダリングした後に呼び出される
                 すべてのカメラとGUIがレンダリングされた後で何かしたい場合は、WaitForEndOfFrameコルーチンを使用する
                 MonoBehaviour.OnPostRender（）
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnPostRender.html
<WaitForEndOfFrame>
https://docs.unity3d.com/ja/current/ScriptReference/WaitForEndOfFrame.html
<MonoBehaviour.OnPreRender()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnPreRender.html


OnPreCull  :  OnPreCullは、カメラがシーンをカリングする前に呼び出される
              この関数は、この関数が記述されたスクリプトにCameraがアタッチされていて有効である場合のみ呼び出される
              MonoBehaviour.OnPreCull（）
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnPreCull.html
<Camera>
https://docs.unity3d.com/ja/current/ScriptReference/Camera.html


OnPreRender  :  カメラがシーンのレンダリングを開始する前に呼び出される
                この関数は、この関数が記述されたスクリプトにCameraがアタッチされていて有効である場合のみ呼び出される
                MonoBehaviour.OnPreRender()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnPreRender.html


OnRenderImage  :  OnRenderImageはすべてのレンダリングがRenderImageへと完了したときに呼び出される
                  このメッセージはカメラにアタッチされているすべてのスクリプトに送られる
                  MonoBehaviour.OnRenderImage(RenderTexture,RenderTexture)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnRenderImage.html


OnRenderObject  :  OnRenderObjectは、カメラがシーンをレンダリングした後に呼び出される
                   これは、Graphics.DrawMeshNowまたは他の関数を使用して独自のオブジェクトをレンダリングするために使用できる
                   この関数はOnPostRenderに似ているが、カメラに取り付けられているかどうかに関係なくOnRenderObjectが関数を持つスクリプトを持つ任意のオブジェクトで呼び出される点が異なる
                   MonoBehaviour.OnRenderObject()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnRenderObject.html
<Graphics.DrawMeshNow>
https://docs.unity3d.com/ja/current/ScriptReference/Graphics.DrawMeshNow.html
<MonoBehaviour.OnPostRender()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnPostRender.html


OnSerializeNetworkView  :  ネットワークビューによって監視されるスクリプトの変数の同期をカスタマイズするために使用する
                           シリアライズされた変数が送信/受信するタイミングは、自動的に決定される
                           MonoBehaviour.OnSerializeNetworkView(BitStream,NetworkMessageInfo)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnSerializeNetworkView.html


OnServerInitialized  :  Network.InitializeServerが実行され完了したときにサーバー上で呼び出される
                        MonoBehaviour.OnServerInitialized()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnServerInitialized.html


OnTransformChildrenChanged  :  この関数はGameObjectのTransformのすべての子の中で変更があったときに呼び出される
                               MonoBehaviour.OnTransformChildrenChanged()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTransformChildrenChanged.html


OnTransformParentChanged  :  この関数はGameObjectのTransformのparentプロパティーに変更があったときに呼び出される
                             MonoBehaviour.OnTransformParentChanged()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTransformParentChanged.html


OnTriggerEnter  :  OnTriggerEnterをするときに呼び出されるゲームオブジェクトが相互に衝突するゲームオブジェクト
                   指定されたother Colliderには、そのGameObjectの名前など、トリガーイベントに関する詳細があります。
                   2のいずれかのゲームオブジェクトの持っている必要があります剛体コンポーネントを。
                   剛体部品は両方有しRigidbody.useGravityとRigidbody.isKinematicにセットしますfalse。
                   これらは、GameObjectが重力下に陥り、運動学的動作をすることを防ぎます。
                   一つの衝突はしていCollider.isTriggerはに設定しましたtrue。
                   ゲームオブジェクトとCollider.isTriggerがするように設定trueしているOnTriggerEnterが呼び出されたときに他のGameObjectがそれに触れるか通過します。
                   OnTriggerEnterは、FixedUpdateの終了後に発生します。
                   無効にされたゲームオブジェクトはOnTriggerEnterメッセージを受け取ります。
                   MonoBehaviour.OnTriggerEnter(Collider)

                   [パラメーター]
                   other   この衝突に関与したCollider
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerEnter.html


OnTriggerEnter2D  :  オブジェクトにアタッチしたトリガーの中に別のオブジェクトが入ったときに呼び出される（2D 物理挙動のみ）
                     入ったオブジェクトに関する詳細な情報は呼び出し時に渡されるCollision2D引数に代入される
                     MonoBehaviour.OnTriggerEnter2D(Collider2D)

                     [パラメーター]
                     other   他のCollider2Dがこの衝突に関係しているか
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerEnter2D.html
<Collider2D>
https://docs.unity3d.com/ja/current/ScriptReference/Collider2D.html
<MonoBehaviour.OnTriggerExit2D(Collider2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerExit2D.html
<MonoBehaviour.OnTriggerStay2D(Collider2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerStay2D.html


OnTriggerExit  :  Colliderがotherのトリガーに触れるのをやめたときにOnTriggerExitは呼び出される
                  このメッセージは、トリガーとトリガーに触れるコライダーに送信される
                  注：コライダーの1つにもリジッドボディがアタッチされている場合にのみ、トリガーイベントが送信される
                  トリガーイベントは無効化されたMonoBehavioursに送信され、衝突に対応して動作を有効化できるようにする
                  MonoBehaviour.OnTriggerExit(Collider)

                  [パラメーター]
                  other   この衝突に含まれるその他のCollider
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerExit.html


OnTriggerExit2D  :  トリガー状態のオブジェクトのコライダーと別のオブジェクトのコライダーが衝突から離れた瞬間に呼び出される（2D 物理挙動のみ）
                    入ったオブジェクトに関する詳細な情報は呼び出し時に渡されるCollision2D引数に代入される
                    MonoBehaviour.OnTriggerExit2D(Collider2D)

                    [パラメーター]
                    other   他のCollider2Dがこの衝突に関係しているか
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerExit2D.html
<Collider2D>
https://docs.unity3d.com/ja/current/ScriptReference/Collider2D.html
<MonoBehaviour.OnTriggerEnter2D(Collider2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerEnter2D.html
<MonoBehaviour.OnTriggerStay2D(Collider2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerStay2D.html


OnTriggerStay  :  OnTriggerStayは、トリガーに接触しているすべてのその他(other)のコライダーの物理更新ごとに1回呼び出される
                  このメッセージはトリガーと触れたトリガー状態のコライダーに送信される
                  MonoBehaviour.OnTriggerStay(Collider)

                  [パラメーター]
                  other   この衝突に含まれるその他のCollider
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerStay.html


OnTriggerStay2D  :  トリガー状態のオブジェクトのコライダーと別のオブジェクトのコライダー衝突している間、毎フレーム呼び出され続ける（2D 物理挙動のみ）
                    入ったオブジェクトに関する詳細な情報は呼び出し時に渡されるCollision2D引数に代入される
                    MonoBehaviour.OnTriggerStay2D(Collider2D)

                    [パラメーター]
                    other   他のCollider2Dがこの衝突に関係しているか
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerStay2D.html
<Collider2D>
https://docs.unity3d.com/ja/current/ScriptReference/Collider2D.html
<MonoBehaviour.OnTriggerEnter2D(Collider2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerEnter2D.html
<MonoBehaviour.OnTriggerExit2D(Collider2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerExit2D.html


OnValidate  :  この関数はスクリプトがロードされた時やインスペクターの値が変更されたときに呼び出される（この呼出はエディター上のみ）
               この関数を使用して、MonoBehavioursのデータを検証する
               これを使用して、エディターでデータを変更するときに、データが特定の範囲内に留まるようにすることができる
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnValidate.html


OnWillRenderObject  :  OnWillRenderObjectは、オブジェクトが表示され、UI要素ではない場合、カメラごとに呼び出される
                       この関数はMonoBehaviourが無効である場合は受け付けられない
                       カリングプロセス中に、カリングされた各オブジェクトをレンダリングする直前に呼び出される
                       適切なコンテキストでの使用方法についてはWater.cs、Assets-> Import Package-> Effectsのスクリプト参照
                       Camera.currentは、オブジェクトをレンダリングするカメラに設定されることに注意
                       MonoBehaviour .OnWillRenderObject（）
https://docs.unity3d.com/ja/current/ScriptReference/Camera-current.html
<Camera.current>
https://docs.unity3d.com/ja/current/ScriptReference/Camera-current.html


Reset  :  デフォルト値にリセットされる
          ResetはインスペクターのコンテキストメニューにあるResetボタンやコンポーネントを初めて追加するときに呼び出される
          この関数はエディターモードのみで呼び出される
          Resetはインスペクターでデフォルト値を設定するときにもっともよく使用される
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Reset.html


Start  :  Startは、Updateメソッドが初めて呼び出される直前にスクリプトが有効になったときに、フレームで呼び出される
          Awake関数と同様に、Startはスクリプトの有効期間中に1回だけ呼び出される
          ただし、スクリプトが有効化されているかどうかに関係なく、スクリプトオブジェクトが初期化されるとAwakeが呼び出される
          スクリプトが初期化時に有効になっていない場合、Awakeと同じフレームでStartが呼び出されない場合がある
          アウェイク任意のオブジェクトのStart関数が呼び出される前に関数がシーン内のすべてのオブジェクトで呼び出される
          この事実は、オブジェクトAの初期化コードが、既に初期化されているオブジェクトBに依存する必要がある場合に役立つ
          Bの初期化はAwakeで行う必要がありますが、AはStartで行う必要がある
          ゲームプレイ中にオブジェクトがインスタンス化される場合、それらのAwake関数は、SceneオブジェクトのStart関数が既に完了した後に呼び出される
          MonoBehaviour.Start()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Start.html
<MonoBehaviour.Awake()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Awake.html


Update  :  UpdateはMonoBehaviourが有効の場合に、毎フレーム呼び出される
           Updateは、あらゆる種類のゲームスクリプトを実装するために最も一般的に使用される関数
           すべてのMonoBehaviourスクリプトにUpdate必要なわけではない
           MonoBehaviour.Update()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Update.html
---

--------------------------------------------------------------------------------------------------------------------

/* MonoBehaviour
参照
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.html
*/

--------------------------------------------------------------------------------------------------------------------

/*
   MonoBehaviour
*/

---
[説明]

MonoBehaviourは、すべてのUnityスクリプトが派生する基本クラス
C＃を使用する場合は、MonoBehaviourから明示的に派生させる必要がある
このクラスは、null条件演算子（?.）とnull結合演算子（??）をサポートしていない
注：UnityエディターにはMonoBehaviourを無効にするためのチェックボックスがある
チェックを外すと、機能が無効になる
スクリプトにこれらの関数が存在しない場合、エディターはチェックボックスを表示しない
機能は以下
Start()
Update()
FixedUpdate()
LateUpdate()
OnGUI()
OnDisable()
OnEnable()
---

---
[変数]


runInEditMode  :  MonoBehaviourの特定のインスタンスを編集モードで実行できるようにする（エディターでのみ使用可能）
                  デフォルトでは、スクリプトコンポーネントは再生モードでのみ実行される
                  このプロパティを設定すると、MonoBehaviourは、エディターがプレイモードにないときにコールバック関数が実行される
                  public bool runInEditMode ;
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour-runInEditMode.html
<ExecuteInEditMode>
https://docs.unity3d.com/ja/current/ScriptReference/ExecuteInEditMode.html


useGUILayout  :  これを無効にすると、GUI のレイアウトフェーズをスキップすることができる
                 このOnGUI呼び出し内でGUI.WindowおよびGUILayoutを使用しない場合にのみ使用できる
                 public bool useGUILayout ;
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour-useGUILayout.html
<GUI.Window>
https://docs.unity3d.com/ja/current/ScriptReference/GUI.Window.html
---

---
[Public 関数]


CancelInvoke  :  すべてのInvokeをキャンセルする
                  public void CancelInvoke ();
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.CancelInvoke.html


Invoke  :  設定した時間（単位は秒）にメソッドを呼び出す
           public void Invoke (string methodName, float time);
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Invoke.html


InvokeRepeating  :  設定した時間（単位は秒）にメソッドを呼び出し、repeatRate秒ごとにリピートする
                    注：時間スケールを0に設定した場合、これは機能しない
                    public void InvokeRepeating (string methodName, float time, float repeatRate);
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.InvokeRepeating.html


IsInvoking  :  メソッドの呼出が保留中かどうか
               public bool IsInvoking (string methodName);
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.IsInvoking.html


StartCoroutine  :  コルーチンを開始する
                   コルーチンの実行は、yieldステートメントを使用していつでも一時停止できる
                   yieldステートメントが使用されると、コルーチンは実行を一時停止し、次のフレームで自動的に再開する
                   コルーチンは、複数のフレームにわたる動作をモデリングすることができる
                   StartCoroutine関数は常にすぐに戻りますが、結果を得ることができる
                   Yieldingは、コルーチンの実行が完了するまで待機する
                   同じフレームで終了する場合でも、コルーチンが開始されたのと同じ順序で終了するわけではない
                   public Coroutine StartCoroutine (IEnumerator routine);
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.StartCoroutine.html


StopAllCoroutines  :  Behaviour上で実行されているコルーチンをすべて停止する
                      このアクションは、複数のコルーチンを実行するスクリプトで使用することができる
                      スクリプトのすべてのコルーチンが停止されるので、引数は必要ない
                      public void StopAllCoroutines ()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.StopAllCoroutines.html


StopCoroutine  :  このBehaviour上で実行されているmethodNameという名のコルーチン、またはroutineとして保持されているコルーチンをすべて停止する
                  public void StopCoroutine (string methodName)
                  public void StopCoroutine (IEnumerator routine)
                  public void StopCoroutine (Coroutine routine)
                  
                  [パラメーター]
                  methodName   ストップするメソッド名
                  routine      保持しているコルーチン(routine = WaitAndPrint(3.0f);とか)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.StopCoroutine.html

---

---
[Static 関数]


print  :  Unity コンソールにログを出力します (Debug.Log と同じです)
          public static void print (object message);
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour-print.html
Debug.Log
https://docs.unity3d.com/ja/current/ScriptReference/Debug.Log.html
Debug.LogWarning
https://docs.unity3d.com/ja/current/ScriptReference/Debug.LogWarning.html
Debug.LogError
https://docs.unity3d.com/ja/current/ScriptReference/Debug.LogError.html
---

---
[メッセージ]


Awake  :  スクリプトのインスタンスがロードされたときに呼び出される
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Awake.html


FixedUpdate  :  物理計算のためのフレームレートに依存しないMonoBehaviour.FixedUpdateメッセージ
                MonoBehaviour.FixedUpdateには、物理システムの頻度がある => すべての固定フレームレートフレームと呼ばれる
                計算物理学の後のシステムの計算
                0.02秒（50コール/秒）が、コール間のデフォルトの時間 => この値にアクセスするには、Time.fixedDeltaTimeを使用
                スクリプト内で適切な値に設定して変更するか、Edit > Settings > Time > Fixed Timestepそこに移動して設定する
                Application.targetFrameRateを使用してフレームレートを設定する
                Rigidbodyを使用する場合はFixedUpdateを使用する必要がある
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.FixedUpdate.html
<Update>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Update.html
<Physics>
https://docs.unity3d.com/ja/current/ScriptReference/Physics.html
<Time.fixedDeltaTime>
https://docs.unity3d.com/ja/current/ScriptReference/Time-fixedDeltaTime.html
<Application.targetFrameRate>
https://docs.unity3d.com/ja/current/ScriptReference/Application-targetFrameRate.html
<Rigidbody>
https://docs.unity3d.com/ja/current/ScriptReference/Rigidbody.html


LateUpdate  :  Behaviourが有効の場合LateUpdateは毎フレーム呼びだされる
               LateUpdateはUpdate関数が呼び出された後に実行される
               これはスクリプトの実行順を決める時に使用できる
               例えばカメラを追従するにはUpdateで移動された結果を基に常にLateUpdateで位置を更新する必要がある
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.LateUpdate.html
 

OnAnimatorIK  :  アニメーションIK（インバースキネマティクス）をセットアップするときのコールバック
                 OnAnimatorIK() はAnimatorコンポーネントが内部IKシステムを更新する直前により呼び出される
                 このコールバックはIKGoalのポジションおよび関連するWeight（重み付け) を設定するために使用することができる
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnAnimatorIK.html


OnAnimatorMove  :  ルートモーションを修正するアニメーション動作を処理するコールバック
                   このコールバックは、ステートマシンとアニメーションが評価された後、OnAnimatorIKの前に各フレームで呼び出される
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnAnimatorMove.html
<MonoBehaviour.OnAnimatorIK(int)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnAnimatorIK.html


OnApplicationFocus  :  bool値
                       プレイヤーがフォーカスを取得、または、失ったときに、すべてのゲームオブジェクトに送信される
                       OnApplicationFocusはアプリケーションがフォーカスを失ったとき、またはフォーカスを取得したときに呼び出される
                       Alt-tabbingまたはCmd-tabbingは、Unityアプリケーションから別のデスクトップアプリケーションにフォーカスを移すことができる
                       これにより、GameObject は引数がfalseに設定されたOnApplicationFocus呼び出しを受け取る
                       ユーザーがUnityアプリケーションに戻ると、GameObjects は引数がtrueに設定されたOnApplicationFocus呼び出しを受け取ります。
                       OnApplicationFocusはコルーチンにできる => 関数でyieldステートメントを使用する
                       この方法で実装され、最初のフレーム中に2回評価される => 1つ目は早期通知、2つ目は通常のコルーチン更新ステップ中に評価される
                       Androidでは、スクリーンキーボードが有効になっていると、OnApplicationFocus（false）イベントが発生する
                       さらに、キーボードが有効になっているときにHomeを押すと、OnApplicationFocus（）イベントは呼び出されず、代わりにOnApplicationPause（）が呼び出される
                       MonoBehaviour.OnApplicationFocus (hasFocus)

                       [パラメーター]
                       hasFocus   true  :  ゲームオブジェクトにフォーカスがあるとき
                                  false :  ゲームオブジェクトにフォーカスがないとき
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnApplicationFocus.html


OnApplicationPause  :  bool値
                       プレイヤーが一時停止したときにすべてのゲームオブジェクトに送信される
                       OnApplicationPauseはtrueまたはfalseに設定される
                       通常、OnApplicationPauseメッセージによって返される値はfalse => ゲームがエディターで正常に実行されていることを意味する
                       インスペクターなどのエディターウィンドウが選択されている場合、ゲームは一時停止され、OnApplicationPauseはtrueを返す
                       ゲームウィンドウが選択され、アクティブなOnApplicationPauseが再びfalseを返す場合 => trueは、ゲームがアクティブでないことを意味する(ここ誤訳してるかも)
                       参照) Player Settings...のResolutionとPresentation、Run in BackgroundとVisible in Backgroundの解除
                       OnApplicationPauseエディターとは別に実行される独立したゲームで使用できる
                       実行中のゲームはウィンドウ表示され、全画面よりも小さい必要がある
                       ゲームが別のアプリケーションによって（完全にまたは部分的に）非表示になっている場合、OnApplicationPauseはtrueを返す
                       ゲームが現在の状態に戻ると、一時停止されなくなり、 OnApplicationPauseがfalseに戻る
                       OnApplicationPauseコルーチンにすることができる => 関数でyieldステートメントを使用する
                       この方法で実装され、最初のフレーム中に2回評価される => 1つは早期通知として、2つ目は通常のコルーチン更新ステップ中に評価される
                       Androidでは、スクリーンキーボードが有効になっていると、OnApplicationFocus（false）イベントが発生する
                       また、キーボードが有効になっているときに「Home」を押すと、OnApplicationFocus（）イベントは呼び出されず、代わりにOnApplicationPause（）が呼び出される
                       注： MonoBehaviour.OnApplicationPauseは、ゲームオブジェクトの開始時に呼び出される
                            呼び出しはAwakeの後に行われる
                            各GameObjectにより、この呼び出しが行われる
                       MonoBehaviour.OnApplicationPause (pauseStatus)

                       [パラメーター]
                       pauseStatus   true  :  アプリケーションが起動している
                                     false :  アプリケーションが起動していない
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnApplicationPause.html


OnApplicationQuit  :  アプリケーションが終了する前に、すべてのゲームオブジェクトに送信される
                      エディターでは、ユーザーが再生モードを停止したときに呼び出される
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnApplicationQuit.html


OnAudioFilterRead  :  OnAudioFilterReadが実装されている場合、UnityはDSPチェーンにカスタムフィルターを挿入する
                      フィルターは、MonoBehaviourスクリプトがインスペクターに表示されるのと同じ順序で挿入される
                      OnAudioFilterReadは、オーディオのチャンクがフィルターに送信されるたびに呼び出されます（これは、サンプルレートとプラットフォームに応じて、20msごとの頻度で発生する）
                      オーディオデータは[-1.0f、1.0F】の範囲の浮動小数点数のアレイであり、チェーン内の前のフィルタ又はAudioClipのAudioSourceからなる
                      これがチェーンの最初のフィルターであり、クリップがオーディオソースに接続されていない場合、このフィルターはオーディオソースとして再生される
                      このようにして、フィルターをオーディオクリップとして使用し、手続き的にオーディオを生成できる
                      複数のチャネルがある場合、チャネルデータはインターリーブされる
                      つまり、配列内の連続する各データサンプルは、チャネルが不足して最初のループに戻るまで、異なるチャネルから取得される
                      data.Lengthはデータの合計サイズを報告する => チャンネルあたりのサンプル数を見つけるには、data.Lengthをchannelsで割る
                      OnAudioFilterReadが実装されている場合、VUメーターがインスペクターに表示され、出力サンプルレベルを表示する
                      フィルターの処理時間も測定され、費やされたミリ秒がVUメーターの横に表示される
                      フィルターの処理に時間がかかりすぎると、数値が赤(警告)に変わる
                      また、OnAudioFilterReadはメインスレッド（つまりオーディオスレッド）とは別のスレッドで呼び出されるため、この関数からは多くのUnity関数を呼び出すことができない（実行しようとすると、実行時に警告が表示される）
                      MonoBehaviour.OnAudioFilterRead(data[], channels)

                      [パラメーター]
                      data       オーディオデータを持つ   float配列
                      channels   デリゲートに渡されたオーディオデータのチャネルの数を格納する   int型  
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnAudioFilterRead.html
<AudioClip>
https://docs.unity3d.com/ja/current/ScriptReference/AudioClip.html
<AudioSource>
https://docs.unity3d.com/ja/current/ScriptReference/AudioSource.html
<Audio Filter>
https://docs.unity3d.com/ja/current/Manual/class-AudioEffect.html


OnBecameInvisible  :  レンダラーがカメラから見えなくなったときに呼び出される
                      このメッセージは、レンダラーに接続されているすべてのスクリプトに送信される
                      OnBecameVisibleおよびOnBecameInvisibleは、オブジェクトが表示されている場合にのみ必要な計算を回避する事ができる
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnBecameInvisible.html
<MonoBehaviour.OnBecameVisible()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnBecameVisible.html
<MonoBehaviour.OnBecameInvisible()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnBecameInvisible.html


OnBecameVisible  :  レンダラーが任意のカメラから見えるようになると呼び出されます
                    このメッセージは、レンダラーに接続されているすべてのスクリプトに送信される
                    OnBecameVisibleおよびOnBecameInvisibleは、オブジェクトが表示されている場合にのみ必要な計算を回避することができる
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnBecameVisible.html
<MonoBehaviour.OnBecameVisible()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnBecameVisible.html
<MonoBehaviour.OnBecameInvisible()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnBecameInvisible.html


OnCollisionEnter  :  このcollider/rigidbodyは他のcollider/rigidbodyに触れたときにOnCollisionEnterは呼び出される
                     OnTriggerEnterのコントラストに応じてOnCollisionEnterはCollision classでなくColliderを渡す
                     Collision classは衝撃(impact)、速度(velocity)etc.に関する情報を含んでいる
                     もしcollisionInfoの機能を使わないならクラスは、接点、衝突速度などに関する情報が含まれている
                     注：Collisionイベントは、Colliderの1つに非キネマティックリジッドボディも接続されている場合にのみ送信される
                     Collisionイベントは無効化されたMonoBehavioursに送信され、Colliderに応答して動作を有効化できるようにする
                     MonoBehaviour.OnCollisionEnter(Collision)

                     [パラメーター]
                     other   このCollisionに関連付けられているCollisionデータ
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionEnter.html
<Collider>
https://docs.unity3d.com/ja/current/ScriptReference/Collider.html
<Collision>
https://docs.unity3d.com/ja/current/ScriptReference/Collision.html


OnCollisionEnter2D  :  オブジェクトのコライダーが別のコライダーに衝突したときに呼び出される（2D 物理挙動のみ）
                       衝突に関する詳細情報は、呼び出し中に渡されるCollision2Dパラメーターで報告される
                       この情報が必要ない場合は、パラメーターなしでOnCollisionEnter2Dを宣言できる
                       MonoBehaviour.OnCollisionEnter2D(Collision2D)

                       [パラメーター]
                       other   この衝突に関係のあるCollision2Dデータ
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionEnter2D.html
<Collision2D>
https://docs.unity3d.com/ja/current/ScriptReference/Collision2D.html
<MonoBehaviour.OnCollisionExit2D(Collision2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionExit2D.html
<MonoBehaviour.OnCollisionStay2D(Collision2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionStay2D.html


OnCollisionExit  :  Colliderがotherのトリガーに触れるのをやめたときに呼び出される
                    このメッセージは、トリガーとトリガーに触れるColliderに送信される
                    注：1つにもリジッドボディがアタッチされている場合にのみ、トリガーイベントが送信される
                        トリガーイベントは無効化されたMonoBehavioursに送信され、衝突に対応して動作を有効化できるようにする
                    MonoBehaviour.OnTriggerExit(Collider)

                    [パラメーター]
                    other   この衝突に含まれるその他のCollider
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerExit.html


OnCollisionExit2D  :  オブジェクトのコライダーと別のオブジェクトコライダーが衝突から離れた瞬間に呼び出される（2D 物理挙動のみ）
                      衝突についての詳しい情報は、呼び出されるときにパラメーターとして取得できるCollision2Dで取得することができる
                      この情報が必要ない場合はパラメーターなしのOnCollisionExit2Dを使用することができる
                      MonoBehaviour.OnCollisionExit2D(Collision2D)

                      [パラメーター]
                      other   この衝突に関係のあるCollision2Dデータ
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionExit2D.html
<Collision2D>
https://docs.unity3d.com/ja/current/ScriptReference/Collision2D.html
<MonoBehaviour.OnCollisionExit2D(Collision2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionExit2D.html
<MonoBehaviour.OnCollisionStay2D(Collision2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionStay2D.html


OnCollisionStay  :  OnCollisionStayは、collider/rigidbodyに接触しているすべてのcollider/rigidbodyについて、フレームごとに1回呼び出される
                    OnTriggerStayとは対照的に、OnCollisionStayにはColliderではなくCollisionクラスが渡される
                    Collision classは衝撃(impact)、速度(velocity)etc.に関する情報を含んでいる
                    もしcollisionInfoの機能を使わないならクラスは、接点、衝突速度などに関する情報が含まれている
                    注：衝突イベントは、コライダーの1つに非キネマティックリジッドボディも接続されている場合にのみ送信される
                    衝突イベントは無効化されたMonoBehavioursに送信され、衝突に応答して動作を有効化できるようにする
                    OnCollisionStayイベントは、スリープ中のrigidbodyには送信されない
                    MonoBehaviour.OnCollisionStay(Collision)

                    [パラメーター]
                    other   衝突と関連するCollisionデータ
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionStay.html
<Collider>
https://docs.unity3d.com/ja/current/ScriptReference/Collider.html
<Collision>
https://docs.unity3d.com/ja/current/ScriptReference/Collision.html


OnCollisionStay2D  :  オブジェクトのコライダーと別のオブジェクトのコライダーが衝突している間、毎フレーム呼び出され続ける（2D 物理挙動のみ）
                      衝突についての詳しい情報は、呼び出されるときにパラメーターとして取得できるCollision2Dで取得することができる
                      この情報が必要ない場合はパラメーターなしのOnCollisionStay2Dを使用することができる
                      MonoBehaviour.OnCollisionStay2D(Collision2D)

                      [パラメーター]
                      other   この衝突に関係のあるCollision2Dデータ
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionStay2D.html
<Collision2D>
https://docs.unity3d.com/ja/current/ScriptReference/Collision2D.html
<MonoBehaviour.OnCollisionExit2D(Collision2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionExit2D.html
<MonoBehaviour.OnCollisionEnter2D(Collision2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnCollisionEnter2D.html


OnConnectedToServer  :  サーバーとの接続に成功したときにクライアント上で呼び出されます
                        MonoBehaviour.OnConnectedToServer(OnConnectedToServer)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnConnectedToServer.html 


OnControllerColliderHit  :  OnControllerColliderHitはキャラクターコントローラーが移動中にコライダーに衝突した際に、呼び出される
                            これはキャラクターと衝突したときにオブジェクトを押すのに使用することができる
                            MonoBehaviour.OnControllerColliderHit(ControllerColliderHit)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnControllerColliderHit.htmlOnDestroy


OnDisable  :  動作が無効になったときに呼び出される
              オブジェクトを破棄し、任意なクリーンアップのコードを実行したいときにも呼び出される
              コンパイルが完了した後にスクリプトがリロードされるときOnDisableが呼び出され、スクリプトがロードされた後にOnEnableが呼び出される
              protected void OnDisable ()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnDisable.html


OnDisconnectedFromServer  :  サーバーとの接続が失われたか切断されたときにクライアント上で呼びされる
                             MonoBehaviour.OnDisconnectedFromServer(NetworkDisconnection)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnDisconnectedFromServer.html


OnDrawGizmos  :  選択可能にしたり、常に描画したいギズモを描画するにはOnDrawGizmosを使用する
                 OnDrawGizmosはシーンビューから相対的なマウス位置を使用することに注意
                 この関数はインスペクター上でコンポーネントが折りたたまれている場合、「ない」を取得して呼び出されない
                 ゲームオブジェクトを選択するとき、ギズモを描画するのにOnDrawGizmosSelectedを利用する
                 MonoBehaviour.OnDrawGizmos()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnDrawGizmos.html
<MonoBehaviour.OnDrawGizmosSelected()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnDrawGizmosSelected.html


OnDrawGizmosSelected  :  オブジェクトが選択されている場合は、ギズモを描画するためにOnDrawGizmosSelectedを実装する
                         Gizmosはオブジェクトを選択している時のみ描画される
                         ギズモは選択可能ではない
                         これはセットアップを簡単に実行するために使用される
                         MonoBehaviour.OnDrawGizmosSelected()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnDrawGizmosSelected.html
<Gizmos>
https://docs.unity3d.com/ja/current/ScriptReference/Gizmos.html


OnEnable  :  この関数はオブジェクトが有効/アクティブになったときに呼び出される
             MonoBehaviour.OnEnable()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnEnable.html


OnFailedToConnect  :  接続試行がなんらかの理由で失敗したときにクライアント上で呼び出される
                      失敗した理由はNetworkConnectionErrorとして取得できる
                      MonoBehaviour.OnFailedToConnect(NetworkConnectionError)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnFailedToConnect.html


OnFailedToConnectToMasterServer  :  MasterServer への接続に問題がある場合に、クライアントまたはサーバーで呼び出される
                                    エラーの理由はNetworkConnectionErrorとして取得できる
                                    MonoBehaviour.OnFailedToConnectToMasterServer(NetworkConnectionError)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnFailedToConnectToMasterServer.html


OnGUI  :  OnGUIはレンダリングとGUIイベントのハンドリングのために呼び出される
          これはOnGUIを実装した際には毎フレーム複数回（イベントごとに1回）呼び出されることを意味する
          GUIイベントについて、詳しくはEventリファレンスを参照
          MonoBehaviourのenabledプロパティーをfalseにした場合、OnGUI()が呼び出されることはない
          MonoBehaviour.OnGUI()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnGUI.html
<Event>
https://docs.unity3d.com/ja/current/ScriptReference/Event.html


OnJointBreak  :  ゲームオブジェクトに対するジョイントが外れたとき呼び出される
                 ジョイントのbreakForceよりも大きな力がかかると、ジョイントは壊れる
                 ジョイントが壊れると、OnJointBreakが呼び出され、ジョイントに適用されたブレークフォースが渡される
                 OnJointBreakの後で、ジョイントはゲームオブジェクトから自動的に削除され、削除される
                 MonoBehaviour.OnJointBreak(float)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnJointBreak.html


OnJointBreak2D  :  ゲームオブジェクトにアタッチした Joint2D が壊れたときに呼び出される
                   Joint2D.reactionForceがJoint2D.breakForceより高いまたはJoint2D.reactionTorqueがJoint2D.breakTorqueのジョイントより高いときジョイントは破損する
                   ジョイントが壊れると、OnJointBreak2Dが呼び出され、壊れた特定のJoint2Dが渡される
                   OnJointBreak2Dが呼び出された後、ジョイントはゲームオブジェクトから自動的に削除される
                   MonoBehaviour .OnJointBreak2D（Joint2D）
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnJointBreak2D.html
<Joint2D.breakForce>
https://docs.unity3d.com/ja/current/ScriptReference/Joint2D-breakForce.html
<Joint2D.breakTorque>
https://docs.unity3d.com/ja/current/ScriptReference/Joint2D-breakTorque.html
<Joint2D.reactionForce>
https://docs.unity3d.com/ja/current/ScriptReference/Joint2D-reactionForce.html
<Joint2D.reactionTorque>
https://docs.unity3d.com/ja/current/ScriptReference/Joint2D-reactionTorque.html


OnMasterServerEvent  :  MasterServer からイベントを報告してくるときにクライアントやサーバー上で呼び出される
                        例えば、ホストのリストを受信したり、ホストの登録が成功したとき
                        MonoBehaviour.OnMasterServerEvent(MasterServerEvent)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMasterServerEvent.html


OnMouseDown  :  OnMouseDownは、ユーザーがGUIElementまたはCollider上でマウスボタンを押したときに呼び出される
                このイベントはColliderまたはGUIElementにアタッチされているすべてのスクリプトに送信される
                MonoBehaviour .OnMouseDown（）
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseDown.html
<GUIElement>
https://docs.unity3d.com/ja/current/ScriptReference/GUIElement.html
<Collider>
https://docs.unity3d.com/ja/current/ScriptReference/Collider.html


OnMouseDrag  :  ユーザーがGUIElementまたはColliderをマウスでクリックし、ドラッグしている間呼び出される
                OnMouseDragはマウスを押している間、毎フレーム呼び出される
                MonoBehaviour.OnMouseDrag()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseDrag.html


OnMouseEnter  :  GUIElementまたはCollider上にマウスが乗ったときに呼び出される
                 オブジェクトの上にマウスが重なっている間、対応する.OnMouseOver関数が呼び出され、マウスがオブジェクトから離れたとき、OnMouseExit関数が呼び出される
                 MonoBehaviour.OnMouseEnter()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseEnter.html
<MonoBehaviour.OnMouseExit()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseExit.html


OnMouseExit  :  GUIElementまたはCollider上からマウス離れたときに呼び出される
                OnMouseExitの呼び出しは、OnMouseEnterとOnMouseOver に対応する呼び出しの後に続く
                この関数はレイヤーが「Ignore Raycast」のゲームオブジェクトでは呼び出されない
                MonoBehaviour.OnMouseExit()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseExit.html
<MonoBehaviour.OnMouseOver()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseOver.html
<Physics.queriesHitTriggers>
https://docs.unity3d.com/ja/current/ScriptReference/Physics-queriesHitTriggers.html


OnMouseOver  :  GUIElementまたはCollider上にマウスがあり続ける限り毎フレーム呼び出され続ける
                OnMouseEnterの呼び出しは、マウスがオブジェクト上にある最初のフレームで発生する
                その後、マウスが離れるまでOnMouseOverがフレームごとに呼び出され、その時点でOnMouseExitが呼び出される
                この関数はレイヤーが「Ignore Raycast」のゲームオブジェクトでは呼び出されない
                この関数はレイヤーが「Ignore Raycast」のゲームオブジェクトではトリガーされない
                Physics.queriesHitTriggersはtrue
                OnMouseOverはコルーチンにできる => 関数でyieldステートメントを使用する
                このイベントは、コライダーまたはGUIElementに接続されているすべてのスクリプトに送信される
                MonoBehaviour.OnMouseOver()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseOver.html


OnMouseUp  :  OnMouseUpはユーザーがマウスボタンを離したときに呼び出される
              OnMouseUpはマウスを押した時と同じGUIElementやCollider上にない場合でも呼び出されることに注意
              MonoBehaviour.OnMouseUp()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseUp.html
<MonoBehaviour.OnMouseUpAsButton()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseUpAsButton.html


OnMouseUpAsButton  :  OnMouseUpAsButtonはマウスを押した時と同じGUIElementやCollider上でマウスを離した時のみに呼び出される
                      MonoBehaviour.OnMouseUpAsButton()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnMouseUpAsButton.html
<GUIElement>
https://docs.unity3d.com/ja/current/ScriptReference/GUIElement.html
<Collider>
https://docs.unity3d.com/ja/current/ScriptReference/Collider.html


OnNetworkInstantiate  : Network.Instantiateでインスタンス化されたオブジェクトに対して呼び出される 
                        これは、インスタンス化されたオブジェクトのコンポーネントを無効または有効にする場合に役立つ
                        それらの動作は、ローカルに所有されているかリモートに所有されているかによって異なる
                        注： NetworkMessageInfo内のnetworkView属性は、OnNetworkInstantiate内では使用されない
                        MonoBehaviour.OnNetworkInstantiate(NetworkMessageInfo)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnNetworkInstantiate.html


OnParticleCollision  :  パーティクルがコライダーにヒットしたときにOnParticleCollisionが呼び出される
                        パーティクルがヒットしたときにゲームオブジェクトにダメージを適用させるために使用することができる
                        このメッセージはパーティクルシステムにアタッチされたスクリプトとヒットしたColliderに対して送信される
                        インスペクターにあるParticle System CollisionモジュールのSend Collision Messagesを有効にした場合のみ、メッセージは送信される
                        OnParticleCollisionは関数の中にシンプルなyield文を使用して、コルーチンにすることができる
                        MonoBehaviour.OnParticleCollision(GameObject)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnParticleCollision.html
<ParticlePhysicsExtensions.GetCollisionEvents>
https://docs.unity3d.com/ja/current/ScriptReference/ParticlePhysicsExtensions.GetCollisionEvents.html
<ParticleSystem>
https://docs.unity3d.com/ja/current/ScriptReference/ParticleSystem.html


OnParticleSystemStopped  :  システム内のすべてのパーティクルが消滅し、新しいパーティクルが発生しないときに呼び出される
                            新しいパーティクルは、Stopが呼び出された後、または非ループシステムの継続時間プロパティを超えたときに作成されなくなる
                            これは、パーティクルシステムが終了したことをスクリプトに通知するために使用できる
                            コールバックを受信するには、ParticleSystem.MainModule.stopActionプロパティをCallbackに設定する必要がある
                            MonoBehaviour.OnParticleSystemStopped()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnParticleSystemStopped.html
<ParticleSystem.MainModule.stopAction>
https://docs.unity3d.com/ja/current/ScriptReference/ParticleSystem.MainModule-stopAction.html


OnParticleTrigger  :  OnParticleTriggerは、パーティクルシステムのパーティクルがトリガーモジュールの条件を満たすときに呼び出される
                      衝突範囲の内側か外側にあるパーティクルを削除、または、修正するために使用される
                      MonoBehaviour .OnParticleTrigger（）
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnParticleTrigger.html


OnPlayerConnected  :  新しいプレイヤーが接続に成功したときにサーバー上で呼び出されます
                      MonoBehaviour.OnPlayerConnected(NetworkPlayer)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnPlayerConnected.html


OnPlayerDisconnected  :  プレイヤーがサーバーから接続が切断されるたびにサーバー上で呼び出される
                         MonoBehaviour.OnPlayerDisconnected(NetworkPlayer)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnPlayerDisconnected.html


OnPostRender  :  OnPostRenderは、カメラがシーンのレンダリングを完了した後に呼び出される
                 この関数は、スクリプトがカメラにアタッチされ、有効になっている場合にのみ呼び出される
                 OnPostRenderはコルーチンにすることができ、関数でyieldステートメントを使用
                 OnPostRenderは、カメラがすべてのオブジェクトをレンダリングした後に呼び出される
                 すべてのカメラとGUIがレンダリングされた後で何かしたい場合は、WaitForEndOfFrameコルーチンを使用する
                 MonoBehaviour.OnPostRender()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnPostRender.html
<MonoBehaviour.OnPreRender()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnPreRender.html
<WaitForEndOfFrame>
https://docs.unity3d.com/ja/current/ScriptReference/WaitForEndOfFrame.html


OnPreCull  :  OnPreCullは、カメラがシーンをカリングする前に呼び出される
              この関数は、この関数が記述されたスクリプトにCameraがアタッチされていて有効である場合のみ呼び出される
              MonoBehaviour.OnPreCull（）
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnPreCull.html
<Camera>
https://docs.unity3d.com/ja/current/ScriptReference/Camera.html


OnPreRender  :  カメラがシーンのレンダリングを開始する前に呼び出される
                この関数は、この関数が記述されたスクリプトにCameraがアタッチされていて有効である場合のみ呼び出される
                MonoBehaviour.OnPreRender()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnPreRender.html


OnRenderImage  :  OnRenderImage はすべてのレンダリングが RenderImage へと完了したときに呼び出されます。
                  ポストプロセッシングエフェクト
                  このメッセージはカメラにアタッチされているすべてのスクリプトに送られる
                  MonoBehaviour.OnRenderImage(RenderTexture,RenderTexture)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnRenderImage.html
<Graphics.Blit>
https://docs.unity3d.com/ja/current/ScriptReference/Graphics.Blit.html


OnRenderObject  :  OnRenderObjectは、カメラがシーンをレンダリングした後に呼び出される
                   これは、Graphics.DrawMeshNowまたは他の関数を使用して独自のオブジェクトをレンダリングするために使用できる
                   この関数はOnPostRenderに似ていますが、OnRenderObjectが関数を持つスクリプトを持つ任意のオブジェクトで呼び出される点が異なる
                   それがカメラに取り付けられているかどうかは関係ない
                   MonoBehaviour.OnRenderObject()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnRenderObject.html
<Graphics.DrawMeshNow>
https://docs.unity3d.com/ja/current/ScriptReference/Graphics.DrawMeshNow.html
<MonoBehaviour.OnPostRender()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnPostRender.html


OnSerializeNetworkView  :  ネットワークビューによって監視されるスクリプトの変数の同期をカスタマイズするために使用する
                           シリアライズされた変数が送信/受信するタイミングは、自動的に決定される
                           これはオブジェクトの所有者に依存 => 自身と他のすべてを受信する
                           MonoBehaviour.OnSerializeNetworkView(BitStream,NetworkMessageInfo)
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnSerializeNetworkView.html


OnServerInitialized  :  Network.InitializeServerが実行され完了したときにサーバー上で呼び出される
                        MonoBehaviour.OnServerInitialized()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnServerInitialized.html


OnTransformChildrenChanged  :  この関数はGameObjectのTransformのすべての子の中で変更があったときに呼び出される
                               MonoBehaviour.OnTransformChildrenChanged()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTransformChildrenChanged.html


OnTransformParentChanged  :  この関数はGameObjectのTransformのparentプロパティーに変更があったときに呼び出される
                             MonoBehaviour.OnTransformParentChanged()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTransformParentChanged.html


OnTriggerEnter  :  OnTriggerEnterをするときに呼び出されるゲームオブジェクトが相互に衝突するゲームオブジェクト
                   指定されたother Colliderには、そのGameObjectの名前など、トリガーイベントに関する詳細がある
                   OnTriggerEnterは、FixedUpdateの終了後に発生する
                   無効にされたゲームオブジェクトはOnTriggerEnterメッセージを受け取る
                   MonoBehaviour .OnTriggerEnter（Collider）

                   [パラメーター]
                   other   この衝突に関与したコライダー
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerEnter.html
<MonoBehaviour.FixedUpdate()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.FixedUpdate.html
<Collider.isTrigger>
https://docs.unity3d.com/ja/current/ScriptReference/Collider-isTrigger.html
<Rigidbody.isKinematic>
https://docs.unity3d.com/ja/current/ScriptReference/Rigidbody-isKinematic.html
<Rigidbody.useGravity>
https://docs.unity3d.com/ja/current/ScriptReference/Rigidbody-useGravity.html
<Rigidbody>
https://docs.unity3d.com/ja/current/ScriptReference/Rigidbody.html
<Collider>
https://docs.unity3d.com/ja/current/ScriptReference/Collider.html


OnTriggerEnter2D  :  オブジェクトにアタッチしたトリガーの中に別のオブジェクトが入ったときに呼び出される（2D 物理挙動のみ）
                     入ったオブジェクトに関する詳細な情報は呼び出し時に渡されるCollision2D引数に代入される
                     MonoBehaviour.OnTriggerEnter2D(Collider2D)

                     [パラメーター]
                     other   他のCollider2Dがこの衝突に関係しているかどうか
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerEnter2D.html
<Collider2D>
https://docs.unity3d.com/ja/current/ScriptReference/Collider2D.html
<MonoBehaviour.OnTriggerExit2D(Collider2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerExit2D.html
<MonoBehaviour.OnTriggerStay2D(Collider2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerStay2D.html


OnTriggerExit  :  Colliderがotherのトリガーに触れるのをやめたときにOnTriggerExitは呼び出される
                  このメッセージは、トリガーとトリガーに触れるコライダーに送信される
                  注：コライダーの1つにもリジッドボディがアタッチされている場合にのみ、トリガーイベントが送信される
                  トリガーイベントは無効化されたMonoBehavioursに送信され、衝突に対応して動作を有効化できるようにする
                  MonoBehaviour.OnTriggerExit(Collider)

                  [パラメーター]
                  other   この衝突に含まれるその他の Collider
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerExit.html


OnTriggerExit2D  :  トリガー状態のオブジェクトのコライダーと別のオブジェクトのコライダーが衝突から離れた瞬間に、呼び出される（2D 物理挙動のみ）
                    入ったオブジェクトに関する詳細な情報は呼び出し時に渡されるCollision2D引数に代入される
                    MonoBehaviour.OnTriggerExit2D(Collider2D)

                    [パラメーター]
                    other   他のCollider2Dがこの衝突に関係してるか
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerExit2D.html
<Collider2D>
https://docs.unity3d.com/ja/current/ScriptReference/Collider2D.html
<MonoBehaviour.OnTriggerEnter2D(Collider2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerEnter2D.html
<MonoBehaviour.OnTriggerStay2D(Collider2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerStay2D.html


OnTriggerStay  :  OnTriggerStayは、トリガーに接触しているすべてのコライダーの物理更新ごとに1回呼び出される
                  MonoBehaviour.OnTriggerStay(Collider)

                  [パラメーター]
                  other   この衝突に含まれるその他の Collider
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerStay.html


OnTriggerStay2D  :  トリガー状態のオブジェクトのコライダーと別のオブジェクトのコライダー衝突している間、毎フレーム呼び出され続ける（2D 物理挙動のみ）
                    入ったオブジェクトに関する詳細な情報は呼び出し時に渡されるCollision2D引数に代入される
                    MonoBehaviour.OnTriggerStay2D(Collider2D)

                    [パラメーター]
                    other   他のCollider2Dがこの衝突に関係しているか
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerStay2D.html
<Collider2D>
https://docs.unity3d.com/ja/current/ScriptReference/Collider2D.html
<MonoBehaviour.OnTriggerEnter2D(Collider2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerEnter2D.html
<MonoBehaviour.OnTriggerExit2D(Collider2D)>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerExit2D.html


OnValidate  :  この関数はスクリプトがロードされた時やインスペクターの値が変更されたときに呼び出される（この呼出しはエディター上のみ）
               この関数を使用して、MonoBehavioursのデータを検証する
               これを使用して、エディターでデータを変更するときに、データが特定の範囲内に留まるようにすることができる
               MonoBehaviour.OnValidate()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnValidate.html


OnWillRenderObject  :  OnWillRenderObjectは、オブジェクトが表示され、UI要素ではない場合、カメラごとに呼び出される
                       この関数はMonoBehaviourが無効である場合は受け付けられない
                       カリングプロセス中に、カリングされた各オブジェクトをレンダリングする直前に呼び出される
                       適切なコンテキストでの使用方法についてはWater.cs、Assets-> Import Package-> Effectsのスクリプトを参照
                       Camera.currentは、オブジェクトをレンダリングするカメラに設定されることに注意
                       注： UI要素から呼び出された場合、これは効果がない
                       MonoBehaviour.OnWillRenderObject()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnWillRenderObject.html
<Camera.current>
https://docs.unity3d.com/ja/current/ScriptReference/Camera-current.html


Reset  :  デフォルト値にリセットします
          インスペクターのコンテキストメニューにあるResetボタンやコンポーネントを初めて追加するときに呼び出される
          この関数はエディターモードのみで呼び出される
          Resetはインスペクターでデフォルト値を設定するときにもっともよく使用される
          MonoBehaviour.Reset()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Reset.html


Start  :  Startは、Updateメソッドが初めて呼び出される直前にスクリプトが有効になったときに、フレームで呼び出される
          Awake関数と同様に、Startはスクリプトの有効期間中に1回だけ呼び出される
          ただし、スクリプトが有効化されているかどうかに関係なく、スクリプトオブジェクトが初期化されるとAwakeが呼び出される
          スクリプトが初期化時に有効になっていない場合、Awakeと同じフレームでStartが呼び出されない場合がある
          アウェイク任意のオブジェクトのStart関数が呼び出される前に関数がシーン内のすべてのオブジェクトで呼び出される
          この事実は、オブジェクトAの初期化コードが、既に初期化されているオブジェクトBに依存する必要がある場合に役立つ
          Bの初期化はAwakeで行う必要がありますが、AはStartで行う必要がある
          ゲームプレイ中にオブジェクトがインスタンス化される場合、それらのAwake関数は、SceneオブジェクトのStart関数が既に完了した後に呼び出される
          MonoBehaviour.Start()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Start.html
<MonoBehaviour.Awake()>
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Awake.html


Update  :  UpdateはMonoBehaviourが有効の場合に、毎フレーム呼び出される
           MonoBehaviour.Update()
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.Update.html
---

<継承メンバー>

---
[変数]


enabled  :  有効であれば更新され、無効であれば更新されない
            インスペクター上ではチェックボックスとして表示される
            public bool enabled ;
https://docs.unity3d.com/ja/current/ScriptReference/Behaviour-enabled.html


isActiveAndEnabled  :  Behaviorはアクティブで有効になっているかどうか
                       GameObjectはアクティブまたは非アクティブにできる
                       同様に、スクリプトを有効または無効にすることができる
                       GameObjectがアクティブで、スクリプトが有効になっている場合、isActiveAndEnabledはtrueが返される
                       それ以外の場合falseが返される
                       public bool isActiveAndEnabled ;
https://docs.unity3d.com/ja/current/ScriptReference/Behaviour-isActiveAndEnabled.html


gameObject  :  このコンポーネントはゲームオブジェクトにアタッチされる
               コンポーネントはいつもゲームオブジェクトにアタッチされている
               public GameObject gameObject ;
https://docs.unity3d.com/ja/current/ScriptReference/Component-gameObject.html


tag  :  ゲームオブジェクトのタグ
        タグはゲームオブジェクトを見分けるために使用することができる
        タグを使用する前にTags and Layersマネージャーでタグ名を宣言する必要がある
        public string tag ;
https://docs.unity3d.com/ja/current/ScriptReference/Component-tag.html


transform  :  gameObjectに付属している位置情報
              public Transform transform ;
https://docs.unity3d.com/ja/current/ScriptReference/Component-transform.html


hideFlags  :  オブジェクトを非表示にするか、シーンに保存するか、ユーザーが変更できるようにするか
              public HideFlags hideFlags ;
https://docs.unity3d.com/ja/current/ScriptReference/Object-hideFlags.html


name  :  オブジェクト名
         コンポーネントは、ゲームオブジェクトとすべてのアタッチされたコンポーネントと同じ名前を共有する
         クラスがMonoBehaviourから派生する場合、クラスはMonoBehaviourからnameフィールドを継承する
         このクラスがGameObjectにもアタッチされている場合、nameフィールドはそのGameObjectの名前に設定される
https://docs.unity3d.com/ja/current/ScriptReference/Object-name.html
---

---
[public関数]


BroadcastMessage  :  ゲームオブジェクトまたは子オブジェクトにあるすべてのMonoBehaviourを継承したクラスにあるmethodName名のメソッドを呼び出す
                      public void BroadcastMessage (string methodName, object parameter= null, SendMessageOptions options= SendMessageOptions.RequireReceiver);
                      public void BroadcastMessage (string methodName, SendMessageOptions options);

                      [パラメーター]
                      methodName   呼び出すメソッド名
                      parameter    呼び出すメソッドに渡すオプショナルパラメーター（どのような値でも可）
                      options      目的のオブジェクトに指定したメソッドが存在しない場合、エラーを発生させるかどうか
https://docs.unity3d.com/ja/current/ScriptReference/Component.BroadcastMessage.html


CompareTag  :  このゲームオブジェクトは tag とタグ付けされているかどうか
               public bool CompareTag (string tag);

               [パラメーター]
               tag   比較するタグ
https://docs.unity3d.com/ja/current/ScriptReference/Component.CompareTag.html


GetComponent  :  ゲームオブジェクトにtypeがアタッチされている場合はtypeのタイプを使用してコンポーネントを返す
                 ない場合はnull
                 public Component GetComponent (Type type);

                 [パラメーター]
                 type   取得するコンポーネントの型
https://docs.unity3d.com/ja/current/ScriptReference/Component.GetComponent.html


GetComponentInChildren  :  GameObjectや深さ優先探索を活用して、親子関係にある子オブジェクトからtypeのタイプのコンポーネントを取得する
                           GameObjectでアクティブと判定された場合のみコンポーネントを返す
                           public Component GetComponentInChildren (Type t);

                           [パラメーター]
                           t   取得するコンポーネントの型

                           [戻り値]
                           Component   見つかった場合、型に一致したコンポーネントを返す
https://docs.unity3d.com/ja/current/ScriptReference/Component.GetComponentInChildren.html


GetComponentInParent  :  GameObjectや深さ優先探索を活用して、親子関係にある親オブジェクトからtypeのタイプのコンポーネントを取得
                         public Component GetComponentInParent (Type t);

                         [パラメーター]
                         t   取得するコンポーネントの型

                         [戻り値]
                         Component   見つかった場合、型に一致したコンポーネントを返す
https://docs.unity3d.com/ja/current/ScriptReference/Component.GetComponentInParent.html


GetComponents  :  GameObject からtypeのタイプのコンポーネントを「すべて」取得する
                  public Component[] GetComponents (Type type);

                  [パラメーター]
                  type   取得するコンポーネントの型
https://docs.unity3d.com/ja/current/ScriptReference/Component.GetComponents.html


GetComponentsInChildren  :  GameObjectや深さ優先探索を活用して、親子関係にある子オブジェクトからtypeのタイプのコンポーネントを「すべて」取得する
                            public Component[] GetComponentsInChildren (Type t, bool includeInactive);
                            
                            [パラメーター]
                            t                 取得するコンポーネントの型
                            includeInactive   非アクティブのコンポーネントも含めるかどうか
https://docs.unity3d.com/ja/current/ScriptReference/Component.GetComponentsInChildren.html


GetComponentsInParent  :  GameObjectや深さ優先探索を活用して、親子関係にある親オブジェクトからtypeのタイプのコンポーネントを「すべて」取得する
                          public Component[] GetComponentsInParent (Type t, bool includeInactive= false);

                          [パラメーター]
                          t                 取得するコンポーネントの型
                          includeInactive   非アクティブのコンポーネントも含めるかどうか
https://docs.unity3d.com/ja/current/ScriptReference/Component.GetComponentsInParent.html


SendMessage  :  ゲームオブジェクトにアタッチされているすべてのMonoBehaviourにあるmethodNameと名付けたメソッドを呼び出す
                このメッセージは非アクティブのオブジェクトには送信されない
                public void SendMessage (string methodName);
                public void SendMessage (string methodName, object value);
                public void SendMessage (string methodName, object value, SendMessageOptions options);
                public void SendMessage (string methodName, SendMessageOptions options);
                
                [パラメーター]
                methodName   呼び出すメソッド名
                value        呼び出すメソッドに引数として渡すパラメーター
                options      目的のオブジェクトにメソッドが実装されていない場合、エラーを発生させるかどうか
https://docs.unity3d.com/ja/current/ScriptReference/Component.SendMessage.html


SendMessageUpwards  :  ゲームオブジェクトと親（の親、さらに親 ... ）にアタッチされているすべてのMonoBehaviourにあるmethodNameと名付けたメソッドを呼び出す
                       このメッセージは非アクティブのオブジェクトには送信されない
                       public void SendMessageUpwards (string methodName, SendMessageOptions options);
                       public void SendMessageUpwards (string methodName, object value= null, SendMessageOptions options= SendMessageOptions.RequireReceiver);

                       [パラメーター]
                       methodName	呼び出すメソッド名
                       value        呼び出すメソッドに引数として渡すパラメーター
                       options      目的のオブジェクトにメソッドが存在しない場合、エラーを発生させるかどうか
https://docs.unity3d.com/ja/current/ScriptReference/Component.SendMessageUpwards.html


GetInstanceID  :  オブジェクトのインスタンスIDを返します
                  オブジェクトのインスタンスIDは、常に固有的なものです
                  public int GetInstanceID ();
https://docs.unity3d.com/ja/current/ScriptReference/Object.GetInstanceID.html


ToString  :  GameObjectの名前を返す
             public string ToString ();

             [戻り値]
             string   ToStringによって返される名前
https://docs.unity3d.com/ja/current/ScriptReference/Object.ToString.html
---

---
[Static 関数]


Destroy  :  アタッチされたBehaviorを破棄すると、ゲームまたはシーンがOnDestroyを受け取る
            シーンまたはゲームの終了時に発生する
            エディター内から実行中に再生モードを停止すると、アプリケーションが終了する
            この終了が発生すると、OnDestroyが実行される
            また、シーンが閉じて新しいシーンが読み込まれると、OnDestroy呼び出しが行われる
            スタンドアロンアプリケーションとして構築した場合、シーンの終了時にOnDestroy呼び出しが行われる
            シーンの終了は通常、新しいシーンが読み込まれることを意味する
            注  :  OnDestroyは、以前にアクティブであったゲームオブジェクトでのみ呼び出される
            public static void Destroy (Object obj, float t= 0.0F);

            [パラメーター]
            obj   破壊するオブジェクト
            t     オブジェクトを破壊するまでのディレイ時間
https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnDestroy.html


DestroyImmediate  :  オブジェクトをobjすぐに破棄する。
                     代わりにDestroyを使用する方がよい。というかこっちは使う必要でない限り極力使わない方がいい。
                     遅延破棄は編集モードでは呼び出されないので、この関数はエディターコードを記述する場合以外で使用してはいけない
                     ゲームコードでは、代わりにObject.Destroyを使用する必要がある
                     破棄は常に遅延する（ただし、同じフレーム内で実行される）
                     この機能はObjectを永久に破壊する可能性がある
                     また、配列を繰り返し処理したり繰り返し処理している要素を破棄していけない
                     public static void DestroyImmediate (Object obj, bool allowDestroyingAssets = false)

                     [パラメーター]
                     obj                     破壊されるオブジェクト
                     allowDestroyingAssets   アセットを破棄できるようにするには、trueに設定
https://docs.unity3d.com/ja/current/ScriptReference/Object.DestroyImmediate.html
<Object.Destroy>
https://docs.unity3d.com/ja/current/ScriptReference/Object.Destroy.html


DontDestroyOnLoad  :  新しいシーンをロードするときにターゲットオブジェクトを破棄したくないときに使用
                      新しいシーンをロードすると、現在のシーンオブジェクトがすべて破棄される
                      Object.DontDestroyOnLoadを呼び出して、レベルの読み込み中にオブジェクトを保持する
                      ターゲットオブジェクトがコンポーネントまたはGameObjectの場合、UnityはTransformの子もすべて保持する
                      Object.DontDestroyOnLoadは値を返さない
                      typeof演算子を使用して引数のタイプを変更する
                      public static void DontDestroyOnLoad (Object target)
                      
                      [パラメーター]
                      target   シーンの変更時に破壊されないようにするオブジェクト
https://docs.unity3d.com/ja/current/ScriptReference/Object.DontDestroyOnLoad.html


FindObjectOfType  :  タイプtypeから最初に見つけたアクティブのオブジェクトを返す
                     アセット（メッシュ、テクスチャ、プレハブなど）または非アクティブなオブジェクトを返さない
                     GameObjectを見つけるために使用される
                     HideFlags.DontSaveが設定されているオブジェクトは返さない
                     Object.FindObjectOfTypeを呼び出し、型に一致するオブジェクトを返す
                     型に一致するオブジェクトがない場合はnullを返す
                     この機能は非常に遅い => この関数をフレームごとに使用することは非推奨
                     public static Object FindObjectOfType (Type type)

                     [パラメーター]
                     type   見つけるオブジェクトの型

                     [戻り値]
                     Object   指定されたタイプと一致するオブジェクトを返す
                              タイプに一致するオブジェクトがない場合は、nullを返す
https://docs.unity3d.com/ja/current/ScriptReference/Object.FindObjectOfType.html


FindObjectsOfType  :  タイプtypeから見つかったすべてのアクティブのオブジェクトを返す
                      アセット（メッシュ、テクスチャ、プレハブなど）または非アクティブなオブジェクトを返さない
                      非アクティブなオブジェクトなどを含めたい場合はFindObjectsOfTypeAllを使用する
                      GameObjectを見つけるために使用される
                      HideFlags.DontSaveが設定されているオブジェクトは返さない
                      Object.FindObjectsOfTypeを呼び出し、型に一致するオブジェクトを返す
                      型に一致するオブジェクトがない場合はnullを返す
                      この機能は非常に遅い => この関数をフレームごとに使用することは非推奨
                      public static Object[] FindObjectsOfType (Type type)

                      [パラメーター]
                      type   見つけるオブジェクトの型

                      [戻り値]
                      Object[]   指定した型で見つかったオブジェクトの配列を返す
https://docs.unity3d.com/ja/current/ScriptReference/Object.FindObjectsOfType.html
<Resources.FindObjectsOfTypeAll>
https://docs.unity3d.com/ja/current/ScriptReference/Resources.FindObjectsOfTypeAll.html


Instantiate  :  originalのオブジェクトをクローンする
                この関数は、エディターの複製コマンド(CTRL + D)と同様の方法でオブジェクトのコピーを作成する
                GameObjectのクローンを作成する場合は、オプションでその位置と回転を指定することができる（これらはデフォルトでは元のGameObjectの位置と回転）
                コンポーネントのクローンを作成している場合は、それが接続されているGameObjectもクローンされる
                GameObjectまたはComponentのクローンを作成すると、すべての子オブジェクトとコンポーネントも、元のオブジェクトのプロパティと同様にプロパティが設定されてクローンされる
                新しいオブジェクトのnullはnullになるため、元のオブジェクトの兄弟にはならない
                ただし、オーバーロードされたメソッドを使用して親を設定することはできる
                親が指定され、位置と回転が指定されていない場合、クローンのオブジェクトのローカルの位置と回転、またはinstantiateInWorldSpaceパラメーターがtrueの場合はそのワールドの位置と回転に、元の位置と回転が使用されます。
                位置と回転が指定されている場合、それらはワールドスペースでのオブジェクトの位置と回転として使用されます。
                クローン作成時のGameObjectのアクティブステータスが渡されるため、オリジナルが非アクティブの場合、クローンも非アクティブな状態で作成されます。
                public static Object Instantiate (Object original)
                public static Object Instantiate (Object original, Transform parent)
                public static Object Instantiate (Object original, Transform parent, bool instantiateInWorldSpace)
                public static Object Instantiate (Object original, Vector3 position, Quaternion rotation)
                public static Object Instantiate (Object original, Vector3 position, Quaternion rotation, Transform parent)

                [パラメーター]
                original                  コピーしたい既存オブジェクト
                position                  新しいオブジェクトの位置
                rotation                  新しいオブジェクトの向き
                parent                    新しいオブジェクトに割り当てられる親
                instantiateInWorldSpace   ture  => 新しい親に相対的な位置を設定するのではなく、オブジェクトのワールド位置を維持するために親オブジェクトを割り当てる
                                          false => 新しい親を基準にしてオブジェクトの位置を設定

                [戻り値]
                Object   インスタンス化されたクローン
https://docs.unity3d.com/ja/current/ScriptReference/Object.Instantiate.html
---

---
[Operator]


bool  :  オブジェクトが存在するかどうか
https://docs.unity3d.com/ja/current/ScriptReference/Object-operator_Object.html


operator !=  :  二つのオブジェクトが異なるオブジェクトを参照しているか比較する(つまりただの !=)
                public static bool operator != (Object x, Object y);
                
                [パラメーター]
                x   最初のオブジェクト
                y   比較対象のオブジェクト
https://docs.unity3d.com/ja/current/ScriptReference/Object-operator_ne.html


operator ==  :  2つのオブジェクト参照が同じオブジェクトを参照しているか比較する(つまりただの ==)
                public static bool operator == (Object x, Object y);

                [パラメーター]
                x   最初のオブジェクト
                y   比較対象のオブジェクト
https://docs.unity3d.com/ja/current/ScriptReference/Object-operator_eq.html
---

--------------------------------------------------------------------------------------------------------------------

/* GetSiblingIndex
参照
https://docs.unity3d.com/jp/460/ScriptReference/Transform.GetSiblingIndex.html
*/

--------------------------------------------------------------------------------------------------------------------

/*
   GetSiblingIndex ()
   Transform.GetSiblingIndex
*/

---
[説明]

兄弟関係のインデックスを取得する
これを使用して、GameObjectの兄弟インデックスを返す
GameObjectが他のGameObjectsと親を共有し、同じレベルにある場合（つまり、同じ直接の親を共有する場合）、これらのGameObjectsは兄弟と呼ばれる
兄弟インデックスは、各兄弟兄弟がこの兄弟階層のどこに位置するかを示す
GetSiblingIndexを使用して、この階層でのGameObjectの場所を見つけることができる
GameObjectの兄弟インデックスが変更されると、階層ウィンドウでのその順序も変更される
これは、レイアウトグループコンポーネントを使用する場合など、GameObjectの子を意図的に順序付けることができる
---

---
[使用例]

int setSiblingIndex = transform.GetSiblingIndex();
---

--------------------------------------------------------------------------------------------------------------------

/*SetSiblingIndex
参照
https://docs.unity3d.com/ja/current/ScriptReference/Transform.SetSiblingIndex.html
*/

--------------------------------------------------------------------------------------------------------------------

/*
   SetSiblingIndex (int index)
   Transform.SetSiblingIndex
*/

---
[パラメーター]

index  :  設定するインデックス
---

---
[説明]

指定のインデックスにTransformを移動させる
これを使用して、GameObjectの兄弟インデックスを変更できる
GameObjectが他のGameObjectsと親を共有し、同じレベルにある場合（つまり、同じ直接の親を共有する場合）、これらのGameObjectsは兄弟と呼ばれる
兄弟インデックスは、各兄弟兄弟がこの兄弟階層のどこに位置するかを示す
SetSiblingIndexを使用して、この階層でのゲームオブジェクトの位置を変更する
GameObjectの兄弟インデックスが変更されると、階層ウィンドウでのその順序も変更される
これは、レイアウトグループコンポーネントを使用する場合など、GameObjectの子を意図的に順序付けることができる
---

---
[使用例]

int setSiblingIndex = transform.GetSiblingIndex();
transform.SetSiblingIndex(setSiblingIndex);
---

--------------------------------------------------------------------------------------------------------------------

/* CreateAssetMenu
参照
CreateAssetMenuAttribute
https://docs.unity3d.com/ScriptReference/CreateAssetMenuAttribute.html
CreateAssetMenuAttribute.fileName
https://docs.unity3d.com/ScriptReference/CreateAssetMenuAttribute-fileName.html
CreateAssetMenuAttribute.menuName
https://docs.unity3d.com/ScriptReference/CreateAssetMenuAttribute-menuName.html
CreateAssetMenuAttribute.order
https://docs.unity3d.com/ScriptReference/CreateAssetMenuAttribute-order.html
*/

--------------------------------------------------------------------------------------------------------------------

/*
   [CreateAssetMenu(fileName = "", menuName = "",order = )]
*/

[説明]

Assets / Createサブメニューに自動的にリストされるようにScriptableObject派生タイプをマークします。これにより、タイプのインスタンスを簡単に作成し、プロジェクトに「.asset」ファイルとして保存できます。

[プロパティ]

fileName   新しく作成されたインスタンスによって使用されるデフォルトのファイル名  string型
menuName   Assets/Createメニューに表示される表示名  string型
order      Assets/Createメニュー内のメニュー項目の位置  int型
---

-----------------------------------------------------------------------------------------------------------------------
