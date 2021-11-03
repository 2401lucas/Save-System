# Simple C# Save and Load System
A simple C# Saving and Loading System, following the SOLID principles. [Read more about the SOLID principles here](https://en.wikipedia.org/wiki/SOLID)

## It is compatable with both Unity and C# projects. 

## Template Script
SaveTemplate is the default script for the Save System 

# The Setup
Create a script, inherit from SaveTemplate.cs and implement the abstract methods. There are 3 methods that need to be implemented for the save system to be functional.

### File Path
The File Path is used in the saving and loading of fIles.

Update the File Path to ```public override string filePath => "playerSave";```

### Gettting the Data
The GetData method returns all of the variation, or data, in a string array to be written to a file.

A const char, named DataSplitter, is used as a split between the variables, so that it can easily be split once the data needs to be interpreted.

### Interpretting the Data
The InterpretData method recieves all of the data in a save file, and is responsible for splitting, parsing and assigning the data to its respective variables.

If the data is empty or null, we default to the default values.

If it is not empty or null, the data is split using the constant DataSplitter and then parsed using the methods on SaveTemplate.


### Default Variables
The default variables are assigned when the variables are declared. 


# Example

PlayerSaveData.cs is an example of how to implement this. The save data can be created in a GameManager for instance, and once loaded can be accessed directly to modify the data.



## It's as simple as that!
