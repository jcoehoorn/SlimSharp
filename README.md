# SlimSharp

SlimSharp is an esoteric programming language based on C# intended for use in Code Golf scenarios. Currently the language exists only as a specification.

The aim is **not** to compete with other esoteric programming languages intended for code golf, but rather to reduce some of the worst points of verbosity holding back C# as a language for simple code golf problems: `Console.WriteLine()`, `Console.ReadLine()`, `Replace()`, `ToLower()`, etc.

SlimSharp starts with C# 9 (including [top-level statements](https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/exploration/top-level-statements)) and includes the following features and changes:

* Implicit using directives for (so far) System, System.Collections, System.Collections.Generics, System.Text.
* The P() function (short for "Print") aliases to System.Diagnostics.Trace.WriteLine()
* The p() function (short for "print") aliases to System.Diagnostics.Trace.Write()
* ConsoleTraceListener attached by default, and configurable by the compiler to include any built-in listener, allowing for, eg file output. 
  In short, the P()/p() functions can mean whatever you need them to in terms of output, as long as they can be created with a .Net built-in TraceListener constructor. 
* The R() function (short for "read") reads a string from the Console
* The R(string prompt) function reads a string from the Console, with the included prompt.
* The RI() function reads an integer from the Console. Invalid input will throw an exception, but most code golf problems assume perfect typists.
* The RI(string prompt) function reads an integer from the Console, with the included prompt. If the input is not a valid integer it will re-prompt until a valid integer is received (potentially forever).
* The RI(string prompt, int MaxTries) function reads an integer from the Console, with the included prompt. If the input is not a valid integer, it will re-prompt up to MaxTries times, after which an exception is thrown.
* The RD() function reads a Double from the Console. Invalid input will throw an exception, but most code golf problems assume perfect typists.
* The RD(string prompt) function reads a double from the Console, with the included prompt. If the input is not a valid double it will re-prompt until a valid double is received (potentially forever).
* The RD(string prompt, int MaxTries) function reads a double from the Console, with the included prompt. If the input is not a valid double it will re-prompt up to MaxTries times, after which an exception is thrown.
* The RT() function reads a DateTime from the Console. Is not necessarily implemented using DateTime.Parse(), but must follow the documentation for the default DateTime.Parse() function. Right now, this means using the conventions of the current culture.
* The RT(string prompt) function reads a DateTime from the Console, with the included prompt. If the input is not a valid DateTime, it will re-prompt until a valid DateTime value is received (potentially forever). The same parsing rules as the base RT() function apply.
* The RT(string prompt, int MaxTries) function reads a DateTime from the Console, with the included prompt. If the input is not a valid DateTime, it will re-prompt up to MaxTries times, after which an exception is thrown. The same parsing rules as the base RT() function apply.
* `S` is a reserved keyword, aliased to System.String.
* `I` is a reserved keyword, aliased to System.Int32.
* `U` is a reserved keyword, aliased to System.UInt32.
* `D` is a reserved keyword, aliased to System.Double.
* `T` is a reserved keyword, aliased to System.DateTime.
* `O` is a reserved keyword, aliased to System.Object.
* `System.String.R()` is an alias for `System.String.Replace()`
* `System.String.S()` is an alias for `System.String.Substring()`
* `System.String.I()` is an alias for `System.String.IndexOf()`
* `System.String.l()` is an alias for `System.String.ToLower()`
* `System.String.U()` is an alias for `System.String.ToUpper()`
* `System.String.T()` is an alias for `System.String.Trim()`
* `System.String.L` is an alias for `System.String.Length`
* `System.Int32.P()` is an alias for `System.Int32.Parse()`
* `System.Double.P()` is an alias for `System.Double.Parse()`
* `System.DateTime.P()` is an alias for `System.DateTime.Parse()`. Note: `new T()` is often just as good or better, but this is useful if you have a string from elsewhere.
* `System.Int32.Mx` is an alias for `System.Int32.MaxValue` (`I.Mx`)
* `System.Int32.Mn` is an alias for `System.Int32.MinValue`
* `System.Double.Mx` is an alias for `System.Double.MaxValue` (`D.Mx`)
* `System.Double.Mn` is an alias for `System.Double.MinValue`
* `L` as an alias for the `Length` property on arrays, and the `Count` property on `IList<T>`

# Under consideration

The following changes are **under consideration**, but _not yet adopted_ and should not yet be used.

* Using `e` (short for `each`) as an alias for the `foreach` keyword. The justification for this is it's often shorter to use a lamdba expression on a linq method, which causes you to mutate what would have been good code into... something else. Introducing `e` could flip this back the other way.
* Type inference on the `R()` family of functions (default to `System.String` if a definite type cannot be inferred). The reason to hold back here is we can't actually implement it right now without changing the compiler. Most other proposed changes could potentially be implemented by including a source file at the top of the program with some `using` directives, extension methods, and a few lines of warm-up code (Yes, extension properties are also not a thing. But they should be). But C# methods must have a known return type, and so this requires lower-level changes to the compiler.
* More shortcuts around arrays and Lists.
* More shortcuts around DateTime math

More is possible. We could create single-character keywords as aliases for _**all**_ of the C# built in keywords, as well as more common types, methods, properties. However, this is held in balance against the language remaining simple and regonizable to C# (and other) developers.

# Example

[This Stack Exchange Code Golf C# answer](https://codegolf.stackexchange.com/a/115112/58322) currently requires 127 bytes. The below SlimSharp code shortens it to 57 bytes:

```
for(;;)P($"{new T(2019,3,31)-T.Now:ddd\\:hh\\:mm\\:ss}");
```

