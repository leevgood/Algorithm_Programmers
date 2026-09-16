# \[Lecture Summary\] C#과 Python으로 배열에서 특정 원소 삭제하기

## 개요(Overview)

이 문제의 목표는 정수 배열 `arr`에서 `delete_list`에 포함된 모든 원소를
제거하고, **기존 `arr`의 순서를 유지한 새로운 배열**을 반환하는
것입니다.

C#에서는 **LINQ(Language Integrated Query)** 의 `Where()`, `Contains()`,
`ToArray()`를 사용할 수 있고, Python에서는 **리스트 컴프리헨션(List
Comprehension)** 과 `not in`을 사용하면 간결하게 해결할 수 있습니다.

------------------------------------------------------------------------

## 주요 개념 및 아키텍처(Key Concepts & Architecture)

### 문제의 핵심

각 `arr`의 원소에 대해 다음 조건을 검사합니다.

> 현재 원소가 `delete_list`에 포함되어 있지 않다면 결과에 남긴다.

예를 들어 다음 입력이 있다고 가정합니다.

``` text
arr         = [293, 1000, 395, 678, 94]
delete_list = [94, 777, 104, 1000, 1, 12]
```

검사 과정은 다음과 같습니다.

    원소  `delete_list`에 존재?   결과
  ------ ----------------------- ------
     293         아니오           유지
    1000           예             삭제
     395         아니오           유지
     678         아니오           유지
      94           예             삭제

최종 결과:

``` text
[293, 395, 678]
```

------------------------------------------------------------------------

## 상세 구현(Detailed Implementation)

### 1. C# 풀이

``` csharp
using System;
using System.Linq;

public class Solution
{
    public int[] solution(int[] arr, int[] delete_list)
    {
        return arr
            .Where(x => !delete_list.Contains(x))
            .ToArray();
    }
}
```

핵심 코드는 다음과 같습니다.

``` csharp
arr.Where(x => !delete_list.Contains(x)).ToArray();
```

  C# 코드                     의미
  --------------------------- -------------------------------
  `x`                         현재 검사 중인 `arr`의 원소
  `delete_list.Contains(x)`   `x`가 삭제 목록에 있는지 검사
  `!`                         논리 결과를 반대로 변경
  `Where(...)`                조건이 `true`인 원소만 선택
  `ToArray()`                 결과를 `int[]`로 변환

즉,

``` csharp
x => !delete_list.Contains(x)
```

는 다음 의미입니다.

> **`x`가 `delete_list`에 들어 있지 않은 경우에만 남긴다.**

`Where()`, `Contains()`, `ToArray()`를 사용하기 위해서는 다음
네임스페이스가 필요합니다.

``` csharp
using System.Linq;
```

`System.Text`는 이 문제에서 사용하지 않으므로 필요하지 않습니다.

------------------------------------------------------------------------

### 2. Python 풀이

``` python
def solution(arr, delete_list):
    return [num for num in arr if num not in delete_list]
```

핵심 코드는 다음과 같습니다.

``` python
[num for num in arr if num not in delete_list]
```

Python의 **리스트 컴프리헨션(List Comprehension)** 기본 형태는 다음과
같습니다.

``` python
[결과값 for 변수 in 반복가능객체 if 조건]
```

이 문제에서는:

``` python
[num for num in arr if num not in delete_list]
```

로 작성합니다.

  Python 코드                의미
  -------------------------- -------------------------------------------
  `num`                      현재 검사 중인 원소
  `for num in arr`           `arr`의 원소를 순서대로 검사
  `num in delete_list`       삭제 목록에 존재하는지 검사
  `num not in delete_list`   삭제 목록에 없는지 검사
  `[ ... ]`                  조건을 만족하는 값으로 새로운 리스트 생성

Python에서는 C#의 `!` 대신 **`not`**을 사용합니다.

``` python
not (num in delete_list)
```

하지만 Python에서는 다음 표현이 더 자연스럽습니다.

``` python
num not in delete_list
```

------------------------------------------------------------------------

### C#과 Python 비교

두 코드는 문법만 다를 뿐 동일한 작업을 수행합니다.

``` csharp
// C#
return arr.Where(x => !delete_list.Contains(x)).ToArray();
```

``` python
# Python
return [num for num in arr if num not in delete_list]
```

개념적으로 비교하면 다음과 같습니다.

  목적             C#                  Python
  ---------------- ------------------- --------------------------------------
  원소 반복        `Where(x => ...)`   `for num in arr`
  포함 여부 확인   `Contains(x)`       `in`
  포함되지 않음    `!Contains(x)`      `not in`
  결과 생성        `ToArray()`         리스트 컴프리헨션 자체가 리스트 생성

------------------------------------------------------------------------

## 활용 사례 및 결론(Use Cases & Conclusion)

이 문제에서 기억해야 할 핵심 패턴은 **"특정 목록에 포함되지 않은 원소만
필터링한다"**입니다.

C#에서는:

``` csharp
arr.Where(x => !delete_list.Contains(x)).ToArray();
```

Python에서는:

``` python
[num for num in arr if num not in delete_list]
```

를 사용할 수 있습니다.

두 언어 모두 결국 다음 논리를 표현합니다.

> `arr`을 처음부터 순회하면서 `delete_list`에 없는 값만 새로운 결과에
> 넣는다.

### 최종 C# 정답

``` csharp
using System;
using System.Linq;

public class Solution
{
    public int[] solution(int[] arr, int[] delete_list)
    {
        return arr.Where(x => !delete_list.Contains(x)).ToArray();
    }
}
```

### 최종 Python 정답

``` python
def solution(arr, delete_list):
    return [num for num in arr if num not in delete_list]
```

### 실무 팁

현재 문제의 배열 길이는 최대 100이므로 위 풀이로 충분합니다. 데이터가
매우 커진다면 `delete_list`를 **해시 집합(Hash Set)** 으로 만들어 포함
여부를 더 빠르게 검사하는 방법도 고려할 수 있습니다.
