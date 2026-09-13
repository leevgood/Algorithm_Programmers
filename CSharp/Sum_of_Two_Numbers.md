# [Lecture Summary] 문자열로 주어진 매우 큰 정수 덧셈 — C# / Python

## 개요(Overview)

문제는 **문자열(String)** 로 주어진 두 개의 0 이상의 정수 `a`, `b`를 더한 뒤, 결과를 다시 문자열로 반환하는 것입니다.

예를 들어:

```text
a = "582"
b = "734"

결과 = "1316"
```

하지만 입력 문자열의 길이가 최대 **100,000자리**이므로 일반적인 정수 자료형으로는 처리할 수 없습니다.

특히 다음과 같은 접근은 위험합니다.

### C#

```csharp
int.Parse(a)
long.Parse(a)
```

`int`, `long`은 저장 가능한 범위가 제한되어 있기 때문에 매우 큰 숫자를 담을 수 없습니다.

### Python

Python의 `int`는 일반적으로 매우 큰 정수를 지원하지만, 실행 환경에 따라 너무 긴 문자열을 한 번에 `int()`로 변환할 때 자릿수 제한 때문에 런타임 에러가 발생할 수 있습니다.

```python
int(a)
```

따라서 이 문제에서는 언어에 관계없이 **문자열의 각 자릿수를 오른쪽부터 직접 더하는 방식**이 가장 안전합니다.

---

## 주요 개념 및 아키텍처(Key Concepts & Architecture)

핵심 아이디어는 초등학교에서 큰 수를 더하는 방식과 같습니다.

```text
  582
+ 734
-----
 1316
```

오른쪽부터 한 자리씩 계산합니다.

```text
2 + 4 = 6
8 + 3 = 11
5 + 7 + 1 = 13
```

여기서 `1`은 다음 자리로 넘어가는 **올림값(Carry)** 입니다.

전체 흐름은 다음과 같습니다.

```text
문자열의 마지막 인덱스에서 시작
        ↓
각 자리 숫자를 정수로 변환
        ↓
a의 현재 자리 + b의 현재 자리 + carry
        ↓
현재 자리 = sum % 10
        ↓
carry = sum / 10
        ↓
왼쪽으로 한 자리 이동
        ↓
결과를 뒤집어서 반환
```

---

## 공통 핵심 로직

두 숫자의 마지막 자리부터 시작합니다.

```text
a = "582"
      ↑

b = "734"
      ↑
```

각 위치를 가리키는 인덱스를 만듭니다.

```text
i = a의 마지막 인덱스
j = b의 마지막 인덱스
```

그리고 반복하면서 계산합니다.

```text
sum = carry

a에 숫자가 남아 있으면 더함
b에 숫자가 남아 있으면 더함

현재 자리 = sum % 10
carry = sum // 10
```

마지막에 `carry`가 남아 있다면 그것도 결과에 추가합니다.

---

# C# 풀이

## C#에서 발생했던 주요 오류

### 1. `int.Parse()` 사용

다음 코드는 작은 숫자에서는 동작합니다.

```csharp
int result = int.Parse(a) + int.Parse(b);
```

하지만 `a`, `b`가 수만 자리라면 `int` 범위를 훨씬 초과합니다.

```text
int 최대값
2,147,483,647
```

`long`을 사용해도 해결되지 않습니다.

```text
long 최대값
9,223,372,036,854,775,807
```

따라서 문자열을 직접 계산해야 합니다.

---

### 2. `if(int i >= 0)` 문법 오류

잘못된 코드:

```csharp
if (int i >= 0)
```

`i`는 이미 선언된 변수이므로 조건에서는 자료형을 다시 적지 않습니다.

올바른 코드:

```csharp
if (i >= 0)
```

---

### 3. `a[i]`는 숫자가 아니라 문자

예를 들어:

```csharp
a[i]
```

가 `'5'`라면 이것은 숫자 `5`가 아니라 **문자(Character)** 입니다.

숫자로 변환하려면:

```csharp
a[i] - '0'
```

을 사용합니다.

예:

```text
'5' - '0' = 5
```

따라서:

```csharp
sum += a[i] - '0';
```

처럼 사용합니다.

---

### 4. `sum =`이 아니라 `sum +=`

잘못된 코드:

```csharp
sum = next + (a[i] - '0');
sum = next + (b[j] - '0');
```

두 번째 줄에서 첫 번째 계산 결과가 덮어써집니다.

올바른 코드:

```csharp
sum += a[i] - '0';
sum += b[j] - '0';
```

즉 **누적 덧셈**을 해야 합니다.

---

### 5. `b[i]`가 아니라 `b[j]`

`a`의 위치는 `i`, `b`의 위치는 `j`가 담당합니다.

```csharp
a[i]
b[j]
```

따라서:

```csharp
sum += b[j] - '0';
```

가 맞습니다.

---

### 6. `char[]`을 문자열로 변환

다음 코드는 원하는 문자열을 반환하지 않습니다.

```csharp
return result.ToString();
```

`result`가 `char[]`라면 다음처럼 변환해야 합니다.

```csharp
return new string(result);
```

---

## C# 최종 코드

```csharp
using System;
using System.Text;

public class Solution
{
    public string solution(string a, string b)
    {
        StringBuilder sb = new StringBuilder();

        int i = a.Length - 1;
        int j = b.Length - 1;
        int carry = 0;

        while (i >= 0 || j >= 0 || carry > 0)
        {
            int sum = carry;

            if (i >= 0)
            {
                sum += a[i] - '0';
                i--;
            }

            if (j >= 0)
            {
                sum += b[j] - '0';
                j--;
            }

            sb.Append(sum % 10);

            carry = sum / 10;
        }

        char[] result = sb.ToString().ToCharArray();

        Array.Reverse(result);

        return new string(result);
    }
}
```

---

## C# 코드 분석

### 인덱스 초기화

```csharp
int i = a.Length - 1;
int j = b.Length - 1;
```

문자열의 가장 오른쪽 자리부터 시작합니다.

---

### 올림값

```csharp
int carry = 0;
```

예를 들어:

```text
8 + 3 = 11
```

이면:

```text
현재 자리 = 1
carry = 1
```

입니다.

---

### 반복 조건

```csharp
while (i >= 0 || j >= 0 || carry > 0)
```

다음 중 하나라도 남아 있으면 계속 계산합니다.

```text
a에 숫자가 남음
b에 숫자가 남음
carry가 남음
```

---

### 현재 자리 계산

```csharp
sb.Append(sum % 10);
```

예:

```text
sum = 13

13 % 10 = 3
```

따라서 현재 자리에는 `3`이 들어갑니다.

---

### 올림 계산

```csharp
carry = sum / 10;
```

C#에서 `sum`, `10`이 모두 `int`이므로 정수 나눗셈이 됩니다.

```text
13 / 10 = 1
```

---

### 결과 뒤집기

오른쪽부터 계산했기 때문에 결과가 역순으로 들어갑니다.

예:

```text
정답 = 1316

StringBuilder 내부 = 6131
```

따라서:

```csharp
Array.Reverse(result);
```

로 뒤집습니다.

---

# Python 풀이

## Python에서 발생했던 주요 오류

### 1. `int + str`

잘못된 코드:

```python
result = result + a[i]
```

`result`는 정수이고 `a[i]`는 문자열입니다.

예:

```python
3 + "5"
```

는 불가능합니다.

따라서:

```python
result = result + int(a[i])
```

처럼 한 자리만 정수로 변환해야 합니다.

---

### 2. 인덱스를 증가시키면 안 됨

잘못된 코드:

```python
i = i + 1
```

우리는 오른쪽에서 왼쪽으로 이동해야 합니다.

따라서:

```python
i = i - 1
```

이 맞습니다.

---

### 3. `i = j - 1` 오타

잘못된 코드:

```python
if j >= 0:
    result += int(b[j])
    i = j - 1
```

`b`의 인덱스는 `j`이므로:

```python
j = j - 1
```

이어야 합니다.

---

### 4. `/`가 아니라 `//`

잘못된 코드:

```python
carry = result / 10
```

Python에서 `/`는 실수 나눗셈입니다.

```python
11 / 10
```

결과:

```text
1.1
```

하지만 필요한 올림값은 `1`입니다.

따라서 정수 나눗셈을 사용합니다.

```python
carry = result // 10
```

결과:

```text
1
```

---

## Python 최종 코드

```python
def solution(a, b):
    i = len(a) - 1
    j = len(b) - 1
    carry = 0

    result = []

    while i >= 0 or j >= 0 or carry > 0:
        total = carry

        if i >= 0:
            total += int(a[i])
            i -= 1

        if j >= 0:
            total += int(b[j])
            j -= 1

        result.append(str(total % 10))

        carry = total // 10

    return ''.join(result[::-1])
```

---

## Python 코드 분석

### 결과 배열

```python
result = []
```

계산된 각 자릿수를 문자열 형태로 저장합니다.

---

### 현재 자리 추가

```python
result.append(str(total % 10))
```

예:

```text
total = 11

11 % 10 = 1
```

따라서:

```python
"1"
```

을 배열에 추가합니다.

---

### 올림 계산

```python
carry = total // 10
```

예:

```text
11 // 10 = 1
```

---

### 결과 뒤집기

계산 결과가 역순으로 저장됩니다.

예:

```python
["6", "1", "3", "1"]
```

따라서:

```python
result[::-1]
```

로 뒤집으면:

```python
["1", "3", "1", "6"]
```

이 되고,

```python
''.join(result[::-1])
```

으로 합치면:

```text
"1316"
```

이 됩니다.

---

# 예제 동작 과정

입력:

```text
a = "582"
b = "734"
```

초기 상태:

```text
i = 2
j = 2
carry = 0
```

## 1회차

```text
2 + 4 + 0 = 6
```

```text
현재 자리 = 6
carry = 0
```

결과:

```text
6
```

---

## 2회차

```text
8 + 3 + 0 = 11
```

```text
현재 자리 = 1
carry = 1
```

결과:

```text
61
```

---

## 3회차

```text
5 + 7 + 1 = 13
```

```text
현재 자리 = 3
carry = 1
```

결과:

```text
613
```

---

## 마지막 carry

두 문자열을 모두 처리했지만:

```text
carry = 1
```

이 남아 있습니다.

따라서:

```text
6131
```

이 됩니다.

이 값을 뒤집으면:

```text
1316
```

입니다.

---

# C#과 Python 비교

| 항목 | C# | Python |
|---|---|---|
| 문자열 길이 | `a.Length` | `len(a)` |
| 문자 접근 | `a[i]` | `a[i]` |
| 한 자리 숫자 변환 | `a[i] - '0'` | `int(a[i])` |
| 결과 저장 | `StringBuilder` | `list` |
| 현재 자리 | `sum % 10` | `total % 10` |
| 올림 | `sum / 10` | `total // 10` |
| 결과 뒤집기 | `Array.Reverse()` | `[::-1]` |
| 최종 문자열 | `new string(result)` | `''.join(...)` |

---

# 자주 틀리는 부분

## C#

잘못된 코드:

```csharp
if (int i >= 0)
```

올바른 코드:

```csharp
if (i >= 0)
```

잘못된 코드:

```csharp
sum = next + (a[i] - '0');
```

올바른 코드:

```csharp
sum += a[i] - '0';
```

잘못된 코드:

```csharp
b[i]
```

올바른 코드:

```csharp
b[j]
```

잘못된 코드:

```csharp
return result.ToString();
```

올바른 코드:

```csharp
return new string(result);
```

---

## Python

잘못된 코드:

```python
result += a[i]
```

올바른 코드:

```python
result += int(a[i])
```

잘못된 코드:

```python
i = i + 1
```

올바른 코드:

```python
i = i - 1
```

잘못된 코드:

```python
i = j - 1
```

올바른 코드:

```python
j = j - 1
```

잘못된 코드:

```python
carry = result / 10
```

올바른 코드:

```python
carry = result // 10
```

---

## 활용 사례 및 결론(Use Cases & Conclusion)

이 문제의 핵심은 **아주 큰 정수를 자료형에 직접 저장하려고 하지 않고 문자열의 각 자릿수를 직접 계산하는 것**입니다.

핵심 공식은 두 언어 모두 동일합니다.

```text
현재 합 = carry + a의 현재 자리 + b의 현재 자리

현재 자리 = 합 % 10

carry = 합 // 10
```

그리고 오른쪽부터 계산했기 때문에 마지막에 결과를 뒤집습니다.

시간 복잡도는:

```text
O(max(len(a), len(b)))
```

입니다.

각 자릿수를 한 번씩만 처리하므로 입력이 100,000자리여도 효율적으로 처리할 수 있습니다.

핵심적으로 기억할 내용은 다음과 같습니다.

```text
1. 가장 오른쪽 자리부터 시작한다.
2. 각 문자를 한 자리 숫자로 변환한다.
3. carry를 포함해서 더한다.
4. sum % 10은 현재 자리이다.
5. sum / 10 또는 sum // 10은 carry이다.
6. 결과를 역순으로 저장했으므로 마지막에 뒤집는다.
```

이 방식은 **큰 수 덧셈(Big Integer Addition)** 뿐만 아니라 큰 수 뺄셈, 곱셈 등의 구현에서도 기본이 되는 중요한 알고리즘입니다.
