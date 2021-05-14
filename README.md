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

Then create your struct and add in your desired variables.
There are 2 Contructors and 1 method that we will use.
The First Contructor is a normal constructor.

The second constructor is used to create our "default" Objects with preset values. For example, if we don't have a defaultData file and we need to initialize a new one with preset variables, we can call this one. C# doesn't allow paramaterless contructors in Structs, so we pass it a string to know we want to initialize the default variables. [Link to read more](https://stackoverflow.com/questions/333829/why-cant-i-define-a-default-constructor-for-a-struct-in-net) This is easier to do because if we change our data, either adding or removing variables, we only need to modify the default values in the contructor.

The GetSaveInfo() method is for writing to file, instead of parsing thru the data externally, doing it in the struct makes it much more readable and straight forward when modifying the struct  

![image](https://user-images.githubusercontent.com/32739337/118185758-47fbe180-b413-11eb-93a0-90f6e9b065c4.png)

We will now setup the Data to be interpreted from the file.

We first check if the file exists, if it doesn't, we load default data from our special constructor. If the file does exist, we read all of the data and go thru line by line, splitting the current line at every semi colon and parsing the data to a new data object. We then call the Generic LoadData method from the StatsAndAchievements.cs script

![image](https://user-images.githubusercontent.com/32739337/118199615-d7ac8a80-b429-11eb-8818-ba283686c550.png)

Lastly, we want to call WriteToFile() in the SaveData method and DeleteFile() from the ResetData() method, it should resemble this
 ```
WriteToFile(defaultFilePath, StatsAndAchievements.GetDefaultData().GetSafeInfo());
DeleteFile(defaultFilePath);
 ```
## StatsAndAchievements.cs
![image](https://user-images.githubusercontent.com/32739337/118199656-e98e2d80-b429-11eb-97d6-2de46cf93e4b.png)

The first thing to do is to create our variable for our data the we will use, we will do this for all of the data that the data manager loads in. This is so that all of the variables that are going to be persistant are in the same place, for clarity.

![image](https://user-images.githubusercontent.com/32739337/118199748-28bc7e80-b42a-11eb-9de9-da804c0a9164.png)

Next, we will want to setup the Mutators for our data, in this example default data has 2 variables and we have a mutator for both.

![image](https://user-images.githubusercontent.com/32739337/118200032-a5e7f380-b42a-11eb-8df7-7776bfb19623.png)

We will also have a method that returns our data that has been modified so that the entire data can be accessed easily. This is for the data manager saving and could also be used if you wanted to get all of the players settings.

![image](https://user-images.githubusercontent.com/32739337/118201014-e9dbf800-b42c-11eb-93c8-9d900f6dbb41.png)

We also want to add our new data into our generic LoadData method that will set the data to the variable we created. We want to check if the passed data is of the right data struct, and if it is, we cast it to an object to cast it back into the struct type. This is done so that the compiler knows for certain this is the right data.

## It's as simple as that!
