# Trains Problem

This project is intended to solve the Trains Problem. 

Problem Description
-------------------
**Input:**  A directed graph where a node represents a town and an edge represents a route between two towns.  The weighting of the edge represents the distance between the two towns.  A given route will never appear more than once, and for a given route, the starting and ending town will not be the same town. For the test input, the towns are named using the first few letters of the alphabet from A to D.  A route between two towns (A to B) with a distance of 5 is represented as AB5.
 
**Output:** For test input 1 through 5, if no such route exists, output 'NO SUCH ROUTE'.  Otherwise, follow the route as given; do not make any extra stops!  For example, the first problem means to start at city A, then travel directly to city B (a distance of 5), then directly to city C (a distance of 4).
1. The distance of the route A-B-C.
2. The distance of the route A-D.
3. The distance of the route A-D-C.
4. The distance of the route A-E-B-C-D.
5. The distance of the route A-E-D.
6. The number of trips starting at C and ending at C with a maximum of 3 stops.  In the sample data below, there are two such trips: C-D-C (2 stops). and C-E-B-C (3 stops).
7. The number of trips starting at A and ending at C with exactly 4 stops.  In the sample data below, there are three such trips: A to C (via B,C,D); A to C (via D,C,D); and A to C (via D,E,B).
8. The length of the shortest route (in terms of distance to travel) from A to C.
9. The length of the shortest route (in terms of distance to travel) from B to B.
10. The number of different routes from C to C with a distance of less than 30.  In the sample data, the trips are: CDC, CEBC, CEBCDC, CDCEBC, CDEBC, CEBCEBC, CEBCEBCEBC.

Test Input:
```
AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7
```

Test Output:
```
Output #1: 9
Output #2: 5
Output #3: 13
Output #4: 22
Output #5: NO SUCH ROUTE
Output #6: 2
Output #7: 3
Output #8: 9
Output #9: 9
Output #10: 7
```

Solution
-------------------
The application starts providing instructions and ready to read the input data from the standard input (console). It creates a graph representation of the town routes and, for each input data, adds an edge into the graph. After reading and parsing all the input data, the application runs all test cases reported in the problem description and shows the corresponding outputs.

Assumptions
-------------------
- The input data is a directed graph where a node represents a town and an edge represents a route between two towns.
- The weighting of the edge represents the distance between the two towns and should be a positive number. 
- A given route should not appear more than once.
- For a given route, the starting and ending town should not be the same town.
- The towns are named using the letters of the alphabet from A to Z.
- A route between two towns (A to B) with a distance of 5 is represented as AB5.
- The user should provide either a valid route or the finishing command 'OK'.
  
Solution Structure
-------------------
The solution is structured in two projects, the first is the application itself and the latter is a test project. The application is structured in four main folders, based on the different domains of the application:

- **DataStructures:** contains generic data structures used to represent the input data.
  - **Graph:** representation of a graph, containing all vertices.
  - **Edge:** represents an edge, containing a destination vertex and weight.
  - **Vertex:** represents a node in the graph, containing a value and a list of edges.
  - **GraphBuilder:** separates the construction of a graph object from its representation.
  - **DirectedGraphBuilder:** responsible to construct a directed graph.
- RoutesCalculators:** relates to route calculations over a graph structure.
  - **ExactStopsRoutesCalculator:** computes possible routes with a given number of stops.
  - **MaxDistanceRoutesCalculator:** computes possible routes within a max distance.
  - **MaxStopsRoutesCalculator:** computes possible routes within a max number of stops.
  - **RouteDistanceCalculator:** computes the distance of a given route.
  - **ShortestRouteDistanceCalculator:** computes the shortest route distance.
- **TestCases:** relates to executing the application and the test cases of the problem.
  - **TestCasesExecuter:** responsible to execute all test cases.
  - **TrainsProblemApplication:** singleton representing the application itself.
- **TownRoutes:** relates to input data reading, parsing, and validation.
  - **InputErrorMessages:** error messages related to input validation.
  - **RouteInputParser:** responsible to parse the input.
  - **RouteModel:** represents a town route.
  - **RoutesConsoleReader:** responsible to read the input data from the console.
  - **RouteValidator:** handles input validation.

Running Instructions
-------------------
- If you are using Visual Studio, run the Main method of the Program class to start the application.
- If you wish to run the project using the command line, go to the project folder “TrainsProblem” and run the command “dotnet run”.

Tests
-------------------
The unit test classes are placed inside the "TrainsProblemTests" project, with the same structure as the source files. 
- If you are using the Visual Studio, run the tests by clicking “Run All” in the “Test Explorer” window.
- If you are using the CLI, run the command “dotnet test” within the “TrainsProblemTests” folder.

Dependencies
-------------------
- C#
- .NET Core 2.1 SDK
