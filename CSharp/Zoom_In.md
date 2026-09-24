# 그림 확대하기 (Picture Enlargement)

## 문제 설명

직사각형 형태의 그림 파일이 있으며, 각 픽셀은 `1 × 1` 크기의 정사각형입니다.

문자열 배열 `picture`와 정수 `k`가 주어질 때, 그림을 **가로와 세로 방향으로 각각 `k`배 확대**한 결과를 문자열 배열로 반환해야 합니다.

---

## 핵심 아이디어

그림을 `k`배 확대하려면 두 가지 작업이 필요합니다.

1. **가로 확대**
   - 각 문자를 `k`번 반복합니다.
   - 예: `"x."`, `k = 3`
   - 결과: `"xxx..."`

2. **세로 확대**
   - 가로로 확대된 한 줄을 `k`번 반복해서 결과 배열에 추가합니다.

예를 들어:

```text
원본:
x.
.x

k = 2

가로 확대:
xx..
..xx

세로 확대:
xx..
xx..
..xx
..xx
```

---

# C# 풀이

## Solution

```csharp
using System;
using System.Collections.Generic;
using System.Text;

public class Solution
{
    public string[] solution(string[] picture, int k)
    {
        List<string> answer = new List<string>();

        foreach (string row in picture)
        {
            StringBuilder expandedRow = new StringBuilder();

            // 각 문자를 가로 방향으로 k번 반복
            foreach (char pixel in row)
            {
                expandedRow.Append(new string(pixel, k));
            }

            // 완성된 한 줄을 세로 방향으로 k번 반복
            for (int i = 0; i < k; i++)
            {
                answer.Add(expandedRow.ToString());
            }
        }

        return answer.ToArray();
    }
}
```

---

## C# 코드 설명

### 1. 결과를 저장할 리스트 생성

```csharp
List<string> answer = new List<string>();
```

확대된 각 행을 차례대로 저장합니다.

---

### 2. 원본 그림의 각 행을 순회

```csharp
foreach (string row in picture)
```

`picture`의 각 문자열은 그림의 한 줄을 의미합니다.

---

### 3. 각 문자를 `k`번 반복

```csharp
foreach (char pixel in row)
{
    expandedRow.Append(new string(pixel, k));
}
```

예를 들어:

```text
row = "x.x"
k = 3
```

각 문자는 다음과 같이 변환됩니다.

```text
x → xxx
. → ...
x → xxx
```

따라서:

```text
"xxx...xxx"
```

가 됩니다.

---

### 4. 확대된 행을 `k`번 추가

```csharp
for (int i = 0; i < k; i++)
{
    answer.Add(expandedRow.ToString());
}
```

가로로 확대된 한 줄을 `k`번 반복하여 세로 방향도 확대합니다.

---

## C# 주요 문법

| 문법 | 설명 |
|---|---|
| `List<string>` | 문자열을 동적으로 저장하는 리스트 |
| `foreach` | 배열이나 문자열의 요소를 순서대로 반복 |
| `StringBuilder` | 문자열을 반복해서 이어 붙일 때 효율적 |
| `new string(pixel, k)` | 문자 `pixel`을 `k`번 반복한 문자열 생성 |
| `ToArray()` | `List<string>`을 `string[]` 배열로 변환 |

---

# Python 풀이

## Solution

```python
def solution(picture, k):
    answer = []

    for row in picture:
        expanded_row = ""

        # 각 문자를 가로 방향으로 k번 반복
        for pixel in row:
            expanded_row += pixel * k

        # 완성된 한 줄을 세로 방향으로 k번 반복
        for _ in range(k):
            answer.append(expanded_row)

    return answer
```

---

## Python 코드 설명

### 1. 결과 리스트 생성

```python
answer = []
```

확대된 그림의 각 행을 저장합니다.

---

### 2. 그림의 각 행을 순회

```python
for row in picture:
```

각 `row`는 원본 그림의 한 줄입니다.

---

### 3. 각 문자를 `k`번 반복

```python
for pixel in row:
    expanded_row += pixel * k
```

Python에서는 문자열에 정수를 곱하면 문자열이 반복됩니다.

예:

```python
"x" * 3
```

결과:

```text
xxx
```

따라서:

```text
"x.x" → "xxx...xxx"
```

처럼 가로 확대가 가능합니다.

---

### 4. 확대된 행을 `k`번 추가

```python
for _ in range(k):
    answer.append(expanded_row)
```

한 줄을 `k`번 추가해서 세로 방향도 확대합니다.

---

# Python 간단 풀이

Python에서는 리스트 컴프리헨션을 이용해 더 짧게 작성할 수도 있습니다.

```python
def solution(picture, k):
    answer = []

    for row in picture:
        expanded = ''.join(pixel * k for pixel in row)
        answer.extend([expanded] * k)

    return answer
```

`''.join(...)`을 사용하면 문자열을 반복해서 `+=` 하는 것보다 일반적으로 효율적입니다.

---

# 예제

입력:

```text
picture = ["x.x", ".x.", "x.x"]
k = 3
```

가로 확대:

```text
xxx...xxx
...xxx...
xxx...xxx
```

각 줄을 3번 반복:

```text
xxx...xxx
xxx...xxx
xxx...xxx
...xxx...
...xxx...
...xxx...
xxx...xxx
xxx...xxx
xxx...xxx
```

결과:

```text
[
    "xxx...xxx",
    "xxx...xxx",
    "xxx...xxx",
    "...xxx...",
    "...xxx...",
    "...xxx...",
    "xxx...xxx",
    "xxx...xxx",
    "xxx...xxx"
]
```

---

# 시간 복잡도

원본 그림의 크기를 다음과 같이 두겠습니다.

- 세로 길이: `H`
- 가로 길이: `W`
- 확대 배수: `k`

최종 그림의 크기는:

```text
(H × k) × (W × k)
```

이므로 최종적으로 생성해야 하는 문자 수는:

```text
H × W × k²
```

따라서 전체 시간 복잡도는 대략:

```text
O(H × W × k²)
```

입니다.

공간 복잡도 역시 결과 배열 자체가 같은 크기를 가지므로:

```text
O(H × W × k²)
```

입니다.

---

# 정리

이 문제에서 기억할 핵심은 다음 두 단계입니다.

```text
1. 각 문자를 k번 반복한다. → 가로 확대
2. 확대된 각 행을 k번 반복한다. → 세로 확대
```

C#에서는:

```csharp
new string(pixel, k)
```

Python에서는:

```python
pixel * k
```

를 이용하면 문자를 간단하게 반복할 수 있습니다.
