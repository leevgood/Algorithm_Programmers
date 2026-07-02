# 배열 원소 바꾸기 문제 풀이

## 문제 설명

정수 배열 `arr`와 2차원 정수 배열 `queries`가 주어집니다.

`queries`의 각 원소는 `[i, j]` 형태이며, 각 query마다 `arr[i]`와 `arr[j]`의 값을 서로 바꿉니다.

모든 query를 순서대로 처리한 뒤 최종 배열 `arr`를 반환하는 문제입니다.

---

## 입출력 예시

| arr               | queries                    | result            |
| ----------------- | -------------------------- | ----------------- |
| `[0, 1, 2, 3, 4]` | `[[0, 3], [1, 2], [1, 4]]` | `[3, 4, 1, 0, 2]` |

---

## 문제 풀이 아이디어

각 query는 두 인덱스 `i`, `j`를 의미합니다.

따라서 `queries`를 처음부터 끝까지 반복하면서 다음 작업을 수행하면 됩니다.

1. query에서 `i`, `j` 값을 꺼냅니다.
2. `arr[i]`와 `arr[j]`를 서로 바꿉니다.
3. 모든 query를 처리한 뒤 `arr`를 반환합니다.

배열의 길이와 query의 개수가 최대 1,000이므로 단순 반복문으로 충분히 해결할 수 있습니다.

---

## C# 풀이

```csharp
using System;

public class Solution
{
    public int[] solution(int[] arr, int[,] queries)
    {
        // queries의 행 개수만큼 반복
        for (int q = 0; q < queries.GetLength(0); q++)
        {
            int i = queries[q, 0];
            int j = queries[q, 1];

            // arr[i]와 arr[j] 값 교환
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        return arr;
    }
}
```

---

## C# 코드 설명

| 코드                     | 설명                              |
| ---------------------- | ------------------------------- |
| `queries.GetLength(0)` | 2차원 배열 `queries`의 행 개수를 구합니다.   |
| `queries[q, 0]`        | q번째 query의 첫 번째 인덱스 `i`를 가져옵니다. |
| `queries[q, 1]`        | q번째 query의 두 번째 인덱스 `j`를 가져옵니다. |
| `temp`                 | 두 값을 교환하기 위해 임시로 값을 저장하는 변수입니다. |
| `return arr`           | 모든 query 처리 후 변경된 배열을 반환합니다.    |

---

## Python 풀이

```python
def solution(arr, queries):
    for i, j in queries:
        # arr[i]와 arr[j] 값 교환
        arr[i], arr[j] = arr[j], arr[i]

    return arr
```

---

## Python 코드 설명

| 코드                                | 설명                                    |
| --------------------------------- | ------------------------------------- |
| `for i, j in queries`             | `queries`의 각 원소에서 `i`, `j`를 꺼내 반복합니다. |
| `arr[i], arr[j] = arr[j], arr[i]` | Python의 다중 할당을 이용해 두 값을 교환합니다.        |
| `return arr`                      | 모든 query를 처리한 최종 배열을 반환합니다.           |

---

## 동작 과정 예시

초기 배열:

```text
[0, 1, 2, 3, 4]
```

### 1. query `[0, 3]`

`arr[0]`과 `arr[3]`을 교환합니다.

```text
[3, 1, 2, 0, 4]
```

### 2. query `[1, 2]`

`arr[1]`과 `arr[2]`를 교환합니다.

```text
[3, 2, 1, 0, 4]
```

### 3. query `[1, 4]`

`arr[1]`과 `arr[4]`를 교환합니다.

```text
[3, 4, 1, 0, 2]
```

최종 결과:

```text
[3, 4, 1, 0, 2]
```

---

## 시간 복잡도

`queries`의 길이를 `Q`라고 하면, 각 query마다 한 번의 교환만 수행합니다.

```text
시간 복잡도: O(Q)
```

`Q`는 최대 1,000이므로 매우 효율적입니다.

---

## 공간 복잡도

입력 배열 `arr`를 직접 수정하므로 추가 공간은 거의 사용하지 않습니다.

```text
공간 복잡도: O(1)
```

단, C#에서는 값 교환을 위해 임시 변수 `temp` 하나를 사용합니다.

---

## 핵심 정리

* 각 query는 `[i, j]` 형태입니다.
* `arr[i]`와 `arr[j]`를 순서대로 교환하면 됩니다.
* C#에서는 `temp` 변수를 사용해 값을 교환합니다.
* Python에서는 다중 할당으로 간단히 값을 교환할 수 있습니다.
* 전체 시간 복잡도는 `O(Q)`입니다.
