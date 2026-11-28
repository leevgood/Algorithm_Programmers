# 최댓값 만들기 (2) — Python & C# LINQ

## 1. 문제 설명 (Problem Description)

정수 배열 `numbers`에서 서로 다른 인덱스에 위치한 두 원소를 곱하여 만들 수 있는 최댓값을 반환한다. 두 원소의 값은 같아도 된다.

### 제한사항

- -10,000 ≤ `numbers`의 원소 ≤ 10,000
- 2 ≤ `numbers`의 길이 ≤ 100

### 입출력 예시

| numbers | result | 계산 |
|---|---:|---|
| `[1, 2, -3, 4, -5]` | 15 | -3 × -5 |
| `[0, -31, 24, 10, 1, 9]` | 240 | 10 × 24 |
| `[10, 20, 30, 5, 5, 20, 5]` | 600 | 20 × 30 |

---

## 2. 핵심 알고리즘 (Key Algorithm)

**정렬(Sorting)** 을 이용하여 가장 작은 두 원소의 곱과 가장 큰 두 원소의 곱을 비교한다.

> 음수끼리 곱하면 양수가 되므로 가장 큰 두 원소만 비교해서는 안 된다.

예를 들어 `[1, 2, -3, 4, -5]`를 오름차순 정렬하면 다음과 같다.

```text
정렬 전: [ 1,  2, -3,  4, -5]
정렬 후: [-5, -3,  1,  2,  4]
          └───┘       └───┘
            15           8

max(15, 8) = 15
```

두 양수의 곱은 가장 큰 두 양수에서 최대가 되고, 두 음수의 곱은 가장 작은 두 음수에서 최대가 된다. 0이 있는 경우와 원소가 두 개뿐인 경우에도 같은 공식이 성립한다. 따라서 정렬한 배열의 양 끝 두 쌍만 비교하면 충분하다.

---

## 3. Python 풀이 (Python Solution)

### 추천 풀이 — 정렬 활용

```python
def solution(numbers):
    # 원본 리스트를 변경하지 않고 오름차순 정렬
    nums = sorted(numbers)

    # 가장 작은 두 수와 가장 큰 두 수의 곱을 비교
    return max(nums[0] * nums[1], nums[-1] * nums[-2])
```

### 주요 문법

| 문법 | 설명 |
|---|---|
| `sorted(numbers)` | 정렬된 새로운 리스트를 반환 |
| `numbers.sort()` | 원본 리스트를 직접 정렬하며 반환값은 `None` |
| `nums[0]`, `nums[1]` | 첫 번째, 두 번째 원소 |
| `nums[-1]`, `nums[-2]` | 마지막, 뒤에서 두 번째 원소 |
| `max(a, b)` | 두 값 중 큰 값을 반환 |

---

## 4. C# 풀이 (C# LINQ Solution)

### 추천 풀이 — LINQ 정렬 활용

```csharp
using System;
using System.Linq;

public class Solution
{
    public int solution(int[] numbers)
    {
        // LINQ로 오름차순 정렬한 새로운 배열 생성
        int[] nums = numbers.OrderBy(n => n).ToArray();
        int length = nums.Length;

        // 양 끝의 두 원소씩 곱한 뒤 최댓값 반환
        return Math.Max(
            nums[0] * nums[1],
            nums[length - 1] * nums[length - 2]
        );
    }
}
```

### 주요 메서드 및 문법

| 문법 | 설명 |
|---|---|
| `using System.Linq;` | LINQ 확장 메서드를 사용하기 위한 선언 |
| `OrderBy(n => n)` | 원소 자체를 기준으로 오름차순 정렬 |
| `n => n` | 입력값을 그대로 반환하는 람다식(Lambda Expression) |
| `ToArray()` | LINQ 결과를 배열로 구체화(Materialization) |
| `Length` | 배열의 원소 개수 |
| `Math.Max(a, b)` | 두 값 중 큰 값을 반환 |

C# 8.0 이상에서는 `nums[^1]`, `nums[^2]`로 마지막 두 원소에 접근할 수도 있다. 위 코드는 버전 호환성을 고려하여 일반 인덱스를 사용했다.

---

## 5. 기존 코드 분석 및 수정 (Brute Force)

### 기존 Python 코드의 문제점

```python
if i == j:
    continue
```

원소의 값을 비교하므로 `[5, 5]`처럼 서로 다른 위치에 같은 값이 존재하면 유효한 곱셈까지 제외된다. 모든 값이 같으면 `result`가 비어 `max(result)`에서 `ValueError`가 발생한다.

### Python — 인덱스 기반 완전 탐색

```python
def solution(numbers):
    # 유효한 두 원소의 곱으로 최댓값 초기화
    answer = numbers[0] * numbers[1]

    for i in range(len(numbers)):
        for j in range(i + 1, len(numbers)):
            answer = max(answer, numbers[i] * numbers[j])

    return answer
```

`j`를 `i + 1`부터 시작하면 자기 자신과의 곱셈 및 순서만 다른 중복 연산을 방지할 수 있다. 최댓값을 0으로 초기화하지 않는 이유는 `[-3, 2]`처럼 정답이 음수일 수 있기 때문이다.

### Python — itertools 활용

```python
from itertools import combinations

def solution(numbers):
    return max(a * b for a, b in combinations(numbers, 2))
```

`combinations(numbers, 2)`는 서로 다른 위치의 원소 두 개를 선택한다. 같은 값의 원소도 선택할 수 있다. 제너레이터 표현식을 사용하여 모든 곱을 리스트에 저장하지 않는다.

### C# — LINQ 완전 탐색

```csharp
using System.Linq;

public class Solution
{
    public int solution(int[] numbers)
    {
        return numbers
            .SelectMany((a, i) => numbers.Skip(i + 1)
                .Select(b => a * b))
            .Max();
    }
}
```

| LINQ 메서드 | 역할 |
|---|---|
| `SelectMany((a, i) => ...)` | 원소와 인덱스를 받아 각 결과 시퀀스를 하나로 펼침 |
| `Skip(i + 1)` | 현재 원소까지 건너뜀 |
| `Select(b => a * b)` | 각 원소와의 곱을 생성 |
| `Max()` | 전체 곱 중 최댓값 반환 |

---

## 6. 시간 및 공간 복잡도 (Complexity)

| 방법 | 시간 | 추가 공간 |
|---|---|---|
| Python `sorted()` | O(n log n) | O(n) |
| C# `OrderBy().ToArray()` | O(n log n) | O(n) |
| 인덱스 기반 완전 탐색 | O(n²) | O(1) |
| Python `combinations()` | O(n²) | O(n), 입력 풀 저장 |
| C# LINQ 완전 탐색 | O(n²) | O(1), 배열과 일반적인 지연 실행 기준 |

최대 배열 길이가 100이므로 완전 탐색도 최대 4,950개의 쌍만 비교한다. 다만 정렬 풀이는 코드가 간결하며 더 큰 입력에도 효율적이다. 최솟값 두 개와 최댓값 두 개를 직접 추적하면 O(n) 시간, O(1) 추가 공간으로도 해결할 수 있다.

---

## 7. 테스트 케이스 (Test Cases)

| 입력 | 예상 결과 | 검증 목적 |
|---|---:|---|
| `[1, 2, -3, 4, -5]` | 15 | 음수 두 개의 곱 |
| `[0, -31, 24, 10, 1, 9]` | 240 | 양수 두 개의 곱 |
| `[10, 20, 30, 5, 5, 20, 5]` | 600 | 중복 원소 |
| `[5, 5]` | 25 | 동일한 값 두 개 |
| `[-5, -3, -1]` | 15 | 모든 원소가 음수 |
| `[-3, 2]` | -6 | 음수인 정답 |
| `[0, -5]` | 0 | 0 포함 |
| `[-10000, -10000]` | 100000000 | 제한 범위 최댓값 |

Python 실행 예시:

```python
print(solution([1, 2, -3, 4, -5]))  # 15
print(solution([5, 5]))             # 25
print(solution([-3, 2]))             # -6
```

---

## 8. 참고 사항 및 결론 (Conclusion)

- 서로 다른 **값(Value)** 과 서로 다른 **인덱스(Index)** 를 구분해야 한다.
- 음수가 존재하면 배열 양 끝의 두 쌍을 비교한다.
- 최대 곱의 절댓값은 100,000,000이므로 C#의 `int` 범위 안에 있다.
- Python은 `sorted()`와 `max()`, C#은 LINQ의 `OrderBy()`와 `Math.Max()`를 활용하는 풀이를 추천한다.
- 추천 풀이는 두 언어 모두 원본 배열 또는 리스트를 변경하지 않는다.
