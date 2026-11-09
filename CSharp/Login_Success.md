# 프로그래머스 로그인 — C# LINQ & Python 풀이

## 1. 문제 개요

입력한 아이디·비밀번호 `id_pw`와 회원 정보 2차원 배열 `db`를 비교하여 로그인 결과를 반환합니다.

| 조건 | 반환값 |
| --- | --- |
| 아이디와 비밀번호가 모두 일치 | `"login"` |
| 아이디는 일치하지만 비밀번호 불일치 | `"wrong pw"` |
| 아이디가 존재하지 않음 | `"fail"` |

**중요:** 비밀번호가 다른 회원과 같더라도 아이디가 일치하지 않으면 `"fail"`입니다. 회원 아이디는 중복되지 않습니다.

---

## 2. C# 정답 — LINQ `FirstOrDefault()` (추천)

```csharp
using System.Linq;

public class Solution
{
    public string solution(string[] id_pw, string[,] db)
    {
        // 아이디가 일치하는 회원의 행 번호 검색 (없으면 -1)
        int row = Enumerable.Range(0, db.GetLength(0))
                            .Where(i => db[i, 0] == id_pw[0])
                            .Select(i => (int?)i)
                            .FirstOrDefault() ?? -1;

        if (row == -1)
            return "fail";

        return db[row, 1] == id_pw[1] ? "login" : "wrong pw";
    }
}
```

### 코드 설명

- `db`는 **C#의 직사각형 2차원 배열(`string[,]`)**입니다. `db[i, 0]`은 아이디, `db[i, 1]`은 비밀번호입니다.
- `db.GetLength(0)`은 행(회원) 개수를 반환합니다.
- `Enumerable.Range(0, n)`은 인덱스 `0`부터 `n - 1`까지 생성합니다.
- `Where(...)`는 입력 아이디와 같은 회원 행만 필터링합니다.
- `Select(i => (int?)i)`는 행 인덱스를 nullable 정수로 변환합니다.
- `FirstOrDefault() ?? -1`은 일치하는 행이 없을 때 `-1`을 반환하도록 합니다. **행 인덱스 0과 '검색 실패'를 혼동하지 않도록** nullable로 변환했습니다.
- 해당 회원의 비밀번호가 같다면 `"login"`, 아니면 `"wrong pw"`입니다.

> **참고:** 프로그래머스 C#의 이 문제는 일반적으로 `string[,] db` 형태로 입력받습니다. `string[][] db`와 혼동하지 마세요. `string[,]`은 `db[i, 0]`, `string[][]`는 `db[i][0]`으로 접근합니다.

---

## 3. C# 정답 — LINQ `Any()` (짧고 직관적인 방식)

```csharp
using System.Linq;

public class Solution
{
    public string solution(string[] id_pw, string[,] db)
    {
        var rows = Enumerable.Range(0, db.GetLength(0));

        if (rows.Any(i => db[i, 0] == id_pw[0] && db[i, 1] == id_pw[1]))
            return "login";

        if (rows.Any(i => db[i, 0] == id_pw[0]))
            return "wrong pw";

        return "fail";
    }
}
```

`Any(predicate)`는 조건에 맞는 원소가 **하나라도 존재하면 `true`**를 반환합니다. 가장 간단하게 LINQ를 연습하기 좋은 풀이입니다. 최악의 경우 최대 두 번 전체 회원을 확인하므로 시간 복잡도는 여전히 `O(N)`입니다.

---

## 4. C# 정답 — 일반 `for`문 (LINQ 없이)

```csharp
public class Solution
{
    public string solution(string[] id_pw, string[,] db)
    {
        for (int i = 0; i < db.GetLength(0); i++)
        {
            if (db[i, 0] == id_pw[0])
                return db[i, 1] == id_pw[1] ? "login" : "wrong pw";
        }

        return "fail";
    }
}
```

회원 아이디는 중복되지 않으므로, 같은 아이디를 찾았다면 곧바로 비밀번호만 확인하고 반환할 수 있습니다.

---

## 5. Python 정답 — `for`문 (추천)

```python
def solution(id_pw, db):
    for user_id, password in db:
        # 아이디가 같은 회원을 발견하면 비밀번호 검사
        if user_id == id_pw[0]:
            return "login" if password == id_pw[1] else "wrong pw"

    # 같은 아이디의 회원이 없음
    return "fail"
```

Python은 2차원 리스트의 한 행을 `for user_id, password in db`처럼 **언패킹(unpacking)**할 수 있습니다.

### Python — `next()` 활용

```python
def solution(id_pw, db):
    member = next((row for row in db if row[0] == id_pw[0]), None)

    if member is None:
        return "fail"

    return "login" if member[1] == id_pw[1] else "wrong pw"
```

`next(generator, None)`은 조건에 일치하는 첫 번째 회원을 반환하고, 찾지 못하면 `None`을 반환합니다. C#의 `FirstOrDefault()`와 유사합니다.

---

## 6. 예제로 실행 과정 확인

### 예제 1: `"login"`

```text
id_pw = ["meosseugi", "1234"]
db = [["rardss", "123"], ["yyoom", "1234"], ["meosseugi", "1234"]]

1. rardss    != meosseugi → 다음 회원
2. yyoom     != meosseugi → 다음 회원
3. meosseugi == meosseugi → 비밀번호 비교
   1234      == 1234      → "login"
```

### 예제 2: `"wrong pw"`

```text
id_pw = ["programmer01", "15789"]
db = [["programmer02", "111111"], ["programmer00", "134"], ["programmer01", "1145"]]

programmer01 아이디를 발견했지만
1145 != 15789 → "wrong pw"
```

### 예제 3: `"fail"`

```text
id_pw = ["rabbit04", "98761"]
db = [["jaja11", "98761"], ["krong0313", "29440"], ["rabbit00", "111333"]]

rabbit04 아이디가 없음 → "fail"
※ 첫 번째 회원의 비밀번호가 같아도 아이디가 다르면 로그인 실패입니다.
```

---

## 7. 주요 문법 비교

| 기능 | C# | Python |
| --- | --- | --- |
| 회원 순회 | `for (int i = 0; i < db.GetLength(0); i++)` | `for user_id, password in db:` |
| 아이디 비교 | `db[i, 0] == id_pw[0]` | `user_id == id_pw[0]` |
| 첫 일치 검색 | LINQ `FirstOrDefault()` | `next(generator, None)` |
| 존재 여부 확인 | LINQ `Any(...)` | `any(...)` |
| 삼항 연산 | `condition ? a : b` | `a if condition else b` |
| 문자열 리턴 | `return "login";` | `return "login"` |

---

## 8. 시간·공간 복잡도

회원 수를 `N`이라 할 때:

| 풀이 | 시간 복잡도 | 추가 공간 복잡도 |
| --- | --- | --- |
| C# LINQ `FirstOrDefault()` | `O(N)` | `O(1)` |
| C# LINQ `Any()` | `O(N)` | `O(1)` |
| C# `for`문 | `O(N)` | `O(1)` |
| Python `for`문 | `O(N)` | `O(1)` |
| Python `next()` | `O(N)` | `O(1)` |

`Enumerable.Range`와 LINQ 필터는 지연 실행되므로 회원 인덱스 전체를 따로 저장할 필요가 없습니다. 여기서는 회원 수가 최대 10명이므로 어느 방식이든 충분히 빠릅니다.

---

## 9. 자주 하는 실수와 핵심 정리

1. **비밀번호만 일치하는 경우**에도 `"login"`을 반환하면 안 됩니다.
2. 아이디가 존재하는지 먼저 판단해야 `"fail"`과 `"wrong pw"`를 구분할 수 있습니다.
3. LINQ `FirstOrDefault()`가 정수 인덱스를 직접 반환하도록 하면 검색 실패 시 기본값 `0`과 첫 번째 회원 인덱스 `0`을 구분할 수 없습니다. nullable 인덱스를 사용하거나 `Any()`로 검사하세요.
4. **프로그래머스 C#의 `string[,]` 입력**에는 `db[i, 0]` 문법을 사용하세요.

**추천:** LINQ를 연습하려면 `Any()` 풀이, 아이디를 한 번만 검색하려면 `FirstOrDefault()` 풀이, 가장 직관적인 구현은 C#과 Python 모두 `for`문 풀이를 선택하세요.
