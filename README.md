# C# Design Patterns
This is the repository for the LinkedIn Learning course C# Design Patterns. The full course is available from [LinkedIn Learning][lil-course-url].

![C# Design Patterns][lil-thumbnail-url] 
Design patterns are an important part of programming. Rather than programming solutions to every issue from scratch, developers can implement these patterns that solve common problems. In this course, instructor Richard Goforth explains the purpose and effective use of key design patterns in C#. Richard begins by discussing why design patterns make sense, what they are, and how they are grouped and categorized. He then provides an overview of the creational, behavioral, and structural Gang of Four design patterns and how they are applied in C# and .NET. Next, he takes a deeper dive into the Iterator, Factory Method, and Adapter patterns, providing hands-on challenges that help you master the application of these patterns in your own code.

There are four applicaitons in this repository.  Three applications are simple console application pattern examples, in the folders Iterator, Adapter, and Factory.

The fourth application, HPlusSports, is a sample of a more robust web application in ASP.Net core, to give a different example of using each of the patterns in a more realistic situation.  It is more complex than an application of similar functionality would be to show examples of architecture in a more fully featured, long term support application.
The web application is using an EF Core Backend to a SQLite Database file, to simplify running the application locally.

## Instructions
This repository has branches for each of the videos in the course. You can use the branch pop up menu in github to switch to a specific branch and take a look at the course at that stage, or you can add `/tree/BRANCH_NAME` to the URL to go to the branch you want to access.

## Branches
The branches are structured to correspond to the videos in the course. The naming convention is `CHAPTER#_MOVIE#`. As an example, the branch named `02_03` corresponds to the second chapter and the third video in that chapter. 
Some branches will have a beginning and an end state. These are marked with the letters `b` for "beginning" and `e` for "end". The `b` branch contains the code as it is at the beginning of the movie. The `e` branch contains the code as it is at the end of the movie. The `main` branch holds the final state of the code when in the course.

## Installing
1. To use these exercise files, you must have the .Net Core SDK 3.1 Installed
2. Clone this repository into your local machine using the terminal (Mac), CMD (Windows), or a GUI tool like SourceTree.

### Instructor

**Richard Goforth**

_Software Architect and Consultant_

Check out some of my other courses on [LinkedIn Learning](https://www.linkedin.com/learning/instructors/richard-goforth).

[lil-course-url]: https://www.linkedin.com/learning/c-sharp-design-patterns
[lil-thumbnail-url]: https://cdn.lynda.com/course/2314072/2314072-1602606433506-16x9.jpg
