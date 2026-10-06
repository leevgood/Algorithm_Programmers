# 문자열 잘라서 배열로 저장하기 — C# / Python

## 문제 설명

문자열 `my_str`과 정수 `n`이 주어질 때 문자열을 앞에서부터 **길이 `n`씩 잘라 배열에 저장**합니다. 마지막에 남은 문자열이 `n`보다 짧다면 그대로 배열에 추가합니다.

## C# 풀이

```csharp
using System;
using System.Collections.Generic;

public class Solution
{
    public string[] solution(string my_str, int n)
    {
        List<string> result = new List<string>();

        for (int i = 0; i < my_str.Length; i += n)
        {
            int length = Math.Min(n, my_str.Length - i);
            result.Add(my_str.Substring(i, length));
        }

        return result.ToArray();
    }
}
```

### 핵심 설명

- `for (int i = 0; i < my_str.Length; i += n)`으로 시작 위치를 `n`씩 이동합니다.
- `Substring(startIndex, length)`의 두 번째 인자는 **끝 인덱스가 아니라 길이**입니다.
- 마지막 문자열이 `n`보다 짧을 수 있으므로 `Math.Min(n, my_str.Length - i)`로 실제 잘라낼 길이를 계산합니다.

### 기존 코드의 문제

```csharp
result.Add(my_str.Substring(i * n, i * n + n - 1));
```

`Substring()`의 두 번째 인자를 끝 위치처럼 계산한 것이 문제입니다.

또한:

```csharp
int cnt = my_str.Length / n;
```

처럼 정수 나눗셈으로 반복 횟수를 계산하면 나머지가 있는 경우 마지막 문자열을 놓칠 수 있습니다.

---

## Python 풀이

```python
def solution(my_str, n):
    result = []

    for i in range(0, len(my_str), n):
        result.append(my_str[i:i + n])

    return result
```

### 핵심 설명

- `range(0, len(my_str), n)`으로 인덱스를 `n`씩 증가시킵니다.
- `my_str[i:i + n]`으로 문자열을 자릅니다.
- Python 슬라이싱은 끝 범위가 문자열 길이를 넘어가도 자동으로 가능한 범위까지만 잘라주므로 별도 처리가 필요하지 않습니다.

### 더 간단한 Python 풀이

```python
def solution(my_str, n):
    return [my_str[i:i + n] for i in range(0, len(my_str), n)]
```

---

## C#과 Python 비교

| 항목 | C# | Python |
|---|---|---|
| 문자열 길이 | `my_str.Length` | `len(my_str)` |
| 문자열 자르기 | `Substring(start, length)` | `my_str[start:end]` |
| 결과 저장 | `List<string>` | `list` |
| `n`칸씩 이동 | `i += n` | `range(..., n)` |
| 마지막 문자열 처리 | `Math.Min()` 사용 | 슬라이싱이 자동 처리 |

---

## 동작 예시

```text
my_str = "abc1Addfggg4556b"
n = 6
```

처리 과정:

```text
0 ~ 5   -> "abc1Ad"
6 ~ 11  -> "dfggg4"
12 ~ 끝 -> "556b"
```

결과:

```text
["abc1Ad", "dfggg4", "556b"]
```

---

## 시간 복잡도

문자열 전체를 한 번 처리하므로 시간 복잡도는 **O(N)** 입니다.

## 핵심 정리

C#:

```csharp
my_str.Substring(i, Math.Min(n, my_str.Length - i))
```

Python:

```python
my_str[i:i + n]
```

핵심은 **문자열의 시작 위치를 `n`씩 증가시키면서 일정 길이로 자르는 것**입니다.
