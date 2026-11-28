# 진료 순서 정하기 (Emergency Ranking) — C# & Python

## 1. 문제 설명 (Overview)

정수 배열 `emergency`의 각 원소에 응급도가 높은 순서대로 1부터 순위를 부여하고, 원본 배열의 순서를 유지한 순위 배열을 반환한다.

- 원소는 중복되지 않는다.
- 배열 길이는 1~10, 원소는 1~100이다.
- 핵심 공식: **순위 = 자신보다 큰 원소의 개수 + 1**

| 입력 | 출력 |
|---|---|
| `[3, 76, 24]` | `[3, 1, 2]` |
| `[1, 2, 3, 4, 5, 6, 7]` | `[7, 6, 5, 4, 3, 2, 1]` |
| `[30, 10, 23, 6, 100]` | `[2, 4, 3, 5, 1]` |

---

## 2. C# 풀이 (LINQ)

### 방법 1. Select + Count (추천)

```csharp
using System.Linq;

public class Solution
{
    public int[] solution(int[] emergency)
    {
        // 자신보다 큰 원소의 개수에 1을 더해 순위를 계산한다.
        return emergency
            .Select(x => emergency.Count(y => y > x) + 1)
            .ToArray();
    }
}
```

### 방법 2. 정렬과 인덱스 검색

```csharp
using System;
using System.Linq;

public class Solution
{
    public int[] solution(int[] emergency)
    {
        // 원본을 변경하지 않고 내림차순 배열을 생성한다.
        int[] sorted = emergency.OrderByDescending(x => x).ToArray();
        return emergency.Select(x => Array.IndexOf(sorted, x) + 1).ToArray();
    }
}
```

### 방법 3. Dictionary 활용

```csharp
using System.Linq;

public class Solution
{
    public int[] solution(int[] emergency)
    {
        // 정렬된 인덱스에 1을 더하여 순위 딕셔너리를 생성한다.
        var ranks = emergency
            .OrderByDescending(x => x)
            .Select((x, i) => new { Value = x, Rank = i + 1 })
            .ToDictionary(x => x.Value, x => x.Rank);

        // 원본 순서대로 순위를 조회한다.
        return emergency.Select(x => ranks[x]).ToArray();
    }
}
```

### 주요 메서드 및 문법

| 문법 | 설명 | 반환 자료형 |
|---|---|---|
| `Select(x => ...)` | 각 원소를 변환 | `IEnumerable<T>` |
| `Count(y => y > x)` | 조건을 만족하는 개수 | `int` |
| `OrderByDescending()` | 내림차순 정렬 | `IOrderedEnumerable<T>` |
| `Array.IndexOf()` | 원소의 첫 인덱스 검색, 없으면 -1 | `int` |
| `Select((x, i) => ...)` | 원소와 0부터 시작하는 인덱스를 함께 사용 | `IEnumerable<T>` |
| `new { Value = x, Rank = i + 1 }` | 익명 형식(Anonymous Type) 생성 | 익명 형식 |
| `ToDictionary()` | 키와 값으로 딕셔너리 생성 | `Dictionary<TKey, TValue>` |
| `ToArray()` | 시퀀스를 배열로 변환 | `T[]` |

---

## 3. Python 풀이

### 방법 1. 리스트 컴프리헨션과 sum (추천)

```python
def solution(emergency):
    # True는 1, False는 0으로 합산된다.
    return [sum(y > x for y in emergency) + 1 for x in emergency]
```

### 방법 2. sorted와 index

```python
def solution(emergency):
    ranked = sorted(emergency, reverse=True)
    return [ranked.index(x) + 1 for x in emergency]
```

### 방법 3. 딕셔너리 컴프리헨션

```python
def solution(emergency):
    ranks = {
        x: i
        for i, x in enumerate(sorted(emergency, reverse=True), start=1)
    }
    return [ranks[x] for x in emergency]
```

### 방법 4. 일반 반복문 (학습용)

```python
def solution(emergency):
    answer = []
    for x in emergency:
        rank = 1
        for y in emergency:
            if y > x:
                rank += 1
        answer.append(rank)
    return answer
```

| 문법 | 설명 |
|---|---|
| `sum()` | 반복 가능한 객체의 원소를 합산 |
| `y > x for y in emergency` | 불리언 값을 생성하는 제너레이터 표현식 |
| `[... for x in emergency]` | 리스트 컴프리헨션 |
| `sorted(..., reverse=True)` | 새 내림차순 리스트 생성 |
| `list.index(x)` | 첫 일치 원소의 인덱스 반환, 없으면 ValueError |
| `enumerate(..., start=1)` | 번호와 원소를 함께 제공 |
| `{x: i for ...}` | 딕셔너리 컴프리헨션 |

---

## 4. 코드 동작 과정 (Execution Flow)

입력: `[3, 76, 24]`

| 현재 응급도 x | 자신보다 큰 원소 | 개수 | 순위 |
|---:|---|---:|---:|
| 3 | 76, 24 | 2 | 3 |
| 76 | 없음 | 0 | 1 |
| 24 | 76 | 1 | 2 |

```text
원본 배열: [3, 76, 24]
정렬 배열: [76, 24, 3]
순위 매핑: {76: 1, 24: 2, 3: 3}
반환 배열: [3, 1, 2]
```

Python의 `sum(y > x for y in emergency)`에서 x=3이면 `False, True, True`가 생성되어 합계는 2이다. 여기에 1을 더하면 3위이다.

---

## 5. 시간 및 공간 복잡도 (Complexity)

N은 배열의 길이이며, 공간 복잡도는 반환 배열을 포함한다.

| 풀이 | 시간 | 공간 |
|---|---|---|
| C# Select + Count / Python sum | O(N²) | O(N) |
| 정렬 + 인덱스 검색 | O(N²) | O(N) |
| 정렬 + 딕셔너리 | 평균 O(N log N) | O(N) |
| 일반 이중 반복문 | O(N²) | O(N) |

딕셔너리 조회는 평균 O(1)로 가정한다. 이 문제는 N이 최대 10이므로 Count 또는 sum 방식이 충분하다.

---

## 6. 테스트 및 참고 사항 (Tests & Notes)

```python
assert solution([3, 76, 24]) == [3, 1, 2]
assert solution([1, 2, 3, 4, 5, 6, 7]) == [7, 6, 5, 4, 3, 2, 1]
assert solution([30, 10, 23, 6, 100]) == [2, 4, 3, 5, 1]
assert solution([100]) == [1]
assert solution([100, 50, 1]) == [1, 2, 3]
```

- 순위는 0이 아니라 1부터 시작한다.
- 정렬 결과 자체가 아니라 원본 순서에 대응하는 순위를 반환한다.
- 입력에 중복이 없으므로 딕셔너리의 키 충돌이 발생하지 않는다. 중복을 허용하는 문제라면 동점 순위 규칙을 별도로 고려해야 한다.
- Python 네 가지 풀이를 예제 및 경계 사례로 검증했다. C#은 별도로 컴파일하지 않았다.

---

## 7. 활용 사례 및 결론 (Use Cases & Conclusion)

시험 점수, 주식 수익률, 우선순위 등 숫자 데이터의 상대 순위를 계산할 때 활용할 수 있다. 작은 배열은 조건 기반 개수 계산이 간결하며, 큰 데이터는 정렬과 딕셔너리를 결합하는 방식이 효율적이다.
