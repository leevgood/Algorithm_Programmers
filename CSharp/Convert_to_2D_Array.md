# 2차원으로 만들기 (Convert to 2D Array)

## 1. 프로그램 설명 (Overview)

정수 배열 `num_list`를 앞에서부터 `n`개씩 묶어 반환합니다. 배열 길이를 `L`이라고 하면 결과는 `L / n`행, `n`열입니다.

### 제한사항

- 배열 길이는 n의 배수입니다.
- 0 ≤ 배열 길이 ≤ 150
- 2 ≤ n < 배열 길이

| num_list | n | result |
|---|---:|---|
| [1, 2, 3, 4, 5, 6, 7, 8] | 2 | [[1, 2], [3, 4], [5, 6], [7, 8]] |
| [100, 95, 2, 4, 5, 6, 18, 33, 948] | 3 | [[100, 95, 2], [4, 5, 6], [18, 33, 948]] |

---

## 2. C# 소스 코드 (LINQ)

### 방법 1. Chunk() — .NET 6 이상 추천

```csharp
using System.Linq;

public class Solution
{
    public int[][] solution(int[] num_list, int n)
    {
        // 배열을 n개씩 분할하고 가변 배열로 변환
        return num_list.Chunk(n).ToArray();
    }
}
```

`Chunk(n)`은 원소를 최대 n개씩 묶은 `IEnumerable<int[]>`를 반환합니다. 이 문제에서는 길이가 n의 배수이므로 모든 행의 길이가 같습니다.

### 방법 2. Range(), Select(), Skip(), Take() — 호환성 중심

```csharp
using System.Linq;

public class Solution
{
    public int[][] solution(int[] num_list, int n)
    {
        // 행의 개수만큼 반복
        return Enumerable.Range(0, num_list.Length / n)
            .Select(i => num_list
                .Skip(i * n) // 이전 행의 원소 건너뛰기
                .Take(n)     // 현재 행의 원소 n개 추출
                .ToArray())  // 각 행을 배열로 변환
            .ToArray();      // 전체 결과를 가변 배열로 변환
    }
}
```

### 방법 3. 반복문과 Array.Copy()

```csharp
using System;

public class Solution
{
    public int[][] solution(int[] num_list, int n)
    {
        int rows = num_list.Length / n;
        int[][] answer = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            answer[i] = new int[n];
            Array.Copy(num_list, i * n, answer[i], 0, n);
        }

        return answer;
    }
}
```

### 주요 메서드 및 문법

| 문법 | 설명 |
|---|---|
| `Chunk(n)` | 최대 n개씩 묶어 배열 생성 (.NET 6 이상) |
| `Enumerable.Range(0, count)` | 0부터 count개의 연속 정수 생성 |
| `Select()` | 각 원소를 새로운 값으로 변환 |
| `Skip(k)` | 처음 k개 원소 건너뛰기 |
| `Take(n)` | 앞에서 n개 원소 추출 |
| `ToArray()` | 열거 가능한 데이터를 배열로 변환 |
| `Array.Copy()` | 배열의 지정 구간 복사 |
| `int[][]` | 각 행이 별도 배열인 가변 배열 (Jagged Array) |
| `int[,]` | 직사각형 다차원 배열 (Rectangular Array) |

채점 함수의 반환형은 `int[][]`이므로 `int[,]`로 대체하지 않습니다.

---

## 3. Python 소스 코드

### 방법 1. 리스트 컴프리헨션 — 추천

```python
def solution(num_list, n):
    # 시작 인덱스를 n씩 증가시키며 구간 추출
    return [num_list[i:i + n]
            for i in range(0, len(num_list), n)]
```

### 방법 2. 반복문

```python
def solution(num_list, n):
    answer = []

    for i in range(0, len(num_list), n):
        answer.append(num_list[i:i + n])

    return answer
```

### 주요 메서드 및 문법

| 문법 | 설명 |
|---|---|
| `len(num_list)` | 리스트 길이 |
| `range(start, stop, step)` | stop 미만까지 step 간격으로 반복 |
| `num_list[i:i+n]` | i 이상 i+n 미만의 구간을 새 리스트로 복사 |
| `append()` | 리스트 끝에 원소 추가 |
| `[expression for i in iterable]` | 리스트 컴프리헨션 (List Comprehension) |

---

## 4. 코드 동작 과정 (Step-by-Step)

입력: `num_list = [1, 2, 3, 4, 5, 6, 7, 8]`, `n = 2`

```text
[1, 2 | 3, 4 | 5, 6 | 7, 8]
              ↓
[
  [1, 2],
  [3, 4],
  [5, 6],
  [7, 8]
]
```

| 행 인덱스 | 시작 인덱스 | Python 슬라이싱 | 결과 |
|---:|---:|---|---|
| 0 | 0 | [0:2] | [1, 2] |
| 1 | 2 | [2:4] | [3, 4] |
| 2 | 4 | [4:6] | [5, 6] |
| 3 | 6 | [6:8] | [7, 8] |

C#의 `i * n`과 Python의 `range(0, len(num_list), n)`은 동일한 시작 인덱스를 생성합니다. 결과는 4행 2열입니다. 문제의 2 × 4 표현은 일반적인 행 × 열 표기와 반대입니다.

---

## 5. 시간 및 공간 복잡도 (Complexity)

L은 입력 배열 길이, n은 행의 크기입니다.

| 풀이 | 시간 복잡도 | 결과 공간 |
|---|---|---|
| C# Chunk | O(L) | O(L) |
| C# Skip/Take | 배열 최적화 시 O(L), 일반 순차 열거 시 최악 O(L²/n) | O(L) |
| C# Array.Copy | O(L) | O(L) |
| Python 슬라이싱 | O(L) | O(L) |

LINQ의 Skip/Take 성능은 런타임과 원본 자료형에 따라 달라집니다. 결과 배열을 저장하는 공간을 포함했습니다.

---

## 6. 테스트 케이스 (Test Cases)

| 입력 | n | 예상 결과 |
|---|---:|---|
| [1,2,3,4,5,6,7,8] | 2 | [[1,2],[3,4],[5,6],[7,8]] |
| [100,95,2,4,5,6,18,33,948] | 3 | [[100,95,2],[4,5,6],[18,33,948]] |
| [0,-1,0,-1] | 2 | [[0,-1],[0,-1]] |
| [1,2,3,4,5,6] | 3 | [[1,2,3],[4,5,6]] |

### Python 실행 예시

```python
print(solution([1, 2, 3, 4, 5, 6, 7, 8], 2))
# [[1, 2], [3, 4], [5, 6], [7, 8]]
```

---

## 7. 참고 사항 (Conclusion)

- C#은 .NET 6 이상이면 **Chunk()**, 이전 환경에서는 **Range + Select + Skip + Take**를 추천합니다.
- Python은 **슬라이싱과 리스트 컴프리헨션**을 추천합니다.
- 입력의 길이가 n의 배수라는 조건 때문에 나머지 원소 처리는 필요하지 않습니다.
- C# 코드는 별도로 컴파일하지 않았으며, Python의 두 풀이를 아래 테스트에 대해 검증했습니다.
