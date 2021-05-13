# Simple C# Save and Load System
It has the ability to track achievements, load data from several files and modify data without needing to modify the whole Object. 

## It is compatable with Unity and C# projects. 

## Template Script
It comes with the premade struct "Default Data", this is so that you can easily understand how the script works and implement new data structs easier.   

# The Setup

## GameManager.cs
The GameManager should call the LoadData method on the DataManager on game load

## DataManager.cs
![image](https://user-images.githubusercontent.com/32739337/118184117-534e0d80-b411-11eb-85fe-81ae0ee9ef9b.png)

To Start, create a const string named "/yourDesiredFilepath.txt", this is the filePath to your save file

![image](https://user-images.githubusercontent.com/32739337/118184464-c6578400-b411-11eb-927d-472d3893bff6.png)

Then, create your struct, and add in your desired variables.
There are 2 Contructors and 1 methods that we will use.
The First Contructor is a normal constructor
The second constructor is used to create "default" Objects. For example, if we don't have a defaultData file and we need to initialize a new one with default variables, we can call this one to give it our default parameters. This is easier to do because if we change our data, either adding or removing variables, we only need to modify the default values in the contructor. C# doesn't allow paramaterless contructors in Structs, so we pass it a string to know we want to initialize the default variables. [Link to read more](https://stackoverflow.com/questions/333829/why-cant-i-define-a-default-constructor-for-a-struct-in-net)

The GetSafeInfo() method is for writing to file, instead of parsing thru the data externally, doing it in the struct makes it much more readable and straight forward when modifying the struct  

![image](https://user-images.githubusercontent.com/32739337/118185758-47fbe180-b413-11eb-93a0-90f6e9b065c4.png)

We will now setup the Data to be interpreted from the file.

We first check if the file exists, if it doesn't, we load default data from our special constructor. If the file does exist, we read all of the data and go thru line by line, splitting the current line at every semi colon and parsing the data to a new data object. We then call the Generic LoadData method from the StatsAndAchievements.cs script

Lastly, we want to call WriteToFile() in the SaveData method and DeleteFile() from the ResetData() method, it should resemble this
 ```
WriteToFile(defaultFilePath, StatsAndAchievements.GetDefaultData().GetSafeInfo());
DeleteFile(defaultFilePath);
 ```
## StatsAndAchievements.cs
