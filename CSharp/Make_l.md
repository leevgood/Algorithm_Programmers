# 문자열 바꾸기 문제 풀이 (Python / C#)

## 문제 설명

알파벳 소문자로 이루어진 문자열 `myString`이 주어집니다.

알파벳 순서에서 **`"l"`보다 앞서는 모든 문자**를 `"l"`로 바꾼 문자열을 반환하는 `solution` 함수를 작성합니다.

예를 들어:

```text
abcdevwxyz
```

에서 `a`, `b`, `c`, `d`, `e`는 모두 `l`보다 앞서는 문자이므로 `"l"`로 변경합니다.

결과:

```text
lllllvwxyz
```

---

## 핵심 아이디어

알파벳은 문자끼리 비교할 수 있습니다.

```text
a < l
b < l
...
k < l
l == l
m > l
...
z > l
```

따라서 각 문자 `c`에 대해 다음 조건을 적용하면 됩니다.

```text
c < 'l' 이면 → 'l'
그렇지 않으면 → 기존 문자 c
```

---

# Python 풀이

## 소스 코드

```python
def solution(myString):
    return ''.join('l' if c < 'l' else c for c in myString)
```

---

## 코드 설명

### 1. 문자열의 문자를 하나씩 확인

```python
for c in myString
```

예를 들어 다음 문자열이 주어졌다면:

```python
myString = "abcdevwxyz"
```

`c`에는 순서대로 다음 값이 들어갑니다.

```text
a
b
c
d
e
v
w
x
y
z
```

---

### 2. `"l"`보다 앞서는 문자인지 검사

```python
c < 'l'
```

Python에서는 문자도 사전식 순서(lexicographical order)로 비교할 수 있습니다.

```python
'a' < 'l'   # True
'k' < 'l'   # True
'l' < 'l'   # False
'm' < 'l'   # False
```

---

### 3. 조건 표현식

```python
'l' if c < 'l' else c
```

의미는 다음과 같습니다.

```text
c가 'l'보다 작다 → 'l'
그렇지 않다      → c
```

예:

```text
a → l
b → l
k → l
l → l
m → m
z → z
```

---

### 4. `join()`으로 문자열 만들기

다음 표현식은 문자들을 차례대로 생성합니다.

```python
('l' if c < 'l' else c for c in myString)
```

이를 `''.join()`으로 연결합니다.

```python
''.join(...)
```

따라서 최종 결과가 하나의 문자열이 됩니다.

---

## Python 리스트 컴프리헨션 버전

중간 결과를 확인하고 싶다면 다음과 같이 작성할 수도 있습니다.

```python
def solution(myString):
    result = ['l' if c < 'l' else c for c in myString]
    return ''.join(result)
```

### 동작 예

```python
myString = "abcdevwxyz"
```

중간 리스트:

```python
['l', 'l', 'l', 'l', 'l', 'v', 'w', 'x', 'y', 'z']
```

`join()` 적용 후:

```text
lllllvwxyz
```

---

# C# 풀이

## 소스 코드

```csharp
using System;
using System.Text;

public class Solution
{
    public string solution(string myString)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in myString)
        {
            // 'l'보다 앞서는 문자는 'l'로 변경
            if (c < 'l')
            {
                result.Append('l');
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }
}
```

---

## C# 코드 설명

### 1. `StringBuilder` 생성

```csharp
StringBuilder result = new StringBuilder();
```

문자열에 문자를 반복해서 추가해야 하므로 `StringBuilder`를 사용합니다.

C#의 `string`은 변경 불가능한(immutable) 객체이기 때문에 반복문에서 문자열을 계속 이어 붙이면 불필요한 문자열 객체가 많이 생성될 수 있습니다.

`StringBuilder`를 사용하면 문자열을 효율적으로 구성할 수 있습니다.

---

### 2. 문자열 순회

```csharp
foreach (char c in myString)
```

문자열에서 문자를 하나씩 꺼내 `c`에 저장합니다.

예를 들어:

```csharp
string myString = "jjnnllkkmm";
```

이면 다음과 같은 순서로 확인합니다.

```text
j
j
n
n
l
l
k
k
m
m
```

---

### 3. 문자 비교

```csharp
if (c < 'l')
```

C#의 `char`는 문자 코드 값을 기반으로 비교할 수 있습니다.

알파벳 소문자의 문자 코드도 알파벳 순서대로 증가하므로 다음 비교가 가능합니다.

```csharp
'a' < 'l'   // true
'j' < 'l'   // true
'k' < 'l'   // true
'l' < 'l'   // false
'm' < 'l'   // false
```

---

### 4. 결과에 문자 추가

`"l"`보다 앞서는 문자라면:

```csharp
result.Append('l');
```

그렇지 않으면 원래 문자를 추가합니다.

```csharp
result.Append(c);
```

---

### 5. 문자열로 반환

```csharp
return result.ToString();
```

`StringBuilder` 객체를 최종 문자열로 변환하여 반환합니다.

---

# C# 간단한 풀이

LINQ를 사용하면 더 짧게 작성할 수도 있습니다.

```csharp
using System.Linq;

public class Solution
{
    public string solution(string myString)
    {
        return new string(
            myString
                .Select(c => c < 'l' ? 'l' : c)
                .ToArray()
        );
    }
}
```

핵심 조건은 다음 부분입니다.

```csharp
c < 'l' ? 'l' : c
```

C#의 삼항 연산자(ternary operator)입니다.

```text
조건 ? 참일 때 값 : 거짓일 때 값
```

따라서:

```csharp
c < 'l' ? 'l' : c
```

는 다음 의미입니다.

```text
c가 'l'보다 앞선다 → 'l'
그렇지 않다        → c
```

---

# Python과 C# 비교

| 기능 | Python | C# |
|---|---|---|
| 문자 순회 | `for c in myString` | `foreach (char c in myString)` |
| 문자 비교 | `c < 'l'` | `c < 'l'` |
| 조건 표현식 | `'l' if 조건 else c` | `조건 ? 'l' : c` |
| 문자열 생성 | `''.join()` | `StringBuilder` |
| 최종 반환 | 문자열 그대로 | `result.ToString()` |

---

# 입출력 예제

## 예제 1

입력:

```text
abcdevwxyz
```

처리 과정:

| 원래 문자 | 조건 | 결과 |
|---|---|---|
| a | `a < l` | l |
| b | `b < l` | l |
| c | `c < l` | l |
| d | `d < l` | l |
| e | `e < l` | l |
| v | `v < l` 아님 | v |
| w | `w < l` 아님 | w |
| x | `x < l` 아님 | x |
| y | `y < l` 아님 | y |
| z | `z < l` 아님 | z |

출력:

```text
lllllvwxyz
```

---

## 예제 2

입력:

```text
jjnnllkkmm
```

처리:

```text
j → l
j → l
n → n
n → n
l → l
l → l
k → l
k → l
m → m
m → m
```

출력:

```text
llnnllllmm
```

---

# 시간 복잡도

문자열의 길이를 `N`이라고 하면 모든 문자를 한 번씩 확인합니다.

따라서 시간 복잡도는:

```text
O(N)
```

입니다.

문제의 최대 문자열 길이는 `100,000`이므로 충분히 빠르게 처리할 수 있습니다.

---

# 잘못 작성하기 쉬운 코드

Python에서 다음과 같이 작성하면 오류가 발생합니다.

```python
c - 'l'
```

Python에서는 문자열이나 문자를 `-` 연산자로 뺄 수 없습니다.

잘못된 예:

```python
result = [c for c in myString if c - 'l' > 0 else 'l']
```

문자를 비교하고 싶다면 다음과 같이 직접 비교해야 합니다.

```python
c < 'l'
```

또한 Python의 조건 표현식은 다음 순서로 작성합니다.

```python
참일_때_값 if 조건 else 거짓일_때_값
```

따라서 올바른 코드는:

```python
'l' if c < 'l' else c
```

입니다.

---

# 최종 정답

## Python

```python
def solution(myString):
    return ''.join('l' if c < 'l' else c for c in myString)
```

## C#

```csharp
using System.Text;

public class Solution
{
    public string solution(string myString)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in myString)
        {
            result.Append(c < 'l' ? 'l' : c);
        }

        return result.ToString();
    }
}
```

---

## 핵심 정리

이 문제의 핵심은 **문자를 숫자로 변환할 필요 없이 바로 비교할 수 있다는 것**입니다.

Python과 C# 모두 다음 조건을 그대로 사용할 수 있습니다.

```text
c < 'l'
```

그리고 조건에 따라:

```text
'l'보다 앞선 문자 → 'l'
'l' 이상인 문자   → 원래 문자 유지
```

하면 문제를 해결할 수 있습니다.
