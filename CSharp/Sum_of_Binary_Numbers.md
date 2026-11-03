# 이진수 더하기 (Binary Addition) — C# / Python

## 1. 문제 설명 (Problem)

두 이진수 문자열 `bin1`, `bin2`가 주어질 때, 두 수를 더한 결과를 **이진수 문자열**로 반환합니다.

**제한사항**

- `1 ≤ bin1.length, bin2.length ≤ 10`
- 문자열에는 `0`과 `1`만 포함됩니다.
- `"0"`을 제외하면 0으로 시작하지 않습니다.

| bin1 | bin2 | 결과 |
|---|---|---|
| `"10"` | `"11"` | `"101"` |
| `"1001"` | `"1111"` | `"11000"` |

---

## 2. C# 풀이

```csharp
using System;

public class Solution
{
    public string solution(string bin1, string bin2)
    {
        // 2진수 문자열을 10진수 정수로 변환
        int num1 = Convert.ToInt32(bin1, 2);
        int num2 = Convert.ToInt32(bin2, 2);

        // 두 정수를 더한 뒤 결과를 2진수 문자열로 변환
        return Convert.ToString(num1 + num2, 2);
    }
}
```

### 핵심 문법

| 코드 | 의미 |
|---|---|
| `Convert.ToInt32(bin1, 2)` | 2진수 문자열을 정수로 변환 |
| `num1 + num2` | 두 정수의 합 계산 |
| `Convert.ToString(sum, 2)` | 정수를 2진수 문자열로 변환 |

**참고:** 입력 문자열 길이가 최대 10자리이므로 두 수를 더해도 C#의 `int` 범위를 넘지 않습니다.

---

## 3. Python 풀이

```python
def solution(bin1, bin2):
    # 2진수 문자열을 10진수 정수로 변환
    num1 = int(bin1, 2)
    num2 = int(bin2, 2)

    # 더한 결과를 2진수 문자열로 변환 (앞의 '0b' 제거)
    return bin(num1 + num2)[2:]
```

### 핵심 문법

| 코드 | 의미 |
|---|---|
| `int(bin1, 2)` | 2진수 문자열을 정수로 변환 |
| `bin(sum)` | 정수를 `0b` 접두사가 붙은 2진수 문자열로 변환 |
| `[2:]` | `0b` 두 글자를 제외한 문자열 추출 |

예를 들어 `bin(5)`는 `'0b101'`이므로 `bin(5)[2:]`는 `'101'`입니다.

---

## 4. 동작 과정 (Step by Step)

입력: `bin1 = "1001"`, `bin2 = "1111"`

1. `"1001"`(2진수) → `9`(10진수)
2. `"1111"`(2진수) → `15`(10진수)
3. `9 + 15 = 24`
4. `24`(10진수) → `"11000"`(2진수)

**최종 반환값:** `"11000"`

---

## 5. 테스트 예시

### C#

```csharp
using System;

public class Program
{
    public static void Main()
    {
        Solution s = new Solution();
        Console.WriteLine(s.solution("10", "11"));     // 101
        Console.WriteLine(s.solution("1001", "1111")); // 11000
    }
}
```

위 테스트는 2번 항목의 `Solution` 클래스와 함께 실행합니다.

### Python

```python
print(solution("10", "11"))      # 101
print(solution("1001", "1111"))  # 11000
```

위 테스트는 3번 항목의 `solution` 함수와 함께 실행합니다.

---

## 6. 시간 및 공간 복잡도

두 입력 중 더 긴 문자열 길이를 `n`이라고 할 때, 진법 변환과 결과 문자열 생성에 필요한 시간은 **O(n)**, 결과 문자열 공간은 **O(n)**입니다. 단, 입력 제한(`n ≤ 10`)에서는 사실상 매우 작은 연산입니다.

## 7. 결론

- **C#:** `Convert.ToInt32(문자열, 2)` → 덧셈 → `Convert.ToString(합, 2)`
- **Python:** `int(문자열, 2)` → 덧셈 → `bin(합)[2:]`

두 언어 모두 **이진수 → 정수 → 덧셈 → 이진수**라는 동일한 흐름으로 간단하게 해결할 수 있습니다.
