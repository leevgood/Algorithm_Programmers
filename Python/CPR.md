# 심폐소생술 순서 찾기 - 빈칸 채우기 (CPR Order Fill-in-the-Blank)

## 프로그램 설명

이 문제는 심폐소생술 방법들이 무작위 순서로 담긴 리스트 `cpr`가 주어졌을 때, 각 방법이 올바른 심폐소생술 순서에서 몇 번째 단계인지 찾아 리스트로 반환하는 문제입니다.

심폐소생술의 올바른 순서는 다음과 같습니다.

1. `"check"` - 심정지 및 무호흡 확인
2. `"call"` - 도움 및 119 신고 요청
3. `"pressure"` - 가슴압박 30회 시행
4. `"respiration"` - 인공호흡 2회 시행
5. `"repeat"` - 가슴압박, 인공호흡 반복

---

## 빈칸 채우기 문제 안내

이 문제는 **빈칸 채우기** 유형입니다.

빈칸 채우기 문제에서는 이미 작성된 코드 중 일부 빈칸에 알맞은 코드를 넣어야 합니다.

주의할 점은 다음과 같습니다.

- 빈칸을 제외한 기본 코드는 수정할 수 없습니다.
- 빈칸에 알맞은 코드를 입력해야 정상적으로 실행됩니다.
- 빈칸을 채우지 않으면 실행 결과에 에러 메시지가 표시됩니다.

---

## 완성 코드

```python
def solution(cpr):
    answer = []
    basic_order = ["check", "call", "pressure", "respiration", "repeat"]

    for action in cpr:
        for i in range(len(basic_order)):
            if action == basic_order[i]:
                answer.append(i + 1)

    return answer
```

---

## 빈칸에 들어갈 코드

원래 코드의 빈칸에는 다음 코드가 들어갑니다.

| 위치 | 들어갈 코드 | 설명 |
|---|---|---|
| `for action in ____:` | `cpr` | 입력 리스트 `cpr`의 값을 하나씩 꺼냅니다. |
| `for i in ____:` | `range(len(basic_order))` | `basic_order`의 인덱스를 순서대로 확인합니다. |
| `answer.append(____)` | `i + 1` | 인덱스는 0부터 시작하므로 단계 번호로 만들기 위해 1을 더합니다. |

---

## 코드 설명

```python
def solution(cpr):
```

`solution` 함수는 심폐소생술 방법들이 들어 있는 리스트 `cpr`를 입력받습니다.

```python
answer = []
```

결과를 저장할 빈 리스트 `answer`를 만듭니다.

```python
basic_order = ["check", "call", "pressure", "respiration", "repeat"]
```

심폐소생술의 올바른 순서를 리스트로 저장합니다.

```python
for action in cpr:
```

입력 리스트 `cpr`에 들어 있는 심폐소생술 방법을 하나씩 꺼냅니다.

예를 들어 `cpr`가 다음과 같다면,

```python
["call", "respiration", "repeat", "check", "pressure"]
```

`action`에는 차례대로 `"call"`, `"respiration"`, `"repeat"`, `"check"`, `"pressure"`가 들어갑니다.

```python
for i in range(len(basic_order)):
```

`basic_order` 리스트의 인덱스를 하나씩 확인합니다.

`basic_order`의 길이는 5이므로,

```python
range(len(basic_order))
```

는 다음과 같은 인덱스를 만듭니다.

```python
0, 1, 2, 3, 4
```

```python
if action == basic_order[i]:
```

현재 `action`이 `basic_order[i]`와 같은지 비교합니다.

예를 들어 `action`이 `"call"`일 때,

```python
basic_order[1]
```

은 `"call"`이므로 조건이 참이 됩니다.

```python
answer.append(i + 1)
```

일치하는 위치를 찾으면 해당 순서를 `answer`에 추가합니다.

리스트의 인덱스는 0부터 시작하지만, 문제에서 원하는 단계 번호는 1부터 시작합니다.

따라서 `i`가 아니라 `i + 1`을 추가해야 합니다.

```python
return answer
```

완성된 결과 리스트를 반환합니다.

---

## 입력 예시 1

```python
cpr = ["call", "respiration", "repeat", "check", "pressure"]
print(solution(cpr))
```

## 출력 예시 1

```python
[2, 4, 5, 1, 3]
```

## 예시 1 동작 과정

| `action` | `basic_order`에서의 인덱스 `i` | 단계 번호 `i + 1` |
|---|---:|---:|
| `"call"` | 1 | 2 |
| `"respiration"` | 3 | 4 |
| `"repeat"` | 4 | 5 |
| `"check"` | 0 | 1 |
| `"pressure"` | 2 | 3 |

따라서 결과는 다음과 같습니다.

```python
[2, 4, 5, 1, 3]
```

---

## 입력 예시 2

```python
cpr = ["respiration", "repeat", "check", "pressure", "call"]
print(solution(cpr))
```

## 출력 예시 2

```python
[4, 5, 1, 3, 2]
```

## 예시 2 동작 과정

| `action` | `basic_order`에서의 인덱스 `i` | 단계 번호 `i + 1` |
|---|---:|---:|
| `"respiration"` | 3 | 4 |
| `"repeat"` | 4 | 5 |
| `"check"` | 0 | 1 |
| `"pressure"` | 2 | 3 |
| `"call"` | 1 | 2 |

따라서 결과는 다음과 같습니다.

```python
[4, 5, 1, 3, 2]
```

---

## 주요 문법 설명

| 문법 | 설명 |
|---|---|
| `for action in cpr` | `cpr` 리스트의 값을 하나씩 꺼내 반복합니다. |
| `range()` | 정해진 범위의 숫자를 차례대로 생성합니다. |
| `len(basic_order)` | `basic_order` 리스트의 길이를 구합니다. |
| `range(len(basic_order))` | 리스트의 인덱스를 순서대로 반복할 때 사용합니다. |
| `basic_order[i]` | `basic_order` 리스트에서 `i`번째 값을 가져옵니다. |
| `if action == basic_order[i]` | 두 값이 같은지 비교합니다. |
| `append()` | 리스트의 끝에 값을 추가합니다. |
| `i + 1` | 0부터 시작하는 인덱스를 1부터 시작하는 순서 번호로 바꿉니다. |

---

## 핵심 아이디어

이 문제의 핵심은 입력으로 들어온 문자열이 올바른 순서 리스트에서 몇 번째 위치에 있는지 찾는 것입니다.

1. 올바른 순서를 `basic_order` 리스트에 저장합니다.
2. `cpr` 리스트의 값을 하나씩 확인합니다.
3. 각 값이 `basic_order`의 몇 번째 인덱스에 있는지 찾습니다.
4. 인덱스에 1을 더해 실제 단계 번호로 변환합니다.
5. 결과 리스트 `answer`에 추가합니다.

---

## 참고 사항

이 문제에서는 기본 코드가 정해져 있기 때문에 빈칸만 채워야 합니다.

따라서 아래와 같은 더 짧은 풀이도 가능하지만, 빈칸 채우기 문제에서는 기본 구조를 유지해야 합니다.

```python
def solution(cpr):
    basic_order = ["check", "call", "pressure", "respiration", "repeat"]
    return [basic_order.index(action) + 1 for action in cpr]
```

또는 딕셔너리를 사용하면 다음과 같이 풀 수도 있습니다.

```python
def solution(cpr):
    order = {
        "check": 1,
        "call": 2,
        "pressure": 3,
        "respiration": 4,
        "repeat": 5
    }

    return [order[action] for action in cpr]
```

하지만 이 문제의 목적은 주어진 코드의 빈칸을 올바르게 채우는 것이므로, 최종 제출 코드는 아래 형태가 가장 적절합니다.

```python
def solution(cpr):
    answer = []
    basic_order = ["check", "call", "pressure", "respiration", "repeat"]

    for action in cpr:
        for i in range(len(basic_order)):
            if action == basic_order[i]:
                answer.append(i + 1)

    return answer
```
