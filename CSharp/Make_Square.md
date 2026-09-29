# [Lecture Summary] 이차원 배열을 정사각형으로 만들기

## 개요(Overview)

주어진 **이차원 배열(2D Array)** `arr`의 행과 열의 개수를 비교하여, 더 큰 쪽의 길이에 맞춰 배열을 **정사각형(Square Matrix)** 으로 만드는 문제입니다.

핵심 아이디어는 매우 단순합니다.

- 행의 개수 > 열의 개수 → 부족한 열을 `0`으로 채운다.
- 열의 개수 > 행의 개수 → 부족한 행을 `0`으로 채운다.
- 행의 개수 == 열의 개수 → 그대로 반환한다.

즉, 최종 배열의 크기는 항상 다음과 같습니다.

```text
size = max(행의 개수, 열의 개수)
```

---

## 주요 개념 및 아키텍처(Key Concepts & Architecture)

### 1. 행과 열의 개수 구하기

예를 들어 다음 배열이 있다고 가정합니다.

```text
[
    [1, 2, 3],
    [4, 5, 6]
]
```

행의 개수는 `2`, 열의 개수는 `3`입니다.

따라서 최종 배열은 `3 × 3` 크기가 되어야 합니다.

```text
[
    [1, 2, 3],
    [4, 5, 6],
    [0, 0, 0]
]
```

---

### 2. 가장 큰 길이를 기준으로 정사각형 배열 생성

행과 열 중 더 큰 값을 구합니다.

```text
size = max(row, col)
```

그리고 `size × size` 크기의 새로운 배열을 생성합니다.

새 배열은 기본값이 `0`이므로 기존 배열의 값만 복사하면 나머지 영역은 자동으로 `0`이 됩니다.

이 방법의 장점은 다음과 같습니다.

- 행이 더 많은 경우와 열이 더 많은 경우를 따로 처리할 필요가 없습니다.
- 조건문이 줄어들어 코드가 단순합니다.
- 배열 복사 과정만 이해하면 쉽게 구현할 수 있습니다.

---

## 상세 구현(Detailed Implementation)

### C# 풀이

```csharp
using System;

public class Solution
{
    public int[,] solution(int[,] arr)
    {
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);

        int size = Math.Max(rows, cols);

        // size × size 정사각형 배열 생성
        // int 배열의 기본값은 0
        int[,] answer = new int[size, size];

        // 기존 배열의 값만 복사
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                answer[i, j] = arr[i, j];
            }
        }

        return answer;
    }
}
```

### C# 핵심 문법

| 문법 | 설명 |
|---|---|
| `arr.GetLength(0)` | **행(Row)** 개수를 가져옵니다. |
| `arr.GetLength(1)` | **열(Column)** 개수를 가져옵니다. |
| `Math.Max(a, b)` | 두 값 중 더 큰 값을 반환합니다. |
| `new int[size, size]` | `size × size` 크기의 이차원 배열을 생성합니다. |
| `answer[i, j]` | C# 다차원 배열의 특정 원소에 접근합니다. |

### C# 동작 과정

입력:

```text
[
    [572, 22, 37],
    [287, 726, 384],
    [85, 137, 292],
    [487, 13, 876]
]
```

행의 개수:

```text
rows = 4
```

열의 개수:

```text
cols = 3
```

최종 크기:

```text
size = Math.Max(4, 3)
size = 4
```

먼저 다음과 같은 `4 × 4` 배열이 만들어집니다.

```text
[
    [0, 0, 0, 0],
    [0, 0, 0, 0],
    [0, 0, 0, 0],
    [0, 0, 0, 0]
]
```

이후 기존 배열의 값만 복사합니다.

```text
[
    [572, 22, 37, 0],
    [287, 726, 384, 0],
    [85, 137, 292, 0],
    [487, 13, 876, 0]
]
```

---

### Python 풀이

```python
def solution(arr):
    rows = len(arr)
    cols = len(arr[0])

    size = max(rows, cols)

    # size × size 정사각형 배열 생성
    answer = [[0] * size for _ in range(size)]

    # 기존 배열의 값 복사
    for i in range(rows):
        for j in range(cols):
            answer[i][j] = arr[i][j]

    return answer
```

### Python 핵심 문법

| 문법 | 설명 |
|---|---|
| `len(arr)` | 행의 개수를 구합니다. |
| `len(arr[0])` | 열의 개수를 구합니다. |
| `max(rows, cols)` | 행과 열 중 더 큰 값을 구합니다. |
| `[[0] * size for _ in range(size)]` | `size × size` 크기의 0으로 채운 배열을 생성합니다. |
| `answer[i][j]` | Python 이차원 리스트의 특정 원소에 접근합니다. |

---

### Python에서 주의할 점

다음과 같이 작성하는 것은 피하는 것이 좋습니다.

```python
answer = [[0] * size] * size
```

이 방식은 내부 리스트가 서로 같은 객체를 참조하기 때문에 한 행을 수정했을 때 다른 행도 함께 변경될 수 있습니다.

예를 들어:

```python
arr = [[0] * 3] * 3
arr[0][0] = 1

print(arr)
```

결과:

```text
[
    [1, 0, 0],
    [1, 0, 0],
    [1, 0, 0]
]
```

따라서 반드시 **리스트 컴프리헨션(List Comprehension)** 을 사용하는 것이 안전합니다.

```python
answer = [[0] * size for _ in range(size)]
```

---

## 다른 풀이 방법

### Python에서 행과 열을 직접 추가하는 방식

문제 설명 그대로 구현하면 다음처럼 작성할 수도 있습니다.

```python
def solution(arr):
    rows = len(arr)
    cols = len(arr[0])

    if rows > cols:
        for row in arr:
            row.extend([0] * (rows - cols))

    elif cols > rows:
        for _ in range(cols - rows):
            arr.append([0] * cols)

    return arr
```

이 코드도 정답이지만, 기존 배열 `arr` 자체를 수정합니다.

알고리즘 테스트에서는 문제에 따라 원본 배열 변경이 허용되지 않을 수도 있기 때문에, 새로운 배열을 생성하는 첫 번째 방식이 더 일반적이고 이해하기 쉽습니다.

---

## 시간 복잡도(Time Complexity)

기존 배열의 모든 원소를 한 번씩 복사합니다.

행의 수를 `R`, 열의 수를 `C`라고 하면 시간 복잡도는:

```text
O(R × C)
```

새로운 정사각형 배열의 한 변의 길이를 `N = max(R, C)`라고 하면 공간 복잡도는:

```text
O(N²)
```

입니다.

문제의 최대 크기가 `100 × 100`이므로 충분히 빠르게 처리할 수 있습니다.

---

## 활용 사례 및 결론(Use Cases & Conclusion)

이 문제에서 중요한 것은 조건문 자체가 아니라 **새 배열을 먼저 만들고 기존 데이터를 복사하는 패턴**입니다.

알고리즘 테스트에서 다음 유형에 자주 활용됩니다.

- 배열 크기 확장
- 행렬 패딩(**Padding**)
- 이미지 데이터 주변에 0 추가
- 좌표 공간 확장
- BFS/DFS 문제에서 경계 처리용 패딩
- 서로 다른 크기의 배열을 동일한 크기로 맞추는 문제

핵심 패턴은 다음 한 줄로 기억하면 됩니다.

```text
새 배열 크기 = max(행의 수, 열의 수)
```

그리고:

```text
새 배열을 0으로 초기화 → 기존 배열의 값만 복사
```

하는 방식으로 해결하면 됩니다.

### 알고리즘 테스트용 핵심 정리

```csharp
int rows = arr.GetLength(0);
int cols = arr.GetLength(1);
int size = Math.Max(rows, cols);
```

```python
rows = len(arr)
cols = len(arr[0])
size = max(rows, cols)
```

이후 `size × size` 배열을 만든 뒤 기존 값을 복사하면 문제를 간단하게 해결할 수 있습니다.
