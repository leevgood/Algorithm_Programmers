# 등차수열의 특정한 항만 더하기

---

## 프로그램 설명

이 문제는 첫째항이 `a`, 공차가 `d`인 **등차수열**에서 `included` 배열의 값이 `true`인 항만 골라 더하는 문제입니다.

`included[i]`가 `true`라면 등차수열의 `i + 1`번째 항을 결과에 더합니다.

예를 들어 `a = 3`, `d = 4`일 때 등차수열은 다음과 같습니다.

```text
3, 7, 11, 15, 19, ...
```

여기서 `included = [true, false, false, true, true]`라면 1항, 4항, 5항만 더합니다.

```text
3 + 15 + 19 = 37
```

---

## 문제 조건

- `1 ≤ a ≤ 100`
- `1 ≤ d ≤ 100`
- `1 ≤ included의 길이 ≤ 100`
- `included`에는 `true`가 적어도 하나 존재합니다.

---

## 풀이 아이디어

등차수열의 `i + 1`번째 항은 다음 공식으로 구할 수 있습니다.

```text
a + d * i
```

Python 배열의 인덱스는 `0`부터 시작하므로,

- `i = 0`이면 1항
- `i = 1`이면 2항
- `i = 2`이면 3항

이 됩니다.

따라서 `included[i]`가 `True`인 경우에만 `a + d * i`를 더하면 됩니다.

---

## 소스 코드

```python
def solution(a, d, included):
    answer = 0

    # included 배열을 인덱스와 함께 순회
    for i in range(len(included)):
        # included[i]가 True이면 해당 항을 더함
        if included[i]:
            answer += a + d * i

    return answer
```

---

## 더 간단한 풀이

`enumerate()`를 사용하면 인덱스와 값을 동시에 가져올 수 있어 더 깔끔하게 작성할 수 있습니다.

```python
def solution(a, d, included):
    answer = 0

    for i, check in enumerate(included):
        if check:
            answer += a + d * i

    return answer
```

---

## 한 줄 풀이

Python의 `sum()`과 `enumerate()`를 사용하면 한 줄로도 해결할 수 있습니다.

```python
def solution(a, d, included):
    return sum(a + d * i for i, check in enumerate(included) if check)
```

---

## 주요 문법 설명

| 문법 | 설명 |
|---|---|
| `range(len(included))` | `included` 배열의 인덱스를 순서대로 생성합니다. |
| `included[i]` | `included` 배열의 `i`번째 값을 확인합니다. |
| `if included[i]:` | 값이 `True`일 때만 내부 코드를 실행합니다. |
| `a + d * i` | 등차수열의 `i + 1`번째 항을 계산합니다. |
| `answer += 값` | 기존 `answer`에 값을 누적합니다. |
| `enumerate()` | 인덱스와 값을 동시에 가져올 수 있는 함수입니다. |
| `sum()` | 여러 값을 모두 더해주는 함수입니다. |

---

## 입력 예시 1

```python
a = 3
d = 4
included = [True, False, False, True, True]
```

---

## 출력 예시 1

```text
37
```

---

## 예시 1 동작 과정

| 항 번호 | 인덱스 i | 등차수열 값 `a + d * i` | included[i] | 더하는 값 |
|---:|---:|---:|:---:|---:|
| 1항 | 0 | 3 | True | 3 |
| 2항 | 1 | 7 | False | - |
| 3항 | 2 | 11 | False | - |
| 4항 | 3 | 15 | True | 15 |
| 5항 | 4 | 19 | True | 19 |

따라서 결과는 다음과 같습니다.

```text
3 + 15 + 19 = 37
```

---

## 입력 예시 2

```python
a = 7
d = 1
included = [False, False, False, True, False, False, False]
```

---

## 출력 예시 2

```text
10
```

---

## 예시 2 동작 과정

| 항 번호 | 인덱스 i | 등차수열 값 `a + d * i` | included[i] | 더하는 값 |
|---:|---:|---:|:---:|---:|
| 1항 | 0 | 7 | False | - |
| 2항 | 1 | 8 | False | - |
| 3항 | 2 | 9 | False | - |
| 4항 | 3 | 10 | True | 10 |
| 5항 | 4 | 11 | False | - |
| 6항 | 5 | 12 | False | - |
| 7항 | 6 | 13 | False | - |

따라서 4항만 더하므로 결과는 다음과 같습니다.

```text
10
```

---

## 시간 복잡도

`included` 배열을 한 번 순회하므로 시간 복잡도는 다음과 같습니다.

```text
O(n)
```

여기서 `n`은 `included` 배열의 길이입니다.

---

## 공간 복잡도

추가로 사용하는 변수는 `answer`, `i` 정도이므로 공간 복잡도는 다음과 같습니다.

```text
O(1)
```

---

## 참고 사항

이 문제에서 가장 중요한 부분은 Python의 인덱스가 `0`부터 시작한다는 점입니다.

등차수열의 일반항은 보통 다음과 같이 표현합니다.

```text
a + d * (항 번호 - 1)
```

하지만 코드에서는 인덱스 `i`가 이미 `항 번호 - 1`과 같은 역할을 하므로 다음처럼 계산하면 됩니다.

```python
a + d * i
```
