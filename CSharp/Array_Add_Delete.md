# [Problem Solution] 빈 배열에 추가, 삭제하기

## 개요 (Overview)

빈 배열 `X`에서 시작하여 `flag` 배열을 순서대로 확인하면서 다음 작업을 수행합니다.

- `flag[i] == true`이면  
  `arr[i]`를 `arr[i] * 2`번 배열의 뒤에 추가합니다.
- `flag[i] == false`이면  
  배열의 뒤에서 `arr[i]`개의 원소를 제거합니다.

최종적으로 완성된 배열 `X`를 반환합니다.

---

## 핵심 개념 (Key Concepts)

이 문제의 핵심은 **동적 배열(List)** 을 사용하는 것입니다.

배열의 뒤에 값을 계속 추가하거나 마지막 값을 제거해야 하기 때문에, 고정 길이 배열보다는 다음 자료구조가 적합합니다.

- C#: `List<int>`
- Python: `list`

특히 마지막 원소를 제거할 때는 다음 메서드를 사용합니다.

| 언어 | 추가 | 마지막 원소 삭제 |
|---|---|---|
| C# | `Add()` | `RemoveAt(list.Count - 1)` |
| Python | `append()` | `pop()` |

---

# C# Solution

## 소스 코드

```csharp
using System;
using System.Collections.Generic;

public class Solution
{
    public int[] solution(int[] arr, bool[] flag)
    {
        // 결과를 저장할 동적 배열
        List<int> result = new List<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            if (flag[i])
            {
                // arr[i] 값을 arr[i] * 2번 추가
                for (int j = 0; j < arr[i] * 2; j++)
                {
                    result.Add(arr[i]);
                }
            }
            else
            {
                // 마지막 원소를 arr[i]개 제거
                for (int j = 0; j < arr[i]; j++)
                {
                    result.RemoveAt(result.Count - 1);
                }
            }
        }

        return result.ToArray();
    }
}
```

---

## 주요 메서드 및 문법 설명

| 문법 / 메서드 | 설명 |
|---|---|
| `List<int>` | 크기를 자유롭게 변경할 수 있는 정수 리스트 |
| `result.Add(value)` | 리스트 마지막에 값을 추가 |
| `result.Count` | 현재 리스트의 원소 개수 |
| `RemoveAt(index)` | 해당 인덱스의 원소를 삭제 |
| `result.Count - 1` | 마지막 원소의 인덱스 |
| `ToArray()` | `List<int>`를 `int[]` 배열로 변환 |
| `if (flag[i])` | `flag[i]`가 `true`인지 확인 |

### `Remove()`와 `RemoveAt()`의 차이

```csharp
result.Remove(3);
```

위 코드는 **값이 3인 원소**를 찾아 삭제합니다.

반면,

```csharp
result.RemoveAt(result.Count - 1);
```

위 코드는 **마지막 위치의 원소**를 삭제합니다.

이 문제에서는 뒤에서 원소를 제거해야 하므로 `RemoveAt()`이 적절합니다.

---

# Python Solution

## 소스 코드

```python
def solution(arr, flag):
    # 결과를 저장할 리스트
    result = []

    for i in range(len(arr)):

        if flag[i]:
            # arr[i]를 arr[i] * 2번 추가
            for _ in range(arr[i] * 2):
                result.append(arr[i])

        else:
            # 마지막 원소를 arr[i]개 제거
            for _ in range(arr[i]):
                result.pop()

    return result
```

---

## 주요 메서드 및 문법 설명

| 문법 / 메서드 | 설명 |
|---|---|
| `result = []` | 빈 리스트 생성 |
| `range(len(arr))` | `0`부터 `len(arr)-1`까지 반복 |
| `if flag[i]` | `flag[i]`가 `True`인지 확인 |
| `append(value)` | 리스트 마지막에 값을 추가 |
| `pop()` | 리스트의 마지막 원소를 삭제 |
| `_` | 반복 변수의 값을 사용하지 않을 때 주로 사용하는 변수명 |

---

## Python에서 주의할 점

잘못된 코드:

```python
if arr[i] == True:
```

조건을 판단해야 하는 배열은 `arr`가 아니라 **`flag`** 입니다.

따라서 다음과 같이 작성해야 합니다.

```python
if flag[i]:
```

또한 다음 코드는 마지막 원소를 삭제하는 코드가 아닙니다.

```python
result.remove(-1)
```

`remove(-1)`은 리스트에서 **값이 -1인 원소**를 찾아 삭제합니다.

마지막 원소를 제거하려면 다음과 같이 작성합니다.

```python
result.pop()
```

---

# 입력 예시

```text
arr = [3, 2, 4, 1, 3]
flag = [true, false, true, false, false]
```

Python에서는 Boolean 값을 다음과 같이 작성합니다.

```python
arr = [3, 2, 4, 1, 3]
flag = [True, False, True, False, False]
```

---

# 출력 예시

```text
[3, 3, 3, 3, 4, 4, 4, 4]
```

---

# 코드 동작 과정

초기 상태:

```text
X = []
```

### 1. `arr[0] = 3`, `flag[0] = true`

`3`을 `3 * 2 = 6`번 추가합니다.

```text
[3, 3, 3, 3, 3, 3]
```

### 2. `arr[1] = 2`, `flag[1] = false`

뒤에서 2개를 삭제합니다.

```text
[3, 3, 3, 3]
```

### 3. `arr[2] = 4`, `flag[2] = true`

`4`를 `4 * 2 = 8`번 추가합니다.

```text
[3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4]
```

### 4. `arr[3] = 1`, `flag[3] = false`

마지막 원소 1개를 삭제합니다.

```text
[3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4]
```

### 5. `arr[4] = 3`, `flag[4] = false`

마지막 원소 3개를 삭제합니다.

```text
[3, 3, 3, 3, 4, 4, 4, 4]
```

따라서 최종 결과는 다음과 같습니다.

```text
[3, 3, 3, 3, 4, 4, 4, 4]
```

---

# 시간 복잡도 (Time Complexity)

단순히 `arr`의 길이만 반복하는 것이 아니라, 각 원소에 따라 여러 번 추가 또는 삭제 작업을 수행합니다.

`arr[i]`의 최댓값이 9이므로 한 번의 반복에서 수행되는 작업량은 매우 작습니다.

전체 수행 횟수를 `K`라고 하면 시간 복잡도는 대략 다음과 같습니다.

```text
O(K)
```

문제의 제한사항이 작기 때문에 충분히 빠르게 실행됩니다.

---

# 참고 사항 (Conclusion)

이 문제에서 기억해야 할 핵심은 다음과 같습니다.

1. `flag[i]`를 이용해 추가 또는 삭제 작업을 결정합니다.
2. `true`이면 `arr[i]`를 `arr[i] * 2`번 추가합니다.
3. `false`이면 마지막 원소를 `arr[i]`번 삭제합니다.
4. C#에서는 `List<int>`와 `RemoveAt()`을 사용합니다.
5. Python에서는 `list`와 `pop()`을 사용합니다.

두 언어 모두 기본적인 **리스트(List) 조작**과 **반복문(Loop)** 을 연습하기 좋은 문제입니다.
