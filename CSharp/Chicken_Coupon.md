# 프로그래머스 — 치킨 쿠폰 (C# / Python)

## 1. 문제 개요 (Overview)

치킨 한 마리를 주문할 때마다 **쿠폰 1장**을 받습니다. 쿠폰 **10장**을 모으면 서비스 치킨 1마리로 교환할 수 있으며, **서비스 치킨에서도 쿠폰 1장**을 받습니다.

정수 `chicken`이 주어질 때 받을 수 있는 **최대 서비스 치킨 수**를 구하세요.

- 입력 범위: `0 ≤ chicken ≤ 1,000,000`
- 반환값: 서비스 치킨의 총 마릿수 (`int`)

| chicken | result |
| ---: | ---: |
| 100 | 11 |
| 1081 | 120 |

---

## 2. 핵심 아이디어 (Key Concepts)

**쿠폰 10장을 사용해 서비스 치킨 1마리를 받으면, 서비스 치킨에서 쿠폰 1장을 다시 받습니다.**

따라서 서비스 치킨을 한 마리 받을 때 **쿠폰의 순감소량은 9장**입니다.

> 교환 1회: 쿠폰 10장 사용 − 쿠폰 1장 재발급 = 쿠폰 9장 감소

단, 교환을 시작하려면 **현재 쿠폰이 적어도 10장** 있어야 합니다.

### 2.1 반복 시뮬레이션

1. 현재 쿠폰 수를 `chicken`으로 설정합니다.
2. 쿠폰이 10장 이상인 동안 교환할 서비스 치킨 수를 계산합니다.
3. 사용하지 않은 쿠폰과 서비스 치킨에서 새로 받은 쿠폰을 합칩니다.
4. 교환한 서비스 치킨 수를 누적합니다.

한 번에 여러 마리를 교환할 때:

- `service = coupons / 10` (C# 정수 나눗셈) 또는 `coupons // 10` (Python)
- `coupons = coupons % 10 + service`
- `answer += service`

### 2.2 수학 공식

서비스 치킨을 한 마리 받을 때마다 쿠폰이 실질적으로 9장 줄어듭니다. 마지막 교환 **직전**에는 최소 10장의 쿠폰이 있어야 하므로, `chicken ≥ 1`에서:

\[
\text{answer} = \left\lfloor\frac{chicken - 1}{9}\right\rfloor
\]

입력이 0일 때는 결과가 0이어야 하므로 아래와 같이 처리합니다.

\[
\boxed{\text{answer} = \max\left(0, \left\lfloor\frac{chicken - 1}{9}\right\rfloor\right)}
\]

**주의:** C#의 정수 나눗셈은 0을 향해 버림하고, Python의 `//`는 음의 무한대 방향으로 내림합니다. 여기서는 `Math.Max` / `max`를 사용하여 두 언어 모두 0을 올바르게 처리합니다.

---

## 3. C# 풀이 (C# Implementation)

### 3.1 추천 풀이 — 수학 공식, O(1)

```csharp
using System;

public class Solution
{
    public int solution(int chicken)
    {
        // 서비스 치킨 1마리당 쿠폰이 실질적으로 9장 감소
        // 0마리일 때도 결과가 음수가 되지 않도록 처리
        return Math.Max(0, (chicken - 1) / 9);
    }
}
```

- **시간 복잡도(Time Complexity):** `O(1)`
- **공간 복잡도(Space Complexity):** `O(1)`

### 3.2 이해하기 쉬운 풀이 — while문

```csharp
public class Solution
{
    public int solution(int chicken)
    {
        int coupons = chicken; // 현재 남은 쿠폰
        int answer = 0;       // 누적 서비스 치킨 수

        while (coupons >= 10)
        {
            int service = coupons / 10; // 이번에 받는 서비스 치킨
            answer += service;          // 서비스 치킨 수 누적

            // 남은 쿠폰 + 서비스 치킨에서 발급된 쿠폰
            coupons = coupons % 10 + service;
        }

        return answer;
    }
}
```

- **시간 복잡도:** `O(log chicken)` (쿠폰 수가 매 반복마다 대략 1/10로 감소)
- **공간 복잡도:** `O(1)`

### 3.3 LINQ 사용 가능 여부

**LINQ(Language Integrated Query)**는 컬렉션을 조회·필터링·집계할 때 유용합니다. 그러나 이 문제는 **교환한 쿠폰이 다음 교환에 영향을 주는 상태 갱신 문제**이므로, LINQ를 억지로 적용하면 코드가 오히려 복잡해집니다.

LINQ 문법을 사용하는 예시는 다음과 같지만, **학습용 예시일 뿐 실제 제출에는 권장하지 않습니다**.

```csharp
using System;
using System.Linq;

public class Solution
{
    public int solution(int chicken)
    {
        // 공식으로 교환 횟수를 구한 뒤, 해당 개수의 항목을 만들어 Count
        int total = Math.Max(0, (chicken - 1) / 9);
        return Enumerable.Range(0, total).Count();
    }
}
```

위 코드는 공식 풀이와 결과가 같지만, 불필요한 열거 과정을 거치므로 **직접 공식을 반환하는 3.1 풀이가 더 효율적**입니다.

---

## 4. Python 풀이 (Python Implementation)

### 4.1 추천 풀이 — 수학 공식, O(1)

```python
def solution(chicken):
    # 서비스 치킨 1마리당 쿠폰이 실질적으로 9장 감소
    return max(0, (chicken - 1) // 9)
```

- **시간 복잡도:** `O(1)`
- **공간 복잡도:** `O(1)`

### 4.2 이해하기 쉬운 풀이 — while문

```python
def solution(chicken):
    coupons = chicken  # 현재 남은 쿠폰
    answer = 0        # 누적 서비스 치킨 수

    while coupons >= 10:
        service = coupons // 10  # 이번에 받는 서비스 치킨
        answer += service

        # 남은 쿠폰 + 서비스 치킨에서 발급된 쿠폰
        coupons = coupons % 10 + service

    return answer
```

- **시간 복잡도:** `O(log chicken)`
- **공간 복잡도:** `O(1)`

---

## 5. 동작 과정 (Step-by-Step Examples)

### 예시 A: `chicken = 100`

| 단계 | 교환 전 쿠폰 | 서비스 치킨 | 교환 후 쿠폰 | 누적 서비스 |
| ---: | ---: | ---: | ---: | ---: |
| 1 | 100 | 10 | 10 | 10 |
| 2 | 10 | 1 | 1 | 11 |

쿠폰이 1장이므로 더 이상 교환할 수 없습니다. **정답: 11**

공식 확인: `(100 - 1) // 9 = 11`

### 예시 B: `chicken = 1081`

| 단계 | 교환 전 쿠폰 | 서비스 치킨 | 교환 후 쿠폰 | 누적 서비스 |
| ---: | ---: | ---: | ---: | ---: |
| 1 | 1081 | 108 | 109 | 108 |
| 2 | 109 | 10 | 19 | 118 |
| 3 | 19 | 1 | 10 | 119 |
| 4 | 10 | 1 | 1 | 120 |

쿠폰이 1장이므로 더 이상 교환할 수 없습니다. **정답: 120**

공식 확인: `(1081 - 1) // 9 = 120`

---

## 6. 주요 문법 비교 (Syntax Comparison)

| 기능 | C# | Python |
| --- | --- | --- |
| 정수 나눗셈 | `coupons / 10` (`int`끼리 연산) | `coupons // 10` |
| 나머지 연산 | `coupons % 10` | `coupons % 10` |
| 반복 조건 | `while (coupons >= 10)` | `while coupons >= 10:` |
| 최댓값 | `Math.Max(0, value)` | `max(0, value)` |
| 함수 정의 | `public int solution(int chicken)` | `def solution(chicken):` |
| LINQ | `System.Linq` | 기본 기능으로 직접 대응되는 문법 없음 |

---

## 7. 테스트 케이스 (Test Cases)

| chicken | 기대 결과 | 설명 |
| ---: | ---: | --- |
| 0 | 0 | 주문 없음 |
| 1 | 0 | 쿠폰 부족 |
| 9 | 0 | 쿠폰 부족 |
| 10 | 1 | 첫 서비스 교환 |
| 19 | 2 | 새 쿠폰까지 활용 |
| 100 | 11 | 문제 예시 1 |
| 1081 | 120 | 문제 예시 2 |
| 1,000,000 | 111,111 | 입력 최댓값 |

### Python 간단 테스트

```python
cases = [(0, 0), (1, 0), (9, 0), (10, 1),
         (19, 2), (100, 11), (1081, 120), (1_000_000, 111_111)]

for chicken, expected in cases:
    assert solution(chicken) == expected

print("모든 테스트 통과")
```

---

## 8. 정리 (Conclusion)

이 문제의 핵심은 **서비스 치킨에도 쿠폰이 발급된다**는 점입니다. 쿠폰 10장을 사용하지만 다시 1장을 받으므로, 서비스 치킨 한 마리당 쿠폰이 **실질적으로 9장 감소**합니다.

- **개념 이해:** `while`로 쿠폰 교환을 시뮬레이션합니다.
- **실전 제출:** `Math.Max(0, (chicken - 1) / 9)` (C#), `max(0, (chicken - 1) // 9)` (Python)을 추천합니다.
- **LINQ 판단:** 모든 문제에 LINQ를 쓰기보다, 반복 상태 갱신에는 반복문, 단순 계산에는 수식을 선택하는 편이 좋습니다.
