# C# 정수 입력 및 형식 출력 기본 예제 (Integer Input & Formatted Output)

이 파일은 C# 환경에서 두 개의 정수를 입력받고, 지정된 형식에 맞게 콘솔 화면에 출력하는 기본 프로그램 구조를 정리한 문서입니다.

---

## 1. 소스 코드 (Source Code)

```csharp
using System;

public class Example
{
    public static void Main()
    {
        // 한 줄의 입력을 공백 기준으로 나누어 문자열 배열에 저장합니다.
        string[] input = Console.ReadLine().Split();

        // 첫 번째 입력값을 정수로 변환하여 변수 a에 저장합니다.
        int a = int.Parse(input[0]);

        // 두 번째 입력값을 정수로 변환하여 변수 b에 저장합니다.
        int b = int.Parse(input[1]);

        // 변수 a의 값을 지정된 형식에 맞게 출력합니다.
        Console.WriteLine($"a = {a}");

        // 변수 b의 값을 지정된 형식에 맞게 출력합니다.
        Console.WriteLine($"b = {b}");
    }
}
```

---

## 2. 주요 메서드 및 문법 설명 (Key Methods & Syntax)

| 메서드 / 문법 (Method / Syntax) | 설명 (Description) |
| :--- | :--- |
| **`Console.ReadLine()`** | 사용자가 키보드로 문자열을 입력하고 **엔터(Enter)** 키를 누를 때까지 대기합니다. 입력된 한 줄의 문자열을 읽어옵니다. |
| **`.Split()`** | 문자열을 공백 기준으로 나누어 문자열 배열로 변환합니다. 예를 들어 `"4 5"`는 `["4", "5"]`가 됩니다. |
| **`int.Parse()`** | 문자열 형태의 숫자를 정수형(`int`)으로 변환합니다. 예를 들어 `"4"`는 정수 `4`가 됩니다. |
| **`Console.WriteLine()`** | 괄호 안에 전달된 값을 콘솔 화면에 출력한 후, 자동으로 다음 줄로 **줄바꿈(New Line)**을 수행합니다. |
| **`$"a = {a}"`** | 문자열 보간(String Interpolation) 문법입니다. 문자열 안에 변수 값을 직접 넣어 출력할 수 있습니다. |

---

## 3. 입력 예시 (Input Example)

```text
4 5
```

---

## 4. 출력 예시 (Output Example)

```text
a = 4
b = 5
```

---

## 5. 코드 동작 과정 (How It Works)

1. 사용자가 콘솔에 `4 5`를 입력합니다.
2. `Console.ReadLine()`이 입력된 한 줄을 문자열로 읽어옵니다.
3. `.Split()`이 공백을 기준으로 문자열을 나눕니다.
4. `input[0]`에는 `"4"`, `input[1]`에는 `"5"`가 저장됩니다.
5. `int.Parse()`를 사용해 두 값을 정수로 변환합니다.
6. `Console.WriteLine()`을 사용해 아래 형식으로 출력합니다.

```text
a = 4
b = 5
```

---

## 6. 참고 사항 (Notes)

- 입력값은 공백으로 구분된 두 개의 정수라고 가정합니다.
- 출력 형식은 문제에서 요구한 예시와 정확히 일치해야 합니다.
- `=` 기호 앞뒤의 공백도 출력 형식에 포함됩니다.
- 문자열 보간을 사용하면 변수 값을 더 간단하고 읽기 쉽게 출력할 수 있습니다.
