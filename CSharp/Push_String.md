# 문자열 밀기 (String Rotation) - C# / Python 풀이

## 1. 문제 설명

문자열 `A`의 각 문자를 오른쪽으로 한 칸씩 밀고, 마지막 문자를 맨 앞으로 이동시키는 연산을 **문자열을 민다**고 합니다.

예를 들어:

```text
hello
→ ohell
→ lohel
→ llohe
→ elloh
→ hello
```

문자열 `A`와 `B`가 주어질 때,

- `A`를 오른쪽으로 밀어서 `B`로 만들 수 있다면 **최소 이동 횟수**를 반환합니다.
- 만들 수 없다면 `-1`을 반환합니다.

---

## 2. 제한사항

- `0 < A의 길이 = B의 길이 < 100`
- `A`, `B`는 알파벳 소문자로 이루어져 있습니다.

---

## 3. 입출력 예

| A | B | result |
|---|---|---:|
| `"hello"` | `"ohell"` | `1` |
| `"apple"` | `"elppa"` | `-1` |
| `"atat"` | `"tata"` | `1` |
| `"abc"` | `"abc"` | `0` |

---

## 4. 핵심 아이디어

문자열의 길이가 `N`이라면 오른쪽으로 `N`번 밀었을 때 다시 원래 문자열로 돌아옵니다.

예를 들어:

```text
abc

0회 : abc
1회 : cab
2회 : bca
3회 : abc
```

따라서 최대 `A.Length`번만 확인하면 됩니다.

---

## 5. 방법 1 - 직접 문자열 회전

가장 이해하기 쉬운 방법은 실제로 문자열을 한 칸씩 오른쪽으로 이동시키면서 `B`와 비교하는 것입니다.

### C#

```csharp
using System;

public class Solution
{
    public int solution(string A, string B)
    {
        for (int i = 0; i < A.Length; i++)
        {
            // 현재 문자열이 B와 같으면
            // 지금까지 이동한 횟수를 반환
            if (A == B)
                return i;

            // 마지막 문자를 맨 앞으로 이동
            A = A[A.Length - 1] + A.Substring(0, A.Length - 1);
        }

        return -1;
    }
}
```

### 핵심 코드

```csharp
A = A[A.Length - 1] + A.Substring(0, A.Length - 1);
```

`A = "hello"`라면:

```csharp
A[A.Length - 1]
```

결과:

```text
'o'
```

그리고:

```csharp
A.Substring(0, A.Length - 1)
```

결과:

```text
"hell"
```

따라서:

```text
"o" + "hell"
= "ohell"
```

이 되어 문자열이 오른쪽으로 한 칸 이동합니다.

---

### Python

```python
def solution(A, B):
    for i in range(len(A)):
        if A == B:
            return i

        # 마지막 문자를 맨 앞으로 이동
        A = A[-1] + A[:-1]

    return -1
```

핵심 코드는 다음과 같습니다.

```python
A = A[-1] + A[:-1]
```

`A = "hello"`라면:

```python
A[-1]
```

결과:

```text
o
```

그리고:

```python
A[:-1]
```

결과:

```text
hell
```

따라서:

```text
o + hell
= ohell
```

이 됩니다.

---

## 6. 방법 2 - 문자열을 두 번 이어 붙이기

이 문제는 문자열 회전의 성질을 이용하면 더 간단하게 해결할 수 있습니다.

예를 들어:

```text
A = hello
B = ohell
```

`B`를 두 번 이어 붙이면:

```text
ohell + ohell
= ohellohell
```

이 문자열에서 `A`인 `"hello"`를 찾으면 시작 위치가 `1`입니다.

```text
o h e l l o h e l l
  └── hello ──┘
```

따라서 `A`를 오른쪽으로 `1`번 밀면 `B`가 됩니다.

---

## 7. 간단한 C# 풀이

```csharp
public class Solution
{
    public int solution(string A, string B)
    {
        return (B + B).IndexOf(A);
    }
}
```

C#의 `IndexOf()`는 문자열을 찾지 못하면 `-1`을 반환합니다.

따라서 별도의 조건문이 필요하지 않습니다.

---

## 8. 간단한 Python 풀이

```python
def solution(A, B):
    return (B + B).find(A)
```

Python의 `find()`도 문자열을 찾지 못하면 `-1`을 반환합니다.

---

## 9. 왜 `A + A`가 아니라 `B + B`인가?

이 문제에서 구하려는 값은 다음과 같습니다.

> **A를 오른쪽으로 몇 번 이동해야 B가 되는가?**

예를 들어:

```text
A = hello
B = ohell
```

`B + B`는:

```text
ohellohell
```

여기서 `A = "hello"`의 시작 위치는:

```text
1
```

즉 오른쪽으로 한 번 이동하면 된다는 의미입니다.

반대로:

```text
A + A
= hellohello
```

여기서 `"ohell"`의 위치는:

```text
4
```

하지만 실제 정답은 `1`입니다.

따라서 이 문제에서는 다음과 같이 사용해야 합니다.

```csharp
(B + B).IndexOf(A)
```

또는:

```python
(B + B).find(A)
```

---

## 10. 시간 복잡도

### 직접 회전 방식

문자열 길이를 `N`이라고 하면 각 회전에서 새로운 문자열을 생성하므로 대략:

```text
O(N²)
```

입니다.

하지만 문제의 제한이:

```text
N < 100
```

이므로 성능상 문제는 없습니다.

### 문자열 검색 방식

코드는 훨씬 간결하며 코딩테스트에서는 다음 풀이가 특히 유용합니다.

```csharp
return (B + B).IndexOf(A);
```

```python
return (B + B).find(A)
```

---

## 11. 최종 추천 답안

### C#

```csharp
public class Solution
{
    public int solution(string A, string B)
    {
        return (B + B).IndexOf(A);
    }
}
```

### Python

```python
def solution(A, B):
    return (B + B).find(A)
```

---

## 12. 정리

이 문제의 핵심은 **문자열 회전(String Rotation)** 입니다.

다음 성질을 기억하면 비슷한 문제를 쉽게 해결할 수 있습니다.

> 어떤 문자열의 회전 결과는 해당 문자열을 두 번 이어 붙인 문자열 안에서 찾을 수 있습니다.

이 문제에서는 **오른쪽 회전 횟수**가 필요하므로:

```text
B + B
```

안에서:

```text
A
```

의 위치를 찾으면 됩니다.
