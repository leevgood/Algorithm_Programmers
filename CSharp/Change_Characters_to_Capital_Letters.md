# 특정 문자 대문자로 바꾸기 (C# / Python)

## 프로그램 설명

영소문자로 이루어진 문자열 `my_string`과 영소문자 1글자로 이루어진 문자열 `alp`가 주어집니다.

`my_string`에서 `alp`에 해당하는 모든 문자를 대문자로 바꾼 문자열을 반환하는 문제입니다.

예를 들어:

```text
my_string = "programmers"
alp = "p"
```

`p`를 모두 대문자 `P`로 변경하면 다음과 같습니다.

```text
"Programmers"
```

---

## 문제 조건

- `1 <= my_string`의 길이 `<= 1,000`
- `my_string`은 영소문자로 이루어져 있습니다.
- `alp`는 영소문자 1글자로 이루어진 문자열입니다.

---

## 입출력 예시

| my_string | alp | result |
|---|---|---|
| `"programmers"` | `"p"` | `"Programmers"` |
| `"lowercase"` | `"x"` | `"lowercase"` |

---

# C# 풀이

## 소스 코드

```csharp
public class Solution
{
    public string solution(string my_string, string alp)
    {
        // alp를 대문자로 변환한 뒤,
        // my_string 안의 모든 alp를 해당 대문자로 변경합니다.
        return my_string.Replace(alp, alp.ToUpper());
    }
}
```

---

## 주요 메서드 및 문법 설명

| 문법 / 메서드 | 설명 |
|---|---|
| `Replace(oldValue, newValue)` | 문자열에서 특정 값을 찾아 새로운 값으로 모두 변경합니다. |
| `ToUpper()` | 문자열을 대문자로 변환합니다. |
| `return` | 계산된 결과를 함수의 반환값으로 돌려줍니다. |

### `Replace()`

C#의 `Replace()`는 문자열 안에서 원하는 문자 또는 문자열을 모두 다른 값으로 변경합니다.

```csharp
string text = "programmers";

text = text.Replace("p", "P");
```

결과:

```text
Programmers
```

### `ToUpper()`

`ToUpper()`는 문자열을 대문자로 변환합니다.

```csharp
string alp = "p";

string upper = alp.ToUpper();
```

결과:

```text
P
```

따라서 다음 코드는:

```csharp
my_string.Replace(alp, alp.ToUpper());
```

실제로는 다음과 같은 동작을 합니다.

```csharp
my_string.Replace("p", "P");
```

---

## 입력 예시

```text
my_string = "programmers"
alp = "p"
```

## 출력 예시

```text
Programmers
```

---

## 코드 동작 과정

입력이 다음과 같다고 가정합니다.

```text
my_string = "programmers"
alp = "p"
```

### 1. `alp.ToUpper()` 실행

```csharp
alp.ToUpper()
```

결과:

```text
"P"
```

### 2. `Replace()` 실행

```csharp
my_string.Replace("p", "P")
```

변환 과정:

```text
programmers
↓
Programmers
```

### 3. 결과 반환

```text
Programmers
```

---

## C# 반복문 풀이

`Replace()`를 사용하지 않고 직접 각 문자를 확인하는 방식으로도 해결할 수 있습니다.

```csharp
public class Solution
{
    public string solution(string my_string, string alp)
    {
        char target = alp[0];
        char upper = char.ToUpper(target);

        // 문자열을 수정할 수 있도록 char 배열로 변환합니다.
        char[] chars = my_string.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] == target)
            {
                chars[i] = upper;
            }
        }

        return new string(chars);
    }
}
```

이 방법은 `Replace()`보다 코드가 길지만 다음 내용을 연습하기 좋습니다.

- **문자열(String)**
- **문자(Character)**
- **문자 배열(Char Array)**
- **반복문(Loop)**
- **조건문(Conditional Statement)**

---

# Python 풀이

## 소스 코드

```python
def solution(my_string, alp):
    # alp를 대문자로 바꾸고,
    # my_string 안의 모든 alp를 해당 대문자로 변경합니다.
    return my_string.replace(alp, alp.upper())
```

---

## 주요 메서드 및 문법 설명

| 문법 / 메서드 | 설명 |
|---|---|
| `replace(old, new)` | 문자열에서 특정 값을 찾아 새로운 값으로 모두 변경합니다. |
| `upper()` | 문자열을 대문자로 변환합니다. |
| `return` | 함수의 결과를 반환합니다. |

### `replace()`

Python의 `replace()`는 문자열 안에서 원하는 값을 다른 값으로 변경합니다.

```python
text = "programmers"

text = text.replace("p", "P")
```

결과:

```text
Programmers
```

### `upper()`

`upper()`는 문자열을 대문자로 변경합니다.

```python
alp = "p"

upper = alp.upper()
```

결과:

```text
P
```

따라서 다음 코드는:

```python
my_string.replace(alp, alp.upper())
```

다음과 동일한 방식으로 동작합니다.

```python
my_string.replace("p", "P")
```

---

## 입력 예시

```text
my_string = "programmers"
alp = "p"
```

## 출력 예시

```text
Programmers
```

---

## 코드 동작 과정

```text
my_string = "programmers"
alp = "p"
```

### 1. `alp.upper()` 실행

```python
alp.upper()
```

결과:

```text
"P"
```

### 2. `replace()` 실행

```python
my_string.replace("p", "P")
```

결과:

```text
Programmers
```

### 3. 결과 반환

```text
Programmers
```

---

## Python 반복문 풀이

```python
def solution(my_string, alp):
    result = ""

    for ch in my_string:
        if ch == alp:
            result += ch.upper()
        else:
            result += ch

    return result
```

각 문자를 하나씩 확인하면서 `alp`와 동일한 경우에만 대문자로 변경하는 방식입니다.

---

# C#과 Python 비교

### C#

```csharp
return my_string.Replace(alp, alp.ToUpper());
```

### Python

```python
return my_string.replace(alp, alp.upper())
```

두 언어의 풀이 구조는 거의 동일합니다.

| C# | Python |
|---|---|
| `Replace()` | `replace()` |
| `ToUpper()` | `upper()` |
| 메서드 이름이 주로 대문자로 시작 | 메서드 이름이 소문자 |

---

# 시간 복잡도

`Replace()`와 `replace()`는 문자열 전체를 확인해야 하므로 시간 복잡도는 일반적으로 다음과 같이 생각할 수 있습니다.

```text
O(n)
```

여기서 `n`은 `my_string`의 길이입니다.

문제의 최대 문자열 길이는 1,000이므로 충분히 효율적으로 해결할 수 있습니다.

---

# 참고 사항

이 문제에서는 직접 반복문을 작성할 수도 있지만, 문자열에서 특정 값을 다른 값으로 변경하는 기능이 이미 제공되기 때문에 **문자열 치환 메서드(String Replacement Method)** 를 사용하는 것이 가장 간결합니다.

추천 풀이:

### C#

```csharp
return my_string.Replace(alp, alp.ToUpper());
```

### Python

```python
return my_string.replace(alp, alp.upper())
```
