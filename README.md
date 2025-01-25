Expense Tracker Application
An advanced Expense Tracker Application built with C# in Visual Studio 2022, designed to help users efficiently manage their financial transactions, track debts, and categorize expenses. This project demonstrates the use of object-oriented programming concepts, robust data handling, and JSON-based data storage for a seamless user experience.

Features
-Transaction Management: Add, view, and categorize transactions with custom tags.
-Debt Tracking: Monitor debts and payments with detailed records.
-Tagging System: Assign tags to transactions for better organization.
-Dashboard Overview: View summaries of inflows, outflows, and pending debts.
-JSON Data Storage: All data is stored in a JSON file, ensuring easy retrieval and portability.

Project Structure
The project consists of the following main components:

1. Models:

Tag: Represents tags with properties like Id, Name, and Description.
TransactionItem: Manages transaction details, including Title, Amount, Type, and Tag.
TransactionMoney: Handles the financial data with properties like Amount, Category, and Tags.

2. Methods:

Add, update, and delete transactions.
Calculate totals for inflows, outflows, and debts.
Apply filtering and sorting for efficient data management.

3. Data Storage:

All data is saved and loaded from a JSON file, ensuring persistence across sessions.

Installation and Setup

1. Clone the Repository
```bash
git clone https://github.com/nischal-0016/C-sharp-.NET-software-application.git
cd C-sharp-.NET-software-application
```
2. Open the project in Visual Studio 2022:

Open Visual Studio 2022.
Navigate to File > Open > Project/Solution.
Select the .sln file from the cloned directory.

3. Build the project:

# Restore NuGet packages
nuget restore

# Build the solution
msbuild C-sharp-.NET-software-application.sln

4. Run the application:

Press F5 in Visual Studio 2022 or use the Debug button to start the application.
