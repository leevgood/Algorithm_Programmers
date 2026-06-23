# [PCCE 기출문제] 3번 / 수 나누기

## 문제 설명

2자리 이상의 정수 `number`가 주어집니다.

주어진 코드는 이 수를 **2자리씩 자른 뒤**, 자른 수를 모두 더해서 그 합을 출력하는 코드입니다.

코드가 올바르게 작동하도록 **한 줄을 수정**해야 합니다.

---

## 기존 코드

```python
number = int(input())

answer = 0

for i in range(1):
    answer += number % 100
    number //= 100

print(answer)
```

---

## 문제점

기존 코드의 반복문은 다음과 같습니다.

```python
for i in range(1):
```

`range(1)`은 반복문을 **한 번만 실행**합니다.

하지만 문제에서는 `number`를 2자리씩 계속 잘라서 더해야 하므로,  
`number`가 `0`이 될 때까지 반복해야 합니다.

---

## 수정해야 할 코드

```python
for i in range(1):
```

위 코드를 아래처럼 수정합니다.

```python
while number > 0:
```

---

## 최종 코드

```python
number = int(input())

answer = 0

while number > 0:
    answer += number % 100
    number //= 100

print(answer)
```

---

## 코드 설명

| 코드 | 설명 |
|---|---|
| `number % 100` | `number`의 마지막 두 자리를 구합니다. |
| `answer += number % 100` | 구한 두 자리 수를 `answer`에 더합니다. |
| `number //= 100` | 마지막 두 자리를 제거합니다. |
| `while number > 0` | `number`가 0이 될 때까지 반복합니다. |

---

## 입력 예시

```text
123456
```

---

## 출력 예시

```text
102
```

---

## 동작 과정

입력값이 `123456`일 때, 숫자를 뒤에서부터 2자리씩 나누면 다음과 같습니다.

```text
56, 34, 12
```

각 값을 모두 더하면 다음과 같습니다.

```text
56 + 34 + 12 = 102
```

따라서 출력값은 `102`입니다.

---

## 핵심 포인트

이 문제의 핵심은 반복문을 한 번만 실행하는 것이 아니라,  
숫자가 모두 나누어질 때까지 반복해야 한다는 점입니다.

따라서 `for i in range(1):` 대신 `while number > 0:`을 사용해야 합니다.
