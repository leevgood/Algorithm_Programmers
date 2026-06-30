# 문자열의 뒤의 n글자

---

## 프로그램 설명

이 문제는 문자열 `code`를 앞에서부터 한 글자씩 읽으면서, 현재 `mode`에 따라 특정 인덱스의 문자만 골라 새로운 문자열 `ret`을 만드는 문제입니다.

`mode`는 처음에 `0`으로 시작합니다.

- 문자가 `"1"`이면 `mode`를 변경합니다.
  - `mode == 0`이면 `1`로 변경
  - `mode == 1`이면 `0`으로 변경
- 문자가 `"1"`이 아니면 현재 `mode`와 인덱스 `idx`의 짝수/홀수 여부에 따라 문자를 추가합니다.

최종적으로 만들어진 문자열 `ret`이 비어 있다면 `"EMPTY"`를 반환합니다.

---

## 문제 조건

- `1 ≤ code의 길이 ≤ 100,000`
- `code`는 알파벳 소문자 또는 `"1"`로 이루어진 문자열입니다.
- 시작할 때 `mode`는 `0`입니다.

---

## 풀이 아이디어

문자열을 왼쪽부터 한 번만 순회하면서 다음 규칙을 적용합니다.

### mode가 0일 때

- `code[idx] == '1'`이면 `mode`를 `1`로 변경합니다.
- `code[idx] != '1'`이면 `idx`가 짝수일 때만 결과 문자열에 추가합니다.

### mode가 1일 때

- `code[idx] == '1'`이면 `mode`를 `0`으로 변경합니다.
- `code[idx] != '1'`이면 `idx`가 홀수일 때만 결과 문자열에 추가합니다.

문자열 길이가 최대 `100,000`이므로 문자열을 반복해서 `+=`로 붙이면 비효율적일 수 있습니다.  
따라서 C#에서는 **StringBuilder**를 사용하는 것이 좋습니다.

---

## 소스 코드

```csharp
using System;
using System.Text;

public class Solution
{
    public string solution(string code)
    {
        // 결과 문자열을 효율적으로 만들기 위한 StringBuilder
        StringBuilder ret = new StringBuilder();

        // 시작 mode는 0
        int mode = 0;

        // code의 각 문자를 앞에서부터 확인
        for (int idx = 0; idx < code.Length; idx++)
        {
            // 현재 문자가 '1'이면 mode를 변경
            if (code[idx] == '1')
            {
                mode = 1 - mode;
            }
            else
            {
                // mode가 0이고 idx가 짝수이면 문자 추가
                if (mode == 0 && idx % 2 == 0)
                {
                    ret.Append(code[idx]);
                }
                // mode가 1이고 idx가 홀수이면 문자 추가
                else if (mode == 1 && idx % 2 == 1)
                {
                    ret.Append(code[idx]);
                }
            }
        }

        // ret가 빈 문자열이면 "EMPTY" 반환
        return ret.Length == 0 ? "EMPTY" : ret.ToString();
    }
}
```

---

## 주요 메서드 및 문법 설명

| 문법 / 메서드 | 설명 |
|---|---|
| `StringBuilder` | 문자열을 효율적으로 이어 붙이기 위한 클래스입니다. |
| `ret.Append()` | `StringBuilder` 객체 뒤에 문자를 추가합니다. |
| `code[idx]` | 문자열 `code`에서 `idx`번째 문자를 가져옵니다. |
| `idx % 2 == 0` | 인덱스가 짝수인지 확인합니다. |
| `idx % 2 == 1` | 인덱스가 홀수인지 확인합니다. |
| `mode = 1 - mode` | `mode`가 `0`이면 `1`로, `1`이면 `0`으로 바꿉니다. |
| 삼항 연산자 `조건 ? A : B` | 조건이 참이면 `A`, 거짓이면 `B`를 반환합니다. |

---

## 입력 예시

```text
code = "abc1abc1abc"
```

---

## 출력 예시

```text
"acbac"
```

---

## 코드 동작 과정

입력 문자열은 다음과 같습니다.

```text
abc1abc1abc
```

처음 `mode`는 `0`, `ret`는 빈 문자열입니다.

| idx | code[idx] | mode 변화 | ret |
|---:|:---:|:---:|:---|
| 0 | a | 0 | a |
| 1 | b | 0 | a |
| 2 | c | 0 | ac |
| 3 | 1 | 0 → 1 | ac |
| 4 | a | 1 | ac |
| 5 | b | 1 | acb |
| 6 | c | 1 | acb |
| 7 | 1 | 1 → 0 | acb |
| 8 | a | 0 | acba |
| 9 | b | 0 | acba |
| 10 | c | 0 | acbac |

따라서 최종 결과는 다음과 같습니다.

```text
"acbac"
```

---

## 시간 복잡도

문자열 `code`를 한 번만 순회하므로 시간 복잡도는 다음과 같습니다.

```text
O(n)
```

여기서 `n`은 문자열 `code`의 길이입니다.

---

## 공간 복잡도

결과 문자열을 저장하기 위해 최대 `n`개의 문자를 저장할 수 있으므로 공간 복잡도는 다음과 같습니다.

```text
O(n)
```

---

## 참고 사항

`mode`를 변경할 때 다음과 같이 작성하면 코드를 간단하게 만들 수 있습니다.

```csharp
mode = 1 - mode;
```

이 코드는 다음과 같은 의미입니다.

- `mode`가 `0`이면 `1 - 0 = 1`
- `mode`가 `1`이면 `1 - 1 = 0`

즉, `0`과 `1`을 번갈아 바꾸는 효과가 있습니다.
