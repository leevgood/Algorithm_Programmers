# 문자열 뒤집기 쿼리 처리 문제

---

## 프로그램 설명

주어진 문자열 `my_string`과 이차원 정수 배열 `queries`가 있습니다.

각 쿼리는 `[s, e]` 형태이며, 문자열의 인덱스 `s`부터 `e`까지의 부분 문자열을 뒤집으라는 의미입니다.

모든 쿼리를 순서대로 처리한 뒤 최종 문자열을 반환하는 문제입니다.

---

## 문제 예시

### 입력

```text
my_string = "rermgorpsam"
queries = [[2, 3], [0, 7], [5, 9], [6, 10]]
```

### 처리 과정

| queries   | my_string       |
| --------- | --------------- |
| 시작        | `"rermgorpsam"` |
| `[2, 3]`  | `"remrgorpsam"` |
| `[0, 7]`  | `"progrmersam"` |
| `[5, 9]`  | `"prograsremm"` |
| `[6, 10]` | `"programmers"` |

### 출력

```text
"programmers"
```

---

## 핵심 아이디어

문자열은 직접 수정하기 어렵기 때문에, 수정 가능한 자료구조로 변환해서 처리합니다.

* C#에서는 문자열을 `char[]` 배열로 변환
* Python에서는 문자열을 `list`로 변환

각 쿼리 `[s, e]`마다 `s`부터 `e`까지의 문자를 뒤집습니다.

---

# C# 풀이

## 소스 코드

```csharp
using System;

public class Solution
{
    public string solution(string my_string, int[,] queries)
    {
        // 문자열을 수정 가능한 char 배열로 변환
        char[] chars = my_string.ToCharArray();

        // queries의 행 개수만큼 반복
        for (int i = 0; i < queries.GetLength(0); i++)
        {
            int s = queries[i, 0];
            int e = queries[i, 1];

            // 투 포인터 방식으로 s부터 e까지 뒤집기
            while (s < e)
            {
                char temp = chars[s];
                chars[s] = chars[e];
                chars[e] = temp;

                s++;
                e--;
            }
        }

        // char 배열을 다시 문자열로 변환
        return new string(chars);
    }
}
```

---

## 주요 메서드 및 문법 설명

| 코드                        | 설명                          |
| ------------------------- | --------------------------- |
| `my_string.ToCharArray()` | 문자열을 문자 배열로 변환합니다.          |
| `queries.GetLength(0)`    | 2차원 배열의 행 개수를 구합니다.         |
| `queries[i, 0]`           | i번째 쿼리의 시작 인덱스 `s`입니다.      |
| `queries[i, 1]`           | i번째 쿼리의 끝 인덱스 `e`입니다.       |
| `while (s < e)`           | 양쪽 끝에서 가운데로 이동하며 문자를 교환합니다. |
| `new string(chars)`       | 문자 배열을 다시 문자열로 변환합니다.       |

---

## C# 코드 동작 과정

예를 들어 `[2, 3]` 쿼리가 들어오면 다음 인덱스의 문자를 교환합니다.

```text
r e r m g o r p s a m
    ↑ ↑
    2 3
```

`r`과 `m`을 교환하면 다음과 같이 바뀝니다.

```text
r e m r g o r p s a m
```

이 과정을 모든 쿼리에 대해 순서대로 반복합니다.

---

# Python 풀이

## 소스 코드

```python
def solution(my_string, queries):
    # 문자열을 수정 가능한 리스트로 변환
    chars = list(my_string)

    for s, e in queries:
        # s부터 e까지의 구간을 뒤집어서 다시 저장
        chars[s:e + 1] = reversed(chars[s:e + 1])

    # 리스트를 다시 문자열로 변환
    return ''.join(chars)
```

---

## Python 다른 풀이

슬라이싱을 사용하면 더 간결하게 작성할 수도 있습니다.

```python
def solution(my_string, queries):
    chars = list(my_string)

    for s, e in queries:
        chars[s:e + 1] = chars[s:e + 1][::-1]

    return ''.join(chars)
```

---

## 주요 메서드 및 문법 설명

| 코드                    | 설명                          |
| --------------------- | --------------------------- |
| `list(my_string)`     | 문자열을 문자 리스트로 변환합니다.         |
| `for s, e in queries` | 각 쿼리의 시작 인덱스와 끝 인덱스를 꺼냅니다.  |
| `chars[s:e + 1]`      | 인덱스 `s`부터 `e`까지의 부분 리스트입니다. |
| `[::-1]`              | 리스트나 문자열을 거꾸로 뒤집습니다.        |
| `''.join(chars)`      | 문자 리스트를 하나의 문자열로 합칩니다.      |

---

## 입력 예시

```text
my_string = "rermgorpsam"
queries = [[2, 3], [0, 7], [5, 9], [6, 10]]
```

---

## 출력 예시

```text
"programmers"
```

---

## 시간 복잡도

문자열의 길이를 `N`, 쿼리의 개수를 `Q`라고 하면, 각 쿼리마다 최대 `N`개의 문자를 뒤집을 수 있습니다.

```text
시간 복잡도: O(N × Q)
```

제한사항에서 `N ≤ 1,000`, `Q ≤ 1,000`이므로 충분히 빠르게 실행됩니다.

---

## 공간 복잡도

문자열을 문자 배열 또는 리스트로 변환해서 사용합니다.

```text
공간 복잡도: O(N)
```

---

## 참고 사항

* 문자열은 불변 객체이므로 직접 수정하지 않는 것이 좋습니다.
* C#에서는 `char[]` 배열을 사용하는 방식이 효율적입니다.
* Python에서는 `list`와 슬라이싱을 사용하면 간단하게 구현할 수 있습니다.
* 쿼리는 반드시 주어진 순서대로 처리해야 합니다.
