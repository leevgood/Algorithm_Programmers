# 배열 회전시키기 (Rotate Array) — Python & C# LINQ

## 1. 문제 설명 (Problem Description)

정수 배열 `numbers`와 문자열 `direction`이 주어질 때, 지정된 방향으로 원소를 한 칸씩 순환 이동한 배열을 반환합니다.

### 제한사항 (Constraints)

- `numbers`의 길이: 3 이상 20 이하
- `direction`: `"left"` 또는 `"right"`

### 입출력 예 (Examples)

| numbers | direction | result |
|---|---|---|
| [1, 2, 3] | right | [3, 1, 2] |
| [4, 455, 6, 4, -1, 45, 6] | left | [455, 6, 4, -1, 45, 6, 4] |

---

## 2. 핵심 알고리즘 (Algorithm)

**순환 이동(Circular Shift)** 은 배열의 경계를 벗어나는 원소를 반대편 끝으로 이동시키는 연산입니다.

```text
원본: [1, 2, 3, 4, 5]
오른쪽: [5] + [1, 2, 3, 4] → [5, 1, 2, 3, 4]
왼쪽: [2, 3, 4, 5] + [1] → [2, 3, 4, 5, 1]
```

> 원소를 삭제하는 것이 아니라 위치만 변경하므로 배열의 길이와 각 원소의 개수는 유지됩니다.

---

## 3. Python 추천 풀이 (Slicing)

```python
def solution(numbers, direction):
    if direction == "right":
        # 마지막 원소를 맨 앞으로 이동
        return numbers[-1:] + numbers[:-1]
    else:
        # 첫 번째 원소를 맨 뒤로 이동
        return numbers[1:] + numbers[:1]
```

### 주요 문법 (Syntax)

| 문법 | 설명 | [1, 2, 3, 4, 5] 기준 |
|---|---|---|
| `numbers[-1:]` | 마지막 원소를 포함하는 리스트 | `[5]` |
| `numbers[:-1]` | 마지막 원소를 제외한 리스트 | `[1, 2, 3, 4]` |
| `numbers[1:]` | 첫 번째 원소를 제외한 리스트 | `[2, 3, 4, 5]` |
| `numbers[:1]` | 첫 번째 원소를 포함하는 리스트 | `[1]` |
| `+` | 두 리스트 연결 | `[5] + [1, 2]` → `[5, 1, 2]` |

**슬라이싱(Slicing)** 의 기본 문법은 `numbers[start:stop:step]`이며 `stop` 위치는 포함하지 않습니다. `numbers[-1]`은 정수이지만 `numbers[-1:]`은 리스트이므로 리스트 연결에 사용할 수 있습니다.

### 조건 표현식 (Conditional Expression)

```python
def solution(numbers, direction):
    return (numbers[-1:] + numbers[:-1]
            if direction == "right"
            else numbers[1:] + numbers[:1])
```

---

## 4. C# 추천 풀이 (LINQ)

```csharp
using System.Linq;

public class Solution
{
    public int[] solution(int[] numbers, string direction)
    {
        return direction == "right"
            // 마지막 원소 + 나머지 원소
            ? numbers.Skip(numbers.Length - 1)
                     .Concat(numbers.Take(numbers.Length - 1))
                     .ToArray()
            // 첫 번째 원소를 제외한 나머지 + 첫 번째 원소
            : numbers.Skip(1)
                     .Concat(numbers.Take(1))
                     .ToArray();
    }
}
```

### 주요 LINQ 메서드

| 메서드 | 설명 | 예시 결과 (원본: [1, 2, 3, 4, 5]) |
|---|---|---|
| `Skip(4)` | 앞의 4개 원소 건너뛰기 | `[5]` |
| `Take(4)` | 앞의 4개 원소 가져오기 | `[1, 2, 3, 4]` |
| `Skip(1)` | 첫 번째 원소 건너뛰기 | `[2, 3, 4, 5]` |
| `Take(1)` | 첫 번째 원소 가져오기 | `[1]` |
| `Concat()` | 두 시퀀스를 순서대로 연결 | `[5, 1, 2, 3, 4]` |
| `ToArray()` | 시퀀스를 배열로 변환 | `int[]` |

`Skip()`, `Take()`, `Concat()`은 지연 실행(Deferred Execution)되는 시퀀스를 반환합니다. `ToArray()`에서 실제 결과를 배열로 생성합니다. `Concat()`은 중복을 제거하지 않으므로 이 문제에 적합합니다.

### Python과 C# 문법 비교

| Python | C# LINQ |
|---|---|
| `numbers[-1:]` | `numbers.Skip(numbers.Length - 1)` |
| `numbers[:-1]` | `numbers.Take(numbers.Length - 1)` |
| `numbers[1:]` | `numbers.Skip(1)` |
| `numbers[:1]` | `numbers.Take(1)` |
| `a + b` | `a.Concat(b).ToArray()` |

---

## 5. 추가 풀이 (Alternative Solutions)

### Python — deque

```python
from collections import deque

def solution(numbers, direction):
    queue = deque(numbers)
    queue.rotate(1 if direction == "right" else -1)
    return list(queue)
```

`rotate(1)`은 오른쪽, `rotate(-1)`은 왼쪽으로 한 칸 회전합니다. 덱 자체의 한 칸 회전은 O(1)이지만 리스트와 덱 사이의 변환을 포함하면 전체 O(n)입니다.

### C# — Select와 나머지 연산 (Modulo)

```csharp
using System.Linq;

public class Solution
{
    public int[] solution(int[] numbers, string direction)
    {
        int n = numbers.Length;
        int offset = direction == "right" ? n - 1 : 1;

        // 결과 배열의 인덱스를 원본 배열의 인덱스로 변환
        return Enumerable.Range(0, n)
                         .Select(i => numbers[(i + offset) % n])
                         .ToArray();
    }
}
```

`Enumerable.Range(0, n)`은 0부터 n-1까지 생성하고, `Select()`는 각 인덱스를 대응하는 원소로 변환합니다. `% n`은 인덱스가 배열의 경계를 순환하도록 합니다. 이 방식은 여러 칸 회전으로 확장하기 좋습니다.

---

## 6. 코드 동작 과정 (Step-by-Step)

입력: `[4, 455, 6, 4, -1, 45, 6]`, `"left"`

1. 첫 번째 원소를 분리합니다: `[4]`
2. 나머지 원소를 가져옵니다: `[455, 6, 4, -1, 45, 6]`
3. 나머지 뒤에 첫 번째 원소를 연결합니다.
4. `[455, 6, 4, -1, 45, 6, 4]`를 반환합니다.

---

## 7. 복잡도 분석 (Complexity Analysis)

| 풀이 | 시간 복잡도 | 공간 복잡도 (결과 포함) |
|---|---|---|
| Python 슬라이싱 | O(n) | O(n) |
| Python deque | O(n) | O(n) |
| C# Skip / Take / Concat | O(n) | O(n) |
| C# Select / Modulo | O(n) | O(n) |

모든 풀이가 원본 배열을 변경하지 않고 새로운 결과를 생성합니다.

---

## 8. 테스트 케이스 (Test Cases)

| numbers | direction | expected |
|---|---|---|
| [1, 2, 3] | right | [3, 1, 2] |
| [4, 455, 6, 4, -1, 45, 6] | left | [455, 6, 4, -1, 45, 6, 4] |
| [1, 2, 3] | left | [2, 3, 1] |
| [7, 7, 7] | right | [7, 7, 7] |
| [-1, 0, -2] | right | [-2, -1, 0] |

---

## 9. 결론 (Conclusion)

- Python은 **슬라이싱**으로 간결하게 구현할 수 있습니다.
- C#은 **LINQ의 Skip, Take, Concat**을 활용하면 Python 슬라이싱과 유사한 방식으로 구현할 수 있습니다.
- 여러 칸 회전으로 확장할 때는 **나머지 연산(Modulo)** 또는 `deque.rotate()`가 유용합니다.
- 제한사항에서 방향이 두 가지로 보장되므로 별도의 잘못된 방향 검사는 생략했습니다.
