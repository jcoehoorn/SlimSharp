# SlimSharp

SlimSharp is an esoteric programming language based on C# intended for use in Code Golf scenarios. [Try it on .Net Fiddle.](https://dotnetfiddle.net/DkPEcu)

The aim is **not** to compete with other esoteric programming languages intended for code golf, but rather to reduce some of the worst points of verbosity holding back C# as a language for simple code golf problems: `Console.WriteLine()`, `Console.ReadLine()`, `Replace()`, `ToLower()`, etc.

SlimSharp starts with C# 9 (including [top-level statements](https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/exploration/top-level-statements)) and includes the following features and changes:

* Implicit using directives for (so far) System, System.Collections, System.Collections.Generics, System.Text, System.Linq.
* The `P()` function (short for "Print") aliases to `System.Diagnostics.Trace.WriteLine()`
* The `p()` function (short for "print") aliases to `System.Diagnostics.Trace.Write()`
* ConsoleTraceListener attached by default, and configurable by the compiler to include any built-in listener, allowing eg file output. 
  In short, the `P()`/`p()` functions can mean whatever you need them to in terms of output, as long as they can be created with a .Net built-in TraceListener constructor. 
* The `R()` function (short for "read") reads a string from the console
* The `R(string prompt)` function reads a string from the console, with the included prompt.
* The `RI()` function reads an integer from the console. Invalid input will throw an exception, but most code golf problems assume perfect typists.
* The `RI(string prompt)` function reads an integer from the console, with the included prompt. If the input is not a valid integer it will re-prompt until a valid integer is received (potentially forever).
* The `RI(string prompt, int MaxTries)` function reads an integer from the Console, with the included prompt. If the input is not a valid integer, it will re-prompt up to `MaxTries` times, after which an exception is thrown.
* The `RD()` function reads a double from the console. Invalid input will throw an exception, but most code golf problems assume perfect typists.
* The `RD(string prompt)` function reads a double from the console, with the included prompt. If the input is not a valid double it will re-prompt until a valid double is received (potentially forever).
* The `RD(string prompt, int MaxTries)` function reads a double from the console, with the included prompt. If the input is not a valid double it will re-prompt up to `MaxTries` times, after which an exception is thrown.
* The `RT()` function reads a datetime value from the console. Is not necessarily implemented using `DateTime.Parse()`, but must follow the documentation for the default `DateTime.Parse()` function. Right now, this means using the "conventions of the current culture".
* The `RT(string prompt)` function reads a datetime value from the console, with the included prompt. If the input is not a valid datetime, it will re-prompt until a valid datetime value is received (potentially forever). The same parsing rules as the base `RT()` function apply.
* The `RT(string prompt, int MaxTries)` function reads a datetime value from the console, with the included prompt. If the input is not a valid datetime, it will re-prompt up to `MaxTries` times, after which an exception is thrown. The same parsing rules as the base `RT()` function apply.
* `S` is an alias for `System.String`.
* `I` is an alias for `System.Int32`.
* `U` is an alias for `System.UInt32`.
* `D` is an alias for `System.Double`.
* `T` is an alias for `System.DateTime`.
* `O` is an alias for `System.Object`.
* `System.String.R()` is an alias for `System.String.Replace()`
* `System.String.S()` is an alias for `System.String.Substring()`
* `System.String.I()` is an alias for `System.String.IndexOf()`
* `System.String.l()` is an alias for `System.String.ToLower()`
* `System.String.U()` is an alias for `System.String.ToUpper()`
* `System.String.T()` is an alias for `System.String.Trim()`
* `System.String.Pad(int length)` is an alternative for `System.String.PadLeft()` and `System.String.PadRight()`. Positive `length` values pad to the right. Negative `length` values pad to the left.
* `System.String.L()` replaces `System.String.Length`
* `IP()` replaces `System.Int32.Parse()`
* `DP()` replaces `System.Double.Parse()`
* `TP()` replaces `System.DateTime.Parse()`. Note: `new T()` is often just as good or better, but this is useful if you have a string from elsewhere.
* `IMx()` replaces `System.Int32.MaxValue` (`IMx()`)
* `IMn()` replaces `System.Int32.MinValue`
* `DMx()` replaces `System.Double.MaxValue` (`D.Mx`)
* `DMn()` replaces `System.Double.MinValue`
* `L()` as a replacement for the `Length` property on arrays, and the `Count` property on `IList<T>`
* `s()` as a replacement `System.Object.ToString()`
* `Int32.s(S f)` is an alias for `Int32.ToString(string format)`
* `Double.s(S f)` is an alias for `Double.ToString(string format)`
* `UInt33.s(S f)` is an alias for `UInt32.ToString(string format)`
* `DateTime.s(S f)` is an alias for `DateTime.ToString(string format)`

# Under consideration

The following changes are **under consideration**, but _not yet adopted_ and should not yet be used.

* Using `e` (short for `each`) as an alias for the `foreach` keyword. The justification for this (aside from saving 6 bytes) is it's often shorter to use a lamdba expression on a linq method, which causes you to mutate what would have been good code into... something else. Introducing `e` could flip this back the other way.
* Type inference on the `R()` family of functions (default to `System.String` if a definite type cannot be inferred). The reason to hold back here is we can't actually implement it right now without changing the compiler. Most other proposed changes could potentially be implemented by including a source file at the top of the program with some `using` directives, extension methods, and a few lines of warm-up code (Yes, extension properties and static extension methods are also not a thing. But maybe they should be). But C# methods must have a known return type, and so this requires lower-level changes to the compiler.
* More shortcuts around arrays and Lists.
* More shortcuts around DateTime math

More is possible. We could create single-character keywords as aliases for _**all**_ of the C# built in keywords, as well as more common types, methods, properties. However, this is held in balance against the language remaining simple and regonizable to C# (and other) developers.

# Example

[This Stack Exchange Code Golf C# answer](https://codegolf.stackexchange.com/a/115112/58322) currently requires 127 bytes. The below SlimSharp code shortens it to 56 bytes:

```
for(;;)P($"{TP("2019-3-31")-T.Now:ddd\\:hh\\:mm\\:ss}");
```

