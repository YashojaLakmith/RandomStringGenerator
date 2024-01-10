# RandomStringGenerator

A simple .NET Standard 2.1 library for generating a random string from a given set of characters.

### Usage

```csharp
using RandomStringGenerator;

// Implicitely ignore duplicates in input character set.
string output1 = Generator.GenerateRandomString("somestring", 10)

// Explicitely allow duplicates in input character set.
string output2 = Generator.GenerateRandomString("somestring", 10, false)
```