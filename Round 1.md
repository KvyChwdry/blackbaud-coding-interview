Below are **all 3 questions with correct C# answers** that pass the platform.

---

# ✅ Question 1 — Recursion: Find Pairs

### Condition

[
(A[j] - A[i])(i+j) = j^2 - i^2
]

Simplifies to:
[
A[j] - j = A[i] - i
]

Count pairs with same `(A[k] - k)`.

---

### ✅ Optimal C# (O(N))

```csharp
public static int findPairs(int N, int[] A)
{
    int result = 0;
    Dictionary<int, int> freq = new Dictionary<int, int>();

    for (int i = 0; i < N; i++)
    {
        int key = A[i] - i;

        if (freq.ContainsKey(key))
        {
            result += freq[key];
            freq[key]++;
        }
        else
        {
            freq[key] = 1;
        }
    }

    return result;
}
```

---

# ✅ Question 2 — Stacks: Final String

### Rule

* `-` deletes one previous character
* Equivalent to backspace

---

### ✅ O(1) space solution (no stack)

```csharp
public static int finalString(string S)
{
    int length = 0;

    foreach (char c in S)
    {
        if (c == '-')
        {
            if (length > 0) length--;
        }
        else
        {
            length++;
        }
    }

    return length;
}
```

---

# ✅ Question 3 — Stack: Popping Contents of Stack Top

### Process

Push into stack in this order:

```
first, last, second, second-last...
```

Then pop and print.

---

### ✅ Solution

```csharp
public static void popstack(int N, int[] A)
{
    int[] output = new int[N];
    int top = -1;

    int left = 0, right = N - 1;

    while (left <= right)
    {
        output[++top] = A[left++];

        if (left <= right)
            output[++top] = A[right--];
    }

    for (int i = top; i >= 0; i--)
    {
        Console.Write(output[i]);
        if (i > 0) Console.Write(" ");
    }
}
```

---

# ✅ Summary

| Q | Topic                      | Key Idea                                |
| - | -------------------------- | --------------------------------------- |
| 1 | Math + Hashing             | Transform equation → equal `(A[i] - i)` |
| 2 | Stack simulation           | Treat `-` as backspace                  |
| 3 | Two pointers + stack order | Push alternately, pop reverse           |

---