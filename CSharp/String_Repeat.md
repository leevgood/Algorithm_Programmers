# 문자열 반복해서 출력하기

## 문제 설명

문자열 `str`과 정수 `n`이 주어집니다.

`str`이 `n`번 반복된 문자열을 만들어 출력하는 코드를 작성하는 문제입니다.

---

## 제한사항

| 조건 | 내용 |
|---|---|
| 문자열 길이 | `1 ≤ str의 길이 ≤ 10` |
| 반복 횟수 | `1 ≤ n ≤ 5` |

---

## 입력 형식

문자열 `str`과 정수 `n`이 공백으로 구분되어 입력됩니다.

```text
str n
```

---

## 출력 형식

문자열 `str`을 `n`번 반복한 결과를 출력합니다.

---

## 입력 예시

```text
string 3
```

---

## 출력 예시

```text
stringstringstring
```

---

## 풀이 아이디어

문자열과 반복 횟수를 입력받은 뒤, 반복문을 사용하여 문자열을 `n`번 출력하면 됩니다.

C#에서는 `for`문을 사용하여 정해진 횟수만큼 반복할 수 있습니다.

---

## 최종 코드

```csharp
using System;

public class Example
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');

        string str = input[0];
        int n = int.Parse(input[1]);

        for (int i = 0; i < n; i++)
        {
            Console.Write(str);
        }
    }
}
```

---

## 코드 설명

| 코드 | 설명 |
|---|---|
| `Console.ReadLine()` | 한 줄을 입력받습니다. |
| `.Split(' ')` | 입력받은 문자열을 공백 기준으로 나눕니다. |
| `string str = input[0];` | 첫 번째 입력값을 문자열로 저장합니다. |
| `int n = int.Parse(input[1]);` | 두 번째 입력값을 정수로 변환합니다. |
| `for (int i = 0; i < n; i++)` | `n`번 반복합니다. |
| `Console.Write(str);` | 줄바꿈 없이 문자열을 출력합니다. |

---

## 동작 과정

입력이 다음과 같다고 가정합니다.

```text
hello 4
```

변수에는 다음과 같이 저장됩니다.

| 변수 | 값 |
|---|---|
| `str` | `"hello"` |
| `n` | `4` |

반복문은 총 4번 실행됩니다.

```text
1번째 반복: hello
2번째 반복: hello
3번째 반복: hello
4번째 반복: hello
```

따라서 최종 출력은 다음과 같습니다.

```text
hellohellohellohello
```

---

## 핵심 포인트

이 문제의 핵심은 문자열을 직접 이어 붙이는 것보다, 반복문을 사용하여 필요한 횟수만큼 출력하는 것입니다.

또한 줄바꿈 없이 출력해야 하므로 `Console.WriteLine()`이 아니라 `Console.Write()`를 사용합니다.
