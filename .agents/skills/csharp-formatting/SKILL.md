---
name: csharp-formatting
description: Use the repository's templates/.editorconfig file as the template for formatting a C# project with dotnet format until no warnings or messages remain.
user-invocable: true
---

# C# Formatting

Use this skill when the task is to format a C# project so that `dotnet format` completes without remaining warnings or messages.

## Intent

Use the bundled [templates/.editorconfig](.editorconfig) as the template for formatting and style, then copy it into the target project root before running `dotnet format`.

## Template

The attached [templates/.editorconfig](.editorconfig) is the formatting template for this skill. It must be copied into the project being formatted so the target project uses the same indentation, spacing, newline, analyzer, and naming rules.

## Procedure

1. Locate the project or solution root that should be formatted.
2. Copy the bundled [templates/.editorconfig](.editorconfig) into the target project or solution root.
3. Run `dotnet format --severity info` against the solution or project that owns the C# files.
4. if statements with only one statement should be formatted without braces, e.g.:
   ```csharp
   if (condition) DoSomething();
   ```
5. Re-run `dotnet format --severity info --verify-no-changes` to confirm the tree is clean.
6. If warnings or messages remain, fix the source files rather than suppressing the output.
7. Repeat until `dotnet format --severity info` reports no remaining issues for the targeted project.

## Rules

- Treat `.editorconfig` as the governing style contract.
- Prefer formatting and code-style changes that remove analyzer messages instead of leaving them as pending suggestions.
- Do not weaken analyzers or style settings just to silence `dotnet format`.
- Keep the edits minimal and localized to the files reported by `dotnet format`.
- If a project-wide rule conflicts with a file-specific exception, follow the more specific `.editorconfig` scope.

### for XAML
- use Name instead of x:Name for XAML elements, unless the task explicitly requires x:Name.
- the first attribute of a XAML element should be on the same line as the opening tag.
- align XAML attributes in a single line, as long as the width does not exceed 80. In that case, break the line after that attribute, 
  indent the next line.
- add new lines only if the width of the line exceeds 80 characters.
- add a white space before the closing tag of a XAML element.
- attributes should always be indented on a new line to align with the attribute names.
- attributes for events should always be last placed on a new line.


## Review Checklist

- Was the correct solution or project formatted?
- Were the repository's `.editorconfig` rules applied consistently?
- Does `dotnet format --severity info --verify-no-changes` pass for the targeted scope?
- Were any remaining warnings or messages resolved in code instead of being ignored?