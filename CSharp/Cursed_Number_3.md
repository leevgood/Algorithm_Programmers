# 3x 마을 — C# LINQ 및 Python 문제 풀이

## 1. 문제 설명 (Problem Overview)

3x 마을에서는 **3의 배수**와 **숫자 3이 포함된 수**를 사용하지 않습니다. 자연수 `n`이 주어졌을 때, 사용할 수 있는 숫자를 작은 순서대로 나열한 **n번째 숫자**를 반환합니다.

| 일반 숫자 `n` | 3x 마을 숫자 | 일반 숫자 `n` | 3x 마을 숫자 |
|---:|---:|---:|---:|
| 1 | 1 | 6 | 8 |
| 2 | 2 | 7 | 10 |
| 3 | 4 | 8 | 11 |
| 4 | 5 | 9 | 14 |
| 5 | 7 | 10 | 16 |

**제한사항:** `1 ≤ n ≤ 100`

**입출력 예시**

| 입력 `n` | 반환값 |
|---:|---:|
| 15 | 25 |
| 40 | 76 |

---

## 2. 핵심 아이디어 (Key Idea)

다음 두 조건을 **모두** 만족하는 수만 유효합니다.

1. `x % 3 != 0` : 3의 배수가 아니다.
2. `!x.ToString().Contains("3")` (C#) 또는 `"3" not in str(x)` (Python) : 숫자 3을 포함하지 않는다.

조건을 모두 만족해야 하므로 **AND(`&&`, `and`)** 연산자를 사용합니다.

유효한 숫자는 `1, 2, 4, 5, 7, 8, 10, 11, 14, 16, ...` 순서입니다. 따라서 이 수열에서 **n번째 원소**를 선택하면 됩니다.

---

## 3. C# 정답 — LINQ 활용 (Recommended)

```csharp
using System;
using System.Linq;

public class Solution
{
    public int solution(int n)
    {
        return Enumerable.Range(1, 1000)
            // 3의 배수도 아니고 숫자 3을 포함하지 않는 숫자만 선택
            .Where(x => x % 3 != 0 && !x.ToString().Contains("3"))
            // n번째 요소: 인덱스는 0부터 시작하므로 n - 1
            .ElementAt(n - 1);
    }
}
```

### 동작 과정

- `Enumerable.Range(1, 1000)` : 1부터 1000까지 정수를 생성합니다.
- `.Where(...)` : 두 금지 조건에 걸리지 않는 수만 통과시킵니다.
- `.ElementAt(n - 1)` : 유효한 수 중 n번째 값을 꺼냅니다.
- **1000이라는 상한은 문제 제한(`n ≤ 100`)을 고려한 충분한 범위**입니다. 이 범위에는 유효한 숫자가 100개 이상 존재합니다.

### 주요 C# 문법

| 문법 | 설명 |
|---|---|
| `Enumerable.Range(start, count)` | `start`부터 `count`개의 연속 정수를 생성 |
| `.Where(x => 조건)` | 조건을 만족하는 원소만 필터링 |
| `x % 3 != 0` | 3의 배수가 아닌지 검사 |
| `x.ToString().Contains("3")` | 10진수 문자열에 `3`이 포함되는지 검사 |
| `!` | 논리 부정(NOT) |
| `&&` | 논리곱(AND), 두 조건 모두 참이어야 함 |
| `.ElementAt(index)` | 지정된 인덱스의 원소를 반환 (0부터 시작) |

### C# 대안 — 반복문

임의의 큰 `n`에도 상한을 가정하지 않고 순차적으로 계산하려면 다음 방법을 사용할 수 있습니다.

```csharp
using System;

public class Solution
{
    public int solution(int n)
    {
        int answer = 0;

        for (int i = 0; i < n; i++)
        {
            answer++;
            while (answer % 3 == 0 || answer.ToString().Contains("3"))
            {
                answer++;
            }
        }

        return answer;
    }
}
```

여기서는 `while`의 조건이 **제외할 수인지** 검사하므로 OR(`||`)가 맞습니다.

---

## 4. Python 정답

```python
def solution(n):
    answer = 0

    for _ in range(n):
        answer += 1
        # 제외 대상이라면 계속 다음 수로 이동
        while answer % 3 == 0 or "3" in str(answer):
            answer += 1

    return answer
```

### Python 대안 — 리스트 컴프리헨션 (C# LINQ와 유사)

```python
def solution(n):
    valid = [x for x in range(1, 1001)
             if x % 3 != 0 and "3" not in str(x)]
    return valid[n - 1]
```

C#의 `Where`와 Python의 리스트 컴프리헨션은 둘 다 **조건에 맞는 원소를 걸러내는 방식**입니다. Python의 `valid[n - 1]`은 C#의 `.ElementAt(n - 1)`에 대응합니다.

### 주요 Python 문법

| 문법 | 설명 |
|---|---|
| `range(n)` | `0`부터 `n-1`까지 반복 |
| `%` | 나머지 연산 |
| `str(x)` | 정수를 문자열로 변환 |
| `"3" in str(x)` | 문자열에 `3`이 포함되는지 확인 |
| `not in` | 포함되지 않는지 확인 |
| `and`, `or` | 논리곱, 논리합 |
| `[x for x in ... if ...]` | 리스트 컴프리헨션 |

---

## 5. 기존 코드가 틀린 이유

처음 작성했던 접근 방식은 다음과 같습니다.

```csharp
int total = Enumerable.Range(1, n)
    .Where(x => x % 3 == 0 || x.ToString().Contains("3"))
    .Count();

return n + total;
```

이 코드는 **1부터 n까지** 제외되는 숫자만 세어 `n`에 더합니다. 하지만 `n`에서 증가한 구간에도 제외할 숫자가 추가로 존재할 수 있습니다.

예를 들어 `n = 10`이면 `1~10`의 제외 대상은 `3, 6, 9`로 3개입니다. 기존 코드는 `10 + 3 = 13`을 반환하지만, `13`도 숫자 `3`을 포함해 사용하지 못합니다. 실제 10번째 유효 숫자는 **16**입니다.

따라서 문제를 **제외할 숫자 개수 계산**이 아닌 **유효한 숫자 중 n번째 찾기**로 접근해야 합니다.

---

## 6. 테스트 예시 (Test Cases)

| `n` | 기대 결과 |
|---:|---:|
| 1 | 1 |
| 3 | 4 |
| 10 | 16 |
| 15 | 25 |
| 40 | 76 |
| 100 | 185 |

```python
for n, expected in [(1, 1), (3, 4), (10, 16), (15, 25), (40, 76), (100, 185)]:
    assert solution(n) == expected
print("모든 테스트 통과")
```

---

## 7. 시간 복잡도 및 결론

- **C# LINQ 풀이:** 정해진 최대 1000개 후보 중 필요한 원소까지 필터링합니다. 문제 제한에서는 충분히 빠릅니다. `ElementAt`은 `Where`의 결과를 순서대로 조회하므로 일반적으로 앞의 후보들을 검사합니다.
- **Python 반복문 풀이:** 유효 숫자 n개를 찾을 때까지 차례로 검사하며, 별도 리스트를 만들지 않으므로 추가 공간 사용량이 작습니다.
- **핵심 차이:** 금지된 수를 검사할 때는 `3의 배수 OR 숫자 3 포함`, 허용된 수를 필터링할 때는 `3의 배수 아님 AND 숫자 3 미포함`입니다.

**추천:** C#은 요청하신 **LINQ + `Where` + `ElementAt`** 풀이를 사용하고, 동작 원리 이해에는 **반복문 + `while`** 풀이를 함께 확인하세요.
