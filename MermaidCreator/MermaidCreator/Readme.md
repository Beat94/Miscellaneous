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
- ~~add IConfiguration~~
- fix issue with configuration
- implement reader-class
- Change Configuration(loading) in Program.cs to toolbox-function

# Use Cases
- One class in one file  
- Multiple classes in one file  
- One function in one class  
- Multiple functions in one class  
- Partial class over multiple files  
- Inheritance  
- Global variables in class  
- ~~Configuration via IConfigration~~
- Connection of classes (Association, Dependency, Aggregation, Composition, Interitance, Realisation)  
- Load Configuration (Usage of IConfiguration)  
	- Location analyzed project  
	- Definition Output (Mermaid or other - first one is Mermaid)  
	- check Configuration  
- Write file according defined output  
