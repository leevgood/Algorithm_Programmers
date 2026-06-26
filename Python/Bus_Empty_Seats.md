# 버스 빈 좌석 구하기 (Bus Empty Seats)

---

## 📌 문제 설명

영진이는 약속 장소에 가기 위해 버스를 타려고 합니다.  
버스에는 총 `seat`개의 좌석이 있으며, 영진이가 기다리는 정거장에 버스가 도착했을 때 **남아 있는 좌석 수**를 구해야 합니다.

버스는 기점에서 출발할 때 승객이 `0명`이며, 영진이가 기다리는 정거장에 도착하기 전까지 각 정거장에서 승객이 타거나 내립니다.

각 정거장의 정보는 다음 문자열로 주어집니다.

| 문자열 | 의미 |
|---|---|
| `"On"` | 승객이 버스에 탑승 |
| `"Off"` | 승객이 버스에서 하차 |
| `"-"` | 의미 없는 값, 배열 길이를 맞추기 위한 요소 |

영진이가 기다리는 정거장에서는 **영진이가 가장 먼저 탑승**합니다.  
따라서 이전 정거장들까지 계산한 현재 탑승객 수를 기준으로 빈 좌석 수를 계산하면 됩니다.

---

## ✅ 제한사항

- `1 ≤ seat ≤ 30`
- `1 ≤ passengers의 길이 ≤ 10`
- `1 ≤ passengers[i]의 길이 ≤ 20`
- `passengers[i]`의 원소는 `"On"`, `"Off"`, `"-"` 중 하나입니다.
- `"-"`는 배열의 길이를 맞추기 위한 값이며 계산에 포함하지 않습니다.
- 버스는 기점에서 승객 `0명`으로 출발합니다.

---

## 🧩 빈칸 채우기 핵심 아이디어

주어진 코드에는 네 개의 보조 함수가 있습니다.

```python
def func1(num):
    if 0 > num:
        return 0
    else:
        return num
```

`func1(num)`은 `num`이 음수이면 `0`을 반환하고, 아니면 그대로 반환합니다.  
즉, **남은 좌석 수가 음수가 되지 않도록 보정**할 때 사용합니다.

```python
def func2(num):
    if num > 0:
        return 0
    else:
        return num
```

`func2(num)`은 양수이면 `0`을 반환하고, 아니면 그대로 반환합니다.  
이 문제의 최종 답을 구하는 데는 적합하지 않습니다.

```python
def func3(station):
    num = 0
    for people in station:
        if people == "Off":
            num += 1
    return num
```

`func3(station)`은 해당 정거장에서 **하차한 승객 수**를 구합니다.

```python
def func4(station):
    num = 0
    for people in station:
        if people == "On":
            num += 1
    return num
```

`func4(station)`은 해당 정거장에서 **탑승한 승객 수**를 구합니다.

---

## ✅ 빈칸에 들어갈 코드

기존 코드의 빈칸은 아래처럼 채워야 합니다.

```python
num_passenger += func4(station)
num_passenger -= func3(station)
answer = func1(seat - num_passenger)
```

### 이유

각 정거장마다 다음 순서로 계산합니다.

1. `"On"` 승객 수만큼 현재 탑승객 수를 증가시킵니다.
2. `"Off"` 승객 수만큼 현재 탑승객 수를 감소시킵니다.
3. 모든 정거장 계산이 끝난 뒤 `seat - num_passenger`로 남은 좌석 수를 구합니다.
4. 승객 수가 좌석 수보다 많을 수 있으므로 `func1()`을 사용해 음수 결과를 `0`으로 보정합니다.

---

## 💻 완성 코드

```python
def func1(num):
    if 0 > num:
        return 0
    else:
        return num


def func2(num):
    if num > 0:
        return 0
    else:
        return num


def func3(station):
    num = 0
    for people in station:
        if people == "Off":
            num += 1
    return num


def func4(station):
    num = 0
    for people in station:
        if people == "On":
            num += 1
    return num


def solution(seat, passengers):
    num_passenger = 0

    for station in passengers:
        # 해당 정거장에서 탑승한 승객 수를 더합니다.
        num_passenger += func4(station)

        # 해당 정거장에서 하차한 승객 수를 뺍니다.
        num_passenger -= func3(station)

    # 전체 좌석 수에서 현재 탑승객 수를 뺀 뒤,
    # 음수가 나오면 0으로 보정합니다.
    answer = func1(seat - num_passenger)

    return answer
```

---

## 🔍 주요 함수 및 문법 설명

| 함수 / 문법 | 설명 |
|---|---|
| `func1(num)` | `num`이 음수이면 `0`, 아니면 `num`을 반환합니다. |
| `func3(station)` | 한 정거장에서 `"Off"`의 개수를 세어 하차 승객 수를 반환합니다. |
| `func4(station)` | 한 정거장에서 `"On"`의 개수를 세어 탑승 승객 수를 반환합니다. |
| `for station in passengers` | 각 정거장의 승/하차 정보를 순서대로 확인합니다. |
| `num_passenger += ...` | 현재 버스에 탄 승객 수를 증가시킵니다. |
| `num_passenger -= ...` | 현재 버스에 탄 승객 수를 감소시킵니다. |
| `seat - num_passenger` | 남아 있는 좌석 수를 계산합니다. |

---

## 📥 입출력 예시 1

### 입력

```python
seat = 5
passengers = [
    ["On", "On", "On"],
    ["Off", "On", "-"],
    ["Off", "-", "-"]
]
```

### 출력

```python
3
```

### 설명

| 정거장 | 탑승 | 하차 | 현재 승객 수 |
|---|---:|---:|---:|
| 1번 정거장 | 3명 | 0명 | 3명 |
| 2번 정거장 | 1명 | 1명 | 3명 |
| 3번 정거장 | 0명 | 1명 | 2명 |

버스 좌석은 `5개`이고 현재 승객은 `2명`입니다.

```python
5 - 2 = 3
```

따라서 남은 좌석 수는 `3개`입니다.

---

## 📥 입출력 예시 2

### 입력

```python
seat = 10
passengers = [
    ["On", "On", "On", "On", "On", "On", "On", "On", "-", "-"],
    ["On", "On", "Off", "Off", "Off", "On", "On", "-", "-", "-"],
    ["On", "On", "On", "Off", "On", "On", "On", "Off", "Off", "Off"],
    ["On", "On", "Off", "-", "-", "-", "-", "-", "-", "-"]
]
```

### 출력

```python
0
```

### 설명

최종적으로 버스에는 `12명`이 타고 있습니다.  
좌석 수는 `10개`이므로 계산상 남은 좌석은 다음과 같습니다.

```python
10 - 12 = -2
```

하지만 남은 좌석 수는 음수가 될 수 없으므로 `0`을 반환합니다.

---

## 🧠 코드 동작 과정

1. `num_passenger`를 `0`으로 초기화합니다.
2. 각 정거장 정보를 순서대로 확인합니다.
3. `"On"`의 개수를 세어 현재 승객 수에 더합니다.
4. `"Off"`의 개수를 세어 현재 승객 수에서 뺍니다.
5. 모든 정거장을 처리한 뒤 `seat - num_passenger`를 계산합니다.
6. 결과가 음수라면 `func1()`을 통해 `0`으로 변환합니다.
7. 최종 남은 좌석 수를 반환합니다.

---

## ⏱️ 시간 복잡도

`passengers`의 모든 원소를 한 번씩 확인합니다.

- 정거장 수: `N`
- 각 정거장 정보 길이: `M`

따라서 시간 복잡도는 다음과 같습니다.

```text
O(N × M)
```

---

## ✅ 제출용 코드

```python
def solution(seat, passengers):
    num_passenger = 0

    for station in passengers:
        num_passenger += func4(station)
        num_passenger -= func3(station)

    answer = func1(seat - num_passenger)

    return answer
```
