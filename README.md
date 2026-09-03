# Nada

**Nada** is a transpiler that converts Spanish-keyword programming syntax into valid, executable C# code. It is being developed as my A-Level Computer Science coursework project (NEA).

## Why Nada exists

Spanish-speaking students who want to learn programming face a real barrier before they even start: almost every mainstream language — Python, C, C++, Java, C# — uses English keywords. According to the TIOBE index (July 2026), these five languages make up the majority of global usage. In the UK, 100% of state school students have access to programming as part of the curriculum. In Spain, that figure drops to 35–40%, and the language barrier is a genuine contributing factor.

Existing solutions don't fully solve this:

- **Latino** translates syntax to Spanish but doesn't map cleanly onto the English keywords used elsewhere (e.g. `escribir` means "write," not "print"), meaning students still have to relearn vocabulary when they move to a mainstream language.
- **Si** translates Spanish syntax correctly and consistently, but requires command line knowledge to even run, and its error messages are in English — making it inaccessible to the complete beginners it's meant for.

**Nada** is built to solve both problems at once: Spanish keywords that map sensibly onto their English/mainstream-language equivalents, and a genuinely beginner-friendly way to run the code, with no command line and no English required to understand what went wrong.

## How it works

Nada source code is written using Spanish keywords (`si`, `mientras`, `imprimir`, `entero`, `doble`, `cadena`, and so on). It's compiled directly after input and the output is shown to the user — the aim is not to build large, complex programs, but to give beginners a genuine taste of what programming can do.

The pipeline works in stages:

1. **Lexer** — reads the raw Nada source and breaks it into tokens, with error handling so malformed input doesn't crash the program.
2. **Parser** — takes the tokens and builds an Abstract Syntax Tree (AST) using recursive descent parsing, correctly handling operator precedence (e.g. multiplication binding tighter than addition) and nested expressions.
3. **Code generation** — walks the AST and produces equivalent, valid C# code.
4. **Execution** — the generated C# is compiled and run using the Roslyn compiler API, with the output shown directly to the user.
5. **IDE** — a simple, IDLE-style interface (WinForms, with a Blazor version planned for browser-based, no-download access) so beginners and teachers can use Nada without any setup or command line knowledge.

## Project status

This project is a work in progress, built and documented as part of my ongoing A-Level coursework.

- [x] Lexer — complete, with keyword mapping, multi-character operator handling, and string/number literal parsing
- [x] Expression parsing — recursive descent parser handling operator precedence for `+`, `-`, `*`, `/`
- [ ] Statement parsing — `si` / `sino`, `mientras`, `imprimir`, variable declarations
- [ ] Bracketed expressions
- [ ] Code generation to valid C#
- [ ] Roslyn compilation and execution
- [ ] IDE (WinForms)
- [ ] Browser-based version (Blazor)

## Example

Input (Nada):
```
entero x = 5
si (x menorque 10) {
    imprimir "x is small"
}
```

Planned output (generated C#):
```csharp
int x = 5;
if (x < 10) {
    Console.WriteLine("x is small");
}
```

## Technical notes

- Written in C#
- Uses a hand-written lexer and recursive descent parser — no parser generator libraries
- Planned use of `Microsoft.CodeAnalysis.CSharp.Scripting` (Roslyn) for dynamic compilation and execution of generated code

## Author

Built by Henry, as part of A-Level Computer Science coursework.
