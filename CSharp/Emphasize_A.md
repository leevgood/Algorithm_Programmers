# 문자열 바꾸기 (C# / Python)

## 문제 설명

문자열 `myString`에서 다음 규칙을 적용합니다.

- 소문자 `'a'`는 대문자 `'A'`로 변경합니다.
- `'A'`가 아닌 모든 대문자는 소문자로 변경합니다.
- 그 외의 소문자는 그대로 유지합니다.

---

## C# 풀이

```csharp
using System;

public class Solution
{
    public string solution(string myString)
    {
        char[] arr = myString.ToCharArray();

        for (int i = 0; i < arr.Length; i++)
        {
            // 소문자 a는 대문자 A로 변경
            if (arr[i] == 'a')
            {
                arr[i] = 'A';
            }
            // A가 아닌 대문자는 소문자로 변경
            else if (arr[i] >= 'B' && arr[i] <= 'Z')
            {
                arr[i] = char.ToLower(arr[i]);
            }
        }

        return new string(arr);
    }
}
```

### 주요 문법

| 문법 | 설명 |
| --- | --- |
| `ToCharArray()` | 문자열을 `char` 배열로 변환합니다. |
| `char.ToLower()` | 문자를 소문자로 변환합니다. |
| `new string(arr)` | `char[]` 배열을 문자열로 변환합니다. |
| `arr.ToString()` | 배열 내용을 문자열로 바꾸지 않으며, `System.Char[]`를 반환합니다. |

---

## Python 풀이

```python
def solution(myString):
    result = []

    for char in myString:
        # 소문자 a는 대문자 A로 변경
        if char == 'a':
            result.append('A')
        # 나머지 문자는 소문자로 변경
        else:
            result.append(char.lower())

    return ''.join(result)
```

### Python 간단 풀이

```python
def solution(myString):
    return ''.join('A' if char == 'a' else char.lower() for char in myString)
```

---

## 입출력 예시

| 입력 | 출력 |
| --- | --- |
| `"abstract algebra"` | `"AbstrAct AlgebrA"` |
| `"PrOgRaMmErS"` | `"progrAmmers"` |

---

## 코드 동작 과정

입력값이 `"PrOgRaMmErS"`인 경우입니다.

1. `'P'`, `'O'`, `'R'`, `'M'`, `'E'`, `'S'`는 `'A'`가 아닌 대문자이므로 소문자로 바꿉니다.
2. 소문자 `'a'`는 대문자 `'A'`로 바꿉니다.
3. 나머지 소문자는 그대로 유지합니다.
4. 결과로 `"progrAmmers"`를 반환합니다.

---

## 시간 복잡도

문자열을 한 번 순회하므로 시간 복잡도는 **O(n)** 입니다.
