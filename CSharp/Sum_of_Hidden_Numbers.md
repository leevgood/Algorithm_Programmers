# 문자열 안의 자연수 합 구하기 (Sum of Numbers in a String)

## 1. 문제 개요 (Overview)

영문 대·소문자와 숫자로 이루어진 문자열 `my_string`에서 **연속된 숫자들을 각각 하나의 자연수로 인식**하고, 그 합을 반환합니다. 자연수가 없으면 `0`을 반환합니다.

- 입력: `"aAb1B2cC34oOp"`
- 자연수 추출: `1`, `2`, `34`
- 출력: `37`

### 제한사항

- 문자열 길이: 1~1,000자
- 문자열 속 자연수의 크기: 1~1,000
- 연속된 숫자는 하나의 수로 처리
- `000123`처럼 0으로 시작하는 수는 주어지지 않음
- 숫자가 없는 경우 `0` 반환

### 입출력 예

| `my_string` | `result` |
|---|---:|
| `"aAb1B2cC34oOp"` | `37` |
| `"1a2b3c4d123Z"` | `133` |
| `"abcXYZ"` | `0` |

---

## 2. 핵심 아이디어 (Key Concepts)

**정규 표현식(Regular Expression)** `\d+`로 연속된 숫자를 한 덩어리로 추출한 다음, **합계(Sum)**를 계산합니다.

> `\d`는 숫자 한 글자를, `+`는 바로 앞 패턴이 한 번 이상 반복됨을 뜻합니다. 따라서 `\d+`는 `34`, `123` 같은 연속된 숫자 전체를 매칭합니다.

예: `"a1b23c456"` → `["1", "23", "456"]` → `1 + 23 + 456 = 480`

---

## 3. C# 풀이 — LINQ 활용

### 제출용 코드

```csharp
using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Solution
{
    public int solution(string my_string)
    {
        return Regex.Matches(my_string, @"\d+")
                    .Cast<Match>()
                    .Sum(match => int.Parse(match.Value));
    }
}
```

### 주요 메서드 및 문법

| 코드 | 역할 |
|---|---|
| `Regex.Matches(my_string, @"\d+")` | 연속된 숫자 부분을 모두 찾음 |
| `@"\d+"` | C#의 축자 문자열 리터럴(Verbatim String Literal). 역슬래시를 그대로 표현 |
| `.Cast<Match>()` | `MatchCollection`을 LINQ에서 순회 가능한 `IEnumerable<Match>`로 변환 |
| `match.Value` | 일치한 숫자 문자열을 추출 |
| `int.Parse(...)` | 숫자 문자열을 정수로 변환 |
| `.Sum(...)` | 변환한 정수를 모두 합산 |

### 처리 과정

```text
입력: "aAb1B2cC34oOp"
Regex.Matches → "1", "2", "34"
Cast<Match>() → 각 Match를 LINQ로 순회
int.Parse()   → 1, 2, 34
Sum()         → 37
```

> **숫자가 없는 경우:** `Regex.Matches`는 빈 컬렉션을 반환하며, LINQ의 정수 `Sum()`은 `0`을 반환합니다.

---

## 4. Python 풀이 — re.findall 활용

### 제출용 코드

```python
import re

def solution(my_string):
    return sum(map(int, re.findall(r"\d+", my_string)))
```

### 주요 함수 및 문법

| 코드 | 역할 |
|---|---|
| `import re` | 정규 표현식 모듈 불러오기 |
| `re.findall(r"\d+", my_string)` | 연속된 숫자 문자열을 리스트로 추출 |
| `r"\d+"` | Python의 원시 문자열(Raw String)로 정규식 표현 |
| `map(int, ...)` | 추출된 각 문자열을 정수로 변환 |
| `sum(...)` | 정수들을 모두 더함 |

### 처리 과정

```text
입력: "1a2b3c4d123Z"
re.findall() → ["1", "2", "3", "4", "123"]
map(int, ...) → 1, 2, 3, 4, 123
sum(...)     → 133
```

> **숫자가 없는 경우:** `re.findall`은 빈 리스트 `[]`를 반환하며, `sum([])`은 `0`입니다.

---

## 5. 정규식 없이 푸는 방법 (추가 학습)

숫자를 한 글자씩 읽으면서 누적해도 됩니다. 숫자가 끝나고 문자가 나타나면 누적값을 합계에 더합니다.

### C# — 반복문

```csharp
public class Solution
{
    public int solution(string my_string)
    {
        int total = 0;
        int number = 0;

        foreach (char ch in my_string)
        {
            if (ch >= '0' && ch <= '9')
            {
                number = number * 10 + (ch - '0'); // 연속된 숫자 누적
            }
            else
            {
                total += number; // 숫자 구간이 끝나면 합산
                number = 0;
            }
        }

        return total + number; // 문자열 마지막이 숫자인 경우까지 처리
    }
}
```

### Python — 반복문

```python
def solution(my_string):
    total = 0
    number = 0

    for ch in my_string:
        if '0' <= ch <= '9':
            number = number * 10 + int(ch)  # 연속된 숫자 누적
        else:
            total += number                 # 구간 종료 시 합산
            number = 0

    return total + number  # 마지막 숫자 구간 처리
```

---

## 6. 시간·공간 복잡도 (Complexity)

`n`은 문자열 길이입니다.

| 풀이 | 시간 복잡도 | 추가 공간 복잡도 |
|---|---|---|
| C# 정규식 + LINQ | `O(n)` | `O(n)` |
| Python 정규식 + `map`/`sum` | `O(n)` | `O(n)` |
| C# / Python 직접 순회 | `O(n)` | `O(1)` |

정규식은 추출 결과를 저장하기 때문에 추가 공간이 필요합니다. 직접 순회 방식은 합계와 현재 숫자만 저장하므로 공간 사용이 적습니다. 위 복잡도는 문제의 숫자 길이 제한을 전제로 합니다.

---

## 7. 활용 사례 및 결론 (Use Cases & Conclusion)

- **정규식 + LINQ(C#)**: 짧고 선언적인 코드로 숫자 추출과 합산을 표현할 수 있어 추천합니다.
- **`re.findall` + `sum`(Python)**: 같은 아이디어를 간결한 한 줄로 구현할 수 있습니다.
- **직접 순회 방식**: 정규식 없이 문자열 파싱(Parsing)과 숫자 누적 원리를 이해할 때 유용합니다.

**핵심:** 한 자리 숫자를 각각 더하는 것이 아니라, `\d+`로 **연속된 숫자를 하나의 수로 묶어** 합산해야 합니다.
