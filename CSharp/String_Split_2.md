# a, b, c를 구분자로 문자열 나누기

## 프로그램 설명 (Problem Description)

문자열 `myStr`이 주어졌을 때 문자 **`a`**, **`b`**, **`c`**를 구분자(Delimiter)로 사용하여 문자열을 나눕니다.

분리된 문자열 중 **빈 문자열은 저장하지 않으며**, 최종 결과가 비어 있다면 `["EMPTY"]`를 반환합니다.

### 예시

```text
입력
"baconlettucetomato"

구분자
a, b, c

출력
["onlettu", "etom", "to"]
```

문자열을 구분자 기준으로 보면 다음과 같이 나눌 수 있습니다.

```text
b | a | c | onlettu | c | etom | a | to
```

`a`, `b`, `c` 자체는 결과에 포함하지 않고, 그 사이에 있는 문자열만 저장합니다.

---

## 제한사항 (Constraints)

- `1 <= myStr.length <= 1,000,000`
- `myStr`은 알파벳 소문자로만 이루어져 있습니다.

문자열 길이가 최대 **1,000,000**이므로 모든 문자를 한 번씩 확인하는 **O(n)** 풀이가 적합합니다.

---

# C# 풀이

## C# 소스 코드

```csharp
using System;
using System.Collections.Generic;

public class Solution
{
    public string[] solution(string myStr)
    {
        // a, b, c를 모두 구분자로 사용하여 문자열 분리
        string[] splitResult = myStr.Split(
            new char[] { 'a', 'b', 'c' },
            StringSplitOptions.RemoveEmptyEntries
        );

        // 분리된 문자열이 하나도 없다면 "EMPTY" 반환
        if (splitResult.Length == 0)
        {
            return new string[] { "EMPTY" };
        }

        return splitResult;
    }
}
```

---

## C# 핵심 문법 설명

| 문법 / 메서드 | 설명 |
|---|---|
| `string.Split()` | 문자열을 특정 문자를 기준으로 나눕니다. |
| `new char[] { 'a', 'b', 'c' }` | 여러 개의 구분자를 지정합니다. |
| `StringSplitOptions.RemoveEmptyEntries` | 구분자가 연속되어 생기는 빈 문자열을 결과에서 제거합니다. |
| `splitResult.Length` | 분리된 문자열 배열의 원소 개수를 확인합니다. |
| `new string[] { "EMPTY" }` | `"EMPTY"` 하나를 가진 문자열 배열을 생성합니다. |

---

## C# 코드 동작 과정

예를 들어 다음 문자열이 주어졌다고 가정합니다.

```text
"baconlettucetomato"
```

`a`, `b`, `c`를 구분자로 지정하면 다음과 같이 처리됩니다.

```text
b a c onlettu c etom a to
↓ ↓ ↓         ↓      ↓
구분자         구분자
```

`StringSplitOptions.RemoveEmptyEntries`를 사용했기 때문에 구분자끼리 붙어 있어 발생하는 빈 문자열은 자동으로 제거됩니다.

최종 결과는 다음과 같습니다.

```text
["onlettu", "etom", "to"]
```

---

## C# 다른 풀이 - 정규식(Regex)

정규식을 사용하면 더 짧게 작성할 수도 있습니다.

```csharp
using System.Linq;
using System.Text.RegularExpressions;

public class Solution
{
    public string[] solution(string myStr)
    {
        string[] answer = Regex.Split(myStr, "[abc]")
                               .Where(x => x.Length > 0)
                               .ToArray();

        return answer.Length == 0
            ? new string[] { "EMPTY" }
            : answer;
    }
}
```

다만 이 문제에서는 단순히 세 문자만 구분자로 사용하므로 **`string.Split()` 방식이 더 간단하고 적절합니다.**

---

# Python 풀이

## Python 소스 코드

Python의 기본 `str.split()`은 여러 개의 서로 다른 구분자를 한 번에 지정할 수 없습니다.

따라서 정규식(Regular Expression)을 사용하면 간단하게 해결할 수 있습니다.

```python
import re

def solution(myStr):
    # a, b, c 중 하나를 기준으로 문자열 분리
    result = [s for s in re.split(r'[abc]', myStr) if s]

    # 결과가 비어 있다면 ["EMPTY"] 반환
    return result if result else ["EMPTY"]
```

---

## Python 핵심 문법 설명

| 문법 / 함수 | 설명 |
|---|---|
| `import re` | Python의 정규식 모듈을 가져옵니다. |
| `re.split(r'[abc]', myStr)` | `a`, `b`, `c` 중 하나를 만날 때마다 문자열을 나눕니다. |
| `[abc]` | `a`, `b`, `c` 중 문자 하나를 의미하는 정규식입니다. |
| `[s for s in ... if s]` | 빈 문자열을 제외한 값만 리스트에 저장합니다. |
| `result if result else ["EMPTY"]` | 결과가 존재하면 `result`, 없으면 `["EMPTY"]`를 반환합니다. |

---

## Python 코드 동작 과정

입력이 다음과 같다고 가정합니다.

```python
myStr = "baconlettucetomato"
```

먼저 다음 코드가 실행됩니다.

```python
re.split(r'[abc]', myStr)
```

중간 결과는 다음과 같이 빈 문자열을 포함할 수 있습니다.

```python
['', '', '', 'onlettu', 'etom', 'to']
```

리스트 컴프리헨션(List Comprehension)을 이용해 빈 문자열을 제거합니다.

```python
[s for s in re.split(r'[abc]', myStr) if s]
```

결과:

```python
['onlettu', 'etom', 'to']
```

---

# 입출력 예시

## 예제 1

### 입력

```text
"baconlettucetomato"
```

### 출력

```text
["onlettu", "etom", "to"]
```

### 설명

`a`, `b`, `c`를 구분자로 문자열을 나누면 다음 문자열들이 남습니다.

```text
onlettu
etom
to
```

---

## 예제 2

### 입력

```text
"abcd"
```

### 출력

```text
["d"]
```

### 설명

`a`, `b`, `c`가 모두 구분자로 제거되고 마지막 문자 `d`만 남습니다.

---

## 예제 3

### 입력

```text
"cabab"
```

### 출력

```text
["EMPTY"]
```

### 설명

문자열 전체가 `a`, `b`, `c`로만 이루어져 있으므로 저장할 문자열이 없습니다.

따라서 다음 배열을 반환합니다.

```text
["EMPTY"]
```

---

# 시간 복잡도 (Time Complexity)

문자열의 길이를 `n`이라고 할 때 각 문자를 한 번씩 확인하여 분리하므로 시간 복잡도는 다음과 같습니다.

```text
O(n)
```

결과 문자열을 저장하기 위한 공간이 필요하므로 공간 복잡도 역시 최악의 경우 다음과 같습니다.

```text
O(n)
```

문제에서 문자열 길이가 최대 `1,000,000`이기 때문에 **O(n)** 방식은 충분히 효율적입니다.

---

# 핵심 정리

이 문제에서 중요한 부분은 다음 두 가지입니다.

1. **`a`, `b`, `c`를 모두 구분자로 사용한다.**
2. **구분자 사이에 문자가 없어서 생기는 빈 문자열은 결과에 포함하지 않는다.**

C#에서는 다음 옵션을 이용하면 빈 문자열 제거까지 한 번에 처리할 수 있습니다.

```csharp
StringSplitOptions.RemoveEmptyEntries
```

Python에서는 정규식의 문자 집합(Character Class)을 사용합니다.

```python
[abc]
```

따라서 이 문제는 다음과 같이 기억하면 됩니다.

```text
C#     -> string.Split() + RemoveEmptyEntries
Python -> re.split() + 빈 문자열 제거
```
