# 배열 조각에서 조건에 맞는 최솟값 찾기

## 문제 설명

정수 배열 `arr`와 2차원 정수 배열 `queries`가 주어집니다.

각 쿼리는 `[s, e, k]` 형태이며, 인덱스 `s`부터 `e`까지의 범위 안에서 `k`보다 큰 값 중 가장 작은 값을 찾아야 합니다.

조건을 만족하는 값이 없다면 `-1`을 저장합니다.

---

## 입출력 예시

```text
arr = [0, 1, 2, 4, 3]
queries = [[0, 4, 2], [0, 3, 2], [0, 2, 2]]

result = [3, 4, -1]
```

---

## 풀이 아이디어

각 쿼리마다 다음 과정을 수행합니다.

1. 쿼리에서 `s`, `e`, `k`를 꺼냅니다.
2. `arr[s]`부터 `arr[e]`까지 확인합니다.
3. `k`보다 큰 값만 후보로 봅니다.
4. 후보 중 가장 작은 값을 저장합니다.
5. 후보가 없다면 `-1`을 저장합니다.

배열 길이와 쿼리 개수가 최대 `1000`이므로, 단순 반복문으로도 충분히 해결할 수 있습니다.

---

## C# 풀이

```csharp
using System;
using System.Collections.Generic;

public class Solution
{
    public int[] solution(int[] arr, int[,] queries)
    {
        int queryCount = queries.GetLength(0);
        int[] answer = new int[queryCount];

        for (int q = 0; q < queryCount; q++)
        {
            int s = queries[q, 0];
            int e = queries[q, 1];
            int k = queries[q, 2];

            int minValue = int.MaxValue;

            // s부터 e까지 범위를 확인
            for (int i = s; i <= e; i++)
            {
                // k보다 큰 값 중 가장 작은 값을 찾음
                if (arr[i] > k && arr[i] < minValue)
                {
                    minValue = arr[i];
                }
            }

            // 조건을 만족하는 값이 없으면 -1 저장
            answer[q] = minValue == int.MaxValue ? -1 : minValue;
        }

        return answer;
    }
}
```

---

## Python 풀이

```python
def solution(arr, queries):
    answer = []

    for s, e, k in queries:
        min_value = float('inf')

        # s부터 e까지 범위를 확인
        for i in range(s, e + 1):
            # k보다 큰 값 중 가장 작은 값을 찾음
            if arr[i] > k and arr[i] < min_value:
                min_value = arr[i]

        # 조건을 만족하는 값이 없으면 -1 저장
        if min_value == float('inf'):
            answer.append(-1)
        else:
            answer.append(min_value)

    return answer
```

---

## Python 간단한 풀이

```python
def solution(arr, queries):
    answer = []

    for s, e, k in queries:
        candidates = [x for x in arr[s:e + 1] if x > k]
        answer.append(min(candidates) if candidates else -1)

    return answer
```

---

## 주요 문법 설명

| 개념       | 설명                        |
| -------- | ------------------------- |
| 반복문      | 각 쿼리를 순서대로 처리하기 위해 사용     |
| 범위 탐색    | `s`부터 `e`까지 배열 값을 확인      |
| 조건문      | `arr[i] > k`인 값만 후보로 선택   |
| 최솟값 비교   | 현재까지 찾은 값보다 더 작으면 갱신      |
| 예외 처리 방식 | 조건을 만족하는 값이 없을 경우 `-1` 저장 |

---

## 시간 복잡도

배열의 길이를 `N`, 쿼리의 개수를 `Q`라고 하면,

```text
O(N × Q)
```

입니다.

제한사항에서 `N ≤ 1000`, `Q ≤ 1000`이므로 최대 약 `1,000,000`번 정도의 비교만 수행합니다. 따라서 충분히 빠르게 실행됩니다.

---

## 예제 실행 과정

```text
arr = [0, 1, 2, 4, 3]
queries = [[0, 4, 2], [0, 3, 2], [0, 2, 2]]
```

### 첫 번째 쿼리

```text
[0, 4, 2]
범위: arr[0] ~ arr[4] = [0, 1, 2, 4, 3]
2보다 큰 값: [4, 3]
가장 작은 값: 3
```

### 두 번째 쿼리

```text
[0, 3, 2]
범위: arr[0] ~ arr[3] = [0, 1, 2, 4]
2보다 큰 값: [4]
가장 작은 값: 4
```

### 세 번째 쿼리

```text
[0, 2, 2]
범위: arr[0] ~ arr[2] = [0, 1, 2]
2보다 큰 값: 없음
결과: -1
```

---

## 최종 결과

```text
[3, 4, -1]
```
