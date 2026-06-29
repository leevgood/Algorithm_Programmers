# 성적 비교 문제 풀이 (Python)

---

## 문제 설명

A반 학생들은 시험이 끝난 뒤, 실제 성적이 나오기 전에 자신의 시험지를 가채점했습니다.

이후 선생님이 실제 성적을 알려주었을 때,  
학생이 가채점한 점수와 실제 성적이 같은지 다른지 확인해야 합니다.

학생 번호가 담긴 리스트 `numbers`,  
학생들이 가채점한 점수가 담긴 리스트 `our_score`,  
실제 성적이 학생 번호 순서대로 담긴 리스트 `score_list`가 주어집니다.

각 학생의 가채점 점수와 실제 점수를 비교하여 다음과 같이 반환합니다.

- 점수가 같으면 `"Same"`
- 점수가 다르면 `"Different"`

---

## 핵심 아이디어

이 문제에서 가장 중요한 부분은 **학생 번호와 리스트 인덱스의 차이**입니다.

학생 번호는 **1번부터 시작**하지만,  
Python 리스트의 인덱스는 **0부터 시작**합니다.

예를 들어, 3번 학생의 실제 점수는 `score_list[3]`이 아니라 `score_list[2]`에 있습니다.

따라서 `numbers[i]`번 학생의 실제 점수는 다음과 같이 접근해야 합니다.

```python
score_list[numbers[i] - 1]
```

---

## 수정해야 하는 부분

기존 코드에서는 다음과 같이 작성되어 있었습니다.

```python
score_list[numbers[i]]
```

하지만 이 코드는 학생 번호를 그대로 리스트 인덱스로 사용하기 때문에 잘못된 결과가 나올 수 있습니다.

올바른 코드는 다음과 같습니다.

```python
score_list[numbers[i] - 1]
```

---

## Python 풀이 코드

```python
def solution(numbers, our_score, score_list):
    answer = []

    for i in range(len(numbers)):
        # numbers[i]번 학생의 실제 점수는 score_list[numbers[i] - 1]에 있음
        if our_score[i] == score_list[numbers[i] - 1]:
            answer.append("Same")
        else:
            answer.append("Different")

    return answer
```

---

## 코드 설명

| 코드 | 설명 |
|---|---|
| `answer = []` | 결과를 저장할 리스트를 생성합니다. |
| `for i in range(len(numbers)):` | 문의하려는 학생 수만큼 반복합니다. |
| `our_score[i]` | `i`번째 학생이 가채점한 점수입니다. |
| `score_list[numbers[i] - 1]` | 해당 학생 번호의 실제 점수입니다. |
| `answer.append("Same")` | 가채점 점수와 실제 점수가 같을 때 추가합니다. |
| `answer.append("Different")` | 가채점 점수와 실제 점수가 다를 때 추가합니다. |

---

## 입출력 예시 1

### 입력

```python
numbers = [1]
our_score = [100]
score_list = [100, 80, 90, 84, 20]
```

### 출력

```python
["Same"]
```

### 설명

1번 학생의 가채점 점수는 100점이고,  
실제 점수도 `score_list[0]`인 100점입니다.

따라서 결과는 `"Same"`입니다.

---

## 입출력 예시 2

### 입력

```python
numbers = [3, 4]
our_score = [85, 93]
score_list = [85, 92, 38, 93, 48, 85, 92, 56]
```

### 출력

```python
["Different", "Same"]
```

### 설명

3번 학생의 실제 점수는 `score_list[2]`인 38점입니다.  
가채점 점수 85점과 다르므로 `"Different"`입니다.

4번 학생의 실제 점수는 `score_list[3]`인 93점입니다.  
가채점 점수 93점과 같으므로 `"Same"`입니다.

---

## 시간 복잡도

문의하려는 학생 수를 `n`이라고 할 때,  
반복문은 `numbers`의 길이만큼 한 번 실행됩니다.

```text
시간 복잡도: O(n)
```

---

## 공간 복잡도

결과를 저장하는 리스트 `answer`가 필요합니다.

```text
공간 복잡도: O(n)
```

---

## 정리

이 문제는 리스트 인덱스 개념을 정확히 이해하는 것이 핵심입니다.

학생 번호는 1부터 시작하지만, Python 리스트 인덱스는 0부터 시작하므로  
실제 점수를 확인할 때 반드시 `numbers[i] - 1`을 사용해야 합니다.
