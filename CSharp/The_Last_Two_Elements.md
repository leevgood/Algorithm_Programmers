# 마지막 두 원소 비교 후 값 추가하기

## 문제 설명

정수 리스트 `num_list`가 주어질 때, 마지막 원소와 그전 원소를 비교합니다.

- 마지막 원소가 그전 원소보다 크면  
  → `마지막 원소 - 그전 원소` 값을 리스트의 끝에 추가합니다.

- 마지막 원소가 그전 원소보다 크지 않으면  
  → `마지막 원소 * 2` 값을 리스트의 끝에 추가합니다.

최종적으로 값이 하나 추가된 리스트를 반환합니다.

---

## 제한사항

- `2 ≤ num_list의 길이 ≤ 10`
- `1 ≤ num_list의 원소 ≤ 9`

---

## 입출력 예시

| num_list | result |
|---|---|
| `[2, 1, 6]` | `[2, 1, 6, 5]` |
| `[5, 2, 1, 7, 5]` | `[5, 2, 1, 7, 5, 10]` |

---

## 입출력 예시 설명

### 예시 1

```text
num_list = [2, 1, 6]
```

마지막 원소는 `6`, 그전 원소는 `1`입니다.

```text
6 > 1
```

마지막 원소가 더 크므로 `6 - 1 = 5`를 추가합니다.

결과:

```text
[2, 1, 6, 5]
```

---

### 예시 2

```text
num_list = [5, 2, 1, 7, 5]
```

마지막 원소는 `5`, 그전 원소는 `7`입니다.

```text
5 <= 7
```

마지막 원소가 그전 원소보다 크지 않으므로 `5 * 2 = 10`을 추가합니다.

결과:

```text
[5, 2, 1, 7, 5, 10]
```

---

# C# 풀이

## 코드

```csharp
using System;

public class Solution {
    public int[] solution(int[] num_list) {
        int lastIndex = num_list.Length - 1;

        // 기존 배열보다 길이가 1 큰 새 배열 생성
        int[] answer = new int[num_list.Length + 1];

        // 기존 배열의 값을 answer 배열에 복사
        for (int i = 0; i < num_list.Length; i++) {
            answer[i] = num_list[i];
        }

        // 마지막 원소가 그전 원소보다 큰 경우
        if (num_list[lastIndex] > num_list[lastIndex - 1]) {
            answer[answer.Length - 1] = num_list[lastIndex] - num_list[lastIndex - 1];
        }
        // 마지막 원소가 그전 원소보다 크지 않은 경우
        else {
            answer[answer.Length - 1] = num_list[lastIndex] * 2;
        }

        return answer;
    }
}
```

---

## C# 코드 설명

| 코드 | 설명 |
|---|---|
| `num_list.Length` | 배열의 길이를 구합니다. |
| `num_list.Length - 1` | 마지막 원소의 인덱스를 구합니다. |
| `num_list[lastIndex]` | 마지막 원소를 의미합니다. |
| `num_list[lastIndex - 1]` | 마지막 바로 앞 원소를 의미합니다. |
| `new int[num_list.Length + 1]` | 기존 배열보다 길이가 1 큰 새 배열을 만듭니다. |
| `answer[answer.Length - 1]` | 새 배열의 마지막 위치를 의미합니다. |

---

## C#에서 주의할 점

C#의 배열은 크기가 고정되어 있습니다.

따라서 Python처럼 바로 값을 추가할 수 없습니다.

```csharp
num_list.Add(값);
```

위 코드는 `int[]` 배열에서는 사용할 수 없습니다.

배열에 값을 추가하려면 새로운 배열을 만들어야 합니다.

```csharp
int[] answer = new int[num_list.Length + 1];
```

---

# Python 풀이

## 코드

```python
def solution(num_list):
    last = num_list[-1]      # 마지막 원소
    prev = num_list[-2]      # 마지막 바로 앞 원소

    if last > prev:
        num_list.append(last - prev)
    else:
        num_list.append(last * 2)

    return num_list
```

---

## Python 코드 설명

| 코드 | 설명 |
|---|---|
| `num_list[-1]` | 리스트의 마지막 원소를 의미합니다. |
| `num_list[-2]` | 리스트의 마지막 바로 앞 원소를 의미합니다. |
| `append()` | 리스트의 끝에 값을 추가합니다. |
| `last > prev` | 마지막 원소가 그전 원소보다 큰지 비교합니다. |

---

## Python에서 간단히 풀 수 있는 이유

Python의 리스트는 크기가 동적으로 변합니다.

그래서 `append()`를 사용하면 리스트 끝에 값을 바로 추가할 수 있습니다.

```python
num_list.append(value)
```

반면 C#의 배열은 크기가 고정되어 있기 때문에 새 배열을 만들어야 합니다.

---

# C#과 Python 비교

| 구분 | C# | Python |
|---|---|---|
| 자료구조 | 배열 `int[]` | 리스트 `list` |
| 마지막 원소 접근 | `num_list[num_list.Length - 1]` | `num_list[-1]` |
| 그전 원소 접근 | `num_list[num_list.Length - 2]` | `num_list[-2]` |
| 값 추가 방법 | 새 배열 생성 필요 | `append()` 사용 |
| 코드 길이 | 비교적 김 | 비교적 짧음 |

---

# 핵심 아이디어

이 문제의 핵심은 마지막 두 원소를 비교하는 것입니다.

```text
마지막 원소 > 그전 원소
```

이면:

```text
마지막 원소 - 그전 원소
```

를 추가합니다.

그렇지 않으면:

```text
마지막 원소 * 2
```

를 추가합니다.

---

# 시간 복잡도

## C#

C#에서는 새 배열을 만들고 기존 배열을 복사합니다.

```text
시간 복잡도: O(n)
```

## Python

Python에서는 마지막 두 원소를 확인하고 `append()`를 수행합니다.

```text
시간 복잡도: O(1)
```

단, 입력 리스트 자체를 수정합니다.

---

# 정리

- C# 배열은 크기가 고정되어 있으므로 새 배열을 만들어야 합니다.
- Python 리스트는 `append()`로 쉽게 값을 추가할 수 있습니다.
- 두 언어 모두 마지막 원소와 그전 원소를 비교하는 로직은 동일합니다.