# 특정 문자열로 끝나는 가장 긴 부분 문자열

프로그래머스 문제 **"특정 문자열로 끝나는 가장 긴 부분 문자열 찾기"** 풀이입니다.

C#과 Python 두 가지 버전으로 정리했습니다.

---

## 문제 설명

문자열 `myString`과 `pat`가 주어집니다.

`myString`의 부분 문자열 중에서 **`pat`로 끝나는 가장 긴 부분 문자열**을 찾아 반환하는 `solution` 함수를 작성합니다.

예를 들어,

```text
myString = "AbCdEFG"
pat = "dE"
```

`"dE"`가 등장하는 마지막 위치까지 문자열을 자르면 다음과 같습니다.

```text
"AbCdE"
```

따라서 정답은 `"AbCdE"`입니다.

---

## 제한사항

- `5 ≤ myString의 길이 ≤ 20`
- `1 ≤ pat의 길이 ≤ 5`
- `pat`은 반드시 `myString`의 부분 문자열입니다.
- 대문자와 소문자를 구분합니다.

---

## 입출력 예

| myString | pat | result |
|---|---|---|
| `"AbCdEFG"` | `"dE"` | `"AbCdE"` |
| `"AAAAaaaa"` | `"a"` | `"AAAAaaaa"` |

---

# 핵심 아이디어

가장 긴 문자열을 만들려면 `myString` 안에서 **가장 마지막에 등장하는 `pat`의 위치**를 찾아야 합니다.

예를 들어,

```text
myString = "AAAAaaaa"
pat = "a"
```

`"a"`는 여러 번 등장하지만 가장 마지막 `"a"`를 기준으로 자르면

```text
AAAAaaaa
```

전체 문자열을 얻을 수 있습니다.

따라서 다음 순서로 해결할 수 있습니다.

1. `pat`이 마지막으로 등장하는 시작 위치를 찾습니다.
2. `pat`의 길이를 더해서 끝 위치를 계산합니다.
3. 문자열의 처음부터 해당 위치까지 잘라냅니다.

---

# C# 풀이

## 소스 코드

```csharp
public class Solution
{
    public string solution(string myString, string pat)
    {
        // pat이 마지막으로 등장하는 시작 위치
        int index = myString.LastIndexOf(pat);

        // 문자열의 처음부터 pat이 끝나는 위치까지 잘라서 반환
        return myString.Substring(0, index + pat.Length);
    }
}
```

---

## 주요 메서드 및 문법 설명

| 문법 / 메서드 | 설명 |
|---|---|
| `LastIndexOf()` | 문자열에서 특정 문자열이 마지막으로 등장하는 위치를 반환 |
| `Substring(start, length)` | 지정한 위치부터 원하는 길이만큼 문자열을 잘라냄 |
| `pat.Length` | 문자열 `pat`의 길이 |
| `index + pat.Length` | 마지막 `pat`이 끝나는 위치 계산 |

---

## 동작 과정

입력:

```text
myString = "AbCdEFG"
pat = "dE"
```

### 1. 마지막 `pat` 위치 찾기

```csharp
int index = myString.LastIndexOf(pat);
```

문자열의 인덱스는 다음과 같습니다.

```text
A b C d E F G
0 1 2 3 4 5 6
```

`"dE"`는 인덱스 `3`부터 시작합니다.

```text
index = 3
```

### 2. 자를 문자열 길이 계산

```csharp
index + pat.Length
```

`pat`의 길이는 `2`이므로

```text
3 + 2 = 5
```

### 3. 문자열 자르기

```csharp
myString.Substring(0, 5)
```

결과:

```text
AbCdE
```

---

# Python 풀이

## 소스 코드

```python
def solution(myString, pat):
    # pat이 마지막으로 등장하는 시작 위치
    index = myString.rfind(pat)

    # 처음부터 pat이 끝나는 위치까지 슬라이싱
    return myString[:index + len(pat)]
```

---

## 주요 메서드 및 문법 설명

| 문법 / 메서드 | 설명 |
|---|---|
| `rfind()` | 문자열에서 특정 문자열이 마지막으로 등장하는 위치를 반환 |
| `len(pat)` | 문자열 `pat`의 길이를 반환 |
| `myString[:n]` | 문자열의 처음부터 `n` 직전까지 잘라냄 |
| `index + len(pat)` | 마지막 `pat`이 끝나는 위치 계산 |

---

## 동작 과정

입력:

```text
myString = "AAAAaaaa"
pat = "a"
```

### 1. 마지막 `"a"` 위치 찾기

```python
index = myString.rfind(pat)
```

문자열 인덱스:

```text
A A A A a a a a
0 1 2 3 4 5 6 7
```

마지막 `"a"`의 위치는

```text
index = 7
```

입니다.

### 2. 끝 위치 계산

```python
index + len(pat)
```

```text
7 + 1 = 8
```

### 3. 문자열 슬라이싱

```python
myString[:8]
```

결과:

```text
AAAAaaaa
```

---

# 다른 풀이 방법

문자열을 직접 순회하면서 `pat`이 등장하는 위치를 계속 갱신하는 방법도 있습니다.

## C#

```csharp
public class Solution
{
    public string solution(string myString, string pat)
    {
        int lastIndex = 0;

        for (int i = 0; i <= myString.Length - pat.Length; i++)
        {
            if (myString.Substring(i, pat.Length) == pat)
            {
                lastIndex = i + pat.Length;
            }
        }

        return myString.Substring(0, lastIndex);
    }
}
```

하지만 C#에서는 이미 **`LastIndexOf()`** 메서드를 제공하기 때문에 첫 번째 풀이가 더 간단하고 읽기 좋습니다.

---

## Python

```python
def solution(myString, pat):
    last_index = 0

    for i in range(len(myString) - len(pat) + 1):
        if myString[i:i + len(pat)] == pat:
            last_index = i + len(pat)

    return myString[:last_index]
```

Python 역시 **`rfind()`**를 사용하면 훨씬 간단하게 해결할 수 있습니다.

---

# 시간 복잡도

문자열의 길이를 `N`이라고 할 때,

```text
O(N)
```

정도의 시간 복잡도로 해결할 수 있습니다.

문제의 문자열 길이는 최대 `20`이므로 성능은 크게 신경 쓰지 않아도 됩니다.

---

# 최종 정리

이 문제의 핵심은 **`pat`이 마지막으로 등장하는 위치를 찾는 것**입니다.

C#에서는

```csharp
LastIndexOf()
```

Python에서는

```python
rfind()
```

를 사용하면 매우 간단하게 해결할 수 있습니다.

### C# 핵심 코드

```csharp
int index = myString.LastIndexOf(pat);
return myString.Substring(0, index + pat.Length);
```

### Python 핵심 코드

```python
index = myString.rfind(pat)
return myString[:index + len(pat)]
```

가장 마지막 `pat`까지 포함해서 문자열을 자르면 **`pat`으로 끝나는 가장 긴 부분 문자열**을 얻을 수 있습니다.
