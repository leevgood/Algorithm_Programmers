# 닉네임 규칙 수정하기 (Fix Nickname Rules)

## 프로그램 설명

이 문제는 사용할 수 없는 닉네임 `nickname`을 정해진 규칙에 따라 사용할 수 있는 닉네임으로 바꾸는 문제입니다.

주어진 코드에는 대부분의 규칙이 구현되어 있지만, **닉네임의 길이가 4 미만일 경우 뒤에 소문자 `o`를 길이가 4가 될 때까지 이어붙이는 부분**이 잘못되어 있습니다.

기존 코드는 `o`를 한 번만 추가하기 때문에, 길이가 2 이하인 경우에는 여전히 길이가 4보다 작을 수 있습니다.

---

## 문제 핵심

닉네임 변경 규칙은 다음 순서대로 적용됩니다.

1. 소문자 `l`을 대문자 `I`로 변경합니다.
2. 소문자 `w`를 소문자 `vv`로 변경합니다.
3. 대문자 `W`를 대문자 `VV`로 변경합니다.
4. 대문자 `O`를 숫자 `0`으로 변경합니다.
5. 수정된 닉네임의 길이가 4 미만이면 뒤에 `o`를 길이가 4가 될 때까지 추가합니다.
6. 수정된 닉네임의 길이가 8보다 크면 8번째 문자까지만 사용합니다.

---

## 기존 코드의 문제점

기존 코드에서는 다음 부분이 잘못되어 있습니다.

```python
if len(answer) < 4:
    answer += "o"
```

이 코드는 `answer`의 길이가 4보다 작을 때 `o`를 **한 번만** 추가합니다.

예를 들어 `"GO"`가 입력되면 다음과 같이 동작합니다.

```text
"GO" → "G0"
```

이후 길이가 2이므로 `o`를 2개 붙여야 합니다.

```text
"G0" → "G0oo"
```

하지만 기존 코드는 `o`를 한 번만 붙여 `"G0o"`가 됩니다.

따라서 `if`문을 `while`문으로 수정해야 합니다.

---

## 수정된 소스 코드

```python
def solution(nickname):
    answer = ""

    for letter in nickname:
        # 소문자 l은 대문자 I로 변경
        if letter == "l":
            answer += "I"

        # 소문자 w는 소문자 vv로 변경
        elif letter == "w":
            answer += "vv"

        # 대문자 W는 대문자 VV로 변경
        elif letter == "W":
            answer += "VV"

        # 대문자 O는 숫자 0으로 변경
        elif letter == "O":
            answer += "0"

        # 그 외 문자는 그대로 사용
        else:
            answer += letter

    # 길이가 4 미만이면 길이가 4가 될 때까지 o 추가
    while len(answer) < 4:
        answer += "o"

    # 길이가 8보다 크면 앞에서 8글자만 사용
    if len(answer) > 8:
        answer = answer[:8]

    return answer
```

---

## 한 줄 수정 포인트

문제에서 요구하는 것은 **한 줄 수정**입니다.

따라서 아래 코드를

```python
if len(answer) < 4:
```

다음과 같이 수정하면 됩니다.

```python
while len(answer) < 4:
```

---

## 최종 제출 코드

```python
def solution(nickname):
    answer = ""
    for letter in nickname:
        if letter == "l":
            answer += "I"
        elif letter == "w":
            answer += "vv"
        elif letter == "W":
            answer += "VV"
        elif letter == "O":
            answer += "0"
        else:
            answer += letter

    while len(answer) < 4:
        answer += "o"

    if len(answer) > 8:
        answer = answer[:8]

    return answer
```

---

## 주요 문법 설명

| 문법 | 설명 |
|---|---|
| `for letter in nickname` | 문자열을 한 글자씩 반복합니다. |
| `if`, `elif`, `else` | 조건에 따라 다른 코드를 실행합니다. |
| `answer += "문자열"` | 기존 문자열 뒤에 새로운 문자열을 이어 붙입니다. |
| `len(answer)` | 문자열의 길이를 구합니다. |
| `while len(answer) < 4` | 문자열 길이가 4보다 작은 동안 반복합니다. |
| `answer[:8]` | 문자열의 앞에서부터 8번째 문자까지 자릅니다. |

---

## 입력 예시 1

```python
nickname = "WORLDworld"
```

## 출력 예시 1

```python
"VV0RLDvv"
```

## 동작 과정 1

```text
"WORLDworld"
→ "WORLDworId"
→ "WORLDvvorId"
→ "VVORLDvvorId"
→ "VV0RLDvvorId"
→ "VV0RLDvv"
```

---

## 입력 예시 2

```python
nickname = "GO"
```

## 출력 예시 2

```python
"G0oo"
```

## 동작 과정 2

```text
"GO"
→ "G0"
→ "G0oo"
```

---

## 코드 동작 과정

1. 빈 문자열 `answer`를 생성합니다.
2. `nickname`의 문자를 하나씩 확인합니다.
3. 사용할 수 없는 문자인 `l`, `w`, `W`, `O`를 규칙에 맞게 변경합니다.
4. 변경된 문자열의 길이가 4보다 작으면 `o`를 계속 추가합니다.
5. 변경된 문자열의 길이가 8보다 크면 앞에서 8글자만 남깁니다.
6. 최종 닉네임을 반환합니다.

---

## 참고 사항

- 이 문제의 핵심은 `if`와 `while`의 차이를 이해하는 것입니다.
- `if`는 조건이 참일 때 코드를 **한 번만** 실행합니다.
- `while`은 조건이 참인 동안 코드를 **반복해서** 실행합니다.
- 따라서 길이가 4가 될 때까지 `o`를 계속 붙이려면 `while`문을 사용해야 합니다.
