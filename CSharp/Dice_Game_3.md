# 주사위 게임 3 풀이

## 문제 설명

1부터 6까지 숫자가 적힌 주사위 4개를 굴렸을 때, 나온 숫자의 조합에 따라 점수를 계산하는 문제입니다.

주사위 값은 정수 `a`, `b`, `c`, `d`로 주어지며, 조건에 맞는 점수를 계산해 `return`해야 합니다.

---

## 점수 계산 규칙

| 경우 | 조건 | 점수 |
|---|---|---|
| 1 | 네 숫자가 모두 같음 | `1111 × p` |
| 2 | 세 숫자가 같고, 나머지 하나가 다름 | `(10 × p + q)²` |
| 3 | 두 숫자씩 같은 값이 나옴 | `(p + q) × |p - q|` |
| 4 | 두 숫자만 같고, 나머지 두 숫자가 서로 다름 | `q × r` |
| 5 | 네 숫자가 모두 다름 | 가장 작은 숫자 |

---

## 핵심 아이디어

주사위 4개의 숫자 개수를 세면 각 조건을 쉽게 구분할 수 있습니다.

예를 들어 입력이 `4, 1, 4, 4`라면 숫자별 개수는 다음과 같습니다.

```text
4 → 3개
1 → 1개
```

즉, 세 숫자가 같고 나머지 하나가 다른 경우입니다.

따라서 Dictionary를 사용해 숫자의 등장 횟수를 저장한 뒤, 등장 횟수에 따라 점수를 계산합니다.

---

# C# 풀이

## 소스 코드

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int solution(int a, int b, int c, int d)
    {
        int[] dice = { a, b, c, d };

        // 숫자별 등장 횟수를 저장할 Dictionary
        Dictionary<int, int> count = new Dictionary<int, int>();

        foreach (int num in dice)
        {
            if (!count.ContainsKey(num))
            {
                count[num] = 0;
            }

            count[num]++;
        }

        // 경우 1: 네 숫자가 모두 같은 경우
        if (count.Count == 1)
        {
            int p = count.Keys.First();
            return 1111 * p;
        }

        // 경우 2: 세 숫자가 같고 하나가 다른 경우
        if (count.Count == 2 && count.ContainsValue(3))
        {
            int p = count.First(x => x.Value == 3).Key;
            int q = count.First(x => x.Value == 1).Key;

            return (10 * p + q) * (10 * p + q);
        }

        // 경우 3: 두 숫자씩 같은 경우
        if (count.Count == 2 && count.ContainsValue(2))
        {
            int[] keys = count.Keys.ToArray();

            int p = keys[0];
            int q = keys[1];

            return (p + q) * Math.Abs(p - q);
        }

        // 경우 4: 두 숫자만 같고 나머지 두 숫자는 서로 다른 경우
        if (count.Count == 3)
        {
            int result = 1;

            foreach (var item in count)
            {
                // 한 번만 나온 숫자 q, r을 곱함
                if (item.Value == 1)
                {
                    result *= item.Key;
                }
            }

            return result;
        }

        // 경우 5: 네 숫자가 모두 다른 경우
        return dice.Min();
    }
}
```

---

## C# 코드 설명

| 코드 | 설명 |
|---|---|
| `int[] dice = { a, b, c, d };` | 주사위 값을 배열로 저장 |
| `Dictionary<int, int>` | 숫자별 등장 횟수를 저장 |
| `count.Count == 1` | 서로 다른 숫자가 1개이면 네 숫자가 모두 같음 |
| `count.ContainsValue(3)` | 같은 숫자가 3개 있는지 확인 |
| `count.ContainsValue(2)` | 같은 숫자가 2개 있는지 확인 |
| `Math.Abs(p - q)` | 두 숫자의 차이를 절댓값으로 계산 |
| `dice.Min()` | 네 숫자가 모두 다를 때 가장 작은 값 반환 |

---

# Python 풀이

## 소스 코드

```python
from collections import Counter

def solution(a, b, c, d):
    dice = [a, b, c, d]

    # 숫자별 등장 횟수 계산
    count = Counter(dice)

    # 경우 1: 네 숫자가 모두 같은 경우
    if len(count) == 1:
        p = dice[0]
        return 1111 * p

    # 경우 2: 세 숫자가 같고 하나가 다른 경우
    if len(count) == 2 and 3 in count.values():
        p = [num for num, cnt in count.items() if cnt == 3][0]
        q = [num for num, cnt in count.items() if cnt == 1][0]

        return (10 * p + q) ** 2

    # 경우 3: 두 숫자씩 같은 경우
    if len(count) == 2 and 2 in count.values():
        p, q = count.keys()

        return (p + q) * abs(p - q)

    # 경우 4: 두 숫자만 같고 나머지 두 숫자는 서로 다른 경우
    if len(count) == 3:
        result = 1

        for num, cnt in count.items():
            # 한 번만 나온 숫자 q, r을 곱함
            if cnt == 1:
                result *= num

        return result

    # 경우 5: 네 숫자가 모두 다른 경우
    return min(dice)
```

---

## Python 코드 설명

| 코드 | 설명 |
|---|---|
| `Counter(dice)` | 리스트 안의 숫자별 등장 횟수를 계산 |
| `len(count) == 1` | 네 숫자가 모두 같은 경우 |
| `3 in count.values()` | 같은 숫자가 3개 있는 경우 |
| `2 in count.values()` | 같은 숫자가 2개 있는 경우 |
| `abs(p - q)` | 두 숫자의 차이를 절댓값으로 계산 |
| `min(dice)` | 가장 작은 주사위 값 반환 |

---

## 입출력 예시

| a | b | c | d | result |
|---|---|---|---|---|
| 2 | 2 | 2 | 2 | 2222 |
| 4 | 1 | 4 | 4 | 1681 |
| 6 | 3 | 3 | 6 | 27 |
| 2 | 5 | 2 | 6 | 30 |
| 6 | 4 | 2 | 5 | 2 |

---

## 실행 예시

### C#

```csharp
Solution sol = new Solution();

Console.WriteLine(sol.solution(2, 2, 2, 2)); // 2222
Console.WriteLine(sol.solution(4, 1, 4, 4)); // 1681
Console.WriteLine(sol.solution(6, 3, 3, 6)); // 27
Console.WriteLine(sol.solution(2, 5, 2, 6)); // 30
Console.WriteLine(sol.solution(6, 4, 2, 5)); // 2
```

### Python

```python
print(solution(2, 2, 2, 2))  # 2222
print(solution(4, 1, 4, 4))  # 1681
print(solution(6, 3, 3, 6))  # 27
print(solution(2, 5, 2, 6))  # 30
print(solution(6, 4, 2, 5))  # 2
```

---

## 코드 동작 과정

예를 들어 `a = 2`, `b = 5`, `c = 2`, `d = 6`인 경우를 살펴보겠습니다.

```text
dice = [2, 5, 2, 6]
```

숫자별 등장 횟수는 다음과 같습니다.

```text
2 → 2개
5 → 1개
6 → 1개
```

따라서 두 주사위에서만 같은 숫자 `2`가 나왔고, 나머지 숫자는 `5`, `6`입니다.

점수는 다음과 같습니다.

```text
5 × 6 = 30
```

따라서 결과는 `30`입니다.

---

## 시간 복잡도

주사위는 항상 4개만 주어지므로 반복 횟수는 고정입니다.

```text
시간 복잡도: O(1)
공간 복잡도: O(1)
```

---

## 참고 사항

이 문제는 조건문을 복잡하게 작성하기보다, 숫자의 등장 횟수를 먼저 계산하면 훨씬 쉽게 해결할 수 있습니다.

핵심은 다음과 같습니다.

```text
숫자가 몇 종류인지
각 숫자가 몇 번 등장했는지
```

이 두 가지 정보만 알면 모든 조건을 구분할 수 있습니다.