# **Regex Simple Builder**
## **Overview**
The Regex Simple Build framework is a simple builder for regular expression strings.

### **Why**
Regular expressions are powerful tools for interacting with strings that yield impressive results for develops.
However, many developers have expressed frustration with the readability of regular expressions, describing them as hard to read, especially as they growth more complicated. 

### **Goal**
It's goal to provide a more human-readable method of producing regular expressions in code.

### **Why "Simple" Builder**
While this may change in the future, this project will provide target the most common regular expression functions. This is mainly to keep the project maintainable.

There is the ability for a developer to add raw regex to the builder for more complex tasks, however at that point it might be easier to
simply compose the regex as a string if the framework does not offer any clear benefit.

## **Usage**

## **Notes**
1. There is currently no intention to add functionality to allow the removing of a regex element from a builder once added.
The rational being that this function should not be needed.
The purpose of this tool is allow the defining of a regex search in a more readable form, not to preform complex 
2. In some cases the code may attempt to optimise on render. For instance a repeater object of "{0,1}" will render "?" instead
3. It is not recommended to use the builder to render strings in high usage areas of codes, like loops, high traffic endpoints, or anywhere memory usage may become a premium.
Instead, it recommended the build be done once and the resulting Regex object be stored in a singleton pattern or similar
4. As to the above point, it is recommended that the "Compiled" option be set where possible

