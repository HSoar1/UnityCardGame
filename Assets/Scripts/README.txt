/*目次*/
1.コードに関するメモ(L.50 - L)
        L.50   - L.153  GetComponentsInChildren
                L.64   - L.90   public Component[] GetComponentsInChildren (Type type, bool includeInactive = false / true);
                L.90   - L.126  public T[] GetComponentsInChildren ();
                                public T[] GetComponentsInChildren (bool includeInactive);
                L.126  - L.153  public void GetComponentsInChildren (List<T> results);
                                public void GetComponentsInChildren (bool includeInactive, List<T> results);
        L.153  - L.271  staticとシングルトンパターン
                L.167  - L.192  public static class ClassSample{}   静的クラス
                L.192  - L.221  public static void MethodSample();  静的メソッド
                L.221  - L.251  シングルトンパターン
                L.251  - L.271  staticクラスとシングルトンパターンの違い
        L.271  - L.326  SetActive
                L.279  - L.301  SetActive (bool);
                L.301  - L.326  SetActiveの注意点
        L.334  - L.363 foreach
                L.334  - L.363  foreach (型名 オブジェクト名 in コレクション)
        L.363  - L.420  Destroy
                L.372  - L.399  Destroy (obj);
                L.399  - L.420  Destroy (Object obj, floot);
        L.420  - L.547  Coroutine(コルーチン)
                L.434  - L.450  コルーチンとは
                L.450  - L.473  コルーチンの使い方
                L.473  - L.507  yield return null;
                                yield return new WaitForSeconds (floot);
                L.507  - L.547  コルーチンを止めるとき
        L.547  - L.1076 Findメソッド
                L.575  - L.612  List<T>.Find (Predicate<T> match)
                L.612  - L.646  Array.Find (T[] array, Predicate<T> match)
                L.646  - L.689  List<T>.FindIndex (Predicate<T> match)
                L.689  - L.732  List<T>.FindIndex (int startIndex, Predicate<T> match)
                L.732  - L.777  List<T>.FindIndex (int startIndex, int count, Predicate<T> match)
                L.777  - L.819  Array.FindIndex (T[] array, Predicate<T> match)
                L.819  - L.862  Array.FindIndex (T[] array, int startIndex, Predicate<T> match)
                L.862  - L.906  Array.FindIndex (T[] array, int startIndex, int count, Predicate<T> match)
                L.906  - L.950  List<T>.FindLast (Predicate<T> match)
                L.950  - L.993  Array.FindLast (T[] array, Predicate<T> match)
                L.993  - L.1035 List<T>.FindAll (Predicate<T> match)
                L.1035 - L.1076 Array.FindAll (T[] array, Predicate<T> match)
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

void Sample(){
    int [] n = new int[] { 1, 2, 3, 4, 5 };
    int [] result = Array.FindAll (n, n => n > 3); // result == {4, 5}
}
---

--------------------------------------------------------------------------------------------------------------------

















ArgumentNullException
https://docs.microsoft.com/ja-jp/dotnet/api/system.argumentnullexception?view=netframework-4.8