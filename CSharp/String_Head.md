# 문자열의 앞의 N글자 반환하기

## 문제 설명 (Problem Description)

문자열 `my_string`과 정수 `n`이 매개변수로 주어질 때,
`my_string`의 **앞에서부터 n개의 문자**로 이루어진 문자열을 반환하는 `solution` 함수를 작성합니다.

---

## 제한사항 (Constraints)

* `my_string`은 숫자와 알파벳으로 이루어져 있습니다.
* `1 ≤ my_string.Length ≤ 1,000`
* `1 ≤ n ≤ my_string.Length`

---

## 입출력 예시 (Examples)

| my_string          |  n | result          |
| ------------------ | -: | --------------- |
| `"ProgrammerS123"` | 11 | `"ProgrammerS"` |
| `"He110W0r1d"`     |  5 | `"He110"`       |

---

## C# 풀이

### 소스 코드

```csharp
public class Solution
{
    public string solution(string my_string, int n)
    {
        // 문자열의 0번째 위치부터 n개의 문자를 추출합니다.
        return my_string.Substring(0, n);
    }
}
```

### 풀이 설명

C#의 **`Substring()` 메서드**를 사용하면 문자열의 특정 위치부터 원하는 길이만큼 문자를 추출할 수 있습니다.

```csharp
my_string.Substring(시작_인덱스, 가져올_문자_개수)
```

이 문제에서는 문자열의 처음부터 문자를 가져와야 하므로 시작 인덱스는 `0`입니다.

```csharp
my_string.Substring(0, n)
```

따라서 `my_string`의 첫 번째 문자부터 `n`개의 문자를 반환합니다.

### 주요 메서드 및 문법

| 문법                              | 설명                            |
| ------------------------------- | ----------------------------- |
| `Substring(startIndex, length)` | 지정된 위치부터 원하는 개수만큼 문자열을 추출합니다. |
| `startIndex = 0`                | 문자열의 첫 번째 문자부터 시작합니다.         |
| `length = n`                    | 앞에서부터 `n`개의 문자를 가져옵니다.        |
| `return`                        | 처리한 결과를 함수 호출 위치로 반환합니다.      |

---

## Python 풀이

### 소스 코드

```python
def solution(my_string, n):
    # 문자열의 처음부터 n번째 문자 전까지 잘라서 반환합니다.
    return my_string[:n]
```

### 풀이 설명

Python에서는 **문자열 슬라이싱(String Slicing)**을 사용하여 문자열의 일부를 가져올 수 있습니다.

```python
문자열[시작_인덱스:종료_인덱스]
```

시작 인덱스를 생략하면 문자열의 처음부터 시작합니다.

```python
my_string[:n]
```

슬라이싱의 종료 인덱스에 해당하는 문자는 포함되지 않으므로, 위 코드는 문자열의 인덱스 `0`부터 `n - 1`까지 총 `n`개의 문자를 반환합니다.

### 주요 문법

| 문법              | 설명                           |
| --------------- | ---------------------------- |
| `my_string[:n]` | 문자열의 처음부터 인덱스 `n` 전까지 가져옵니다. |
| `:`             | 문자열의 범위를 지정하는 슬라이싱 문법입니다.    |
| `return`        | 슬라이싱한 문자열을 반환합니다.            |

---

## 실행 예시 (C#)

```csharp
using System;

public class Solution
{
    public string solution(string my_string, int n)
    {
        return my_string.Substring(0, n);
    }
}

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        Console.WriteLine(solution.solution("ProgrammerS123", 11));
        Console.WriteLine(solution.solution("He110W0r1d", 5));
    }
}
```

### 출력 결과

```text
ProgrammerS
He110
```

---

## 실행 예시 (Python)

```python
def solution(my_string, n):
    return my_string[:n]


print(solution("ProgrammerS123", 11))
print(solution("He110W0r1d", 5))
```

### 출력 결과

```text
ProgrammerS
He110
```

---

## 코드 동작 과정

### 예제 1

```text
my_string = "ProgrammerS123"
n = 11
```

앞에서부터 11개의 문자를 선택합니다.

```text
P r o g r a m m e r S
1 2 3 4 5 6 7 8 9 10 11
```

따라서 반환되는 값은 다음과 같습니다.

```text
"ProgrammerS"
```

### 예제 2

```text
my_string = "He110W0r1d"
n = 5
```

앞에서부터 5개의 문자를 선택합니다.

```text
H e 1 1 0
1 2 3 4 5
```

따라서 반환되는 값은 다음과 같습니다.

```text
"He110"
```

---

## 시간 복잡도 및 공간 복잡도

문자열에서 `n`개의 문자를 추출하여 새로운 문자열을 생성합니다.

* **시간 복잡도:** `O(n)`
* **공간 복잡도:** `O(n)`

---

## 참고 사항

* 문제의 제한사항에서 `n`은 항상 문자열의 길이 이하로 주어집니다.
* 따라서 별도의 범위 검사 없이 `Substring(0, n)` 또는 `my_string[:n]`을 사용할 수 있습니다.
* C#의 문자열 인덱스는 `0`부터 시작합니다.
* Python 슬라이싱의 종료 인덱스는 결과에 포함되지 않습니다.
