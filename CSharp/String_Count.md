# 문자열 안에 특정 문자열이 등장하는 횟수 구하기 (C# / Python)

## 프로그램 설명

문자열 `myString`과 `pat`이 주어졌을 때, `myString` 안에서 `pat`이 등장하는 횟수를 구하는 문제입니다.

이 문제에서 중요한 점은 **문자열이 서로 겹쳐서 등장하는 경우도 모두 세어야 한다는 것**입니다.

예를 들어:

- `myString = "aaaa"`
- `pat = "aa"`

인 경우 다음과 같이 총 3번 등장합니다.

```text
aaaa
^^    → 1회

aaaa
 ^^   → 2회

aaaa
  ^^  → 3회
```

따라서 정답은 `3`입니다.

---

## C# 소스 코드

```csharp
using System;

public class Solution
{
    public int solution(string myString, string pat)
    {
        int answer = 0;

        // pat이 들어갈 수 있는 마지막 시작 위치까지 반복
        for (int i = 0; i <= myString.Length - pat.Length; i++)
        {
            // 현재 위치부터 pat 길이만큼 잘라서 비교
            if (myString.Substring(i, pat.Length) == pat)
            {
                answer++;
            }
        }

        return answer;
    }
}
```

---

## C# 주요 메서드 및 문법 설명

| 문법 / 메서드 | 설명 |
| --- | --- |
| `myString.Length` | 문자열의 길이를 반환합니다. |
| `pat.Length` | 찾으려는 문자열의 길이를 반환합니다. |
| `Substring(i, pat.Length)` | `i`번째 위치부터 `pat.Length`만큼 문자열을 잘라냅니다. |
| `== pat` | 잘라낸 문자열과 `pat`이 같은지 비교합니다. |
| `answer++` | `pat`이 발견될 때마다 등장 횟수를 1 증가시킵니다. |
| `i++` | 시작 위치를 한 칸씩 이동하여 겹치는 문자열도 검사합니다. |

---

## Python 소스 코드

```python
def solution(myString, pat):
    answer = 0

    # pat이 들어갈 수 있는 마지막 시작 위치까지 반복
    for i in range(len(myString) - len(pat) + 1):
        # 현재 위치부터 pat 길이만큼 슬라이싱하여 비교
        if myString[i:i + len(pat)] == pat:
            answer += 1

    return answer
```

---

## Python 주요 문법 설명

| 문법 | 설명 |
| --- | --- |
| `len(myString)` | 문자열 `myString`의 길이를 반환합니다. |
| `len(pat)` | 문자열 `pat`의 길이를 반환합니다. |
| `range(...)` | 가능한 시작 인덱스를 순서대로 반복합니다. |
| `myString[i:i + len(pat)]` | `i`번째 위치부터 `pat` 길이만큼 문자열을 슬라이싱합니다. |
| `== pat` | 슬라이싱한 문자열과 `pat`이 같은지 비교합니다. |
| `answer += 1` | 문자열이 일치하면 등장 횟수를 1 증가시킵니다. |

---

## 입력 예시

### 예시 1

```text
myString = "banana"
pat = "ana"
```

### 예시 2

```text
myString = "aaaa"
pat = "aa"
```

---

## 출력 예시

### 예시 1

```text
2
```

### 예시 2

```text
3
```

---

## 코드 동작 과정

### 예시 1: `"banana"`, `"ana"`

`pat`의 길이는 3이므로 `banana`에서 길이가 3인 문자열을 한 칸씩 이동하면서 비교합니다.

| 시작 인덱스 | 부분 문자열 | 비교 결과 |
| ---: | --- | --- |
| 0 | `"ban"` | 불일치 |
| 1 | `"ana"` | 일치 |
| 2 | `"nan"` | 불일치 |
| 3 | `"ana"` | 일치 |

따라서 `"ana"`는 총 **2번** 등장합니다.

---

### 예시 2: `"aaaa"`, `"aa"`

| 시작 인덱스 | 부분 문자열 | 비교 결과 |
| ---: | --- | --- |
| 0 | `"aa"` | 일치 |
| 1 | `"aa"` | 일치 |
| 2 | `"aa"` | 일치 |

따라서 `"aa"`는 총 **3번** 등장합니다.

여기서 시작 인덱스를 `0 → 1 → 2`처럼 한 칸씩 이동하기 때문에 서로 겹치는 `"aa"`도 모두 셀 수 있습니다.

---

## 시간 복잡도

문자열의 길이를 `N`, `pat`의 길이를 `M`이라고 하면 각 위치에서 최대 `M`개의 문자를 비교하므로 시간 복잡도는 대략 다음과 같습니다.

```text
O(N × M)
```

문제의 제한사항은 `myString`의 길이가 최대 1000, `pat`의 길이가 최대 10이므로 충분히 빠르게 동작합니다.

---

## 참고 사항

- `pat`이 겹쳐서 등장하는 경우도 모두 포함해야 합니다.
- 단순히 문자열을 분리하거나 한 번 찾은 뒤 `pat.Length`만큼 이동하면 겹치는 경우를 놓칠 수 있습니다.
- 따라서 **시작 인덱스를 반드시 한 칸씩 증가시키며 검사하는 방식**이 안전합니다.
- C#에서는 `Substring`, Python에서는 문자열 슬라이싱을 사용하면 직관적으로 구현할 수 있습니다.

---

## 핵심 정리

이 문제의 핵심은 다음 한 문장으로 정리할 수 있습니다.

> 문자열의 모든 가능한 시작 위치에서 `pat` 길이만큼 잘라 비교하고, 일치할 때마다 카운트를 증가시킨다.
