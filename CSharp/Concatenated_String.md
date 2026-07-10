# 부분 문자열 이어 붙여 문자열 만들기

## 문제 설명

길이가 같은 문자열 배열 `my_strings`와 2차원 정수 배열 `parts`가 주어집니다.

`parts[i]`는 `[s, e]` 형태이며, `my_strings[i]`의 인덱스 `s`부터 인덱스 `e`까지의 부분 문자열을 의미합니다.

각 문자열에서 지정된 부분 문자열을 추출한 뒤, 순서대로 이어 붙인 문자열을 반환합니다.

---

## 입출력 예시

### 입력

```text
my_strings = ["progressive", "hamburger", "hammer", "ahocorasick"]
parts = [[0, 4], [1, 2], [3, 5], [7, 7]]
```

### 출력

```text
"programmers"
```

---

## 부분 문자열 추출 과정

| `i` | `my_strings[i]` | `parts[i]` | 추출한 부분 문자열 |
| --: | --------------- | ---------- | ---------- |
|   0 | `"progressive"` | `[0, 4]`   | `"progr"`  |
|   1 | `"hamburger"`   | `[1, 2]`   | `"am"`     |
|   2 | `"hammer"`      | `[3, 5]`   | `"mer"`    |
|   3 | `"ahocorasick"` | `[7, 7]`   | `"s"`      |

각 부분 문자열을 순서대로 이어 붙이면 다음과 같습니다.

```text
"progr" + "am" + "mer" + "s"
= "programmers"
```

---

# C# 풀이

## 소스 코드

```csharp
using System;
using System.Text;

public class Solution
{
    public string solution(string[] my_strings, int[,] parts)
    {
        StringBuilder result = new StringBuilder();

        // parts의 행 개수만큼 반복
        for (int i = 0; i < parts.GetLength(0); i++)
        {
            int start = parts[i, 0];
            int end = parts[i, 1];

            // Substring의 두 번째 인자는 끝 인덱스가 아니라 문자열의 길이
            int length = end - start + 1;

            result.Append(my_strings[i].Substring(start, length));
        }

        return result.ToString();
    }
}
```

---

## C# 핵심 문법

| 문법                         | 설명                               |
| -------------------------- | -------------------------------- |
| `parts.GetLength(0)`       | 2차원 배열의 행 개수를 반환합니다.             |
| `parts.GetLength(1)`       | 2차원 배열의 열 개수를 반환합니다.             |
| `parts[i, 0]`              | `i`번째 행의 첫 번째 값인 시작 인덱스를 가져옵니다.  |
| `parts[i, 1]`              | `i`번째 행의 두 번째 값인 끝 인덱스를 가져옵니다.   |
| `Substring(start, length)` | `start`부터 `length`개의 문자를 추출합니다.  |
| `end - start + 1`          | 시작 인덱스와 끝 인덱스를 모두 포함한 문자열 길이입니다. |
| `StringBuilder`            | 문자열을 반복해서 연결할 때 사용하는 클래스입니다.     |
| `Append()`                 | `StringBuilder`에 문자열을 추가합니다.     |

---

## `Substring()` 사용 시 주의점

C#의 `Substring()` 메서드는 다음과 같은 형식으로 사용합니다.

```csharp
문자열.Substring(시작_인덱스, 가져올_문자_개수)
```

두 번째 인자는 끝 인덱스가 아닙니다.

예를 들어 인덱스 `0`부터 `4`까지 추출하려면 총 5개의 문자가 필요합니다.

```csharp
int start = 0;
int end = 4;

int length = end - start + 1;

string result = "progressive".Substring(start, length);
```

결과:

```text
"progr"
```

다음과 같이 작성해도 현재 예제에서는 같은 결과가 나올 수 있지만, 의미가 잘못되었습니다.

```csharp
my_strings[i].Substring(start, end);
```

`end`는 끝 인덱스이고, `Substring()`의 두 번째 인자는 문자열 길이이므로 반드시 다음과 같이 계산해야 합니다.

```csharp
my_strings[i].Substring(start, end - start + 1);
```

---

## C# 간단한 풀이

문자열의 크기가 최대 100이므로 일반 문자열 연결을 사용해도 문제를 해결할 수 있습니다.

```csharp
using System;

public class Solution
{
    public string solution(string[] my_strings, int[,] parts)
    {
        string result = "";

        for (int i = 0; i < parts.GetLength(0); i++)
        {
            int start = parts[i, 0];
            int end = parts[i, 1];

            result += my_strings[i].Substring(
                start,
                end - start + 1
            );
        }

        return result;
    }
}
```

다만 문자열 연결이 많이 발생하는 문제에서는 `StringBuilder`를 사용하는 것이 더 효율적입니다.

---

# Python 풀이

## 소스 코드

```python
def solution(my_strings, parts):
    result = ""

    # parts의 행 개수만큼 반복
    for i in range(len(parts)):
        start = parts[i][0]
        end = parts[i][1]

        # Python 슬라이싱의 끝 인덱스는 포함되지 않으므로 end + 1 사용
        result += my_strings[i][start:end + 1]

    return result
```

---

## Python 핵심 문법

| 문법                    | 설명                                |
| --------------------- | --------------------------------- |
| `len(parts)`          | `parts`의 행 개수를 반환합니다.             |
| `range(len(parts))`   | `0`부터 `len(parts) - 1`까지 반복합니다.   |
| `parts[i][0]`         | `i`번째 행의 시작 인덱스를 가져옵니다.           |
| `parts[i][1]`         | `i`번째 행의 끝 인덱스를 가져옵니다.            |
| `text[start:end]`     | `start`부터 `end - 1`까지 문자열을 추출합니다. |
| `text[start:end + 1]` | `start`부터 `end`까지 문자열을 추출합니다.     |
| `result += value`     | 기존 문자열 뒤에 새로운 문자열을 연결합니다.         |

---

## Python 슬라이싱 사용 시 주의점

Python의 문자열 슬라이싱은 다음 형식으로 사용합니다.

```python
문자열[시작_인덱스:끝_인덱스]
```

슬라이싱에서는 **끝 인덱스가 결과에 포함되지 않습니다.**

예를 들어 다음 코드는 인덱스 `0`부터 `3`까지만 추출합니다.

```python
text = "progressive"

print(text[0:4])
```

결과:

```text
"prog"
```

인덱스 `0`부터 `4`까지 포함하려면 끝 인덱스에 `1`을 더해야 합니다.

```python
text = "progressive"

print(text[0:5])
```

결과:

```text
"progr"
```

따라서 문제에서는 다음과 같이 작성합니다.

```python
my_strings[i][start:end + 1]
```

---

## Python의 구조 분해 할당을 사용한 풀이

`parts[i]`에는 항상 `[start, end]` 두 개의 값이 들어 있으므로, 구조 분해 할당을 사용할 수 있습니다.

```python
def solution(my_strings, parts):
    result = ""

    for i in range(len(parts)):
        start, end = parts[i]
        result += my_strings[i][start:end + 1]

    return result
```

---

## Python의 `zip()`을 사용한 풀이

`my_strings`와 `parts`의 길이가 같으므로 `zip()`을 사용해 두 배열을 동시에 순회할 수 있습니다.

```python
def solution(my_strings, parts):
    result = ""

    for text, part in zip(my_strings, parts):
        start, end = part
        result += text[start:end + 1]

    return result
```

이 방법은 배열의 인덱스를 직접 사용하지 않아 코드가 더 간결합니다.

---

## Python의 `join()`을 사용한 풀이

문자열을 여러 번 연결해야 할 때는 잘라 낸 문자열들을 모은 뒤 `join()`으로 합칠 수도 있습니다.

```python
def solution(my_strings, parts):
    result = []

    for text, part in zip(my_strings, parts):
        start, end = part
        result.append(text[start:end + 1])

    return "".join(result)
```

리스트 컴프리헨션(List Comprehension)을 사용하면 다음과 같이 줄일 수 있습니다.

```python
def solution(my_strings, parts):
    return "".join(
        text[start:end + 1]
        for text, (start, end) in zip(my_strings, parts)
    )
```

---

# 코드 동작 과정

주어진 입력은 다음과 같습니다.

```text
my_strings = ["progressive", "hamburger", "hammer", "ahocorasick"]
parts = [[0, 4], [1, 2], [3, 5], [7, 7]]
```

## 첫 번째 반복

```text
문자열: "progressive"
범위: [0, 4]
부분 문자열: "progr"
```

현재 결과:

```text
"progr"
```

## 두 번째 반복

```text
문자열: "hamburger"
범위: [1, 2]
부분 문자열: "am"
```

현재 결과:

```text
"program"
```

## 세 번째 반복

```text
문자열: "hammer"
범위: [3, 5]
부분 문자열: "mer"
```

현재 결과:

```text
"programmer"
```

## 네 번째 반복

```text
문자열: "ahocorasick"
범위: [7, 7]
부분 문자열: "s"
```

최종 결과:

```text
"programmers"
```

---

# 행과 열의 의미

`parts`는 각 행이 `[start, end]` 형태인 2차원 배열입니다.

```text
[
    [0, 4],
    [1, 2],
    [3, 5],
    [7, 7]
]
```

행과 열을 표로 표현하면 다음과 같습니다.

| 행 인덱스 | 0번 열 | 1번 열 |
| ----: | ---: | ---: |
|     0 |    0 |    4 |
|     1 |    1 |    2 |
|     2 |    3 |    5 |
|     3 |    7 |    7 |

각 행은 하나의 문자열과 대응합니다.

```text
my_strings[0] ↔ parts[0]
my_strings[1] ↔ parts[1]
my_strings[2] ↔ parts[2]
my_strings[3] ↔ parts[3]
```

따라서 이 문제에서는 **열이 아니라 행을 기준으로 반복해야 합니다.**

Python:

```python
for i in range(len(parts)):
```

C#:

```csharp
for (int i = 0; i < parts.GetLength(0); i++)
```

각 행 안의 열은 시작 인덱스와 끝 인덱스를 가져올 때 사용합니다.

Python:

```python
start = parts[i][0]
end = parts[i][1]
```

C#:

```csharp
int start = parts[i, 0];
int end = parts[i, 1];
```

---

# 시간 복잡도

각 문자열에서 필요한 부분 문자열을 한 번씩 추출합니다.

전체 결과 문자열의 길이를 `K`라고 하면 시간 복잡도는 다음과 같습니다.

```text
O(K)
```

추가 공간 복잡도 역시 결과 문자열을 저장해야 하므로 다음과 같습니다.

```text
O(K)
```

단, 단순 문자열 연결을 반복하는 구현은 언어와 실행 환경에 따라 문자열 복사가 추가로 발생할 수 있습니다.

효율적인 문자열 결합 방법은 다음과 같습니다.

* C#: `StringBuilder`
* Python: 리스트에 저장한 후 `"".join()`

---

# 최종 정답

## C#

```csharp
using System;
using System.Text;

public class Solution
{
    public string solution(string[] my_strings, int[,] parts)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < parts.GetLength(0); i++)
        {
            int start = parts[i, 0];
            int end = parts[i, 1];

            result.Append(
                my_strings[i].Substring(start, end - start + 1)
            );
        }

        return result.ToString();
    }
}
```

## Python

```python
def solution(my_strings, parts):
    return "".join(
        text[start:end + 1]
        for text, (start, end) in zip(my_strings, parts)
    )
```
