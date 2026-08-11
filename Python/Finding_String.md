# 대소문자를 구분하지 않는 부분 문자열 찾기

## 문제 설명

알파벳으로 이루어진 문자열 `myString`과 `pat`이 주어집니다. `myString`의 연속된 부분 문자열 중 `pat`이 존재하면 `1`, 그렇지 않으면 `0`을 반환합니다.

단, 알파벳의 대문자와 소문자는 구분하지 않습니다.

## 제한사항

- `1 ≤ myString`의 길이 `≤ 100,000`
- `1 ≤ pat`의 길이 `≤ 300`
- `myString`과 `pat`은 모두 알파벳으로 이루어진 문자열입니다.

## Python 풀이

```python
def solution(myString, pat):
    return int(pat.lower() in myString.lower())
```

## 풀이 방법

두 문자열을 `lower()` 메서드로 모두 소문자로 변환하면 대소문자 차이를 제거할 수 있습니다.

이후 `in` 연산자로 `pat`이 `myString`에 포함되는지 확인합니다.

- 포함되면 `True`이며, `int(True)`는 `1`입니다.
- 포함되지 않으면 `False`이며, `int(False)`는 `0`입니다.

## 예시

```python
solution("AbCdEfG", "aBc")
```

```text
1
```

```python
solution("aaAA", "aaaaa")
```

```text
0
```

## 복잡도 분석

`N`을 `myString`의 길이, `M`을 `pat`의 길이라 할 때:

- 소문자 변환: `O(N + M)`
- 부분 문자열 탐색: 최악의 경우 `O(N × M)`

주어진 제한 범위에서 충분히 사용할 수 있는 풀이입니다.
