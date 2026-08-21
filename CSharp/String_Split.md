# 공백으로 구분하기 2

## 문제 설명

단어가 공백 한 개 이상으로 구분되어 있는 문자열 `my_string`이 주어질 때,  
문자열에 등장하는 단어를 앞에서부터 순서대로 문자열 배열에 담아 반환하는 문제입니다.

문자열의 앞뒤에도 공백이 있을 수 있고, 단어 사이에 여러 개의 공백이 존재할 수 있습니다.

---

## 제한사항

- `my_string`은 영소문자와 공백으로만 이루어져 있습니다.
- `1 ≤ my_string.length ≤ 1,000`
- `my_string`의 맨 앞과 맨 뒤에도 공백이 있을 수 있습니다.
- `my_string`에는 단어가 하나 이상 존재합니다.

---

## 입출력 예

| my_string | result |
|---|---|
| `" i    love  you"` | `["i", "love", "you"]` |
| `"    programmers  "` | `["programmers"]` |

---

# C# 풀이

## 소스 코드

```csharp
using System;
using System.Linq;

public class Solution
{
    public string[] solution(string my_string)
    {
        return my_string.Split(' ')
                        .Where(x => x != "")
                        .ToArray();
    }
}
```

---

## 풀이 설명

먼저 `Split(' ')`을 사용해서 공백을 기준으로 문자열을 나눕니다.

```csharp
my_string.Split(' ')
```

하지만 문자열에 공백이 여러 개 연속해서 존재하면 빈 문자열 `""`도 결과에 포함될 수 있습니다.

예를 들어 다음 문자열이 있다고 가정합니다.

```text
" i    love  you"
```

단순히 `Split(' ')`을 사용하면 다음과 같이 빈 문자열이 포함될 수 있습니다.

```text
["", "i", "", "", "", "love", "", "you"]
```

따라서 `Where()`를 이용해 빈 문자열을 제거합니다.

```csharp
.Where(x => x != "")
```

여기서:

```csharp
x => x != ""
```

는

> `x`가 빈 문자열이 아닌 경우만 남긴다

라는 의미입니다.

마지막으로 `Where()`의 결과를 다시 문자열 배열로 만들기 위해 `ToArray()`를 사용합니다.

```csharp
.ToArray()
```

결과적으로:

```text
["i", "love", "you"]
```

가 반환됩니다.

---

## 코드 동작 과정

### 1. 공백을 기준으로 문자열 분리

```csharp
my_string.Split(' ')
```

예시:

```text
" i    love  you"
```

결과:

```text
["", "i", "", "", "", "love", "", "you"]
```

---

### 2. 빈 문자열 제거

```csharp
.Where(x => x != "")
```

빈 문자열 `""`은 제거하고 실제 단어만 남깁니다.

결과:

```text
["i", "love", "you"]
```

---

### 3. 배열로 변환

```csharp
.ToArray()
```

`Where()`의 결과를 최종적으로 `string[]` 배열로 변환합니다.

---

## 주요 메서드 및 문법

| 문법 / 메서드 | 설명 |
|---|---|
| `Split(' ')` | 공백을 기준으로 문자열을 분리 |
| `Where()` | 조건에 맞는 데이터만 선택 |
| `x => x != ""` | 빈 문자열이 아닌 값만 선택 |
| `ToArray()` | 결과를 배열로 변환 |
| `string[]` | 문자열 배열 |
| `return` | 함수의 결과를 반환 |

---

## LINQ

이 풀이에서는 `Where()`와 `ToArray()`를 사용하기 때문에 다음 네임스페이스가 필요합니다.

```csharp
using System.Linq;
```

`LINQ(Language Integrated Query)`는 배열이나 리스트와 같은 데이터에서 원하는 값을 쉽게 필터링하거나 검색할 수 있게 해주는 기능입니다.

---

## 핵심 코드

```csharp
return my_string.Split(' ')
                .Where(x => x != "")
                .ToArray();
```

코드의 흐름은 다음과 같이 기억하면 쉽습니다.

```text
Split
  ↓
문자열 분리
  ↓
Where
  ↓
빈 문자열 제거
  ↓
ToArray
  ↓
배열 반환
```

즉:

```text
Split → Where → ToArray
```

순서로 기억하면 됩니다.

---

# Python 풀이

## 소스 코드

```python
def solution(my_string):
    return my_string.split()
```

---

## 풀이 설명

Python에서는 `split()`에 아무 인자도 넣지 않으면 연속된 공백을 자동으로 처리합니다.

```python
my_string.split()
```

예를 들어:

```python
my_string = " i    love  you"

print(my_string.split())
```

결과:

```text
['i', 'love', 'you']
```

Python의 `split()`은 자동으로 다음을 처리합니다.

- 문자열 앞의 공백 무시
- 문자열 뒤의 공백 무시
- 연속된 여러 개의 공백 처리
- 실제 단어만 분리

따라서 별도로 빈 문자열을 제거할 필요가 없습니다.

---

# C#과 Python 비교

## C#

```csharp
return my_string.Split(' ')
                .Where(x => x != "")
                .ToArray();
```

C#에서는 다음 세 단계로 처리합니다.

```text
1. Split()   → 공백으로 분리
2. Where()   → 빈 문자열 제거
3. ToArray() → 배열로 변환
```

---

## Python

```python
return my_string.split()
```

Python에서는 `split()` 하나만으로 연속된 공백과 앞뒤 공백까지 자동으로 처리됩니다.

---

# 시간 복잡도

문자열의 길이를 `N`이라고 하면 문자열 전체를 확인해야 하므로 시간 복잡도는:

```text
O(N)
```

입니다.

분리한 문자열을 저장하기 위한 공간도 필요하므로 공간 복잡도는:

```text
O(N)
```

입니다.

---

# 핵심 정리

C#에서 기억해야 할 핵심 흐름은:

```text
Split → Where → ToArray
```

입니다.

실제 코드는 다음과 같습니다.

```csharp
my_string.Split(' ')
         .Where(x => x != "")
         .ToArray();
```

각 메서드의 역할은 다음과 같습니다.

```text
Split()   : 문자열을 나눈다
Where()   : 필요한 값만 남긴다
ToArray() : 배열로 만든다
```

Python에서는 더 간단하게:

```python
my_string.split()
```

만 사용하면 됩니다.

이 문제의 핵심은 **연속된 공백 때문에 생기는 빈 문자열을 제거하고 실제 단어만 배열에 저장하는 것**입니다.