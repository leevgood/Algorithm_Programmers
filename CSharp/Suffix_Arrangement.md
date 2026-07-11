# 모든 접미사 배열 만들기 (Suffix Array)

## 문제 설명

문자열 `my_string`이 주어질 때, 문자열의 모든 **접미사(Suffix)**를 구한 뒤 사전순으로 정렬하여 반환합니다.

접미사란 문자열의 특정 위치부터 마지막 문자까지 이어지는 문자열을 의미합니다.

예를 들어 문자열이 `"banana"`라면 모든 접미사는 다음과 같습니다.

```text
banana
anana
nana
ana
na
a
```

이를 사전순으로 정렬하면 다음과 같습니다.

```text
a
ana
anana
banana
na
nana
```

---

## 문제 조건

* `my_string`은 알파벳 소문자로만 이루어져 있습니다.
* `1 ≤ my_string의 길이 ≤ 100`

---

## 입출력 예시

| my_string       | result                                                                                                           |
| --------------- | ---------------------------------------------------------------------------------------------------------------- |
| `"banana"`      | `["a", "ana", "anana", "banana", "na", "nana"]`                                                                  |
| `"programmers"` | `["ammers", "ers", "grammers", "mers", "mmers", "ogrammers", "programmers", "rammers", "rogrammers", "rs", "s"]` |

---

# C# 풀이

## 소스 코드

```csharp
using System;
using System.Collections.Generic;

public class Solution
{
    public string[] solution(string my_string)
    {
        // 모든 접미사를 저장할 리스트
        List<string> suffixes = new List<string>();

        // 각 인덱스부터 마지막 문자까지 잘라 접미사를 생성
        for (int i = 0; i < my_string.Length; i++)
        {
            suffixes.Add(my_string.Substring(i));
        }

        // 접미사를 사전순으로 정렬
        suffixes.Sort();

        // List<string>을 string[] 배열로 변환하여 반환
        return suffixes.ToArray();
    }
}
```

---

## 주요 메서드 및 문법 설명

| 문법 및 메서드           | 설명                                      |
| ------------------ | --------------------------------------- |
| `List<string>`     | 문자열을 동적으로 저장할 수 있는 리스트입니다.              |
| `my_string.Length` | 문자열의 전체 길이를 반환합니다.                      |
| `Substring(i)`     | 인덱스 `i`부터 문자열의 마지막까지 잘라서 반환합니다.         |
| `Add()`            | 리스트에 새로운 값을 추가합니다.                      |
| `Sort()`           | 리스트의 값을 오름차순으로 정렬합니다. 문자열은 사전순으로 정렬됩니다. |
| `ToArray()`        | 리스트를 배열로 변환합니다.                         |

---

## 코드 동작 과정

`my_string`이 `"banana"`인 경우 반복문은 다음과 같이 실행됩니다.

| 인덱스 `i` | `my_string.Substring(i)` |
| ------: | ------------------------ |
|       0 | `"banana"`               |
|       1 | `"anana"`                |
|       2 | `"nana"`                 |
|       3 | `"ana"`                  |
|       4 | `"na"`                   |
|       5 | `"a"`                    |

생성된 접미사 리스트는 다음과 같습니다.

```text
["banana", "anana", "nana", "ana", "na", "a"]
```

`Sort()` 메서드로 사전순 정렬을 수행하면 다음 결과가 됩니다.

```text
["a", "ana", "anana", "banana", "na", "nana"]
```

---

## C# LINQ 풀이

LINQ를 사용하면 코드를 더 간결하게 작성할 수 있습니다.

```csharp
using System.Linq;

public class Solution
{
    public string[] solution(string my_string)
    {
        return Enumerable.Range(0, my_string.Length)
                         .Select(index => my_string.Substring(index))
                         .OrderBy(suffix => suffix)
                         .ToArray();
    }
}
```

### LINQ 문법 설명

| 메서드                           | 설명                               |
| ----------------------------- | -------------------------------- |
| `Enumerable.Range(0, length)` | `0`부터 `length - 1`까지의 정수를 생성합니다. |
| `Select()`                    | 각 인덱스를 해당 위치에서 시작하는 접미사로 변환합니다.  |
| `OrderBy()`                   | 접미사를 사전순으로 정렬합니다.                |
| `ToArray()`                   | 정렬 결과를 문자열 배열로 변환합니다.            |

가독성과 초보자 이해를 고려하면 반복문을 사용하는 첫 번째 풀이가 더 직관적입니다.

---

# Python 풀이

## 소스 코드

```python
def solution(my_string):
    # 모든 접미사를 저장할 리스트
    suffixes = []

    # 각 인덱스부터 마지막 문자까지 잘라 접미사를 생성
    for i in range(len(my_string)):
        suffixes.append(my_string[i:])

    # 접미사를 사전순으로 정렬
    suffixes.sort()

    return suffixes
```

---

## 주요 메서드 및 문법 설명

| 문법 및 메서드                | 설명                             |
| ----------------------- | ------------------------------ |
| `len(my_string)`        | 문자열의 전체 길이를 반환합니다.             |
| `range(len(my_string))` | `0`부터 문자열 길이보다 1 작은 값까지 반복합니다. |
| `my_string[i:]`         | 인덱스 `i`부터 문자열의 마지막까지 잘라 반환합니다. |
| `append()`              | 리스트에 새로운 값을 추가합니다.             |
| `sort()`                | 리스트 내부의 값을 오름차순으로 정렬합니다.       |

---

## Python 리스트 컴프리헨션 풀이

Python의 **리스트 컴프리헨션(List Comprehension)**을 사용하면 더 간단하게 작성할 수 있습니다.

```python
def solution(my_string):
    return sorted(my_string[i:] for i in range(len(my_string)))
```

또는 리스트 형태를 명확히 표현할 수 있습니다.

```python
def solution(my_string):
    return sorted([my_string[i:] for i in range(len(my_string))])
```

### 문법 설명

```python
my_string[i:]
```

문자열의 `i`번째 인덱스부터 마지막 문자까지 추출합니다.

```python
for i in range(len(my_string))
```

문자열의 모든 시작 인덱스를 순회합니다.

```python
sorted(...)
```

생성된 모든 접미사를 사전순으로 정렬한 새로운 리스트를 반환합니다.

---

# 실행 예시

## C#

```csharp
using System;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        string[] result = solution.solution("banana");

        Console.WriteLine(string.Join(", ", result));
    }
}
```

### 출력

```text
a, ana, anana, banana, na, nana
```

---

## Python

```python
result = solution("banana")
print(result)
```

### 출력

```text
['a', 'ana', 'anana', 'banana', 'na', 'nana']
```

---

# 시간 복잡도

문자열의 길이를 `N`이라고 하겠습니다.

1. 모든 접미사를 만드는 과정에서 문자열을 잘라 복사합니다.
2. 생성된 `N`개의 접미사를 정렬합니다.

단순히 정렬 횟수만 보면 약 `O(N log N)`이지만, 문자열 비교와 문자열 복사 비용까지 고려하면 전체 시간 복잡도는 대략 다음과 같이 볼 수 있습니다.

```text
O(N² log N)
```

문자열의 최대 길이가 `100`이므로 충분히 빠르게 실행됩니다.

공간 복잡도는 모든 접미사를 저장해야 하므로 다음과 같습니다.

```text
O(N²)
```

---

# 풀이 핵심

1. 문자열의 모든 인덱스를 순회합니다.
2. 각 인덱스부터 문자열의 끝까지 잘라 접미사를 만듭니다.
3. 생성한 접미사들을 사전순으로 정렬합니다.
4. 정렬된 배열 또는 리스트를 반환합니다.

---

# 참고 사항

* C#의 `Substring(i)`와 Python의 `my_string[i:]`는 같은 역할을 합니다.
* 문자열 정렬은 기본적으로 문자 코드 순서를 기준으로 수행됩니다.
* 문제에서 문자열이 알파벳 소문자로만 주어지므로 기본 정렬 기능을 그대로 사용할 수 있습니다.
* 입력 크기가 작기 때문에 별도의 고급 접미사 배열 알고리즘은 필요하지 않습니다.
