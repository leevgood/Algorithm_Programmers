# 전국 대회 선발 고사 풀이 (C# / Python)

## 1. 문제 요약

`rank[i]`는 **i번 학생의 시험 등수**이고,  
`attendance[i]`는 **i번 학생이 전국 대회에 참가 가능한지 여부**를 나타냅니다.

참가 가능한 학생들 중에서 등수가 가장 높은 학생 3명을 선발합니다.

선발된 학생 번호를 등수가 높은 순서대로 `a`, `b`, `c`라고 할 때 다음 값을 반환합니다.

```text
10000 × a + 100 × b + c
```

---

## 2. 핵심 아이디어

등수가 높다는 것은 `rank` 값이 **작다**는 의미입니다.

예를 들어:

```text
rank = [3, 7, 2, 5, 4, 6, 1]
```

학생 번호와 등수는 다음과 같습니다.

| 학생 번호 | 등수 |
|---:|---:|
| 0 | 3 |
| 1 | 7 |
| 2 | 2 |
| 3 | 5 |
| 4 | 4 |
| 5 | 6 |
| 6 | 1 |

여기서 `attendance[i] == true`인 학생만 선택한 뒤,  
그 학생들을 `rank[i]` 기준으로 오름차순 정렬하면 됩니다.

즉, 풀이 과정은 다음과 같습니다.

1. 모든 학생을 확인한다.
2. `attendance[i] == true`인 학생만 선택한다.
3. 선택된 학생을 `rank[i]`가 작은 순서대로 정렬한다.
4. 앞에서 3명의 학생 번호를 각각 `a`, `b`, `c`로 가져온다.
5. `10000 * a + 100 * b + c`를 반환한다.

---

# 3. C# 풀이

## C# 코드

```csharp
using System;
using System.Linq;

public class Solution
{
    public int solution(int[] rank, bool[] attendance)
    {
        int[] selected = Enumerable.Range(0, rank.Length)
            .Where(i => attendance[i])
            .OrderBy(i => rank[i])
            .Take(3)
            .ToArray();

        int a = selected[0];
        int b = selected[1];
        int c = selected[2];

        return 10000 * a + 100 * b + c;
    }
}
```

---

## C# 코드 설명

### `Enumerable.Range()`

```csharp
Enumerable.Range(0, rank.Length)
```

학생 번호를 생성합니다.

예를 들어 학생이 7명이면 다음과 같습니다.

```text
0, 1, 2, 3, 4, 5, 6
```

---

### `Where()`

```csharp
.Where(i => attendance[i])
```

전국 대회에 참가 가능한 학생만 선택합니다.

즉,

```csharp
attendance[i] == true
```

인 학생 번호만 남깁니다.

---

### `OrderBy()`

```csharp
.OrderBy(i => rank[i])
```

학생 번호를 시험 등수 기준으로 정렬합니다.

등수는 숫자가 작을수록 높은 순위이므로 **오름차순 정렬**합니다.

예를 들어:

```text
학생 2 → 2등
학생 4 → 4등
학생 3 → 5등
학생 1 → 7등
```

이라면 다음 순서가 됩니다.

```text
2 → 4 → 3 → 1
```

---

### `Take(3)`

```csharp
.Take(3)
```

등수가 가장 높은 학생 3명만 선택합니다.

---

### 결과 계산

```csharp
return 10000 * a + 100 * b + c;
```

문제에서 요구하는 공식 그대로 계산합니다.

---

# 4. C# 반복문 풀이

LINQ를 사용하지 않고 작성할 수도 있습니다.

```csharp
using System;
using System.Collections.Generic;

public class Solution
{
    public int solution(int[] rank, bool[] attendance)
    {
        List<int> students = new List<int>();

        for (int i = 0; i < rank.Length; i++)
        {
            if (attendance[i])
            {
                students.Add(i);
            }
        }

        students.Sort((a, b) => rank[a].CompareTo(rank[b]));

        int first = students[0];
        int second = students[1];
        int third = students[2];

        return 10000 * first + 100 * second + third;
    }
}
```

### 핵심 부분

```csharp
students.Sort((a, b) => rank[a].CompareTo(rank[b]));
```

여기서 `students`에는 **학생 번호**가 들어 있습니다.

따라서 학생 번호 자체를 비교하는 것이 아니라,

```csharp
rank[a]
rank[b]
```

를 비교하여 등수가 높은 순서대로 정렬합니다.

---

# 5. Python 풀이

## Python 코드

```python
def solution(rank, attendance):
    students = [
        i
        for i in range(len(rank))
        if attendance[i]
    ]

    students.sort(key=lambda i: rank[i])

    a, b, c = students[:3]

    return 10000 * a + 100 * b + c
```

---

## Python 코드 설명

### 참가 가능한 학생 선택

```python
students = [
    i
    for i in range(len(rank))
    if attendance[i]
]
```

`attendance[i]`가 `True`인 학생 번호만 리스트에 저장합니다.

예를 들어:

```python
attendance = [False, True, True, True, True, False, False]
```

이면:

```python
students = [1, 2, 3, 4]
```

가 됩니다.

---

### 시험 등수 기준 정렬

```python
students.sort(key=lambda i: rank[i])
```

학생 번호를 `rank[i]`를 기준으로 오름차순 정렬합니다.

즉, 가장 높은 등수의 학생이 리스트 앞쪽으로 이동합니다.

---

### 상위 3명 선택

```python
a, b, c = students[:3]
```

정렬된 학생 중 앞의 3명을 가져옵니다.

---

### 결과 계산

```python
return 10000 * a + 100 * b + c
```

---

# 6. Python 한 줄 스타일 풀이

조금 더 간단하게 작성하면 다음과 같습니다.

```python
def solution(rank, attendance):
    students = sorted(
        [i for i in range(len(rank)) if attendance[i]],
        key=lambda i: rank[i]
    )

    return 10000 * students[0] + 100 * students[1] + students[2]
```

---

# 7. 예제 1 동작 과정

```text
rank       = [3, 7, 2, 5, 4, 6, 1]
attendance = [F, T, T, T, T, F, F]
```

참가 가능한 학생은:

```text
1번 → 7등
2번 → 2등
3번 → 5등
4번 → 4등
```

등수 순으로 정렬하면:

```text
2번 → 4번 → 3번 → 1번
```

상위 3명은:

```text
a = 2
b = 4
c = 3
```

따라서:

```text
10000 × 2 + 100 × 4 + 3
= 20000 + 400 + 3
= 20403
```

정답:

```text
20403
```

---

# 8. 예제 2 동작 과정

```text
rank       = [1, 2, 3]
attendance = [T, T, T]
```

등수 순서가 그대로:

```text
0번 → 1번 → 2번
```

따라서:

```text
a = 0
b = 1
c = 2
```

계산하면:

```text
10000 × 0 + 100 × 1 + 2
= 102
```

정답:

```text
102
```

---

# 9. 예제 3 동작 과정

```text
rank       = [6, 1, 5, 2, 3, 4]
attendance = [T, F, T, F, F, T]
```

참가 가능한 학생:

```text
0번 → 6등
2번 → 5등
5번 → 4등
```

등수 순으로 정렬하면:

```text
5번 → 2번 → 0번
```

따라서:

```text
a = 5
b = 2
c = 0
```

계산하면:

```text
10000 × 5 + 100 × 2 + 0
= 50200
```

정답:

```text
50200
```

---

# 10. 시간 복잡도

학생 수를 `n`이라고 하면 참가 가능한 학생들을 정렬하므로 시간 복잡도는 다음과 같습니다.

```text
O(n log n)
```

문제에서:

```text
n ≤ 100
```

이므로 충분히 빠릅니다.

---

# 11. 핵심 정리

이 문제에서 가장 중요한 부분은 **학생 번호와 등수를 구분하는 것**입니다.

```text
i       = 학생 번호
rank[i] = 해당 학생의 등수
```

따라서 학생 번호를 저장한 뒤,

```csharp
rank[i]
```

또는

```python
rank[i]
```

를 기준으로 정렬해야 합니다.

### C# 핵심 코드

```csharp
int[] selected = Enumerable.Range(0, rank.Length)
    .Where(i => attendance[i])
    .OrderBy(i => rank[i])
    .Take(3)
    .ToArray();

return 10000 * selected[0]
     + 100 * selected[1]
     + selected[2];
```

### Python 핵심 코드

```python
students = sorted(
    [i for i in range(len(rank)) if attendance[i]],
    key=lambda i: rank[i]
)

return 10000 * students[0] + 100 * students[1] + students[2]
```
