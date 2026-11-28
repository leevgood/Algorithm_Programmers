# 외계행성의 나이 (Alien Planet Age)

## 1. 문제 설명 (Overview)

정수 `age`의 각 자릿수를 `0 → a`, `1 → b`, …, `9 → j` 규칙에 따라 변환한 문자열을 반환합니다. 음이 아닌 정수를 전제로 합니다.

| 숫자 | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |
|---|---|---|---|---|---|---|---|---|---|---|
| 문자 | a | b | c | d | e | f | g | h | i | j |

---

## 2. C# 풀이 — LINQ (추천)

```csharp
using System.Linq;

public class Solution
{
    public string solution(int age)
    {
        // 각 숫자 문자를 알파벳으로 변환하고 하나의 문자열로 연결
        return string.Concat(
            age.ToString().Select(c => (char)(c - '0' + 'a'))
        );
    }
}
```

### 주요 메서드 및 문법

| 문법 | 설명 |
|---|---|
| `age.ToString()` | 정수를 문자열로 변환 |
| `Select(c => ...)` | 각 문자에 변환 함수를 적용하는 LINQ 메서드 |
| `c - '0'` | 숫자 문자를 실제 정수 값으로 변환 |
| `(char)(...)` | 정수 문자 코드를 문자로 형 변환 |
| `string.Concat()` | 문자 시퀀스를 하나의 문자열로 연결 |

### 대체 풀이: 문자열 인덱싱

```csharp
using System.Linq;

public class Solution
{
    public string solution(int age)
    {
        return string.Concat(
            age.ToString().Select(c => "abcdefghij"[c - '0'])
        );
    }
}
```

### 대체 풀이: 문자 배열 생성

```csharp
using System.Linq;

public class Solution
{
    public string solution(int age)
    {
        return new string(age.ToString()
            .Select(c => (char)(c - '0' + 'a'))
            .ToArray());
    }
}
```

---

## 3. Python 풀이

```python
def solution(age):
    # 각 자릿수를 알파벳으로 변환하고 문자열로 연결
    return ''.join(chr(int(c) + ord('a')) for c in str(age))
```

### 주요 메서드 및 문법

| 문법 | 설명 |
|---|---|
| `str(age)` | 정수를 문자열로 변환 |
| `int(c)` | 숫자 문자를 정수로 변환 |
| `ord('a')` | 문자 a의 유니코드 코드 포인트(97) 반환 |
| `chr(n)` | 코드 포인트를 문자로 변환 |
| `for c in str(age)` | 각 자릿수를 순회하는 제너레이터 표현식의 일부 |
| `''.join(...)` | 구분자 없이 문자열 연결 |

### 대체 풀이: 문자열 인덱싱

```python
def solution(age):
    return ''.join('abcdefghij'[int(c)] for c in str(age))
```

---

## 4. 입력 및 출력 예시 (Examples)

| 입력 age | 출력 |
|---:|---|
| 23 | `cd` |
| 51 | `fb` |
| 100 | `baa` |
| 0 | `a` |
| 9876543210 | `jihgfedcba` (Python 예시, C# int 범위 초과) |

### 실행 과정: age = 23

1. 정수 `23`을 문자열 `"23"`으로 변환합니다.
2. 문자 `'2'`를 정수 2로 변환한 후 `'a'`의 코드 값 97을 더합니다. 결과 99는 `'c'`입니다.
3. 문자 `'3'`도 같은 방식으로 `'d'`로 변환합니다.
4. 두 문자를 연결하여 `"cd"`를 반환합니다.

| 문자 | 문자 코드 | 숫자 값 | 변환 코드 | 결과 |
|---|---:|---:|---:|---|
| '2' | 50 | 2 | 99 | c |
| '3' | 51 | 3 | 100 | d |

---

## 5. 기존 코드 오류 분석

```csharp
return age.ToString().Select(c => char(int(c) + int('a')))
    .ToString();
```

- **형 변환:** C#에서는 `int(c)`, `char(n)`이 아니라 `(int)c`, `(char)n`을 사용합니다.
- **숫자 문자 변환:** `(int)'2'`는 2가 아니라 50입니다. `c - '0'`으로 숫자 값을 구해야 합니다.
- **문자열 연결:** `Select()`의 반환값은 `IEnumerable<char>`입니다. `ToString()`은 문자들을 연결하지 않습니다. `string.Concat()` 또는 `new string(...ToArray())`를 사용합니다.

---

## 6. C#과 Python 문법 비교

| 기능 | C# | Python |
|---|---|---|
| 정수 → 문자열 | `age.ToString()` | `str(age)` |
| 숫자 문자 → 정수 | `c - '0'` | `int(c)` |
| 문자 → 문자 코드 | `(int)c` | `ord(c)` |
| 문자 코드 → 문자 | `(char)n` | `chr(n)` |
| 원소 변환 | `Select()` | 제너레이터 표현식 |
| 문자열 연결 | `string.Concat()` | `''.join()` |

---

## 7. 시간 및 공간 복잡도 (Complexity)

자릿수를 d라고 할 때 시간 복잡도는 **O(d)**, 결과 문자열과 중간 저장 공간을 포함한 공간 복잡도는 **O(d)**입니다.

## 8. 참고 사항 (Notes)

- LINQ의 `Select()`는 지연 실행되며 `string.Concat()`에서 결과를 열거합니다.
- 문자열 인덱싱 방식은 문자 코드 계산을 직접 작성하지 않아도 됩니다.
- 원문 문제의 정확한 제한사항은 제공되지 않았으므로 음이 아닌 정수라는 가정으로 정리했습니다.
- Python 예시는 실행 검증했으며 C#은 별도 컴파일 검증하지 않았습니다.
