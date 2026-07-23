# 배열 조각하기 (Slice an Array)

## 프로그램 설명

정수 `n`, 세 개의 정수가 담긴 배열 `slicer`, 여러 정수가 담긴 배열 `num_list`가 주어집니다.

`slicer`의 원소를 순서대로 `a`, `b`, `c`라고 할 때, `n`의 값에 따라 `num_list`의 특정 구간을 잘라 새로운 배열로 반환합니다.

| n | 슬라이싱 범위                        |
| - | ------------------------------ |
| 1 | `0`번 인덱스부터 `b`번 인덱스까지          |
| 2 | `a`번 인덱스부터 마지막 인덱스까지           |
| 3 | `a`번 인덱스부터 `b`번 인덱스까지          |
| 4 | `a`번 인덱스부터 `b`번 인덱스까지 `c` 간격으로 |

---

## 소스 코드

```csharp
using System;
using System.Collections.Generic;

public class Solution
{
    public int[] solution(int n, int[] slicer, int[] num_list)
    {
        int a = slicer[0];
        int b = slicer[1];
        int c = slicer[2];

        List<int> result = new List<int>();

        if (n == 1)
        {
            // 0번 인덱스부터 b번 인덱스까지 저장
            for (int i = 0; i <= b; i++)
            {
                result.Add(num_list[i]);
            }
        }
        else if (n == 2)
        {
            // a번 인덱스부터 마지막 인덱스까지 저장
            for (int i = a; i < num_list.Length; i++)
            {
                result.Add(num_list[i]);
            }
        }
        else if (n == 3)
        {
            // a번 인덱스부터 b번 인덱스까지 저장
            for (int i = a; i <= b; i++)
            {
                result.Add(num_list[i]);
            }
        }
        else
        {
            // a번 인덱스부터 b번 인덱스까지 c 간격으로 저장
            for (int i = a; i <= b; i += c)
            {
                result.Add(num_list[i]);
            }
        }

        return result.ToArray();
    }
}
```

---

## 주요 메서드 및 문법 설명

| 문법                | 설명                              |
| ----------------- | ------------------------------- |
| `slicer[0]`       | 배열의 0번 인덱스에 있는 값을 가져옵니다.        |
| `num_list.Length` | 배열에 저장된 원소의 개수를 반환합니다.          |
| `List<int>`       | 크기를 동적으로 변경할 수 있는 정수형 리스트입니다.   |
| `Add()`           | 리스트의 마지막 위치에 새로운 원소를 추가합니다.     |
| `ToArray()`       | `List<int>`를 `int[]` 배열로 변환합니다. |
| `i += c`          | 반복할 때마다 변수 `i`를 `c`만큼 증가시킵니다.   |

---

## 입력 예시 1

```text
n = 3
slicer = [1, 5, 2]
num_list = [1, 2, 3, 4, 5, 6, 7, 8, 9]
```

## 출력 예시 1

```text
[2, 3, 4, 5, 6]
```

`n`이 `3`이므로 `a`번 인덱스부터 `b`번 인덱스까지 선택합니다.

```text
a = 1
b = 5
```

선택되는 인덱스는 다음과 같습니다.

```text
1, 2, 3, 4, 5
```

따라서 선택되는 값은 다음과 같습니다.

```text
2, 3, 4, 5, 6
```

---

## 입력 예시 2

```text
n = 4
slicer = [1, 5, 2]
num_list = [1, 2, 3, 4, 5, 6, 7, 8, 9]
```

## 출력 예시 2

```text
[2, 4, 6]
```

`n`이 `4`이므로 `a`번 인덱스부터 `b`번 인덱스까지 `c` 간격으로 선택합니다.

```text
a = 1
b = 5
c = 2
```

선택되는 인덱스는 다음과 같습니다.

```text
1 → 3 → 5
```

따라서 선택되는 값은 다음과 같습니다.

```text
2 → 4 → 6
```

---

## 코드 동작 과정

1. `slicer` 배열에서 `a`, `b`, `c` 값을 가져옵니다.
2. 결과를 저장할 `List<int>` 객체를 생성합니다.
3. `n`의 값에 따라 반복문의 시작 인덱스와 종료 인덱스를 결정합니다.
4. 조건에 맞는 `num_list`의 원소를 `result`에 추가합니다.
5. `result.ToArray()`를 사용하여 리스트를 배열로 변환한 후 반환합니다.

---

## 간결한 풀이

각 조건에서 시작 인덱스, 종료 인덱스, 증가값만 계산하면 하나의 반복문으로도 작성할 수 있습니다.

```csharp
using System;
using System.Collections.Generic;

public class Solution
{
    public int[] solution(int n, int[] slicer, int[] num_list)
    {
        int a = slicer[0];
        int b = slicer[1];
        int c = slicer[2];

        int start = n == 1 ? 0 : a;
        int end = n == 2 ? num_list.Length - 1 : b;
        int step = n == 4 ? c : 1;

        List<int> result = new List<int>();

        for (int i = start; i <= end; i += step)
        {
            result.Add(num_list[i]);
        }

        return result.ToArray();
    }
}
```

### 변수의 의미

| 변수      | 설명            |
| ------- | ------------- |
| `start` | 슬라이싱을 시작할 인덱스 |
| `end`   | 슬라이싱을 종료할 인덱스 |
| `step`  | 인덱스가 증가하는 간격  |

초보자라면 첫 번째 풀이가 조건별 동작을 이해하기 쉽고, 코드에 익숙하다면 두 번째 풀이가 중복을 줄일 수 있어 적합합니다.

---

## 시간 복잡도

선택하는 배열의 원소 개수를 `k`라고 할 때 시간 복잡도는 다음과 같습니다.

```text
O(k)
```

최악의 경우 `num_list`의 모든 원소를 확인하므로 다음과 같이 표현할 수도 있습니다.

```text
O(N)
```

여기서 `N`은 `num_list`의 길이입니다.

---

## 참고 사항

C# 배열은 다음과 같은 방식으로 범위를 지정할 수 없습니다.

```csharp
// 잘못된 코드
return num_list[a, b];
```

배열의 대괄호 `[]`에는 기본적으로 하나의 인덱스만 전달해야 합니다.

```csharp
int value = num_list[a];
```

또한 `List<T>`의 `Add` 메서드를 호출할 때는 대괄호가 아닌 소괄호를 사용합니다.

```csharp
// 잘못된 코드
result.Add[num_list[i]];

// 올바른 코드
result.Add(num_list[i]);
```
