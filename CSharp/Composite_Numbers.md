# 합성수 찾기 (Composite Numbers) — C# & Python

## 1. 문제 설명 (Problem Description)

약수가 세 개 이상인 자연수를 **합성수(Composite Number)**라고 합니다. 자연수 `n` 이하의 합성수 개수를 반환하는 `solution` 함수를 작성합니다.

- 제한사항: `1 ≤ n ≤ 100`
- 1은 소수도 합성수도 아닙니다.
- 소수(Prime Number)는 약수가 정확히 2개입니다.

| n | result | 합성수 |
|---:|---:|---|
| 10 | 5 | 4, 6, 8, 9, 10 |
| 15 | 8 | 4, 6, 8, 9, 10, 12, 14, 15 |

---

## 2. 핵심 개념 (Key Concepts)

**나머지 연산자(Modulo Operator)** `%`를 사용합니다. `x % d == 0`이면 `d`는 `x`의 약수입니다.

| 자연수 | 약수 | 약수 개수 | 분류 |
|---:|---|---:|---|
| 1 | 1 | 1 | 해당 없음 |
| 2 | 1, 2 | 2 | 소수 |
| 4 | 1, 2, 4 | 3 | 합성수 |
| 6 | 1, 2, 3, 6 | 4 | 합성수 |
| 9 | 1, 3, 9 | 3 | 합성수 |

---

## 3. C# 풀이 (LINQ)

```csharp
using System;
using System.Linq;

public class Solution
{
    public int solution(int n)
    {
        // 1부터 n까지 자연수 중 약수가 3개 이상인 수를 계산
        return Enumerable.Range(1, n)
            .Count(x => Enumerable.Range(1, x)
                .Count(d => x % d == 0) >= 3);
    }
}
```

### 주요 메서드 및 문법

| 문법 | 설명 |
|---|---|
| `Enumerable.Range(1, n)` | 1부터 n까지 정수 생성 |
| `Count(predicate)` | 조건을 만족하는 요소의 개수 반환 |
| `x => ...` | 람다식(Lambda Expression) |
| `x % d == 0` | d가 x의 약수인지 검사 |
| `>= 3` | 약수가 3개 이상인지 검사 |

`Enumerable.Range(start, count)`의 두 번째 인수는 종료값이 아니라 **생성할 요소 개수**입니다.

---

## 4. Python 풀이

```python
def solution(n):
    # 각 자연수의 약수 개수를 구하고 합성수 개수를 합산
    return sum(
        sum(x % d == 0 for d in range(1, x + 1)) >= 3
        for x in range(1, n + 1)
    )
```

### 주요 함수 및 문법

| 문법 | 설명 |
|---|---|
| `range(1, n + 1)` | 1부터 n까지 정수 생성 |
| `sum()` | 요소들의 합 반환 |
| `for ... in ...` | 반복 처리 |
| `조건식 for ...` | 제너레이터 표현식(Generator Expression) |
| `True`, `False` | 합산 시 각각 1, 0으로 처리 |

리스트 컴프리헨션(List Comprehension)으로도 표현할 수 있습니다.

```python
def solution(n):
    return len([
        x for x in range(1, n + 1)
        if len([d for d in range(1, x + 1) if x % d == 0]) >= 3
    ])
```

제너레이터 방식은 중간 리스트를 생성하지 않습니다.

---

## 5. 코드 동작 과정 (Execution Flow)

`n = 10`인 경우:

| x | 약수 개수 | 합성수 여부 | 누적 개수 |
|---:|---:|---|---:|
| 1 | 1 | False | 0 |
| 2 | 2 | False | 0 |
| 3 | 2 | False | 0 |
| 4 | 3 | True | 1 |
| 5 | 2 | False | 1 |
| 6 | 4 | True | 2 |
| 7 | 2 | False | 2 |
| 8 | 4 | True | 3 |
| 9 | 3 | True | 4 |
| 10 | 4 | True | 5 |

최종 반환값은 `5`입니다.

---

## 6. 최적화 풀이 (Square Root Optimization)

합성수 `x`는 반드시 2 이상, √x 이하인 약수를 하나 이상 가집니다. 약수는 곱셈의 쌍으로 존재하기 때문입니다. 예를 들어 `36 = 4 × 9 = 6 × 6`입니다.

따라서 약수 개수를 모두 세지 않고 해당 범위에 약수가 하나라도 존재하는지 검사하면 됩니다.

### C# — LINQ Any()

```csharp
using System;
using System.Linq;

public class Solution
{
    public int solution(int n)
    {
        if (n < 4) return 0;

        // 4부터 n까지 제곱근 이하의 약수가 존재하는 수를 계산
        return Enumerable.Range(4, n - 3)
            .Count(x => Enumerable.Range(2, (int)Math.Sqrt(x) - 1)
                .Any(d => x % d == 0));
    }
}
```

### Python — any(), isqrt()

```python
from math import isqrt


def solution(n):
    # 2부터 정수 제곱근까지 약수가 하나라도 존재하는지 검사
    return sum(
        any(x % d == 0 for d in range(2, isqrt(x) + 1))
        for x in range(4, n + 1)
    )
```

| C# | Python | 역할 |
|---|---|---|
| `Any()` | `any()` | 조건을 만족하는 요소가 하나라도 존재하는지 검사 |
| `(int)Math.Sqrt(x)` | `isqrt(x)` | 양의 정수에 대해 제곱근의 정수 부분 계산 |
| `Count(predicate)` | `sum(조건식 ...)` | 조건을 만족하는 요소 개수 계산 |

`Any()`와 `any()`는 조건을 만족하는 첫 요소에서 탐색을 종료하는 **단락 평가(Short-circuit Evaluation)**를 수행합니다.

C#의 `Enumerable.Range(2, (int)Math.Sqrt(x) - 1)`은 2부터 제곱근의 정수 부분까지 생성합니다. Python의 `range`는 종료값을 포함하지 않으므로 `+ 1`이 필요합니다.

---

## 7. 시간 및 공간 복잡도 (Complexity)

| 풀이 | 시간 복잡도 (상한) | 보조 공간 복잡도 |
|---|---|---|
| 전체 약수 검사 (LINQ / 제너레이터) | O(n²) | O(1) |
| 리스트 컴프리헨션 | O(n²) | O(n) |
| 제곱근 + Any / any | O(n√n) | O(1) |

공간 복잡도는 입력과 반환값을 제외한 보조 공간 기준입니다. 제곱근 풀이는 단락 평가 덕분에 실제 검사 횟수가 더 적을 수 있습니다.

---

## 8. 테스트 케이스 (Test Cases)

| 입력 | 예상 출력 |
|---:|---:|
| 1 | 0 |
| 2 | 0 |
| 3 | 0 |
| 4 | 1 |
| 10 | 5 |
| 15 | 8 |
| 25 | 15 |
| 100 | 74 |

---

## 9. 참고 사항 및 결론 (Notes & Conclusion)

- 처음 학습할 때는 전체 약수 검사 방식으로 `Count()`와 `sum()`의 원리를 익히는 것이 좋습니다.
- 제출용으로는 제곱근과 `Any()` / `any()`를 활용한 풀이를 권장합니다.
- `1`을 합성수로 계산하지 않도록 주의합니다.
- 완전제곱수의 제곱근도 검사 범위에 포함해야 합니다.
- Python의 `isqrt()`는 Python 3.8 이상에서 사용할 수 있습니다.
- 입력 범위가 훨씬 커지면 에라토스테네스의 체(Sieve of Eratosthenes)도 고려할 수 있습니다.

---

## 10. 영어 표현 교정 (English Correction)

자연스러운 요청 문장:

> Please organize the solutions to this problem in C# and Python. If possible, use LINQ for the C# solution. Please provide the solutions in a downloadable Markdown file.

- `organize about this` → `organize the solutions to this problem`
- `c#`, `python`, `linq` → `C#`, `Python`, `LINQ`
- `make c# solution` → `write a C# solution`
- `a markdown file for downloading` → `a downloadable Markdown file`
