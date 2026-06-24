# 대소문자 바꿔서 출력하기

---

## 프로그램 설명

영어 알파벳으로 이루어진 문자열 `str`이 주어졌을 때,  
대문자는 소문자로, 소문자는 대문자로 변환하여 출력하는 프로그램입니다.

예를 들어 입력이 `aBcDeFg`라면 출력은 `AbCdEfG`가 됩니다.

---

## 소스 코드

```csharp
using System;

public class Example
{
    public static void Main()
    {
        string str = Console.ReadLine();

        foreach (char c in str)
        {
            // 대문자라면 소문자로 변환
            if (char.IsUpper(c))
            {
                Console.Write(char.ToLower(c));
            }
            // 소문자라면 대문자로 변환
            else
            { 
                Console.Write(char.ToUpper(c));
            }
        }
    }
}
```

---

## 주요 메서드 및 문법 설명

| 문법 / 메서드 | 설명 |
|---|---|
| `Console.ReadLine()` | 사용자로부터 문자열을 입력받습니다. |
| `foreach` | 문자열의 문자를 하나씩 반복해서 처리합니다. |
| `char.IsUpper(c)` | 문자 `c`가 대문자인지 확인합니다. |
| `char.ToLower(c)` | 문자 `c`를 소문자로 변환합니다. |
| `char.ToUpper(c)` | 문자 `c`를 대문자로 변환합니다. |
| `Console.Write()` | 줄바꿈 없이 값을 출력합니다. |

---

## 입력 예시

```text
aBcDeFg
```

---

## 출력 예시

```text
AbCdEfG
```

---

## 코드 동작 과정

1. 문자열 `str`을 입력받습니다.
2. `foreach`문으로 문자열의 각 문자를 하나씩 확인합니다.
3. 현재 문자가 대문자이면 `char.ToLower()`로 소문자로 바꿉니다.
4. 현재 문자가 소문자이면 `char.ToUpper()`로 대문자로 바꿉니다.
5. 변환된 문자를 바로 출력합니다.

---

## 참고 사항

문자열은 알파벳으로만 이루어져 있으므로, 숫자나 특수문자 처리는 따로 하지 않아도 됩니다.