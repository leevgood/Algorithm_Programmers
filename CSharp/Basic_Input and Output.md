# C# 콘솔 입출력 기본 예제 (Console I/O Basics)

이 파일은 C# 환경에서 콘솔 화면을 제어하고, 사용자로부터 문자열을 입력받아 화면에 다시 출력하는 온전한 프로그램 구조를 정리한 문서입니다.

---

## 1. 소스 코드 (Source Code)

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        // 문자열을 저장할 변수 s를 선언합니다.
        string s;

        // 콘솔 창의 모든 텍스트를 깨끗이 지웁니다.
        Console.Clear();

        // 사용자로부터 한 줄의 문자열을 입력받아 변수 s에 저장합니다.
        s = Console.ReadLine();

        // 변수 s에 저장된 문자열을 콘솔 창에 출력합니다.
        Console.WriteLine(s);
    }
}
```

---

## 2. 주요 메서드 설명 (Key Methods)

| 메서드 (Method) | 설명 (Description) |
| :--- | :--- |
| **`Console.Clear()`** | 현재 콘솔 창에 표시되어 있는 모든 텍스트를 지우고, 커서의 위치를 화면의 맨 왼쪽 상단(첫 번째 줄, 첫 번째 칸)으로 이동시킵니다. |
| **`Console.ReadLine()`** | 사용자가 키보드로 문자열을 입력하고 **엔터(Enter)** 키를 누를 때까지 대기합니다. 입력된 문자열을 읽어와 프로그램의 변수에 전달합니다. |
| **`Console.WriteLine(s)`** | 괄호 안에 전달된 문자열(변수 `s`의 값)을 콘솔 화면에 출력한 후, 자동으로 다음 줄로 **줄바꿈(New Line)**을 수행합니다. |