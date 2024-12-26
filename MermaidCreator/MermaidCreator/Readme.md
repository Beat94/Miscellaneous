# Documentation of MermaidCreator
This project creates out of dotnet projects a class diagram.

# notation
'+ Public'  
'- Private'  
'# Protected'  
'~ Package'

# Link
https://mermaid.js.org/syntax/classDiagram.html

# toDo
- fix issue with configuration
- ~~add IConfiguration~~
- ~~implement reader-class~~
- ~~Change Configuration(loading) in Program.cs to toolbox-function~~

# Use Cases
- Connection of classes (Association, Dependency, Aggregation, Composition, Interitance, Realisation)  
- Load Configuration (Usage of IConfiguration)  
	- Location analyzed project  
	- Definition Output (Mermaid or other - first one is Mermaid)  
	- check Configuration  
- Write file according defined output  
- Inheritance  
- ~~Configuration via IConfigration~~
- ~~One class in one file~~
- ~~Multiple classes in one file~~
- ~~One function in one class~~
- ~~Multiple functions in one class~~
- ~~Partial class over multiple files~~
- ~~Global variables in class~~
