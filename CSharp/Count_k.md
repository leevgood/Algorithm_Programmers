# [Lecture Summary] C#과 Python으로 숫자 k의 등장 횟수 구하기

## 개요 (Overview)

정수 `i`, `j`, `k`가 주어질 때, `i`부터 `j`까지 모든 정수에서 숫자 `k`가 등장하는 **총횟수**를 구합니다.

예를 들어 `i=1`, `j=13`, `k=1`이라면 `1`, `10`, `11`, `12`, `13`에 등장하는 `1`의 개수는 각각 1, 1, 2, 1, 1이므로 정답은 **6**입니다. `11`의 `1`을 두 번 세는 것이 중요합니다.

| i | j | k | 결과 |
|---|---|---|---|
| 1 | 13 | 1 | 6 |
| 10 | 50 | 5 | 5 |
| 3 | 10 | 2 | 0 |

---

## 주요 개념 및 아키텍처 (Key Concepts & Architecture)

> **반복 → 문자열 변환(String Conversion) → 등장 횟수 계산(Counting) → 합산(Summation)**

각 정수를 문자열로 바꾸면 자릿수를 손쉽게 검사할 수 있습니다.

| 기능 | C# | Python |
|---|---|---|
| 정수 범위 생성 | `Enumerable.Range(i, j - i + 1)` | `range(i, j + 1)` |
| 문자열 변환 | `ToString()` | `str()` |
| 조건에 맞는 문자 개수 | LINQ `Count(predicate)` | 문자열 `count(substring)` |
| 합산 | `Sum()` | `sum()` |

**주의:** C#의 `Contains()`는 등장 횟수가 아닌 **포함 여부**를 반환합니다. 따라서 `"11".Contains("1")`은 `true`지만 `1`이 두 번 나왔다는 정보는 주지 않습니다.

---

## 상세 구현 (Detailed Implementation)

### 1. C# — 원본 LINQ 풀이

```csharp
using System;
using System.Linq;

public class Solution {
    public int solution(int i, int j, int k) =>
        Enumerable.Range(i, j - i + 1)
            .Select(x => x.ToString()
                .Where(y => y.Equals(k.ToString().First()))
                .Count())
            .Sum();
}
```

1. **`Enumerable.Range(i, j - i + 1)`**는 시작값 `i`부터 총 `j-i+1`개의 정수를 만듭니다.
2. **`Select()`**는 각 정수를 해당 숫자 안에서 `k`가 등장한 횟수로 변환합니다.
3. **`ToString()`**으로 숫자를 문자열로 변환합니다.
4. **`Where()`**는 목표 문자와 일치하는 문자만 선택하고 **`Count()`**는 그 개수를 셉니다.
5. **`Sum()`**은 각 숫자의 등장 횟수를 모두 합칩니다.

### 2. C# — 간결하게 개선한 풀이

```csharp
using System;
using System.Linq;

public class Solution {
    public int solution(int i, int j, int k) {
        char target = k.ToString()[0]; // 찾을 숫자를 문자로 변환

        return Enumerable.Range(i, j - i + 1)
            .Sum(n => n.ToString().Count(c => c == target));
    }
}
```

**`Count(c => c == target)`**는 `Where(...).Count()`를 하나의 메서드로 표현합니다. 문제에서 `k`는 한 자리 숫자이므로 `k.ToString()[0]`을 사용합니다.

### 3. Python — 원본 리스트 컴프리헨션(List Comprehension) 풀이

```python
def solution(i, j, k):
    answer = sum([str(n).count(str(k)) for n in range(i, j + 1)])
    return answer
```

- **`range(i, j + 1)`**는 `i`부터 `j`까지 순회합니다. 끝값은 포함되지 않으므로 `j+1`을 사용합니다.
- **`str(n).count(str(k))`**는 해당 정수에서 `k`의 등장 횟수를 계산합니다.
- **리스트 컴프리헨션(List Comprehension)**은 각 정수의 등장 횟수를 리스트로 만듭니다.
- **`sum()`**은 해당 리스트의 요소를 모두 더합니다.

### 4. Python — 제너레이터 표현식(Generator Expression)으로 개선

```python
def solution(i, j, k):
    return sum(str(n).count(str(k)) for n in range(i, j + 1))
```

대괄호 `[]`를 제거하면 중간 리스트를 만들지 않고 합계를 계산할 수 있습니다.

### 5. 예제 실행 과정

입력: `i=1`, `j=13`, `k=1`

```text
숫자:       1  2  3  4  5  6  7  8  9 10 11 12 13
등장 횟수:  1  0  0  0  0  0  0  0  0  1  2  1  1
합계: 6
```

Python에서 `"11".count("1")`은 `2`이며, C#에서 `"11".Count(c => c == '1')` 역시 `2`입니다.

### 6. 시간 및 공간 복잡도

`N = j - i + 1`, `D = 범위 내 정수의 최대 자릿수`라고 할 때:

- **시간 복잡도(Time Complexity):** `O(N × D)` — 각 정수를 문자 단위로 검사합니다.
- **공간 복잡도(Space Complexity):** 개선한 C# LINQ 및 Python 제너레이터 풀이에는 문자열 변환을 위한 `O(D)` 수준의 보조 공간이 필요합니다. Python 리스트 컴프리헨션은 결과 리스트에 `O(N)` 공간을 추가로 사용합니다.

---

## 활용 사례 및 결론 (Use Cases & Conclusion)

이 문제를 통해 **문자열 변환(String Conversion)**, **LINQ**, **리스트 컴프리헨션(List Comprehension)**, **제너레이터 표현식(Generator Expression)**, **조건부 개수 계산(Conditional Counting)**을 연습할 수 있습니다.

**실무 팁:** `Contains()`처럼 존재 여부만 검사하는 메서드와 `Count()`처럼 개수를 세는 메서드를 구분해야 합니다. Python의 문자열 `count()`와 C# LINQ의 `Count(predicate)`는 사용 방식은 다르지만 이 문제에서 같은 목적을 달성합니다.

**최종 추천 코드**

C#:

```csharp
using System;
using System.Linq;

public class Solution {
    public int solution(int i, int j, int k) {
        char target = k.ToString()[0];
        return Enumerable.Range(i, j - i + 1)
            .Sum(n => n.ToString().Count(c => c == target));
    }
}
```

Python:

```python
def solution(i, j, k):
    return sum(str(n).count(str(k)) for n in range(i, j + 1))
```

> **결론:** 언어별 문법은 달라도 핵심 알고리즘은 동일합니다. 각 정수의 자릿수에서 `k`의 등장 횟수를 센 뒤, 그 결과를 모두 더합니다.
