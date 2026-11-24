# 특정 문자 제거하기 (Remove a Character from a String)

## 1. 문제 설명 (Problem Description)

문자열 `my_string`과 길이가 1인 문자 `letter`가 주어집니다. `my_string`에 등장하는 **모든 `letter`를 제거한 문자열**을 반환하는 `solution` 함수를 작성합니다.

### 제한사항

- `1 ≤ my_string.Length ≤ 100`
- `letter`는 길이가 1인 영문자입니다.
- 입력은 영어 대문자와 소문자로 이루어집니다.
- **대문자와 소문자를 구분**합니다.

### 입출력 예

| my_string | letter | result |
|---|---|---|
| `"abcdef"` | `"f"` | `"abcde"` |
| `"BCBdbe"` | `"B"` | `"Cdbe"` |

---

## 2. C# 풀이 — LINQ 활용 (C# Solution with LINQ)

```csharp
using System;
using System.Linq;

public class Solution
{
    public string solution(string my_string, string letter)
    {
        // letter[0]과 다른 문자만 필터링한 후 다시 문자열로 결합합니다.
        return new string(my_string.Where(c => c != letter[0]).ToArray());
    }
}
```

### 주요 메서드 및 문법 설명

| 문법 | 설명 |
|---|---|
| `using System.Linq;` | LINQ 확장 메서드를 사용할 수 있도록 네임스페이스를 가져옵니다. |
| `letter[0]` | 길이가 1인 문자열에서 비교할 `char` 값을 가져옵니다. |
| `Where(c => c != letter[0])` | `letter`와 **다른** 문자만 남기는 필터입니다. |
| `c => ...` | 각 문자에 적용되는 **람다 표현식(Lambda Expression)**입니다. |
| `ToArray()` | 필터링된 문자들을 `char[]` 배열로 변환합니다. |
| `new string(char[])` | 문자 배열을 새로운 문자열로 생성합니다. |

### 실행 예시

```csharp
using System;
using System.Linq;

public class Solution
{
    public string solution(string my_string, string letter)
    {
        return new string(my_string.Where(c => c != letter[0]).ToArray());
    }
}

public class Program
{
    public static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.solution("abcdef", "f")); // abcde
        Console.WriteLine(s.solution("BCBdbe", "B")); // Cdbe
    }
}
```

### 동작 과정

입력: `my_string = "BCBdbe"`, `letter = "B"`

1. `my_string`의 각 문자 `B`, `C`, `B`, `d`, `b`, `e`를 순회합니다.
2. `Where()`에서 `B`와 같은 문자는 제외합니다.
3. 남은 문자 `C`, `d`, `b`, `e`를 배열로 변환합니다.
4. 배열을 문자열 `"Cdbe"`로 만들어 반환합니다.

---

## 3. Python 풀이 — 컴프리헨션 활용 (Python Solution with Comprehension)

```python
def solution(my_string, letter):
    # letter와 다른 문자만 선택하여 하나의 문자열로 합칩니다.
    return ''.join(c for c in my_string if c != letter)
```

### 주요 메서드 및 문법 설명

| 문법 | 설명 |
|---|---|
| `for c in my_string` | 문자열에서 문자를 하나씩 순회합니다. |
| `if c != letter` | 제거할 문자와 다른 문자만 선택합니다. |
| `(c for c in ... if ...)` | 조건에 맞는 문자를 생성하는 **제너레이터 표현식(Generator Expression)**입니다. |
| `''.join(...)` | 선택한 문자들을 구분자 없이 하나의 문자열로 연결합니다. |

### 실행 예시

```python
def solution(my_string, letter):
    return ''.join(c for c in my_string if c != letter)

print(solution('abcdef', 'f'))  # abcde
print(solution('BCBdbe', 'B'))  # Cdbe
```

### Python의 간단한 대안: `replace()`

```python
def solution(my_string, letter):
    return my_string.replace(letter, '')
```

`str.replace(old, new)`는 문자열에 등장하는 `old`를 모두 `new`로 바꿉니다. 여기서는 빈 문자열 `''`로 바꾸므로 해당 문자가 삭제됩니다.

---

## 4. C#과 Python 비교 (Comparison)

| 항목 | C# (LINQ) | Python (컴프리헨션) |
|---|---|---|
| 문자 선택 | `Where(c => c != letter[0])` | `c for c in my_string if c != letter` |
| 결과 결합 | `new string(...ToArray())` | `''.join(...)` |
| 시간 복잡도 | **O(n)** | **O(n)** |
| 추가 공간 복잡도 | **O(n)** | **O(n)** |

여기서 `n`은 `my_string`의 길이입니다. 두 구현 모두 문자열을 한 번 순회하며 결과를 생성합니다.

## 5. 참고 사항 (Notes)

- 문자열에서 지정한 문자가 **여러 번 나타나도 모두 제거**해야 합니다.
- 대소문자를 구분하므로 `"B"`를 지울 때 `"b"`는 유지됩니다.
- C#의 `letter`는 `string` 타입이므로 `char`와 비교하려면 `letter[0]`을 사용합니다.
- C#에서는 간단히 `my_string.Replace(letter, "")`로도 풀 수 있지만, 이 문서에서는 **LINQ 연습을 위해 `Where()` 방식**을 우선 사용했습니다.
