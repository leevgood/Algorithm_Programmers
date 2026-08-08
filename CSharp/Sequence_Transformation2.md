# 조건에 맞게 수열 변환하기 2

## 문제 설명

정수 배열 `arr`의 각 원소에 다음 규칙을 적용합니다.

- 값이 `50` 이상인 짝수라면 `2`로 나눕니다.
- 값이 `50` 미만인 홀수라면 `2`를 곱한 후 `1`을 더합니다.
- 나머지 값은 변경하지 않습니다.

이 작업을 `x`번 반복한 배열을 `arr(x)`라고 할 때, `arr(x) = arr(x + 1)`을 만족하는 가장 작은 `x`를 구합니다.

---

## 제한사항

- `1 ≤ arr의 길이 ≤ 1,000,000`
- `1 ≤ arr의 원소 ≤ 100`

---

## 입출력 예

| arr | result |
| --- | ---: |
| `[1, 2, 3, 100, 99, 98]` | `5` |

---

## 풀이 아이디어

배열 전체를 순회하면서 각 원소에 변환 규칙을 적용합니다.

이때 원소가 하나라도 변경되었다면 다음 반복을 진행하고, 모든 원소가 그대로라면 현재 반복 횟수를 반환합니다.

변환 전 배열 전체를 복사할 필요 없이 각 원소의 변환 전후 값만 비교하면 추가 배열 없이 정답을 구할 수 있습니다.

### 반복 횟수 처리

현재 배열이 `arr(x)`라고 가정하고 한 번 변환하여 `arr(x + 1)`을 만듭니다.

- 변한 원소가 없다면 `arr(x) = arr(x + 1)`이므로 `x`를 반환합니다.
- 변한 원소가 있다면 `x`를 1 증가시키고 다음 변환을 진행합니다.

---

## C# 풀이

```csharp
using System;

public class Solution
{
    public int solution(int[] arr)
    {
        int x = 0;

        while (true)
        {
            bool changed = false;

            for (int i = 0; i < arr.Length; i++)
            {
                int current = arr[i];

                if (current >= 50 && current % 2 == 0)
                {
                    arr[i] = current / 2;
                }
                else if (current < 50 && current % 2 == 1)
                {
                    arr[i] = current * 2 + 1;
                }

                if (arr[i] != current)
                {
                    changed = true;
                }
            }

            if (!changed)
            {
                return x;
            }

            x++;
        }
    }
}
```

---

## Python 풀이

```python
def solution(arr):
    x = 0

    while True:
        changed = False

        for i in range(len(arr)):
            current = arr[i]

            if current >= 50 and current % 2 == 0:
                arr[i] = current // 2
            elif current < 50 and current % 2 == 1:
                arr[i] = current * 2 + 1

            if arr[i] != current:
                changed = True

        if not changed:
            return x

        x += 1
```

---

## 실행 과정

입력 배열이 `[1, 2, 3, 100, 99, 98]`인 경우 다음과 같이 변합니다.

| 반복 횟수 | 배열 |
| ---: | --- |
| 0 | `[1, 2, 3, 100, 99, 98]` |
| 1 | `[3, 2, 7, 50, 99, 49]` |
| 2 | `[7, 2, 15, 25, 99, 99]` |
| 3 | `[15, 2, 31, 51, 99, 99]` |
| 4 | `[31, 2, 63, 51, 99, 99]` |
| 5 | `[63, 2, 63, 51, 99, 99]` |
| 6 | `[63, 2, 63, 51, 99, 99]` |

`arr(5)`와 `arr(6)`이 같으므로 정답은 `5`입니다.

---

## 복잡도

배열의 길이를 `N`, 배열이 안정될 때까지의 반복 횟수를 `K`라고 하면 다음과 같습니다.

- 시간 복잡도: `O(N × K)`
- 추가 공간 복잡도: `O(1)`

각 원소는 제한된 횟수만 변환된 후 더 이상 바뀌지 않으므로 `K`는 매우 작습니다.