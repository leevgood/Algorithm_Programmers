# 직각 이등변 삼각형 출력 (Right Isosceles Triangle)

> C# · Python | 반복문, 문자열 반복, LINQ

---

## 1. 문제 설명 (Problem Description)

`*`의 높이와 너비를 1이라고 할 때, 정수 `n`을 입력받아 높이와 너비가 `n`인 직각 이등변 삼각형을 출력한다.

### 제한사항 (Constraints)

- 1 ≤ n ≤ 10
- 첫 번째 행에는 별 1개, 마지막 행에는 별 n개를 출력한다.

### 입력 예시 (Input)

```text
3
```

### 출력 예시 (Output)

```text
*
**
***
```

---

## 2. 핵심 알고리즘 (Algorithm)

1. 정수 `n`을 입력받는다.
2. 1부터 `n`까지 반복한다.
3. 현재 반복 횟수 `i`만큼 별을 출력한다.
4. 각 행을 출력한 후 줄바꿈한다.

| 반복 변수 i | 별의 개수 | 출력 |
|---:|---:|---|
| 1 | 1 | `*` |
| 2 | 2 | `**` |
| 3 | 3 | `***` |

---

## 3. C# 풀이 (LINQ)

### 소스 코드 (Source Code)

```csharp
using System;
using System.Linq;

public class Example
{
    public static void Main()
    {
        // 문자열 입력을 정수로 변환
        int n = int.Parse(Console.ReadLine());

        // 1부터 n까지의 정수를 각각 별 문자열로 변환하고 줄바꿈으로 연결
        Console.WriteLine(string.Join("\n",
            Enumerable.Range(1, n)
                      .Select(i => new string('*', i))));
    }
}
```

### 주요 메서드 및 문법

| 문법 | 설명 | 예시 |
|---|---|---|
| `Console.ReadLine()` | 문자열 입력 | `"3"` |
| `int.Parse()` | 문자열을 정수로 변환 | `int.Parse("3")` → `3` |
| `Enumerable.Range(start, count)` | 시작값부터 지정된 개수의 연속 정수 생성 | `Range(1, 3)` → `1, 2, 3` |
| `Select()` | 각 원소를 새로운 값으로 변환하는 LINQ 메서드 | `Select(i => i * 2)` |
| `i => ...` | 람다 표현식(Lambda Expression) | `i => new string('*', i)` |
| `new string(char, count)` | 문자를 지정 횟수만큼 반복 | `new string('*', 3)` → `"***"` |
| `string.Join()` | 문자열을 구분자로 연결 | `string.Join("-", new[] {"a", "b"})` → `"a-b"` |
| `Console.WriteLine()` | 출력 후 줄바꿈 | `Console.WriteLine("*")` |

### LINQ 동작 과정 (Execution Flow)

```text
n = 3
        ↓
Enumerable.Range(1, n)
        ↓
1, 2, 3
        ↓
.Select(i => new string('*', i))
        ↓
"*", "**", "***"
        ↓
string.Join("\n", ...)
        ↓
"*\n**\n***"
        ↓
Console.WriteLine(...)
```

**주의:** `Enumerable.Range(1, n)`의 두 번째 인수는 종료값이 아니라 생성할 원소의 개수이다. `Select()`는 지연 실행(Deferred Execution)되며, `string.Join()`이 결과를 열거할 때 각 문자열이 생성된다.

### 대안 1: 문자열 생성자와 반복문

```csharp
using System;

public class Example
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            // 현재 행에 필요한 별 문자열을 생성하여 출력
            Console.WriteLine(new string('*', i));
        }
    }
}
```

### 대안 2: 중첩 반복문 (Nested Loop)

```csharp
using System;

public class Example
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
```

외부 반복문은 행을, 내부 반복문은 각 행의 별 개수를 제어한다.

---

## 4. Python 풀이

### 소스 코드 (Source Code)

```python
# 문자열 입력을 정수로 변환
n = int(input())

# 1부터 n까지 별 문자열을 생성하여 출력
for i in range(1, n + 1):
    print("*" * i)
```

### 주요 문법

| 문법 | 설명 | 예시 |
|---|---|---|
| `input()` | 문자열 입력 | `"3"` |
| `int()` | 정수로 변환 | `int("3")` → `3` |
| `range(start, stop)` | 시작값 이상, 종료값 미만의 정수 범위 | `range(1, 4)` → `1, 2, 3` |
| `str * int` | 문자열 반복 | `"*" * 3` → `"***"` |
| `print()` | 기본적으로 출력 후 줄바꿈 | `print("*")` |
| `str.join()` | 문자열을 구분자로 연결 | `"-".join(["a", "b"])` → `"a-b"` |

### 대안 1: 제너레이터 표현식 (Generator Expression)

C#의 `Select()`와 유사한 변환 흐름을 구현한다.

```python
n = int(input())
print("\n".join("*" * i for i in range(1, n + 1)))
```

### 대안 2: 중첩 반복문

```python
n = int(input())

for i in range(n):
    for j in range(i + 1):
        print("*", end="")  # 줄바꿈 없이 출력
    print()  # 한 행이 끝나면 줄바꿈
```

---

## 5. C#과 Python 문법 비교 (Comparison)

| 기능 | C# | Python |
|---|---|---|
| 정수 입력 | `int.Parse(Console.ReadLine())` | `int(input())` |
| 1부터 n까지 생성 | `Enumerable.Range(1, n)` | `range(1, n + 1)` |
| 원소 변환 | `.Select(i => ...)` | `(... for i in ...)` |
| 문자열 반복 | `new string('*', i)` | `"*" * i` |
| 줄바꿈으로 연결 | `string.Join("\n", values)` | `"\n".join(values)` |
| 줄바꿈 출력 | `Console.WriteLine()` | `print()` |
| 줄바꿈 없는 출력 | `Console.Write()` | `print(..., end="")` |

---

## 6. 시간 및 공간 복잡도 (Complexity)

출력하는 전체 별의 개수는 `1 + 2 + ... + n = n(n + 1) / 2`이다.

| 풀이 | 시간 복잡도 | 보조 공간 복잡도 |
|---|---|---|
| C# LINQ + Join | O(n²) | O(n²) |
| C# 문자열 생성자 + for | O(n²) | O(n) |
| Python 문자열 반복 + for | O(n²) | O(n) |
| Python 제너레이터 + join | O(n²) | O(n²) |
| 중첩 반복문 (두 언어) | O(n²) | O(1) |

공간 복잡도는 외부 출력 스트림의 버퍼를 제외한 보조 메모리 기준이다. `Join` 방식은 전체 출력 문자열을 메모리에 생성한다. 제한사항이 n ≤ 10이므로 모든 풀이가 충분히 효율적이다.

---

## 7. 테스트 케이스 (Test Cases)

| 입력 | 예상 출력 (줄바꿈은 `\n`으로 표기) |
|---:|---|
| 1 | `*` |
| 3 | `*\n**\n***` |
| 5 | `*\n**\n***\n****\n*****` |
| 10 | 별 1개부터 10개까지 총 10행 |

---

## 8. 참고 사항 (Notes)

- C#에서 `Console.LeadLine()`은 `Console.ReadLine()`으로 수정해야 한다.
- `Console.ReadLine()`은 문자열을 반환하므로 `int.Parse()`로 변환한다.
- `Console.Write({"*"})`가 아니라 `Console.Write("*")`를 사용한다.
- C# LINQ를 사용하려면 `using System.Linq;`가 필요하다.
- LINQ 학습에는 `Range → Select → Join` 방식이 적합하다. 단순 출력 작업에서는 일반 반복문과 문자열 생성자 방식도 읽기 쉽고 메모리 효율적이다.
- 입력은 문제의 제한사항을 만족한다고 가정한다.
