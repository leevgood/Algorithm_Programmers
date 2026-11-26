# 문자열 정렬하기 (1) (String Sorting)

## 1. 문제 설명 (Problem Description)

문자열 `my_string`에서 숫자만 추출하여 정수로 변환하고 오름차순으로 정렬한 결과를 반환한다.

### 제한사항

- 문자열 길이: 1 이상 100 이하
- 숫자가 한 개 이상 포함된다.
- 영어 소문자와 0~9 사이의 숫자로만 구성된다.
- 중복된 숫자는 제거하지 않는다.

---

## 2. C# 소스 코드 (LINQ Solution)

```csharp
using System;
using System.Linq;

public class Solution
{
    public int[] solution(string my_string)
    {
        return my_string
            .Where(char.IsDigit)       // 숫자 문자만 추출
            .Select(c => c - '0')      // 문자를 정수로 변환
            .OrderBy(n => n)          // 오름차순 정렬
            .ToArray();               // int[] 배열 반환
    }
}
```

### 주요 메서드 및 문법

| 메서드 | 설명 |
|---|---|
| `Where(char.IsDigit)` | 숫자 문자만 필터링(Filtering) |
| `Select(c => c - '0')` | 각 문자를 정수로 변환(Mapping) |
| `OrderBy(n => n)` | 오름차순 정렬(Sorting) |
| `ToArray()` | 결과를 정수 배열로 변환 |
| `=>` | 람다 표현식(Lambda Expression) |

### 문자에 '0'을 빼는 이유

C#에서 `char`끼리 뺄셈을 하면 문자 코드값의 차이가 `int`로 반환된다. ASCII 숫자 문자는 유니코드에서도 연속적으로 배치된다.

```csharp
char c = '7';
int number = c - '0'; // 55 - 48 = 7
```

`(int)c`는 숫자 7이 아니라 문자 코드값 55를 반환하므로 주의한다.

---

## 3. Python 소스 코드 (Python Solution)

```python
def solution(my_string):
    # 숫자 문자만 추출하고 정수로 변환한 뒤 정렬
    return sorted([int(c) for c in my_string if c.isdigit()])
```

### 주요 함수 및 문법

| 문법 | 설명 |
|---|---|
| `for c in my_string` | 문자열의 각 문자를 순회 |
| `c.isdigit()` | 숫자 문자인지 확인 |
| `int(c)` | 문자를 정수로 변환 |
| `[표현식 for 변수 in 반복객체 if 조건]` | 리스트 컴프리헨션(List Comprehension) |
| `sorted()` | 정렬된 새 리스트 반환 |

### 제너레이터 표현식 (Generator Expression)

```python
def solution(my_string):
    return sorted(int(c) for c in my_string if c.isdigit())
```

중간 리스트를 명시적으로 만들지 않고 `sorted()`에 값을 전달할 수 있다.

---

## 4. 입출력 예시 (Input & Output)

| 입력 (my_string) | 출력 (result) |
|---|---|
| `"hi12392"` | `[1, 2, 2, 3, 9]` |
| `"p2o4i8gj2"` | `[2, 2, 4, 8]` |
| `"abcde0"` | `[0]` |

---

## 5. 코드 동작 과정 (Execution Flow)

```text
"hi12392"
    ↓ 숫자 문자 필터링
['1', '2', '3', '9', '2']
    ↓ 정수 변환
[1, 2, 3, 9, 2]
    ↓ 오름차순 정렬
[1, 2, 2, 3, 9]
```

### C#과 Python 문법 비교

| 기능 | C# LINQ | Python |
|---|---|---|
| 필터링 | `Where(char.IsDigit)` | `if c.isdigit()` |
| 변환 | `Select(c => c - '0')` | `int(c)` |
| 정렬 | `OrderBy(n => n)` | `sorted()` |
| 결과 자료형 | `int[]` | `list[int]` |

---

## 6. 시간 및 공간 복잡도 (Complexity)

전체 문자열 길이를 n, 숫자의 개수를 k라고 정의한다.

| 연산 | 시간 복잡도 |
|---|---|
| 필터링 및 변환 | O(n) |
| 정렬 (최악의 경우) | O(k log k) |
| 전체 | O(n + k log k) |
| 공간 복잡도 (결과 포함) | O(k) |

---

## 7. 참고 사항 (Notes)

- 연속된 숫자도 각각의 한 자리 숫자로 처리한다. 예: `"abc123"` → `[1, 2, 3]`.
- 중복 숫자를 유지해야 하므로 `Distinct()`나 `set()`을 사용하지 않는다.
- 이 문제는 입력이 ASCII 숫자와 영어 소문자로 제한되므로 `char.IsDigit()` 및 `isdigit()`을 안전하게 사용할 수 있다. 일반 유니코드 문자열에서는 별도의 검증이 필요할 수 있다.
- 숫자의 범위가 0~9로 고정되어 있으므로 계수 정렬(Counting Sort)을 이용한 선형 시간 풀이도 가능하지만, 이 문제에서는 가독성이 좋은 LINQ와 리스트 컴프리헨션을 우선한다.
