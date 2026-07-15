# 문자열 여러 번 뒤집기 (Reverse a Substring)

## 프로그램 설명 (Program Description)

문자열 `my_string`과 두 정수 `s`, `e`가 주어질 때, 문자열의 **인덱스 `s`부터 인덱스 `e`까지의 구간을 뒤집은 문자열**을 반환하는 문제입니다.

문자열은 다음 세 부분으로 나눌 수 있습니다.

1. 인덱스 `s` 이전 부분
2. 인덱스 `s`부터 `e`까지 뒤집을 부분
3. 인덱스 `e` 이후 부분

뒤집을 구간만 역순으로 변경한 뒤, 세 부분을 다시 연결하면 됩니다.

---

## 제한사항 (Constraints)

* `my_string`은 숫자와 알파벳으로만 이루어져 있습니다.
* `1 ≤ my_string.Length ≤ 1,000`
* `0 ≤ s ≤ e < my_string.Length`

---

## C# 풀이

### 소스 코드

```csharp
using System;

public class Solution
{
    public string solution(string my_string, int s, int e)
    {
        // 문자열을 문자 배열로 변환합니다.
        char[] characters = my_string.ToCharArray();

        // s부터 e까지 양쪽 문자를 서로 교환합니다.
        while (s < e)
        {
            char temp = characters[s];
            characters[s] = characters[e];
            characters[e] = temp;

            s++;
            e--;
        }

        // 문자 배열을 다시 문자열로 변환하여 반환합니다.
        return new string(characters);
    }
}
```

---

## C# 주요 메서드 및 문법 설명

| 문법 및 메서드                 | 설명                                 |
| ------------------------ | ---------------------------------- |
| `ToCharArray()`          | 문자열을 수정 가능한 문자 배열 `char[]`로 변환합니다. |
| `char[]`                 | 여러 개의 문자를 저장하는 문자 배열입니다.           |
| `while (s < e)`          | 왼쪽 인덱스와 오른쪽 인덱스가 만날 때까지 반복합니다.     |
| `characters[s]`          | 문자 배열에서 인덱스 `s` 위치의 문자입니다.         |
| `new string(characters)` | 문자 배열을 문자열로 변환합니다.                 |
| 임시 변수 `temp`             | 두 문자의 위치를 안전하게 교환하기 위해 사용합니다.      |

---

## C# 코드 동작 과정

예를 들어 다음과 같은 값이 주어졌다고 가정합니다.

```text
my_string = "Progra21Sremm3"
s = 6
e = 12
```

뒤집어야 하는 구간은 다음과 같습니다.

```text
인덱스:  6 7 8 9 10 11 12
문자:    2 1 S r  e  m  m
```

양쪽 문자부터 순서대로 교환합니다.

```text
2 ↔ m
1 ↔ m
S ↔ e
```

구간을 뒤집은 결과는 다음과 같습니다.

```text
"mm erS12"
```

전체 문자열에 적용하면 다음 결과가 만들어집니다.

```text
"ProgrammerS123"
```

---

## Python 풀이

### 소스 코드

```python
def solution(my_string, s, e):
    # s부터 e까지의 문자열을 슬라이싱한 뒤 역순으로 뒤집습니다.
    reversed_part = my_string[s:e + 1][::-1]

    # 앞부분 + 뒤집은 부분 + 뒷부분을 연결합니다.
    return my_string[:s] + reversed_part + my_string[e + 1:]
```

---

## Python 주요 문법 설명

| 문법                   | 설명                             |
| -------------------- | ------------------------------ |
| `my_string[:s]`      | 문자열의 시작부터 인덱스 `s` 이전까지 가져옵니다.  |
| `my_string[s:e + 1]` | 인덱스 `s`부터 `e`까지 가져옵니다.         |
| `[::-1]`             | 문자열이나 리스트를 역순으로 뒤집습니다.         |
| `my_string[e + 1:]`  | 인덱스 `e` 다음 위치부터 문자열 끝까지 가져옵니다. |
| `+`                  | 여러 문자열을 하나의 문자열로 연결합니다.        |

---

## Python 코드 동작 과정

다음 입력을 예로 들어보겠습니다.

```python
my_string = "Progra21Sremm3"
s = 6
e = 12
```

문자열을 세 부분으로 나눕니다.

```python
my_string[:s]       # "Progra"
my_string[s:e + 1]  # "21Sremm"
my_string[e + 1:]   # "3"
```

가운데 문자열을 뒤집습니다.

```python
my_string[s:e + 1][::-1]  # "mm erS12"에서 공백 없이 "mmerS12"
```

세 문자열을 연결합니다.

```python
"Progra" + "mmerS12" + "3"
```

최종 결과는 다음과 같습니다.

```text
"ProgrammerS123"
```

---

## 입력 예시 (Input Example)

```text
my_string = "Progra21Sremm3"
s = 6
e = 12
```

## 출력 예시 (Output Example)

```text
"ProgrammerS123"
```

---

## 추가 테스트

### 테스트 1

```text
입력:
my_string = "abcdef"
s = 1
e = 4

뒤집을 구간:
"bcde" → "edcb"

출력:
"aedcbf"
```

### 테스트 2

```text
입력:
my_string = "Stanley1yelnatS"
s = 4
e = 10

출력:
"Stanley1yelnatS"
```

뒤집을 구간이 좌우 대칭 형태이므로 결과가 원래 문자열과 같습니다.

### 테스트 3

```text
입력:
my_string = "12345"
s = 0
e = 4

출력:
"54321"
```

---

## 시간 복잡도 (Time Complexity)

### C#

문자열을 문자 배열로 변환하고 일부 구간을 교환하므로 시간 복잡도는 다음과 같습니다.

```text
O(n)
```

여기서 `n`은 문자열의 길이입니다.

문자 배열을 사용하므로 공간 복잡도는 다음과 같습니다.

```text
O(n)
```

### Python

문자열 슬라이싱과 문자열 연결 과정에서 새로운 문자열을 생성하므로 시간 복잡도는 다음과 같습니다.

```text
O(n)
```

공간 복잡도도 다음과 같습니다.

```text
O(n)
```

---

## 참고 사항 (Notes)

* C#의 문자열 `string`은 **불변 객체(Immutable Object)**이므로 문자열 내부의 문자를 직접 변경할 수 없습니다.
* 따라서 C#에서는 문자열을 `char[]` 배열로 변환한 뒤 문자를 교환합니다.
* Python의 문자열도 불변 객체이므로 **슬라이싱(Slicing)**을 이용해 새로운 문자열을 생성합니다.
* 인덱스 `e` 위치까지 포함해야 하므로 Python 슬라이싱에서는 `e + 1`을 사용해야 합니다.
* 뒤집을 범위가 한 글자인 경우에는 원래 문자열이 그대로 반환됩니다.
* `s`와 `e`가 문자열 전체 범위를 가리키면 전체 문자열이 뒤집힙니다.
