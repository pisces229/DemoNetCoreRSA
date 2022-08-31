// See https://aka.ms/new-console-template for more information

//RSA 演算法公式
//N = pq : p、q分別都是隨意挑的質數，N是p、q的乘積。
//φ(N) = (p - 1)(q - 1) : φ(N)的意思是小於 N 的質數，(p-1)(q - 1) 是φ(N)的公式算法。
//gcd(e, φ(N)) = 1 : 找出一個和 φ(N) 這個數互質的 e 。
//d*e ≡ 1 (mod φ(N)) : 找到 d ，條件如下，使得 d*e 之乘積除以 φ(N) 的餘數等於 1 ！也就是說， (d * e - 1) 是 φ(N) 的整數倍！
//Me≡C(mod N) : M 代表原文，Me除以 N 取餘數，餘數即為密文！
//Cd≡M (mod N) : C 代表密文，Cd除以 N 取餘數，餘數即為密文！

//Example：A 要傳送訊息 “islab" 給 B 。
//1.選擇 p = 47, q = 71，則 N = 3337 (47*71)。
//2.φ(N) = 3220(46 * 70)。
//3.找一個和 3220 互質的數字，假設我們找 79，e = 79。
//4.利用公式 d*e ≡ 1 (mod φ(N)) ，推得(d * e - 1) = Z * φ(N)，Z是正整數、e是79、φ(N)是3220。找到Z為25時，d是正整數1019
//5.把e = 79、N=3337的訊息送過去給A

//A 利用傳送過來的 e 和 N 運算出密文：
//1.將原文 “islab " 轉為十進位的ASCII碼 “105115108097098″(我們假設通訊內容的字母編碼為三位數)。
//2.將轉碼後的原文分割為三個數一組 "105 115 108 097 098″，要割成幾個一組都可以。
//3.進行加密的運算Me≡C(mod N)
//105^79    (mod 3337)  -> 193
//115^79    (mod 3337)  -> 732
//108^79    (mod 3337)  -> 1795
//097^79    (mod 3337)  -> 957
//098^79    (mod 3337)  -> 617
//4.將密文 "01930732179509570617″送給B，因為餘數最多可能到四位數，不足地方補零，才不會造成錯誤。

//B利用 d 和 N 進行解密：
//1.進行解密的運算Cd≡M(mod N)
//193^1019  (mod 3337)  -> 105
//732^1019  (mod 3337)  -> 115
//1795^1019 (mod 3337)  -> 108
//957^1019  (mod 3337)  -> 97
//617^1019  (mod 3337)  -> 98

//計算公鑰和金鑰
//假設p = 3、q = 11（p，q都是素數即可。），則N = pq = 33；
//r = (p-1)(q - 1) = (3 - 1)(11 - 1) = 20；
//根據模反元素的計算公式，我們可以得出，e·d ≡ 1(mod 20),即e·d = 20n 1(n為正整數)
//我們假設n = 1，則e·d = 21。e、d為正整數，並且e與r互質，則e = 3，d = 7。（兩個數交換一下也可以。）
//公鑰為(N, e) = (33, 3)，金鑰為(N, d) = (33, 7)。
using System.Numerics;

//var (p, q, N) = (3, 11, 33);
//var (e, d) = (3, 7);
//var text = 24;
//Console.WriteLine($"text:{text}");
//var encrypt = Math.Pow(text, e) % N;
//Console.WriteLine($"encrypt:{encrypt}");
//var decrypt = Math.Pow(encrypt, d) % N;
//Console.WriteLine($"decrypt:{decrypt}");

//new BigInteger()
//var (p, q, N) = (47, 71, new BigInteger(3337));
//var (e, d) = (79, 1019);
//var text = new BigInteger(24);
//Console.WriteLine($"text:{text}");
//var encrypt = BigInteger.Pow(text, e) % N;
//Console.WriteLine($"encrypt:{encrypt}");
//var decrypt = BigInteger.Pow(encrypt, d) % N;
//Console.WriteLine($"decrypt:{decrypt}");



var first = new Demo(1);
var second = new Demo(2);
var third = first + second;
Console.WriteLine(third.Value);
public class Demo
{
    public int Value { get; set; }
    public Demo(int value)
    { 
        Value = value;
    }
    public static Demo operator +(Demo left, Demo right)
    {
        return new Demo(left.Value + right.Value);
    }
    public static bool operator !=(Demo left, Demo right)
    {
        return true;
    }
    public static bool operator ==(Demo left, Demo right)
    {
        return true;
    }
};