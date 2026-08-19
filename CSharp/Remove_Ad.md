# 문자열 배열에서 "ad"가 포함된 문자열 제거

## 문제 설명

문자열 배열 `strArr`가 주어집니다.

배열 내의 문자열 중 `"ad"`라는 부분 문자열을 포함하고 있는 모든 문자열을 제거하고, 남은 문자열을 기존 순서를 유지하여 배열로 반환하는 `solution` 함수를 작성합니다.

---

## 제한사항

- `1 ≤ strArr.length ≤ 1,000`
- `1 ≤ strArr[i].length ≤ 20`
- `strArr`의 원소는 알파벳 소문자로 이루어진 문자열입니다.

---

## 입출력 예

| strArr | result |
|---|---|
| `["and","notad","abcd"]` | `["and","abcd"]` |
| `["there","are","no","a","ds"]` | `["there","are","no","a","ds"]` |

---

## 입출력 예 설명

### 예제 1

```text
["and", "notad", "abcd"]
```

`"notad"`에는 부분 문자열 `"ad"`가 포함되어 있습니다.

따라서 `"notad"`를 제거하고 나머지 문자열의 순서를 유지합니다.

```text
["and", "abcd"]
```

### 예제 2

```text
["there", "are", "no", "a", "ds"]
```

모든 문자열에 `"ad"`가 포함되어 있지 않으므로 원래 배열을 그대로 반환합니다.

---

## 문제 해결 아이디어

배열의 문자열을 처음부터 하나씩 확인합니다.

각 문자열에 `"ad"`가 포함되어 있는지 검사하고,

- `"ad"`가 포함되어 있으면 제거
- `"ad"`가 포함되어 있지 않으면 결과에 추가

하면 됩니다.

핵심 로직은 다음과 같습니다.

```text
문자열 확인
    ↓
"ad"가 포함되어 있는가?
    ↓
Yes → 제외
No  → 결과에 추가
```

---

# C# 풀이

## 기본 풀이

```csharp
using System;
using System.Collections.Generic;

public class Solution
{
    public string[] solution(string[] strArr)
    {
        // 조건을 만족하는 문자열을 저장할 리스트
        List<string> answer = new List<string>();

        foreach (string str in strArr)
        {
            // "ad"가 포함되어 있지 않은 문자열만 추가
            if (!str.Contains("ad"))
            {
                answer.Add(str);
            }
        }

        // List<string>을 string[]으로 변환
        return answer.ToArray();
    }
}
```

---

## C# 주요 메서드 및 문법

| 문법 | 설명 |
|---|---|
| `foreach` | 배열의 요소를 하나씩 순회합니다. |
| `Contains("ad")` | 문자열 안에 `"ad"`가 포함되어 있는지 확인합니다. |
| `!` | 논리 NOT 연산자로 조건의 결과를 반대로 바꿉니다. |
| `List<string>` | 크기를 동적으로 변경할 수 있는 문자열 리스트입니다. |
| `Add()` | 리스트에 새로운 요소를 추가합니다. |
| `ToArray()` | 리스트를 배열로 변환합니다. |

---

## C# 핵심 코드

```csharp
if (!str.Contains("ad"))
```

`Contains("ad")`는 문자열에 `"ad"`가 포함되어 있으면 `true`를 반환합니다.

문제에서는 `"ad"`가 없는 문자열만 남겨야 하므로 `!` 연산자를 사용합니다.

```csharp
!str.Contains("ad")
```

예를 들어 다음과 같이 동작합니다.

```text
"and"   → Contains("ad") = false → 추가
"notad" → Contains("ad") = true  → 제거
"abcd"  → Contains("ad") = false → 추가
```

---

## C# LINQ 풀이

LINQ를 사용하면 코드를 더 간결하게 작성할 수 있습니다.

```csharp
using System;
using System.Linq;

public class Solution
{
    public string[] solution(string[] strArr)
    {
        return strArr
            .Where(str => !str.Contains("ad"))
            .ToArray();
    }
}
```

핵심 코드는 다음과 같습니다.

```csharp
.Where(str => !str.Contains("ad"))
```

`Where()`는 조건이 `true`인 요소만 선택합니다.

따라서 `"ad"`가 포함되지 않은 문자열만 남게 됩니다.

---

# Python 풀이

## 기본 풀이

```python
def solution(strArr):
    answer = []

    for string in strArr:
        # "ad"가 포함되어 있지 않은 문자열만 추가
        if "ad" not in string:
            answer.append(string)

    return answer
```

Python에서는 문자열 포함 여부를 `in` 연산자로 검사할 수 있습니다.

```python
"ad" in string
```

반대로 `"ad"`가 없는지 확인하려면 다음과 같이 작성합니다.

```python
"ad" not in string
```

---

## Python 리스트 컴프리헨션 풀이

Python에서는 리스트 컴프리헨션(List Comprehension)을 사용하면 한 줄로 작성할 수 있습니다.

```python
def solution(strArr):
    return [string for string in strArr if "ad" not in string]
```

다음 코드는

```python
[string for string in strArr if "ad" not in string]
```

아래와 같은 의미입니다.

```text
strArr의 문자열을 하나씩 확인
        ↓
"ad"가 포함되어 있지 않은가?
        ↓
       Yes
        ↓
결과 리스트에 포함
```

---

# 동작 과정

입력이 다음과 같다고 가정합니다.

```text
["and", "notad", "abcd"]
```

### 1단계

```text
"and"
```

`"ad"`가 포함되어 있지 않습니다.

따라서 결과에 추가합니다.

```text
["and"]
```

### 2단계

```text
"notad"
```

`"ad"`가 포함되어 있습니다.

따라서 결과에 추가하지 않습니다.

```text
["and"]
```

### 3단계

```text
"abcd"
```

`"ad"`가 포함되어 있지 않습니다.

따라서 결과에 추가합니다.

```text
["and", "abcd"]
```

최종 결과:

```text
["and", "abcd"]
```

---

# 시간 복잡도

`strArr`의 길이를 `N`, 각 문자열의 최대 길이를 `M`이라고 하면 각 문자열에서 `"ad"`를 검색해야 합니다.

따라서 시간 복잡도는 다음과 같습니다.

```text
O(N × M)
```

문제의 제한은 다음과 같습니다.

```text
N ≤ 1,000
M ≤ 20
```

따라서 충분히 빠르게 처리할 수 있습니다.

---

# 정리

이 문제의 핵심은 **문자열 포함 여부를 검사한 뒤 조건에 맞는 문자열만 필터링하는 것**입니다.

C#에서는 다음 조건을 사용합니다.

```csharp
!str.Contains("ad")
```

Python에서는 다음 조건을 사용합니다.

```python
"ad" not in string
```

C#에서 LINQ에 익숙하다면 다음 풀이가 간결합니다.

```csharp
return strArr
    .Where(str => !str.Contains("ad"))
    .ToArray();
```

Python에서는 리스트 컴프리헨션을 사용한 풀이가 간결합니다.

```python
return [string for string in strArr if "ad" not in string]
```
