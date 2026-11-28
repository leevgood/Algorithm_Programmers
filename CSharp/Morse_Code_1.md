# 모스부호 (1) — C# & Python (Morse Code)

## 1. 문제 설명 (Problem Description)

공백으로 구분된 모스부호 문자열 `letter`를 영어 소문자로 해독하여 반환합니다.

### 제한사항

- `1 ≤ letter.Length ≤ 1,000`
- 반환값은 영어 소문자입니다.
- 모스부호는 하나의 공백으로 구분됩니다.
- 해독할 수 없는 모스부호는 주어지지 않습니다.
- 문자열의 시작과 끝에는 공백이 없습니다.

### 입출력 예 (Examples)

| 입력 (`letter`) | 출력 (`result`) |
| --- | --- |
| `".... . .-.. .-.. ---"` | `"hello"` |
| `".--. -.-- - .... --- -."` | `"python"` |

---

## 2. C# 풀이 (LINQ Solution)

### 소스 코드

```csharp
using System;
using System.Linq;

public class Solution
{
    public string solution(string letter)
    {
        string[] morse =
        {
            ".-", "-...", "-.-.", "-..", ".", "..-.",
            "--.", "....", "..", ".---", "-.-", ".-..",
            "--", "-.", "---", ".--.", "--.-", ".-.",
            "...", "-", "..-", "...-", ".--", "-..-",
            "-.--", "--.."
        };

        // 배열의 인덱스를 이용해 모스부호와 알파벳을 매핑
        var dictionary = morse
            .Select((code, index) => new
            {
                Code = code,
                Character = (char)('a' + index)
            })
            .ToDictionary(x => x.Code, x => x.Character);

        // 공백으로 분리하고 각 모스부호를 문자로 변환한 뒤 결합
        return string.Concat(
            letter.Split(' ').Select(code => dictionary[code])
        );
    }
}
```

### 주요 메서드 및 문법 (Methods & Syntax)

| 문법 | 설명 |
| --- | --- |
| `Select((code, index) => ...)` | 배열 요소와 인덱스를 함께 사용하여 변환합니다. |
| `(char)('a' + index)` | 인덱스를 이용해 `a`부터 `z`까지의 문자를 생성합니다. |
| `new { ... }` | 익명 타입(Anonymous Type)을 생성합니다. |
| `ToDictionary()` | 키와 값으로 구성된 딕셔너리를 생성합니다. |
| `Split(' ')` | 공백을 기준으로 문자열을 분리합니다. |
| `dictionary[code]` | 해당 키에 대응하는 문자를 조회합니다. |
| `string.Concat()` | 변환된 문자들을 구분자 없이 결합합니다. |

### 핵심 원리: 문자와 인덱스

C#에서 `char`에 정수를 더하면 정수형 결과가 나오므로 다시 `char`로 형 변환합니다.

| 인덱스 | 모스부호 | 변환식 | 결과 |
| --- | --- | --- | --- |
| 0 | `.-` | `(char)('a' + 0)` | `a` |
| 1 | `-...` | `(char)('a' + 1)` | `b` |
| 2 | `-.-.` | `(char)('a' + 2)` | `c` |
| 25 | `--..` | `(char)('a' + 25)` | `z` |

### 대안: Array.IndexOf를 활용한 짧은 LINQ 풀이

위 코드의 딕셔너리 생성 및 반환 부분을 다음 코드로 대체할 수 있습니다.

```csharp
return string.Concat(
    letter.Split(' ')
          .Select(code => (char)('a' + Array.IndexOf(morse, code)))
);
```

`Array.IndexOf()`는 모스부호가 배열에서 몇 번째 위치에 있는지 검색합니다. 코드가 간결하지만 문자마다 배열을 선형 탐색합니다. 이 문제에서는 알파벳이 26개로 고정되어 있으므로 두 방식 모두 충분히 효율적입니다.

---

## 3. Python 풀이 (Python Solution)

### 소스 코드

```python
from string import ascii_lowercase


def solution(letter):
    morse = [
        '.-', '-...', '-.-.', '-..', '.', '..-.',
        '--.', '....', '..', '.---', '-.-', '.-..',
        '--', '-.', '---', '.--.', '--.-', '.-.',
        '...', '-', '..-', '...-', '.--', '-..-',
        '-.--', '--..'
    ]

    # 모스부호와 알파벳을 순서대로 연결하여 딕셔너리 생성
    dictionary = dict(zip(morse, ascii_lowercase))

    # 분리된 모스부호를 문자로 변환하고 문자열로 결합
    return ''.join(dictionary[code] for code in letter.split())
```

### 주요 메서드 및 문법 (Methods & Syntax)

| 문법 | 설명 |
| --- | --- |
| `ascii_lowercase` | `abcdefghijklmnopqrstuvwxyz` 문자열을 제공합니다. |
| `zip()` | 두 반복 가능한 객체의 요소를 순서대로 묶습니다. |
| `dict()` | 키와 값의 쌍을 딕셔너리로 변환합니다. |
| `split()` | 공백 문자를 기준으로 문자열을 분리합니다. |
| `dictionary[code]` | 모스부호에 대응하는 문자를 조회합니다. |
| `dictionary[code] for code in ...` | 제너레이터 표현식(Generator Expression)으로 문자를 순차적으로 생성합니다. |
| `''.join()` | 문자열 요소들을 구분자 없이 결합합니다. |

### 대안: 리스트의 index() 활용

위 코드의 딕셔너리 생성 및 반환 부분을 다음 코드로 대체할 수 있습니다.

```python
return ''.join(ascii_lowercase[morse.index(code)] for code in letter.split())
```

C#의 `Array.IndexOf()` 방식과 같은 원리입니다.

---

## 4. 코드 동작 과정 (Execution Flow)

입력: `".... . .-.. .-.. ---"`

1. 문자열 분리: `["....", ".", ".-..", ".-..", "---"]`
2. 딕셔너리 조회를 통해 각 모스부호를 문자로 변환합니다.

| 모스부호 | 문자 |
| --- | --- |
| `....` | `h` |
| `.` | `e` |
| `.-..` | `l` |
| `.-..` | `l` |
| `---` | `o` |

3. 변환된 문자들을 결합합니다.
4. 최종 결과: `"hello"`

---

## 5. C#과 Python 비교 (Comparison)

| 기능 | C# | Python |
| --- | --- | --- |
| 문자열 분리 | `Split(' ')` | `split()` |
| 매핑 생성 | `Select()` + `ToDictionary()` | `dict(zip())` |
| 요소 변환 | LINQ `Select()` | 제너레이터 표현식 |
| 문자열 결합 | `string.Concat()` | `''.join()` |
| 배열 위치 검색 | `Array.IndexOf()` | `list.index()` |

---

## 6. 시간 및 공간 복잡도 (Complexity)

`n`은 입력 문자열 길이, `k`는 모스부호 종류의 수(26), `m`은 해독된 문자 수입니다.

| 방식 | 시간 복잡도 | 공간 복잡도 (출력 포함) |
| --- | --- | --- |
| 딕셔너리 | 평균 `O(n + k)` | `O(n + k)` |
| 인덱스 검색 | `O(n + m × k)` | `O(n + k)` |

모스부호의 최대 길이는 4이고 `k = 26`으로 고정되어 있으므로 이 문제에서는 두 방식 모두 시간 및 공간 복잡도가 `O(n)`입니다. 딕셔너리 조회는 일반적으로 평균 `O(1)`이며, 배열 인덱스 검색은 일반적으로 `O(k)`입니다.

---

## 7. 테스트 케이스 (Test Cases)

| 입력 | 예상 출력 | 설명 |
| --- | --- | --- |
| `.... . .-.. .-.. ---` | `hello` | 기본 예제 |
| `.--. -.-- - .... --- -.` | `python` | 기본 예제 |
| `.-` | `a` | 첫 번째 알파벳 |
| `--..` | `z` | 마지막 알파벳 |
| `. . .` | `eee` | 반복 문자 |

---

## 8. 참고 사항 (Notes)

- **딕셔너리(Dictionary)** 는 키를 이용하여 대응하는 값을 빠르게 조회할 때 유용합니다.
- **LINQ의 Select()** 는 각 요소를 새로운 값으로 변환하는 메서드입니다.
- **zip()** 은 순서가 대응되는 두 데이터를 연결할 때 유용합니다.
- 문제에서 유효한 입력만 제공하므로 별도의 예외 처리를 생략했습니다. 실제 프로그램에서는 잘못된 모스부호에 대한 처리가 필요할 수 있습니다.
- C#에서는 LINQ 사용을 위해 `using System.Linq;`가 필요합니다.
- 매핑의 의미를 명확히 표현하고 일반화하기 쉬운 딕셔너리 방식을 기본 풀이로 권장합니다.
