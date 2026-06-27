# 문자열 덮어쓰기 (Overwrite String)

## 프로그램 설명

이 문제는 문자열 `my_string`의 특정 위치 `s`부터 `overwrite_string`의 길이만큼 기존 문자열을 제거하고, 그 자리에 `overwrite_string`을 덮어쓴 결과 문자열을 반환하는 문제입니다.

C#에서는 문자열의 일부를 잘라내는 **Substring()** 메서드를 사용하면 간단하게 해결할 수 있습니다.

---

## 문제 핵심

예를 들어 다음과 같은 문자열이 있다고 가정합니다.

```csharp
my_string = "He11oWor1d";
overwrite_string = "lloWorl";
s = 2;
```

`my_string`의 인덱스 `2`부터 `overwrite_string`의 길이만큼인 `"11oWor1"` 부분을 `"lloWorl"`로 바꾸면 다음 결과가 됩니다.

```csharp
"HelloWorld"
```

---

## 소스 코드

```csharp
using System;

public class Solution
{
    public string solution(string my_string, string overwrite_string, int s)
    {
        // s 이전까지의 문자열
        string before = my_string.Substring(0, s);

        // overwrite_string이 덮어쓴 이후에 남는 문자열
        string after = my_string.Substring(s + overwrite_string.Length);

        // 앞부분 + 덮어쓸 문자열 + 뒷부분을 합쳐서 반환
        return before + overwrite_string + after;
    }
}
```

---

## 더 짧은 풀이

아래처럼 한 줄로도 작성할 수 있습니다.

```csharp
using System;

public class Solution
{
    public string solution(string my_string, string overwrite_string, int s)
    {
        return my_string.Substring(0, s) 
             + overwrite_string 
             + my_string.Substring(s + overwrite_string.Length);
    }
}
```

---

## 주요 메서드 및 문법 설명

| 문법 | 설명 |
|---|---|
| `Substring(startIndex)` | `startIndex`부터 문자열 끝까지 잘라냅니다. |
| `Substring(startIndex, length)` | `startIndex`부터 `length`만큼 문자열을 잘라냅니다. |
| `overwrite_string.Length` | `overwrite_string`의 길이를 구합니다. |
| `+` | 문자열을 이어 붙입니다. |

---

## 입력 예시 1

```csharp
my_string = "He11oWor1d";
overwrite_string = "lloWorl";
s = 2;
```

## 출력 예시 1

```csharp
"HelloWorld"
```

## 동작 과정 1

```text
my_string           = "He11oWor1d"
s                   = 2
overwrite_string    = "lloWorl"

before = "He"
after  = "d"

결과 = "He" + "lloWorl" + "d"
     = "HelloWorld"
```

---

## 입력 예시 2

```csharp
my_string = "Program29b8UYP";
overwrite_string = "merS123";
s = 7;
```

## 출력 예시 2

```csharp
"ProgrammerS123"
```

## 동작 과정 2

```text
my_string           = "Program29b8UYP"
s                   = 7
overwrite_string    = "merS123"

before = "Program"
after  = ""

결과 = "Program" + "merS123" + ""
     = "ProgrammerS123"
```

---

## 코드 동작 과정

1. `my_string.Substring(0, s)`로 덮어쓰기 전까지의 문자열을 구합니다.
2. `overwrite_string`을 그대로 중간에 넣습니다.
3. `my_string.Substring(s + overwrite_string.Length)`로 덮어쓰기 이후의 남은 문자열을 구합니다.
4. 세 문자열을 합쳐서 최종 결과를 반환합니다.

---

## 참고 사항

- 문자열 인덱스는 `0`부터 시작합니다.
- 문제의 제한사항에서 `s`와 `overwrite_string.Length`가 항상 올바른 범위 안에 있도록 주어지므로 별도의 예외 처리는 필요하지 않습니다.
- C#의 문자열은 직접 수정할 수 없는 **불변(Immutable)** 객체이므로, 기존 문자열을 바꾸는 것이 아니라 새로운 문자열을 만들어 반환합니다.