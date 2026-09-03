# 문자열 묶기 문제 풀이

## 문제 요약

문자열 배열 `strArr`이 주어졌을 때, **문자열의 길이가 같은 것끼리 그룹화**합니다.

각 길이별 문자열 개수를 세고, 그중 **가장 많은 그룹의 크기**를 반환하면 됩니다.

예를 들어:

```text
["a", "bc", "d", "efg", "hi"]
```

문자열 길이별로 나누면:

| 문자열 길이 | 문자열 목록 | 개수 |
|---|---|---:|
| 1 | `["a", "d"]` | 2 |
| 2 | `["bc", "hi"]` | 2 |
| 3 | `["efg"]` | 1 |

따라서 가장 큰 그룹의 크기는 `2`입니다.

---

## 핵심 아이디어

문자열의 실제 내용은 중요하지 않고, **문자열의 길이**만 확인하면 됩니다.

제한사항에서 문자열 길이는 최대 `30`이므로, 길이별 개수를 저장할 배열을 만들 수 있습니다.

```text
count[1] = 길이가 1인 문자열 개수
count[2] = 길이가 2인 문자열 개수
...
count[30] = 길이가 30인 문자열 개수
```

`strArr`을 한 번 순회하면서 각 문자열의 길이를 확인하고 해당 위치의 값을 증가시킵니다.

---

# C# 풀이

## 기본 풀이

```csharp
using System;

public class Solution
{
    public int solution(string[] strArr)
    {
        int[] count = new int[31];
        int answer = 0;

        foreach (string str in strArr)
        {
            int len = str.Length;

            count[len]++;

            answer = Math.Max(answer, count[len]);
        }

        return answer;
    }
}
```

---

## 코드 설명

### 1. 길이별 개수 배열 생성

```csharp
int[] count = new int[31];
```

문자열 길이가 최대 `30`이므로 인덱스 `1 ~ 30`을 사용합니다.

C#의 `int` 배열은 자동으로 모든 값이 `0`으로 초기화됩니다.

즉 다음과 같은 상태입니다.

```text
count[0] = 0
count[1] = 0
count[2] = 0
...
count[30] = 0
```

---

### 2. 문자열 배열 순회

```csharp
foreach (string str in strArr)
```

`strArr`에 있는 문자열을 하나씩 가져옵니다.

예를 들어:

```text
"a"
"bc"
"d"
"efg"
"hi"
```

순서로 확인합니다.

---

### 3. 문자열 길이 확인

```csharp
int len = str.Length;
```

C# 문자열의 길이는 `.Length`로 구합니다.

```csharp
"a".Length       // 1
"bc".Length      // 2
"efg".Length     // 3
```

---

### 4. 해당 길이의 개수 증가

```csharp
count[len]++;
```

예를 들어 `"bc"`의 길이는 `2`이므로:

```csharp
count[2]++;
```

가 실행됩니다.

---

### 5. 현재 최대 개수 갱신

```csharp
answer = Math.Max(answer, count[len]);
```

문자열을 처리할 때마다 현재 그룹의 개수와 기존 최대값을 비교합니다.

따라서 마지막에 별도로 `count` 배열을 다시 탐색할 필요가 없습니다.

---

## 동작 과정

입력:

```csharp
string[] strArr = { "a", "bc", "d", "efg", "hi" };
```

처리 과정:

| 문자열 | 길이 | 증가한 값 | answer |
|---|---:|---:|---:|
| `"a"` | 1 | `count[1] = 1` | 1 |
| `"bc"` | 2 | `count[2] = 1` | 1 |
| `"d"` | 1 | `count[1] = 2` | 2 |
| `"efg"` | 3 | `count[3] = 1` | 2 |
| `"hi"` | 2 | `count[2] = 2` | 2 |

결과:

```text
2
```

---

# Python 풀이

```python
def solution(strArr):
    count = [0] * 31
    answer = 0

    for s in strArr:
        length = len(s)

        count[length] += 1

        answer = max(answer, count[length])

    return answer
```

---

## Python 코드 설명

### 길이별 개수 배열

```python
count = [0] * 31
```

길이가 `31`인 리스트를 만들고 모든 값을 `0`으로 초기화합니다.

```text
[0, 0, 0, ..., 0]
```

문자열 길이가 최대 `30`이므로 `count[1]`부터 `count[30]`까지 사용합니다.

---

### 문자열 길이

```python
length = len(s)
```

Python에서는 `len()` 함수를 사용하여 문자열 길이를 구합니다.

```python
len("a")    # 1
len("bc")   # 2
len("efg")  # 3
```

---

### 그룹 개수 증가

```python
count[length] += 1
```

현재 문자열 길이에 해당하는 개수를 하나 증가시킵니다.

---

### 최대값 갱신

```python
answer = max(answer, count[length])
```

현재까지 가장 많은 그룹의 크기를 계속 저장합니다.

---

# 다른 풀이: Dictionary 사용

문자열 길이 제한이 작기 때문에 배열 방식이 가장 간단하지만, 길이 제한을 모르는 일반적인 문제라면 `Dictionary`를 사용할 수도 있습니다.

## C#

```csharp
using System;
using System.Collections.Generic;

public class Solution
{
    public int solution(string[] strArr)
    {
        Dictionary<int, int> count = new Dictionary<int, int>();

        int answer = 0;

        foreach (string str in strArr)
        {
            int len = str.Length;

            if (!count.ContainsKey(len))
            {
                count[len] = 0;
            }

            count[len]++;

            answer = Math.Max(answer, count[len]);
        }

        return answer;
    }
}
```

---

## Python

```python
def solution(strArr):
    count = {}
    answer = 0

    for s in strArr:
        length = len(s)

        count[length] = count.get(length, 0) + 1

        answer = max(answer, count[length])

    return answer
```

---

# 시간 복잡도

문자열 개수를 `N`이라고 하면 모든 문자열을 한 번씩 확인합니다.

```text
시간 복잡도: O(N)
```

문자열 길이는 최대 `30`이므로 길이별 배열 크기는 항상 `31`입니다.

```text
공간 복잡도: O(1)
```

배열 크기가 입력 크기와 관계없이 고정되어 있기 때문입니다.

---

# 핵심 정리

이 문제에서는 문자열 자체를 저장하거나 그룹을 실제로 만들 필요가 없습니다.

필요한 것은 오직:

```text
문자열 길이 → 해당 길이 문자열의 개수
```

입니다.

따라서 가장 적합한 방법은 다음과 같습니다.

### C#

```csharp
int[] count = new int[31];
```

### Python

```python
count = [0] * 31
```

그리고 배열을 한 번 순회하면서:

```text
1. 문자열 길이를 구한다.
2. 해당 길이의 개수를 증가시킨다.
3. 최대 개수를 갱신한다.
```

이렇게 하면 `O(N)`으로 문제를 해결할 수 있습니다.
