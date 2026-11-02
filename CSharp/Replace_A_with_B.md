# 문자열 순서 바꾸기 — Python과 C# LINQ 풀이

## 문제 설명

문자열 `before`의 문자 순서를 바꾸어 `after`를 만들 수 있으면 `1`, 만들 수 없으면 `0`을 반환합니다.

**제한사항**
- `0 < before.length == after.length < 1,000`
- 두 문자열은 모두 소문자로 이루어져 있습니다.

| before | after | result |
|---|---|---:|
| `"olleh"` | `"hello"` | 1 |
| `"allpe"` | `"apple"` | 0 |

---

## 1. Python 풀이

```python
def solution(before, after):
    return int(sorted(before) == sorted(after))
```

- `sorted()`는 문자열을 문자 단위로 정렬하여 리스트를 반환합니다.
- `==`는 두 리스트의 원소와 순서가 같은지 비교합니다.
- `int()`는 `True`를 `1`, `False`를 `0`으로 바꿉니다.

---

## 2. C# LINQ 풀이

```csharp
using System;
using System.Linq;

public class Solution
{
    public int solution(string before, string after)
    {
        return before.OrderBy(c => c)
                     .SequenceEqual(after.OrderBy(c => c)) ? 1 : 0;
    }
}
```

| 메서드 / 연산자 | 설명 |
|---|---|
| `OrderBy(c => c)` | 각 문자를 오름차순으로 정렬합니다. |
| `SequenceEqual()` | 두 시퀀스의 원소가 순서대로 모두 동일한지 확인합니다. |
| `? 1 : 0` | 조건이 참이면 1, 거짓이면 0을 반환합니다. |

---

## 3. 동작 예시

```text
before = "olleh" → 정렬 → "ehllo"
after  = "hello" → 정렬 → "ehllo"
```

정렬 결과가 같으므로 `1`을 반환합니다.

반면 `"allpe"`는 `"aellp"`, `"apple"`은 `"aelpp"`로 정렬되어 서로 다르므로 `0`을 반환합니다.

---

## 4. 복잡도 분석

- **시간 복잡도:** `O(N log N)` — 정렬 수행
- **공간 복잡도:** `O(N)` — 정렬된 문자 시퀀스 저장

문자열 길이가 1,000 미만이므로 두 방법 모두 충분히 효율적입니다.

---

## 5. 영어 표현 교정

- 원문: `please make solution in python and c# linq`
- 자연스러운 표현: **Please provide solutions in Python and C# using LINQ.**

두 언어의 풀이를 요청하므로 `solutions`가 자연스럽고, `using LINQ`로 적용 대상을 명확히 표현할 수 있습니다.
