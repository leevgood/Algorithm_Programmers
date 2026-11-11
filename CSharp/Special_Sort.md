# 가까운 수 정렬하기 (Sorting Numbers by Distance)

## 1. 문제 설명 (Problem Overview)

정수 배열 `numlist`의 원소를 정수 `n`과 **가까운 순서**로 정렬합니다.

정렬 기준은 다음 두 가지입니다.

1. **1차 기준:** `n`과의 절댓값 거리 `|x - n|`가 작은 원소를 앞에 배치합니다.
2. **2차 기준:** 거리가 같다면 **숫자가 더 큰 원소**를 앞에 배치합니다.

### 제한사항

- `1 ≤ n ≤ 10,000`
- `1 ≤ numlist[i] ≤ 10,000`
- `1 ≤ numlist.Length ≤ 100`
- `numlist`의 원소는 중복되지 않습니다.

### 입출력 예시

| numlist | n | result |
| --- | ---: | --- |
| `[1, 2, 3, 4, 5, 6]` | 4 | `[4, 5, 3, 6, 2, 1]` |
| `[10000, 20, 36, 47, 40, 6, 10, 7000]` | 30 | `[36, 40, 20, 47, 10, 6, 7000, 10000]` |

---

## 2. C# 풀이 — LINQ

### 정답 코드

```csharp
using System;
using System.Linq;

public class Solution
{
    public int[] solution(int[] numlist, int n)
    {
        return numlist
            .OrderBy(x => Math.Abs(x - n)) // n과의 거리가 가까운 순서 (오름차순)
            .ThenByDescending(x => x)       // 거리가 같으면 큰 숫자를 먼저 (내림차순)
            .ToArray();                     // 정렬된 결과를 int[] 배열로 변환
    }
}
```

### 주요 메서드 및 문법

| 문법 | 의미 | 역할 |
| --- | --- | --- |
| `using System.Linq;` | LINQ 네임스페이스 가져오기 | 정렬 확장 메서드 사용 |
| `Math.Abs(x - n)` | 절댓값 계산 | `n`과의 거리 구하기 |
| `OrderBy(...)` | 오름차순 정렬 | 거리가 짧은 값부터 배치 |
| `ThenByDescending(...)` | 앞선 정렬 키가 같은 요소를 내림차순 정렬 | 동일 거리에서는 큰 값 우선 |
| `x => ...` | 람다 표현식 (Lambda Expression) | 각 원소의 정렬 기준 정의 |
| `ToArray()` | 배열로 변환 | 반환 형식 `int[]`에 맞추기 |

> **주의:** `OrderBy(...).OrderByDescending(...)`을 사용하면 두 번째 `OrderByDescending`이 새로운 기본 정렬을 시작합니다. 기존 정렬의 동률 처리에는 반드시 `ThenByDescending(...)`을 사용합니다.

---

## 3. Python 풀이

### 정답 코드

```python
def solution(numlist, n):
    return sorted(numlist, key=lambda x: (abs(x - n), -x))
```

### 주요 함수 및 문법

| 문법 | 의미 | 역할 |
| --- | --- | --- |
| `sorted(numlist, key=...)` | 정렬된 새 리스트 반환 | 원본 리스트는 변경하지 않음 |
| `lambda x: ...` | 익명 함수 (Lambda Function) | 원소별 정렬 키를 만듦 |
| `abs(x - n)` | 절댓값 계산 | `n`과의 거리 |
| `(abs(x - n), -x)` | 튜플 정렬 키 | 거리 오름차순 → 숫자 내림차순 |
| `-x` | 숫자의 부호 반전 | 기본 오름차순 정렬로 큰 숫자를 먼저 배치 |

Python의 튜플 비교는 **첫 번째 요소를 먼저 비교**하고, 같을 경우 **두 번째 요소를 비교**합니다.

예를 들어 `n = 4`일 때:

- `x = 3` → 정렬 키 `(1, -3)`
- `x = 5` → 정렬 키 `(1, -5)`

`-5 < -3`이므로 숫자 `5`가 `3`보다 먼저 정렬됩니다.

---

## 4. 정렬 과정 (Step-by-Step)

`numlist = [1, 2, 3, 4, 5, 6]`, `n = 4`의 경우:

| 원소 `x` | 거리 `abs(x - 4)` | 동률 정렬 키 `-x` | 최종 순서 |
| ---: | ---: | ---: | ---: |
| 4 | 0 | -4 | 1 |
| 5 | 1 | -5 | 2 |
| 3 | 1 | -3 | 3 |
| 6 | 2 | -6 | 4 |
| 2 | 2 | -2 | 5 |
| 1 | 3 | -1 | 6 |

따라서 결과는 다음과 같습니다.

```text
[4, 5, 3, 6, 2, 1]
```

### 두 번째 예시의 동률 처리

`n = 30`일 때 `20`과 `40`은 모두 거리가 `10`입니다.

- `20` → 거리 `10`
- `40` → 거리 `10`

거리가 같으므로 큰 값인 **40이 20보다 먼저** 옵니다.

---

## 5. 실행 및 출력 예시

### C# 테스트 코드

아래 코드는 프로그래머스 제출 코드와 별도로, 콘솔에서 테스트할 때 사용할 수 있습니다.

```csharp
using System;
using System.Linq;

public class Solution
{
    public int[] solution(int[] numlist, int n)
    {
        return numlist
            .OrderBy(x => Math.Abs(x - n))
            .ThenByDescending(x => x)
            .ToArray();
    }
}

public class Program
{
    public static void Main()
    {
        var solver = new Solution();
        int[] result = solver.solution(new[] { 1, 2, 3, 4, 5, 6 }, 4);
        Console.WriteLine($"[{string.Join(", ", result)}]");
    }
}
```

### Python 테스트 코드

```python
def solution(numlist, n):
    return sorted(numlist, key=lambda x: (abs(x - n), -x))

print(solution([1, 2, 3, 4, 5, 6], 4))
print(solution([10000, 20, 36, 47, 40, 6, 10, 7000], 30))
```

### 출력 결과

```text
[4, 5, 3, 6, 2, 1]
[36, 40, 20, 47, 10, 6, 7000, 10000]
```

---

## 6. 시간 및 공간 복잡도 (Complexity)

배열의 길이를 `m`이라고 할 때:

| 항목 | 복잡도 | 설명 |
| --- | --- | --- |
| 시간 복잡도 | `O(m log m)` | 비교 기반 정렬에 소요되는 시간 |
| 추가 공간 복잡도 | `O(m)` 수준 | 정렬 과정 및 반환 결과를 위한 추가 저장 공간 (구현에 따라 차이 있음) |

입력 길이가 최대 100이므로 두 풀이 모두 충분히 효율적입니다.

---

## 7. 핵심 정리 (Key Takeaways)

- **다중 정렬 기준(Multi-key Sorting):** 첫 기준인 거리가 같을 때 두 번째 기준인 숫자 크기를 적용합니다.
- **C# LINQ:** `OrderBy(x => Math.Abs(x - n)).ThenByDescending(x => x)`
- **Python:** `sorted(numlist, key=lambda x: (abs(x - n), -x))`
- 거리가 같을 때 더 큰 값이 먼저 와야 한다는 조건을 놓치지 않는 것이 핵심입니다.
