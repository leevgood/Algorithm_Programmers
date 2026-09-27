# 단위 행렬 만들기 (C# / Python)

## 1. 문제 요약

정수 `n`이 주어질 때, `n × n` 크기의 2차원 배열을 생성합니다.

조건은 다음과 같습니다.

- `i == j`인 경우: `1`
- `i != j`인 경우: `0`

즉, **주대각선(Main Diagonal)** 의 값만 `1`이고 나머지는 모두 `0`인 **단위 행렬(Identity Matrix)** 을 반환하는 문제입니다.

### 예시

`n = 3`

```text
1 0 0
0 1 0
0 0 1
```

반환 결과:

```text
[[1, 0, 0],
 [0, 1, 0],
 [0, 0, 1]]
```

---

## 2. 핵심 아이디어

2차원 배열을 생성하면 정수형 배열의 각 원소는 기본적으로 `0`으로 초기화됩니다.

따라서 모든 원소를 하나씩 검사할 필요 없이,

```text
(0, 0)
(1, 1)
(2, 2)
...
(n-1, n-1)
```

처럼 **행 인덱스와 열 인덱스가 같은 위치만 `1`로 변경**하면 됩니다.

즉,

```text
arr[i][i] = 1
```

이라는 아이디어가 핵심입니다.

---

# C# 풀이

## 3. 정답 코드

```csharp
using System;

public class Solution
{
    public int[,] solution(int n)
    {
        // n x n 크기의 2차원 배열 생성
        // int 배열의 기본값은 0
        int[,] answer = new int[n, n];

        // 주대각선만 1로 변경
        for (int i = 0; i < n; i++)
        {
            answer[i, i] = 1;
        }

        return answer;
    }
}
```

---

## 4. C# 코드 설명

### 4.1 2차원 배열 생성

```csharp
int[,] answer = new int[n, n];
```

`n × n` 크기의 2차원 배열을 생성합니다.

C#에서 `int` 배열의 기본값은 모두 `0`입니다.

예를 들어 `n = 3`이면 처음에는 다음과 같습니다.

```text
0 0 0
0 0 0
0 0 0
```

---

### 4.2 주대각선에 1 저장

```csharp
for (int i = 0; i < n; i++)
{
    answer[i, i] = 1;
}
```

`i`를 행과 열 인덱스에 동시에 사용합니다.

실행 과정은 다음과 같습니다.

```csharp
answer[0, 0] = 1;
answer[1, 1] = 1;
answer[2, 2] = 1;
```

결과:

```text
1 0 0
0 1 0
0 0 1
```

---

## 5. 이중 반복문으로도 작성 가능

```csharp
public int[,] solution(int n)
{
    int[,] answer = new int[n, n];

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (i == j)
            {
                answer[i, j] = 1;
            }
        }
    }

    return answer;
}
```

이 코드도 정답이지만 모든 `n × n` 원소를 검사합니다.

첫 번째 방법은 대각선 `n`개만 변경하므로 더 간결하고 효율적입니다.

---

## 6. C#에서 주의할 점

### `int[,]`와 `int[][]`의 차이

C#에는 대표적으로 두 종류의 2차원 배열 표현이 있습니다.

### 다차원 배열(Multidimensional Array)

```csharp
int[,] arr = new int[3, 3];

arr[0, 0] = 1;
```

접근 방법:

```csharp
arr[i, j]
```

---

### 가변 배열(Jagged Array)

```csharp
int[][] arr = new int[3][];

arr[0] = new int[3];
arr[1] = new int[3];
arr[2] = new int[3];
```

접근 방법:

```csharp
arr[i][j]
```

이번 문제에서 함수 반환형이

```csharp
int[,]
```

이므로 `int[,]` 형식을 사용해야 합니다.

---

## 7. 처음 코드에서 발생한 주요 오류

다음과 같은 형태는 올바른 C# 문법이 아닙니다.

```csharp
int [i] var1 = {0};
```

배열의 크기를 변수로 지정하려면 다음처럼 작성합니다.

```csharp
int[] var1 = new int[n];
```

또한 다음 코드는 제네릭 타입이 일치하지 않습니다.

```csharp
List<int[]> list = new List<int>();
```

올바른 형태는 다음과 같습니다.

```csharp
List<int[]> list = new List<int[]>();
```

하지만 이렇게 만들어도

```csharp
list.ToArray()
```

의 결과는

```csharp
int[][]
```

이므로 문제에서 요구하는

```csharp
int[,]
```

와는 다른 자료형입니다.

따라서 이 문제에서는 `List`를 사용하는 것보다 처음부터 `int[,]` 배열을 만드는 것이 가장 좋습니다.

---

# Python 풀이

## 8. Python 정답 코드

```python
def solution(n):
    answer = [[0] * n for _ in range(n)]

    for i in range(n):
        answer[i][i] = 1

    return answer
```

---

## 9. Python 코드 설명

### 9.1 `n × n` 배열 생성

```python
answer = [[0] * n for _ in range(n)]
```

예를 들어 `n = 3`이면:

```python
[
    [0, 0, 0],
    [0, 0, 0],
    [0, 0, 0]
]
```

가 만들어집니다.

---

### 9.2 대각선 값 변경

```python
for i in range(n):
    answer[i][i] = 1
```

실행 과정:

```python
answer[0][0] = 1
answer[1][1] = 1
answer[2][2] = 1
```

결과:

```python
[
    [1, 0, 0],
    [0, 1, 0],
    [0, 0, 1]
]
```

---

## 10. Python 한 줄 풀이

리스트 컴프리헨션(List Comprehension)을 이용하면 다음과 같이 작성할 수도 있습니다.

```python
def solution(n):
    return [[1 if i == j else 0 for j in range(n)] for i in range(n)]
```

이 방법은 모든 `i`, `j` 조합을 검사합니다.

알고리즘 원리를 직관적으로 확인하기에는 좋지만, 이 문제에서는 배열을 `0`으로 생성한 뒤 대각선만 `1`로 바꾸는 방법이 더 간단합니다.

---

# 시간 복잡도와 공간 복잡도

## 11. 시간 복잡도(Time Complexity)

대각선 값만 변경하는 반복문 자체는:

```text
O(n)
```

입니다.

다만 실제로 `n × n` 크기의 결과 배열을 생성해야 하므로 결과 배열 생성까지 고려하면 전체적으로는:

```text
O(n²)
```

의 공간과 초기화 비용이 필요합니다.

---

## 12. 공간 복잡도(Space Complexity)

`n × n` 크기의 배열을 반환하므로:

```text
O(n²)
```

입니다.

---

# 알고리즘 테스트 핵심 정리

## 13. 기억할 포인트

1. **정수 배열은 기본적으로 0으로 초기화된다.**
2. `i == j`는 2차원 배열의 **주대각선**을 의미한다.
3. 모든 원소를 검사하지 않고 `arr[i][i]`만 변경할 수 있다.
4. C#의 `int[,]`와 `int[][]`는 서로 다른 자료형이다.
5. Python에서는 `answer[i][i]`, C#에서는 `answer[i, i]`로 접근한다.

---

## 14. C# / Python 문법 비교

| 기능 | C# | Python |
|---|---|---|
| 2차원 배열 생성 | `new int[n, n]` | `[[0] * n for _ in range(n)]` |
| 원소 접근 | `arr[i, j]` | `arr[i][j]` |
| 반복문 | `for (int i = 0; i < n; i++)` | `for i in range(n)` |
| 대각선 설정 | `arr[i, i] = 1` | `arr[i][i] = 1` |
| 반환 | `return answer;` | `return answer` |

---

## 15. 최종 정답

### C#

```csharp
using System;

public class Solution
{
    public int[,] solution(int n)
    {
        int[,] answer = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            answer[i, i] = 1;
        }

        return answer;
    }
}
```

### Python

```python
def solution(n):
    answer = [[0] * n for _ in range(n)]

    for i in range(n):
        answer[i][i] = 1

    return answer
```
